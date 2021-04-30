CREATE DATABASE senai_hroads_tarde;

USE senai_hroads_tarde;

CREATE TABLE TipoHabilidade
(
	 IdTipo INT PRIMARY KEY IDENTITY
	,NomeTipo VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Habilidades
(
	 IdHabilidade INT PRIMARY KEY IDENTITY
	,IdTipo INT FOREIGN KEY REFERENCES TipoHabilidade(IdTipo)
	,NomeHabilidade VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Classe
(
	 IdClasse INT PRIMARY KEY IDENTITY
	,NomeClasse VARCHAR(100)
);
GO

CREATE TABLE ClasseHabilidade
(
	 IdClasse INT FOREIGN KEY REFERENCES Classe(IdClasse)
	,IdHabilidade INT FOREIGN KEY REFERENCES Habilidades(IdHabilidade)
);
GO

CREATE TABLE Personagens
(
	 IdPersonagem INT PRIMARY KEY IDENTITY
	,IdClasse INT FOREIGN KEY REFERENCES Classe(IdClasse)
	,NomePersonagem VARCHAR(200) NOT NULL
	,CapacidadeMAXVida VARCHAR(300) NOT NULL
	,CapacidadeMAXMana VARCHAR(300) NOT NULL
	,DataAtualizacao VARCHAR(200) NOT NULL
	,DataCriacao VARCHAR(300) NOT NULL
);
GO

CREATE TABLE tipoUsuario
(
	 idTipoUsuario INT PRIMARY KEY IDENTITY
	,tituloTipoUsuario VARCHAR (100) NOT NULL
);
GO

CREATE TABLE usuario
(
	idUsuario INT PRIMARY KEY IDENTITY
	,idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario (idTipoUsuario)
	,email VARCHAR (250) UNIQUE NOT NULL
	,senha VARCHAR (250) NOT NULL
);
GO

