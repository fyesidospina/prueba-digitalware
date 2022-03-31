/****************************************************************************************
   $Archivo: LISTA PRODUCTOS EXISTENCIA MINIMO PERMITIDO 5
   $Autor:   Freddy Ospina
   $Fecha Creación:        28/03/2022
   $Objetivo: LISTA PRODUCTOS EXISTENCIA MINIMO PERMITIDO 5
*****************************************************************************************/
CREATE VIEW [vw_lista_producto_existencia_min] AS
select 
	pr.nombre_producto, 
	inv.existencia 
from 
	TL_Inventario inv
	inner join TL_Producto pr on inv.id_producto = pr.id
where 
	inv.existencia <= 5