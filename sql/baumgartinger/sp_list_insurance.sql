USE VersicherungsDB
GO

DROP PROCEDURE IF EXISTS list_products_by_category
GO

CREATE PROCEDURE list_products_by_category @category_id INT
AS
	BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY

		IF (SELECT COUNT(*) FROM PRODUKT_KATEGORIE WHERE PRODUKT_KATEGORIE.ID = @category_id) != 1
			THROW 60000, 'invalid category id', 1

		SELECT	prods.NAME as category, BESCHREIBUNG as description,
				PREIS as price, LAUFZEIT as duration, anb.NAME as vendor_name, ADRESSE as address
				FROM PRODUKTE AS prods
					FULL OUTER JOIN PRODUKTE_ANBIETER AS prod_anb
					ON prods.ID = prod_anb.FK_ID_PRODUKTE
					FULL OUTER JOIN ANBIETER AS anb
					ON anb.ID = prod_anb.FK_ID_ANBIETER
				WHERE prods.FK_ID_PRODUKT_KATEGORIE = @category_id

		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH

		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION

	END CATCH
GO