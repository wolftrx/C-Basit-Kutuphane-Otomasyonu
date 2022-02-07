USE [Kutuphane]
GO

/****** Object:  Table [dbo].[YONETICI]    Script Date: 26.12.2021 16:08:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[YONETICI](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[Ad] [nvarchar](50) NULL
) ON [PRIMARY]

GO


