USE [Kutuphane]
GO

/****** Object:  Table [dbo].[ODUNCALMA]    Script Date: 26.12.2021 16:07:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ODUNCALMA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kitap_id] [int] NOT NULL,
	[VerisTarihi] [date] NOT NULL,
	[Uye_id] [int] NOT NULL,
	[AlisTarihi] [date] NOT NULL,
 CONSTRAINT [PK_ODUNCALMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ODUNCALMA]  WITH CHECK ADD  CONSTRAINT [FK_ODUNCALMA_KITAPLAR] FOREIGN KEY([Kitap_id])
REFERENCES [dbo].[KITAPLAR] ([Id])
GO

ALTER TABLE [dbo].[ODUNCALMA] CHECK CONSTRAINT [FK_ODUNCALMA_KITAPLAR]
GO

ALTER TABLE [dbo].[ODUNCALMA]  WITH CHECK ADD  CONSTRAINT [FK_ODUNCALMA_UYELER] FOREIGN KEY([Uye_id])
REFERENCES [dbo].[UYELER] ([Id])
GO

ALTER TABLE [dbo].[ODUNCALMA] CHECK CONSTRAINT [FK_ODUNCALMA_UYELER]
GO


