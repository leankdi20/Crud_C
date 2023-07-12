USE [Ventas]
GO

INSERT INTO [dbo].[Clientes]
           ([Codigo]
           ,[Nombre]
           ,[Direccion]
           ,[Provincia]
           ,[Telefono]
           ,[CorreoElectronico])
     VALUES
           (<Codigo, int,>
           ,<Nombre, nvarchar(50),>
           ,<Direccion, nvarchar(50),>
           ,<Provincia, nchar(20),>
           ,<Telefono, int,>
           ,<CorreoElectronico, nvarchar(50),>)
GO


