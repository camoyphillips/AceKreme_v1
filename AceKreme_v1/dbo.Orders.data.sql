SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([OrderId], [OrderDate], [TotalAmount], [Status]) VALUES (1, N'2025-10-15 00:00:00', CAST(300.00 AS Decimal(18, 2)), N'In Progress')
INSERT INTO [dbo].[Orders] ([OrderId], [OrderDate], [TotalAmount], [Status]) VALUES (2, N'2025-10-14 00:00:00', CAST(900.00 AS Decimal(18, 2)), N'Delivered')
SET IDENTITY_INSERT [dbo].[Orders] OFF
