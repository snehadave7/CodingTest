
--1. Provide a SQL script that initializes the database for the Pet
--Adoption Platform ”PetPals”

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PetPals')
BEGIN
    CREATE DATABASE PetPals;
END;

use PetPals

--2. Create tables for pets, shelters, donations, adoption events,
--and participants.
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Pets')
begin
create table Pets (
PetId int identity primary key,
PetName varchar(20),
PetAge int,
PetBreed varchar(30),
Type varchar(20),
AvailableForAdoption bit 
)
end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Shelters')
Begin
create table Shelters(
ShelterId int identity primary key,
Name varchar(20),
Loaction varchar(20)
)
end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Donations')
begin
create table Donations(
DonationId int identity primary key,
DonorName varchar(20),
DonationType varchar(20) check (DonationType in('Cash','Item')),
DonationAmount decimal(10,2) default 0,
DonationItem varchar(20) default 0,
DonationDate datetime,
ShelterId int,
foreign key(shelterId) references shelters(shelterId)
)
end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'AdoptionEvents')
begin
create table AdoptionEvents(
Eventid int identity primary key,
EventNamne varchar(20),
EventDate datetime,
Location varchar(30)
)
end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Participants')
begin
create table Participants(
ParticipantId int identity Primary key,
ParticipantName varchar(20),
ParticipantType varchar(20) check (ParticipantType in('Shelter','Adopter')),
EventId int ,
foreign key(eventid) references AdoptionEvents(EventId)
)
end

insert into Pets values
('Simba',4,'Pomerian','Dog',0),
('Mia',3,'Persian','Cat',1),
('Lucy',1,'GermanShephered','Dog',0),
('Jackey',2,'Husky','Dog',1)

insert into Shelters values
('Kalyan','Kolar'),
('AnimalHouse','MPNagar'),
('WelfareClub','BHEL'),
('PetLovers','Lalghati')

insert into Donations values
('Sneha','Cash',5000,null,GETDATE(),1),
('Prashant','Item',null,'Food',GETDATE(),2),
('Perl','Cash',5000,null,GETDATE(),2),
('Ruby','Item',null,'Clothes',GETDATE(),3)

insert into AdoptionEvents values
('Pet Adoption Fair', '2024-10-01 10:00:00', 'City Park'),
('Dog Walkathon', '2024-10-15 09:00:00', 'Downtown Plaza'),
('Cat Adoption Day', '2024-11-01 11:00:00', 'Community Center'),
('Pet Care Workshop', '2024-11-20 14:00:00', 'Animal Shelter')

insert into Participants values
('Alice ', 'Shelter', 1),
('Bob ', 'Shelter', 2),
('Shreya', 'Adopter', 2),
('David', 'Adopter', 4);

-- QUERIES

--5 Write an SQL query that retrieves a list of available pets (those marked as available for adoption)
--from the "Pets" table. Include the pet's name, age, breed, and type in the result set. Ensure that
--the query filters out pets that are not available for adoption

select* from pets

select PetName,PetAge,PetAge,Type
from Pets
where AvailableForAdoption=1

--6 Write an SQL query that retrieves the names of participants (shelters and adopters) registered
--for a specific adoption event. Use a parameter to specify the event ID. Ensure that the query
--joins the necessary tables to retrieve the participant names and types.

select* from Participants
declare @EventId int
set @EventId=2
select p.participantname,p.participanttype
from participants p
join adoptionevents ae on p.eventid=ae.eventid
where p.eventid=@eventid;



--8 Write an SQL query that calculates and retrieves the total donation amount for each shelter (by
--shelter name) from the "Donations" table. The result should include the shelter name and the
--total donation amount. Ensure that the query handles cases where a shelter has received no
--donations
select*from Shelters
select* from Donations

select s.name as sheltername,COALESCE(SUM(DonationAmount), 0) as totaldonationamount
from donations d
right join shelters s on d.shelterid=s.shelterid
group by s.name

--9 Write an SQL query that retrieves the names of pets from the "Pets" table that do not have an
--owner (i.e., where "OwnerID" is null). Include the pet's name, age, breed, and type in the result
--set

alter table pets
add ParticipantId int

select PetName,PetAge,PetBreed,Type
from pets
where participantid is null

--10 Write an SQL query that retrieves the total donation amount for each month and year (e.g.,
--January 2023) from the "Donations" table. The result should include the month-year and the
--corresponding total donation amount. Ensure that the query handles cases where no donations
--were made in a specific month-year

select* from Donations

SELECT concat_ws('/',month(DonationDate), year(donationDate)) as MonthYear,
coalesce(SUM(DonationAmount),0) AS TotalDonation
FROM Donations
group by month(DonationDate),year(DonationDate)
ORDER BY MonthYear


--11 Retrieve a list of distinct breeds for all pets that are either aged between 1 and 3 years or older
--than 5 years.

SELECT DISTINCT PetBreed
FROM Pets
WHERE (PetAge BETWEEN 1 AND 3) OR PetAge > 5;

--12. Retrieve a list of pets and their respective shelters where the pets are currently available for
--adoption.

select*from pets
select*from Shelters
alter table pets
add shelterid int
alter table pets
add constraint FK_Pet_shelter
foreign key(shelterid) references shelters(shelterid)


SELECT Pets.PetName AS PetName, Shelters.Name AS ShelterName
FROM Pets
JOIN Shelters ON Pets.ShelterID = Shelters.ShelterID
WHERE Pets.AvailableForAdoption = 1;


13. Find the total number of participants in events organized by shelters located in specific city.
--Example: City=kolar

select*from Shelters
select*from AdoptionEvents
SELECT COUNT(Participants.ParticipantID) AS TotalParticipants
FROM Participants
JOIN AdoptionEvents ON Participants.EventID = AdoptionEvents.EventID
JOIN Shelters ON AdoptionEvents.Location = Shelters.Loaction
WHERE Shelters.Loaction = 'bhel';


14. Retrieve a list of unique breeds for pets with ages between 1 and 5 years.
SELECT DISTINCT PetBreed

FROM Pets
WHERE PetAge BETWEEN 1 AND 5;

15. Find the pets that have not been adopted by selecting their information from the 'Pet' table.

SELECT PetName, PetAge, PetBreed, Type
FROM Pets
WHERE ParticipantId IS NULL;


--16. Retrieve the names of all adopted pets along with the adopter's name from the 'Adoption' and
--'User' tables.

select*from participants
select*from pets

select participantname as AdopterName,petName
from participants as p join pets on p.participantid=pets.participantid
where ParticipantType='adopter'

17. Retrieve a list of all shelters along with the count of pets currently available for adoption in each
shelter.

select s.name as sheltername,count(p.petid) as availablepetscount
from shelters s
left join pets p on s.shelterid=p.shelterid
where p.availableforadoption=1
group by s.name


18. Find pairs of pets from the same shelter that have the same breed.

select* from pets
select * from Shelters
SELECT p1.petName AS Pet1, p2.petName AS Pet2, p1.petBreed
FROM Pets p1
JOIN Pets p2 ON p1.ShelterID = p2.ShelterID AND p1.petBreed = p2.petBreed 
AND p1.PetID != p2.PetID;


19. List all possible combinations of shelters and adoption events.

select* from AdoptionEvents
select* from Shelters
SELECT Shelters.Name AS ShelterName,Shelters.Loaction, AdoptionEvents.EventNamne,AdoptionEvents.EventDate,AdoptionEvents.Location
FROM Shelters
CROSS JOIN AdoptionEvents;

20. Determine the shelter that has the highest number of adopted pets.

select*from shelters
select* from pets

SELECT top 1 S.Name AS ShelterName, COUNT(P.PetId) AS AdoptedPetsCount
FROM Shelters S
JOIN Pets P ON S.ShelterId = P.ShelterId
WHERE P.AvailableForAdoption = 1  -- Only consider adopted pets
GROUP BY S.Name
ORDER BY  AdoptedPetsCount DESC
 -- Get the shelter with the highest count
