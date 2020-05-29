--Phantom Reads Part 1 
--T1: delay + insert + commit

BEGIN TRAN 
WAITFOR DELAY '00:00:04' 
INSERT INTO Athlete(FirstName, LastName, Age, Height, Weight) VALUES ('Izabela', 'Craciun', 45, 160, 45) 
COMMIT TRAN 



