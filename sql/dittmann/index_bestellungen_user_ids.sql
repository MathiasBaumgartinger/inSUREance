USE VersicherungsDB
GO

DROP INDEX IF EXISTS BESTELLUNGEN.index_bestellungen_users
GO

CREATE NONCLUSTERED INDEX index_bestellungen_users
ON dbo.BESTELLUNGEN (FK_ID_USERS)