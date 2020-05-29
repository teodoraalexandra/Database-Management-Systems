/* Create a stored procedure that inserts data in tables that are in a m:n  relationship. 
If one insert fails, all the operations performed by the procedure must be rolled back. (grade: 3) */

/*VALIDATION FUNCTIONS - Athlete*/
GO
CREATE OR ALTER FUNCTION uf_ValidateFirstName (@firstName varchar(255)) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(LEFT(@firstName,1) = UPPER(LEFT(@firstName,1)) COLLATE Latin1_General_CS_AS) 
		SET @return = 1 
	RETURN @return 
END 

GO
CREATE OR ALTER FUNCTION uf_ValidateLastName (@lastName varchar(255)) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(LEFT(@lastName,1) = UPPER(LEFT(@lastName,1)) COLLATE Latin1_General_CS_AS) 
		SET @return = 1 
	RETURN @return 
END 

GO
CREATE OR ALTER FUNCTION uf_ValidateAge (@age INT) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(@age >= 18) /*An athlete must be at least 18 to participate in such competitions.*/ 
		SET @return = 1 
	RETURN @return 
END 

GO
CREATE OR ALTER FUNCTION uf_ValidateHeight (@height INT) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(@height >= 130) /*An athlete must be at least 130 cm to participate in such competitions.*/ 
		SET @return = 1 
	RETURN @return 
END 
 
GO
CREATE OR ALTER FUNCTION uf_ValidateWeight (@weight INT) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(@weight >= 40) /*An athlete must be at least 40 kg to participate in such competitions.*/ 
		SET @return = 1 
	RETURN @return 
END 

/*VALIDATION FUNCTIONS - Competititon*/
GO
CREATE OR ALTER FUNCTION uf_ValidateCDate (@date DATE) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(@date IS NOT NULL)
		SET @return = 1 
	RETURN @return 
END 

GO
CREATE OR ALTER FUNCTION uf_ValidateCountry (@country varchar(255)) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(LEFT(@country,1) = UPPER(LEFT(@country,1)) COLLATE Latin1_General_CS_AS) 
		SET @return = 1 
	RETURN @return 
END 

GO
CREATE OR ALTER FUNCTION uf_ValidateCType (@type varchar(100)) RETURNS INT AS 
BEGIN 
	DECLARE @return INT 
	SET @return = 0 
	IF(@type  IN ('Bodybuilding','Bikini','Powerlifting','Wellness')) 
		SET @return = 1 
	RETURN @return 
END 
 
/* Create the procedure for adding in the m:n relationship - grade:3 */
GO
CREATE OR ALTER PROCEDURE AddAthleteCompetition3 
	@firstName varchar(255),
	@lastName varchar(255),
	@age int, 
	@height int,
	@weight int,
	@cdate date, 
	@country varchar(255),
	@ctype varchar(255) AS

BEGIN 
	BEGIN TRAN 
		BEGIN TRY 
			/*Athlete validation */
			IF(dbo.uf_ValidateFirstName(@firstName)<>1) 
				BEGIN 
					RAISERROR('First name must start with uppercase.',14,1) 
				END 
			IF(dbo.uf_ValidateLastName(@lastName)<>1) 
				BEGIN 
					RAISERROR('Last name must start with uppercase.',14,1) 
				END 
			IF(dbo.uf_ValidateAge(@age)<>1) 
				BEGIN 
					RAISERROR('Age must be greater than 18.',14,1) 
				END 
			IF(dbo.uf_ValidateHeight(@height)<>1) 
				BEGIN 
					RAISERROR('Height must be greater than 130.',14,1) 
				END 
			IF(dbo.uf_ValidateAge(@weight)<>1) 
				BEGIN 
					RAISERROR('Weight must be greater than 40.',14,1) 
				END 

			/*Competition validation*/
			IF(dbo.uf_ValidateCDate(@cdate)<>1) 
				BEGIN 
					RAISERROR('Date is not allowed to be null.',14,1) 
				END 
			IF(dbo.uf_ValidateCountry(@country)<>1) 
				BEGIN 
					RAISERROR('Country must start with uppercase.',14,1) 
				END 
			IF(dbo.uf_ValidateCType(@ctype)<>1) 
				BEGIN 
					RAISERROR('Type must be Bodybuilding, Bikini, Powerlifting or Wellness.',14,1) 
				END 

			/*INSERT Athlete*/
			INSERT INTO Athlete(FirstName, LastName, Age, Height, Weight) VALUES (@firstName, @lastName, @age, @height, @weight) 
			PRINT 'Athlete added successfully'

			/*INSERT Competition*/
			INSERT INTO Competition(CDate, Country, CType) VALUES (@cdate, @country, @ctype) 
			PRINT 'Competition added successfully'

			/*Get id from Athlete*/
			DECLARE @athleteID INT
			SET @athleteID = (SELECT IDENT_CURRENT('Athlete'))

			/*Get id from Competition*/
			DECLARE @competitionID INT
			SET @competitionID = (SELECT IDENT_CURRENT('Competition'))

			/*INSERT Participate*/
			INSERT INTO Participate VALUES(@athleteID, @competitionID)
			print 'Participation added successfully'

			COMMIT TRAN 
			SELECT 'Transaction committed' 
		END TRY 
 
		BEGIN CATCH 
			ROLLBACK TRAN 
			SELECT 'Transaction rollbacked' 
			PRINT ERROR_MESSAGE()
		END CATCH 
END 

/* Setup a logging system to track executed actions for all scenarios */

/*Happy scenario #1*/
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate
EXEC AddAthleteCompetition3 'Ion', 'Popescu', 20, 190, 80, '02-02-2020', 'Romania', 'Powerlifting'
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate

/*Happy scenario #2*/
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate
EXEC AddAthleteCompetition3 'Vasile', 'Pop', 30, 180, 85, '03-03-2020', 'SUA', 'Bodybuilding'
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate

/*Error scenario #1 - Error from athlete -> everything rolled back*/
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate
EXEC AddAthleteCompetition3 'Aurel', 'Ionescu', 15, 180, 85, '03-03-2020', 'SUA', 'Bodybuilding'
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate

/*Error scenario #2 - Error from competition -> everything rolled back*/
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate
EXEC AddAthleteCompetition3 'Aurel', 'Ionescu', 25, 180, 85, '03-03-2020', 'SUA', 'Test'
SELECT * FROM Athlete
SELECT * FROM Competition
SELECT * FROM Participate


