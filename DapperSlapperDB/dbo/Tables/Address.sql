CREATE TABLE [dbo].[Address]
(
	[AddressId] INT IDENTITY NOT NULL PRIMARY KEY, 
    [City] VARCHAR(50) NULL, 
    [StateAbr] VARCHAR(2) NULL, 
    [Zip] VARCHAR(5) NULL
)
