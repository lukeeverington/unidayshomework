CREATE DATABASE UniDaysHomework
GO

BEGIN TRANSACTION
USE UniDaysHomework

CREATE TABLE [User] (
	Id INT IDENTITY(1,1) NOT NULL,
	EmailAddress VARCHAR(320) NOT NULL UNIQUE,
	PasswordHash NVARCHAR(60) NOT NULL,
	PRIMARY KEY (Id)
)

CREATE LOGIN UniDaysHomeworkWebsite
WITH PASSWORD = 'F95a976169a3818c21f84ada5c2e74aa2cb5b08da58397d0f85e80f256e3fff9'

CREATE LOGIN UniDaysHomeworkAcceptanceTests
WITH PASSWORD = '51Be8bd9d20be6099948e841b160dec816fe49fb2ee6379dda9b2980ac9239c3'

CREATE USER UniDaysHomeworkWebsite
FOR LOGIN UniDaysHomeworkWebsite

CREATE USER UniDaysHomeworkAcceptanceTests
FOR LOGIN UniDaysHomeworkAcceptanceTests

GRANT SELECT TO UniDaysHomeworkWebsite
GRANT INSERT TO UniDaysHomeworkWebsite

GRANT SELECT TO UniDaysHomeworkAcceptanceTests
GRANT INSERT TO UniDaysHomeworkAcceptanceTests
GRANT DELETE TO UniDaysHomeworkAcceptanceTests

COMMIT TRANSACTION

--Cleanup
--USE UniDaysHomework
--DROP USER UniDaysHomeworkWebsite 
--DROP USER UniDaysHomeworkAcceptanceTests
--DROP LOGIN UniDaysHomeworkWebsite 
--DROP LOGIN UniDaysHomeworkAcceptanceTests 
--DROP TABLE [User]