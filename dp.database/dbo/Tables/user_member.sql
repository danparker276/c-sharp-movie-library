CREATE TABLE [dbo].[user_member]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [Membership] INT NOT NULL DEFAULT 0, 
    [FirstName] NVARCHAR(250) NULL, 
    [LastName] NVARCHAR(250) NULL, 
    CONSTRAINT [FK_user_member_users] FOREIGN KEY ([UserId]) REFERENCES [users]([UserId])
)
