CREATE TABLE `properties` (
  `idproperties` int NOT NULL AUTO_INCREMENT,
  `name` varchar(256) NOT NULL,
  `bairro` varchar(256) NOT NULL,
  `numero` int NOT NULL,
  `cidade` varchar(256) NOT NULL,
  `cep` varchar(9) NOT NULL,
  `estado` varchar(45) NOT NULL,
  `idUser` int DEFAULT NULL,
  `isRented` tinyint NOT NULL,
  PRIMARY KEY (`idproperties`),
  KEY `FK_Properties_User_idx` (`idUser`),
  CONSTRAINT `FK_Properties_User` FOREIGN KEY (`idUser`) REFERENCES `user` (`iduser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
