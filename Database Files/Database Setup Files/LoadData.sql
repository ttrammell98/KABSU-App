LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/People.csv'
INTO TABLE person
FIELDS TERMINATED BY ','
ENCLOSED BY '"'
LINES terminated by '\n'
IGNORE 1 ROWS;

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/Animal.csv'
INTO TABLE animal
FIELDS TERMINATED BY ','
ENCLOSED BY '"'
LINES terminated by '\n'
IGNORE 1 ROWS;

DROP TABLE IF EXISTS tempsample;

CREATE TABLE tempsample (
Valid VARCHAR(8) NOT NULL,
CanNum VARCHAR(32) NOT NULL,
Code VARCHAR(100) NOT NULL,
CollDate VARCHAR(128),
NumUnits INT NOT NULL,
AnimalName VARCHAR(128) NOT NULL,
Breed VARCHAR(64) NOT NULL,
RegNum VARCHAR(128),
Notes VARCHAR(1000),
PersonName VARCHAR(100) NOT NULL,
Town VARCHAR(64) NOT NULL,
State VARCHAR(2) NOT NULL
);

LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/sample.csv'
INTO TABLE tempsample
FIELDS TERMINATED BY ','
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS;

INSERT INTO sample (Valid, CanNum, AnimalID, CollDate, NumUnits, PersonID, Notes)
SELECT Valid, CanNum, TS.Code, CollDate, NumUnits, P.PersonID, Notes
FROM tempsample TS
	INNER JOIN person P ON P.Name = TS.PersonName AND P.City = TS.Town
	INNER JOIN animal A ON A.AnimalID = TS.Code;

DROP TABLE tempsample;
