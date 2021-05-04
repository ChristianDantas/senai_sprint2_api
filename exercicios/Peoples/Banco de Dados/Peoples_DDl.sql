CREATE DATABASE T_Peoples;

USE T_Peoples;

CREATE TABLE funcionarios
(
    idFuncionarios INT PRIMARY KEY IDENTITY
    ,nome VARCHAR (200) NOT NULL
    ,sobrenome VARCHAR (200) NOT NULL
);
