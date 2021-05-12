USE [QLKhachSan]

CREATE TABLE KHACHHANG (
	MaKH CHAR(6) PRIMARY KEY,
	HoTen NVARCHAR(50),
	NgaySinh DATE,
	GioiTinh NVARCHAR(5) CHECK (GioiTinh in (N'Nam', N'Nữ')),
)

CREATE TABLE PHONG (
	MaPhong CHAR(6) PRIMARY KEY,
	TenPhong VARCHAR(10),
	LoaiPhong NVARCHAR(50),
	GiaThue1Ngay INT
)

CREATE TABLE THUE(
	MaDK CHAR(6) PRIMARY KEY,
	MaKH CHAR(6) REFERENCES KHACHHANG(MaKH),
	MaPhong CHAR(6) REFERENCES PHONG(MaPhong),
	NgayDen DATE,
	NgayDi DATE
)

CREATE TABLE HOADON (
	MaHD CHAR(6) PRIMARY KEY,
	TongTien INT,
	MaKH CHAR(6) REFERENCES KHACHHANG(MaKH),
	MaPhong CHAR(6) REFERENCES PHONG(MaPhong)
)

CREATE TABLE VATDUNG(
	MaVatDung CHAR(6) PRIMARY KEY,
	TenVatDung NVARCHAR(50),
	GiaTienSuDung INT,
	MaPhong CHAR(6) REFERENCES PHONG(MaPhong)
)

CREATE TABLE HOADON_VATDUNG(
	MaHD CHAR(6) REFERENCES HOADON(MaHD),
	MaVatDung CHAR(6) REFERENCES VATDUNG(MaVatDung),
	SoLuong INT,
	TongTienSuDungVatDung INT,
	PRIMARY KEY (MaHD, MaVatDung)
)

CREATE TABLE DICHVU(
	MaDV CHAR(6) PRIMARY KEY,
	TenDV NVARCHAR(50),
	GiaSuDung INT
)

CREATE TABLE HOADON_DICHVU(
	MaHD CHAR(6) REFERENCES HOADON(MaHD),
	MaDV CHAR(6) REFERENCES DICHVU(MaDV),
	SoLanSuDungDichVu INT,
	TongTienSuDungDichVu INT,
	PRIMARY KEY(MaHD, MaDV)
)

--DROP TABLE HOADON_DICHVU
--DROP TABLE HOADON_VATDUNG
--DROP TABLE DICHVU
--DROP TABLE VATDUNG
--DROP TABLE HOADON
--DROP TABLE THUE
--DROP TABLE KHACHHANG
--DROP TABLE PHONG

INSERT INTO KHACHHANG VALUES
	('KH0001', N'Nguyễn Thị Thanh Tùng', '2000/11/03', N'Nữ'),
	('KH0002', N'Bùi Doãn Tú', '2000/08/25', N'Nam'),
	('KH0003', N'Nguyễn Minh Kiên', '2000/02/13', N'Nam'),
	('KH0004', N'Mạc Trung Lam', '2000/08/03', N'Nam'),
	('KH0005', N'Vũ Anh Hiếu', '2000/01/30', N'Nam'),
	('KH0006', N'Nguyễn Hoàng Hưng', '2000/12/12', N'Nam'),
	('KH0007', N'Bùi Thị Mỹ Hưng', '2000/06/25', N'Nữ'),
	('KH0008', N'Đỗ Thành Thằng Tùng', '2000/08/10', N'Nam'),
	('KH0009', N'Kiều Thị Như Kiên', '2000/02/29', N'Nam'),
	('KH0010', N'Đô Nan Lộc', '2000/03/15', N'Nam')

INSERT INTO PHONG VALUES
	('PH0001', 'P101', N'Vip Pro No 1', 700000),
	('PH0002', 'P102', N'Tình yêu', 1000000),
	('PH0003', 'P201', N'Chó Shiba', 500000),
	('PH0004', 'P202', N'Siêu cấp vũ trụ', 700000),
	('PH0005', 'P301', N'Top Server', 1700000)

INSERT INTO THUE VALUES
	('DK0001', 'KH0001', 'PH0002', '2021/03/08', '2021/03/21'),
	('DK0002', 'KH0002', 'PH0001', '2021/04/01', '2021/04/10'),
	('DK0003', 'KH0003', 'PH0002', '2021/02/08', '2021/02/12'),
	('DK0004', 'KH0004', 'PH0003', '2021/01/10', '2021/01/23'),
	('DK0005', 'KH0005', 'PH0004', '2021/03/14', '2021/03/24'),
	('DK0006', 'KH0006', 'PH0004', '2021/02/01', '2021/02/20'),
	('DK0007', 'KH0007', 'PH0003', '2021/03/04', '2021/03/11'),
	('DK0008', 'KH0008', 'PH0004', '2021/02/28', '2021/03/11'),
	('DK0009', 'KH0009', 'PH0005', '2021/01/05', '2021/01/26'),
	('DK0010', 'KH0010', 'PH0005', '2021/02/04', '2021/02/22')

INSERT INTO HOADON(MaHD, MaKH, MaPhong) VALUES
	('HD0001', 'KH0001', 'PH0002'),
	('HD0002', 'KH0002', 'PH0001'),
	('HD0003', 'KH0003', 'PH0002'),
	('HD0004', 'KH0004', 'PH0004'),
	('HD0005', 'KH0005', 'PH0003'),
	('HD0006', 'KH0006', 'PH0005'),
	('HD0007', 'KH0007', 'PH0001'),
	('HD0008', 'KH0008', 'PH0004'),
	('HD0009', 'KH0009', 'PH0003'),
	('HD0010', 'KH0010', 'PH0005')

INSERT INTO VATDUNG VALUES
	('VD0001', N'Tủ lạnh mini', 120000, 'PH0001'),
	('VD0002', N'Cô ca', 10000, 'PH0001'),
	('VD0003', N'Nước lọc', 6000, 'PH0002'),
	('VD0004', N'Bao cao su', 50000, 'PH0003'),
	('VD0005', N'Khăn tắm', 30000, 'PH0002'),
	('VD0006', N'Xới cơm', 120000, 'PH0003'),
	('VD0007', N'Dây trói', 120000, 'PH0003'),
	('VD0008', N'Ghế tình yêu', 120000, 'PH0003'),
	('VD0009', N'Tủ lạnh mini', 120000, 'PH0004'),
	('VD0010', N'Pepsi', 120000, 'PH0004'),
	('VD0011', N'Nước lọc', 120000, 'PH0004'),
	('VD0012', N'Khăn tắm', 120000, 'PH0004'),
	('VD0013', N'Xới cơm', 120000, 'PH0005'),
	('VD0014', N'Cô ca', 120000, 'PH0005'),
	('VD0015', N'Bao cao su', 120000, 'PH0005')

INSERT INTO HOADON_VATDUNG(MaHD, MaVatDung, SoLuong) VALUES
	('HD0001', 'VD0001', 1),
	('HD0002', 'VD0002', 3),
	('HD0003', 'VD0003', 2),
	('HD0004', 'VD0004', 4),
	('HD0003', 'VD0005', 5),
	('HD0002', 'VD0005', 3),
	('HD0001', 'VD0003', 6),
	('HD0005', 'VD0004', 3),
	('HD0006', 'VD0007', 4),
	('HD0003', 'VD0006', 5),
	('HD0006', 'VD0008', 2),
	('HD0002', 'VD0009', 3),
	('HD0002', 'VD0010', 4),
	('HD0007', 'VD0012', 5),
	('HD0008', 'VD0011', 3),
	('HD0009', 'VD0013', 1),
	('HD0008', 'VD0014', 2),
	('HD0010', 'VD0015', 3),
	('HD0010', 'VD0010', 5),
	('HD0007', 'VD0015', 4)

INSERT INTO DICHVU VALUES
	('DV0001', N'Giặt là', 30000),
	('DV0002', N'Đưa đón', 30000),
	('DV0003', N'Ăn sáng', 30000),
	('DV0004', N'Ăn trưa', 30000),
	('DV0005', N'Ăn tối', 30000)

INSERT INTO HOADON_DICHVU(MaHD, MaDV, SoLanSuDungDichVu) VALUES
	('HD0001', 'DV0001', 3 ),
	('HD0002', 'DV0002', 2 ),
	('HD0003', 'DV0002', 4 ),
	('HD0004', 'DV0003', 6 ),
	('HD0005', 'DV0004', 2 ),
	('HD0006', 'DV0003', 3 ),
	('HD0007', 'DV0005', 4 ),
	('HD0008', 'DV0001', 2 ),
	('HD0009', 'DV0004', 4 ),
	('HD0010', 'DV0003', 3 )



create sequence RoomSeq
	start with 1000 --bat dau tu 1000
	increment by 1; --moi lan tang 1 don vi
go
create proc InsertPhong @tenPhong varchar(10), @loaiPhong nvarchar(50), @giaThue1Ngay int
as
begin
	insert into PHONG(MaPhong,TenPhong,LoaiPhong,GiaThue1Ngay)
	values('PH' + cast(next value for RoomSeq as nvarchar(10)),@tenPhong,@loaiPhong,@giaThue1Ngay)
	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

go
create proc SelectPhongByID @maPhong char(6)
as
begin
	select * from PHONG
	where MaPhong = @maPhong
end
go
create proc SelectPhongByName @tenPhong varchar(10)
as
begin
	select * from PHONG
	where TenPhong = @tenPhong
end
go
create proc SelectPhongByCategory @loaiPhong nvarchar(50)
as
begin
	select * from PHONG
	where LoaiPhong = @loaiPhong
end
go
create proc SelectPhongByPrice @giaPhong1Ngay int
as
begin
	select * from PHONG
	where GiaThue1Ngay = @giaPhong1Ngay
end
go

create proc SelectAllPhong
as
begin
	select * from PHONG
end
go
create proc UpdatePhong @maPhong char(6),@tenPhong varchar(10), @loaiPhong nvarchar(50), @giaThue1Ngay int
as
begin
	update PHONG
	set TenPhong = @tenPhong,
	LoaiPhong = @loaiPhong,
	GiaThue1Ngay = @giaThue1Ngay
	where MaPhong = @maPhong
	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

--search vat dung ---
-- ma vat dung--
go
create procedure searchMaVatDung @Ma char(10)
as 
begin
	select MaVatDung, TenVatDung, GiaTienSuDung, MaPhong
	from VATDUNG
	where MaVatDung = @Ma
end
-- ten vat dung--
go
create procedure searchTenVatDung @TenVatDung nvarchar(100)
as 
begin
	select MaVatDung, TenVatDung, GiaTienSuDung, MaPhong
	from VATDUNG
	where TenVatDung = @TenVatDung
end
-- ma phong--
go
create procedure searchMaPhong @Ma char(10)
as 
begin
	select MaVatDung, TenVatDung, GiaTienSuDung, MaPhong
	from VATDUNG
	where MaPhong = @Ma
end

-- them sua vat dung--
go
create sequence VatDungSeq
	start with 1000 --bat dau tu 1000
	increment by 1; --moi lan tang 1 don vi
go
create proc InsertVatDung @tenVatDung char(10), @giaTien int, @maPhong char(10)
as
begin
	insert into VATDUNG(MaVatDung,TenVatDung,GiaTienSuDung,MaPhong)
	values('VD' + cast(next value for VatDungSeq as char(10)),@tenVatDung,@giaTien,@maPhong)
	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

go
create procedure UpdateVatDung
	@maVatDung char(10),
	@tenVatDung nvarchar(50),
	@giaTien int,
	@maPhong char(10)
as 
begin
	update VATDUNG
	set 		
		TenVatDung = @tenVatDung,
		GiaTienSuDung = @giaTien,
		MaPhong = @maPhong
	where MaVatDung = @maVatDung;

		if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

go
create procedure UpdateHoaDonVatDung
	@maVatDung char(10),
	@giaTien int
as 
begin
	update HOADON_VATDUNG
	set 		
		TongTienSuDungVatDung = @giaTien * SoLuong
	where MaVatDung = @maVatDung;

		if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

----------------------------------------------------------------------
---KHACHHANG---

create sequence GuestSeq
	start with 1000 --bat dau tu 1000
	increment by 1; --moi lan tang 1 don vi
go

-----------------------------
create proc InsertKhach @tenKH nvarchar(50), @NS date, @GT nvarchar(5)
as
begin
	insert into KHACHHANG(MaKH, HoTen, NgaySinh, GioiTinh)
	values('KH' + cast(next value for GuestSeq as nvarchar(10)),@tenKH,@NS,@GT);

	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end
----------------------------
create proc SelectKHByID @maKH char(6)
as
begin
	select * from KHACHHANG
	where MaKH = @maKH
end
----------------------------
go
create proc SelectKHByName @tenKH nvarchar(50)
as
begin
	select * from KHACHHANG
	where HoTen = @tenKH
end
----------------------------
go
create proc SelectAllKHACHHANG
as
begin
	select * from KHACHHANG
end
go
----------------------------
create proc UpdateKHACHHANG @maKH char(6),@tenKH nvarchar(50), @NS date, @gt nvarchar(5)
as
begin
	update KHACHHANG
	set HoTen = @tenKH,
	NgaySinh = @NS,
	GioiTinh = @gt
	where MaKH = @maKH
	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

----------------------------
---tim kiem---
---MaKH
create procedure searchMaKH @MaKH char(6)
as 
begin
	select MaKH, HoTen, NgaySinh, GioiTinh
	from KHACHHANG
	where MaKH = @MaKH
end

---TenKH
create procedure searchTenKH @TenKH nvarchar(50)
as 
begin
	select MaKH, HoTen, NgaySinh, GioiTinh
	from KHACHHANG
	where HoTen = @TenKH
end
-----------------------------------
--select * from THUE
--select * from KHACHHANG
--select * from PHONG

--select KHACHHANG.MaKH from KHACHHANG 
--inner join THUE on THUE.MaKH = KHACHHANG.MaKH
--where THUE.NgayDi is null
--union
--select KHACHHANG.MaKH from KHACHHANG
--EXCEPT
--(select KHACHHANG.MaKH from KHACHHANG 
--inner join THUE on THUE.MaKH = KHACHHANG.MaKH
--where THUE.NgayDi is null)

--select KHACHHANG.MaKH from KHACHHANG 
--	inner join THUE on THUE.MaKH = KHACHHANG.MaKH
--	where THUE.NgayDen is null or THUE.NgayDi is not null
--	union
--	(select KHACHHANG.MaKH from KHACHHANG
--	EXCEPT
--	select THUE.MaKH from THUE)
-----------------------------------
create proc InsertTHUE @MaKH char(6), @MaPhong char(6), @NgayDen date
as
begin
	insert into THUE(MaDK , MaKH, MaPhong, NgayDen)
	values('TU' + cast(next value for GuestSeq as char(6)),@MaKH,@MaPhong,@NgayDen);

	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

exec InsertTHUE 'KH1000','PH1000','2021-02-02'
-----------------------------------
create proc UpdateTHUE @maThue char(6),@MaKH char(6), @MaPhong char(6), @NgayDen date
as
begin
	update THUE
	set MaKH = @MaKH,
	MaPhong = @MaPhong,
	NgayDen = @NgayDen
	where MaDK = @maThue
	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end
go
-----------------------------------
create proc selectMaKHforRent
as
begin
	select KHACHHANG.MaKH from KHACHHANG
	EXCEPT
	(select KHACHHANG.MaKH from KHACHHANG 
	inner join THUE on THUE.MaKH = KHACHHANG.MaKH
	where THUE.NgayDi is null)

end
go

exec selectMaKHforRent
-------------------------------------
create proc selectThuebyID @maDK char(6)
as
begin
	select * from THUE
	where THUE.MaDK = @maDK
end

exec selectThuebyID 'DK0001'
---------------------------------------

create proc selectMaPHforRent
as
begin
	select PHONG.MaPhong from PHONG
	EXCEPT
	(select PHONG.MaPhong from PHONG
	inner join THUE on THUE.MaPhong = PHONG.MaPhong
	where THUE.NgayDi is null)

end
go

exec selectMaPHforRent
------------------------------------
---tim kiem---
---MaKH
create procedure searchMaKHforRent @MaKH char(6)
as 
begin
	select *
	from THUE
	where MaKH = @MaKH
end

---TenKH
create procedure searchMaPHONGforRent @MaPH char(6)
as 
begin
	select *
	from THUE
	where MaPhong = @MaPH
end
go

--Hiếu thêm--
create sequence DVSeq
	start with 1000 --bat dau tu 1000
	increment by 1; --moi lan tang 1 don vi
go

create proc InsertDV @tenDV nvarchar(50), @gia int as
begin
	insert into DICHVU(MaDV , TenDV, GiaSuDung)
	values('DV' + cast(next value for DVSeq as char(6)),@tenDV,@gia);

	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end
go

create proc UpdateDV @maDV char(6),@tenDV nvarchar(50), @gia int as
begin
	update DICHVU
	set 
	TenDV = @tenDV,
	GiaSuDung = @gia
	where MaDV = @maDV
	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end
go

create trigger UpdateHDNV on DICHVU for update as
begin
	declare @giaDV int, @maDV char(6)
	select @maDV = MaDV, @giaDV = GiaSuDung from inserted
	update HOADON_DICHVU
	set TongTienSuDungDichVu = SoLanSuDungDichVu * @giaDV
	where MaDV = @maDV
end
go


------------------tung---------------------
create function tienKH_phong (@makh char(6),@maphong nvarchar(50)) 
returns int
as
begin
	declare @tien int
	set @tien = (select p.GiaThue1Ngay from PHONG p where p.MaPhong=@maphong) * (SELECT  DATEDIFF(day, (select NgayDen from THUE where MaKH=@makh and MaPhong=@maphong), (select NgayDi from THUE where MaKH=@makh and MaPhong=@maphong)))
	return @tien
end
go

select dbo.tienKH_phong ('KH0002','PH0001')

go

alter function tien (@makh char(6),@maphong nvarchar(50),@mahd nvarchar(10)) 
returns int
as
begin
	declare @tien int
	set @tien = (select dbo.tienKH_phong (@makh,@maphong)) +  (select TongTienSuDungDichVu from HOADON_DICHVU where MaHD=@mahd) + (select distinct hd.TongTienSuDungVatDung from HOADON_VATDUNG hd, VATDUNG vd where MaHD=@mahd and vd.MaPhong=@maphong)
	--(select dbo.tienKH_phong (@makh,@maphong)) +
	return @tien
end
go
 (select dbo.tien ('KH0003','PH0003','HD1025'))

select dbo.tien ('KH0002','PH0001','HD1027')

go

create sequence HDsequ
	start with 4000 --bat dau tu 1000
	increment by 1; --moi lan tang 1 don vi
go




 go
 
alter proc test @maKH nvarchar(50), @maPhong nvarchar(50), @madv  nvarchar(50), @mavatdung  nvarchar(50), @slvd int , @sldv int
as
begin

	declare @temp nvarchar(50)
	set @temp = 'HD' + cast(next value for HDsequ as char(6))

	insert into HOADON
	values(@temp,0,@maKH,@maPhong);

	declare @tmpvd nvarchar(50)
	set @tmpvd = (select distinct MaVatDung from VATDUNG where TenVatDung=@mavatdung)

	insert into HOADON_VATDUNG(MaHD, MaVatDung, SoLuong)
	values (@temp,@tmpvd,@slvd)
	declare @vd int
	set @vd = (select distinct GiaTienSuDung from VATDUNG where TenVatDung=@mavatdung)
	update HOADON_VATDUNG
	set TongTienSuDungVatDung=SoLuong*@vd
	where MaHD = @temp


	declare @tmpdv nvarchar(50)
	set @tmpdv = (select distinct MaDV from DICHVU where TenDV=@madv)

	insert into HOADON_DICHVU(MaHD, MaDV, SoLanSuDungDichVu)
	values (@temp,@tmpdv,@sldv)
	declare @dv int
	set @dv = (select distinct GiaSuDung from DICHVU where TenDV=@madv)
	update HOADON_DICHVU
	set TongTienSuDungDichVu=SoLanSuDungDichVu*@dv
	where MaHD = @temp


	update HOADON
	set TongTien = (select dbo.tien (@maKH,@maPhong,@temp)) where MaHD=@temp

	print @dv
	print @temp


	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end

exec test 'KH0003','PH0003',N'Đưa đón',N'Cô ca',3,3

 (select dbo.tien ('KH0003','PH0003','HD1025'))

SELECT hdvd.SoLuong FROM vatdung vd, hoadon_vatdung hdvd  where hdvd.mavatdung=vd.mavatdung and hdvd.mahd='HD1028' and vd.maphong = 'PH0002'

go

-----

----
 go
alter proc testedit @mahd nvarchar(20),@maKH nvarchar(50), @maPhong nvarchar(50), @madv  nvarchar(50), @mavatdung  nvarchar(50), @slvd int , @sldv int
as
begin


	update  HOADON
	set MaKH=@maKH, MaPhong=@maPhong

	declare @tmpvd nvarchar(50)
	set @tmpvd = (select distinct MaVatDung from VATDUNG where TenVatDung=@mavatdung)

	declare @vd int
	set @vd = (select distinct GiaTienSuDung from VATDUNG where TenVatDung=@mavatdung)
	update HOADON_VATDUNG
	set SoLuong=@slvd
	where MaHD = @mahd

	update HOADON_VATDUNG
	set TongTienSuDungVatDung=SoLuong*@vd
	where MaHD = @mahd


	declare @tmpdv nvarchar(50)
	set @tmpdv = (select distinct MaDV from DICHVU where TenDV=@madv)


	declare @dv int
	set @dv = (select distinct GiaSuDung from DICHVU where TenDV=@madv)

	update HOADON_DICHVU
	set SoLanSuDungDichVu=@sldv
	where MaHD = @mahd

	update HOADON_DICHVU
	set TongTienSuDungDichVu=SoLanSuDungDichVu*@dv
	where MaHD = @mahd


	update HOADON
	set TongTien = (select dbo.tien (@maKH,@maPhong,@mahd)) where MaHD=@mahd 

	print @dv


	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end
exec testedit 'HD1029','KH0004','PH0003',N'Ăn trưa',N'Xới cơm',40,30

go

create procedure searchHD @key nvarchar(100)
as 
begin
	select MaHD, TongTien, MaKH, MaPhong
	from HOADON 
	where MaHD like '%'+@key+'%' or MaKH like '%'+@key+'%' or MaPhong like '%'+@key+'%'
end

exec searchHD 'H'