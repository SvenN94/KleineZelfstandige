USE [KleineZelfstandige]
GO

ALTER TABLE [dbo].[Activiteiten] DROP CONSTRAINT [FK_Activiteiten_Klanten]
GO

/****** Object:  Table [dbo].[Activiteiten]    Script Date: 3/01/2023 17:00:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Activiteiten]') AND type in (N'U'))
DROP TABLE [dbo].[Activiteiten]
GO

/****** Object:  Table [dbo].[Activiteiten]    Script Date: 3/01/2023 17:00:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activiteiten](
	[ActiviteitId] [int] IDENTITY(1,1) NOT NULL,
	[KlantId] [int] NOT NULL,
	[GeplandeDatum] [smalldatetime] NULL,
	[GewerkteUren] [numeric](5, 2) NULL,
	[SoortWerk] [nvarchar](50) NULL,
	[Materialen] [nvarchar](max) NULL,
	[Locatie] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Activiteiten] PRIMARY KEY CLUSTERED 
(
	[ActiviteitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Activiteiten]  WITH CHECK ADD  CONSTRAINT [FK_Activiteiten_Klanten] FOREIGN KEY([KlantId])
REFERENCES [dbo].[Klanten] ([KlantId])
GO

ALTER TABLE [dbo].[Activiteiten] CHECK CONSTRAINT [FK_Activiteiten_Klanten]
GO

