--USE [master]
--GO
--/****** Object:  Database [StudentResultManagementSystem]    Script Date: 7/2/2024 5:02:31 PM ******/
--CREATE DATABASE [StudentResultManagementSystem] ON  PRIMARY 
--( NAME = N'StudentResultManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StudentResultManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'StudentResultManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StudentResultManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO
--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [StudentResultManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET RECOVERY SIMPLE 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET  MULTI_USER 
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET DB_CHAINING OFF 
--GO
--USE [StudentResultManagementSystem]
--GO
--/****** Object:  Table [dbo].[Tbl_Course]    Script Date: 7/2/2024 5:02:32 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Tbl_Course](
--	[CourseId] [int] IDENTITY(1,1) NOT NULL,
--	[CourseName] [nvarchar](100) NULL,
--	[Duration] [nvarchar](50) NULL,
--	[Charges] [decimal](18, 2) NULL,
--	[Description] [nvarchar](255) NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[CourseId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[Tbl_Result]    Script Date: 7/2/2024 5:02:32 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Tbl_Result](
--	[ResultId] [int] IDENTITY(1,1) NOT NULL,
--	[Score] [decimal](18, 2) NULL,
--	[Status] [int] NULL,
--	[StudentId] [int] NULL,
--	[CourseId] [int] NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[ResultId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[Tbl_Student]    Script Date: 7/2/2024 5:02:32 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Tbl_Student](
--	[StudentId] [int] IDENTITY(1,1) NOT NULL,
--	[RollNo] [int] NOT NULL,
--	[Name] [nvarchar](100) NOT NULL,
--	[GenderStatus] [int] NULL,
--	[Age] [int] NULL,
--	[DateOfBirth] [date] NULL,
--	[UserName] [nvarchar](50) NULL,
--	[Password] [nvarchar](50) NULL,
--	[PhoneNumber] [nvarchar](20) NULL,
--	[Address] [nvarchar](200) NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[StudentId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[Tbl_StudentCourse]    Script Date: 7/2/2024 5:02:32 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Tbl_StudentCourse](
--	[StudentId] [int] NOT NULL,
--	[CourseId] [int] NOT NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[StudentId] ASC,
--	[CourseId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--SET IDENTITY_INSERT [dbo].[Tbl_Course] ON 

--INSERT [dbo].[Tbl_Course] ([CourseId], [CourseName], [Duration], [Charges], [Description]) VALUES (1, N'Mathematics', N'3 Months', CAST(150.00 AS Decimal(18, 2)), N'Basic Mathematics Course')
--INSERT [dbo].[Tbl_Course] ([CourseId], [CourseName], [Duration], [Charges], [Description]) VALUES (2, N'Science', N'6 Months', CAST(300.00 AS Decimal(18, 2)), N'Comprehensive Science Course')
--INSERT [dbo].[Tbl_Course] ([CourseId], [CourseName], [Duration], [Charges], [Description]) VALUES (3, N'History', N'4 Months', CAST(200.00 AS Decimal(18, 2)), N'World History Course')
--SET IDENTITY_INSERT [dbo].[Tbl_Course] OFF
--GO
--SET IDENTITY_INSERT [dbo].[Tbl_Result] ON 

--INSERT [dbo].[Tbl_Result] ([ResultId], [Score], [Status], [StudentId], [CourseId]) VALUES (1, CAST(85.50 AS Decimal(18, 2)), 1, 1, 1)
--INSERT [dbo].[Tbl_Result] ([ResultId], [Score], [Status], [StudentId], [CourseId]) VALUES (2, CAST(90.00 AS Decimal(18, 2)), 1, 1, 2)
--INSERT [dbo].[Tbl_Result] ([ResultId], [Score], [Status], [StudentId], [CourseId]) VALUES (3, CAST(75.00 AS Decimal(18, 2)), 2, 2, 1)
--SET IDENTITY_INSERT [dbo].[Tbl_Result] OFF
--GO
--SET IDENTITY_INSERT [dbo].[Tbl_Student] ON 

--INSERT [dbo].[Tbl_Student] ([StudentId], [RollNo], [Name], [GenderStatus], [Age], [DateOfBirth], [UserName], [Password], [PhoneNumber], [Address]) VALUES (1, 1, N'John Doe', 1, 20, CAST(N'2003-05-15' AS Date), N'johndoe', N'password123', N'123-456-7890', N'123 Main St')
--INSERT [dbo].[Tbl_Student] ([StudentId], [RollNo], [Name], [GenderStatus], [Age], [DateOfBirth], [UserName], [Password], [PhoneNumber], [Address]) VALUES (2, 2, N'Jane Smith', 2, 22, CAST(N'2001-07-20' AS Date), N'janesmith', N'password123', N'987-654-3210', N'456 Elm St')
--SET IDENTITY_INSERT [dbo].[Tbl_Student] OFF
--GO
--INSERT [dbo].[Tbl_StudentCourse] ([StudentId], [CourseId]) VALUES (1, 1)
--INSERT [dbo].[Tbl_StudentCourse] ([StudentId], [CourseId]) VALUES (1, 2)
--INSERT [dbo].[Tbl_StudentCourse] ([StudentId], [CourseId]) VALUES (2, 1)
--GO
--ALTER TABLE [dbo].[Tbl_Result]  WITH CHECK ADD FOREIGN KEY([CourseId])
--REFERENCES [dbo].[Tbl_Course] ([CourseId])
--GO
--ALTER TABLE [dbo].[Tbl_Result]  WITH CHECK ADD FOREIGN KEY([StudentId])
--REFERENCES [dbo].[Tbl_Student] ([StudentId])
--GO
--ALTER TABLE [dbo].[Tbl_StudentCourse]  WITH CHECK ADD FOREIGN KEY([CourseId])
--REFERENCES [dbo].[Tbl_Course] ([CourseId])
--GO
--ALTER TABLE [dbo].[Tbl_StudentCourse]  WITH CHECK ADD FOREIGN KEY([StudentId])
--REFERENCES [dbo].[Tbl_Student] ([StudentId])
--GO
--USE [master]
--GO
--ALTER DATABASE [StudentResultManagementSystem] SET  READ_WRITE 
--GO
