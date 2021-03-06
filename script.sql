USE [SuDB]
GO
/****** Object:  Table [dbo].[musteriler]    Script Date: 14.11.2019 20:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteriler](
	[musteriID] [int] IDENTITY(1,1) NOT NULL,
	[musteriAdi] [nvarchar](50) NOT NULL,
	[musteriSoyadi] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](50) NOT NULL,
	[Adres] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_musteriler] PRIMARY KEY CLUSTERED 
(
	[musteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[siparisler]    Script Date: 14.11.2019 20:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[siparisler](
	[siparisID] [int] IDENTITY(1,1) NOT NULL,
	[musAdi] [nvarchar](50) NOT NULL,
	[musSoyadi] [nvarchar](50) NOT NULL,
	[Durum] [nvarchar](50) NOT NULL,
	[musAdres] [nvarchar](50) NOT NULL,
	[Tutar] [int] NOT NULL,
 CONSTRAINT [PK_siparisler] PRIMARY KEY CLUSTERED 
(
	[siparisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[musteriler] ON 

INSERT [dbo].[musteriler] ([musteriID], [musteriAdi], [musteriSoyadi], [Telefon], [Adres]) VALUES (1, N'Ebru', N'Şahin', N'123456789', N'Erzincan')
INSERT [dbo].[musteriler] ([musteriID], [musteriAdi], [musteriSoyadi], [Telefon], [Adres]) VALUES (3, N'Neslihan', N'Yılmaz', N'544123456', N'Güngören')
INSERT [dbo].[musteriler] ([musteriID], [musteriAdi], [musteriSoyadi], [Telefon], [Adres]) VALUES (4, N'Nagihan', N'Ballıoğlu', N'543123456', N'Güneşli')
INSERT [dbo].[musteriler] ([musteriID], [musteriAdi], [musteriSoyadi], [Telefon], [Adres]) VALUES (5, N'Ayşenur', N'Sağırlı', N'05452078888', N'Erzincan')
SET IDENTITY_INSERT [dbo].[musteriler] OFF
SET IDENTITY_INSERT [dbo].[siparisler] ON 

INSERT [dbo].[siparisler] ([siparisID], [musAdi], [musSoyadi], [Durum], [musAdres], [Tutar]) VALUES (5, N'Ebru', N'Şahin', N'Hazırlanıyor', N'Erzincan', 10)
INSERT [dbo].[siparisler] ([siparisID], [musAdi], [musSoyadi], [Durum], [musAdres], [Tutar]) VALUES (6, N'Neslihan', N'Yılmaz', N'Yolda', N'İstanbul', 5)
INSERT [dbo].[siparisler] ([siparisID], [musAdi], [musSoyadi], [Durum], [musAdres], [Tutar]) VALUES (7, N'Nagihan', N'Ballıoğlu', N'Teslim', N'İstanbul', 15)
INSERT [dbo].[siparisler] ([siparisID], [musAdi], [musSoyadi], [Durum], [musAdres], [Tutar]) VALUES (8, N'Ebru', N'Şahin', N'Yolda', N'Erzincan', 5)
SET IDENTITY_INSERT [dbo].[siparisler] OFF
