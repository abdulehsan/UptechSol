/*
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema UptechSol
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema UptechSol
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `UptechSol` DEFAULT CHARACTER SET utf8 ;
USE `UptechSol` ;

-- -----------------------------------------------------
-- Table `UptechSol`.`Employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Employee` (
  `idEmployee` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Gender` VARCHAR(45) NOT NULL,
  `DOJ` DATE NOT NULL,
  `DOB` DATE NOT NULL,
  `Address` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL DEFAULT 'admin',
  PRIMARY KEY (`idEmployee`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`Project`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Project` (
  `P_no` INT NOT NULL,
  `P_name` VARCHAR(45) NOT NULL,
  `Budget` BIGINT(10) NOT NULL,
  `Client_C_id` INT NOT NULL,
  PRIMARY KEY (`P_no`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Client` (
  `C_id` INT NOT NULL,
  `C_name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`C_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`Finance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Finance` (
  `Salary` INT NOT NULL,
  `Employee_idEmployee` INT NOT NULL,
  PRIMARY KEY (`Employee_idEmployee`),
  CONSTRAINT `fk_Finance_Employee1`
    FOREIGN KEY (`Employee_idEmployee`)
    REFERENCES `UptechSol`.`Employee` (`idEmployee`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`HR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`HR` (
  `Resources` INT NOT NULL,
  `Employee_idEmployee` INT NOT NULL,
  PRIMARY KEY (`Employee_idEmployee`),
  CONSTRAINT `fk_HR_Employee1`
    FOREIGN KEY (`Employee_idEmployee`)
    REFERENCES `UptechSol`.`Employee` (`idEmployee`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`Department`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Department` (
  `D_id` INT NOT NULL,
  `D_name` VARCHAR(45) NULL,
  `Employee_idEmployee` INT NOT NULL,
  PRIMARY KEY (`D_id`),
  INDEX `fk_Department_Employee1_idx` (`Employee_idEmployee` ASC) VISIBLE,
  CONSTRAINT `fk_Department_Employee1`
    FOREIGN KEY (`Employee_idEmployee`)
    REFERENCES `UptechSol`.`Employee` (`idEmployee`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`Employee_has_Project`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Employee_has_Project` (
  `Employee_idEmployee` INT NOT NULL,
  `Project_P_no` INT NOT NULL,
  PRIMARY KEY (`Employee_idEmployee`, `Project_P_no`),
  INDEX `fk_Employee_has_Project_Project1_idx` (`Project_P_no` ASC) VISIBLE,
  INDEX `fk_Employee_has_Project_Employee_idx` (`Employee_idEmployee` ASC) VISIBLE,
  CONSTRAINT `fk_Employee_has_Project_Employee`
    FOREIGN KEY (`Employee_idEmployee`)
    REFERENCES `UptechSol`.`Employee` (`idEmployee`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Employee_has_Project_Project1`
    FOREIGN KEY (`Project_P_no`)
    REFERENCES `UptechSol`.`Project` (`P_no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`Attendance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Attendance` (
  `Date` DATE NOT NULL,
  `Status` VARCHAR(45) NOT NULL,
  `Employee_idEmployee` INT NOT NULL,
  PRIMARY KEY (`Employee_idEmployee`),
  CONSTRAINT `fk_Attendance_Employee1`
    FOREIGN KEY (`Employee_idEmployee`)
    REFERENCES `UptechSol`.`Employee` (`idEmployee`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UptechSol`.`Client_has_Project`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UptechSol`.`Client_has_Project` (
  `Client_C_id` INT NOT NULL,
  `Project_P_no` INT NOT NULL,
  PRIMARY KEY (`Client_C_id`, `Project_P_no`),
  INDEX `fk_Client_has_Project_Project1_idx` (`Project_P_no` ASC) VISIBLE,
  INDEX `fk_Client_has_Project_Client1_idx` (`Client_C_id` ASC) VISIBLE,
  CONSTRAINT `fk_Client_has_Project_Client1`
    FOREIGN KEY (`Client_C_id`)
    REFERENCES `UptechSol`.`Client` (`C_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Client_has_Project_Project1`
    FOREIGN KEY (`Project_P_no`)
    REFERENCES `UptechSol`.`Project` (`P_no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
*/

-- Insertion in Employee Table

/*
INSERT INTO `UptechSol`.`Employee` (`idEmployee`, `Name`, `Gender`, `DOJ`, `DOB`, `Address`) VALUES
(1, 'John Doe', 'Male', '2020-01-15', '1990-05-20', '123 Main St'),
(2, 'Jane Smith', 'Female', '2019-06-30', '1985-07-15', '456 Elm St'),
(3, 'Alice Johnson', 'Female', '2021-03-10', '1992-08-25', '789 Oak St'),
(4, 'Bob Brown', 'Male', '2018-11-05', '1988-12-10', '101 Pine St'),
(5, 'Charlie Black', 'Male', '2017-02-20', '1995-03-30', '102 Maple St'),
(6, 'Eve White', 'Female', '2020-09-12', '1993-11-18', '103 Birch St'),
(7, 'Frank Green', 'Male', '2019-04-23', '1987-02-16', '104 Cedar St'),
(8, 'Grace Blue', 'Female', '2016-08-19', '1991-01-29', '105 Spruce St'),
(9, 'Henry Purple', 'Male', '2015-07-21', '1989-04-02', '106 Fir St'),
(10, 'Ivy Red', 'Female', '2014-03-11', '1994-09-10', '107 Willow St'),
(11, 'Jack Yellow', 'Male', '2013-11-22', '1990-12-31', '108 Alder St'),
(12, 'Kathy Orange', 'Female', '2012-05-18', '1988-06-07', '109 Ash St'),
(13, 'Larry Cyan', 'Male', '2011-09-25', '1986-11-15', '110 Poplar St'),
(14, 'Mia Violet', 'Female', '2010-12-13', '1985-08-24', '111 Redwood St'),
(15, 'Ned Brown', 'Male', '2009-07-30', '1993-03-05', '112 Cypress St'),
(16, 'Olive Pink', 'Female', '2008-06-02', '1987-10-20', '113 Dogwood St'),
(17, 'Paul Gray', 'Male', '2007-04-15', '1984-02-28', '114 Hickory St'),
(18, 'Quinn Gold', 'Female', '2006-03-27', '1989-05-13', '115 Maple St'),
(19, 'Rick Silver', 'Male', '2005-02-10', '1992-01-19', '116 Magnolia St'),
(20, 'Sophie Bronze', 'Female', '2004-11-07', '1991-04-04', '117 Chestnut St'),
(21, 'Tom Copper', 'Male', '2003-10-20', '1988-07-23', '118 Beech St'),
(22, 'Uma Pearl', 'Female', '2002-09-16', '1990-11-27', '119 Elm St'),
(23, 'Victor Diamond', 'Male', '2001-08-14', '1989-06-05', '120 Pine St'),
(24, 'Wendy Jade', 'Female', '2000-07-10', '1987-12-12', '121 Oak St'),
(25, 'Xander Ruby', 'Male', '1999-06-05', '1991-10-18', '122 Cedar St');
*/

-- Insertion in Department Table
/*
INSERT INTO `UptechSol`.`Department` (`D_id`, `D_name`, `Employee_idEmployee`) VALUES
(1, 'HR', 1),
(2, 'Finance', 2),
(3, 'IT', 3),
(4, 'Marketing', 4),
(5, 'Sales', 5),
(6, 'Operations', 6),
(7, 'Legal', 7),
(8, 'Research', 8),
(9, 'Development', 9),
(10, 'Support', 10),
(11, 'Administration', 11),
(12, 'Public Relations', 12),
(13, 'Procurement', 13),
(14, 'Engineering', 14),
(15, 'Maintenance', 15),
(16, 'Logistics', 16),
(17, 'Training', 17),
(18, 'Customer Service', 18),
(19, 'Production', 19),
(20, 'Quality Assurance', 20);
*/ 

-- Insertion in Project Table 
/*
INSERT INTO `UptechSol`.`Project` (`P_no`, `P_name`, `Budget`, `Client_C_id`) VALUES
(1, 'Project Alpha', 1000000, 1),
(2, 'Project Beta', 2000000, 2),
(3, 'Project Gamma', 1500000, 3),
(4, 'Project Delta', 2500000, 4),
(5, 'Project Epsilon', 3000000, 5),
(6, 'Project Zeta', 3500000, 6),
(7, 'Project Eta', 4000000, 7),
(8, 'Project Theta', 4500000, 8),
(9, 'Project Iota', 5000000, 9),
(10, 'Project Kappa', 5500000, 10);

INSERT INTO `UptechSol`.`Project` (`P_no`, `P_name`, `Budget`, `Client_C_id`) VALUES
(11, 'Project Lambda', 6000000, 1),
(12, 'Project Mu', 6500000, 2),
(13, 'Project Nu', 7000000, 3),
(14, 'Project Xi', 7500000, 4),
(15, 'Project Omicron', 8000000, 5),
(16, 'Project Pi', 8500000, 6),
(17, 'Project Rho', 9000000, 7),
(18, 'Project Sigma', 9500000, 8),
(19, 'Project Tau', 10000000, 9),
(20, 'Project Upsilon', 10500000, 10),
(21, 'Project Phi', 11000000, 1),
(22, 'Project Chi', 11500000, 2),
(23, 'Project Psi', 12000000, 3),
(24, 'Project Omega', 12500000, 4),
(25, 'Project AlphaPrime', 13000000, 5);

*/

/*
INSERT INTO `UptechSol`.`Client` (`C_id`, `C_name`) VALUES
(1, 'Client One'),
(2, 'Client Two'),
(3, 'Client Three'),
(4, 'Client Four'),
(5, 'Client Five'),
(6, 'Client Six'),
(7, 'Client Seven'),
(8, 'Client Eight'),
(9, 'Client Nine'),
(10, 'Client Ten');
*/

/*
INSERT INTO `UptechSol`.`Finance` (`Salary`, `Employee_idEmployee`) VALUES
(60000, 1),
(70000, 2),
(80000, 3),
(90000, 4),
(100000, 5),
(110000, 6),
(120000, 7),
(130000, 8),
(140000, 9),
(150000, 10),
(160000, 11),
(170000, 12),
(180000, 13),
(190000, 14),
(200000, 15),
(210000, 16),
(220000, 17),
(230000, 18),
(240000, 19),
(250000, 20),
(260000, 21),
(270000, 22),
(280000, 23),
(290000, 24),
(300000, 25);
*/

/*
INSERT INTO `UptechSol`.`HR` (`Resources`, `Employee_idEmployee`) VALUES
(10, 1),
(15, 2),
(20, 3),
(25, 4),
(30, 5),
(35, 6),
(40, 7),
(45, 8),
(50, 9),
(55, 10),
(60, 11),
(65, 12),
(70, 13),
(75, 14),
(80, 15),
(85, 16),
(90, 17),
(95, 18),
(100, 19),
(105, 20),
(110, 21),
(115, 22),
(120, 23),
(125, 24),
(130, 25);
*/

/*
INSERT INTO `UptechSol`.`Employee_has_Project` (`Employee_idEmployee`, `Project_P_no`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 1),
(12, 2),
(13, 3),
(14, 4),
(15, 5),
(16, 6),
(17, 7),
(18, 8),
(19, 9),
(20, 10),
(21, 1),
(22, 2),
(23, 3),
(24, 4),
(25, 5);
*/
/*
INSERT INTO `UptechSol`.`Attendance` (`Date`, `Status`, `Employee_idEmployee`) VALUES
('2024-01-01', 'Present', 1),
('2024-01-02', 'Present', 2),
('2024-01-03', 'Absent', 3),
('2024-01-04', 'Present', 4),
('2024-01-05', 'Present', 5),
('2024-01-06', 'Absent', 6),
('2024-01-07', 'Present', 7),
('2024-01-08', 'Present', 8),
('2024-01-09', 'Absent', 9),
('2024-01-10', 'Present', 10),
('2024-01-11', 'Present', 11),
('2024-01-12', 'Absent', 12),
('2024-01-13', 'Present', 13),
('2024-01-14', 'Present', 14),
('2024-01-15', 'Absent', 15),
('2024-01-16', 'Present', 16),
('2024-01-17', 'Present', 17),
('2024-01-18', 'Absent', 18),
('2024-01-19', 'Present', 19),
('2024-01-20', 'Present', 20),
('2024-01-21', 'Absent', 21),
('2024-01-22', 'Present', 22),
('2024-01-23', 'Present', 23),
('2024-01-24', 'Absent', 24),
('2024-01-25', 'Present', 25);
*/

/*
SELECT 
    e.idEmployee AS ID,
    e.Name,
    e.Gender,
    e.DOJ AS JoinngDate,
    e.DOB AS Birthday,
    e.Address,
    f.Salary,
    d.D_name AS Department
FROM
    Employee e
        INNER JOIN
    Finance f ON e.idEmployee = f.Employee_idEmployee
        INNER JOIN
    Department d ON e.idEmployee = d.Employee_idEmployee;
    
    */


/*
SELECT 
    c.C_id AS ClientID,
    c.C_name AS ClientName,
    p.P_name AS ProjectName,
    p.Budget
FROM
    Client c
        INNER JOIN
    Project p ON c.C_id = p.Client_C_id;
*/

/*
SELECT 
    p.P_no AS Project_ID,
    p.P_name AS Project_Name,
    p.Budget AS Project_Budget,
    e.Name AS Employee_Name,
    c.C_name AS Client_Name
FROM
    Project p
        INNER JOIN
    Employee_has_Project ep ON p.P_no = ep.Project_P_no
        INNER JOIN
    Employee e ON ep.Employee_idEmployee = e.idEmployee
        INNER JOIN
    Client c ON p.Client_C_id = c.C_id;
*/
/*

SELECT 
    e.idEmployee AS Employee_ID,
    f.Salary AS Employee_Salary,
    p.P_no AS Project_ID,
    p.P_name AS Project_Name,
    p.Budget AS Project_Budget
FROM
    Employee e
        INNER JOIN
    Finance f ON e.idEmployee = f.Employee_idEmployee
        INNER JOIN
    Employee_has_Project ep ON e.idEmployee = ep.Employee_idEmployee
        INNER JOIN
    Project p ON ep.Project_P_no = p.P_no;
    
    */
    
    /*
    SELECT 
    e.idEmployee AS EmployeeID,
    e.Name AS EmployeeName,
    a.Date AS AttendanceDate,
    a.Status AS AttendanceStatus
FROM
    Employee e
        INNER JOIN
    Attendance a ON e.idEmployee = a.Employee_idEmployee;

*/
