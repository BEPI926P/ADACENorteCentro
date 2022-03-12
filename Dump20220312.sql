CREATE DATABASE  IF NOT EXISTS `Auditoria` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `Auditoria`;
-- MySQL dump 10.13  Distrib 8.0.20, for macos10.15 (x86_64)
--
-- Host: localhost    Database: Auditoria
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Contribuyente`
--

DROP TABLE IF EXISTS `Contribuyente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Contribuyente` (
  `idContribuyente` int NOT NULL AUTO_INCREMENT,
  `NombredeContribuyente` varchar(100) NOT NULL,
  `RFC` varchar(15) NOT NULL,
  `GiroContribuyente` varchar(255) NOT NULL,
  `DomicilioFiscal` varchar(200) NOT NULL,
  `DomicilioParaOiryRecibirNotificaciones` varchar(200) NOT NULL,
  PRIMARY KEY (`idContribuyente`),
  KEY `RFC` (`RFC`,`idContribuyente`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Contribuyente`
--

LOCK TABLES `Contribuyente` WRITE;
/*!40000 ALTER TABLE `Contribuyente` DISABLE KEYS */;
INSERT INTO `Contribuyente` VALUES (1,'Traver Stone International S.A. de C.V.','TSI100709K84','Venta de Marmol','Avenida Escobedo Ote. número exterior 46, número interior 7 Altos, colonia Centro, C.P. 27000, Torreón, Coahuila de Zaragoza.','Avenida Escobedo Ote. número exterior 46, número interior 7 Altos, colonia Centro, C.P. 27000, Torreón, Coahuila de Zaragoza.');
/*!40000 ALTER TABLE `Contribuyente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Expediente`
--

DROP TABLE IF EXISTS `Expediente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Expediente` (
  `idExpediente` varchar(30) NOT NULL,
  `NumerodeOrden` varchar(20) NOT NULL,
  `TipodeRevision` varchar(100) NOT NULL,
  `idContribuyente` varchar(45) NOT NULL,
  `FechadeApertura` datetime NOT NULL,
  `FechadeCierre` datetime DEFAULT NULL,
  PRIMARY KEY (`idExpediente`),
  KEY `NumerodeOrden` (`NumerodeOrden`),
  KEY `idEmpresa` (`idContribuyente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Expediente`
--

LOCK TABLES `Expediente` WRITE;
/*!40000 ALTER TABLE `Expediente` DISABLE KEYS */;
INSERT INTO `Expediente` VALUES ('7s-005-00000009-2830s','CPA59000009/22','PAMA','1','2022-03-08 23:30:00',NULL);
/*!40000 ALTER TABLE `Expediente` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-12 14:47:58
