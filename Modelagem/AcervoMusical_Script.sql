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

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Michael Jackson', 'Michael Jackson', 'Thriller', '01-02-1982', '14-10-1994', 'Bolacha Discos', 'Vinil', '10', '', 'Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('AC/DC', 'AC/DC', 'Back in Black', '09-05-1980', '05-01-1995', 'Locomotiva Discos', 'K7', '10', '', 'Disponível' );

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Pink Floyd', 'Pink Floyd', 'The Dark Side of the Moon', '12-07-1973', '07-03-1995', 'Pocket Music', 'CD', '10', '', 'Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Led Zeppelin', 'Led Zeppelin', 'Led Zeppelin IV', '03-04-1971', '10-07-1993', 'Locomotiva Discos', 'K7', '9', '', 'Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Bruce Springsteen', 'Bruce Springsteen', 'Born in the U.S.A.', '09-08-1984', '18-09-1994', 'Bolacha Discos', 'Vinil', '9','','Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Dire Straits', 'Dire Straits', 'Brothers in Arms', '12-10-1985', '06-09-1997', 'Bolacha Discos', 'DVD', '10', '', 'Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Guns N Roses', 'Guns N Roses', 'Appetite for Destruction', '10-10-1987', '18-09-1992', 'Locomotiva Discos', 'Vinil', '10', '', 'Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Metallica', 'Metallica', 'Metallica', '17-11-1991', '23-08-1994', 'Bolacha Discos', 'Vinil', '10', '', 'Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Nirvana', 'Nirvana', 'Nevermind', '16-09-1991', '22-09-1994', 'Bolacha Discos', 'Vinil', '10', '','Disponível');

INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status) VALUES
('Guns N Roses', 'Guns N Roses', 'Use Your Illusion II', '16-09-1991', '22-09-1994', 'Bolacha Discos', 'Vinil', '10', '','Disponível');


-- INSERT PESSOAS --

INSERT INTO Pessoa (Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('Francisco da Silva','(12)3667-2244','chico@email.com','R: João Manuel de Siqueira', '55', 
'Jardim das Flores', 'Jumiranda', 'SP');

INSERT INTO Pessoa (Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('João Miguel dos Santos', '(12)3662-7751','Joao.ms@email.com','R: Jair Pereira S.', '74', 
'Vila Maria', 'Campos do Jordão', 'SP');

INSERT INTO Pessoa(Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES
('Andrei Agdo da Rosa','(12)9605-1283','andrei.ifsp@hotmail.com','Rua Benedito Vasconcelos de Oliveira','269','Vila Eliza','Campos do Jordão','SP');

INSERT INTO Pessoa(Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('Wiliam Alexandre Costa','(12)9711-5208','wiliam_costa@yahoo.com.br','Rua Augusto Pagliacci','400','Jardim California','Campos do Jordão','SP');

INSERT INTO Pessoa(Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('Pedro Hugo Makito Sakurai de Lemos','(12)9733-6351', 'pedro.tanaka@hotmail.com','Rua Felicio Raimundo','198','Abernessia','Campos do Jordão','SP');

INSERT INTO Pessoa(Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('Alvaro Costa Neto','(12)0000-0000', 'alvaro.ifsp@hotmail.com','Rua Inacio Caetano','228','Ferraz','Campos do Jordão','SP');

INSERT INTO Pessoa(Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES 
('Fernado J. S. Melllo','(12)3668-9090', 'fernandojmellllo@live.com','Rua da fortuna','39','Jaguaribe','Campos do Jordão','SP');


-- EMPRESTANDO UM ALBUM --

set dateformat dmy
 
select * from Emprestimo


INSERT INTO Emprestimo (DataEmprestimo, DataDevolucao, Id_Pessoa, Id_Album) VALUES ('14-11-2012', NULL , 2, 1);

UPDATE Album SET Status = 'Emprestado' WHERE Id_Album = 1; 


-- DEVOLVENDO UM ALBUM --

UPDATE Emprestimo SET DataDevolucao = '22-11-2012' WHERE Id_Emprestimo = 1;

UPDATE Album SET Status = 'Disponível' WHERE Id_Album = 1; 
 

-- SELECT TELA INICIAL --

SELECT Id_Album, Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status FROM Album;


-- SELECT COUNT  TIPO DE MIDIAS, STATUS ALBUM, PESSOAS --

SELECT * FROM Pessoa;
SELECT COUNT(*) AS 'QTD' FROM Album;
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Digital';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'DVD';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'CD';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'K7';
SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Vinil';

SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Emprestado';

SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Disponível' AND TipoMidia!= 'Digital';


 
SELECT * FROM Album WHERE DataCompra >= '1990/12/13' AND DataCompra <= '2012/12/13'

SELECT Emprestimo.Id_Album, Pessoa.Nome,Album.Interprete, Album.Album, Emprestimo.DataEmprestimo, Emprestimo.DataDevolucao 
FROM Emprestimo INNER JOIN Pessoa ON
	Emprestimo.Id_Pessoa = Pessoa.Id_Pessoa
INNER JOIN Album ON
	Emprestimo.Id_Album = Album.Id_Album


SELECT *FROM Album;