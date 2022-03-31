/****************************************************************************************
   $Archivo: TL_Inventario
   $Autor:   Freddy Ospina
   $Fecha Creación:        28/03/2022
   $Objetivo:		almacena la informacion de los movimientos del producto
*****************************************************************************************/
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TL_Inventario]') 
     AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[TL_Inventario](
       [id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	   [id_producto] [bigint] NOT NULL,
       [cantidad] [bigint] NOT NULL,
	   [valor_und] [bigint] NOT NULL,
	   [existencia] [bigint] NOT NULL
	   
CONSTRAINT [PK_TL_Inventario] PRIMARY KEY CLUSTERED ( [id] ASC ),
CONSTRAINT FK_TL_Producto FOREIGN KEY (id_producto) REFERENCES TL_Producto(id));

END