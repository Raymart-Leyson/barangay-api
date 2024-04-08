CREATE PROCEDURE [dbo].[spDetails_GetDetailsbyId]
    @id INT
AS
BEGIN
    SELECT * FROM Details WHERE Details.Id = @id;
END