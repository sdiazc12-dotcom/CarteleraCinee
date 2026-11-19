CREATE DATABASE CarteleraDB;
GO

USE CarteleraDB;
GO

CREATE TABLE Funciones (
    Id       INT IDENTITY(1,1) PRIMARY KEY,
    Pelicula NVARCHAR(100) NOT NULL,
    Sala     NVARCHAR(50)  NOT NULL,
    Precio   DECIMAL(10,2) NOT NULL
);
GO

INSERT INTO Funciones (Pelicula, Sala, Precio) VALUES ('Coco', 'Sala 1', 40.00);
INSERT INTO Funciones (Pelicula, Sala, Precio) VALUES ('Moana', 'Sala 2', 45.00);
GO