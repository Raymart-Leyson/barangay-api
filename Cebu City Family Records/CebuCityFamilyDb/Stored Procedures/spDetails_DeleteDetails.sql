CREATE PROCEDURE [dbo].[spDetails_DeleteDetails]
	@id INT
AS
BEGIN
	DELETE FROM Details WHERE Id = @id;
END	
