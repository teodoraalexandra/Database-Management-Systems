--T1 remains unchanged
--Solution is for T2: SET TRANSACTION ISOLATION LEVEL TO READ COMMITTED 

SET TRANSACTION ISOLATION LEVEL READ COMMITTED 
BEGIN TRAN 
SELECT * FROM Athlete 
WAITFOR DELAY '00:00:15' 
SELECT * FROM Athlete 
COMMIT TRAN 