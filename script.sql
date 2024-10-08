USE [master]
GO
/****** Object:  Database [DbStokYonetim]    Script Date: 27.09.2024 01:52:49 ******/
CREATE DATABASE [DbStokYonetim]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbStokYonetim', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DbStokYonetim.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbStokYonetim_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DbStokYonetim_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DbStokYonetim] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbStokYonetim].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbStokYonetim] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbStokYonetim] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbStokYonetim] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbStokYonetim] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbStokYonetim] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbStokYonetim] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbStokYonetim] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbStokYonetim] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbStokYonetim] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbStokYonetim] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbStokYonetim] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbStokYonetim] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbStokYonetim] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbStokYonetim] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbStokYonetim] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DbStokYonetim] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbStokYonetim] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbStokYonetim] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbStokYonetim] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbStokYonetim] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbStokYonetim] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbStokYonetim] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbStokYonetim] SET RECOVERY FULL 
GO
ALTER DATABASE [DbStokYonetim] SET  MULTI_USER 
GO
ALTER DATABASE [DbStokYonetim] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbStokYonetim] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbStokYonetim] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbStokYonetim] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbStokYonetim] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbStokYonetim] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DbStokYonetim', N'ON'
GO
ALTER DATABASE [DbStokYonetim] SET QUERY_STORE = ON
GO
ALTER DATABASE [DbStokYonetim] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DbStokYonetim]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27.09.2024 01:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceHistory]    Script Date: 27.09.2024 01:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceHistory](
	[PriceHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OldPrice] [decimal](18, 2) NOT NULL,
	[NewPrice] [decimal](18, 2) NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PriceHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27.09.2024 01:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductPrice] [decimal](18, 2) NOT NULL,
	[MinimumStockLevel] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMovements]    Script Date: 27.09.2024 01:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMovements](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[MovementType] [nvarchar](20) NOT NULL,
	[Quantity] [int] NOT NULL,
	[MovementDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Stoper ')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Bağucu')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'Kordon ')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (4, N'Kuşgözü')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (5, N'test')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (6, N'deneme')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (7, N'kalem')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[PriceHistory] ON 

INSERT [dbo].[PriceHistory] ([PriceHistoryId], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (1, 4, CAST(15.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(N'2024-09-27T00:00:00.000' AS DateTime))
INSERT [dbo].[PriceHistory] ([PriceHistoryId], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (2, 4, CAST(20.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(N'2024-09-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PriceHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductPrice], [MinimumStockLevel], [CategoryId]) VALUES (2, N'kalem', CAST(10.00 AS Decimal(18, 2)), 50, 6)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductPrice], [MinimumStockLevel], [CategoryId]) VALUES (3, N'kalem', CAST(10.00 AS Decimal(18, 2)), 50, 6)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductPrice], [MinimumStockLevel], [CategoryId]) VALUES (4, N'uclu kalem', CAST(15.00 AS Decimal(18, 2)), 50, 7)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductPrice], [MinimumStockLevel], [CategoryId]) VALUES (5, N'uclu kalem', CAST(15.00 AS Decimal(18, 2)), 20, 7)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[StockMovements] ON 

INSERT [dbo].[StockMovements] ([StockId], [ProductId], [MovementType], [Quantity], [MovementDate]) VALUES (1, 4, N'giriş', 50, CAST(N'2024-09-14T00:00:00.000' AS DateTime))
INSERT [dbo].[StockMovements] ([StockId], [ProductId], [MovementType], [Quantity], [MovementDate]) VALUES (2, 4, N'çıkış', 60, CAST(N'2024-09-21T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[StockMovements] OFF
GO
ALTER TABLE [dbo].[PriceHistory]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[StockMovements]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
USE [master]
GO
ALTER DATABASE [DbStokYonetim] SET  READ_WRITE 
GO
