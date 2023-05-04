
--drop procedure SPS_GETPRODUCTOS

CREATE PROCEDURE SPS_GETPRODUCTOS(
@IdProducto int
)
as
begin
	if (@IdProducto <> 0)
	begin
		select * from catProducto where  IdProducto = @IdProducto
	end
	else
	begin
		select * from catProducto
	end
end
GO
------------------------------------------
CREATE PROCEDURE SPI_SAVEPRODUCTO(
@NombreProducto varchar(50),
@DescripcionProducto varchar(200),
@CantidadDisponible int,
@PrecioBase int,
@PrecioVenta int
)
as
begin
	insert into catProducto
	(NombreProducto, DescripcionProducto, CantidadDisponible, PrecioBase, PrecioVenta) 
	values 
	(@NombreProducto, @DescripcionProducto, @CantidadDisponible, @PrecioBase, @PrecioVenta)
end
-----------------------------
GO
CREATE PROCEDURE SPU_UPDATEPRODUCTO(
@IdProducto int,
@NombreProducto varchar(50),
@DescripcionProducto varchar(200),
@CantidadDisponible int,
@PrecioBase int,
@PrecioVenta int
)
as
begin
	update catProducto set 
	NombreProducto = @NombreProducto, DescripcionProducto = @DescripcionProducto , CantidadDisponible = @CantidadDisponible, PrecioBase = @PrecioBase, PrecioVenta = @PrecioVenta
	where IdProducto = @IdProducto
end
-------------------------------------
GO
CREATE PROCEDURE SPD_DELETEPRODUCTO(
@IdProducto int
)
as
begin
	delete from catProducto where IdProducto = @IdProducto
end
-------------------------------------
GO
CREATE PROCEDURE SPI_SAVEVENTA(
@IdProducto int,
@PrecioVenta int,
@GananciaVenta int
)
as
begin
	insert into Venta
	(IdProducto, PrecioVenta, GananciaVenta) 
	values 
	(@IdProducto, @PrecioVenta, @GananciaVenta)
end
---------------------------------------
GO
CREATE PROCEDURE SPS_GETGANANCIAS
as
begin
	select 
	IdVenta, pr.IdProducto, NombreProducto, PrecioBase, v.PrecioVenta, GananciaVenta
	from catProducto pr inner join Venta v on pr.IdProducto = v.IdProducto
end

exec SPS_GETGANANCIAS