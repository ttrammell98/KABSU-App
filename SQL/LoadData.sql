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


select * from person;
select * from animal;