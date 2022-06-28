CREATE PROCEDURE FindInterestsByUserId (@UserID INT)
AS
SELECT interests.ID,interests.name FROM interests
INNER JOIN users_interests ON users_interests.interest_id = interests.ID
INNER JOIN users ON users.ID = users_interests.user_id
WHERE users.ID = @UserID
GO