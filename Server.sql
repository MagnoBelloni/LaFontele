﻿CREATE DATABASE DB_BAR;

USE DB_BAR;

CREATE TABLE TB_LOGIN(
	ID_LOGIN INT identity(1,1) ,
    USU_LOGIN VARCHAR(30) UNIQUE NOT NULL ,
    SENHA_LOGIN VARCHAR(30)NOT NULL ,
    PRIMARY KEY(ID_LOGIN) 
);

CREATE TABLE TB_FUNCIONARIO(
	ID_FUNCIONARIO INT identity(1,1) NOT NULL,
    NM_FUNCIONARIO VARCHAR(50) NOT NULL,
    TEL_FUNCIONARIO CHAR(10) NOT NULL,
    CEL_FUNCIONARIO CHAR(11) NOT NULL,
    RG_FUNCIONARIO CHAR(9) NOT NULL UNIQUE,
    CPF_FUNCIONARIO CHAR(11) NOT NULL UNIQUE,
    CIDADE_FUNCINARIO VARCHAR(40) NOT NULL,
    BAIRRO_FUNCIONARIO VARCHAR(40) NOT NULL,
    LOGRADOURO_FUNCIONARIO VARCHAR(70) NOT NULL,
    N_FUNCIONARIO VARCHAR(5) NOT NULL,
    COMPLEMENTO_FUNCIONARIO VARCHAR(40),
    IDENTIFICADOR_FUNCIONARIO CHAR(10) NOT NULL UNIQUE,
    BANCO_FUNCIONARIO VARCHAR(35) NOT NULL,
    CONTA_FUNCIONARIO VARCHAR(20) NOT NULL,
    AGENCIA_FUNCIONARIO VARCHAR(20) NOT NULL,
    PRIMARY KEY(ID_FUNCIONARIO)
);

CREATE TABLE TB_PRODUTO(
	ID_PRODUTO INT identity(1,1) NOT NULL,
    NM_PRODUTO VARCHAR(45) NOT NULL,
    UM_PRODUTO VARCHAR(15) NOT NULL,
    QTD_PRODUTO INT NOT NULL ,
    VL_PRODUTO DECIMAL(8,2) NOT NULL,
    TP_PRODUTO VARCHAR(25) NOT NULL,
    PRIMARY KEY(ID_PRODUTO)
);

INSERT INTO TB_LOGIN VALUES('ABC','123');