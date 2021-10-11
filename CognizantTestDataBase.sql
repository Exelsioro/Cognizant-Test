create database Cognizant_Test
use Cognizant_Test
create table Task (
	Id int not null identity(1,1) primary key,
	TaskName nvarchar(50) not null,
	TaskDescription nvarchar(max) not null,
	TaskSolution nvarchar(max) not null,
	TaskTestingParameters nvarchar(max)
)

create table Player(
	Id int not null identity(1,1) primary key,
	[Name] nvarchar(100) not null,
	CONSTRAINT UName UNIQUE([Name])  
)

create table TaskSolutions(
	Id int not null identity(1,1) primary key,
	PlayerId int not null,
	TaskId int not null,
	PlayerTaskSolution nvarchar(max) not null,
	IsSolutionCorrect bit 
)
