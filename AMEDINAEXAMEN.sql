CREATE DATABASE AMEDINAEXAMEN
GO
USE AMEDINAEXAMEN

CREATE TABLE Usuario(
Username VARCHAR(50),
Password VARCHAR(50))
GO

INSERT INTO Usuario VALUES('Abel','@bcd1234')
GO

CREATE PROCEDURE LoginUser
@Username VARCHAR(50),
@Password VARCHAR(50)
AS
SELECT Username
FROM Usuario
WHERE Username = @Username AND Password = @Password
GO