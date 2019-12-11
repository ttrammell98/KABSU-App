DROP TABLE IF EXISTS Person;
DROP TABLE IF EXISTS Animal;
DROP TABLE IF EXISTS Sample;

CREATE TABLE Person (
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
PersonID INT NOT NULL,
FOREIGN KEY (PersonID) REFERENCES kabsu.person (PersonID)
);

CREATE TABLE Sample (
Valid BOOL NOT NULL,
CanNum VARCHAR(8) NOT NULL,
AnimalID VARCHAR(32) NOT NULL,
CollDate VARCHAR(32),
NumUnits INT NOT NULL,
PersonID INT NOT NULL,
Notes VARCHAR(1000)
);

INSERT INTO Person (Name, City, State, Country)
VALUES ('Mouse, Mickey', 'Beloit', 'KS', 'USA');

INSERT INTO Animal (AnimalID, Name, Breed, Species, RegNum, PersonID)
VALUES ('54XB445', '1 Oak', 'Cross', 'Cow', NULL, 1);

INSERT INTO Sample (CanNum, CollDate, NumUnits, AnimalID, PersonID, Valid, Notes)
VALUES ('0658', '43494', 10, '54XB445', 1, TRUE, NULL);
