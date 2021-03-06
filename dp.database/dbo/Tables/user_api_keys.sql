CREATE TABLE [dbo].[user_api_keys]
(
	[UserApiKeyId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ApiKeyValue] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Created] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_user_api_keys_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users]([UserId])
)
