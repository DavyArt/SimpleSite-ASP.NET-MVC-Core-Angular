create database sitedb

go
use sitedb

create table Company
(CompanyId int not null identity(1, 1),
Name varchar(100) not null unique,
constraint Company_PK primary key(CompanyId))

create table Employee
(EmployeeId int not null identity(1, 1),
CompanyId int not null,
Position varchar(50) not null,
F varchar(50) not null,
I varchar(50) not null,
O varchar(50) not null,
EmploymentDate date not null,
constraint Employee_PK primary key(EmployeeId),
constraint Employee_CompanyFK foreign key(CompanyId) references Company(CompanyId) on update cascade on delete cascade)