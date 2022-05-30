﻿CREATE TABLE [dbo].[UserProfiles]
(
    [Email] NVARCHAR(50)  NULL,
    [UserId]    NVARCHAR(450) NOT NULL,
    CONSTRAINT [FK_AspNetUsers_UserProfiles] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);