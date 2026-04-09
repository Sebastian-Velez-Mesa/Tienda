CREATE DATABASE tienda;
GO

USE tienda;
GO

CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100)
);

CREATE TABLE Producto (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);

CREATE TABLE Venta (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    FechaVenta DATETIME NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE DetalleVenta (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdVenta) REFERENCES Venta(IdVenta),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);
GO

-- Datos de prueba iniciales
INSERT INTO Producto (Nombre, Precio, Stock) VALUES ('Arroz 1kg', 2.50, 100);
INSERT INTO Producto (Nombre, Precio, Stock) VALUES ('Azucar 1kg', 1.80, 50);
INSERT INTO Producto (Nombre, Precio, Stock) VALUES ('Leche 1L', 1.20, 200);

INSERT INTO Cliente (Nombres, Apellidos, Telefono, Email) VALUES ('Juan', 'Perez', '0991234567', 'juan@email.com');
GO

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    Rol VARCHAR(20) NOT NULL
);
GO

-- Datos de prueba iniciales para Usuarios
INSERT INTO Usuario (Username, Password, Rol) VALUES ('admin', 'admin123', 'Admin');
INSERT INTO Usuario (Username, Password, Rol) VALUES ('cliente', 'cliente123', 'Cliente');
GO
