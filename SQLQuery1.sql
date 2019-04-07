create table Patient
(
  PatientId int primary key identity(1,1),
  PatientName varchar(50) not null,
  Username varchar(50) unique not null,
  Password varchar(50) not null,
  Gender varchar(50) not null,
  PatientAddress varchar(50) not null,
  Email varchar(50) not null,
  ContactNo varchar(50) not null,
  BloodGroup varchar(50) not null
);

create table Doctor
(
  DoctorId int primary key identity(1,1),
  DoctorName varchar(50) not null,
  Username varchar(50) unique not null,
  Password varchar(50) not null,
  Email varchar(50) not null,
  Department varchar(50) not null,
  Qualification varchar(50) not null,
  Gender varchar(50) not null
);

create table Medicine
(
  MedicineId int primary key identity(1,1),
  BrandName varchar(50) not null,
  GenericName varchar(50) not null,
  Dosages varchar(50) not null,
  SideEffects varchar(255)
);

create table DoctorSchedule
(
  ScheduleId int primary key identity(1,1),
  DoctorId int foreign key references Doctor(DoctorId),
  DoctorName varchar(50) not null,
  TotalSlots int not null,
  DaysOfTheWeek varchar(255) not null,
  Time varchar(255) not null
);

create table Prescription
(
 PId int primary key identity(1,1),
 Symptoms varchar(255) not null,
 Diagnosis varchar(255) not null,
 Advice varchar(255) not null,
 Medication varchar(255),
 Date varchar(255) not null
);


CREATE TABLE [dbo].[Test] (
    [TestId]    INT           IDENTITY (1, 1) NOT NULL,
    [PatientId] INT           NOT NULL,
    [AssistantId]  INT           NOT NULL,
    [TestName]  VARCHAR (255) NOT NULL,
    [TestType]  VARCHAR (255) NOT NULL,
    [Findings]  VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([TestId] ASC),
    FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([PatientId]),
    CONSTRAINT [FK_Test_ToTable] FOREIGN KEY ([AssistantId]) REFERENCES [LabAssistant]([AssistantId])
);

CREATE TABLE [dbo].[Admin]
(
	[AdminId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Username] VARCHAR(50) NOT NULL UNIQUE, 
    [Email] VARCHAR(50) NOT NULL UNIQUE, 
    [Password] VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Appointment]
(
	[AppointmentId] INT NOT NULL PRIMARY KEY, 
    [DoctorId] INT NOT NULL, 
    [PatientId] INT NOT NULL, 
    [PrescriptionId] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    CONSTRAINT [FK_Appointment_ToTable] FOREIGN KEY ([DoctorId]) REFERENCES [Doctor]([DoctorId]), 
    CONSTRAINT [FK_Appointment_ToTable_1] FOREIGN KEY ([PatientId]) REFERENCES [Patient]([PatientId]), 
    CONSTRAINT [FK_Appointment_ToTable_2] FOREIGN KEY ([PrescriptionId]) REFERENCES [Prescription]([PId])
)

CREATE TABLE [dbo].[LabAssistant] (
    [AssistantId]      INT           IDENTITY (1, 1) NOT NULL,
    [AssistantName]    VARCHAR (50) NOT NULL,
    [Username]       VARCHAR (50) NOT NULL UNIQUE,
    [Password]       VARCHAR (50) NOT NULL,
    [Gender]         VARCHAR (50) NOT NULL,
    [ContactNo]      VARCHAR (50) NOT NULL,
    [BloodGroup]     VARCHAR (50) NOT NULL,
	[Email]     VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([AssistantId] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC) 
);

CREATE TABLE [dbo].[Payment]
(
	[PaymentId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [PatientId] INT NOT NULL, 
    [PaymentType] VARCHAR(10) NOT NULL, 
    [Amount] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    CONSTRAINT [FK_Table_ToTable] FOREIGN KEY ([PatientId]) REFERENCES [Patient]([PatientId])
)






