USE master;

CREATE DATABASE AcervoMusical;
GO

USE AcervoMusical;
GO

CREATE TABLE Compra (
Id_Compra INT PRIMARY KEY IDENTITY,
Data DATE,
Origem VARCHAR(30)
);

CREATE TABLE Tipo_Midia (
Id_Tipo_Midia INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(15)
);

CREATE TABLE Interprete (
Id_Interprete INT PRIMARY KEY IDENTITY,
Nome VARCHAR(60)
);

CREATE TABLE Autor (
Id_Autor INT PRIMARY KEY IDENTITY,
Nome VARCHAR(60)
);

CREATE TABLE Status (
Id_Status INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(15)
);


CREATE TABLE Album (
Id_Album INT PRIMARY KEY IDENTITY,
Nome VARCHAR(60),
Data DATE,
Nota VARCHAR(2),
Observacao VARCHAR(60),
Id_Compra INT,
Id_Tipo_Midia INT,
Id_Autor INT,
Id_Interprete INT,
Id_Status INT
FOREIGN KEY(Id_Compra) REFERENCES Compra (Id_Compra),
FOREIGN KEY(Id_Tipo_Midia) REFERENCES Tipo_Midia (Id_Tipo_Midia),
FOREIGN KEY(Id_Autor) REFERENCES Autor (Id_Autor),
FOREIGN KEY(Id_Interprete) REFERENCES Interprete (Id_Interprete),
FOREIGN KEY(Id_Status) REFERENCES Status (Id_Status)
);


CREATE TABLE Endereco (
Id_Endereco INT PRIMARY KEY IDENTITY,
Logradouro VARCHAR(60),
Bairro VARCHAR(60),
Cidade VARCHAR(60)
);

CREATE TABLE Pessoas (
Id_Pessoa INT PRIMARY KEY IDENTITY,
Nome VARCHAR(60),
Email VARCHAR(60),
Telefone VARCHAR(13),
Id_Endereco INT,
FOREIGN KEY(Id_Endereco) REFERENCES Endereco (Id_Endereco)
);


CREATE TABLE Emprestimo (
Id_Emprestimo INT PRIMARY KEY IDENTITY,
Data DATE,
Id_Pessoa INT,
Id_Album INT,
FOREIGN KEY(Id_Pessoa) REFERENCES Pessoas (Id_Pessoa),
FOREIGN KEY(Id_Album) REFERENCES Album (Id_Album)
);

-- Formata a data do Banco para Dia-Mês-Ano
SET DATEFORMAT dmy

-- INSERT --
INSERT INTO Compra (Data, Origem)VALUES ('04-11-2012', 'itunes');
INSERT INTO Compra (Data, Origem)VALUES ('10-06-2010', 'Submarino');

INSERT INTO Tipo_Midia VALUES ('Vinil');
INSERT INTO Tipo_Midia VALUES ('K7');
INSERT INTO Tipo_Midia VALUES ('CD');
INSERT INTO Tipo_Midia VALUES ('DVD');
INSERT INTO Tipo_Midia VALUES ('Digital');

INSERT INTO Autor VALUES ('Humberto G & Duca L');
INSERT INTO Autor VALUES ('James Blunt');

INSERT INTO Interprete VALUES ('Pouca Vogal');
INSERT INTO Interprete VALUES ('James Blunt');

INSERT INTO Status VALUES ('Disponível');
INSERT INTO Status VALUES ('Emprestado');

INSERT INTO Album (Nome, Data, Nota, Observacao, Id_Compra, Id_Tipo_Midia, Id_Autor, Id_Interprete, Id_Status)
VALUES ('Pouca Vogal - Ao Vivo em Porto Alegre', '25-05-2011', '8', 'Bem Legal', 1, 5, 1, 1, 1);

INSERT INTO Album (Nome, Data, Nota, Observacao, Id_Compra, Id_Tipo_Midia, Id_Autor, Id_Interprete, Id_Status)
VALUES ('Some Kind of Trouble', '25-05-2010', '7', '', 2, 3, 2, 2, 1);

INSERT INTO Endereco (Logradouro, Bairro, Cidade)
VALUES ('R: João Manuel de Siqueira', 'Jardim das Flores', 'Jumiranda');

INSERT INTO Endereco (Logradouro, Bairro, Cidade)
VALUES ('R: Jair Pereira S.', 'Vila Maria', 'Campos do Jordão');

INSERT INTO Pessoas (Nome, Email, Telefone, Id_Endereco)
VALUES ('Francisco da Silva', 'chico@email.com', '(12)3667-2244',1);

INSERT INTO Pessoas (Nome, Email, Telefone, Id_Endereco)
VALUES ('João Miguel dos Santos', 'Joao.ms@email.com', '(12)3662-7751',2);



 -- ADICIONA O FILME NA TABELA Emprestimo, E ALTERA O CAMPO STATUS NA TABELA ALBUM PARA Emprestado
INSERT INTO Emprestimo (Data, Id_Pessoa, Id_Album)
VALUES ('05-11-2012', 1, 2);

UPDATE Album SET Id_Status = 2 WHERE Album.Id_Album = 1;



-- SELECT --

SELECT * FROM Autor;
SELECT * FROM Interprete;

SELECT * FROM Tipo_Midia;

SELECT * FROM Compra;

SELECT * FROM Album;


 SELECT Interprete.Nome AS 'Interprete', Autor.Nome AS 'Autor', Album.Nome AS 'Album', Album.Data, Compra.Data AS 'Data Compra', 
Compra.Origem, Tipo_Midia.Descricao AS 'Midia' , Album.Nota, Album.Observacao, Album.Id_Status AS 'Status' FROM Album
INNER JOIN Compra ON
	Album.Id_Compra = Compra.Id_Compra
INNER JOIN Tipo_Midia ON
	Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia
INNER JOIN Autor ON
	Album.Id_Autor = Autor.Id_Autor
INNER JOIN Interprete ON
	Album.Id_Interprete = Interprete.Id_Interprete;