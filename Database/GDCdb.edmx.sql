
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 21:08:12
-- Generated from EDMX file: C:\Users\Dragorad\OneDrive\VIII semestar\Baze podataka 2\Projekat\GameDevelopmentCompany\Database\GDCdb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gdcDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GameDevelopmentCompanyEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_GameDevelopmentCompanyEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_GameDevelopmentCompanyGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Games] DROP CONSTRAINT [FK_GameDevelopmentCompanyGame];
GO
IF OBJECT_ID(N'[dbo].[FK_GameDesignerGameBlueprint_GameDesigner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameDesignerGameBlueprint] DROP CONSTRAINT [FK_GameDesignerGameBlueprint_GameDesigner];
GO
IF OBJECT_ID(N'[dbo].[FK_GameDesignerGameBlueprint_GameBlueprint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameDesignerGameBlueprint] DROP CONSTRAINT [FK_GameDesignerGameBlueprint_GameBlueprint];
GO
IF OBJECT_ID(N'[dbo].[FK_GameBetaVersion_Game]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameBetaVersion] DROP CONSTRAINT [FK_GameBetaVersion_Game];
GO
IF OBJECT_ID(N'[dbo].[FK_GameBetaVersion_BetaVersion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameBetaVersion] DROP CONSTRAINT [FK_GameBetaVersion_BetaVersion];
GO
IF OBJECT_ID(N'[dbo].[FK_TesterBetaVersion_Tester]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TesterBetaVersion] DROP CONSTRAINT [FK_TesterBetaVersion_Tester];
GO
IF OBJECT_ID(N'[dbo].[FK_TesterBetaVersion_BetaVersion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TesterBetaVersion] DROP CONSTRAINT [FK_TesterBetaVersion_BetaVersion];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtTester_Art]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtTester] DROP CONSTRAINT [FK_ArtTester_Art];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtTester_Tester]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtTester] DROP CONSTRAINT [FK_ArtTester_Tester];
GO
IF OBJECT_ID(N'[dbo].[FK_GameBlueprintCode_GameBlueprint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameBlueprintCode] DROP CONSTRAINT [FK_GameBlueprintCode_GameBlueprint];
GO
IF OBJECT_ID(N'[dbo].[FK_GameBlueprintCode_Code]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameBlueprintCode] DROP CONSTRAINT [FK_GameBlueprintCode_Code];
GO
IF OBJECT_ID(N'[dbo].[FK_CodeProgrammer_Code]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CodeProgrammer] DROP CONSTRAINT [FK_CodeProgrammer_Code];
GO
IF OBJECT_ID(N'[dbo].[FK_CodeProgrammer_Programmer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CodeProgrammer] DROP CONSTRAINT [FK_CodeProgrammer_Programmer];
GO
IF OBJECT_ID(N'[dbo].[FK_CodeArt_Code]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CodeArt] DROP CONSTRAINT [FK_CodeArt_Code];
GO
IF OBJECT_ID(N'[dbo].[FK_CodeArt_Art]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CodeArt] DROP CONSTRAINT [FK_CodeArt_Art];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtArtist_Art]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtArtist] DROP CONSTRAINT [FK_ArtArtist_Art];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtArtist_Artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArtArtist] DROP CONSTRAINT [FK_ArtArtist_Artist];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_EmployeeEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_GameDesigner_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_GameDesigner] DROP CONSTRAINT [FK_GameDesigner_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Tester_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Tester] DROP CONSTRAINT [FK_Tester_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Programmer_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Programmer] DROP CONSTRAINT [FK_Programmer_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Artist_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Artist] DROP CONSTRAINT [FK_Artist_inherits_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GameDevelopmentCompanies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameDevelopmentCompanies];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Games];
GO
IF OBJECT_ID(N'[dbo].[GameBlueprints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameBlueprints];
GO
IF OBJECT_ID(N'[dbo].[Codes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Codes];
GO
IF OBJECT_ID(N'[dbo].[BetaVersions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BetaVersions];
GO
IF OBJECT_ID(N'[dbo].[Arts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Arts];
GO
IF OBJECT_ID(N'[dbo].[Employees_GameDesigner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_GameDesigner];
GO
IF OBJECT_ID(N'[dbo].[Employees_Tester]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Tester];
GO
IF OBJECT_ID(N'[dbo].[Employees_Programmer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Programmer];
GO
IF OBJECT_ID(N'[dbo].[Employees_Artist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Artist];
GO
IF OBJECT_ID(N'[dbo].[GameDesignerGameBlueprint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameDesignerGameBlueprint];
GO
IF OBJECT_ID(N'[dbo].[GameBetaVersion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameBetaVersion];
GO
IF OBJECT_ID(N'[dbo].[TesterBetaVersion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TesterBetaVersion];
GO
IF OBJECT_ID(N'[dbo].[ArtTester]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtTester];
GO
IF OBJECT_ID(N'[dbo].[GameBlueprintCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameBlueprintCode];
GO
IF OBJECT_ID(N'[dbo].[CodeProgrammer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CodeProgrammer];
GO
IF OBJECT_ID(N'[dbo].[CodeArt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CodeArt];
GO
IF OBJECT_ID(N'[dbo].[ArtArtist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtArtist];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GameDevelopmentCompanies'
CREATE TABLE [dbo].[GameDevelopmentCompanies] (
    [Company_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Employee_Id] int IDENTITY(1,1) NOT NULL,
    [First_name] nvarchar(max)  NOT NULL,
    [Last_name] nvarchar(max)  NOT NULL,
    [GameDevelopmentCompanyCompany_Id] int  NOT NULL,
    [EmployeeEmployee_Id] int  NULL,
    [Position] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [Game_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Release_date] nvarchar(max)  NOT NULL,
    [GameDevelopmentCompanyCompany_Id] int  NOT NULL
);
GO

-- Creating table 'GameBlueprints'
CREATE TABLE [dbo].[GameBlueprints] (
    [Blu_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Codes'
CREATE TABLE [dbo].[Codes] (
    [Code_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BetaVersions'
CREATE TABLE [dbo].[BetaVersions] (
    [Beta_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Arts'
CREATE TABLE [dbo].[Arts] (
    [Art_Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees_GameDesigner'
CREATE TABLE [dbo].[Employees_GameDesigner] (
    [Employee_Id] int  NOT NULL
);
GO

-- Creating table 'Employees_Tester'
CREATE TABLE [dbo].[Employees_Tester] (
    [Employee_Id] int  NOT NULL
);
GO

-- Creating table 'Employees_Programmer'
CREATE TABLE [dbo].[Employees_Programmer] (
    [Employee_Id] int  NOT NULL
);
GO

-- Creating table 'Employees_Artist'
CREATE TABLE [dbo].[Employees_Artist] (
    [Employee_Id] int  NOT NULL
);
GO

-- Creating table 'GameDesignerGameBlueprint'
CREATE TABLE [dbo].[GameDesignerGameBlueprint] (
    [GameDesigners_Employee_Id] int  NOT NULL,
    [GameBlueprints_Blu_Id] int  NOT NULL
);
GO

-- Creating table 'GameBetaVersion'
CREATE TABLE [dbo].[GameBetaVersion] (
    [Games_Game_Id] int  NOT NULL,
    [BetaVersions_Beta_Id] int  NOT NULL
);
GO

-- Creating table 'TesterBetaVersion'
CREATE TABLE [dbo].[TesterBetaVersion] (
    [Testers_Employee_Id] int  NOT NULL,
    [BetaVersions_Beta_Id] int  NOT NULL
);
GO

-- Creating table 'ArtTester'
CREATE TABLE [dbo].[ArtTester] (
    [Arts_Art_Id] int  NOT NULL,
    [Testers_Employee_Id] int  NOT NULL
);
GO

-- Creating table 'GameBlueprintCode'
CREATE TABLE [dbo].[GameBlueprintCode] (
    [GameBlueprints_Blu_Id] int  NOT NULL,
    [Codes_Code_Id] int  NOT NULL
);
GO

-- Creating table 'CodeProgrammer'
CREATE TABLE [dbo].[CodeProgrammer] (
    [Codes_Code_Id] int  NOT NULL,
    [Programmers_Employee_Id] int  NOT NULL
);
GO

-- Creating table 'CodeArt'
CREATE TABLE [dbo].[CodeArt] (
    [Codes_Code_Id] int  NOT NULL,
    [Arts_Art_Id] int  NOT NULL
);
GO

-- Creating table 'ArtArtist'
CREATE TABLE [dbo].[ArtArtist] (
    [Arts_Art_Id] int  NOT NULL,
    [Artists_Employee_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Company_Id] in table 'GameDevelopmentCompanies'
ALTER TABLE [dbo].[GameDevelopmentCompanies]
ADD CONSTRAINT [PK_GameDevelopmentCompanies]
    PRIMARY KEY CLUSTERED ([Company_Id] ASC);
GO

-- Creating primary key on [Employee_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Employee_Id] ASC);
GO

-- Creating primary key on [Game_Id] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([Game_Id] ASC);
GO

-- Creating primary key on [Blu_Id] in table 'GameBlueprints'
ALTER TABLE [dbo].[GameBlueprints]
ADD CONSTRAINT [PK_GameBlueprints]
    PRIMARY KEY CLUSTERED ([Blu_Id] ASC);
GO

-- Creating primary key on [Code_Id] in table 'Codes'
ALTER TABLE [dbo].[Codes]
ADD CONSTRAINT [PK_Codes]
    PRIMARY KEY CLUSTERED ([Code_Id] ASC);
GO

-- Creating primary key on [Beta_Id] in table 'BetaVersions'
ALTER TABLE [dbo].[BetaVersions]
ADD CONSTRAINT [PK_BetaVersions]
    PRIMARY KEY CLUSTERED ([Beta_Id] ASC);
GO

-- Creating primary key on [Art_Id] in table 'Arts'
ALTER TABLE [dbo].[Arts]
ADD CONSTRAINT [PK_Arts]
    PRIMARY KEY CLUSTERED ([Art_Id] ASC);
GO

-- Creating primary key on [Employee_Id] in table 'Employees_GameDesigner'
ALTER TABLE [dbo].[Employees_GameDesigner]
ADD CONSTRAINT [PK_Employees_GameDesigner]
    PRIMARY KEY CLUSTERED ([Employee_Id] ASC);
GO

-- Creating primary key on [Employee_Id] in table 'Employees_Tester'
ALTER TABLE [dbo].[Employees_Tester]
ADD CONSTRAINT [PK_Employees_Tester]
    PRIMARY KEY CLUSTERED ([Employee_Id] ASC);
GO

-- Creating primary key on [Employee_Id] in table 'Employees_Programmer'
ALTER TABLE [dbo].[Employees_Programmer]
ADD CONSTRAINT [PK_Employees_Programmer]
    PRIMARY KEY CLUSTERED ([Employee_Id] ASC);
GO

-- Creating primary key on [Employee_Id] in table 'Employees_Artist'
ALTER TABLE [dbo].[Employees_Artist]
ADD CONSTRAINT [PK_Employees_Artist]
    PRIMARY KEY CLUSTERED ([Employee_Id] ASC);
GO

-- Creating primary key on [GameDesigners_Employee_Id], [GameBlueprints_Blu_Id] in table 'GameDesignerGameBlueprint'
ALTER TABLE [dbo].[GameDesignerGameBlueprint]
ADD CONSTRAINT [PK_GameDesignerGameBlueprint]
    PRIMARY KEY CLUSTERED ([GameDesigners_Employee_Id], [GameBlueprints_Blu_Id] ASC);
GO

-- Creating primary key on [Games_Game_Id], [BetaVersions_Beta_Id] in table 'GameBetaVersion'
ALTER TABLE [dbo].[GameBetaVersion]
ADD CONSTRAINT [PK_GameBetaVersion]
    PRIMARY KEY CLUSTERED ([Games_Game_Id], [BetaVersions_Beta_Id] ASC);
GO

-- Creating primary key on [Testers_Employee_Id], [BetaVersions_Beta_Id] in table 'TesterBetaVersion'
ALTER TABLE [dbo].[TesterBetaVersion]
ADD CONSTRAINT [PK_TesterBetaVersion]
    PRIMARY KEY CLUSTERED ([Testers_Employee_Id], [BetaVersions_Beta_Id] ASC);
GO

-- Creating primary key on [Arts_Art_Id], [Testers_Employee_Id] in table 'ArtTester'
ALTER TABLE [dbo].[ArtTester]
ADD CONSTRAINT [PK_ArtTester]
    PRIMARY KEY CLUSTERED ([Arts_Art_Id], [Testers_Employee_Id] ASC);
GO

-- Creating primary key on [GameBlueprints_Blu_Id], [Codes_Code_Id] in table 'GameBlueprintCode'
ALTER TABLE [dbo].[GameBlueprintCode]
ADD CONSTRAINT [PK_GameBlueprintCode]
    PRIMARY KEY CLUSTERED ([GameBlueprints_Blu_Id], [Codes_Code_Id] ASC);
GO

-- Creating primary key on [Codes_Code_Id], [Programmers_Employee_Id] in table 'CodeProgrammer'
ALTER TABLE [dbo].[CodeProgrammer]
ADD CONSTRAINT [PK_CodeProgrammer]
    PRIMARY KEY CLUSTERED ([Codes_Code_Id], [Programmers_Employee_Id] ASC);
GO

-- Creating primary key on [Codes_Code_Id], [Arts_Art_Id] in table 'CodeArt'
ALTER TABLE [dbo].[CodeArt]
ADD CONSTRAINT [PK_CodeArt]
    PRIMARY KEY CLUSTERED ([Codes_Code_Id], [Arts_Art_Id] ASC);
GO

-- Creating primary key on [Arts_Art_Id], [Artists_Employee_Id] in table 'ArtArtist'
ALTER TABLE [dbo].[ArtArtist]
ADD CONSTRAINT [PK_ArtArtist]
    PRIMARY KEY CLUSTERED ([Arts_Art_Id], [Artists_Employee_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GameDevelopmentCompanyCompany_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_GameDevelopmentCompanyEmployee]
    FOREIGN KEY ([GameDevelopmentCompanyCompany_Id])
    REFERENCES [dbo].[GameDevelopmentCompanies]
        ([Company_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameDevelopmentCompanyEmployee'
CREATE INDEX [IX_FK_GameDevelopmentCompanyEmployee]
ON [dbo].[Employees]
    ([GameDevelopmentCompanyCompany_Id]);
GO

-- Creating foreign key on [GameDevelopmentCompanyCompany_Id] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [FK_GameDevelopmentCompanyGame]
    FOREIGN KEY ([GameDevelopmentCompanyCompany_Id])
    REFERENCES [dbo].[GameDevelopmentCompanies]
        ([Company_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameDevelopmentCompanyGame'
CREATE INDEX [IX_FK_GameDevelopmentCompanyGame]
ON [dbo].[Games]
    ([GameDevelopmentCompanyCompany_Id]);
GO

-- Creating foreign key on [GameDesigners_Employee_Id] in table 'GameDesignerGameBlueprint'
ALTER TABLE [dbo].[GameDesignerGameBlueprint]
ADD CONSTRAINT [FK_GameDesignerGameBlueprint_GameDesigner]
    FOREIGN KEY ([GameDesigners_Employee_Id])
    REFERENCES [dbo].[Employees_GameDesigner]
        ([Employee_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GameBlueprints_Blu_Id] in table 'GameDesignerGameBlueprint'
ALTER TABLE [dbo].[GameDesignerGameBlueprint]
ADD CONSTRAINT [FK_GameDesignerGameBlueprint_GameBlueprint]
    FOREIGN KEY ([GameBlueprints_Blu_Id])
    REFERENCES [dbo].[GameBlueprints]
        ([Blu_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameDesignerGameBlueprint_GameBlueprint'
CREATE INDEX [IX_FK_GameDesignerGameBlueprint_GameBlueprint]
ON [dbo].[GameDesignerGameBlueprint]
    ([GameBlueprints_Blu_Id]);
GO

-- Creating foreign key on [Games_Game_Id] in table 'GameBetaVersion'
ALTER TABLE [dbo].[GameBetaVersion]
ADD CONSTRAINT [FK_GameBetaVersion_Game]
    FOREIGN KEY ([Games_Game_Id])
    REFERENCES [dbo].[Games]
        ([Game_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BetaVersions_Beta_Id] in table 'GameBetaVersion'
ALTER TABLE [dbo].[GameBetaVersion]
ADD CONSTRAINT [FK_GameBetaVersion_BetaVersion]
    FOREIGN KEY ([BetaVersions_Beta_Id])
    REFERENCES [dbo].[BetaVersions]
        ([Beta_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameBetaVersion_BetaVersion'
CREATE INDEX [IX_FK_GameBetaVersion_BetaVersion]
ON [dbo].[GameBetaVersion]
    ([BetaVersions_Beta_Id]);
GO

-- Creating foreign key on [Testers_Employee_Id] in table 'TesterBetaVersion'
ALTER TABLE [dbo].[TesterBetaVersion]
ADD CONSTRAINT [FK_TesterBetaVersion_Tester]
    FOREIGN KEY ([Testers_Employee_Id])
    REFERENCES [dbo].[Employees_Tester]
        ([Employee_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BetaVersions_Beta_Id] in table 'TesterBetaVersion'
ALTER TABLE [dbo].[TesterBetaVersion]
ADD CONSTRAINT [FK_TesterBetaVersion_BetaVersion]
    FOREIGN KEY ([BetaVersions_Beta_Id])
    REFERENCES [dbo].[BetaVersions]
        ([Beta_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TesterBetaVersion_BetaVersion'
CREATE INDEX [IX_FK_TesterBetaVersion_BetaVersion]
ON [dbo].[TesterBetaVersion]
    ([BetaVersions_Beta_Id]);
GO

-- Creating foreign key on [Arts_Art_Id] in table 'ArtTester'
ALTER TABLE [dbo].[ArtTester]
ADD CONSTRAINT [FK_ArtTester_Art]
    FOREIGN KEY ([Arts_Art_Id])
    REFERENCES [dbo].[Arts]
        ([Art_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Testers_Employee_Id] in table 'ArtTester'
ALTER TABLE [dbo].[ArtTester]
ADD CONSTRAINT [FK_ArtTester_Tester]
    FOREIGN KEY ([Testers_Employee_Id])
    REFERENCES [dbo].[Employees_Tester]
        ([Employee_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtTester_Tester'
CREATE INDEX [IX_FK_ArtTester_Tester]
ON [dbo].[ArtTester]
    ([Testers_Employee_Id]);
GO

-- Creating foreign key on [GameBlueprints_Blu_Id] in table 'GameBlueprintCode'
ALTER TABLE [dbo].[GameBlueprintCode]
ADD CONSTRAINT [FK_GameBlueprintCode_GameBlueprint]
    FOREIGN KEY ([GameBlueprints_Blu_Id])
    REFERENCES [dbo].[GameBlueprints]
        ([Blu_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Codes_Code_Id] in table 'GameBlueprintCode'
ALTER TABLE [dbo].[GameBlueprintCode]
ADD CONSTRAINT [FK_GameBlueprintCode_Code]
    FOREIGN KEY ([Codes_Code_Id])
    REFERENCES [dbo].[Codes]
        ([Code_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameBlueprintCode_Code'
CREATE INDEX [IX_FK_GameBlueprintCode_Code]
ON [dbo].[GameBlueprintCode]
    ([Codes_Code_Id]);
GO

-- Creating foreign key on [Codes_Code_Id] in table 'CodeProgrammer'
ALTER TABLE [dbo].[CodeProgrammer]
ADD CONSTRAINT [FK_CodeProgrammer_Code]
    FOREIGN KEY ([Codes_Code_Id])
    REFERENCES [dbo].[Codes]
        ([Code_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Programmers_Employee_Id] in table 'CodeProgrammer'
ALTER TABLE [dbo].[CodeProgrammer]
ADD CONSTRAINT [FK_CodeProgrammer_Programmer]
    FOREIGN KEY ([Programmers_Employee_Id])
    REFERENCES [dbo].[Employees_Programmer]
        ([Employee_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CodeProgrammer_Programmer'
CREATE INDEX [IX_FK_CodeProgrammer_Programmer]
ON [dbo].[CodeProgrammer]
    ([Programmers_Employee_Id]);
GO

-- Creating foreign key on [Codes_Code_Id] in table 'CodeArt'
ALTER TABLE [dbo].[CodeArt]
ADD CONSTRAINT [FK_CodeArt_Code]
    FOREIGN KEY ([Codes_Code_Id])
    REFERENCES [dbo].[Codes]
        ([Code_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Arts_Art_Id] in table 'CodeArt'
ALTER TABLE [dbo].[CodeArt]
ADD CONSTRAINT [FK_CodeArt_Art]
    FOREIGN KEY ([Arts_Art_Id])
    REFERENCES [dbo].[Arts]
        ([Art_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CodeArt_Art'
CREATE INDEX [IX_FK_CodeArt_Art]
ON [dbo].[CodeArt]
    ([Arts_Art_Id]);
GO

-- Creating foreign key on [Arts_Art_Id] in table 'ArtArtist'
ALTER TABLE [dbo].[ArtArtist]
ADD CONSTRAINT [FK_ArtArtist_Art]
    FOREIGN KEY ([Arts_Art_Id])
    REFERENCES [dbo].[Arts]
        ([Art_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Artists_Employee_Id] in table 'ArtArtist'
ALTER TABLE [dbo].[ArtArtist]
ADD CONSTRAINT [FK_ArtArtist_Artist]
    FOREIGN KEY ([Artists_Employee_Id])
    REFERENCES [dbo].[Employees_Artist]
        ([Employee_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtArtist_Artist'
CREATE INDEX [IX_FK_ArtArtist_Artist]
ON [dbo].[ArtArtist]
    ([Artists_Employee_Id]);
GO

-- Creating foreign key on [EmployeeEmployee_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeEmployee]
    FOREIGN KEY ([EmployeeEmployee_Id])
    REFERENCES [dbo].[Employees]
        ([Employee_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeEmployee'
CREATE INDEX [IX_FK_EmployeeEmployee]
ON [dbo].[Employees]
    ([EmployeeEmployee_Id]);
GO

-- Creating foreign key on [Employee_Id] in table 'Employees_GameDesigner'
ALTER TABLE [dbo].[Employees_GameDesigner]
ADD CONSTRAINT [FK_GameDesigner_inherits_Employee]
    FOREIGN KEY ([Employee_Id])
    REFERENCES [dbo].[Employees]
        ([Employee_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Employee_Id] in table 'Employees_Tester'
ALTER TABLE [dbo].[Employees_Tester]
ADD CONSTRAINT [FK_Tester_inherits_Employee]
    FOREIGN KEY ([Employee_Id])
    REFERENCES [dbo].[Employees]
        ([Employee_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Employee_Id] in table 'Employees_Programmer'
ALTER TABLE [dbo].[Employees_Programmer]
ADD CONSTRAINT [FK_Programmer_inherits_Employee]
    FOREIGN KEY ([Employee_Id])
    REFERENCES [dbo].[Employees]
        ([Employee_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Employee_Id] in table 'Employees_Artist'
ALTER TABLE [dbo].[Employees_Artist]
ADD CONSTRAINT [FK_Artist_inherits_Employee]
    FOREIGN KEY ([Employee_Id])
    REFERENCES [dbo].[Employees]
        ([Employee_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------