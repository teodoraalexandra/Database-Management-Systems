--T1 remains unchanged
--Solution is for T2: Set transaction isolation level to SERIALIZABLE 

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE 
BEGIN TRAN 
SELECT * FROM Athlete 
WAITFOR DELAY '00:00:05' 
SELECT * FROM Athlete
COMMIT TRAN 

