/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  [Nombre]
      ,[Rol]
      ,[Email]
      ,[Contacto]
      ,[Cedula]
  FROM [Prueba].[dbo].[Usuario2]

--truncate table  Usuario2

 -- delete FROM [Prueba].[dbo].[Usuario2] where [Cedula] = '1092'