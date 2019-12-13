CREATE PROCEDURE kabsu.RetrieveData(
IN Owner VARCHAR(128),
IN Breed VARCHAR(128),
IN AnimalName VARCHAR(128),
IN Code VARCHAR(128),
IN CanNum VARCHAR(128),
IN Town VARCHAR(128),
IN State VARCHAR(128),
OUT Valid BOOL,
OUT CanNum VARCHAR(32),
OUT AnimalID VARCHAR(32),
OUT NumUnits INT,
OUT AnimalName VARCHAR(128),
OUT Breed VARCHAR(64),
OUT RegNum VARCHAR(32),
OUT PersonName VARCHAR(100),
OUT Town VARCHAR(64),
OUT State VARCHAR(2)
)


BEGIN

SELECT S.Valid, S.CanNum, A.AnimalID, A.CollDate, S.NumUnits, A.Name AS AnimalName, A.Breed, A.RegNum, P.Name AS PersonName, P.City, P.State
FROM Sample S 
INNER JOIN Person P ON P.PersonID = S.PersonID
INNER JOIN Animal A ON A.AnimalID = A.AnimalID
WHERE P.Name = CASE @Owner
			WHEN '*'
			THEN 
				P.Name
			ELSE
				@Owner
			END
AND A.Breed = CASE @Breed
			WHEN '*'
			THEN
				P.Name
			ELSE
				@Breed
			END
AND A.Name = CASE @AnimalName
			WHEN '*'
			THEN
				A.Breed
			ELSE
				@AnimalName
			END
AND A.AnimalID = CASE @Code
			WHEN '*'
			THEN
				A.AnimalID
			ELSE
				@Code
			END
AND S.CanNum= CASE @CanNum
			WHEN N'*'
			THEN
				S.CanNum
			ELSE
				@CanNum
			END
AND P.City = CASE @Town
			WHEN '*'
			THEN
				P.City
			ELSE
				@Town
			END
AND P.State = CASE @State
			WHEN '*'
			THEN
				P.State
			ELSE
				@State
			END;
END;
