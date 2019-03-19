create table Patient
(
  PatientId int primary key identity(1,1),
  PatientName varchar(255) not null,
  Username varchar(255) unique,
  Password varchar(255),
  Gender varchar(255) not null,
  PatientAddress varchar(255) not null,
  ContactNo varchar(255) not null,
  BloodGroup varchar(255) not null
);

create table Doctor
(
  DoctorId int primary key identity(1,1),
  DoctorName varchar(255) not null,
  Department varchar(255) not null,
  Qualification varchar(255) not null,
  Gender varchar(255) not null
);

create table Medicine
(
  MedicineId int primary key identity(1,1),
  BrandName varchar(255) not null,
  GenericName varchar(255) not null,
  Dosages varchar(255) not null,
  SideEffects varchar(255)
);

create table DoctorSchedule
(
  ScheduleId int primary key identity(1,1),
  DoctorId int foreign key references Doctor(DoctorId),
  DoctorName varchar(255) not null,
  TotalSlots int not null,
  DaysOfTheWeek varchar(255) not null,
  Time varchar(255) not null
);

create table Prescription
(
 PId int primary key identity(1,1),
 DoctorId int foreign key references Doctor(DoctorId),
 PatientId int foreign key references Patient(PatientId),
 Symptoms varchar(255) not null,
 Diagnosis varchar(255) not null,
 Advice varchar(255) not null,
 Medication varchar(255),
 Date varchar(255) not null
);


create Table Test
(
  TestId int primary key identity(1,1),
  PatientId int foreign key references Patient(PatientId),
  DoctorId int foreign key references Doctor(DoctorId),
  TestName varchar(255) not null,
  TestType varchar(255) not null,
  Findings varchar(255),
);


