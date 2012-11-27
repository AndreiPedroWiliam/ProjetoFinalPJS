USE master;

CREATE DATABASE AcervoMusical;
GO

USE AcervoMusical;
GO

CREATE TABLE Album (
Id_Album INT PRIMARY KEY IDENTITY,
Interprete VARCHAR(60),
Autor VARCHAR(60),
Album VARCHAR(60),
Data DATE,
DataCompra DATE,
OrigemCompra VARCHAR(30),
TipoMidia VARCHAR(20),
Nota VARCHAR(2),
Observacao VARCHAR(60),
Status VARCHAR(15)
);

CREATE TABLE Pessoa (
Id_Pessoa INT PRIMARY KEY IDENTITY,
Nome VARCHAR(60),
Telefone VARCHAR(13),
Email VARCHAR(60),
Logradouro VARCHAR(60),
Numero VARCHAR(5),
Bairro VARCHAR(60),
Cidade VARCHAR(60),
UF VARCHAR(2)
);

CREATE TABLE Emprestimo (
Id_Emprestimo INT PRIMARY KEY IDENTITY,
DataEmprestimo DATE,
DataDevolucao DATE,
Id_Pessoa INT,
Id_Album INT,
FOREIGN KEY(Id_Pessoa) REFERENCES Pessoa (Id_Pessoa),
FOREIGN KEY(Id_Album) REFERENCES Album (Id_Album)
);

-- Formata a data do Banco para Dia-Mês-Ano
SET DATEFORMAT dmy


-- INSERT ALBUM --

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Pouca Vogal', 'Humberto G & Duca L', 'Pouca Vogal - Ao Vivo em Porto Alegre', '13-03-2009', '20-09-2009', 'Submarino', 
'DVD','9', '', 'Disponível');


INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES 
('James Blunt', 'James Blunt', 'Some Kind of Trouble', '11-05-2010', '10-04-2011', 'itunes', 'Digital', '8', '', 'Disponível');


-- INSERT PESSOAS --

INSERT INTO Pessoa (Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('Francisco da Silva','(12)3667-2244','chico@email.com','R: João Manuel de Siqueira', '55', 
'Jardim das Flores', 'Jumiranda', 'SP');

INSERT INTO Pessoa (Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('João Miguel dos Santos', '(12)3662-7751','Joao.ms@email.com','R: Jair Pereira S.', '74', 
'Vila Maria', 'Campos do Jordão', 'SP');

-- EMPRESTANDO UM ALBUM --


INSERT INTO Emprestimo (DataEmprestimo, DataDevolucao, Id_Pessoa, Id_Album) VALUES ('14-11-2012', null , 1, 1);
UPDATE Album SET Status = 'Emprestado' WHERE Id_Album = 1; 

-- DEVOLVENDO UM ALBUM --

UPDATE Emprestimo SET DataDevolucao = '22-11-2012' WHERE Id_Emprestimo = 1;

UPDATE Album SET Status = 'Disponível' WHERE Id_Album = 1; 
 
-- SELECT TELA INICIAL --

SELECT Id_Album, Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status FROM Album;

-- SELECT COUNT  TIPO DE MIDIAS, STATUS ALBUM, PESSOAS --

SELECT COUNT(*) AS 'QTD' FROM Pessoa;
SELECT COUNT(*) AS 'QTD' FROM Album;
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Digital';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'DVD';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'CD';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'K7';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Vinil';

SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Emprestado';

SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Disponível' AND TipoMidia!= 'Digital';

 --