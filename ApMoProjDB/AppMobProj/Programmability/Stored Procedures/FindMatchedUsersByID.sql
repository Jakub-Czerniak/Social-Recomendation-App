CREATE PROCEDURE FindMatchedUsersById @id INT
AS
SELECT users.ID, users.name FROM users
INNER JOIN pairs ON (pairs.user1_ID = users.ID AND pairs.user2_ID =@id) OR (pairs.user2_ID = users.ID AND pairs.user1_ID =@id)
WHERE NOT users.ID = @id AND pairs.match_date IS NOT NULL
ORDER BY pairs.match_date DESC
GO