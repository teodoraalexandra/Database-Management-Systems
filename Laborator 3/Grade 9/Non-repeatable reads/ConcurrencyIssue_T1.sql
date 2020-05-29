-- T1: insert + delay + update + commit

INSERT INTO Athlete(FirstName, LastName, Age, Height, Weight) VALUES ('Anca', 'Dan', 40, 160, 60) 
BEGIN TRAN 
WAITFOR DELAY '00:00:05' 
UPDATE Athlete 
SET Age = 50 
WHERE FirstName = 'Anca' 
COMMIT TRAN 