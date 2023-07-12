/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Codigo]
      ,[Nombre]
      ,[Direccion]
      ,[Provincia]
      ,[Telefono]
      ,[CorreoElectronico]
  FROM [Ventas].[dbo].[Clientes]

 

