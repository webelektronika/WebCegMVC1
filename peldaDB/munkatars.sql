CREATE TABLE [dbo].[munkatars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nev] NVARCHAR(50) NOT NULL, 
    [Varos] NVARCHAR(50) NOT NULL, 
    [Beosztas] NVARCHAR(50) NULL, 
    [Nyelvtudas] NVARCHAR(50) NULL
)
