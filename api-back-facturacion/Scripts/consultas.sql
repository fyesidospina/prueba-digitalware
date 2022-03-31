select * from TL_Cliente
select * from TL_Producto
select * from TL_Inventario
select * from TL_Facturacion

-- delete from TL_Facturacion
--DBCC CHECKIDENT ('TL_Facturacion', RESEED, 0);

-- LISTA PRECIOS TODOS LOS PRODUCTOS
select pr.nombre_producto, inv.valor_und from TL_Inventario inv
inner join TL_Producto pr on inv.id_producto = pr.id

-- LISTA PRODUCTOS EXISTENCIA MINIMO PERMITIDO 5
select 
	pr.nombre_producto, 
	inv.existencia 
from 
	TL_Inventario inv
	inner join TL_Producto pr on inv.id_producto = pr.id
where 
	inv.existencia <= 5

-- LISTA CLIENTE NO MAYORES 35
select 
	cl.nombres + ' ' +cl.apellidos,  
	cl.edad, fac.fecha_compra 
from 
	TL_Cliente cl
	inner join TL_Facturacion fac on cl.id = fac.id_cliente
where 
	cl.edad < 35 and 
	fac.fecha_compra between '2000/02/01' and '2000/05/25'

-- OBTENER VALOR TOTAL VENDIDO POR CADA PRODUCTO AL AÑO 2000
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

-- OBTENER ULTIMA FECHA POSIBLE COMPRA

select 
	DATEDIFF(day, MIN (fac.fecha_compra), MAX (fac.fecha_compra)) 'DIF'
from 
	TL_Facturacion fac
	inner join TL_Cliente cl on fac.id_cliente = cl.id
where
	cl.id = 10

select 
	SUM(fac.cantidad) AS TOTAL_CANT
from 
	TL_Facturacion fac
	inner join TL_Cliente cl on fac.id_cliente = cl.id
where
	cl.id = 10

select 
	fac.id_cliente,
	cl.nombres,
	((DATEDIFF(day, MIN (fac.fecha_compra), MAX (fac.fecha_compra))) / (SUM(fac.cantidad))) 'MEDIA DIAS',
	DATEADD(DAY, ((DATEDIFF(day, MIN (fac.fecha_compra), MAX (fac.fecha_compra))) / (SUM(fac.cantidad))), GETDATE()) 'PROXIMA COMPRA'
from 
	TL_Facturacion fac
	inner join TL_Cliente cl on fac.id_cliente = cl.id
where
	cl.id = 10
	group by fac.id_cliente, cl.nombres



select 
	--cl.nombres + ' ' +cl.apellidos, 
	fac.fecha_compra
	--fac.cantidad,
	--SUM(fac.cantidad) AS TOTAL_CANT
	--MAX (fac.fecha_compra) 'MAXDATE', 
	--MIN (fac.fecha_compra) 'MINDATE',
	--DATEDIFF(day, MIN (fac.fecha_compra), MAX (fac.fecha_compra)) 'DIF'
	
from 
	TL_Facturacion fac
	inner join TL_Cliente cl on fac.id_cliente = cl.id
where
	cl.id = 10
	--GROUP BY cl.nombres, cl.apellidos, fac.fecha_compra, fac.cantidad
	

------------------------------
select * from vw_lista_precios_productos
select * from vw_lista_producto_existencia_min