--Dirty Reads Part 1 
--T1: 1 update + delay + rollback

BEGIN TRANSACTION 
UPDATE Athlete 
SET age = 30 
WHERE AthleteID = 40 
WAITFOR DELAY '00:00:10' 
ROLLBACK TRANSACTION