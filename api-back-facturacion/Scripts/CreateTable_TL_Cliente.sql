/****************************************************************************************
   $Archivo: TL_Cliente
   $Autor:   Freddy Ospina
   $Fecha Creación:        28/03/2022
   $Objetivo:		almacena la informacion de los clientes
*****************************************************************************************/
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TL_Cliente]') 
     AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[TL_Cliente](
       [id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
       [nombres] [varchar](10) NOT NULL,
	   [apellidos] [varchar](10) NULL,
       [edad] [bigint] NOT NULL    
CONSTRAINT [PK_TL_Cliente] PRIMARY KEY CLUSTERED 
(
      [id] ASC
)) ON [PRIMARY]

END