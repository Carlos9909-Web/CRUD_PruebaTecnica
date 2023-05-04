CREATE TRIGGER TRU_UPDATEVENTA
   ON  Venta
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @insertIdProducto int
    SELECT @insertIdProducto = IdProducto FROM inserted
    UPDATE catProducto set CantidadDisponible = CantidadDisponible-1 
	WHERE IdProducto = @insertIdProducto
END
GO