USE [PR]
GO
/****** Object:  Table [dbo].[Korzina]    Script Date: 18.12.2023 8:22:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korzina](
	[product] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 18.12.2023 8:22:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.12.2023 8:22:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Product] ([product]) VALUES (N'2Д706 АС9/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Д707 АС9/ЭП   ')
INSERT [dbo].[Product] ([product]) VALUES (N'2Д803 АС9/ЭП  ')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т3130 А9/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т3130 Е9/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т313 А-2/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т313 Б-2/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т326 А-2/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т326 Б-2/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т629 АМ-2/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т679 А-2/ЭП')
INSERT [dbo].[Product] ([product]) VALUES (N'2Т679 Б-2/ЭП')
GO
INSERT [dbo].[Users] ([email], [password]) VALUES (N'1', N'1')
INSERT [dbo].[Users] ([email], [password]) VALUES (N'2', N'2')
INSERT [dbo].[Users] ([email], [password]) VALUES (N'21', N'21')
GO
