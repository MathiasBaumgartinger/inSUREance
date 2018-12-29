USE VersicherungsDB
GO

DROP PROCEDURE IF EXISTS add_rating_for_vendor
GO

CREATE PROCEDURE add_rating_for_vendor @user_id INT, @vendor_id INT, @stars INT
AS
	BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

	BEGIN TRY

		IF @stars < 1 OR @stars > 5
			THROW 60000, 'stars must be between 1 and 5', 1

		IF (SELECT COUNT(*) FROM USERS WHERE USERS.ID = @user_id) != 1
			THROW 60000, 'invalid user id', 1

		IF (SELECT COUNT(*) FROM ANBIETER WHERE ANBIETER.ID = @vendor_id) != 1
			THROW 60000, 'invalid vendor id', 1

		INSERT INTO BEWERTUNG_ANBIETER (FK_ID_USERS, FK_ID_ANBIETER, STERNE)
		VALUES (@user_id, @vendor_id, @stars)

		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH

		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION

	END CATCH
GO