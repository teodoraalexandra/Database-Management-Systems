-- T1: update on table A + delay + update on table B

-- transaction 1 
begin tran 
update Athlete set FirstName = 'Loredana' where AthleteID = 51
-- this transaction has exclusively lock on table Athlete
waitfor delay '00:00:10' 
update Competition set Country = 'Italia' where CompetitionID = 7
-- this transaction will be blocked because transaction 2 has already blocked our lock on table Competition
commit tran 
 
