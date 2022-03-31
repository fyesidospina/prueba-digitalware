/****************************************************************************************
   $Archivo: Vista Lista productos precios
   $Autor:   Freddy Ospina
   $Fecha Creación:        28/03/2022
   $Objetivo: Vista Lista productos precios
*****************************************************************************************/
CREATE VIEW [vw_lista_precios_productos] AS
select pr.id, pr.nombre_producto, inv.valor_und from TL_Inventario inv
inner join TL_Producto pr on inv.id_producto = pr.id;