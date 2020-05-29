 -- transaction 1 

 USE GymSupplements 
 GO
 
WAITFOR DELAY '00:00:10' 
BEGIN TRAN 
UPDATE Competition
SET Country = 'Spania' 
WHERE CompetitionID = 5  
-- Country is now Spania
WAITFOR DELAY '00:00:10' 
COMMIT TRAN

