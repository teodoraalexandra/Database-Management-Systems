--T1 remains unchanged
--Solution is for T2: SET DEADLOCK_PRIORITY HIGH

SET DEADLOCK_PRIORITY HIGH 
begin tran 
update Competition set Country = 'Italia-T2' where CompetitionID = 7 
-- this transaction has exclusively lock on table Competition
waitfor delay '00:00:10' 
update Athlete set FirstName = 'Loredana-T2' where AthleteID = 51
commit tran 
-- this transaction has the higher priority level from here (set to HIGH) 
-- transaction 1 finish with an error, and the  results are the ones from this transaction (transaction 2) 





