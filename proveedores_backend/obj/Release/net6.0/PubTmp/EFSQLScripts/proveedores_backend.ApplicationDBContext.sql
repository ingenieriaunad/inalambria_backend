IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    CREATE TABLE [Providers] (
        [IdProvider] uniqueidentifier NOT NULL,
        [Identification] nvarchar(max) NOT NULL,
        [Name] nvarchar(250) NOT NULL,
        [Phone] nvarchar(15) NOT NULL,
        [Email] nvarchar(250) NOT NULL,
        CONSTRAINT [PK_Providers] PRIMARY KEY ([IdProvider])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    CREATE TABLE [Products] (
        [IdProduct] uniqueidentifier NOT NULL,
        [Name] nvarchar(250) NOT NULL,
        [Price] int NOT NULL,
        [Stock] int NOT NULL,
        [IdProvider] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([IdProduct]),
        CONSTRAINT [FK_Products_Providers_IdProvider] FOREIGN KEY ([IdProvider]) REFERENCES [Providers] ([IdProvider]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    CREATE TABLE [Sales] (
        [IdSale] uniqueidentifier NOT NULL,
        [IdProducto] uniqueidentifier NOT NULL,
        [Quantity] int NOT NULL,
        [Total] int NOT NULL,
        [Date] datetime2 NOT NULL,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([IdSale]),
        CONSTRAINT [FK_Sales_Products_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [Products] ([IdProduct]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProvider', N'Email', N'Identification', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Providers]'))
        SET IDENTITY_INSERT [Providers] ON;
    EXEC(N'INSERT INTO [Providers] ([IdProvider], [Email], [Identification], [Name], [Phone])
    VALUES (''4dab72fe-beb5-42dd-9601-61e7691d17c6'', N''proveedor2@inalambria.com'', N''987654321'', N''Proveedor 2'', N''987654321''),
    (''8ff00858-4005-4ab3-8fa6-701b9f93f6ef'', N''proveedor1@inalambria.com'', N''123456789'', N''Proveedor 1'', N''123456789'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProvider', N'Email', N'Identification', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Providers]'))
        SET IDENTITY_INSERT [Providers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProduct', N'IdProvider', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([IdProduct], [IdProvider], [Name], [Price], [Stock])
    VALUES (''a99ed444-60ba-489d-8e66-d62eb1f67762'', ''4dab72fe-beb5-42dd-9601-61e7691d17c6'', N''Producto 2'', 2000, 20),
    (''b775477b-8c4d-4d7b-964b-092497ea8935'', ''8ff00858-4005-4ab3-8fa6-701b9f93f6ef'', N''Producto 1'', 1000, 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProduct', N'IdProvider', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSale', N'Date', N'IdProducto', N'Quantity', N'Total') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] ON;
    EXEC(N'INSERT INTO [Sales] ([IdSale], [Date], [IdProducto], [Quantity], [Total])
    VALUES (''3c694f64-8e17-4f7a-8bc2-a901b5d2bac4'', ''2023-01-25T22:30:32.4487131-05:00'', ''b775477b-8c4d-4d7b-964b-092497ea8935'', 1, 1000),
    (''7678cb8e-50c6-447b-85ae-32e11a9e447b'', ''2023-01-25T22:30:32.4487151-05:00'', ''a99ed444-60ba-489d-8e66-d62eb1f67762'', 2, 4000)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSale', N'Date', N'IdProducto', N'Quantity', N'Total') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    CREATE INDEX [IX_Products_IdProvider] ON [Products] ([IdProvider]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    CREATE INDEX [IX_Sales_IdProducto] ON [Sales] ([IdProducto]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126033032_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230126033032_Initial', N'7.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    EXEC(N'DELETE FROM [Sales]
    WHERE [IdSale] = ''3c694f64-8e17-4f7a-8bc2-a901b5d2bac4'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    EXEC(N'DELETE FROM [Sales]
    WHERE [IdSale] = ''7678cb8e-50c6-447b-85ae-32e11a9e447b'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [IdProduct] = ''a99ed444-60ba-489d-8e66-d62eb1f67762'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [IdProduct] = ''b775477b-8c4d-4d7b-964b-092497ea8935'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    EXEC(N'DELETE FROM [Providers]
    WHERE [IdProvider] = ''4dab72fe-beb5-42dd-9601-61e7691d17c6'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    EXEC(N'DELETE FROM [Providers]
    WHERE [IdProvider] = ''8ff00858-4005-4ab3-8fa6-701b9f93f6ef'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Providers]') AND [c].[name] = N'Identification');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Providers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Providers] ALTER COLUMN [Identification] nvarchar(15) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProvider', N'Email', N'Identification', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Providers]'))
        SET IDENTITY_INSERT [Providers] ON;
    EXEC(N'INSERT INTO [Providers] ([IdProvider], [Email], [Identification], [Name], [Phone])
    VALUES (''263f08aa-fa5d-49af-9ea8-693eb963ed40'', N''proveedor1@inalambria.com'', N''123456789'', N''Proveedor 1'', N''123456789''),
    (''56393997-612c-49a9-89ba-c15c31641f15'', N''proveedor2@inalambria.com'', N''987654321'', N''Proveedor 2'', N''987654321'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProvider', N'Email', N'Identification', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Providers]'))
        SET IDENTITY_INSERT [Providers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProduct', N'IdProvider', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([IdProduct], [IdProvider], [Name], [Price], [Stock])
    VALUES (''673580d1-38aa-4588-8230-a7f39d981c8e'', ''263f08aa-fa5d-49af-9ea8-693eb963ed40'', N''Producto 1'', 1000, 10),
    (''e56125fa-8267-4490-98b6-060579efe311'', ''56393997-612c-49a9-89ba-c15c31641f15'', N''Producto 2'', 2000, 20)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProduct', N'IdProvider', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSale', N'Date', N'IdProducto', N'Quantity', N'Total') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] ON;
    EXEC(N'INSERT INTO [Sales] ([IdSale], [Date], [IdProducto], [Quantity], [Total])
    VALUES (''683b1d6c-d73d-4416-b323-fd733b79bd7a'', ''2023-01-26T10:28:28.5967901-05:00'', ''e56125fa-8267-4490-98b6-060579efe311'', 2, 4000),
    (''ed10750c-ce05-4d23-a8a9-0cb24a10ac51'', ''2023-01-26T10:28:28.5967887-05:00'', ''673580d1-38aa-4588-8230-a7f39d981c8e'', 1, 1000)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSale', N'Date', N'IdProducto', N'Quantity', N'Total') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    CREATE UNIQUE INDEX [IX_Providers_Identification] ON [Providers] ([Identification]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126152828_IdentificationUnica')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230126152828_IdentificationUnica', N'7.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    EXEC(N'DELETE FROM [Sales]
    WHERE [IdSale] = ''683b1d6c-d73d-4416-b323-fd733b79bd7a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    EXEC(N'DELETE FROM [Sales]
    WHERE [IdSale] = ''ed10750c-ce05-4d23-a8a9-0cb24a10ac51'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [IdProduct] = ''673580d1-38aa-4588-8230-a7f39d981c8e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [IdProduct] = ''e56125fa-8267-4490-98b6-060579efe311'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    EXEC(N'DELETE FROM [Providers]
    WHERE [IdProvider] = ''263f08aa-fa5d-49af-9ea8-693eb963ed40'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    EXEC(N'DELETE FROM [Providers]
    WHERE [IdProvider] = ''56393997-612c-49a9-89ba-c15c31641f15'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sales]') AND [c].[name] = N'IdSale');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Sales] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Sales] ADD DEFAULT (NEWID()) FOR [IdSale];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Providers]') AND [c].[name] = N'IdProvider');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Providers] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Providers] ADD DEFAULT (NEWID()) FOR [IdProvider];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'IdProduct');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Products] ADD DEFAULT (NEWID()) FOR [IdProduct];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProvider', N'Email', N'Identification', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Providers]'))
        SET IDENTITY_INSERT [Providers] ON;
    EXEC(N'INSERT INTO [Providers] ([IdProvider], [Email], [Identification], [Name], [Phone])
    VALUES (''1cf8736f-4a91-4024-b487-ce87ccb3bc0c'', N''proveedor2@inalambria.com'', N''987654321'', N''Proveedor 2'', N''987654321''),
    (''e1527492-e961-4c5b-8b66-c70dc9b46b37'', N''proveedor1@inalambria.com'', N''123456789'', N''Proveedor 1'', N''123456789'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProvider', N'Email', N'Identification', N'Name', N'Phone') AND [object_id] = OBJECT_ID(N'[Providers]'))
        SET IDENTITY_INSERT [Providers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProduct', N'IdProvider', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([IdProduct], [IdProvider], [Name], [Price], [Stock])
    VALUES (''77ab317c-a7b6-4069-9a04-bc04bed81d64'', ''e1527492-e961-4c5b-8b66-c70dc9b46b37'', N''Producto 1'', 1000, 10),
    (''be5b56df-9782-4ac7-a520-03c577c790e7'', ''1cf8736f-4a91-4024-b487-ce87ccb3bc0c'', N''Producto 2'', 2000, 20)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdProduct', N'IdProvider', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSale', N'Date', N'IdProducto', N'Quantity', N'Total') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] ON;
    EXEC(N'INSERT INTO [Sales] ([IdSale], [Date], [IdProducto], [Quantity], [Total])
    VALUES (''1ab6891b-53f6-43f9-b724-fd16762cb15c'', ''2023-01-26T10:47:17.4082851-05:00'', ''be5b56df-9782-4ac7-a520-03c577c790e7'', 2, 4000),
    (''57ed4942-bc66-45ff-8c1f-e50ae023537e'', ''2023-01-26T10:47:17.4082826-05:00'', ''77ab317c-a7b6-4069-9a04-bc04bed81d64'', 1, 1000)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdSale', N'Date', N'IdProducto', N'Quantity', N'Total') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126154717_IDUnico')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230126154717_IDUnico', N'7.0.2');
END;
GO

COMMIT;
GO

