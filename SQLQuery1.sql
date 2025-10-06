create database DBGYM;
use DBGYM;

CREATE TABLE Subscriber (
    Id int PRIMARY KEY,
    Name varchar(50),
    DOB date,
    National_ID int,
    Phone int
);

CREATE TABLE Coach (
    Id int PRIMARY KEY,
    Name varchar(50),
    DOB date,
    National_ID int,
    Phone int
);

CREATE TABLE responsible (
    Id int PRIMARY KEY,
    Name_responsible varchar(50),
    DOB date,
    Phone int,
    UserName varchar(50),
    Pass varchar(50)
);

CREATE TABLE Fitness_Department (
   F_id int PRIMARY KEY,
   S_id_C INT FOREIGN KEY REFERENCES Subscriber(Id),
   C_id_C INT FOREIGN KEY REFERENCES Coach(Id)
);

CREATE TABLE Iron_section (
   I_id INT PRIMARY KEY,
   S_id_I INT FOREIGN KEY REFERENCES Subscriber(Id),
   C_id_I INT FOREIGN KEY REFERENCES Coach(Id)
);

CREATE TABLE Boxing_Department (
   B_id INT PRIMARY KEY,
   S_id_B INT FOREIGN KEY REFERENCES Subscriber(Id),
   C_id_B INT FOREIGN KEY REFERENCES Coach(Id)
);


Insert into responsible(Id,Name_responsible,DOB,Phone,UserName,Pass) VALUES(
1,
'Sultan',
'2004-09-27',
778393182,
'sul',
'123');


select UserName,pass from responsible 
