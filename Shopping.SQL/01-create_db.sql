IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = '02_shopping')
BEGIN
    CREATE DATABASE [02_shopping]
END