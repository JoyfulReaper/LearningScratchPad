CREATE PROCEDURE [dbo].[spGetPeople]
AS
BEGIN
	SELECT
		p.[PersonId], 
		p.[FirstName], 
		p.[LastName], 
		p.[AddressId],
		a.AddressId as Address_AddressId,
		a.City as Address_City,
		a.StateAbr as Address_StateAbr,
		a.Zip as Address_Zip
	FROM
		Person p
	INNER JOIN
		[Address] a on a.AddressId = p.AddressId
END
