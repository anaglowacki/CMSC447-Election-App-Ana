CREATE TABLE [dbo].[app_user]
(
	[username] VARCHAR (20)  NOT NULL,
    [password] VARCHAR (20)  NOT NULL,
    [email]    VARCHAR (50)  NULL,
    [address]  VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([username] ASC)
);
