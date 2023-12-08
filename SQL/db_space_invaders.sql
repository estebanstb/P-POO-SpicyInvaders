-- MySQL dump 10.13  Distrib 5.7.11, for Win32 (AMD64)
--
-- Host: localhost    Database: db_space_invaders
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `db_space_invaders`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `db_space_invaders` ;

USE `db_space_invaders`;

--
-- Table structure for table `t_arme`
--

DROP TABLE IF EXISTS `t_arme`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
CREATE TABLE `t_arme` (
  `idArme` int NOT NULL AUTO_INCREMENT,
  `armNom` varchar(255) NOT NULL,
  `armDescription` text,
  `armPrix` int NOT NULL,
  `armForce` int NOT NULL,
  `armNombreCoups` int DEFAULT NULL,
  PRIMARY KEY (`idArme`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_arme`
--

LOCK TABLES `t_arme` WRITE;
/*!40000 ALTER TABLE `t_arme` DISABLE KEYS */;
INSERT INTO `t_arme` VALUES (1,'Laser basique','Un laser standard avec une force modérée.',100,50,20),(2,'Missile nucléaire','Arme très puissante capable de détruire plusieurs ennemis en une fois.',5000,500,1),(3,'Canon à plasma','Tire des boules de plasma à haute température.',800,200,5),(4,'Bouclier magnétique','Une arme défensive qui repousse les projectiles ennemis.',1200,0,10),(5,'Bombes à fragmentation','Explose en plusieurs mini-bombes après le lancement.',1500,250,3),(6,'Rayon gelant','Immobilise temporairement les ennemis en les gelant sur place.',700,25,15),(7,'Torpilles cosmiques','Des torpilles qui suivent les ennemis.',1200,150,5),(8,'Désintégrateur','Rayon puissant qui vaporise l’ennemi instantanément.',2500,400,2),(9,'Ondes soniques','Émet des ondes sonores déstabilisantes.',550,60,10),(10,'Électro-pulse','Une arme qui lance des impulsions électriques paralysantes.',950,80,7),(11,'Lance-roquettes quantique','Tire des roquettes avec une technologie quantique avancée.',2000,280,4),(12,'Vortex noir','Crée un mini trou noir qui aspire tout sur son passage.',5000,1000,1),(13,'Bouclier énergétique','Un bouclier qui absorbe les attaques ennemies pendant un court laps de temps.',1500,0,3),(14,'Champ de force magnétique','Repousse les projectiles ennemis proches.',1200,0,5),(15,'Drone protecteur','Un drone qui vole autour du joueur et intercepte les tirs ennemis.',2000,0,1),(16,'Miroir réfléchissant','Renvoie les projectiles ennemis dans leur direction d\'origine.',1800,0,4),(17,'Générateur de brouillard','Crée un brouillard épais, rendant le joueur moins visible pour une courte durée.',1000,0,3),(18,'Capsule temporelle','Ralentit le temps autour du joueur, permettant d\'éviter plus facilement les attaques.',2500,0,2),(19,'Distorsionneur spatial','Téléporte le joueur dans une position aléatoire à l\'écran pour échapper aux attaques.',2200,0,2);
/*!40000 ALTER TABLE `t_arme` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_arsenal`
--

DROP TABLE IF EXISTS `t_arsenal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_arsenal` (
  `fkArme` int NOT NULL,
  `fkJoueur` int NOT NULL,
  `arsNombreCoupsRestant` int NOT NULL,
  PRIMARY KEY (`fkArme`,`fkJoueur`),
  KEY `fkJoueur` (`fkJoueur`),
  CONSTRAINT `t_arsenal_ibfk_1` FOREIGN KEY (`fkArme`) REFERENCES `t_arme` (`idArme`),
  CONSTRAINT `t_arsenal_ibfk_2` FOREIGN KEY (`fkJoueur`) REFERENCES `t_joueur` (`idJoueur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_arsenal`
--

LOCK TABLES `t_arsenal` WRITE;
/*!40000 ALTER TABLE `t_arsenal` DISABLE KEYS */;
INSERT INTO `t_arsenal` VALUES (1,1,8),(2,2,6),(3,3,7),(4,4,5),(5,5,9),(6,6,4),(7,7,7),(8,8,6),(9,9,8),(10,10,5);
/*!40000 ALTER TABLE `t_arsenal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_commande`
--

DROP TABLE IF EXISTS `t_commande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_commande` (
  `idCommande` int NOT NULL AUTO_INCREMENT,
  `comDate` date NOT NULL,
  `comNumeroCommande` varchar(255) NOT NULL,
  `fkJoueur` int NOT NULL,
  PRIMARY KEY (`idCommande`),
  KEY `fkJoueur` (`fkJoueur`),
  CONSTRAINT `t_commande_ibfk_1` FOREIGN KEY (`fkJoueur`) REFERENCES `t_joueur` (`idJoueur`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_commande`
--

LOCK TABLES `t_commande` WRITE;
/*!40000 ALTER TABLE `t_commande` DISABLE KEYS */;
INSERT INTO `t_commande` VALUES (1,'2023-08-22','CMD001',4),(2,'2023-08-22','CMD002',11),(3,'2023-08-23','CMD003',7),(4,'2023-08-23','CMD004',4),(5,'2023-08-24','CMD005',5),(6,'2023-08-24','CMD006',6),(7,'2023-08-25','CMD007',7),(8,'2023-08-25','CMD008',8),(9,'2023-08-26','CMD009',9),(10,'2023-08-26','CMD010',1),(11,'2023-08-27','CMD011',2),(12,'2023-08-27','CMD012',2),(13,'2023-08-28','CMD013',3),(14,'2023-08-28','CMD014',1),(15,'2023-08-29','CMD015',5),(16,'2023-08-29','CMD016',6),(17,'2023-08-30','CMD017',7),(18,'2023-08-30','CMD018',8),(19,'2023-08-31','CMD019',9),(20,'2023-08-31','CMD020',1);
/*!40000 ALTER TABLE `t_commande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_detail_commande`
--

DROP TABLE IF EXISTS `t_detail_commande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_detail_commande` (
  `fkCommande` int NOT NULL,
  `fkArme` int NOT NULL,
  `detQuantiteCommande` int NOT NULL,
  PRIMARY KEY (`fkCommande`,`fkArme`),
  KEY `fkArme` (`fkArme`),
  CONSTRAINT `t_detail_commande_ibfk_1` FOREIGN KEY (`fkCommande`) REFERENCES `t_commande` (`idCommande`),
  CONSTRAINT `t_detail_commande_ibfk_2` FOREIGN KEY (`fkArme`) REFERENCES `t_arme` (`idArme`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_detail_commande`
--

LOCK TABLES `t_detail_commande` WRITE;
/*!40000 ALTER TABLE `t_detail_commande` DISABLE KEYS */;
INSERT INTO `t_detail_commande` VALUES (1,1,2),(1,2,1),(2,3,3),(2,4,2),(3,5,1),(3,6,3),(4,7,2),(4,8,1),(5,9,1),(5,10,2),(6,11,2),(6,12,1),(7,13,3),(7,14,1),(8,15,1),(8,16,2),(9,17,1),(9,18,2),(10,19,3),(11,1,1),(11,2,2),(12,3,1),(12,4,3),(13,5,2),(13,6,1),(14,7,1),(14,8,2),(15,9,2),(15,10,1),(16,11,2),(16,12,1),(17,13,1),(17,14,3),(18,15,3),(18,16,1),(19,17,2),(19,18,2),(20,19,1);
/*!40000 ALTER TABLE `t_detail_commande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_joueur`
--

DROP TABLE IF EXISTS `t_joueur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_joueur` (
  `idJoueur` int NOT NULL AUTO_INCREMENT,
  `jouPseudo` varchar(255) DEFAULT NULL,
  `jouNombrePoints` int NOT NULL,
  PRIMARY KEY (`idJoueur`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_joueur`
--

LOCK TABLES `t_joueur` WRITE;
/*!40000 ALTER TABLE `t_joueur` DISABLE KEYS */;
INSERT INTO `t_joueur` VALUES (1,'PlayerOne',5000),(2,'PlayerTwo',5500),(3,'PlayerThree',6000),(4,'GalacticGamer',4500),(5,'SpaceRanger',6200),(6,'InvaderZapper',5300),(7,'LunarLander',4800),(8,'CosmicCrusader',4900),(9,'StarStriker',5600),(10,'AstroAce',5750),(11,NULL,5150);
/*!40000 ALTER TABLE `t_joueur` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-23  9:05:49
