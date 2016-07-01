-- MySQL Script generated by MySQL Workbench
-- 06/30/16 17:31:39
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema sgs
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sgs
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sgs` DEFAULT CHARACTER SET utf8 ;
USE `sgs` ;

-- -----------------------------------------------------
-- Table `sgs`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sgs`.`User` (
  `idUser` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(120) NOT NULL,
  `cpf` VARCHAR(14) NOT NULL,
  `address` VARCHAR(200) NOT NULL,
  `city` VARCHAR(50) NOT NULL,
  `district` VARCHAR(50) NOT NULL,
  `state` VARCHAR(2) NOT NULL,
  `cep` VARCHAR(9) NOT NULL,
  `accessLevel` INT NOT NULL COMMENT '0: Patient\n1: Receptionist\n2: Medic\n3: Administrator',
  PRIMARY KEY (`idUser`),
  UNIQUE INDEX `idUser_UNIQUE` (`idUser` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sgs`.`ClinicalHistoryItem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sgs`.`ClinicalHistoryItem` (
  `idClinicalHistoryItem` INT NOT NULL AUTO_INCREMENT,
  `date` DATETIME NOT NULL,
  `text` BLOB NOT NULL,
  PRIMARY KEY (`idClinicalHistoryItem`),
  UNIQUE INDEX `idClinicalHistoryItem_UNIQUE` (`idClinicalHistoryItem` ASC),
  CONSTRAINT `fk_ClinicalHistoryItem_User`
    FOREIGN KEY (`idClinicalHistoryItem`)
    REFERENCES `sgs`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sgs`.`Document`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sgs`.`Document` (
  `idDocument` INT NOT NULL AUTO_INCREMENT,
  `type` INT NOT NULL,
  `text` BLOB NOT NULL,
  PRIMARY KEY (`idDocument`),
  UNIQUE INDEX `idDocument_UNIQUE` (`idDocument` ASC),
  CONSTRAINT `fk_Document_ClinicalHistoryItem`
    FOREIGN KEY (`idDocument`)
    REFERENCES `sgs`.`ClinicalHistoryItem` (`idClinicalHistoryItem`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;