 
 CREATE TABLE Owners (
  id INT PRIMARY KEY AUTO_INCREMENT,
  Names VARCHAR(125) ,
  LastNames VARCHAR(125) ,
  Email VARCHAR(125) UNIQUE ,
  Phone VARCHAR(125) ,
  Address VARCHAR(125) 
);

DROP  TABLE Pets


 CREATE TABLE Pets(
  id INT PRIMARY KEY AUTO_INCREMENT,
  Name VARCHAR(125) ,
  Specie VARCHAR(125) ,
  Race VARCHAR(125),
  DateBirth DATE,
  phone VARCHAR(125),
  OwnerId INT,
  FOREIGN KEY (OwnerId) REFERENCES Owners(id)
);

 DROP table Pets

 DROP table owners


 DROP table Vets

 DROP table Quotes


 DROP table Pets

 DROP table owners





 CREATE TABLE Vets (
  id INT PRIMARY KEY AUTO_INCREMENT,
  Name VARCHAR(125) ,
  Email VARCHAR(125) UNIQUE,
  Phone VARCHAR(125) ,
  Address VARCHAR(125) 
);

CREATE TABLE  Quotes (
  id INT PRIMARY KEY AUTO_INCREMENT,
  DATE DATETIME ,
  Description VARCHAR(125) ,
  PetId INT,
  VetId INT,
  FOREIGN KEY (PetId) REFERENCES Pets(id),
  FOREIGN KEY (VetId) REFERENCES Vets(id)
);

INSERT INTO Vets (Name, Email,Phone, Address) 
VALUES 
    ('Jorge','jorge@example.com','320255874', 'Argentina')




