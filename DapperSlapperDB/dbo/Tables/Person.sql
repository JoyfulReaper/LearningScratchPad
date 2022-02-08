CREATE TABLE [dbo].[Person]
(
	[PersonId] INT IDENTITY NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NULL, 
    [AddressId] INT NULL, 
    CONSTRAINT [FK_Person_ToAddress] FOREIGN KEY ([AddressId]) REFERENCES [Address]([AddressId])
)
