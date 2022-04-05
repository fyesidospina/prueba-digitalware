/****************************************************************************************
   $Archivo: Vista LISTA CLIENTE NO MAYORES 35
   $Autor:   Freddy Ospina
   $Fecha Creación:        03/04/2022
   $Objetivo: Vista LISTA CLIENTE NO MAYORES 35
*****************************************************************************************/
CREATE VIEW [vw_lista_cliente_no_mayor_35] AS
select 
	cl.nombres, cl.apellidos, cl.edad, fac.fecha_compra 
from 
	TL_Cliente cl
	inner join TL_Facturacion fac on cl.id = fac.id_cliente
where 
	cl.edad < 35 and 
	fac.fecha_compra between '2000/02/01' and '2000/05/25'