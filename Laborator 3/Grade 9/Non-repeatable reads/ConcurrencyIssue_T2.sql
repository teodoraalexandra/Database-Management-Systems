--  T2: select + delay + select

SET TRANSACTION ISOLATION LEVEL READ COMMITTED 
BEGIN TRAN 
SELECT * FROM Athlete
WAITFOR DELAY '00:00:05' 
SELECT * FROM Athlete
COMMIT TRAN 