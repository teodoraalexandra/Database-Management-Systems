--transaction 2

USE GymSupplements 
GO 
 
SET TRANSACTION ISOLATION LEVEL SNAPSHOT  
BEGIN TRAN 
SELECT * FROM Competition WHERE CompetitionID = 5 
-- Romania  Powerlifting 
-- the value from the beginning of the transaction 
WAITFOR DELAY '00:00:10' 
SELECT * FROM Competition where CompetitionID = 8
-- the value from the beginning of the transaction – SUA Wellness 
UPDATE Competition SET Country = 'Londra' WHERE CompetitionId = 5 
-- process will block 
-- Process will receive Error 3960. 
COMMIT TRAN 