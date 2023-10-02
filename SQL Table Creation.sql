-- Austin Walling--
-- SQL Table Creation Script for MalachiBudget Application


-- 
-- Definition of Income
-- 
DROP TABLE IF EXISTS `Income`;
CREATE TABLE IF NOT EXISTS `Income` (
  `Username` varchar(17) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `Net` double DEFAULT NULL,
  `Gross` double DEFAULT NULL,
  `Tithe` double DEFAULT NULL,
  `TitheStatus` varchar(45) DEFAULT NULL,
  `Date` varchar(45) DEFAULT NULL,
  `PaycheckStatus` varchar(45) DEFAULT NULL,
  `TransID` datetime NOT NULL,
  PRIMARY KEY (`TransID`,`Username`)
);

-- 
-- Definition of Transactions
-- 

DROP TABLE IF EXISTS `Transactions`;
CREATE TABLE IF NOT EXISTS `Transactions` (
  `Username` varchar(17) NOT NULL,
  `TableName` varchar(20) NOT NULL,
  `Description` varchar(35) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Due` datetime DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Notes` varchar(60) DEFAULT NULL,
  `Category` varchar(20) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `TransID` datetime NOT NULL,
  PRIMARY KEY (`Username`,`TableName`,`TransID`)
);

-- 
-- Definition of Users
-- 

DROP TABLE IF EXISTS `Users`;
CREATE TABLE IF NOT EXISTS `Users` (
  `Username` varchar(17) NOT NULL,
  `Pass` varchar(16) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Name` varchar(25) DEFAULT NULL,
  `Validated` tinyint(4) DEFAULT NULL,
  `ValidationCode` varchar(7) DEFAULT NULL,
  `TransID` datetime DEFAULT NULL,
  PRIMARY KEY (`Email`,`Username`)
);
