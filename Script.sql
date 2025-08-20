-- CRIANDO O BANCO DE DADOS

-- USANDO BANCO DE DADOS
CREATE DATABASE BDProjeto;
use BDProjeto;

-- CRIANDO AS TABELAS DO BANCO DE DADOS
CREATE TABLE tbLogin(
 codLogin int primary key auto_increment,
usuario varchar(40),
senha varchar(40)

);

-- CONSULTANDO AS TABELAS DO BANCO
SELECT * FROM tbLogin;
INSERT INTO tbLogin(usuario,senha) values('cidade','city@2025');

