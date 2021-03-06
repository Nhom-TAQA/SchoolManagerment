USE [master]
GO
/****** Object:  Database [QuanLyTruongHoc]    Script Date: 10/11/2020 7:03:06 AM ******/
CREATE DATABASE [QuanLyTruongHoc]
GO
USE [QuanLyTruongHoc]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassCode] [varchar](20) NOT NULL,
	[Type] [bit] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomeroomTeacher]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeroomTeacher](
	[ClassCode] [varchar](20) NOT NULL,
	[TeacherCode] [int] NOT NULL,
	[SchoolYear] [varchar](10) NULL,
 CONSTRAINT [PK_HomeroomTeacher] PRIMARY KEY CLUSTERED 
(
	[ClassCode] ASC,
	[TeacherCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentCode] [int] NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [bit] NULL,
	[Address] [nvarchar](200) NULL,
	[Avatar] [image] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentInClass]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentInClass](
	[StudentCode] [int] NOT NULL,
	[ClassCode] [varchar](20) NOT NULL,
	[SchoolYear] [varchar](10) NULL,
 CONSTRAINT [PK_StudentInClass] PRIMARY KEY CLUSTERED 
(
	[StudentCode] ASC,
	[ClassCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherCode] [int] NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [bit] NULL,
	[Address] [nvarchar](200) NULL,
	[Avatar] [image] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[HomeroomTeacher]  WITH CHECK ADD  CONSTRAINT [FK_HomeroomTeacher_Class] FOREIGN KEY([ClassCode])
REFERENCES [dbo].[Class] ([ClassCode])
GO
ALTER TABLE [dbo].[HomeroomTeacher] CHECK CONSTRAINT [FK_HomeroomTeacher_Class]
GO
ALTER TABLE [dbo].[HomeroomTeacher]  WITH CHECK ADD  CONSTRAINT [FK_HomeroomTeacher_Teacher] FOREIGN KEY([TeacherCode])
REFERENCES [dbo].[Teacher] ([TeacherCode])
GO
ALTER TABLE [dbo].[HomeroomTeacher] CHECK CONSTRAINT [FK_HomeroomTeacher_Teacher]
GO
ALTER TABLE [dbo].[StudentInClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentInClass_Class] FOREIGN KEY([ClassCode])
REFERENCES [dbo].[Class] ([ClassCode])
GO
ALTER TABLE [dbo].[StudentInClass] CHECK CONSTRAINT [FK_StudentInClass_Class]
GO
ALTER TABLE [dbo].[StudentInClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentInClass_Student] FOREIGN KEY([StudentCode])
REFERENCES [dbo].[Student] ([StudentCode])
GO
ALTER TABLE [dbo].[StudentInClass] CHECK CONSTRAINT [FK_StudentInClass_Student]
GO
/****** Object:  StoredProcedure [dbo].[AccountDelete]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AccountDelete]
@id int
as 
delete Account where id=@id
GO
/****** Object:  StoredProcedure [dbo].[AccountInsert]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AccountInsert]
@username varchar(50),
@password varchar(50)
as 
insert into Account
(username, password)
values
(@username, @password)
GO
/****** Object:  StoredProcedure [dbo].[AccountSelectAll]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AccountSelectAll]
as
select * from Account
GO
/****** Object:  StoredProcedure [dbo].[AccountUpdate]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AccountUpdate]
@id int,
@username varchar(50),
@password varchar(50)
as 
update Account set [password]=@password
where id=@id and username=@username
GO
/****** Object:  StoredProcedure [dbo].[ClassDelete]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ClassDelete]
@ClassCode varchar(20)
as
delete Class where ClassCode=@ClassCode
GO
/****** Object:  StoredProcedure [dbo].[ClassInsert]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[ClassInsert]
@ClassCode varchar(20),
@Type bit
as
insert into Class
values(@ClassCode, @Type)
GO
/****** Object:  StoredProcedure [dbo].[ClassSelectAll]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ClassSelectAll]
as
select * from Class
GO
/****** Object:  StoredProcedure [dbo].[HomeroomTeacherDelete]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[HomeroomTeacherDelete]
@ClassCode varchar(20),
@TeacherCode int
as
delete HomeroomTeacher where ClassCode=@ClassCode and TeacherCode=@TeacherCode
GO
/****** Object:  StoredProcedure [dbo].[HomeroomTeacherInsert]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[HomeroomTeacherInsert]
@ClassCode varchar(20),
@TeacherCode int,
@SchoolYear varchar(10)
as
insert into HomeroomTeacher
values(@ClassCode, @TeacherCode, @SchoolYear)
GO
/****** Object:  StoredProcedure [dbo].[HomeroomTeacherSelectAll]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[HomeroomTeacherSelectAll]
as
select * from HomeroomTeacher
GO
/****** Object:  StoredProcedure [dbo].[StudentDelete]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[StudentDelete]
@StudentCode int
as
delete Student where StudentCode=@StudentCode
GO
/****** Object:  StoredProcedure [dbo].[StudentInClassDelete]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[StudentInClassDelete]
@StudentCode int,
@ClassCode varchar(20)
as
delete StudentInClass where StudentCode=@StudentCode and ClassCode=@ClassCode
GO
/****** Object:  StoredProcedure [dbo].[StudentInClassInsert]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[StudentInClassInsert]
@StudentCode int,
@ClassCode varchar(20),
@SchoolYear varchar(10)
as
insert into StudentInClass
values(@StudentCode, @ClassCode, @SchoolYear)
GO
/****** Object:  StoredProcedure [dbo].[StudentInClassSelectAll]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[StudentInClassSelectAll]
as
select * from StudentInClass
GO
/****** Object:  StoredProcedure [dbo].[StudentInsert]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[StudentInsert]
@StudentCode int,
@FullName nvarchar(50),
@DateOfBirth date,
@Sex bit,
@Address nvarchar(200),
@Avatar image
as
insert into Student(StudentCode, FullName, DateOfBirth, Sex, [Address], Avatar)
values(@StudentCode, @FullName, @DateOfBirth, @Sex, @Address, @Avatar)
GO
/****** Object:  StoredProcedure [dbo].[StudentSelectAll]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[StudentSelectAll]
as
select * from Student
GO
/****** Object:  StoredProcedure [dbo].[StudentUpdate]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[StudentUpdate]
@StudentCode int,
@FullName nvarchar(50),
@DateOfBirth date,
@Sex bit,
@Address nvarchar(200),
@Avatar image
as
update Student set FullName=@FullName, DateOfBirth=@DateOfBirth, Sex=@Sex, [Address]=@Address, Avatar=@Avatar
where StudentCode=@StudentCode
GO
/****** Object:  StoredProcedure [dbo].[TeacherDelete]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TeacherDelete]
@TeacherCode int
as
delete Teacher where TeacherCode=@TeacherCode
GO
/****** Object:  StoredProcedure [dbo].[TeacherInsert]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TeacherInsert]
@TeacherCode int,
@FullName nvarchar(50),
@DateOfBirth date,
@Sex bit,
@Address nvarchar(200),
@Avatar image
as
insert into Teacher(TeacherCode, FullName, DateOfBirth, Sex, [Address], Avatar)
values(@TeacherCode, @FullName, @DateOfBirth, @Sex, @Address, @Avatar)
GO
/****** Object:  StoredProcedure [dbo].[TeacherSelectAll]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[TeacherSelectAll]
as
select * from Teacher
GO
/****** Object:  StoredProcedure [dbo].[TeacherUpdate]    Script Date: 10/11/2020 7:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TeacherUpdate]
@TeacherCode int,
@FullName nvarchar(50),
@DateOfBirth date,
@Sex bit,
@Address nvarchar(200),
@Avatar image
as
update Teacher set FullName=@FullName, DateOfBirth=@DateOfBirth, Sex=@Sex, [Address]=@Address, Avatar=@Avatar
where TeacherCode=@TeacherCode
GO
USE [master]
GO
ALTER DATABASE [QuanLyTruongHoc] SET  READ_WRITE 
GO
