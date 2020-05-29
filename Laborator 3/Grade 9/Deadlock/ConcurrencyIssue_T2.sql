-- T2: update on table B + delay + update on table A

-- transaction 2 
begin tran 
update Competition set Country = 'Italia' where CompetitionID = 7
-- this transact on has exclusively lock on table Competition 
waitfor delay '00:00:10' 
update Athlete set FirstName = 'Loredana' where AthleteID = 51
-- this transaction will be blocked because transaction 1 has exclusively lock on table Athlete, so, both of the transactions are blocked 
commit tran 
-- after some seconds transaction 2 will be chosen as a deadlock victim and terminates with an error 
-- in tables Athlete and Competition will be the values from transaction 1 
 
 


















