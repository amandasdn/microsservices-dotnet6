USE [02_shopping]
GO

IF (OBJECT_ID('dbo.tb_products') IS NOT NULL) DROP TABLE dbo.tb_products
GO

CREATE TABLE [dbo].[tb_products]
(
  [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [active] BIT NOT NULL DEFAULT(0),
  [removed] BIT NOT NULL DEFAULT(0),
  [created_at] DATETIME DEFAULT GETDATE(),
  [updated_at] DATETIME DEFAULT GETDATE(),

  [name] VARCHAR(200) NULL,
  [price] DECIMAL NULL,
  [description] VARCHAR(1000) NULL
);