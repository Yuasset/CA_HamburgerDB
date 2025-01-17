USE [master]
GO
/****** Object:  Database [Hamburger]    Script Date: 1.09.2024 12:34:45 ******/
CREATE DATABASE [Hamburger]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hamburger', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Hamburger.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hamburger_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Hamburger_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Hamburger] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hamburger].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hamburger] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hamburger] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hamburger] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hamburger] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hamburger] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hamburger] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hamburger] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hamburger] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hamburger] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hamburger] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hamburger] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hamburger] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hamburger] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hamburger] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hamburger] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hamburger] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hamburger] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hamburger] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hamburger] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hamburger] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hamburger] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hamburger] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hamburger] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hamburger] SET  MULTI_USER 
GO
ALTER DATABASE [Hamburger] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hamburger] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hamburger] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hamburger] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hamburger] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hamburger] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Hamburger] SET QUERY_STORE = ON
GO
ALTER DATABASE [Hamburger] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Hamburger]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1.09.2024 12:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nchar](120) NOT NULL,
	[Lastname] [nchar](120) NOT NULL,
	[Adress] [nchar](255) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extras]    Script Date: 1.09.2024 12:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extras](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](120) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Extra] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hamburgers]    Script Date: 1.09.2024 12:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hamburgers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](120) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Hamburger] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1.09.2024 12:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[HamburgerID] [int] NOT NULL,
	[ExtraID] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[CustomerID] ASC,
	[HamburgerID] ASC,
	[ExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [Firstname], [Lastname], [Adress]) VALUES (1, N'Yuşa Çağatay                                                                                                            ', N'Günaydın                                                                                                                ', N'Belirtilmedi                                                                                                                                                                                                                                                   ')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Extras] ON 

INSERT [dbo].[Extras] ([ID], [Name], [Price]) VALUES (1, N'Ketçap                                                                                                                  ', 3.0000)
SET IDENTITY_INSERT [dbo].[Extras] OFF
GO
SET IDENTITY_INSERT [dbo].[Hamburgers] ON 

INSERT [dbo].[Hamburgers] ([ID], [Name], [Price]) VALUES (1, N'Big-Mach                                                                                                                ', 180.0000)
SET IDENTITY_INSERT [dbo].[Hamburgers] OFF
GO
INSERT [dbo].[Orders] ([ID], [CustomerID], [HamburgerID], [ExtraID]) VALUES (0, 1, 1, 1)
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Extras] FOREIGN KEY([ExtraID])
REFERENCES [dbo].[Extras] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Extras]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Hamburgers] FOREIGN KEY([HamburgerID])
REFERENCES [dbo].[Hamburgers] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Hamburgers]
GO
USE [master]
GO
ALTER DATABASE [Hamburger] SET  READ_WRITE 
GO
