```
USE [abexauser]
GO
/****** Object:  Table [dbo].[UserItems]    Script Date: 8/10/2021 16:44:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsu] [nvarchar](max) NULL,
	[CorreoUsu] [nvarchar](max) NULL,
	[PerfilUsu] [int] NOT NULL,
	[EmpresaUsu] [int] NOT NULL,
	[EstadoUsu] [int] NOT NULL,
 CONSTRAINT [PK_UserItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


INSERT INTO UserItems (NombreUsu, CorreoUsu, PerfilUsu, EmpresaUsu, EstadoUsu)
VALUES ('Christian', 'gmail',1,2,1)
INSERT INTO UserItems (NombreUsu, CorreoUsu, PerfilUsu, EmpresaUsu, EstadoUsu)
VALUES ('santiago', 'santiago@gmail',2,3,0)
INSERT INTO UserItems (NombreUsu, CorreoUsu, PerfilUsu, EmpresaUsu, EstadoUsu)
VALUES ('Laura', 'laura@gmail',3,1,1)
INSERT INTO UserItems (NombreUsu, CorreoUsu, PerfilUsu, EmpresaUsu, EstadoUsu)
VALUES ('bryan', 'bryan@gmail',4,2,0)
INSERT INTO UserItems (NombreUsu, CorreoUsu, PerfilUsu, EmpresaUsu, EstadoUsu)
VALUES ('gerson', 'gerson@gmail',5,3,1)
```