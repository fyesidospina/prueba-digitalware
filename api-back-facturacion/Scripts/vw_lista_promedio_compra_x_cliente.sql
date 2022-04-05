/****************************************************************************************
   $Archivo: promedio_compra_cliente
   $Autor:   Freddy Ospina
   $Fecha Creación:        03/04/2022
   $Objetivo: Estimacion de posible fecha de proxima compra de un cliente
*****************************************************************************************/
CREATE VIEW [vw_lista_promedio_compra_x_cliente] AS
select 
	fac.id_cliente,
	cl.nombres, cl.apellidos,
	((DATEDIFF(day, MIN (fac.fecha_compra), MAX (fac.fecha_compra))) / (SUM(fac.cantidad))) 'MEDIA DIAS',
	DATEADD(DAY, ((DATEDIFF(day, MIN (fac.fecha_compra), MAX (fac.fecha_compra))) / (SUM(fac.cantidad))), GETDATE()) 'PROXIMA COMPRA'
from 
	TL_Facturacion fac
	inner join TL_Cliente cl on fac.id_cliente = cl.id
where
	cl.id = 10
	group by fac.id_cliente, cl.nombres, cl.apellidos