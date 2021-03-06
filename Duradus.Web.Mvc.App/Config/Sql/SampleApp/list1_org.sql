
/****** Object:  Table [dbo].[ListThis_Is_List_Field]    Script Date: 04/02/2013 20:41:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListThis_Is_List_Field](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Ordinal] [int] NULL,
 CONSTRAINT [PK_ListThis_Is_List_Field] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ListThis_Is_List_Field] ON
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (1, N'Option 1', 10)
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (2, N'Option 2', 20)
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (3, N'Option 3', 30)
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (4, N'Option 4', 40)
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (5, N'Option 5', 50)
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (6, N'Option 6', 60)
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (7, N'Option 7', 70)
INSERT [dbo].[ListThis_Is_List_Field] ([Id], [Name], [Ordinal]) VALUES (8, N'Option 8', 80)
SET IDENTITY_INSERT [dbo].[ListThis_Is_List_Field] OFF
/****** Object:  Table [dbo].[List]    Script Date: 04/02/2013 20:41:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[This_is_Picture_Field] [nvarchar](250) NULL,
	[This_Is_Text_Field] [nvarchar](250) NULL,
	[This_Is_Number_Field] [float] NULL,
	[This_Is_Yes_No_Field] [bit] NULL,
	[This_Is_Date_Field] [datetime] NULL,
	[This_Is_List_FieldId] [int] NULL,
 CONSTRAINT [PK_List] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[List] ON
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (1, N'image1.jpg', N'This is a text example I', 1000, 1, CAST(0x0000A17400000000 AS DateTime), 1)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (2, N'image2.png', N'This is a text example 2', 2000, 0, CAST(0x0000A15900000000 AS DateTime), 2)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (3, N'image3.jpg', N'This is a text example 3', 3000, 0, CAST(0x0000A1B100000000 AS DateTime), 3)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (4, N'image3.jpg', N'This is a text example 4', 4000, 1, CAST(0x0000A1B100000000 AS DateTime), 4)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (5, N'image3.jpg', N'This is a text example 5', 5000, 1, CAST(0x0000A1B100000000 AS DateTime), 5)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (6, N'image3.jpg', N'This is a text example 6', 6000, 1, CAST(0x0000A1D000000000 AS DateTime), 6)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (7, N'image3.jpg', N'This is a text example 7', 7000, 1, CAST(0x0000A1EE00000000 AS DateTime), 7)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (8, N'image3.jpg', N'This is a text example 8', 8000, 1, CAST(0x0000A20D00000000 AS DateTime), 8)
INSERT [dbo].[List] ([Id], [This_is_Picture_Field], [This_Is_Text_Field], [This_Is_Number_Field], [This_Is_Yes_No_Field], [This_Is_Date_Field], [This_Is_List_FieldId]) VALUES (9, NULL, NULL, NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[List] OFF
/****** Object:  ForeignKey [FK_List_ListThis_Is_List_Field_This_Is_List_FieldId]    Script Date: 04/02/2013 20:41:52 ******/
ALTER TABLE [dbo].[List]  WITH CHECK ADD  CONSTRAINT [FK_List_ListThis_Is_List_Field_This_Is_List_FieldId] FOREIGN KEY([This_Is_List_FieldId])
REFERENCES [dbo].[ListThis_Is_List_Field] ([Id])
GO
ALTER TABLE [dbo].[List] CHECK CONSTRAINT [FK_List_ListThis_Is_List_Field_This_Is_List_FieldId]
GO
