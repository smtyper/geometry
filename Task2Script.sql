CREATE TABLE [dbo].[Product]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
)

GO

CREATE TABLE [dbo].[Category]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
)

GO

CREATE TABLE [dbo].[ProductCategory]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [CategoryId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
)

GO

INSERT INTO [dbo].[Product] (
    [Id],
    [Name]
)
SELECT
    *
FROM
(
    VALUES
        ('5518b65e-b0d4-4ac3-8973-6d7d9bf07edd', 'Parmesan'),
        ('f7023c9e-83ab-4e16-bd34-dd23643f392a', 'Milk'),
        ('d93cf28c-f27e-4e8c-8798-61c5c2021906', 'Cherry'),
        ('0c7fca39-ae4c-43be-a01f-2a3d7d1cd6b3', 'Butter'),
        ('fe410cb2-c039-48ef-bea6-6834859aa1f3', 'Error name'), 
        ('d1d70a92-b079-4ead-a9f3-17ba26f8e6a1', 'Raspberries juice'),
        ('e26fdca8-1902-4311-b556-cce3c49cdaa6', 'Egg')
) AS [Values] ([Id], [Name])

GO

INSERT INTO [dbo].[Category] (
    [Id],
    [Name]
)
SELECT
    *
FROM
(
    VALUES
        ('92f16f03-8d96-4fe5-9e97-5459ceae7cd0', 'Dairy'),
        ('cf7d7956-2ea2-4969-89c5-cab2410d7ce2', 'berries'),
        ('da324cea-bb09-4158-ac5f-aea7f3c86869', 'liquid'),
        ('3286ce51-a51b-4a8d-9600-189f5015f345', 'cheese products'),
        ('fc7e9093-a042-4359-868a-b8ee20c727cb', 'sweet'),
        ('e8ebf3d3-32b4-4887-ba0c-b9cfdc1504b8', 'games')
) AS [Values] ([Id], [Name])

GO

INSERT INTO [dbo].[ProductCategory] (
    [Id],
    [ProductId],
    [CategoryId]
)
SELECT
    *
FROM
(
    VALUES
        ('ff11c323-4071-4a70-97e2-44508208fd5d', '5518b65e-b0d4-4ac3-8973-6d7d9bf07edd', '92f16f03-8d96-4fe5-9e97-5459ceae7cd0'),
        ('f61a827e-1922-4bda-8bec-f08a0901d598', '5518b65e-b0d4-4ac3-8973-6d7d9bf07edd', '3286ce51-a51b-4a8d-9600-189f5015f345'),
        ('5a86a46b-0974-4bcd-8d83-fb39ea0ad75d', 'f7023c9e-83ab-4e16-bd34-dd23643f392a', '92f16f03-8d96-4fe5-9e97-5459ceae7cd0'),
        ('ab5c8f4c-8552-4294-9161-cc01f8164601', 'f7023c9e-83ab-4e16-bd34-dd23643f392a', 'da324cea-bb09-4158-ac5f-aea7f3c86869'),
        ('ae08e5a6-bc7a-4d90-abc3-76772ff4a025', 'd93cf28c-f27e-4e8c-8798-61c5c2021906', 'cf7d7956-2ea2-4969-89c5-cab2410d7ce2'),
        ('27dea9d8-819f-4d27-a9c8-d856ddf5b411', 'd93cf28c-f27e-4e8c-8798-61c5c2021906', 'fc7e9093-a042-4359-868a-b8ee20c727cb'),
        ('ee3727f3-4685-4f20-b87e-1fbf98e30c6a', '0c7fca39-ae4c-43be-a01f-2a3d7d1cd6b3', '92f16f03-8d96-4fe5-9e97-5459ceae7cd0'),
        ('2a295112-2817-469b-be24-5e9ce6557421', 'd1d70a92-b079-4ead-a9f3-17ba26f8e6a1', 'cf7d7956-2ea2-4969-89c5-cab2410d7ce2'),
        ('6070e0bb-ca31-4e9e-a614-b25c81a25db7', 'd1d70a92-b079-4ead-a9f3-17ba26f8e6a1', 'fc7e9093-a042-4359-868a-b8ee20c727cb'),
        ('e5a1875b-048b-4ed0-9c5a-9918a032d246', 'd1d70a92-b079-4ead-a9f3-17ba26f8e6a1', 'da324cea-bb09-4158-ac5f-aea7f3c86869')
) AS [Values] ([Id], [ProductId], [CategoryId])

GO

SELECT
    [Product].[Name] AS [ProductName],
    [Category].[Name] AS [CategoryName]
FROM
    [dbo].[Product]
LEFT JOIN
    [dbo].[ProductCategory]
ON
    [ProductCategory].[ProductId] = [Product].[Id]
LEFT JOIN
    [dbo].[Category]
ON
    [ProductCategory].[CategoryId] = [Category].[Id]
