CREATE PROCEDURE [dbo].[spFamilyMembers_UpdateFamilyMembers]
	@Id INT,
	@Name VARCHAR(50),
	@FId INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM FamilyMembers WHERE Id = @Id)
	BEGIN
		SELECT CAST(0 AS INT);
	END
	ELSE
	BEGIN
		IF EXISTS (SELECT * FROM FamilyMembers WHERE Name = @Name AND FId = @FId)
		BEGIN
			SELECT CAST(0 as int);
		END
		ELSE
		BEGIN
			UPDATE FamilyMembers SET Name = @Name WHERE Id = @Id;
			SELECT * FROM FamilyMembers WHERE Id = @Id;
		END
	END
	
END
