CREATE PROCEDURE [dbo].[spDetails_CreateDetails]
	@FmId INT,
	@Age INT,
	@CivilStatus VARCHAR(50),
	@DateOfBirth VARCHAR(50),
	@Gender VARCHAR(50),
	@Occupation VARCHAR(50),
	@PhoneNumber VARCHAR(50),
	@Religion VARCHAR(50)
	AS
BEGIN
	INSERT INTO Details(Age, CivilStatus, DateOfBirth, Gender, Occupation, PhoneNumber, Religion, FmId) VALUES (@Age, @CivilStatus,@DateOfBirth,@Gender,@Occupation,@PhoneNumber,@Religion, @FmId);
	SELECT CAST(SCOPE_IDENTITY() as int);
END
