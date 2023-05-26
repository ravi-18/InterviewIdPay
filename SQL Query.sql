/* 1.   */
-- Membuat Table Data Demografi
CREATE TABLE DataDemografi (
    Id INT IDENTITY,
    NIK BIGINT NOT NULL PRIMARY KEY,
    Nama VARCHAR(50) NOT NULL,
    Tempat_Lahir VARCHAR(50),
    Tanggal_Lahir DATE,
    Jenis_Kelamin VARCHAR(10),
    Golongan_Darah VARCHAR(5),
    Alamat VARCHAR(100),
    RT VARCHAR(5),
    RW VARCHAR(5),
    Kelurahan VARCHAR(50),
    Desa VARCHAR(50),
    Kecamatan VARCHAR(50),
    Kota VARCHAR(50),
    Provinsi VARCHAR(50),
    Agama VARCHAR(20),
    KodePos VARCHAR(10),
    StatusPerkawinan VARCHAR(20),
    Pekerjaan VARCHAR(50),
    Kewarganegaraan VARCHAR(50),
    Masa_Berlaku DATE
);

--Membuat Table Data Photo ID
CREATE TABLE DataPhotoID (
    Id INT IDENTITY PRIMARY KEY,
    NIK BIGINT,
    Path_Photo VARCHAR(100)
);

--SET Relasi Database antara Table Data Demografi dan Table Data Photo ID
ALTER TABLE DataPhotoID
ADD CONSTRAINT FK_DataPhotoID_DataDemografi FOREIGN KEY (NIK) 
REFERENCES DataDemografi (NIK);


/* 2.   */
--INSERT DATA DEMOGRAFI
INSERT INTO DataDemografi(
NIK,Nama,Tempat_Lahir,Tanggal_Lahir,Jenis_Kelamin,Golongan_Darah,Alamat,RT,RW,Kelurahan,Desa,Kecamatan,Kota,Provinsi,Agama,KodePos,StatusPerkawinan,Pekerjaan,Kewarganegaraan,Masa_Berlaku)
VALUES
(1234567890123456,'Abang','Suatu Tempat','1996/01/01','Laki-Laki','B','Ada','01','01','Suatu','Tempat','Ada Suatu','Suatu Tempat','Ada Aja','Islam','12345','Menikah','Crezy Rich','Indonesia','2050/12/30'),
(1234567890123457,'Abang2','Suatu Tempat2','1996/01/02','Laki-Laki','B','Ada','01','01','Suatu','Tempat','Ada Suatu','Suatu Tempat','Ada Aja','Islam','12345','Menikah','Crezy Rich','Indonesia','2050/12/30'),
(1234567890123458,'Abang3','Suatu Tempat3','1996/01/01','Laki-Laki','B','Ada','01','01','Suatu','Tempat','Ada Suatu','Suatu Tempat','Ada Aja','Islam','12345','Menikah','Crezy Rich','Indonesia','2050/12/30'),
(1234567890123459,'Abang4','Suatu Tempat4','1996/01/01','Laki-Laki','B','Ada','01','01','Suatu','Tempat','Ada Suatu','Suatu Tempat','Ada Aja','Islam','12345','Menikah','Crezy Rich','Indonesia','2050/12/30'),
(1234567890123460,'Abang5','Suatu Tempat5','1996/01/01','Laki-Laki','B','Ada','01','01','Suatu','Tempat','Ada Suatu','Suatu Tempat','Ada Aja','Islam','12345','Menikah','Crezy Rich','Indonesia','2050/12/30')

--INSERT DATA PHOTO ID
INSERT INTO DataPhotoID(NIK,Path_Photo)
VALUES
(1234567890123456,'Disini/Ada'),
(1234567890123456,'Disini/Ada1'),
(1234567890123457,'Disini/Ada2'),
(1234567890123457,'Disini/Ada3'),
(1234567890123457,'Disini/Ada4'),
(1234567890123458,'Disini/Ada5'),
(1234567890123459,'Disini/Ada6'),
(1234567890123459,'Disini/Ada7'),
(1234567890123460,'Disini/Ada8'),
(1234567890123460,'Disini/Ada9')

--CHECK DATA INSERT
SELECT * FROM DataDemografi a
INNER JOIN DataPhotoID b on b.NIK = a.NIK


/* 3.   */
--Create Stored Prosedure
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ravi
-- Create date: 26/05/2023
-- Description:	Get data Demografi dengan path photo dari PhotoID
-- =============================================
CREATE PROCEDURE GetAllData 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Select statements for procedure here
	SELECT a.NIK,Nama,Tempat_Lahir,Tanggal_Lahir,Jenis_Kelamin,Golongan_Darah,Alamat,RT,RW,Kelurahan,Desa,Kecamatan,Kota,Provinsi,Agama,KodePos,StatusPerkawinan,Pekerjaan,Kewarganegaraan,Masa_Berlaku,Path_Photo from DataDemografi a
	INNER JOIN DataPhotoID b on b.NIK = a.NIK
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ravi
-- Create date: 26/05/2023
-- Description:	Get data Demografi dengan path photo dari PhotoID
-- =============================================
CREATE PROCEDURE GetDataByNIK
	-- Add the parameters for the stored procedure here
	@NIK BIGINT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Select statements for procedure here
	SELECT a.NIK,Nama,Tempat_Lahir,Tanggal_Lahir,Jenis_Kelamin,Golongan_Darah,Alamat,RT,RW,Kelurahan,Desa,Kecamatan,Kota,Provinsi,Agama,KodePos,StatusPerkawinan,Pekerjaan,Kewarganegaraan,Masa_Berlaku,Path_Photo from DataDemografi a
	INNER JOIN DataPhotoID b on b.NIK = a.NIK
	where a.NIK = @NIK
END
GO

--Execution Stored Prosedure GetAllData
exec GetAllData;

--Execution Stored Prosedure GetDataByNIK
exec GetDataByNIK @NIK = 1234567890123456

