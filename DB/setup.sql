CREATE DATABASE PersonData;
GO
USE PersonData;
GO
CREATE TABLE Persons (
    id  INT NOT NULL    IDENTITY    PRIMARY KEY, 
    firstname varchar(100),
    lastname varchar(100),
    address int 
    );
GO

CREATE TABLE Addresses (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  streetname varchar(100),
  zip varchar(100)  
);
GO

declare @addressid INT
insert into Addresses ([streetname],[zip]) values("krokåsdalen","5302");
SELECT @addressid = Scope_identity();
insert into Persons ([firstname],[lastname],[address])  values("John-Arne", "Fagerli",@addressid);
GO
