CREATE PROCEDURE [dbo].[spFamilyMembers_DeleteFamilyMembers]
	@name VARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT * FROM FamilyMembers WHERE Name = @name)
	BEGIN
		DELETE FROM FamilyMembers WHERE Name = @name;
	END
	ELSE
	BEGIN
		SELECT CAST(0 AS INT);
	END
END	
