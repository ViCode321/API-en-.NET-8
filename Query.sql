USE [booking-database-01];

--USER
CREATE TABLE [User]
(
	UserId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	UserName VARCHAR(50) NOT NULL,
	Password VARCHAR(10) NOT NULL,
);

--Customer
CREATE TABLE [Customer]
(
	CustomerId INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(50) NOT NULL,
	DocumentNumber VARCHAR (8) NOT NULL,
);

CREATE TABLE [Booking]
(
	BookingId INT PRIMARY KEY IDENTITY,
	RegisterDate DATETIME NOT NULL,
	Code VARCHAR(50) NOT NULL,
	Type VARCHAR(50) NOT NULL,
	UserId INT NOT NULL,
	CustomerId INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User](UserId),
	FOREIGN KEY (CustomerId) REFERENCES [Customer](CustomerId),	
);

INSERT INTO [User] (FirstName, LastName, UserName, Password)
VALUES
('Juan', 'Pérez', 'juanperez', 'pass123'),
('Ana', 'García', 'anagarcia', 'pass456'),
('Carlos', 'Martínez', 'carlosm', 'password789');

INSERT INTO [Customer] (FullName, DocumentNumber)
VALUES
('Carlos Rodríguez', '12345678'),
('Laura Sánchez', '23456789'),
('Miguel López', '34567890');

INSERT INTO [Booking] (RegisterDate, Code, Type, UserId, CustomerId)
VALUES
('2024-12-10 10:00:00', 'BKG001', 'Hotel', 1, 1),
('2024-12-11 14:30:00', 'BKG002', 'Flight', 2, 2),
('2024-12-12 16:45:00', 'BKG003', 'Car Rental', 3, 3);


SELECT * FROM [User];

SELECT * FROM [Customer];

SELECT * FROM [Booking];
