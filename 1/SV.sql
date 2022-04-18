USE [master]
GO
/****** Object:  Database [SV]  ******/
CREATE DATABASE SV
GO

USE SV
GO
/****** Object:  Table [dbo].[SVINFO]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SVINFO](
	[Id] [varchar](10) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[ClassCode] [varchar](10) NOT NULL,
	[SubjectCode] [varchar](10) NOT NULL,
 CONSTRAINT [PK_SVINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SVINFO] ([Id], [FullName], [DateOfBirth], [ClassCode], [SubjectCode]) VALUES (N'Ma SV', N'Ho ten SV', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'Ma Lop', N'Ma Mon ')

GO
USE [master]
GO
ALTER DATABASE [SV] SET  READ_WRITE 
GO
