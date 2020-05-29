/* First, we need to set the isolation level, to an optimistic one */
/*ON*/
ALTER DATABASE GymSupplements 
SET ALLOW_SNAPSHOT_ISOLATION ON 

/*OFF*/
ALTER DATABASE GymSupplements 
SET ALLOW_SNAPSHOT_ISOLATION OFF