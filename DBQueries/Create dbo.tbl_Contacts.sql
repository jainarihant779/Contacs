USE [ManageContacts]
GO

/****** Object: Table [dbo].[tbl_Contacts] Script Date: 16-08-2021 18:58:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Contacts] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (20)  NOT NULL,
    [LastName]    VARCHAR (100) NOT NULL,
    [Email]       VARCHAR (20)  NOT NULL,
    [PhoneNumber] VARCHAR (15)  NOT NULL,
    [status]      BIT           NOT NULL
);


