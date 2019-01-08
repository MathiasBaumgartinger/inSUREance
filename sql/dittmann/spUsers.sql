USE VersicherungsDB
GO

DROP PROCEDURE IF EXISTS create_user
GO
DROP PROCEDURE IF EXISTS update_user
GO
DROP PROCEDURE IF EXISTS check_user_login
GO
DROP VIEW IF EXISTS view_users_id_name
GO

CREATE PROCEDURE create_user @user_name VARCHAR(30), @password VARCHAR(30),@birthday DATE, @wohnort VARCHAR(50), @is_admin BIT, @is_berater BIT
AS
	BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

	BEGIN TRY
		IF @user_name = '' or @password='' or @birthday = '1900-01-01' or @birthday = NULL or @wohnort='' or @is_admin = NULL or @is_berater = NULL
			THROW 60000, 'one of the given variables is null or empty', 1

		IF @password LIKE '%[^A-Z0-9]%'
			THROW 60000, 'only letters and numbers allowed in a password', 1
		IF LEN(@password) < 1 or LEN(@password) > 30 
			THROW 60000, 'minimum 1, max 30 characters in pw allowed', 1

		IF LEN(@wohnort) < 5 --(zum testen)
			THROW 60000, 'place of residence not possible', 1

		DECLARE @tmp_name INT = (SELECT count(*) FROM USERS WHERE NAME = @user_name)
		IF @tmp_name <> 0
			THROW 60000, 'username already exists', 1

		INSERT INTO USERS (NAME,PASSWORDHASH,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER)
		VALUES (@user_name,HASHBYTES('SHA2_512',@password),@birthday,@wohnort,@is_admin,@is_berater)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION
	END CATCH
GO


CREATE PROCEDURE update_user @user_name VARCHAR(30), @password VARCHAR(30),@birthday DATE, @wohnort VARCHAR(50), @is_admin BIT, @is_berater BIT
AS
	BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

	BEGIN TRY
		IF @user_name = '' or @password='' or @birthday = '1900-01-01' or @birthday = NULL or @wohnort='' or @is_admin = NULL or @is_berater = NULL
			THROW 60000, 'one of the given variables is null or empty', 1

		IF @password LIKE '%[^A-Z0-9]%'
			THROW 60000, 'only letters and numbers allowed in a password', 1
		IF LEN(@password) < 1 or LEN(@password) > 30 
			THROW 60000, 'minimum 1, max 30 characters in password allowed', 1

		IF LEN(@wohnort) < 1 --(zum testen)
			THROW 60000, 'place of residence not possible', 1

		DECLARE @tmp int = (SELECT COUNT(*) FROM USERS WHERE NAME = @user_name)
		IF @tmp <> 1
			THROW 60000, 'user does not exist', 1

		UPDATE USERS 
		SET 
		NAME=@user_name,PASSWORDHASH=HASHBYTES('SHA2_512',@password),GEBURTSTAG=@birthday,WOHNORT=@wohnort,IS_ADMIN=@is_admin,IS_BERATER=@is_berater
		WHERE NAME = @user_name

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION
	END CATCH
GO

CREATE PROCEDURE check_user_login @user_name VARCHAR(30), @password VARCHAR(30)
AS
	BEGIN
	SET NOCOUNT ON

	-- 0 failure, 1 user, 2 adviser, 3 admin
	SELECT CASE WHEN EXISTS(SELECT NULL FROM USERS WHERE NAME=@user_name AND PASSWORDHASH=HASHBYTES('SHA2_512',@password))
		THEN CAST(1 AS BIT)
		ELSE CAST(0 AS BIT)
		END
	END
GO

CREATE VIEW view_users_id_name
AS
	SELECT USERS.ID, USERS.NAME
	FROM USERS
GO