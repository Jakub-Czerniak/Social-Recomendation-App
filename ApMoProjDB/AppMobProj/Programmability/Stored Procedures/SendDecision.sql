CREATE PROCEDURE SendDecision (@User1_ID INT, @User2_ID INT, @User1_Decision VARCHAR(4))
AS
IF EXISTS
(
	SELECT * FROM pairs
	WHERE user1_ID = @User2_ID AND user2_ID = @User1_ID
)
BEGIN 
	IF EXISTS (SELECT * FROM pairs WHERE user1_decision='y' AND user2_decision='y' )
	BEGIN
		UPDATE pairs SET pairs.user2_decision = @User1_Decision, pairs.match_date=(SELECT GETDATE()) WHERE user1_ID = @User2_ID AND user2_ID = @User1_ID
	END
	ELSE
	BEGIN
		UPDATE pairs SET pairs.user2_decision = @User1_Decision WHERE user1_ID = @User2_ID AND user2_ID = @User1_ID
	END
END
ELSE
BEGIN
INSERT INTO pairs(user1_ID, user2_ID, user1_decision) VALUES (@User1_ID, @User2_ID, @User1_Decision)
END
GO