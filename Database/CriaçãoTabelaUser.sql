CREATE TABLE `user` (
  `iduser` int NOT NULL AUTO_INCREMENT,
  `userName` varchar(256) NOT NULL,
  `userCPF` varchar(11) NOT NULL,
  `userPasswordHash` varchar(256) NOT NULL,
  `adminUser` tinyint NOT NULL,
  PRIMARY KEY (`iduser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
