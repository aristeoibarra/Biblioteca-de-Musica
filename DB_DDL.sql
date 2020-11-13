CREATE DATABASE `musicbit` /*!40100 DEFAULT CHARACTER SET utf8 */;

-- musicbit.artista definition

CREATE TABLE `artista` (
  `cve_artista` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_artista` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`cve_artista`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- musicbit.genero definition

CREATE TABLE `genero` (
  `cve_genero` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_genero` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`cve_genero`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- musicbit.cancion definition

CREATE TABLE `cancion` (
  `cve_cancion` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_cancion` varchar(100) DEFAULT NULL,
  `letra_cancion` varchar(20000) DEFAULT NULL,
  `cveartista_cancion` int(11) DEFAULT NULL,
  `cvegenero_cancion` int(11) DEFAULT NULL,
  PRIMARY KEY (`cve_cancion`),
  KEY `FKartista_cancion` (`cveartista_cancion`),
  KEY `FKgenero_cancion` (`cvegenero_cancion`),
  CONSTRAINT `FKartista_cancion` FOREIGN KEY (`cveartista_cancion`) REFERENCES `artista` (`cve_artista`) ON DELETE CASCADE,
  CONSTRAINT `FKgenero_cancion` FOREIGN KEY (`cvegenero_cancion`) REFERENCES `genero` (`cve_genero`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;