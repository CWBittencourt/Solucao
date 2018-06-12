USE [GimbaDB]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](150) NOT NULL,
	[CNPJ] [char](18) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteSocio]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteSocio](
	[IdClienteSocio] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdSocio] [bigint] NOT NULL,
 CONSTRAINT [PK_ClienteSocio] PRIMARY KEY CLUSTERED 
(
	[IdClienteSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[IdEmail] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[IdEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[IdCliente] [bigint] NOT NULL,
	[UF] [char](2) NOT NULL,
	[Cidade] [nvarchar](100) NOT NULL,
	[Bairro] [nvarchar](100) NOT NULL,
	[TipoLogradouro] [nvarchar](30) NOT NULL,
	[Logradouro] [nvarchar](100) NOT NULL,
	[Numero] [char](10) NOT NULL,
	[Complemento] [nvarchar](30) NULL,
	[CEP] [nchar](8) NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socio]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socio](
	[IdSocio] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[CPF] [char](14) NOT NULL,
 CONSTRAINT [PK_Socio] PRIMARY KEY CLUSTERED 
(
	[IdSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefone]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefone](
	[IdTelefone] [bigint] IDENTITY(1,1) NOT NULL,
	[IdTipoTelefone] [bigint] NOT NULL,
	[DDD] [char](2) NOT NULL,
	[Numero] [nchar](10) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
 CONSTRAINT [PK_Telefone] PRIMARY KEY CLUSTERED 
(
	[IdTelefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTelefone]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTelefone](
	[IdTipoTelefone] [bigint] NOT NULL,
	[Descricao] [nchar](11) NOT NULL,
 CONSTRAINT [PK_TipoTelefone] PRIMARY KEY CLUSTERED 
(
	[IdTipoTelefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TipoTelefone] ([IdTipoTelefone], [Descricao]) VALUES (1, N'FIXO       ')
INSERT [dbo].[TipoTelefone] ([IdTipoTelefone], [Descricao]) VALUES (2, N'RESIDENCIAL')
INSERT [dbo].[TipoTelefone] ([IdTipoTelefone], [Descricao]) VALUES (3, N'CELULAR    ')
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cliente__AA57D6B4AB4419D6]    Script Date: 12/06/2018 05:05:24 ******/
ALTER TABLE [dbo].[Cliente] ADD UNIQUE NONCLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClienteSocio]  WITH CHECK ADD  CONSTRAINT [FK_ClienteSocio_Cliente1] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[ClienteSocio] CHECK CONSTRAINT [FK_ClienteSocio_Cliente1]
GO
ALTER TABLE [dbo].[ClienteSocio]  WITH CHECK ADD  CONSTRAINT [FK_ClienteSocio_Socio1] FOREIGN KEY([IdSocio])
REFERENCES [dbo].[Socio] ([IdSocio])
GO
ALTER TABLE [dbo].[ClienteSocio] CHECK CONSTRAINT [FK_ClienteSocio_Socio1]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Cliente1] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Cliente1]
GO
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Cliente]
GO
ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD  CONSTRAINT [FK_Telefone_Cliente1] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Telefone] CHECK CONSTRAINT [FK_Telefone_Cliente1]
GO
ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD  CONSTRAINT [FK_Telefone_TipoTelefone1] FOREIGN KEY([IdTipoTelefone])
REFERENCES [dbo].[TipoTelefone] ([IdTipoTelefone])
GO
ALTER TABLE [dbo].[Telefone] CHECK CONSTRAINT [FK_Telefone_TipoTelefone1]
GO
/****** Object:  StoredProcedure [dbo].[sp_ClienteAlterar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ClienteAlterar]
@IdCliente bigint,
@Nome nvarchar(150),
@CNPJ char(18),
@Ativo bit

as

UPDATE [dbo].[Cliente]
   SET [Nome] = @Nome
      ,[CNPJ] = @CNPJ
      ,[Ativo] = @Ativo
 WHERE IdCliente = @IdCliente


GO
/****** Object:  StoredProcedure [dbo].[sp_ClienteCriar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ClienteCriar]
@Nome nvarchar(150),
@CNPJ char(18),
@Ativo bit

as
BEGIN
INSERT INTO [dbo].[Cliente]
           ([Nome]
           ,[CNPJ]
           ,[Ativo])
     VALUES
           (@Nome
           ,@CNPJ
           ,@Ativo)


SELECT * FROM Cliente WHERE IdCliente = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ClienteExcluir]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ClienteExcluir]
@IdCliente bigint
as

UPDATE [dbo].[Cliente]
   SET [Ativo] = 0
 WHERE IdCliente = @IdCliente
GO
/****** Object:  StoredProcedure [dbo].[sp_ClienteGetPorNOmeCNPJ]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ClienteGetPorNOmeCNPJ]

@Nome nvarchar(150),
@CNPJ char(18)
as
select IdCliente from cliente where Nome = @Nome and CNPJ = @CNPJ
GO
/****** Object:  StoredProcedure [dbo].[sp_ClienteIncluir]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_ClienteIncluir]
@IdCliente bigint
as

UPDATE [dbo].[Cliente]
   SET [Ativo] = 1
 WHERE IdCliente = @IdCliente
GO
/****** Object:  StoredProcedure [dbo].[sp_ClienteLerPorId]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ClienteLerPorId]
@IdCliente bigint
as
SELECT IdCliente, Nome, CNPJ, Ativo FROM Cliente
where IdCliente = @IdCliente
GO
/****** Object:  StoredProcedure [dbo].[sp_ClienteLerTodos]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ClienteLerTodos]
as
SELECT IdCliente, Nome, CNPJ, Ativo FROM Cliente
GO
/****** Object:  StoredProcedure [dbo].[sp_clienteSocioCriar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_clienteSocioCriar]
@IdCliente bigint,
@IdSocio bigint

AS
INSERT INTO [dbo].[ClienteSocio]
           ([IdCliente]
           ,[IdSocio])
     VALUES
           (@IdCliente
           ,@IdSocio)

GO
/****** Object:  StoredProcedure [dbo].[sp_EmailAlterar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EmailAlterar]
@IdEmail bigint,
@IdCliente bigint,
@Email nvarchar(50)
as

UPDATE [dbo].[Email]
   SET [email] = @Email
 WHERE IdEmail = @IdEmail





GO
/****** Object:  StoredProcedure [dbo].[sp_EmailCriar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EmailCriar]
@IdCliente bigint,
@Email nvarchar(50)
as

INSERT INTO [dbo].[Email]
           ([IdCliente]
           ,[email])
     VALUES
           (@IdCliente
           ,@Email)


GO
/****** Object:  StoredProcedure [dbo].[sp_EmailLerPorId]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EmailLerPorId]
@IdCliente bigint

as

SELECT IdEmail, IdCliente, email FROM dbo.EMAIL WHERE IdCliente = @IdCliente
GO
/****** Object:  StoredProcedure [dbo].[sp_EnderecoAlterar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EnderecoAlterar]
@IdCliente bigint,
@UF char(2),
@Cidade nvarchar(100),
@Bairro nvarchar(100),
@TipoLogradouro nvarchar(30),
@Logradouro nvarchar(100),
@Numero char(10),
@Complemento nvarchar(30)
as

UPDATE [dbo].[Endereco]
   SET [UF] = @UF
      ,[Cidade] = @Cidade
      ,[Bairro] = @Bairro
      ,[TipoLogradouro] = @TipoLogradouro
      ,[Logradouro] = @Logradouro
      ,[Numero] = @Numero
      ,[Complemento] = @Complemento
 WHERE IdCliente = @IdCliente


GO
/****** Object:  StoredProcedure [dbo].[sp_EnderecoCriar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EnderecoCriar]
@IdCliente bigint,
@UF char(2),
@Cidade nvarchar(100),
@Bairro nvarchar(100),
@TipoLogradouro nvarchar(30),
@Logradouro nvarchar(100),
@Numero char(10),
@Complemento nvarchar(30) = '',
@CEP nchar(8)
as
INSERT INTO [dbo].[Endereco]
           ([IdCliente]
           ,[UF]
           ,[Cidade]
           ,[Bairro]
           ,[TipoLogradouro]
           ,[Logradouro]
           ,[Numero]
           ,[Complemento]
		   ,[CEP])
     VALUES
           (@IdCliente
           ,@UF
           ,@Cidade
           ,@Bairro
           ,@TipoLogradouro
           ,@Logradouro
           ,@Numero
           ,@Complemento
		   ,@CEP)


GO
/****** Object:  StoredProcedure [dbo].[sp_EnderecoLerPorId]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EnderecoLerPorId]
@IdCliente bigint
as

SELECT IdCliente, UF, Cidade, Bairro, TipoLogradouro, Logradouro, Numero, Complemento FROM Endereco
WHERE IdCliente = @IdCliente
GO
/****** Object:  StoredProcedure [dbo].[sp_SocioAlterar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SocioAlterar]
@IdSocio bigint,
@Nome nvarchar(50),
@CPF char(14)
as

UPDATE [dbo].[Socio]
   SET [Nome] = @Nome,
       [CPF] = @CPF
 WHERE IdSocio = @IdSocio


GO
/****** Object:  StoredProcedure [dbo].[sp_SocioCriar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SocioCriar]
@Nome nvarchar(50),
@CPF char(14)
as

INSERT INTO [dbo].[Socio]
           ([Nome]
           ,[CPF])
     VALUES
           (@Nome
           ,@CPF)

SELECT IdSocio FROM Socio WHERE IdSocio = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_SocioLerPorId]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_SocioLerPorId]
@IdSocio bigint
as

SELECT [IdSocio]
      ,[Nome]
      ,[CPF]
  FROM [dbo].[Socio]
WHERE IdSocio = @IdSocio

GO
/****** Object:  StoredProcedure [dbo].[sp_TelefoneAlterar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_TelefoneAlterar]
@IdTelefone bigint,
@IdTipoTelefone bigint,
@DDD char(2),
@Numero nchar(10)
as

UPDATE [dbo].[Telefone]
   SET [IdTipoTelefone] = @IdTipoTelefone
      ,[DDD] = @DDD
      ,[Numero] = @Numero
 WHERE IdTelefone = @IdTelefone


GO
/****** Object:  StoredProcedure [dbo].[sp_TelefoneCriar]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_TelefoneCriar]
@IdTipoTelefone bigint,
@DDD char(2),
@Numero nchar(10),
@IdCliente bigint
AS

INSERT INTO [dbo].[Telefone]
           ([IdTipoTelefone]
           ,[DDD]
           ,[Numero]
           ,[IdCliente])
     VALUES
           (@IdTipoTelefone
           ,@DDD
           ,@Numero
           ,@IdCliente)


GO
/****** Object:  StoredProcedure [dbo].[sp_TelefoneLerPorId]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_TelefoneLerPorId]
@IdCliente bigint

as

SELECT IdTelefone, IdCliente, IdTipoTelefone, DDD, Numero FROM Telefone WHERE IdCliente = @IdCliente
GO
/****** Object:  StoredProcedure [dbo].[sp_TipoTelefoneLerTodos]    Script Date: 12/06/2018 05:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_TipoTelefoneLerTodos]
AS
SELECT IdTipoTelefone, Descricao FROM TipoTelefone
GO
