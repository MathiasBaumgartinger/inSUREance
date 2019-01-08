USE VersicherungsDB
Go

IF EXISTS (select * from sys.triggers where name = 'safety_trigger_table')
BEGIN
	DROP TRIGGER safety_trigger_table ON DATABASE
	PRINT('SAFETY TRIGGER #TABLE DELETED')
END
GO 
IF EXISTS (select * from sys.server_triggers where name = 'safety_trigger_db')
BEGIN
DROP TRIGGER safety_trigger_db ON ALL SERVER
	PRINT('SAFETY TRIGGER #DATABASE DELETED')
END
GO 


CREATE TRIGGER safety_trigger_table
ON DATABASE
FOR DROP_TABLE, ALTER_TABLE
AS
	RAISERROR ('You must disable Trigger "safety_trigger_table" to drop or alter tables!',10, 1)
	ROLLBACK
GO
PRINT('SAFETY TRIGGER #TABLE CREATED')
GO

CREATE TRIGGER safety_trigger_db
ON ALL SERVER
FOR DROP_DATABASE
AS
	RAISERROR ('You must disable Trigger "safety_trigger_table" to drop databases!',10, 1)
	ROLLBACK
GO
PRINT('SAFETY TRIGGER #DATABASE CREATED')
GO