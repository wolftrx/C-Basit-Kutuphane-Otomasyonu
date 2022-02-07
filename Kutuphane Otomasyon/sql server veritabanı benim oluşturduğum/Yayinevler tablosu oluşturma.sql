USE [Kutuphane]
GO

/****** Object:  Table [dbo].[YAYINEVLER]    Script Date: 7.02.2022 23:23:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[YAYINEVLER](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Adres_id] [int] NOT NULL,
	[Kitap_id] [int] NOT NULL,
 CONSTRAINT [PK_YAYINEVLER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[YAYINEVLER]  WITH CHECK ADD  CONSTRAINT [FK_YAYINEVLER_ADRESLER] FOREIGN KEY([Adres_id])
REFERENCES [dbo].[ADRESLER] ([Id])
GO

ALTER TABLE [dbo].[YAYINEVLER] CHECK CONSTRAINT [FK_YAYINEVLER_ADRESLER]
GO

ALTER TABLE [dbo].[YAYINEVLER]  WITH CHECK ADD  CONSTRAINT [FK_YAYINEVLER_KITAPLAR] FOREIGN KEY([Kitap_id])
REFERENCES [dbo].[KITAPLAR] ([Id])
GO

ALTER TABLE [dbo].[YAYINEVLER] CHECK CONSTRAINT [FK_YAYINEVLER_KITAPLAR]
GO


