INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'48625d54-b98f-4613-8c23-a004f3236d9a', N'publisher', N'publisher', N'486a64cb-af26-4a50-be85-63d07d2aecc6')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'80def832-b8b0-4d95-ad89-edfd5e6deaa0', N'repo_admin', N'repo_admin', N'dee344a9-708a-4067-9995-ca8149865b26')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'91a47699-e88a-40ec-b04c-279a3c7e6fa7', N'sam@repo.com', N'SAM@REPO.COM', N'sam@repo.com', N'SAM@REPO.COM', 1, N'AQAAAAEAACcQAAAAEM+dsZjdVDJsgtpm+wnlQsiszqunS5GXiwaoh8vL5qs1OqdCLosU6naH2biCjbWh8w==', N'EGKFHHM32HSXUUDS5BDDQ4V342VL55OA', N'54364181-ce62-456e-a78b-94591a85c226', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a4354343-5902-472b-810c-bd74a7511506', N'admin@repo.com', N'ADMIN@REPO.COM', N'admin@repo.com', N'ADMIN@REPO.COM', 1, N'AQAAAAEAACcQAAAAED+TeGNaLivwBERIxX0Ai1n+PCTybt/2Ip2X6Ewv9WCxTSozUQkFPrDf5unkhHwYYg==', N'ELQ6P6P6V375Q4LLJECHPD45BH56BIKF', N'29543055-e50a-4ebb-981e-e3259df5bb32', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'aa0d347f-f6bd-41e6-a1e9-f1e8aab0546f', N'dan@repo.com', N'DAN@REPO.COM', N'dan@repo.com', N'DAN@REPO.COM', 1, N'AQAAAAEAACcQAAAAEEDq5rcbnnRnCGZRzgp9J7xwaz/mo9EkmPGtA93hfV52fMMCPmIk4V66Q6Wse4qITQ==', N'BYZJJ3YXX7ZARRZYHYK5EY56YSTSNDWE', N'6f1ac919-a188-4986-a8b4-b08fb02d3086', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'91a47699-e88a-40ec-b04c-279a3c7e6fa7', N'48625d54-b98f-4613-8c23-a004f3236d9a')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aa0d347f-f6bd-41e6-a1e9-f1e8aab0546f', N'48625d54-b98f-4613-8c23-a004f3236d9a')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4354343-5902-472b-810c-bd74a7511506', N'80def832-b8b0-4d95-ad89-edfd5e6deaa0')
SET IDENTITY_INSERT [dbo].[Publisher] ON
INSERT INTO [dbo].[Publisher] ([Id], [Name], [Email]) VALUES (1, N'Dan W Johnson', N'dan@repo.com')
INSERT INTO [dbo].[Publisher] ([Id], [Name], [Email]) VALUES (2, N'Samson Johns', N'sam@repo.com')
SET IDENTITY_INSERT [dbo].[Publisher] OFF


SET IDENTITY_INSERT [dbo].[Document] ON
INSERT INTO [dbo].[Document] ([Id], [DocumentName], [DocumentUrl], [PublisherId], [Modified]) VALUES (1, N'sample text doc', N'sample_upload_text.txt', 1, N'2020-01-09 20:19:35')
INSERT INTO [dbo].[Document] ([Id], [DocumentName], [DocumentUrl], [PublisherId], [Modified]) VALUES (2, N'sample image file 1', N'sample_image.jpg', 2, N'2020-01-09 21:31:08')
INSERT INTO [dbo].[Document] ([Id], [DocumentName], [DocumentUrl], [PublisherId], [Modified]) VALUES (3, N'sample zip file', N'sample_compressed_docs.zip', 1, N'2020-01-09 21:42:04')
SET IDENTITY_INSERT [dbo].[Document] OFF
SET IDENTITY_INSERT [dbo].[DocumentLog] ON
INSERT INTO [dbo].[DocumentLog] ([Id], [DocumentId], [Time], [Operation]) VALUES (1, 1, N'2020-01-09 20:19:36', 0)
INSERT INTO [dbo].[DocumentLog] ([Id], [DocumentId], [Time], [Operation]) VALUES (2, 2, N'2020-01-09 21:30:09', 0)
INSERT INTO [dbo].[DocumentLog] ([Id], [DocumentId], [Time], [Operation]) VALUES (3, 2, N'2020-01-09 21:31:08', 1)
INSERT INTO [dbo].[DocumentLog] ([Id], [DocumentId], [Time], [Operation]) VALUES (4, 3, N'2020-01-09 21:42:06', 0)
SET IDENTITY_INSERT [dbo].[DocumentLog] OFF
