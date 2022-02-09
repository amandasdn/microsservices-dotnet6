USE [02_shopping]
GO

IF (OBJECT_ID('dbo.tb_products') IS NOT NULL) DROP TABLE dbo.tb_products
GO

CREATE TABLE [dbo].[tb_products]
(
  [id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  [active] BIT NOT NULL DEFAULT(1),
  [created_at] DATETIME DEFAULT GETDATE(),
  [updated_at] DATETIME DEFAULT GETDATE(),

  [name] VARCHAR(200) NULL,
  [price] DECIMAL(7,2) NULL,
  [description] VARCHAR(1000) NULL
);


BEGIN TRAN

INSERT INTO tb_products (name, price, description)
VALUES ('Caderno', 19.00, 'O caderno possui capa dura, folhas pautadas e espiral colorido. Ideal para o dia a dia na escola ou na faculdade.')
GO

INSERT INTO tb_products (name, price, description)
VALUES ('Lápis', 4.99, 'O lápis possui exclusivas esferas antidelizantes que dá um maior conforte e firmeza no traço, e formato triangular ergonômico que garante conforte e melhor escrita')
GO

INSERT INTO tb_products (name, price, description)
VALUES ('Estojo', 8.50, 'O estojo escolar foi desenvolvido para proteger e organizar os seus pertences.')
GO

COMMIT TRAN