-- Database: find_supermarket

-- DROP DATABASE IF EXISTS find_supermarket;

CREATE DATABASE find_supermarket
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

CREATE EXTENSION postgis;

SELECT postgis_full_version();

CREATE TABLE Zona (
  idz INT NOT NULL,
  população INT,
  geom GEOMETRY,
  name VARCHAR,
  PRIMARY KEY (idz));

CREATE TABLE Via (
  idv INT NOT NULL,
  tamanho INT,
  geom GEOMETRY,
  nome VARCHAR,
  PRIMARY KEY (idv));

CREATE TABLE Supermercado (
  ids INT NOT NULL,
  tipo VARCHAR,
  geom GEOMETRY,
  nome VARCHAR,
  idz INT,
  PRIMARY KEY (ids),
  FOREIGN KEY (idz) REFERENCES Zona(idz));

CREATE TABLE Produto (
  idp INT NOT NULL,
  nomeDoProduto VARCHAR,
  qtd INT,
  ids INT,
  PRIMARY KEY (idp),
  FOREIGN KEY (ids) REFERENCES Supermercado(ids));

CREATE TABLE conduz (
  idv INT NOT NULL,
  ids INT NOT NULL,
  PRIMARY KEY (idv, ids),
  FOREIGN KEY (idv) REFERENCES Via(idv),
  FOREIGN KEY (ids) REFERENCES Supermercado(ids));


CREATE VIEW  PRODUTO_ZONA AS SELECT s.tipo tipo_supermercado, s.nome nome_supermercado, p.nomedoproduto nome_produto, p.qtd qtd_produto, z.name nome_zona 
FROM supermercado AS s
INNER JOIN zona z ON z.idz = s.idZ
INNER JOIN produto p ON s.ids = p.ids;

SELECT nome_zona from produto_zona where nome_produto = 'Frango';