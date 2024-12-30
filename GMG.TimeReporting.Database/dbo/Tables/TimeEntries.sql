CREATE TABLE [dbo].[TimeEntries] (
    [TimeEntryId] INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (100) NOT NULL,
    [StartTime]   DATETIME      NOT NULL,
    [EndTime]     DATETIME      NULL,
    CONSTRAINT [PK_TimeEntries] PRIMARY KEY CLUSTERED ([TimeEntryId] ASC)
);

