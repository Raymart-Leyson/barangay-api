CREATE PROCEDURE [dbo].[spDetails_UpdateDetails]
	@id INT,
	@Age INT,
	@CivilStatus VARCHAR(50),
	@Occupation VARCHAR(50),
	@PhoneNumber VARCHAR(50),
	@Religion VARCHAR(50)
AS
BEGIN
	UPDATE Details SET Age = @Age, CivilStatus = @CivilStatus,Occupation = @Occupation,PhoneNumber = @PhoneNumber,Religion = @Religion WHERE Id = @Id;
	SELECT * FROM Details WHERE Id = @Id;
END
