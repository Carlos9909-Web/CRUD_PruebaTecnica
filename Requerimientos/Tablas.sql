


create database DBVenta
USE DBVenta


CREATE TABLE catProducto(
IdProducto int identity primary key,
NombreProducto varchar(50),
DescripcionProducto varchar(200),
CantidadDisponible int,
PrecioBase int,
PrecioVenta int
)

CREATE TABLE Venta(
IdVenta int identity primary key,
IdProducto int,
PrecioVenta int,
GananciaVenta int
)
