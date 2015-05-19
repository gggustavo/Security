
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/18/2014 10:45:57
-- Generated from EDMX file: C:\Users\gugarcia\Desktop\Source\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Seguridad];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AplicationGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_AplicationGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetObjects_dbo_AspNetAplications_AspNetAplications_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Elements] DROP CONSTRAINT [FK_dbo_AspNetObjects_dbo_AspNetAplications_AspNetAplications_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Roles_dbo_Aplications_Aplications_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [FK_dbo_Roles_dbo_Aplications_Aplications_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleGroup_Groups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleGroup] DROP CONSTRAINT [FK_RoleGroup_Groups];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleGroup_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleGroup] DROP CONSTRAINT [FK_RoleGroup_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDomainGroup_Groups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDomainGroup] DROP CONSTRAINT [FK_UserDomainGroup_Groups];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDomainGroup_UserDomains]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDomainGroup] DROP CONSTRAINT [FK_UserDomainGroup_UserDomains];
GO
IF OBJECT_ID(N'[dbo].[FK_ElementRole_Element]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ElementRole] DROP CONSTRAINT [FK_ElementRole_Element];
GO
IF OBJECT_ID(N'[dbo].[FK_ElementRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ElementRole] DROP CONSTRAINT [FK_ElementRole_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Aplications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aplications];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Elements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Elements];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[Permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissions];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[UserDomains]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserDomains];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[RoleGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleGroup];
GO
IF OBJECT_ID(N'[dbo].[UserDomainGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserDomainGroup];
GO
IF OBJECT_ID(N'[dbo].[ElementRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ElementRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aplications'
CREATE TABLE [dbo].[Aplications] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [Discriminator] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Elements'
CREATE TABLE [dbo].[Elements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Aplications_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Status] bit  NOT NULL,
    [Aplication_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Permissions'
CREATE TABLE [dbo].[Permissions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Aplications_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'UserDomains'
CREATE TABLE [dbo].[UserDomains] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] nvarchar(128)  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- Creating table 'RoleGroup'
CREATE TABLE [dbo].[RoleGroup] (
    [Groups_Id] int  NOT NULL,
    [Roles_Id] int  NOT NULL
);
GO

-- Creating table 'UserDomainGroup'
CREATE TABLE [dbo].[UserDomainGroup] (
    [Groups_Id] int  NOT NULL,
    [UserDomains_Id] int  NOT NULL
);
GO

-- Creating table 'ElementRole'
CREATE TABLE [dbo].[ElementRole] (
    [Element_Id] int  NOT NULL,
    [Roles_Id] int  NOT NULL
);
GO

-- Creating table 'ElementPermission'
CREATE TABLE [dbo].[ElementPermission] (
    [Element_Id] int  NOT NULL,
    [Permissions_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Aplications'
ALTER TABLE [dbo].[Aplications]
ADD CONSTRAINT [PK_Aplications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Elements'
ALTER TABLE [dbo].[Elements]
ADD CONSTRAINT [PK_Elements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [PK_Permissions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserDomains'
ALTER TABLE [dbo].[UserDomains]
ADD CONSTRAINT [PK_UserDomains]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- Creating primary key on [Groups_Id], [Roles_Id] in table 'RoleGroup'
ALTER TABLE [dbo].[RoleGroup]
ADD CONSTRAINT [PK_RoleGroup]
    PRIMARY KEY CLUSTERED ([Groups_Id], [Roles_Id] ASC);
GO

-- Creating primary key on [Groups_Id], [UserDomains_Id] in table 'UserDomainGroup'
ALTER TABLE [dbo].[UserDomainGroup]
ADD CONSTRAINT [PK_UserDomainGroup]
    PRIMARY KEY CLUSTERED ([Groups_Id], [UserDomains_Id] ASC);
GO

-- Creating primary key on [Element_Id], [Roles_Id] in table 'ElementRole'
ALTER TABLE [dbo].[ElementRole]
ADD CONSTRAINT [PK_ElementRole]
    PRIMARY KEY CLUSTERED ([Element_Id], [Roles_Id] ASC);
GO

-- Creating primary key on [Element_Id], [Permissions_Id] in table 'ElementPermission'
ALTER TABLE [dbo].[ElementPermission]
ADD CONSTRAINT [PK_ElementPermission]
    PRIMARY KEY CLUSTERED ([Element_Id], [Permissions_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Aplication_Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_AplicationGroup]
    FOREIGN KEY ([Aplication_Id])
    REFERENCES [dbo].[Aplications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AplicationGroup'
CREATE INDEX [IX_FK_AplicationGroup]
ON [dbo].[Groups]
    ([Aplication_Id]);
GO

-- Creating foreign key on [Aplications_Id] in table 'Elements'
ALTER TABLE [dbo].[Elements]
ADD CONSTRAINT [FK_dbo_AspNetObjects_dbo_AspNetAplications_AspNetAplications_Id]
    FOREIGN KEY ([Aplications_Id])
    REFERENCES [dbo].[Aplications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetObjects_dbo_AspNetAplications_AspNetAplications_Id'
CREATE INDEX [IX_FK_dbo_AspNetObjects_dbo_AspNetAplications_AspNetAplications_Id]
ON [dbo].[Elements]
    ([Aplications_Id]);
GO

-- Creating foreign key on [Aplications_Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_dbo_Roles_dbo_Aplications_Aplications_Id]
    FOREIGN KEY ([Aplications_Id])
    REFERENCES [dbo].[Aplications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Roles_dbo_Aplications_Aplications_Id'
CREATE INDEX [IX_FK_dbo_Roles_dbo_Aplications_Aplications_Id]
ON [dbo].[Roles]
    ([Aplications_Id]);
GO

-- Creating foreign key on [User_Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
ON [dbo].[AspNetUserClaims]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_Roles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_Roles'
CREATE INDEX [IX_FK_AspNetUserRoles_Roles]
ON [dbo].[AspNetUserRoles]
    ([RoleId]);
GO

-- Creating foreign key on [Groups_Id] in table 'RoleGroup'
ALTER TABLE [dbo].[RoleGroup]
ADD CONSTRAINT [FK_RoleGroup_Groups]
    FOREIGN KEY ([Groups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'RoleGroup'
ALTER TABLE [dbo].[RoleGroup]
ADD CONSTRAINT [FK_RoleGroup_Roles]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleGroup_Roles'
CREATE INDEX [IX_FK_RoleGroup_Roles]
ON [dbo].[RoleGroup]
    ([Roles_Id]);
GO

-- Creating foreign key on [Groups_Id] in table 'UserDomainGroup'
ALTER TABLE [dbo].[UserDomainGroup]
ADD CONSTRAINT [FK_UserDomainGroup_Groups]
    FOREIGN KEY ([Groups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserDomains_Id] in table 'UserDomainGroup'
ALTER TABLE [dbo].[UserDomainGroup]
ADD CONSTRAINT [FK_UserDomainGroup_UserDomains]
    FOREIGN KEY ([UserDomains_Id])
    REFERENCES [dbo].[UserDomains]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDomainGroup_UserDomains'
CREATE INDEX [IX_FK_UserDomainGroup_UserDomains]
ON [dbo].[UserDomainGroup]
    ([UserDomains_Id]);
GO

-- Creating foreign key on [Element_Id] in table 'ElementRole'
ALTER TABLE [dbo].[ElementRole]
ADD CONSTRAINT [FK_ElementRole_Element]
    FOREIGN KEY ([Element_Id])
    REFERENCES [dbo].[Elements]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'ElementRole'
ALTER TABLE [dbo].[ElementRole]
ADD CONSTRAINT [FK_ElementRole_Role]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ElementRole_Role'
CREATE INDEX [IX_FK_ElementRole_Role]
ON [dbo].[ElementRole]
    ([Roles_Id]);
GO

-- Creating foreign key on [Element_Id] in table 'ElementPermission'
ALTER TABLE [dbo].[ElementPermission]
ADD CONSTRAINT [FK_ElementPermission_Element]
    FOREIGN KEY ([Element_Id])
    REFERENCES [dbo].[Elements]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Permissions_Id] in table 'ElementPermission'
ALTER TABLE [dbo].[ElementPermission]
ADD CONSTRAINT [FK_ElementPermission_Permission]
    FOREIGN KEY ([Permissions_Id])
    REFERENCES [dbo].[Permissions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ElementPermission_Permission'
CREATE INDEX [IX_FK_ElementPermission_Permission]
ON [dbo].[ElementPermission]
    ([Permissions_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------