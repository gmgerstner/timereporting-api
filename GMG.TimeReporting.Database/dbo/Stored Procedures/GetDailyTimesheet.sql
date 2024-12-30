CREATE PROCEDURE [dbo].[GetDailyTimesheet]
  @WorkDate DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @WorkDate IS NULL
      SET @WorkDate = (SELECT CONVERT(VARCHAR(10), getdate(), 111))

    SELECT
      *
    INTO
      #CurrentTimeEntries
    FROM
      TimeEntries
    WHERE
      StartTime BETWEEN @WorkDate AND Dateadd(DAY, 1, @WorkDate)

    SELECT
      te1.TimeEntryId,
      (SELECT TOP 1
         te3.TimeEntryId
       FROM
         #CurrentTimeEntries te3
       WHERE
        te3.StartTime > te1.StartTime
       ORDER  BY
        te3.StartTime) NextTimeEntryId
    INTO
      #CrossLinks
    FROM
      #CurrentTimeEntries te1

    SELECT
      te1.Title,
      Datediff(MINUTE, te1.StartTime, Isnull(te1.EndTime, te2.StartTime)) / 60.0 Hours
    INTO
      #Totals
    FROM
      #CurrentTimeEntries te1
      INNER JOIN #CrossLinks cl
              ON te1.TimeEntryId = cl.TimeEntryId
      LEFT JOIN #CurrentTimeEntries te2
             ON cl.NextTimeEntryId = te2.TimeEntryId

    SELECT
      Title,
      Sum(Hours) TotalHours
    FROM
      #Totals
    GROUP  BY
      Title

    DROP TABLE #CurrentTimeEntries
    DROP TABLE #CrossLinks
    DROP TABLE #Totals
END

