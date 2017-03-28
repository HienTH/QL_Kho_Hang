USE [master]
GO
/****** Object:  Database [QL_KhoHang]    Script Date: 2017-02-18 8:40:45 AM ******/
CREATE DATABASE [QL_KhoHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_KhoHang', FILENAME = N'D:\1-Study\4-HK6\ThucTapNhom\QL_KhoHang.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_KhoHang_log', FILENAME = N'D:\1-Study\4-HK6\ThucTapNhom\QL_KhoHang_log.ldf' , SIZE = 5120KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_KhoHang] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_KhoHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_KhoHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_KhoHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_KhoHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_KhoHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_KhoHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_KhoHang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QL_KhoHang] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_KhoHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_KhoHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_KhoHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_KhoHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_KhoHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_KhoHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_KhoHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_KhoHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_KhoHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_KhoHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_KhoHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_KhoHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_KhoHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_KhoHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_KhoHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_KhoHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_KhoHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_KhoHang] SET  MULTI_USER 
GO
ALTER DATABASE [QL_KhoHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_KhoHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_KhoHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_KhoHang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_KhoHang]
GO
/****** Object:  StoredProcedure [dbo].[ThemCTPN]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemCTPN] @mapn varchar(10), @mahh varchar(10), @soluong int, @dongia float, @thanhtien float
AS
BEGIN
INSERT INTO CHITIETPHIEUNHAP(MaPN, MaHH, SoLuong, DonGia, ThanhTien) values (@mapn, @mahh, @soluong, @dongia, @thanhtien)
END


GO
/****** Object:  StoredProcedure [dbo].[ThemHH]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemHH] @tenhh nvarchar(50), @soluong int, @gianhap bigint, @giaxuat bigint, @nsx nvarchar(50), @thongtin text
AS
BEGIN
DECLARE @MaHH varchar(10)
DECLARE @Sott int
DECLARE contro CURSOR FORWARD_ONLY FOR SELECT MaHH from HANGHOA
SET @Sott = 0

OPEN contro
FETCH NEXT FROM contro INTO @MaHH
WHILE(@@FETCH_STATUS = 0)
BEGIN
	IF((CAST(right(@MaHH, 8) AS int) - @sott) = 1)
		BEGIN
			SET @Sott = CAST(right(@MaHH, 8) AS int)
		END
	ELSE BREAK
	FETCH NEXT FROM contro INTO @MaHH
END

DECLARE @cdai int
DECLARE @i int
SET @MaHH = CAST((@sott + 1) as varchar(8))
SET @cdai = LEN(@MaHH)
SET @i = 1
while ( @i <= 8 - @cdai)
BEGIN
	SET @MaHH = '0' + @MaHH
	SET @i = @i + 1
END
SET @MaHH = 'HH' + @MaHH

INSERT INTO HANGHOA(MaHH, TenHH, SoLuong, GiaNhap, GiaXuat, NSX, ThongTin) values ( @MaHH, @tenhh, @soluong, @gianhap, @giaxuat, @nsx, @thongtin)
SELECT @MaHH
CLOSE contro
DEALLOCATE contro
END


GO
/****** Object:  StoredProcedure [dbo].[ThemPN]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemPN] @mancc varchar(10), @ngaynhap date
AS
BEGIN
DECLARE @MaPN varchar(10)
DECLARE @Sott int
DECLARE contro CURSOR FORWARD_ONLY FOR SELECT MaPN from PHIEUNHAP
SET @Sott = 0

OPEN contro
FETCH NEXT FROM contro INTO @MaPN
WHILE(@@FETCH_STATUS = 0)
BEGIN
	IF((CAST(right(@MaPN, 8) AS int) - @sott) = 1)
		BEGIN
			SET @Sott = @Sott + 1
		END
	ELSE BREAK
	FETCH NEXT FROM contro INTO @MaPN
END
DECLARE @cdai int
DECLARE @i int
SET @MaPN = CAST((@sott + 1) as varchar(8))
SET @cdai = LEN(@MaPN)
SET @i = 1
while ( @i <= 8 - @cdai)
BEGIN
	SET @MaPN = '0' + @MaPN
	SET @i = @i + 1
END
SET @MaPN = 'PN' + @MaPN

INSERT INTO PHIEUNHAP(MaPN, MaNCC, NgayNhap) values (@MaPN, @mancc, @ngaynhap)
SELECT @MaPN
CLOSE contro
DEALLOCATE contro
END


GO
/****** Object:  Table [dbo].[CHINHANH]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHINHANH](
	[MaCN] [varchar](10) NOT NULL,
	[TenCN] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](20) NULL,
 CONSTRAINT [PK_CHINHANH] PRIMARY KEY CLUSTERED 
(
	[MaCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETPHIEUNHAP]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUNHAP](
	[MaPN] [varchar](10) NOT NULL,
	[MaHH] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CHITIETPHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETPHIEUXUAT]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUXUAT](
	[MaPX] [varchar](10) NOT NULL,
	[MaHH] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CHITIETPHIEUXUAT] PRIMARY KEY CLUSTERED 
(
	[MaPX] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HANGHOA]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HANGHOA](
	[MaHH] [varchar](10) NOT NULL,
	[TenHH] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [float] NULL,
	[NSX] [nvarchar](50) NULL,
	[ThongTin] [ntext] NULL,
 CONSTRAINT [PK_HANGHOA] PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNCC] [varchar](10) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](20) NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MaPN] [varchar](10) NOT NULL,
	[MaNCC] [varchar](10) NOT NULL,
	[NgayNhap] [date] NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_PHIEUNHAP_1] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEUXUAT]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHIEUXUAT](
	[MaPX] [varchar](10) NOT NULL,
	[MaCN] [varchar](10) NOT NULL,
	[NgayXuat] [date] NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_PHIEUXUAT_1] PRIMARY KEY CLUSTERED 
(
	[MaPX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERR]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERR](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Quyen] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[THH]    Script Date: 2017-02-18 8:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[THH] as select MaHH from CHITIETPHIEUNHAP where MaPN='PN008'

GO
INSERT [dbo].[CHINHANH] ([MaCN], [TenCN], [DiaChi], [SDT]) VALUES (N'CN001', N'Thinh_HN', N'Ha Noi', N'04656334')
INSERT [dbo].[CHINHANH] ([MaCN], [TenCN], [DiaChi], [SDT]) VALUES (N'CN003', N'Lê Đà Nẵng', N'Da Nang', N'02765635')
INSERT [dbo].[CHINHANH] ([MaCN], [TenCN], [DiaChi], [SDT]) VALUES (N'CN004', N'Hiệp đẹp zai', N'hà nội', N'0909090909')
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN001', N'HH00000001', 80, 12390, 991200)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN001', N'HH00000002', 90, 12500, 1125000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN002', N'HH00000003', 100, 13500, 1350000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN002', N'HH00000004', 100, 15500, 1550000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN003', N'HH00000005', 120, 14500, 1740000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN003', N'HH00000006', 80, 15500, 1240000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN004', N'HH00000007', 40, 20500, 820000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN004', N'HH00000008', 50, 21500, 1075000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN004', N'HH00000009', 60, 30500, 1830000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN005', N'HH00000010', 2, 30000, 60000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([MaPN], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PN006', N'HH00000011', 1, 20000, 20000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX001', N'HH00000001', 20, 14500, NULL)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX002', N'HH00000001', 20, 14500, NULL)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX003', N'HH00000001', 20, 14500, NULL)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX005', N'HH00000001', 10, 12390, 136290)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX005', N'HH00000002', 20, 12500, 275000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX007', N'HH00000005', 10, 14500, 159500)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX007', N'HH00000006', 10, 15000, 165000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX007', N'HH00000009', 20, 30500, 671000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX007', N'HH00000010', 10, 30000, 330000)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX008', N'HH00000001', 30, 12390, 408870)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX008', N'HH00000002', 10, 12500, 137500)
INSERT [dbo].[CHITIETPHIEUXUAT] ([MaPX], [MaHH], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'PX008', N'HH00000004', 20, 15500, 341000)
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000001', N'Dell Inspiron 14 3443 70055103 Black', 70, 12390, N'DELL', N'CPU Intel Core i5-5200U Broadwell (2.2Ghz upto 2.7Ghz, 3MB Cache L3)/ Ram 4GB Buss 1600Mhz')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000002', N'Dell Inspiron 15', 90, 12500, N'DELL', N'CPU Intel Core i5-5200U Broadwell (2.2Ghz upto 2.7Ghz, 3MB Cache L3)/ Ram 4GB  HDD 1TB ')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000003', N'Dell Inspiron 16', 100, 13500, N'DELL', N'CPU Intel Core i5-5200U Broadwell (2.2Ghz upto 2.7Ghz, 3MB Cache L3)/ Ram 4GB Buss 1600Mhz/ HDD 1TB ')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000004', N'Asus P450L', 80, 15500, N'ASUS', N'Ram 4GB')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000005', N'Asus P550L', 90, 14500, N'ASUS', N'Ram 6GB')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000006', N'Asus P650L', 90, 15000, N'ASUS', N'Ram 8GB')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000007', N'HP Lite 80', 100, 20500, N'HP', N'BackLight')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000008', N'HP Lite 90', 100, 21500, N'HP', N'Sensor')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000009', N'Gaming', 80, 30500, N'LMHT', N'Game')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000010', N'Gaming2', 90, 30000, N'lmht', N'Nhanh')
INSERT [dbo].[HANGHOA] ([MaHH], [TenHH], [SoLuong], [GiaNhap], [NSX], [ThongTin]) VALUES (N'HH00000011', N'xxxp', 100, 20000, N'áa', N'sdsd')
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NCC001', N'Định HN', N'Ha Noi', N'04872625')
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NCC002', N'Công HCM', N'TPHCM', N'08123576')
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NCC003', N'Thành  DN', N'Da Nang', N'06876976')
INSERT [dbo].[PHIEUNHAP] ([MaPN], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'PN001', N'NCC001', CAST(0x083C0B00 AS Date), 2116200)
INSERT [dbo].[PHIEUNHAP] ([MaPN], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'PN002', N'NCC001', CAST(0xE23B0B00 AS Date), 2900000)
INSERT [dbo].[PHIEUNHAP] ([MaPN], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'PN003', N'NCC002', CAST(0xE23B0B00 AS Date), 2980000)
INSERT [dbo].[PHIEUNHAP] ([MaPN], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'PN004', N'NCC003', CAST(0xE93B0B00 AS Date), 3725000)
INSERT [dbo].[PHIEUNHAP] ([MaPN], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'PN005', N'NCC002', CAST(0x1A3C0B00 AS Date), 60000)
INSERT [dbo].[PHIEUNHAP] ([MaPN], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'PN006', N'NCC002', CAST(0x1D3C0B00 AS Date), 20000)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX001', N'CN001', CAST(0x0D3C0B00 AS Date), NULL)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX002', N'CN001', CAST(0x0F3C0B00 AS Date), NULL)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX003', N'CN003', CAST(0x0F3C0B00 AS Date), NULL)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX004', N'CN001', CAST(0x223C0B00 AS Date), 786500)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX005', N'CN001', CAST(0x223C0B00 AS Date), 411290)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX006', N'CN001', CAST(0x223C0B00 AS Date), 1386000)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX007', N'CN004', CAST(0x223C0B00 AS Date), 1325500)
INSERT [dbo].[PHIEUXUAT] ([MaPX], [MaCN], [NgayXuat], [TongTien]) VALUES (N'PX008', N'CN003', CAST(0x223C0B00 AS Date), 887370)
INSERT [dbo].[USERR] ([Username], [Password], [Quyen]) VALUES (N'admin', N'admin', 1)
INSERT [dbo].[USERR] ([Username], [Password], [Quyen]) VALUES (N'admin2', N'admin2', 1)
INSERT [dbo].[USERR] ([Username], [Password], [Quyen]) VALUES (N'user1', N'12345', 0)
INSERT [dbo].[USERR] ([Username], [Password], [Quyen]) VALUES (N'user2', N'12345', 0)
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP_HANGHOA] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HANGHOA] ([MaHH])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP_HANGHOA]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP_PHIEUNHAP] FOREIGN KEY([MaPN])
REFERENCES [dbo].[PHIEUNHAP] ([MaPN])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP_PHIEUNHAP]
GO
ALTER TABLE [dbo].[CHITIETPHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUXUAT_HANGHOA] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HANGHOA] ([MaHH])
GO
ALTER TABLE [dbo].[CHITIETPHIEUXUAT] CHECK CONSTRAINT [FK_CHITIETPHIEUXUAT_HANGHOA]
GO
ALTER TABLE [dbo].[CHITIETPHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUXUAT_PHIEUXUAT] FOREIGN KEY([MaPX])
REFERENCES [dbo].[PHIEUXUAT] ([MaPX])
GO
ALTER TABLE [dbo].[CHITIETPHIEUXUAT] CHECK CONSTRAINT [FK_CHITIETPHIEUXUAT_PHIEUXUAT]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_NHACUNGCAP] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP_NHACUNGCAP]
GO
ALTER TABLE [dbo].[PHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_CHINHANH] FOREIGN KEY([MaCN])
REFERENCES [dbo].[CHINHANH] ([MaCN])
GO
ALTER TABLE [dbo].[PHIEUXUAT] CHECK CONSTRAINT [FK_PHIEUXUAT_CHINHANH]
GO
USE [master]
GO
ALTER DATABASE [QL_KhoHang] SET  READ_WRITE 
GO
