CREATE PROCEDURE [dbo].[sp01_CREATE_RDB_TABLES]
AS
CREATE TABLE Brevet
(
  brevetId    INTEGER  NOT NULL,
  distance    INTEGER NOT NULL,
 brevetDate     DATE NOT NULL,
  location    VARCHAR(50) NOT NULL ,
  climbing       INTEGER NOT NULL ,

  CONSTRAINT PK_brevetId PRIMARY KEY (brevetId) ,
  CONSTRAINT CHK_brevetId CHECK(brevetId BETWEEN 1 AND 9999) ,
  CONSTRAINT CHK_distance CHECK(distance=200 or distance=300 or distance=400 or distance=600 or distance=1000 or distance=1200 ) ,
  CONSTRAINT CHK_climbing CHECK(climbing BETWEEN 0 AND 99999)
);

CREATE TABLE Brevet_Rider
(
 riderId INTEGER    NOT NULL,
  brevetId INTEGER NOT NULL,
 isCompleted    CHAR(1) NOT NULL,
finishingTime    CHAR(5)      NOT NULL,
  
  
  CONSTRAINT PK_riderId_brevetId PRIMARY KEY (riderId , brevetId),
  CONSTRAINT FK_riderId FOREIGN KEY (riderId) REFERENCES Rider (riderId),
  CONSTRAINT FK_brevetId FOREIGN KEY (brevetId) REFERENCES Brevet(brevetId),
  CONSTRAINT CHK_isCompleted CHECK(isCompleted = 'N' or isCompleted ='Y')
);

CREATE TABLE Club
(
  clubId  INTEGER      NOT NULL,
  clubName   VARCHAR(50)   NOT NULL UNIQUE,
  city       VARCHAR(50)   NOT NULL,
  email      VARCHAR(50)       NOT NULL,
  

  CONSTRAINT PK_Club PRIMARY KEY (clubId),
  CONSTRAINT CHK_clubId CHECK(clubId BETWEEN 50 AND 4999)
);

CREATE TABLE Rider

(
  riderId  INTEGER NOT NULL,
  familyName VARCHAR(50) NOT NULL,
  givenName    VARCHAR(50) NOT NULL,
 gender       CHAR(1) NOT NULL , 
 phone  VARCHAR(50)NOT NULL,  
  email VARCHAR(50)NOT NULL ,
 clubId  INTEGER NOT NULL,
  username VARCHAR(20) NOT NULL UNIQUE,
  password     VARCHAR(20)NOT NULL ,
  role        VARCHAR(20)NOT NULL ,
  

  CONSTRAINT PK_riderId PRIMARY KEY (riderId) ,
  CONSTRAINT FK_clubId FOREIGN KEY (clubId) REFERENCES Club(clubId) ,
  CONSTRAINT CHK_riderId CHECK(riderId BETWEEN 10 AND 99999),
  CONSTRAINT CHK_gender CHECK(gender = 'F' or gender = 'M'),
  CONSTRAINT CHK_role CHECK(role = 'user' or role= 'admin')
     
);

IF (@@Error = 0) 
  BEGIN
    PRINT '======================================'
    PRINT ' RANDONNEUR TABLES CREATED SUCCESSFULLY.'
    PRINT '======================================'
    PRINT ' '
  END