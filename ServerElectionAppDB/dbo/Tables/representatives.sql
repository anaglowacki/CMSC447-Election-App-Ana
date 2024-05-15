CREATE TABLE [dbo].[representatives]
(
	[name]       VARCHAR (75)  NOT NULL,
    [party]      VARCHAR (50)  NULL,
    [phones]     VARCHAR (70)  NULL,
    [urls]       VARCHAR (500) NULL,
    [emails]     VARCHAR (200) NULL,
    [office]     VARCHAR (100) NULL,
    [photoUrl]   VARCHAR (250) NULL,
    [divisionId] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([name] ASC)
);
