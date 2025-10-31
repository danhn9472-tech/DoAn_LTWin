USE master;
GO

-- 2. "Đuổi" tất cả các kết nối khác ra
ALTER DATABASE QLTAPHOA
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

-- 3. Bây giờ mới Xóa
DROP DATABASE QLTAPHOA;
GO



-- Tạo Database
CREATE DATABASE QLTAPHOA;
GO

USE QLTAPHOA;
GO

CREATE TABLE NHANVIEN (
    MaNV        VARCHAR(12) PRIMARY KEY,
    TenNV       NVARCHAR(100) NOT NULL,
    GioiTinh    NVARCHAR(10),
    NgaySinh    DATE,
    SDT         VARCHAR(13),
    Email       VARCHAR(100),
    DiaChi      NVARCHAR(200),
    ChucVu      NVARCHAR(50),
    TaiKhoan    VARCHAR(50)  NOT NULL,
    MatKhau     VARCHAR(255) NOT NULL
);




CREATE TABLE KHACHHANG (
    MaKH    VARCHAR(12) PRIMARY KEY ,
    TenKH   NVARCHAR(100) NOT NULL,
    SDT     VARCHAR(13),
    Email   VARCHAR(100),
    DiaChi  NVARCHAR(200)
);



CREATE TABLE NHACUNGCAP (
    MaNCC   VARCHAR(12) PRIMARY KEY,
    TenNCC  NVARCHAR(100) NOT NULL,
    SDT     VARCHAR(13),
    Email   VARCHAR(100),
    DiaChi  NVARCHAR(200)
);


CREATE TABLE SANPHAM (
    MaSP        VARCHAR(12) PRIMARY KEY,
    TenSP       NVARCHAR(100) NOT NULL,
    DonViTinh   NVARCHAR(20),
    DonGia      DECIMAL(10, 2),
    SoLuongTon  INT DEFAULT 0,
    MaNCC       VARCHAR(12),
    Avatar      VARCHAR(100),
    TrangThai VARCHAR(20) CHECK (TrangThai IN ('Còn kinh doanh', 'Ngưng kinh doanh')) DEFAULT 'Còn kinh doanh',
    FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC)
);


CREATE TABLE HOADON (
    MaHD        VARCHAR(12) PRIMARY KEY,
    MaKH        VARCHAR(12),
    MaNV        VARCHAR(12),
    NgayLap     DATETIME DEFAULT CURRENT_TIMESTAMP,
    TongTien    DECIMAL(12, 2),
    FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);



CREATE TABLE CHITIETHOADON (
    MaCTHD      VARCHAR(12) PRIMARY KEY,
    MaHD        VARCHAR(12),
    MaSP        VARCHAR(12),
    SoLuong     INT,
    DonGia DECIMAL(10, 2),
    FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);



CREATE TABLE PHIEUNHAP (
    MaPN        VARCHAR(12) PRIMARY KEY,
    MaNCC       VARCHAR(12),
    MaNV        VARCHAR(12),
    NgayNhap    DATETIME DEFAULT CURRENT_TIMESTAMP,
    TongTien    DECIMAL(12, 2),
    FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);



CREATE TABLE CHITIETPHIEUNHAP (
    MaCTPN      VARCHAR(12) PRIMARY KEY,
    MaPN        VARCHAR(12),
    MaSP        VARCHAR(12),
    SoLuong     INT,
    DonGiaNhap  DECIMAL(10, 2),
    FOREIGN KEY (MaPN) REFERENCES PHIEUNHAP(MaPN),
    FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);
-- Chỉnh Ngày khớp cho việt Nam
set dateformat DMY
--nHẬP Nhân Viên
INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, SDT, Email, DiaChi, ChucVu, TaiKhoan, MatKhau) VALUES
('NV001', N'Nguyễn Thị Mai', N'Nữ', '1985-03-20', '0901234567', 'mai.nguyen@example.com', N'45 Nguyễn Huệ, Quận 1, TP.HCM', N'Quản lý',  'admin', '123456'),
('NV002', N'Lê Văn Bình', N'Nam', '1992-07-12', '0902345678', 'binh.le@example.com', N'12 Trần Hưng Đạo, Quận 5, TP.HCM', N'Nhân viên bán hàng', 'binhle', '123456'),
('NV003', N'Trần Thị Hồng', N'Nữ', '1995-11-05', '0903456789', 'hong.tran@example.com', N'88 Lý Thường Kiệt, Quận 10, TP.HCM', N'Nhân viên bán hàng', 'hongtran', '123456'),
('NV004', N'Phạm Văn Dũng', N'Nam', '1990-09-25', '0904567890', 'dung.pham@example.com', N'101 Phan Văn Trị, Gò Vấp, TP.HCM', N'Nhân viên kho',  'dungpham', '1234561'),
('NV005', N'Ngô Văn Sơn', N'Nam', '1988-01-30', '0905678901', 'son.ngo@example.com', N'33 Cách Mạng Tháng 8, Quận 3, TP.HCM', N'Nhân viên',  'sonngo', '1234568'),
('NV006', N'Đặng Thị Lan', N'Nữ', '1987-06-18', '0906789012', 'lan.dang@example.com', N'76 Nguyễn Trãi, Quận 1, TP.HCM', N'Nhân viên',  'landang', '1234567');

-- Khách hàng

INSERT INTO KHACHHANG VALUES ('KH001', N'Nguyễn Văn An', '0987123456', 'an.nguyen@example.com', N'12 Lê Lợi, Q1, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH002', N'Trần Thị Bình', '0912345678', 'binh.tran@example.com', N'34 Nguyễn Trãi, Q5, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH003', N'Lê Văn Cường', '0908765432', 'cuong.le@example.com', N'56 CMT8, Q10, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH004', N'Phạm Thị Dung', '0931122334', 'dung.pham@example.com', N'78 Điện Biên Phủ, Q.Bình Thạnh, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH005', N'Hoàng Văn Đức', '0976543210', 'duc.hoang@example.com', N'90 Nguyễn Văn Cừ, Q1, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH006', N'Ngô Thị Hạnh', '0923344556', 'hanh.ngo@example.com', N'102 Trường Chinh, Tân Bình, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH007', N'Vũ Minh Hiếu', '0967890123', 'hieu.vu@example.com', N'124 Phan Đăng Lưu, Q.Phú Nhuận, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH008', N'Đặng Thị Hương', '0945566778', 'huong.dang@example.com', N'146 Nguyễn Thị Minh Khai, Q3, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH009', N'Từ Hoàng Khang', '0899988776', 'khang.tu@example.com', N'168 Xô Viết Nghệ Tĩnh, Q.Bình Thạnh, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH010', N'Bùi Văn Khánh', '0954433221', 'khanh.bui@example.com', N'180 Nguyễn Xí, Q.Bình Thạnh, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH011', N'Nguyễn Thị Lan', '0918765432', 'lan.nguyen@example.com', N'192 D2, Q.Bình Thạnh, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH012', N'Trần Văn Lâm', '0937654321', 'lam.tran@example.com', N'204 Chu Văn An, Q.Bình Thạnh, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH013', N'Lê Thị Mai', '0909988776', 'mai.le@example.com', N'216 Nguyễn Hữu Cảnh, Q.Bình Thạnh, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH014', N'Phạm Văn Minh', '0978123456', 'minh.pham@example.com', N'228 Võ Thị Sáu, Q3, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH015', N'Hoàng Thị Nga', '0921234567', 'nga.hoang@example.com', N'240 Pasteur, Q1, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH016', N'Ngô Văn Nam', '0965432187', 'nam.ngo@example.com', N'252 Nguyễn Đình Chiểu, Q3, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH017', N'Vũ Thị Oanh', '0943217890', 'oanh.vu@example.com', N'264 Trần Hưng Đạo, Q5, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH018', N'Đặng Văn Phúc', '0891234987', 'phuc.dang@example.com', N'276 Lý Thường Kiệt, Q10, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH019', N'Từ Thị Quỳnh', '0956781234', 'quynh.tu@example.com', N'288 Nguyễn Văn Đậu, Q.Bình Thạnh, TP.HCM');
INSERT INTO KHACHHANG VALUES ('KH020', N'Bùi Thị Quyên', '0901122334', 'quyen.bui@example.com', N'300 Phan Văn Trị, Gò Vấp, TP.HCM');

--Nhà Cung Cấp

INSERT INTO NHACUNGCAP VALUES ('NCC001', N'Vinamilk', '0901234567', 'contact@vinamilk.com.vn', N'10 Tân Cảng, Q.Bình Thạnh, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC002', N'TH True Milk', '0902345678', 'info@thmilk.vn', N'Nghĩa Đàn, Nghệ An');
INSERT INTO NHACUNGCAP VALUES ('NCC003', N'Nestlé Việt Nam', '0903456789', 'nestle@nestle.vn', N'KCN Biên Hòa, Đồng Nai');
INSERT INTO NHACUNGCAP VALUES ('NCC004', N'Coca-Cola Việt Nam', '0904567890', 'cocacola@coca-cola.com.vn', N'62 Trần Hưng Đạo, Q.5, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC005', N'PepsiCo Việt Nam', '0905678901', 'pepsi@pepsico.vn', N'45 Nguyễn Văn Linh, Q.7, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC006', N'Tân Hiệp Phát', '0906789012', 'thp@thp.com.vn', N'219 Quốc lộ 13, Bình Dương');
INSERT INTO NHACUNGCAP VALUES ('NCC007', N'Orion Việt Nam', '0907890123', 'orion@orion.vn', N'56 Nguyễn Văn Cừ, Q.1, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC008', N'Kinh Đô', '0908901234', 'kinhdo@kinhdo.vn', N'25 Nguyễn Hữu Thọ, Q.7, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC009', N'Acecook Việt Nam', '0909012345', 'acecook@acecook.com.vn', N'123 Lê Trọng Tấn, Tân Phú, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC010', N'Masan Consumer', '0910123456', 'masan@masan.vn', N'1 Đinh Bộ Lĩnh, Q.Bình Thạnh, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC011', N'Ajinomoto Việt Nam', '0911234567', 'ajinomoto@ajinomoto.com.vn', N'Long Thành, Đồng Nai');
INSERT INTO NHACUNGCAP VALUES ('NCC012', N'Vissan', '0912345678', 'vissan@vissan.com.vn', N'420 Nơ Trang Long, Q.Bình Thạnh, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC013', N'Saigon Co.op', '0913456789', 'coop@saigoncoop.com.vn', N'199 Nguyễn Thái Học, Q.1, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC014', N'Bánh kẹo Hải Hà', '0914567890', 'haiha@haiha.vn', N'25 Trần Phú, Hà Nội');
INSERT INTO NHACUNGCAP VALUES ('NCC015', N'Dầu ăn Tường An', '0915678901', 'tuongan@tuongan.vn', N'48 Nguyễn Văn Quá, Q.12, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC016', N'Nước khoáng Lavie', '0916789012', 'lavie@lavie.vn', N'KCN Long Hậu, Long An');
INSERT INTO NHACUNGCAP VALUES ('NCC017', N'Bánh kẹo Bibica', '0917890123', 'bibica@bibica.com.vn', N'88 Trường Chinh, Tân Bình, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC018', N'Bánh mì ABC', '0918901234', 'abc@banhmivn.vn', N'12 Nguyễn Văn Đậu, Q.Bình Thạnh, TP.HCM');
INSERT INTO NHACUNGCAP VALUES ('NCC019', N'Giấy Sài Gòn', '0919012345', 'giay@saigonpaper.vn', N'KCN Mỹ Xuân, Bà Rịa - Vũng Tàu');
INSERT INTO NHACUNGCAP VALUES ('NCC020', N'Colgate-Palmolive Việt Nam', '0920123456', 'colgate@colgate.vn', N'KCN VSIP, Bình Dương');

--Nhập sản phẩm
INSERT INTO SANPHAM (MaSP, TenSP, DonViTinh, DonGia, SoLuongTon, MaNCC, Avatar, TrangThai) VALUES
('SP001', N'Sữa tươi Vinamilk 1L', N'Hộp', 29000, 120, 'NCC001', 'SP001.jpg', N'Còn kinh doanh'),
('SP002', N'Sữa chua TH True Milk', N'Hũ', 8000, 200, 'NCC002', 'SP002.jpg', N'Còn kinh doanh'),
('SP003', N'Cà phê Nestlé 3in1', N'Gói', 2500, 500, 'NCC003', 'SP003.jpg', N'Còn kinh doanh'),
('SP004', N'Nước ngọt Coca-Cola 330ml', N'Lon', 10000, 300, 'NCC004', 'SP004.jpg', N'Còn kinh doanh'),
('SP005', N'Nước ngọt Pepsi 1.5L', N'Chai', 18000, 150, 'NCC005', 'SP005.jpg', N'Còn kinh doanh'),
('SP006', N'Trà xanh C2 500ml', N'Chai', 9000, 250, 'NCC006', 'SP006.jpg', N'Còn kinh doanh'),
('SP007', N'Bánh ChocoPie Orion', N'Hộp', 45000, 80, 'NCC007', 'SP007.jpg', N'Còn kinh doanh'),
('SP008', N'Bánh quy Kinh Đô', N'Gói', 32000, 100, 'NCC008', 'SP008.jpg', N'Còn kinh doanh'),
('SP009', N'Mì Hảo Hảo tôm chua cay', N'Gói', 4000, 500, 'NCC009', 'SP009.jpg', N'Còn kinh doanh'),
('SP010', N'Nước mắm Nam Ngư', N'Chai', 28000, 90, 'NCC010', 'SP010.jpg', N'Còn kinh doanh'),
('SP011', N'Bột ngọt Ajinomoto 454g', N'Gói', 22000, 150, 'NCC011', 'SP011.jpg', N'Còn kinh doanh'),
('SP012', N'Xúc xích Vissan', N'Gói', 35000, 120, 'NCC012', 'SP012.jpg', N'Còn kinh doanh'),
('SP013', N'Nước rửa chén Co.op Select', N'Chai', 27000, 80, 'NCC013', 'SP013.jpg', N'Còn kinh doanh'),
('SP014', N'Kẹo dẻo Hải Hà', N'Gói', 15000, 60, 'NCC014', 'SP014.jpg', N'Còn kinh doanh'),
('SP015', N'Dầu ăn Tường An 1L', N'Chai', 52000, 100, 'NCC015', 'SP015.jpg', N'Còn kinh doanh'),
('SP016', N'Nước khoáng Lavie 500ml', N'Chai', 6000, 350, 'NCC016', 'SP016.jpg', N'Còn kinh doanh'),
('SP017', N'Bánh mì sandwich Bibica', N'Gói', 22000, 100, 'NCC017', 'SP017.jpg', N'Còn kinh doanh'),
('SP018', N'Bánh mì ABC đặc ruột', N'Ổ', 5000, 200, 'NCC018', 'SP018.jpg', N'Còn kinh doanh'),
('SP019', N'Giấy vệ sinh Sài Gòn 10 cuộn', N'Lốc', 45000, 70, 'NCC019', 'SP019.jpg', N'Còn kinh doanh'),
('SP020', N'Kem đánh răng Colgate 180g', N'Tuýp', 35000, 90, 'NCC020', 'SP020.jpg', N'Ngưng kinh doanh');


--Hóa Đơn
INSERT INTO HOADON VALUES
('HD001', 'KH001', 'NV001', '2025-10-01 08:00:00', 125000.00),
('HD002', 'KH002', 'NV002', '2025-10-01 08:15:00', 98000.00),
('HD003', 'KH003', 'NV003', '2025-10-01 08:30:00', 157000.00),
('HD004', 'KH004', 'NV004', '2025-10-01 08:45:00', 203000.00),
('HD005', 'KH005', 'NV005', '2025-10-01 09:00:00', 89000.00),
('HD006', 'KH006', 'NV006', '2025-10-01 09:15:00', 112000.00),
('HD007', 'KH007', 'NV001', '2025-10-01 09:30:00', 134000.00),
('HD008', 'KH008', 'NV002', '2025-10-01 09:45:00', 176000.00),
('HD009', 'KH009', 'NV003', '2025-10-01 10:00:00', 99000.00),
('HD010', 'KH010', 'NV004', '2025-10-01 10:15:00', 142000.00),
('HD011', 'KH011', 'NV005', '2025-10-01 10:30:00', 158000.00),
('HD012', 'KH012', 'NV006', '2025-10-01 10:45:00', 121000.00),
('HD013', 'KH013', 'NV001', '2025-10-01 11:00:00', 99000.00),
('HD014', 'KH014', 'NV002', '2025-10-01 11:15:00', 178000.00),
('HD015', 'KH015', 'NV003', '2025-10-01 11:30:00', 87000.00),
('HD016', 'KH016', 'NV004', '2025-10-01 11:45:00', 143000.00),
('HD017', 'KH017', 'NV005', '2025-10-01 12:00:00', 159000.00),
('HD018', 'KH018', 'NV006', '2025-10-01 12:15:00', 99000.00),
('HD019', 'KH019', 'NV001', '2025-10-01 12:30:00', 132000.00),
('HD020', 'KH020', 'NV002', '2025-10-01 12:45:00', 117000.00);


--Chi tiết hóa đơn

INSERT INTO CHITIETHOADON VALUES
('CTHD001', 'HD001', 'SP001', 2, 29000.00),
('CTHD002', 'HD001', 'SP009', 3, 4000.00),
('CTHD003', 'HD002', 'SP003', 1, 2500.00),
('CTHD004', 'HD002', 'SP010', 2, 28000.00),
('CTHD005', 'HD003', 'SP009', 5, 4000.00),
('CTHD006', 'HD003', 'SP016', 3, 6000.00),
('CTHD007', 'HD004', 'SP004', 4, 10000.00),
('CTHD008', 'HD004', 'SP008', 2, 32000.00),
('CTHD009', 'HD005', 'SP001', 1, 29000.00),
('CTHD010', 'HD005', 'SP005', 3, 18000.00),
('CTHD011', 'HD006', 'SP016', 2, 6000.00),
('CTHD012', 'HD006', 'SP003', 1, 2500.00),
('CTHD013', 'HD007', 'SP010', 2, 28000.00),
('CTHD014', 'HD007', 'SP013', 4, 27000.00),
('CTHD015', 'HD008', 'SP009', 5, 4000.00),
('CTHD016', 'HD008', 'SP010', 1, 28000.00),
('CTHD017', 'HD009', 'SP004', 3, 10000.00),
('CTHD018', 'HD009', 'SP015', 1, 52000.00),
('CTHD019', 'HD010', 'SP001', 2, 29000.00),
('CTHD020', 'HD010', 'SP016', 3, 6000.00);



--Phiếu Nhập

INSERT INTO PHIEUNHAP VALUES ('PN001', 'NCC017', 'NV002', '2025-10-01 08:00:00', 264000.00);
INSERT INTO PHIEUNHAP VALUES ('PN002', 'NCC018', 'NV001', '2025-10-01 08:30:00', 300000.00);
INSERT INTO PHIEUNHAP VALUES ('PN003', 'NCC019', 'NV005', '2025-10-01 09:00:00', 315000.00);
INSERT INTO PHIEUNHAP VALUES ('PN004', 'NCC020', 'NV001', '2025-10-01 09:30:00', 315000.00);
INSERT INTO PHIEUNHAP VALUES ('PN005', 'NCC001', 'NV001', '2025-10-01 10:00:00', 348000.00);
INSERT INTO PHIEUNHAP VALUES ('PN006', 'NCC002', 'NV006', '2025-10-01 10:30:00', 160000.00);
INSERT INTO PHIEUNHAP VALUES ('PN007', 'NCC003', 'NV001', '2025-10-01 11:00:00', 250000.00);
INSERT INTO PHIEUNHAP VALUES ('PN008', 'NCC004', 'NV004', '2025-10-01 11:30:00', 300000.00);
INSERT INTO PHIEUNHAP VALUES ('PN009', 'NCC005', 'NV005', '2025-10-01 12:00:00', 270000.00);
INSERT INTO PHIEUNHAP VALUES ('PN010', 'NCC006', 'NV003', '2025-10-01 12:30:00', 270000.00);

--Chi tiết phiếu nhập

INSERT INTO CHITIETPHIEUNHAP VALUES
('CTPN001', 'PN001', 'SP001', 120, 21000.00),
('CTPN002', 'PN001', 'SP002', 200, 6000.00),
('CTPN003', 'PN001', 'SP003', 150, 2000.00),

('CTPN004', 'PN002', 'SP004', 200, 7500.00),
('CTPN005', 'PN002', 'SP005', 100, 13000.00),

('CTPN006', 'PN003', 'SP006', 180, 6500.00),
('CTPN007', 'PN003', 'SP007', 100, 32000.00),
('CTPN008', 'PN003', 'SP008', 120, 25000.00),

('CTPN009', 'PN004', 'SP009', 250, 3000.00),
('CTPN010', 'PN004', 'SP010', 150, 20000.00),

('CTPN011', 'PN005', 'SP001', 100, 21000.00),
('CTPN012', 'PN005', 'SP002', 120, 5500.00),
('CTPN013', 'PN005', 'SP004', 90, 7000.00),

('CTPN014', 'PN006', 'SP005', 150, 14000.00),
('CTPN015', 'PN006', 'SP006', 200, 6000.00),
('CTPN016', 'PN006', 'SP007', 100, 35000.00),

('CTPN017', 'PN007', 'SP008', 150, 25000.00),
('CTPN018', 'PN007', 'SP009', 400, 2500.00),
('CTPN019', 'PN007', 'SP010', 100, 20000.00),

('CTPN020', 'PN008', 'SP003', 200, 1800.00),
('CTPN021', 'PN008', 'SP004', 100, 7000.00),

('CTPN022', 'PN009', 'SP005', 150, 15000.00),
('CTPN023', 'PN009', 'SP006', 200, 7000.00),

('CTPN024', 'PN010', 'SP007', 100, 34000.00),
('CTPN025', 'PN010', 'SP008', 120, 27000.00),
('CTPN026', 'PN010', 'SP009', 300, 3500.00);

Select * From HOADON
SELECT * FROM CHITIETHOADON;



