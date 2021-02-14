--database oluşturduk
create database RentingCar  

--colors tablosu
create table Colors(
                    ColorID int primary key identity (1,1),
                    Name varchar (20) not null 
                    );
-- Brands tablosu
create table Brands(
                    BrandID int identity(1,1) primary key,
                    BrandName varchar(30) not null
);
-- Cars tablosu
create table Cars(
                    CarID int primary key identity(1,1),
                    BrandID int not null,
                    ColorID int not null,
                    ModelYear int not null,
                    DailyPrice float not null,
                    Description varchar(100), 
                    foreign key (BrandID) REFERENCES Brands(BrandID),
                    foreign key (ColorId) references Colors(ColorID)
                    );


--colors tablosunu dolduralım

insert Colors(ColorID,Name) values (1,'Blue') --ilk çalışmada hata verdi. id insert edemiyoruz. 

set identity_insert Colors on -- bu kod ile id eklemeyi açtık.

--her seferinde aynı sorguyu çalıştıracağımız için insert işlemi için Store Procedure yapalım
create procedure insertColor @id int, @colorName nvarchar(30)
AS
insert Colors(ColorID,Name) values (@id,@colorName) 
GO

exec insertColor @id =6, @colorName ='Yellow' --burada id değerleri ve renk değerleri girip tabloya insert ediyoruz.

select * from Colors

-- Brands tablosuna insert için store procedure
set identity_insert Colors Off
create procedure insertBrand @id int, @brandName nvarchar(30)
AS
insert Brands(BrandID,BrandName) values (@id,@brandName) 
GO

exec insertBrand @id =10, @brandName ='Fiat' --burada id değerleri ve model değerleri girip tabloya insert ediyoruz.


set identity_insert brands On

select * from Brands

-- Cars tablosuna insert için store procedure
set identity_insert brands Off
set identity_insert cars on
create procedure insertCar @brandId int,@colorId int, @modelYear int,@dailyPrice float, @description varchar(50)
AS
insert Cars(BrandID,ColorID,ModelYear,DailyPrice,Description) values (@brandId,@colorId,@modelYear,@dailyPrice,@description) 
GO


exec insertCar @brandId =4, @colorId =1,@modelYear =2008,@dailyPrice=100,@description ='Lpg'
exec insertCar @brandId =9, @colorId =4,@modelYear =2003,@dailyPrice=135,@description ='Diesel'
exec insertCar @brandId =10, @colorId =5,@modelYear =2013,@dailyPrice=80,@description ='Lpg'
exec insertCar @brandId =3, @colorId =3,@modelYear =2001,@dailyPrice=1500,@description ='Diesel'
exec insertCar @brandId =6, @colorId =3,@modelYear =2015,@dailyPrice=160,@description ='Diesel'
exec insertCar @brandId =2, @colorId =2,@modelYear =2019,@dailyPrice=150,@description ='Hybrid'
exec insertCar @brandId =5, @colorId =5,@modelYear =1995,@dailyPrice=220,@description ='Hybrid'
exec insertCar @brandId =1, @colorId =6,@modelYear =2019,@dailyPrice=1000,@description ='Hybrid'
exec insertCar @brandId =8, @colorId =2,@modelYear =2001,@dailyPrice=100,@description ='Lpg'
exec insertCar @brandId =7, @colorId =4,@modelYear =2010,@dailyPrice=250,@description ='Diesel'


select CarID,Brands.BrandName,Colors.Name,ModelYear,DailyPrice,Description from Cars join Colors 
on Cars.ColorID =Colors.ColorID
join Brands
on
Cars.BrandID = Brands.BrandID


--tablo colomn ismi güncelleme
EXEC sp_RENAME 'table_name.old_name', 'new_name', 'COLUMN'
EXEC sp_rename 'Cars.CarID', 'ID', 'COLUMN'  
