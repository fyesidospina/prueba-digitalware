/****************************************************************************************
   $Archivo: TL_Facturacion
   $Autor:   Freddy Ospina
   $Fecha Creación:        28/03/2022
   $Objetivo:		almacena la informacion de los productos vendidos
*****************************************************************************************/
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TL_Facturacion]') 
     AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[TL_Facturacion](
       [id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	   [fecha_compra] [date] NOT NULL,
	   [id_inventario] [bigint] NOT NULL,
	   [id_cliente] [bigint] NOT NULL,
       [cantidad] [bigint] NOT NULL,
	   [descripcion] [varchar](100) NULL
	   
CONSTRAINT [PK_TL_Facturacion] PRIMARY KEY CLUSTERED ( [id] ASC ),
CONSTRAINT FK_TL_Inventario FOREIGN KEY (id_inventario) REFERENCES TL_Inventario(id),
CONSTRAINT FK_TL_Cliente FOREIGN KEY (id_cliente) REFERENCES TL_Cliente(id));

END