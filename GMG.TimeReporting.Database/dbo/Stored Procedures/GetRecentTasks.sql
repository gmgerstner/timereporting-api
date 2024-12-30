CREATE PROCEDURE GetRecentTasks
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Favorites_Xml XML = '
	<rows>
		<row Title="Team meeting" />
		<row Title="Admin" />
		<row Title="Daily Scrum" />
		<row Title="Qualtrax" />
	</rows>
	'
	SELECT Tbl.Col.value('@Title', 'varchar(max)') Title
	INTO #Favorites
	FROM @Favorites_Xml.nodes('/rows/row') Tbl(Col)  

	SELECT 
		Title,
		Max(StartTime) LastStarted
	INTO #Results
	FROM [dbo].[TimeEntries]
	GROUP BY Title
	ORDER BY LastStarted DESC, Title

	UPDATE #Results
	SET LastStarted = GETDATE()
	WHERE #Results.Title IN (SELECT Title FROM #Favorites)

	SELECT 
		Title,
		LastStarted
	FROM #Results
	ORDER BY LastStarted DESC, Title

	DROP TABLE #Favorites
	DROP TABLE #Results
END
