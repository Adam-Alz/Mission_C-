-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 19, 2025 at 10:38 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sicilylines`
--

-- --------------------------------------------------------

--
-- Table structure for table `bateau`
--

CREATE TABLE `bateau` (
  `IDBATEAU` int(11) NOT NULL,
  `IDEQUIPEMENTS` int(11) NOT NULL,
  `NOMBATEAU` char(255) DEFAULT NULL,
  `LONGUEUR` bigint(4) DEFAULT NULL,
  `LARGEUR` bigint(4) DEFAULT NULL,
  `VITESSE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `categorie`
--

CREATE TABLE `categorie` (
  `IDCATEGORIE` int(11) NOT NULL,
  `NUMTRAVERSEE` int(11) NOT NULL,
  `CODELIAISON` int(11) NOT NULL,
  `LIBELLECATEGORIE` char(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `equipement`
--

CREATE TABLE `equipement` (
  `IDEQUIPEMENTS` int(11) NOT NULL,
  `LIBELLEEQUIPEMENTS` char(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `liaison`
--

CREATE TABLE `liaison` (
  `CODELIAISON` int(11) NOT NULL,
  `IDPORTDEPART` int(11) NOT NULL,
  `IDPORTARRIVEE` int(11) NOT NULL,
  `IDSECTEUR` int(11) NOT NULL,
  `DUREE` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `liaison`
--

INSERT INTO `liaison` (`CODELIAISON`, `IDPORTDEPART`, `IDPORTARRIVEE`, `IDSECTEUR`, `DUREE`) VALUES
(1, 10, 1, 3, '10:00:00'),
(11, 10, 2, 3, '00:50:00'),
(15, 8, 1, 1, '10:30:00'),
(16, 9, 3, 2, '01:25:00'),
(17, 9, 4, 2, '01:45:00'),
(19, 9, 5, 2, '02:05:00'),
(21, 11, 7, 4, '00:30:00'),
(25, 10, 4, 3, '00:40:00'),
(30, 11, 6, 4, '02:30:00');

-- --------------------------------------------------------

--
-- Table structure for table `periode`
--

CREATE TABLE `periode` (
  `IDPERIODE` int(11) NOT NULL,
  `DATEDEBUT` date DEFAULT NULL,
  `DATEFIN` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `port`
--

CREATE TABLE `port` (
  `IDPORT` int(11) NOT NULL,
  `NOMPORT` char(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `port`
--

INSERT INTO `port` (`IDPORT`, `NOMPORT`) VALUES
(1, 'Ustica'),
(2, 'Lipari'),
(3, 'Stromboli'),
(4, 'Vulcano'),
(5, 'Panarea'),
(6, 'Pantelleria'),
(7, 'Favignagna'),
(8, 'Palerme'),
(9, 'Messine'),
(10, 'Milazzo'),
(11, 'Trapani');

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `CODELIAISON` int(11) NOT NULL,
  `NUMTRAVERSEE` int(11) NOT NULL,
  `NUMRESERVATION` int(11) NOT NULL,
  `IDTYPE` int(11) NOT NULL,
  `DATERESERVATION` date DEFAULT NULL,
  `MONTANT` int(11) DEFAULT NULL,
  `NOMCLIENT` char(255) DEFAULT NULL,
  `ADRESSECLIENT` char(255) DEFAULT NULL,
  `CPCLIENT` char(255) DEFAULT NULL,
  `VILLECLIENT` char(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `secteur`
--

CREATE TABLE `secteur` (
  `IDSECTEUR` int(11) NOT NULL,
  `NOMSECTEUR` char(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `secteur`
--

INSERT INTO `secteur` (`IDSECTEUR`, `NOMSECTEUR`) VALUES
(1, 'Palerme'),
(2, 'Messine'),
(3, 'Milazzo'),
(4, 'Trapani');

-- --------------------------------------------------------

--
-- Table structure for table `tarif`
--

CREATE TABLE `tarif` (
  `CODELIAISON` int(11) NOT NULL,
  `IDTYPE` int(11) NOT NULL,
  `IDPERIODE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `traversee`
--

CREATE TABLE `traversee` (
  `CODELIAISON` int(11) NOT NULL,
  `NUMTRAVERSEE` int(11) NOT NULL,
  `IDBATEAU` int(11) NOT NULL,
  `DATEHEUREDEPART` datetime DEFAULT NULL,
  `PLACESDISPOPASSAGERS` int(11) DEFAULT NULL,
  `PLACESDISPOVEHINF2M` int(11) DEFAULT NULL,
  `PLACESDISPOVEHSUP2M` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `type`
--

CREATE TABLE `type` (
  `IDTYPE` int(11) NOT NULL,
  `NUMRESERVATION` int(11) NOT NULL,
  `NUMTRAVERSEE` int(11) NOT NULL,
  `CODELIAISON` int(11) NOT NULL,
  `IDCATEGORIE` int(11) NOT NULL,
  `LIBELLETYPE` char(255) DEFAULT NULL,
  `CATEGORIE` char(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bateau`
--
ALTER TABLE `bateau`
  ADD PRIMARY KEY (`IDBATEAU`),
  ADD KEY `I_FK_BATEAU_EQUIPEMENT` (`IDEQUIPEMENTS`);

--
-- Indexes for table `categorie`
--
ALTER TABLE `categorie`
  ADD PRIMARY KEY (`IDCATEGORIE`),
  ADD KEY `I_FK_CATEGORIE_TRAVERSEE` (`CODELIAISON`,`NUMTRAVERSEE`);

--
-- Indexes for table `equipement`
--
ALTER TABLE `equipement`
  ADD PRIMARY KEY (`IDEQUIPEMENTS`);

--
-- Indexes for table `liaison`
--
ALTER TABLE `liaison`
  ADD PRIMARY KEY (`CODELIAISON`),
  ADD KEY `I_FK_LIAISON_PORT` (`IDPORTDEPART`),
  ADD KEY `I_FK_LIAISON_PORT1` (`IDPORTARRIVEE`),
  ADD KEY `I_FK_LIAISON_SECTEUR` (`IDSECTEUR`);

--
-- Indexes for table `periode`
--
ALTER TABLE `periode`
  ADD PRIMARY KEY (`IDPERIODE`);

--
-- Indexes for table `port`
--
ALTER TABLE `port`
  ADD PRIMARY KEY (`IDPORT`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`CODELIAISON`,`NUMTRAVERSEE`,`NUMRESERVATION`),
  ADD UNIQUE KEY `I_FK_RESERVATION_TYPE` (`IDTYPE`),
  ADD KEY `I_FK_RESERVATION_TRAVERSEE` (`CODELIAISON`,`NUMTRAVERSEE`);

--
-- Indexes for table `secteur`
--
ALTER TABLE `secteur`
  ADD PRIMARY KEY (`IDSECTEUR`);

--
-- Indexes for table `tarif`
--
ALTER TABLE `tarif`
  ADD PRIMARY KEY (`CODELIAISON`,`IDTYPE`,`IDPERIODE`),
  ADD KEY `I_FK_TARIF_LIAISON` (`CODELIAISON`),
  ADD KEY `I_FK_TARIF_TYPE` (`IDTYPE`),
  ADD KEY `I_FK_TARIF_PERIODE` (`IDPERIODE`);

--
-- Indexes for table `traversee`
--
ALTER TABLE `traversee`
  ADD PRIMARY KEY (`CODELIAISON`,`NUMTRAVERSEE`),
  ADD KEY `I_FK_TRAVERSEE_LIAISON` (`CODELIAISON`),
  ADD KEY `I_FK_TRAVERSEE_BATEAU` (`IDBATEAU`);

--
-- Indexes for table `type`
--
ALTER TABLE `type`
  ADD PRIMARY KEY (`IDTYPE`),
  ADD UNIQUE KEY `I_FK_TYPE_RESERVATION` (`CODELIAISON`,`NUMTRAVERSEE`,`NUMRESERVATION`),
  ADD KEY `I_FK_TYPE_CATEGORIE` (`IDCATEGORIE`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bateau`
--
ALTER TABLE `bateau`
  ADD CONSTRAINT `FK_BATEAU_EQUIPEMENT` FOREIGN KEY (`IDEQUIPEMENTS`) REFERENCES `equipement` (`IDEQUIPEMENTS`);

--
-- Constraints for table `categorie`
--
ALTER TABLE `categorie`
  ADD CONSTRAINT `FK_CATEGORIE_TRAVERSEE` FOREIGN KEY (`CODELIAISON`,`NUMTRAVERSEE`) REFERENCES `traversee` (`CODELIAISON`, `NUMTRAVERSEE`);

--
-- Constraints for table `liaison`
--
ALTER TABLE `liaison`
  ADD CONSTRAINT `FK_LIAISON_PORT` FOREIGN KEY (`IDPORTDEPART`) REFERENCES `port` (`IDPORT`),
  ADD CONSTRAINT `FK_LIAISON_PORT1` FOREIGN KEY (`IDPORTARRIVEE`) REFERENCES `port` (`IDPORT`),
  ADD CONSTRAINT `FK_LIAISON_SECTEUR` FOREIGN KEY (`IDSECTEUR`) REFERENCES `secteur` (`IDSECTEUR`);

--
-- Constraints for table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `FK_RESERVATION_TRAVERSEE` FOREIGN KEY (`CODELIAISON`,`NUMTRAVERSEE`) REFERENCES `traversee` (`CODELIAISON`, `NUMTRAVERSEE`),
  ADD CONSTRAINT `FK_RESERVATION_TYPE` FOREIGN KEY (`IDTYPE`) REFERENCES `type` (`IDTYPE`);

--
-- Constraints for table `tarif`
--
ALTER TABLE `tarif`
  ADD CONSTRAINT `FK_TARIF_LIAISON` FOREIGN KEY (`CODELIAISON`) REFERENCES `liaison` (`CODELIAISON`),
  ADD CONSTRAINT `FK_TARIF_PERIODE` FOREIGN KEY (`IDPERIODE`) REFERENCES `periode` (`IDPERIODE`),
  ADD CONSTRAINT `FK_TARIF_TYPE` FOREIGN KEY (`IDTYPE`) REFERENCES `type` (`IDTYPE`);

--
-- Constraints for table `traversee`
--
ALTER TABLE `traversee`
  ADD CONSTRAINT `FK_TRAVERSEE_BATEAU` FOREIGN KEY (`IDBATEAU`) REFERENCES `bateau` (`IDBATEAU`),
  ADD CONSTRAINT `FK_TRAVERSEE_LIAISON` FOREIGN KEY (`CODELIAISON`) REFERENCES `liaison` (`CODELIAISON`);

--
-- Constraints for table `type`
--
ALTER TABLE `type`
  ADD CONSTRAINT `FK_TYPE_CATEGORIE` FOREIGN KEY (`IDCATEGORIE`) REFERENCES `categorie` (`IDCATEGORIE`),
  ADD CONSTRAINT `FK_TYPE_RESERVATION` FOREIGN KEY (`CODELIAISON`,`NUMTRAVERSEE`,`NUMRESERVATION`) REFERENCES `reservation` (`CODELIAISON`, `NUMTRAVERSEE`, `NUMRESERVATION`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
