DROP TABLE IF EXISTS Record;
DROP TABLE IF EXISTS Person;
DROP TABLE IF EXISTS Animal;
DROP TABLE IF EXISTS Sample;

CREATE TABLE Person (
PersonID INT NOT NULL PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
City VARCHAR(64) NOT NULL,
State VARCHAR(2) NOt NULL,
Country VARCHAR(3) NOT NULL
);

CREATE TABLE Animal (
AnimalID VARCHAR(32) NOT NULL PRIMARY KEY,
Name VARCHAR(128) NOT NULL,
Breed VARCHAR(64) NOT NULL,
Species VARCHAR(16) NOT NULL,
RegNum VARCHAR(32),
);

CREATE TABLE Sample (
Valid BOOL NOT NULL,
CanNum VARCHAR(8) NOT NULL,
AnimalID VARCHAR(32) NOT NULL,
CollDate VARCHAR(32),
NumUnits INT NOT NULL,
PersonID INT NOT NULL,
Notes VARCHAR(1000),
FOREIGN KEY (PersonID) REFERENCES kabsu.person (AnimalID)
);

CREATE TABLE Record (
AnimalID VARCHAR(32) NOT NULL,
ToFrom VARCHAR(100) NOT NULL,
Date VARCHAR(32) NOT NULL,
NumReceived INT NOT NULL,
NumShipped INT NOT NULL,
Balance INT NOT NULL,
FOREIGN KEY (AnimalID) REFERENCES kabsu.animal (AnimalID)
);
