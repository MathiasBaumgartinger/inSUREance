USE VersicherungsDB
GO

DROP PROCEDURE IF EXISTS create_berater
GO
DROP FUNCTION IF EXISTS func_berater_name_by_anbieter_id
GO
DROP INDEX IF EXISTS BERATER.index_berater_anbieter_id
GO

CREATE PROCEDURE create_berater @user_name VARCHAR(30), @anbieter_name VARCHAR(30)
AS
	BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
		
	BEGIN TRY
		DECLARE @tmp_user_id INT = (SELECT ID FROM view_users_id_name WHERE NAME = @user_name)
		IF @tmp_user_id = NULL
			throw 60000, 'username not existing', 1
		DECLARE @tmp_anb_id INT = (SELECT ID FROM ANBIETER WHERE NAME = @anbieter_name)
		IF @tmp_anb_id = NULL
			throw 60000, 'anbieter not existing', 1
		
		INSERT INTO BERATER (FK_ID_USERS,FK_ID_ANB)
		VALUES (@tmp_user_id,@tmp_anb_id)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION
	END CATCH
GO

CREATE INDEX index_berater_anbieter_id ON dbo.BERATER(FK_ID_ANB)
GO

CREATE FUNCTION dbo.func_berater_name_by_anbieter_id (@anbieter_id INT)
RETURNS TABLE
AS
	RETURN(SELECT USERS.NAME
	FROM USERS INNER JOIN BERATER
	ON USERS.ID = BERATER.FK_ID_USERS
	WHERE BERATER.FK_ID_ANB = @anbieter_id)
GO
