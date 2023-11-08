USE [master]
GO

/*******************************************************************************
   Drop database if it exists
********************************************************************************/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'PRN231PROJECT')
BEGIN
	ALTER DATABASE [PRN231PROJECT] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [PRN231PROJECT] SET ONLINE;
	DROP DATABASE [PRN231PROJECT];
END

GO

CREATE DATABASE [PRN231PROJECT]

GO

USE [PRN231PROJECT]

GO
create table Roles(
RoleId int primary key identity(1,1),
RoleName nvarchar(100)
)
GO
create table Users(
UserId int primary key identity(1,1) not null,
RoleId int foreign key references Roles(RoleId),
FullName nvarchar(100),
DateOfBirth datetime,
Username nvarchar(100),
[Password] nvarchar(100),
Email nvarchar(100),
PhoneNumber nvarchar(100),
active bit 
)

GO
create table Rooms(
RoomId int primary key identity(1,1),
RoomName nvarchar(100),
NumberOfSeats int,
)

GO
create table Seats(
SeatId int primary key identity(1,1),
RoomId int foreign key references Rooms(RoomId),
[status] bit,
SeatName nvarchar(50)
)

GO

create table Movies(
MovieId int primary key identity(1,1) not null,
Title nvarchar(100),
DurationMinutes int,
isReleased bit,
URLImages nvarchar(100)
)
GO

create table Shows(
ShowId int primary key identity(1,1) not null,
MovieId int foreign key references Movies(MovieId),
Prices money,
StartTime datetime,
EndTime datetime,
RoomId int foreign key references Rooms(RoomId)
)
Go
create table Bills(
BillId int primary key identity(1,1) not null,
SeatId int foreign key references Seats(SeatId) ,
UserId int foreign key references Users(UserId) ,
ShowId int foreign key references Shows(ShowId) 
)
GO

insert into Roles values( N'Admin')
insert into Roles values(N'Customer')
insert into Roles values(N'Staff')


Go
insert into Users values(1, N'hieu', N'1/1/2000', N'hieu','123', 'hieuhieut123@gmail.com', N'0934386938', 1)
insert into Users values(2, N'hieu', N'1/1/2000', N'htz', '123','hieuhieut123@gmail.com', N'0934386438', 1)
insert into Users values(3, N'hieu', N'1/1/2000', N'htz123', '123','hieuhieut123@gmail.com', N'0934386438', 1)

Go
insert into Rooms values('A', 30)
insert into Rooms values('B', 50)
insert into Rooms values('H', 40)

GO
insert into Seats values(1, 0, 'A1')
insert into Seats values(1, 0, 'A2')
insert into Seats values(1, 0, 'A3')
insert into Seats values(1, 0, 'A4')
insert into Seats values(1, 0, 'A5')
insert into Seats values(1, 0, 'B1')
insert into Seats values(1, 0, 'B2')
insert into Seats values(1, 0, 'B3')
insert into Seats values(1, 0, 'B4')
insert into Seats values(1, 0, 'B5')

Go
insert into Movies values( N'Inception', 120, 1, '')
insert into Movies values( N'Pulp Fiction', 119, 1, '')
insert into Movies values( N'Little Women', 92, 1, '')
insert into Movies values( N'The Revenant', 115, 1, '')

Go
insert into Shows values(1, 100000, N'2023-10-30 14:30:00', N'2023-10-30 16:30:00', 1)
insert into Shows values(1, 100000, N'2023-10-30 7:30:00', N'2023-10-30 9:30:00', 1)
insert into Shows values(1, 100000, N'2023-10-30 10:30:00', N'2023-10-30 12:30:00', 2)
insert into Shows values(2, 120000, N'2023-10-30 14:30:00', N'2023-10-30 16:30:00', 3)
insert into Shows values(2, 120000, N'2023-10-30 7:30:00', N'2023-10-30 9:00:00', 3)

GO

