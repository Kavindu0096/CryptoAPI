USE [master]
GO
/****** Object:  Database [Crypto_UAT]    Script Date: 4/28/2021 2:19:47 AM ******/
CREATE DATABASE [Crypto_UAT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TS_UAT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Crypto_UAT.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TS_UAT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Crypto_UAT_0.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Crypto_UAT] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Crypto_UAT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Crypto_UAT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Crypto_UAT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Crypto_UAT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Crypto_UAT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Crypto_UAT] SET ARITHABORT OFF 
GO
ALTER DATABASE [Crypto_UAT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Crypto_UAT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Crypto_UAT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Crypto_UAT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Crypto_UAT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Crypto_UAT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Crypto_UAT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Crypto_UAT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Crypto_UAT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Crypto_UAT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Crypto_UAT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Crypto_UAT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Crypto_UAT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Crypto_UAT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Crypto_UAT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Crypto_UAT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Crypto_UAT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Crypto_UAT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Crypto_UAT] SET  MULTI_USER 
GO
ALTER DATABASE [Crypto_UAT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Crypto_UAT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Crypto_UAT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Crypto_UAT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Crypto_UAT] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Crypto_UAT]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_GET_Sequence]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE FUNCTION [dbo].[FN_GET_Sequence]
(
	@Type varchar(50)	
)
RETURNS varchar(max)	
AS
BEGIN
	-- Declare the return variable here
	DECLARE @CODE varchar(max)	

	select @CODE = Prefix +'_' + RIGHT('00000'+CAST(NextNumber AS VARCHAR(5)),5)
	from MD_Sequence 
	where Name = @Type;

	-- Return the result of the function
	RETURN @CODE

END


GO
/****** Object:  UserDefinedFunction [dbo].[FN_GET_Sequence_Number]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
CREATE FUNCTION [dbo].[FN_GET_Sequence_Number]
(
	@Type varchar(50)	
)
RETURNS varchar(max)	
AS
BEGIN
	-- Declare the return variable here
	DECLARE @CODE varchar(max)	

	select @CODE = NextNumber
	from MD_Sequence 
	where Name = @Type;

	-- Return the result of the function
	RETURN @CODE

END


GO
/****** Object:  Table [dbo].[AUT_User]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUT_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[EncryptedPassword] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_AUT_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AUT_UserRole]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUT_UserRole](
	[ID] [int] NOT NULL,
	[UserRole] [nvarchar](50) NULL,
 CONSTRAINT [PK_AUT_UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MD_Currency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_Currency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Currency] [nvarchar](20) NULL,
	[CurrencyDescription] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_MD_Currency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MD_MainCurrency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_MainCurrency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MainCurrency] [nvarchar](20) NULL,
	[MainCurrencyDescription] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_MD_MainCurrency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[REF_Status]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REF_Status](
	[ID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_REF_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TD_CurrencyRate]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_CurrencyRate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MainCurrencyID] [int] NULL,
	[CurrencyID] [int] NULL,
	[Rate] [decimal](30, 10) NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedAt] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_TD_CurrencyRate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TD_Order]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](10) NULL,
	[CurrencyID] [int] NULL,
	[ReceivedAmount] [decimal](30, 10) NULL,
	[CurrencyRate] [decimal](30, 10) NULL,
	[ConvertedAmount] [decimal](30, 10) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_TD_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AUT_User]    Script Date: 4/28/2021 2:19:47 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AUT_User] ON [dbo].[AUT_User]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AUT_User] ADD  CONSTRAINT [DF_AUT_User_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[MD_Currency] ADD  CONSTRAINT [DF_MD_Currency_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[MD_MainCurrency] ADD  CONSTRAINT [DF_MD_MainCurrency_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[TD_CurrencyRate] ADD  CONSTRAINT [DF_TD_CurrencyRate_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[TD_Order] ADD  CONSTRAINT [DF_TD_Order_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_ADD_CurrencyRate]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

CREATE PROCEDURE [dbo].[SP_MD_ADD_CurrencyRate]
	@CurrencyID INT,
	@MainCurrencyID INT,
	@Rate decimal(30, 10),
	@CreatedBy INT
AS
BEGIN
DECLARE @ReturnStatus varchar(max);

 
			INSERT INTO  TD_CurrencyRate
					   (CurrencyID
					   ,MainCurrencyID
					   ,Rate
					   ,CreatedBy
					   ,CreatedAt
						)
				 VALUES
					   (@CurrencyID
					   ,@MainCurrencyID
					   ,@Rate
					   ,@CreatedBy
					   ,GETDATE())

				SET @ReturnStatus='0,New Currency Rate Added  Successfull '  
		 


	SELECT @ReturnStatus  AS ReturnStatus
END
 
 
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_CREATE_Currency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_CREATE_Currency]
	@Currency varchar(20),
	@CurrencyDescription varchar(100),
	@CreatedBy INT
AS
BEGIN
DECLARE @ReturnStatus varchar(max);

IF EXISTS(SELECT A.ID FROM MD_Currency AS A WHERE UPPER(A.Currency) = UPPER(@Currency))
		BEGIN
			SET @ReturnStatus='2,Another Currency with  Name: '+@Currency+' Exists'
		END
	ELSE
		BEGIN
			INSERT INTO  MD_Currency
					   (Currency
					   ,CurrencyDescription
					   ,CreatedBy
					   ,CreatedAt
						)
				 VALUES
					   (@Currency
					   ,@CurrencyDescription
					   ,@CreatedBy
					   ,GETDATE())

				SET @ReturnStatus='0,New Currency Created Successfull '  
		END


	SELECT @ReturnStatus  AS ReturnStatus
END
 

GO
/****** Object:  StoredProcedure [dbo].[SP_MD_CREATE_MainCurrency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_CREATE_MainCurrency]
	@MainCurrency varchar(20),
	@MainCurrencyDescription varchar(100),
	@CreatedBy INT
AS
BEGIN
DECLARE @ReturnStatus varchar(max);

IF EXISTS(SELECT A.ID FROM MD_MainCurrency AS A WHERE UPPER(A.MainCurrency) = UPPER(@MainCurrency))
		BEGIN
			SET @ReturnStatus='2,Another Main Currency with  Name: '+@MainCurrency+' Exists'
		END
	ELSE
		BEGIN
			INSERT INTO  MD_MainCurrency
					   (MainCurrency
					   ,MainCurrencyDescription
					   ,CreatedBy
					   ,CreatedAt
						)
				 VALUES
					   (@MainCurrency
					   ,@MainCurrencyDescription
					   ,@CreatedBy
					   ,GETDATE())

				SET @ReturnStatus='0,New Main Currency Created Successfull '  
		END


	SELECT @ReturnStatus  AS ReturnStatus
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_CREATE_Order]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_CREATE_Order]
	@UserID INT,
	@CurrencyID INT,
	@ReceivedAmount decimal(30, 10),
	@CurrencyRate decimal(30, 10),
	@ConvertedAmount decimal(30, 10)
AS
BEGIN
DECLARE @ReturnStatus varchar(max);

 
			INSERT INTO  TD_Order
					   (UserID
					   ,CurrencyID
					   ,ReceivedAmount
					   ,CurrencyRate
					   ,ConvertedAmount
					   ,CreatedAt
						)
				 VALUES
					   (@UserID
					   ,@CurrencyID
					   ,@ReceivedAmount
					   ,@CurrencyRate
					   ,@ConvertedAmount
					   ,GETDATE())

				SET @ReturnStatus='0,New Order Added  Successfull '  
		 


	SELECT @ReturnStatus  AS ReturnStatus
END
 
 

GO
/****** Object:  StoredProcedure [dbo].[SP_MD_CREATE_User]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_CREATE_User]
	@UserName varchar(50),
	@Email varchar(MAX),
	@Password  varchar(MAX),
	@EncryptedPassword  varchar(MAX),
	@CreatedBy INT
AS
BEGIN
DECLARE @ReturnStatus varchar(max);

IF EXISTS(SELECT A.ID FROM AUT_User AS A WHERE UPPER(A.UserName) = UPPER(@UserName))
		BEGIN
			SET @ReturnStatus='2,Another User with User Name: '+@UserName+' Exists'
		END
	ELSE
		BEGIN
			INSERT INTO  AUT_User
					   (UserName
					   ,Email
					   ,Password
					   ,EncryptedPassword
					   ,CreatedBy
					   ,CreatedAt
						)
				 VALUES
					   (@UserName
					   ,@Email
					   ,@Password
					   ,@EncryptedPassword
					   ,@CreatedBy
					   ,GETDATE())

				SET @ReturnStatus='0,User Created Successfull '  
		END


	SELECT @ReturnStatus  AS ReturnStatus
END


GO
/****** Object:  StoredProcedure [dbo].[SP_MD_DELETE_Currency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_DELETE_Currency]
	@CurrencyID INT

AS
BEGIN
DECLARE @ReturnStatus varchar(max);


UPDATE   MD_Currency SET	DeletedAt=GETDATE()
						WHERE ID=@CurrencyID

SET @ReturnStatus='0,Currency Removed Successfull '  
 
	SELECT @ReturnStatus  AS ReturnStatus
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_DELETE_MainCurrency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_DELETE_MainCurrency]
	@MainCurrencyID INT

AS
BEGIN
DECLARE @ReturnStatus varchar(max);


UPDATE   MD_MainCurrency SET	DeletedAt=GETDATE()
						WHERE ID=@MainCurrencyID

SET @ReturnStatus='0,Main Currency Removed Successfull '  
 
	SELECT @ReturnStatus  AS ReturnStatus
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_DELETE_User]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_DELETE_User]
	@UserID INT

AS
BEGIN
DECLARE @ReturnStatus varchar(max);


UPDATE   AUT_User SET	DeletedAt=GETDATE()
						WHERE ID=@UserID

SET @ReturnStatus='0,User Removed Successfull '  
 
	SELECT @ReturnStatus  AS ReturnStatus
END

GO
/****** Object:  StoredProcedure [dbo].[SP_MD_GET_Currency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_GET_Currency]
	@ID INT

AS
BEGIN
DECLARE @b_ID int
if(@ID = 0)
      set @b_ID = 0
else
      set @b_ID = 1
 
SELECT ID,Currency,CurrencyDescription FROM MD_Currency WHERE   DeletedAt='' AND (@b_ID=0 OR(@b_ID=1 AND ID=@ID))
 
END

 
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_GET_CurrencyRate]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_GET_CurrencyRate]
	@ID INT,
	@Type NVARCHAR(50)

AS
BEGIN
DECLARE @b_ID int
if(@Type = 'Currency')
      set @b_ID = 1
else if (@Type = 'MainCurrency')
      set @b_ID = 2
else if (@Type = 'ID')
      set @b_ID = 3
else
  set @b_ID = 0

SELECT TD_CurrencyRate.ID ,CurrencyID,MD_Currency.Currency,MD_Currency.CurrencyDescription,
MainCurrencyID,MD_MainCurrency.MainCurrency,MD_MainCurrency.MainCurrencyDescription
,Rate FROM TD_CurrencyRate
INNER JOIN  MD_Currency ON MD_Currency.ID=TD_CurrencyRate.CurrencyID
INNER JOIN  MD_MainCurrency ON MD_MainCurrency.ID=TD_CurrencyRate.MainCurrencyID
 WHERE  @b_ID=0 
 OR(@b_ID=3 AND TD_CurrencyRate.ID=@ID)
  OR(@b_ID=1 AND CurrencyID=@ID)  
  OR (@b_ID=2 AND MainCurrencyID=@ID)
 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_GET_MainCurrency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[SP_MD_GET_MainCurrency]
	@ID INT

AS
BEGIN
DECLARE @b_ID int
if(@ID = 0)
      set @b_ID = 0
else
      set @b_ID = 1

SELECT ID,MainCurrency,MainCurrencyDescription FROM MD_MainCurrency WHERE @b_ID=0 OR(@b_ID=1 AND ID=@ID)
 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_GET_OrderDetails]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[SP_MD_GET_OrderDetails]
	@ID INT,
	@Type NVARCHAR(10)

AS
BEGIN
DECLARE @b_ID int
if(@Type = 'ID')
      set @b_ID = 1
else if(@Type = 'User')
  set @b_ID = 2
else  
  set @b_ID = 0
 
 SELECT TD_Order.ID,TD_Order.UserID,AUT_User.UserName, TD_Order.CurrencyID, MD_Currency.Currency,MD_Currency.CurrencyDescription,
 TD_Order.ReceivedAmount,TD_Order.CurrencyRate,TD_Order.ReceivedAmount,TD_Order.ConvertedAmount,TD_Order.CreatedAt
 FROM  TD_Order 
 INNER JOIN  MD_Currency ON MD_Currency.ID=TD_Order.CurrencyID
 INNER JOIN  AUT_User ON TD_Order.UserID=AUT_User.ID
 WHERE  @b_ID=0 OR(@b_ID=2 AND TD_Order.UserID=@ID) OR(@b_ID=1 AND TD_Order.ID=@ID)  

END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_GET_User]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_GET_User]
	@ID INT

AS
BEGIN
DECLARE @b_ID int
if(@ID = 0)
      set @b_ID = 0
else
      set @b_ID = 1

SELECT ID,UserName,Email FROM AUT_User WHERE DeletedAt='' AND (@b_ID=0 OR(@b_ID=1 AND ID=@ID))
 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_GET_UserByUserName]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MD_GET_UserByUserName]
	@UseraName Nvarchar(50)

AS
BEGIN
 
SELECT ID,UserName,Email,Password,EncryptedPassword FROM AUT_User WHERE UPPER(UserName)=UPPER(LTRIM(RTRIM(@UseraName)))


END

GO
/****** Object:  StoredProcedure [dbo].[SP_MD_UPDATE_Currency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[SP_MD_UPDATE_Currency]
	@CurrencyID INT,
	@Currency varchar(20),
	@CurrencyDescription varchar(100),
	@CreatedBy INT
AS
BEGIN
DECLARE @ReturnStatus varchar(max);


UPDATE   MD_Currency SET	Currency=@Currency,
							CurrencyDescription=@CurrencyDescription, 
							ModifiedBy=@CreatedBy,
							ModifiedAt=GETDATE()
						WHERE ID=@CurrencyID

SET @ReturnStatus='0,Currency Updated Successfull '  
 
	SELECT @ReturnStatus  AS ReturnStatus
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MD_UPDATE_MainCurrency]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 -----------------
CREATE PROCEDURE [dbo].[SP_MD_UPDATE_MainCurrency]
	@MainCurrencyID INT,
	@MainCurrency varchar(20),
	@MainCurrencyDescription varchar(100),
	@CreatedBy INT
AS
BEGIN
DECLARE @ReturnStatus varchar(max);


UPDATE   MD_MainCurrency SET	MainCurrency=@MainCurrency,
							MainCurrencyDescription=@MainCurrencyDescription, 
							ModifiedBy=@CreatedBy,
							ModifiedAt=GETDATE()
						WHERE ID=@MainCurrencyID

SET @ReturnStatus='0,Main Currency Updated Successfull '  
 
	SELECT @ReturnStatus  AS ReturnStatus
END

GO
/****** Object:  StoredProcedure [dbo].[SP_MD_UPDATE_User]    Script Date: 4/28/2021 2:19:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[SP_MD_UPDATE_User]
	@UserID INT,
	@Email varchar(MAX),
	@Password  varchar(MAX),
	@EncryptedPassword  varchar(MAX),
	@CreatedBy INT
AS
BEGIN
DECLARE @ReturnStatus varchar(max);


UPDATE   AUT_User SET	Email=@Email,
						Password=@Password,
						EncryptedPassword=@EncryptedPassword,
						ModifiedBy=@CreatedBy,
						ModifiedAt=GETDATE()
						WHERE ID=@UserID

SET @ReturnStatus='0,User Updated Successfull '  
 
	SELECT @ReturnStatus  AS ReturnStatus
END

GO
USE [master]
GO
ALTER DATABASE [Crypto_UAT] SET  READ_WRITE 
GO
