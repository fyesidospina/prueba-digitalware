/****************************************************************************************
   $Archivo: Vista valaor total por producto vendido al año
   $Autor:   Freddy Ospina
   $Fecha Creación:        03/04/2022
   $Objetivo: Vista valaor total por producto vendido al año
*****************************************************************************************/
CREATE VIEW [vw_lista_total_venta_x_producto_x_ano] AS
select 
	cl.nombre_producto, 
	--inv.existencia,
	fac.cantidad 'Cant_Vendido', 
	inv.valor_und, 
	(fac.cantidad * inv.valor_und)'TOTAL_VENDIDO',
	fac.fecha_compra
	--YEAR(fac.fecha_compra) as ano
from 
	TL_Producto cl
inner join TL_Inventario inv on cl.id = inv.id_producto
inner join TL_Facturacion fac on inv.id = fac.id_inventario
where 
	YEAR(fac.fecha_compra) = YEAR('01/01/2000')