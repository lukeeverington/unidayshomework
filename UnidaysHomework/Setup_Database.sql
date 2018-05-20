CREATE DATABASE UniDaysHomework

USE UniDaysHomework

CREATE TABLE [User] (
	Id INT IDENTITY(1,1) NOT NULL,
	EmailAddress VARCHAR(320),
	PasswordHash NVARCHAR(60),
	PRIMARY KEY (Id)
)

CREATE LOGIN UniDaysHomeworkWebsite 
WITH PASSWORD = 'f95a976169a3818c21f84ada5c2e74aa2cb5b08da58397d0f85e80f256e3fff9'

CREATE USER UniDaysHomeworkWebsite 
FOR LOGIN UniDaysHomeworkWebsite

GRANT SELECT TO UniDaysHomeworkWebsite
GRANT INSERT TO UniDaysHomeworkWebsite