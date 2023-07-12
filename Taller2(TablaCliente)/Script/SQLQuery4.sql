USE [Ventas]
GO

UPDATE [dbo].[Clientes]
   SET [Codigo] = <Codigo, int,>
      ,[Nombre] = <Nombre, nvarchar(50),>
      ,[Direccion] = <Direccion, nvarchar(50),>
      ,[Provincia] = <Provincia, nchar(20),>
      ,[Telefono] = <Telefono, int,>
      ,[CorreoElectronico] = <CorreoElectronico, nvarchar(50),>
 WHERE <Search Conditions,,>
GO


