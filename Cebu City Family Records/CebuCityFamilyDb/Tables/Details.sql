CREATE TABLE [dbo].[Details]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Age] INT NOT NULL, 
    [CivilStatus] VARCHAR(50) NOT NULL, 
    [DateOfBirth] VARCHAR(50) NOT NULL,
    [Gender] VARCHAR(50) NOT NULL,
    [Occupation] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(50),
    [Religion] VARCHAR(50) NOT NULL,
    [FmId] INT NOT NULL,
    CONSTRAINT [FK_Details] FOREIGN KEY ([FmId]) REFERENCES [FamilyMembers]([Id]) ON DELETE CASCADE
)
