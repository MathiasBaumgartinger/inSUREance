USE VersicherungsDB

------------------------------------- USERS --------------------------------
-- CASUAL USERS
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Max Mustermann','15.01.1990','Beispielweg 1, 1234 Kleinstadt',0,0)
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Maria Berger','22.03.1999','Beispielweg 2, 1234 Kleinstadt',0,0)
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Wolfgang Burg','05.11.1985','Beispielweg 3, 1234 Kleinstadt',0,0)
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Anita Sch�ttel','20.06.2000','Beispielweg 4, 1234 Kleinstadt',0,0)
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Bernhard Zelt','2.07.1993','Meine Strasse 13, 4215 Unterstadt',0,0)
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Ingrid Hofbauer','30.08.1990','Meine Strasse 16, 1234 Unterstadt',0,0)
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Mechmet Alichmet','11.09.1989','Meine Strasse 19, 1234 Unterstadt',0,0)
-- BERATER
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Patrick Stein','11.09.1989','Forstweg 1, 1210 Wien',0,1)
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Denise Dworak','23.02.1991','Kellergasse 7, 1220 Wien',0,1)
-- ADMIN
INSERT INTO dbo.USERS (PASSWORDHASH,NAME,GEBURTSTAG,WOHNORT,IS_ADMIN,IS_BERATER) VALUES (HASHBYTES('SHA2_512','password'),'Ulrich Bauer','01.05.1990','Lange Strasse 99, 6789 Felddorf',1,0)


------------------------------------- ANBIETER --------------------------------
INSERT INTO dbo.ANBIETER (NAME,ADRESSE) VALUES ('Generali AG','Landskrongasse 1-3, 1010 Wien')
INSERT INTO dbo.ANBIETER (NAME,ADRESSE) VALUES ('UNIQA AG','Untere Donaustra�e 21, 1029 Wien')
INSERT INTO dbo.ANBIETER (NAME,ADRESSE) VALUES ('WIENER ST�DTISCHE AG ','Schottenring 30, 1011 Wien')
INSERT INTO dbo.ANBIETER (NAME,ADRESSE) VALUES ('Allianz AG','Hietzinger Kai 101-105, 1130 Wien')


------------------------------------- PRODUKT_KATEGORIE --------------------------------
INSERT INTO dbo.PRODUKT_KATEGORIE (NAME) VALUES ('KFZ-Versicherungen')
INSERT INTO dbo.PRODUKT_KATEGORIE (NAME) VALUES ('Unfall- und Krankenversicherungen')
INSERT INTO dbo.PRODUKT_KATEGORIE (NAME) VALUES ('Haushaltsversicherungen')


------------------------------------- PRODUKTE --------------------------------
INSERT INTO dbo.PRODUKTE (FK_ID_PRODUKT_KATEGORIE,NAME,BESCHREIBUNG) VALUES (1,'KFZ-Haftplicht','Haftpflichtversicherung f�r Ihr KFZ!')
INSERT INTO dbo.PRODUKTE (FK_ID_PRODUKT_KATEGORIE,NAME,BESCHREIBUNG) VALUES (1,'KFZ-Vollkasko','Vollkaskoversicherung f�r Ihr KFZ!')
INSERT INTO dbo.PRODUKTE (FK_ID_PRODUKT_KATEGORIE,NAME,BESCHREIBUNG) VALUES (2,'Unfallversicherung','Wenn Sie ins Krankenhaus kommen, sind Sie nicht alleine!')
INSERT INTO dbo.PRODUKTE (FK_ID_PRODUKT_KATEGORIE,NAME,BESCHREIBUNG) VALUES (2,'Krankenversicherung','Sie m�ssen zum Arzt? Wir �bernehmen die Kosten!')
INSERT INTO dbo.PRODUKTE (FK_ID_PRODUKT_KATEGORIE,NAME,BESCHREIBUNG) VALUES (3,'Haushaltsversicherung Basic','Sch�den am Haus? Wir �bernehmen das!')
INSERT INTO dbo.PRODUKTE (FK_ID_PRODUKT_KATEGORIE,NAME,BESCHREIBUNG) VALUES (3,'Haushaltsversicherung Wasser','Versicherungszusatz! Leitung geplatz? Monteur ist schon unterwegs!')


------------------------------------- BERATER --------------------------------
INSERT INTO dbo.BERATER (FK_ID_USERS,FK_ID_ANB) 
VALUES (
	(Select ID FROM dbo.USERS 
	WHERE NAME = 'Patrick Stein'),
	(SELECT ID FROM dbo.ANBIETER
	WHERE NAME = 'Generali AG')
)	--PATRICK STEIN -> GENERALI
INSERT INTO dbo.BERATER (FK_ID_USERS,FK_ID_ANB) 
VALUES (
	(Select ID FROM USERS 
	WHERE NAME = 'Denise Dworak'),
	(SELECT ID FROM ANBIETER
	WHERE NAME = 'UNIQA AG')
)	--DENISE DWORAK -> UNIQA
INSERT INTO dbo.BERATER (FK_ID_USERS,FK_ID_ANB) 
VALUES (
	(Select ID FROM USERS 
	WHERE NAME = 'Denise Dworak'),
	(SELECT ID FROM ANBIETER
	WHERE NAME = 'Allianz AG')
)	--DENISE DWORAK -> Allianz


------------------------------------- PRODUKTE_ANBIETER --------------------------------
--GENERALI
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (1,1,89.99,12) --Haftpfl.
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (1,2,199.99,24)--Vollkasko
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (1,3,15.00,12)--Unfallvers.
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (1,4,31.50,36)--Krankenvers.
--UNIQA
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (2,3,10.50,12)	--Unfallvers.
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (2,4,27.50,24)	--Krankenvers.
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (2,5,29.90,24)	--Haushalt Basic
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (2,6,9.99,12)	--Haushalt Wasser
--Wr. St�dtische
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (3,1,79.99,12) --Haftpfl.
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (3,2,210.00,12)--Vollkasko
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (3,5,20.00,36)	--Haushalt Basic
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (3,6,18.00,36)	--Haushalt Wasser
--ALLIANZ
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (4,3,19.90,6)--Unfallvers.
INSERT INTO dbo.PRODUKTE_ANBIETER (FK_ID_ANBIETER,FK_ID_PRODUKTE,PREIS,LAUFZEIT) VALUES (4,4,29.90,6)--Krankenvers.


------------------------------------- BEWERTUNG_ANBIETER --------------------------------
INSERT INTO BEWERTUNG_ANBIETER (FK_ID_USERS,FK_ID_ANBIETER,STERNE) VALUES (1,1,3)
INSERT INTO BEWERTUNG_ANBIETER (FK_ID_USERS,FK_ID_ANBIETER,STERNE) VALUES (4,2,5)
INSERT INTO BEWERTUNG_ANBIETER (FK_ID_USERS,FK_ID_ANBIETER,STERNE) VALUES (2,2,2)
INSERT INTO BEWERTUNG_ANBIETER (FK_ID_USERS,FK_ID_ANBIETER,STERNE) VALUES (5,3,4)
INSERT INTO BEWERTUNG_ANBIETER (FK_ID_USERS,FK_ID_ANBIETER,STERNE) VALUES (6,3,5)


------------------------------------- BEWERTUNG_ANBIETER_PROD --------------------------------
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (1,3,4)
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (1,2,2)
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (2,5,2)
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (3,9,2)
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (4,7,5)
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (5,7,1)
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (6,11,3)
INSERT INTO dbo.BEWERTUNG_ANBIETER_PROD (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER,STERNE) VALUES (7,14,4)


------------------------------------- BEWERTUNG_BERATER --------------------------------
INSERT INTO dbo.BEWERTUNG_BERATER (FK_ID_USERS,FK_ID_BERATER,STERNE) VALUES (1,1,3)
INSERT INTO dbo.BEWERTUNG_BERATER (FK_ID_USERS,FK_ID_BERATER,STERNE) VALUES (5,1,4)
INSERT INTO dbo.BEWERTUNG_BERATER (FK_ID_USERS,FK_ID_BERATER,STERNE) VALUES (3,2,4)
INSERT INTO dbo.BEWERTUNG_BERATER (FK_ID_USERS,FK_ID_BERATER,STERNE) VALUES (7,2,5)
INSERT INTO dbo.BEWERTUNG_BERATER (FK_ID_USERS,FK_ID_BERATER,STERNE) VALUES (2,2,2)


------------------------------------- BESTELLUNGEN --------------------------------
INSERT INTO dbo.BESTELLUNGEN (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER) VALUES (1,3)
INSERT INTO dbo.BESTELLUNGEN (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER) VALUES (2,5)
INSERT INTO dbo.BESTELLUNGEN (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER) VALUES (3,9)
INSERT INTO dbo.BESTELLUNGEN (FK_ID_USERS,FK_ID_PRODUKTE_ANBIETER) VALUES (7,14)


------------------------------------- FRAGEN --------------------------------
INSERT INTO dbo.FRAGEN (FK_ID_USERS,FK_ID_BERATER_FRAGEN,FRAGE,ANTWORT,STMP_ANTWORT) 
	VALUES (1,1,'TESTFRAGE KUNDE 1','TEST-ANTWORT BERATER 1',SYSDATETIME())
INSERT INTO dbo.FRAGEN (FK_ID_USERS,FK_ID_BERATER_FRAGEN,FRAGE) 
	VALUES (5,1,'TESTFRAGE KUNDE 5')
INSERT INTO dbo.FRAGEN (FK_ID_USERS,FK_ID_BERATER_FRAGEN,FRAGE,ANTWORT,STMP_ANTWORT) 
	VALUES (7,2,'TESTFRAGE KUNDE 7','TEST-ANTWORT BERATER 2','14.12.2018 21:05:14.123')
INSERT INTO dbo.FRAGEN (FK_ID_USERS,FK_ID_BERATER_FRAGEN,FRAGE) 
	VALUES (3,2,'TESTFRAGE KUNDE 3')
INSERT INTO dbo.FRAGEN (FK_ID_USERS,FK_ID_BERATER_FRAGEN,FRAGE) 
	VALUES (2,2,'TESTFRAGE KUNDE 2')


------------------------------------- BERATER_FRAGEN --------------------------------
INSERT INTO dbo.BERATER_FRAGEN (FK_ID_BERATER,FK_ID_FRAGE) VALUES (1,1)
INSERT INTO dbo.BERATER_FRAGEN (FK_ID_BERATER,FK_ID_FRAGE) VALUES (2,3)