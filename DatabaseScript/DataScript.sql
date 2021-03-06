USE [BildExam9.db]
GO
SET IDENTITY_INSERT [dbo].[DeviceTypes] ON 

INSERT [dbo].[DeviceTypes] ([Id], [Name], [ParentTypeId]) VALUES (1, N'Kompjuter', NULL)
INSERT [dbo].[DeviceTypes] ([Id], [Name], [ParentTypeId]) VALUES (2, N'Laptop', 1)
INSERT [dbo].[DeviceTypes] ([Id], [Name], [ParentTypeId]) VALUES (3, N'Tablet', 2)
SET IDENTITY_INSERT [dbo].[DeviceTypes] OFF
SET IDENTITY_INSERT [dbo].[Devices] ON 

INSERT [dbo].[Devices] ([Id], [Name], [CreatedDate], [DeviceTypeId], [Price]) VALUES (3, N'Dell', CAST(N'2019-02-13T00:00:00.0000000' AS DateTime2), 2, CAST(400.00 AS Decimal(18, 2)))
INSERT [dbo].[Devices] ([Id], [Name], [CreatedDate], [DeviceTypeId], [Price]) VALUES (4, N'Intel', CAST(N'2019-02-12T00:00:00.0000000' AS DateTime2), 3, CAST(300.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Devices] OFF
SET IDENTITY_INSERT [dbo].[DeviceTypesProperties] ON 

INSERT [dbo].[DeviceTypesProperties] ([Id], [Name], [DeviceTypeId]) VALUES (1, N'RAM', 1)
INSERT [dbo].[DeviceTypesProperties] ([Id], [Name], [DeviceTypeId]) VALUES (2, N'Procesor', 1)
INSERT [dbo].[DeviceTypesProperties] ([Id], [Name], [DeviceTypeId]) VALUES (3, N'OPerativni sistem', 1)
INSERT [dbo].[DeviceTypesProperties] ([Id], [Name], [DeviceTypeId]) VALUES (4, N'Dijagonala ekrana', 2)
INSERT [dbo].[DeviceTypesProperties] ([Id], [Name], [DeviceTypeId]) VALUES (5, N'Futrola', 3)
SET IDENTITY_INSERT [dbo].[DeviceTypesProperties] OFF
SET IDENTITY_INSERT [dbo].[DevicePropertyValues] ON 

INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (7, 3, 1, N'16gb')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (8, 3, 2, N'i7')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (9, 3, 3, N'windows')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (10, 3, 4, N'17inch')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (11, 4, 1, N'8gb')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (12, 4, 2, N'i5')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (13, 4, 3, N'mac')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (14, 4, 4, N'10inch')
INSERT [dbo].[DevicePropertyValues] ([Id], [DeviceId], [DeviceTypePropertyId], [Value]) VALUES (15, 4, 5, N'nema')
SET IDENTITY_INSERT [dbo].[DevicePropertyValues] OFF
