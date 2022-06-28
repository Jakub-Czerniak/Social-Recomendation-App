CREATE PROCEDURE FindBestMatchByInerests (@ID INT)
AS
SELECT TOP 1 users.ID ,users.name, count(interests.name)
FROM users_interests ui1 
INNER JOIN users_interests ui2 ON ui1.interest_id = ui2.interest_id
INNER JOIN users ON users.ID = ui2.user_id
INNER JOIN interests ON interests.ID = ui1.interest_id
FULL OUTER JOIN pairs ON (pairs.user1_ID = users.ID AND pairs.user2_ID =@id) OR (pairs.user2_ID = users.ID AND pairs.user1_ID =@id)
WHERE @ID = ui1.user_id AND ((pairs.user1_ID IS NULL AND pairs.user2_ID IS NULL) OR (pairs.user2_ID = @ID AND pairs.user2_decision IS NULL)) AND NOT users.ID = @ID 
AND @ID <> ui2.user_id
GROUP BY users.name, users.ID
ORDER BY count(interests.name) DESC
GO