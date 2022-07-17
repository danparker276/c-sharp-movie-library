CREATE TABLE [dbo].[rentals]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [MovieId] INT NOT NULL, 
    [Rented] DATETIME NULL, 
    [Returned] DATETIME NULL, 
    [Status] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_rentals_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_rentals_ToMovies] FOREIGN KEY ([MovieId]) REFERENCES [Movies]([Id])
)
