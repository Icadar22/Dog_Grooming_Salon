CREATE TABLE [dbo].[Owner] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [FirstName] NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [Phone]     NVARCHAR (MAX) NULL,
    [Email]     NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED ([ID] ASC)
);

