USE [Kutuphane]
GO

/****** Object:  Table [dbo].[ADRESLER]    Script Date: 26.12.2021 16:09:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ADRESLER](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[No] [int] NOT NULL,
	[Cadde] [nvarchar](50) NOT NULL,
	[Postakodu] [int] NOT NULL,
	[Il] [nchar](20) NOT NULL,
	[Mahalle] [nvarchar](50) NOT NULL,
	[Daire] [int] NOT NULL,
	[Kat] [int] NOT NULL,
	[Sokak] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ADRESLER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


