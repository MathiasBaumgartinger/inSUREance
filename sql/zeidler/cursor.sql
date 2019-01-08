---Forward Only Cursor

DECLARE @BestellungenID INT
DECLARE @getBestellungenID CURSOR

SET @getBestellungenID  = CURSOR FORWARD_ONLY FOR 


SELECT id_best
FROM Bestellungen
INNER JOIN User 
ON Bestellungen.id_user = Bestellungen.fk_id_user
WHERE tsmp > '01.12.2018';

OPEN @getBestellungenID 
FETCH NEXT
FROM @getBestellungenID INTO @BestellungenID
WHILE @@FETCH_STATUS = 0

BEGIN
PRINT @BestellungenID
FETCH NEXT
FROM @getBestellungenID INTO @BestellungenID
END

CLOSE @getBestellungenID 
DEALLOCATE @getBestellungenID

-------------------------------------------------

DECLARE @ProdukteID INT
DECLARE @getProdukteID CURSOR

SET @getProdukteID = CURSOR FOR SELECT id_prod FROM Produkte


SELECT id_prod
FROM Produkte
INNER JOIN ProdukteAnbieter 
ON Produkte.id_prod = ProdukteAnbieter.fk_id_prod
WHERE preis <= 100;

OPEN @getProdukteID
FETCH NEXT
FROM @getProdukteID INTO @ProdukteID
WHILE @@FETCH_STATUS = 0

BEGIN
PRINT @ProdukteID
FETCH NEXT
FROM @getProdukteID INTO @ProdukteID
END

CLOSE @getProdukteID
DEALLOCATE @getProdukteID