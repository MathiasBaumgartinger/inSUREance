/*4. PROCEDURE* produkte, kategorien DELETE*/
DROP PROCEDURE IF EXISTS usp_produkte_kategorien_delete
GO
CREATE PROCEDURE 
usp_produkte_kategorien_delete
AS 
SET NOCOUNT ON;
GO
BEGIN TRANSACTION
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

BEGIN TRY
USE database;  
--DELETE STATEMENT
DELETE 
FROM produkte
INNER JOIN produkteKategorien 
ON produkte.id_kat = produkteKategorien.id_kat
WHERE name = "WinningInsurance"; 
END TRY 

BEGIN CATCH  
    SELECT   
        
         ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
IF @@TRANCOUNT > 0  
COMMIT TRANSACTION;
GO

-- END AGNES


DROP PROCEDURE IF EXISTS usp_produkte_kategorien_update
GO
CREATE PROCEDURE 
usp_produkte_kategorien_update
AS 
SET NOCOUNT ON;
GO
BEGIN TRANSACTION
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

BEGIN TRY
USE database;  
--UPDATE STATEMENT
UPDATE 
FROM produkte
INNER JOIN produkteKategorien 
ON produkte.id_kat = produkteKategorien.id_kat
WHERE COUNT(id_kat) = 1; 
END TRY 

BEGIN CATCH  
    SELECT   
        
         ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
IF @@TRANCOUNT > 0  
COMMIT TRANSACTION;
GO

-- END AGNES


DROP PROCEDURE IF EXISTS usp_produkt_kategorien_select
GO
CREATE PROCEDURE 
usp_produkt_kategorien_select
AS 
SET NOCOUNT ON;
GO
BEGIN TRANSACTION
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

BEGIN TRY
USE database;  
--SELECT STATEMENT
SELECT 
FROM produkte
INNER JOIN produkteKategorien 
ON produkte.id_kat = produkteKategorien.id_kat
WHERE COUNT(id_kat) >= 5; 
END TRY 

BEGIN CATCH  
    SELECT   
        
         ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
IF @@TRANCOUNT > 0  
COMMIT TRANSACTION;
GO

DROP PROCEDURE IF EXISTS usp_produkt_kategorien_insert
GO
CREATE PROCEDURE 
usp_produkt_kategorien_insert
AS 
SET NOCOUNT ON;
GO
BEGIN TRANSACTION
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

BEGIN TRY
USE database;  
--INSERT STATEMENT
INSERT
FROM produkte
INNER JOIN produkteKategorien 
ON produkte.id_kat = produkteKategorien.id_kat
WHERE COUNT(id_kat) = 0; 
END TRY 

BEGIN CATCH  
    SELECT   
        
         ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

    IF @@TRANCOUNT > 0  
        ROLLBACK TRANSACTION;  
END CATCH;  
IF @@TRANCOUNT > 0  
COMMIT TRANSACTION;
GO



/*Cursor*/
DECLARE @ProdukteID INT
DECLARE @getProdukteID CURSOR

SET @getProdukteID   = CURSOR FORWARD_ONLY FOR 


SELECT id_kat
FROM produkte
INNER JOIN produkteKategorien 
ON produkte.id_kat = produkteKategorien.id_kat
WHERE name = 'test';

OPEN  @getProdukteID 
FETCH NEXT
FROM  @getProdukteID  INTO @ProdukteID 
WHILE @@FETCH_STATUS = 0

BEGIN
PRINT @ProdukteID 
FETCH NEXT
FROM @getProdukteID   INTO @ProdukteID 
END

CLOSE @getProdukteID 
DEALLOCATE @getProdukteID 





USE database
DECLARE @ProdukteID  INT
DECLARE @name VARCHAR(30)

DECLARE @getProdukteID  CURSOR


SET @getProdukteID = CURSOR FOR 
SELECT id_kat, name, beschreibung 
FROM produkte
INNER JOIN produkteKategorien 
ON produkte.id_kat = produkteKategorien.id_kat
FOR UPDATE OF produkte.name;
OPEN @getProdukteID

FETCH NEXT
FROM @getProdukteID INTO @ProdukteID, @name;

WHILE @@FETCH_STATUS = 0

BEGIN
SELECT @TEMP = 'abgerissen';
UPDATE produkte SET produkte.name = @TEMP WHERE CURRENT OF @getProdukteID
PRINT cast(@ProdukteID) + ' ' +  @name
FETCH NEXT
FROM @getProdukteID  INTO @ProdukteID , @name;

END

CLOSE @getProdukteID ;
DEALLOCATE @getProdukteID;
