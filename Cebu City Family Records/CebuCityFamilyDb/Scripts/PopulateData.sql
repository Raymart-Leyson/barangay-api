USE [CebuCityFamilyDb]
GO

SET IDENTITY_INSERT [Barangay] ON
INSERT [Barangay] ([Id], [Name], [Captain]) 
VALUES 
    (1, 'Tisa', 'Arlee Cathesyed'),
    (2, 'Lahug', 'Brander Andrich'),
    (3, 'Basak', 'Tam Duck'),
    (4, 'Talamban', 'Clayton Porte');
SET IDENTITY_INSERT [Barangay] OFF

INSERT INTO [Family] (Name,Sitio,BId)
VALUES
  ('Uppett','Sidlakan',1),
  ('Pedro','Motra',1),
  ('Joerning','Panas',2),
  ('Berrick','Plaza',2),
  ('Kezar','Ulap',3),
  ('McGow','Guinabsan',3),
  ('Jakeway','Tago',4),
  ('Matashkin','Upper Tayong',4);


INSERT INTO [FamilyMembers] (Name,FId)
VALUES
  ('Andonis Uppett',1),
  ('Andeee Uppett',1),
  ('Velma Uppett',1),
  ('Penrod Pedro',2),
  ('Floris Pedro',2),
  ('Eduardo Pedro',2),
  ('Maxine Joerning',3),
  ('Raine Joerning',3),
  ('Dorothea Joerning',3),
  ('Clemmy Berrick',4),
  ('Brennen Berrick',4),
  ('Culley Berrick',4),
  ('Ardys Kezar',5),
  ('Marlena Kezar',5),
  ('Chicky Kezar',5),
  ('Ambrosi McGow',6),
  ('Glenda McGow',6),
  ('Shelby McGow',6),
  ('Aura Jakeway',7),
  ('Livvie Jakeway',7),
  ('Odele Jakeway',7),
  ('Rubetta Matashkin',8),
  ('Arlen Matashkin',8),
  ('Brewer Matashkin',8);

INSERT INTO [Details] (Age,CivilStatus,DateOfBirth,Gender,Occupation,PhoneNumber,Religion,FmId)
VALUES
  (27,'Married','01/01/1995','Male','Scaffolder','+63-933-555-3103','Roman Catholic',1),
  (21,'Married','02/01/2001','Female','Lecturer','+63-932-555-9092','Roman Catholic',2),
  (10,'Single','03/01/2012','Female','Student','+63-932-555-3309','Roman Catholic',3),
  (52,'Married','04/01/1970','Male','Debt collector','+63-929-555-4046','Roman Catholic',4),
  (51,'Married','05/01/1971','Female','Caretaker','+63-929-555-9803','Roman Catholic',5),
  (25,'Single','06/01/1995','Male','Managing director','+63-919-555-7530','Roman Catholic',6),
  (44,'Married','07/01/1978','Female','Computer analyst','+63-280-555-1238','Roman Catholic',7),
  (45,'Married','08/01/1977','Male','Postal delivery worker','+63-932-555-2457','Roman Catholic',8),
  (22,'Single','09/01/2000','Female','Chemist','+63-919-555-2698','Roman Catholic',9),
  (44,'Married','07/01/1978','Male','Doorman','+63-929-555-3929','Roman Catholic',10),
  (45,'Married','08/01/1977','Female','Waiter','+63-932-555-3054','Roman Catholic',11),
  (22,'Single','09/01/2000','Male','Shoemaker','+63-919-555-1448','Roman Catholic',12),
  (40,'Married','10/01/1982','Male','Crane driver','+63-932-555-2216','Roman Catholic',13),
  (34,'Married','01/02/1988','Female','Occupational therapist','+63-283-555-4736','Roman Catholic',14),
  (17,'Single','02/02/2005','Female','Student','+63-929-555-2545','Roman Catholic',15),
  (27,'Married','01/01/1995','Male','Photographer','+63-280-555-7472','Roman Catholic',16),
  (21,'Married','02/01/2001','Female','Flying instructor','+63-280-555-7472','Roman Catholic',17),
  (10,'Single','03/01/2012','Female','Student','+63-919-555-1079','Roman Catholic',18),
  (52,'Married','04/01/1970','Male','Lift engineer','+63-283-555-2491','Roman Catholic',19),
  (51,'Married','05/01/1971','Female','Photographer','+63-283-555-5054','Roman Catholic',20),
  (25,'Single','06/01/1995','Female','Hairdresser','+63-919-555-6298','Roman Catholic',21),
  (22,'Single','09/01/2000','Female','IT consultant','+63-919-555-2756','Roman Catholic',22),
  (44,'Married','07/01/1978','Female','Auctioneer','+63-928-555-3380','Roman Catholic',23),
  (45,'Married','08/01/1977','Male','Roofer','+63-928-555-0226','Roman Catholic',24);