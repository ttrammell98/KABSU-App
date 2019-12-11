
-- procudere to query informaion based on condistions from spcified in front end
CREATE OR ALTER PROCEDURE kabsu.RetrieveData
@Owner NVARCHAR(128),
@Breed NVARCHAR(128),
@AnimalName NVARCHAR(128),
@Code NVARCHAR(128),
@CanNum NVARCHAR(128),
@Town NVARCHAR(128),
@State NVARCHAR(128),


AS

SELECT S.Valid, S.CanNum, A.AnimalID, A.CollDate, S.NumUnits, A.Name AS AnimalName, A.Breed, A.RegNum, P.Name AS PersonName, P.Town, P.State
FROM Sample S 
INNER JOIN Person P ON P.PersonID = S.PersonID
INNER JOIN Animal A ON A.AnimalID = A.AnimalID
WHERE P.Name = CASE @Owner
			WHEN N'*'
			THEN 
				P.Name
			ELSE
				@Owner
			end
AND A.Breed = CASE @Breed
			WHEN N'*'
			THEN
				P.Name
			ELSE
				@Breed
			END
AND A.Name = CASE @AnimalName
			WHEN N'*'
			THEN
				A.Breed
			ELSE
				@AnimalName
			END
AND A.AnimalID = CASE @Code
			WHEN N'*'
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
AND P.Town = CASE @Town
			WHEN N'*'
			THEN
				P.Town
			ELSE
				@Town
			END
GO
