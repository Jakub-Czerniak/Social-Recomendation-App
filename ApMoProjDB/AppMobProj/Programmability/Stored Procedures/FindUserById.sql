CREATE PROCEDURE FindUserById @ID INT
AS
SELECT users.name, users.phone_number as PhoneNumber FROM users
WHERE users.ID = @ID
GO