use VersicherungsDB
go

DROP VIEW IF EXISTS view_list_user
GO

DROP VIEW IF EXISTS view_list_consultant
GO

DROP VIEW IF EXISTS view_list_admin
GO

CREATE VIEW view_list_user
AS
	SELECT * FROM USERS
	WHERE
		IS_ADMIN = 0 AND IS_BERATER = 0
GO

CREATE VIEW view_list_consultant
AS
	SELECT * FROM USERS
	WHERE
		IS_BERATER = 1
GO

CREATE VIEW view_list_admin
AS
	SELECT * FROM USERS
	WHERE
		IS_ADMIN = 1
GO