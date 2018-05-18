CREATE DATABASE UniDaysHomework

USE UniDaysHomework

CREATE TABLE [User] (
	Id INT IDENTITY(1,1) NOT NULL,
	EmailAddress VARCHAR(320),
	PasswordHash NVARCHAR(60),
	PRIMARY KEY (Id)
)