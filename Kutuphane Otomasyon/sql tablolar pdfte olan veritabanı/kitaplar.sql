USE [Kutuphane]
GO

/****** Object:  Table [dbo].[KITAPLAR]    Script Date: 26.12.2021 16:07:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KITAPLAR](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kategori_id] [int] NOT NULL,
	[RafNo] [int] NOT NULL,
	[Yayimyili] [date] NOT NULL,
	[Basim] [nvarchar](50) NOT NULL,
	[Stok] [nchar](10) NOT NULL,
	[SayfaSayisi] [int] NOT NULL,
	[Tur] [nvarchar](50) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KITAPLAR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[KITAPLAR]  WITH CHECK ADD  CONSTRAINT [FK_KITAPLAR_KATEGORILER] FOREIGN KEY([Kategori_id])
REFERENCES [dbo].[KATEGORILER] ([Id])
GO

ALTER TABLE [dbo].[KITAPLAR] CHECK CONSTRAINT [FK_KITAPLAR_KATEGORILER]
GO


