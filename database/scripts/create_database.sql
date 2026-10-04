CREATE DATABASE cadastro_veiculos;

USE cadastro_veiculos;

CREATE TABLE Veiculos (
    Id INT NOT NULL AUTO_INCREMENT,
    Placa VARCHAR(10) NOT NULL,
    Marca VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Cor VARCHAR(30) NOT NULL,
    Ano INT NOT NULL,
    Porte VARCHAR(20)  NOT NULL,
    TipoCarga VARCHAR(30)  NOT NULL,
    Chassis VARCHAR(17)  NOT NULL,
    CONSTRAINT PK_Veiculos PRIMARY KEY (Id),
    CONSTRAINT UQ_Veiculos_Placa   UNIQUE (Placa),
    CONSTRAINT UQ_Veiculos_Chassis UNIQUE (Chassis)
);

-- Índice para facilitar a pesquisa por modelo
CREATE INDEX IX_Veiculos_Modelo ON Veiculos (Modelo);
