


--LAB 2--
--Completed by Gerda + Sofie


CREATE DATABASE BokHandel
GO

USE BokHandel
GO

--Creating Tables 

CREATE TABLE Authors(
	[ID] int IDENTITY NOT NULL,
	[FirstName] nvarchar(255) NOT NULL,
	[LastName] nvarchar(255) NOT NULL,
	[DateOfBirth] date NOT NULL
	PRIMARY KEY (Id)
);
GO

CREATE TABLE Publishers(
	[Publisher_ID] int IDENTITY,  
	[Publischer_Name] nvarchar(50),
	[Publisher_Address] nvarchar(50),
	[Telephone_Number] nvarchar(30)
	PRIMARY KEY(Publisher_ID),
)
GO

CREATE TABLE Genres(
	[Genre_ID] int,  
	[Genre] nvarchar(50),
	PRIMARY KEY(Genre_ID)
)
GO

CREATE TABLE Books(
	[ISBN_ID] nvarchar(13)NOT NULL,
	[Title] nvarchar(50) NOT NULL,
	[Language] nvarchar(50),
	[Page_Numbers] int,
	[Price(SEK)] money,
	[Release_Date] datetime2(7),
	[Author_ID] int, 
	[Genre_ID] int, 
	[Publishers_ID] int 
	PRIMARY KEY(ISBN_ID)
	
)
GO

CREATE TABLE Inventory(
	[Shop_ID] nvarchar(6),  
	[ISBN_ID] nvarchar(13),  
	[Quantity] int
	PRIMARY KEY (Shop_ID,ISBN_ID)
	FOREIGN KEY (ISBN_ID) REFERENCES Books(ISBN_ID)
)
GO


CREATE TABLE Shops(
	[Shop_ID] nvarchar(6), 
	[Shop_Name] nvarchar(50),
	[Shop_Address] nvarchar(100),
	[Shop_Town] nvarchar(100),
	[Shop_ContactNumber] nvarchar(30),
	PRIMARY KEY (Shop_ID)
)
GO

--Inserting Authors into Author table

INSERT INTO Authors (FirstName, LastName, DateOfBirth)
VALUES ('Stephenie', 'Meyer', '1973/12/24')

INSERT INTO Authors (FirstName, LastName, DateOfBirth)
VALUES ('Stephan', 'King', '1947/09/21')

INSERT INTO Authors (FirstName, LastName, DateOfBirth)
VALUES ('Camilla', 'Läckberg', '1974/08/30')

INSERT INTO Authors (FirstName, LastName, DateOfBirth)
VALUES ('Joanne', 'Rowling', '1965/07/31')

INSERT INTO Authors (FirstName, LastName, DateOfBirth)
VALUES ('Carlin', 'Barton', '1948/12/03')

GO

SELECT * FROM Authors

GO

SELECT FirstName + ' ' + LastName AS 'Full Name', DateOfBirth
FROM Authors
ORDER BY DateOfBirth DESC

GO

--Inserting Genres into Genre table

INSERT INTO Genres (Genre_ID, Genre)
VALUES 
(1, 'Action'),
(2, 'Adventure'),
(3, 'Romance'),
(4, 'Fiction'),
(5, 'Fantasy'),
(6,'Horror'),
(7,'Young Adult'),
(8,'Classics'),
(9,'Graphic Novels'),
(10, 'Mystery'),
(11,'Detective'),
(12,'History'),
(13,'Historical Fiction'),
(14,'Science Fiction'),
(15,'Short Stories'),
(16,'Suspence'),
(17,'Thriller'),
(18,'Biographies'),
(19,'Cookbooks'),
(20,'Memoir'),
(21,'Poetry'),
(22,'Self-Help'),
(23,'True Crime'),
(24, 'Childrens book')

GO

SELECT * FROM Genres

GO

--All books with associated genre

SELECT g.Genre_ID, b.Title, g.Genre
FROM Genres g
INNER JOIN Books b ON b.Genre_ID = g.Genre_ID
ORDER BY g.Genre_ID

GO

--Inserting Publisher Data into Publisher Table

INSERT INTO Publishers(
	[Publischer_Name],
	[Publisher_Address],
	[Telephone_Number]  
)
VALUES (
	'Bloomsbury',
	'31 Bedford Avenue, London, United Kingdom',
	'+44 (0)20 7631 5600'
	)
GO


INSERT INTO Publishers(
	[Publischer_Name],
	[Publisher_Address],
	[Telephone_Number]
)

VALUES(
	'Forum Bokförlag',
	'Sveavägen 56, Stockholm, Sweden',
	'08-696 84 40'
)
GO

INSERT INTO Publishers(
	[Publischer_Name],
	[Publisher_Address],
	[Telephone_Number]  
)
VALUES(
	'University of California Press',
	'155 Grand Ave, Oakland, United States',
	'+1-5108838232'
	)
GO

INSERT INTO Publishers(
	[Publischer_Name],
	[Publisher_Address],
	[Telephone_Number] 
)
VALUES(
	'Hodder Paperback',
	'50 Victoria Embankment, London, United Kingdom',
	'+44 (0)20 7631 5600'
)
GO

INSERT INTO Publishers(
	[Publischer_Name],
	[Publisher_Address],
	[Telephone_Number] 
)
VALUES(
	'Hodder Stoughton',
	'50 Victoria Embankment, London, United Kingdom',
	' +44 (0)20 7631 5600'
)
GO

INSERT INTO Publishers(
	[Publischer_Name],
	[Publisher_Address],
	[Telephone_Number]  
)
VALUES(
	'Hatchette Collections',
	'47 Brunswick Place, London, Inited Kingdom',
	'+44 (01)33 3907 9762'
)
GO

INSERT INTO Publishers(
	[Publischer_Name],
	[Publisher_Address],
	[Telephone_Number] 
)
VALUES(
	'Little, Brown & Company',
	'8125 Mill Pond St., New York, United States',
	'+1-202 555 0178'
)
GO

SELECT * FROM Publishers

GO

--Inserting test data into Books table

INSERT INTO Books(
	[ISBN_ID], 
	[Title], 
	[Language], 
	[Page_Numbers], 
	[Price(SEK)], 
	[Release_Date], 
	[Author_ID], 
	[Genre_ID], 
	[Publishers_ID]
	)
VALUES
('9780316015844', 'Twilight', 'English', 483, 126.26, '2006/06/01', 1, 7, 7),
('9781904233886', 'New Moon', 'English', 512, 95, '2007/01/01', 1,7, 7),
('9781904233916', 'Eclipse', 'English', 559, 75.13,'2008/07/03', 1, 7, 7),
('9781907410352', 'Breaking Dawn', 'English', 720, 95, '2010/04/01', 1, 7, 7),
('9781444720693', 'Carrie', 'English', 275, 67, '2011/10/13',  2, 6, 4),
('9781444708141', 'Salems Lot', 'English', 768, 132, '2001/11/10', 2, 6, 5),
('9781444720723', 'The Shinning', 'English', 497, 108.87, '2011/11/10',2, 6, 6),
('9781444720730', 'The Stand', 'English', 1344, 131, '2011/05/12', 2, 6, 5),
('9781444723601', 'Different Seasons', 'English', 688, 131, '2012/06/07', 2, 6, 4),
('9781444708134', 'Pet Sematary:A Pet Isnt Just For Life', 'English',480, 95, '2011/11/19',2,6,4),
('9780520225251', 'Roman Honor:The Fire in the Bones', 'English', 401, 558.70, '2001/06/04', 5,12,3),
('9789175037431','Isprinsessan','Swedish',320,64,'2017/04/07',3,11, 2),
('9789175037493','Predikanten','Swedish',318,69,'2017/04/07',3,11, 2),
('9789175037509','Stenhuggaren','Swedish',406,75,'2011/09/09',3,11, 2),
('9781408855898','Harry Potter and The Philosophers Stone','English',352,187,'1997/06/26',4,5, 1),
('9781408855669','Harry Potter and The Chamber of Secrets','English',384,183,'2001/11/03',4,5, 1),
('9781408855676','Harry Potter and The Prisoner of Azkaban','English',480,189,'2004/05/31',4,5, 1),
('9781408855683','Harry Potter and The Goblet of Fire','English',640,205,'2005/11/18',4,5, 1),
('9781408855690','Hary Potter and The Order of Phoenix','English',860,361,'2007/07/12',4,5, 1),
('9781408855706','Harry Potter and The Half-Blood Prince','English',560,205,'2009/07/15',4,5, 1),
('9781408855713','Harry Potter and The Deathly Hallows','English',640,205,'2010/11/19',4,5, 1),
('9780751565362','Harry Potter and The Cursed Child','English',352,110,'2016/07/31',4,5, 1)

GO

--All info on books

SELECT * FROM Books

GO

--All books, book language and prices

SELECT Title, Language, [Price(SEK)]
FROM Books

GO

--All books with associated Author,genre and price

SELECT b.Title, a.FirstName + ' '+ a.LastName AS 'Author', g.Genre, g.Genre_ID, b.[Price(SEK)]
FROM Books b 
JOIN Genres g ON g.Genre_ID = b.Genre_ID
JOIN Authors a ON a.ID = b.Author_ID
ORDER BY Genre


GO

--All books with pagenumber over 400

SELECT Title, [Price(SEK)]
FROM Books
WHERE Page_Numbers >= 400

GO

--Adding Inventory Data

CREATE UNIQUE INDEX Inventory on Inventory (Shop_ID, ISBN_ID)

INSERT INTO Inventory(Shop_Id, ISBN_ID, Quantity)
VALUES
('AKANYK','9781904233886', 1),
('AKANYK','9781904233916', 15),
('AKANYK','9781907410352', 1),
('AKANYK','9780316015844', 3),
('AKANYK','9781444708134', 4),
('AKANYK','9781444708141', 1),
('AKANYK','9781444720693', 7),
('AKANYK','9781444720723', 6),
('AKANYK','9781444720730', 4),
('AKANYK','9781444723601', 12),
('AKANYK','9789175037431', 20),
('AKANYK','9789175037493', 11),
('AKANYK','9789175037509', 15),
('AKANYK','9780751565362', 10),
('AKANYK','9781408855669', 5),
('AKANYK','9781408855676', 4),
('AKANYK','9781408855683', 12),
('AKANYK','9781408855690', 4),
('AKANYK','9781408855706', 1),
('AKANYK','9781408855713', 5),
('AKANYK','9781408855898', 3),
('AKANYK','9780520225251', 14),

('DROILD','9781904233886', 3),
('DROILD','9781904233916', 1),
('DROILD','9781907410352', 13),
('DROILD','9780316015844', 4),
('DROILD','9781444708134', 5),
('DROILD','9781444708141', 2),
('DROILD','9781444720693', 5),
('DROILD','9781444720723', 0),
('DROILD','9781444720730', 2),
('DROILD','9781444723601', 12),
('DROILD','9789175037431', 1),
('DROILD','9789175037493', 13),
('DROILD','9789175037509', 14),
('DROILD','9780751565362', 11),
('DROILD','9781408855669', 0),
('DROILD','9781408855676', 3),
('DROILD','9781408855683', 4),
('DROILD','9781408855690', 5),
('DROILD','9781408855706', 6),
('DROILD','9781408855713', 1),
('DROILD','9781408855898', 4),
('DROILD','9780520225251', 2),

('ENGSHO','9781904233886', 0),
('ENGSHO','9781904233916', 2),
('ENGSHO','9781907410352', 4),
('ENGSHO','9780316015844', 1),
('ENGSHO','9781444708134', 2),
('ENGSHO','9781444708141', 4),
('ENGSHO','9781444720693', 1),
('ENGSHO','9781444720723', 5),
('ENGSHO','9781444720730', 1),
('ENGSHO','9781444723601', 5),
('ENGSHO','9789175037431', 2),
('ENGSHO','9789175037493', 4),
('ENGSHO','9789175037509', 4),
('ENGSHO','9780751565362', 12),
('ENGSHO','9781408855669', 3),
('ENGSHO','9781408855676', 4),
('ENGSHO','9781408855683', 5),
('ENGSHO','9781408855690', 1),
('ENGSHO','9781408855706', 2),
('ENGSHO','9781408855713', 4),
('ENGSHO','9781408855898', 4),
('ENGSHO','9780520225251', 3),

('HEDDEL','9781904233886', 2),
('HEDDEL','9781904233916', 4),
('HEDDEL','9781907410352', 5),
('HEDDEL','9780316015844', 1),
('HEDDEL','9781444708134', 0),
('HEDDEL','9781444708141', 8),
('HEDDEL','9781444720693', 5),
('HEDDEL','9781444720723', 5),
('HEDDEL','9781444720730', 3),
('HEDDEL','9781444723601', 1),
('HEDDEL','9789175037431', 3),
('HEDDEL','9789175037493', 5),
('HEDDEL','9789175037509', 4),
('HEDDEL','9780751565362', 11),
('HEDDEL','9781408855669', 3),
('HEDDEL','9781408855676', 2),
('HEDDEL','9781408855683', 1),
('HEDDEL','9781408855690', 2),
('HEDDEL','9781408855706', 3),
('HEDDEL','9781408855713', 5),
('HEDDEL','9781408855898', 6),
('HEDDEL','9780520225251', 6),

('SFTORE','9781904233886', 3),
('SFTORE','9781904233916', 1),
('SFTORE','9781907410352', 3),
('SFTORE','9780316015844', 5),
('SFTORE','9781444708134', 1),
('SFTORE','9781444708141', 4),
('SFTORE','9781444720693', 1),
('SFTORE','9781444720723', 5),
('SFTORE','9781444720730', 6),
('SFTORE','9781444723601', 2),
('SFTORE','9789175037431', 1),
('SFTORE','9789175037493', 4),
('SFTORE','9789175037509', 5),
('SFTORE','9780751565362', 12),
('SFTORE','9781408855669', 4),
('SFTORE','9781408855676', 4),
('SFTORE','9781408855683', 5),
('SFTORE','9781408855690', 6),
('SFTORE','9781408855706', 6),
('SFTORE','9781408855713', 2),
('SFTORE','9781408855898', 3),
('SFTORE','9780520225251', 3)

GO

SELECT * FROM Inventory

GO
--All stores and quantity
SELECT SHOP_ID, SUM(Quantity) AS 'Total Books' FROM Inventory
GROUP BY Shop_ID

GO

--Singel store and quantity
SELECT SHOP_ID, SUM(Quantity) AS 'Total Books' FROM Inventory
WHERE Shop_ID = 'HEDDEL'
GROUP BY Shop_ID

GO

-- Adding Shops data

INSERT INTO Shops(
	[Shop_ID], 
	[Shop_Name],
	[Shop_Address],
	[Shop_ContactNumber],
	[Shop_Town]
	)
VALUES(
	'AKANYK',
	'Akademibokhandeln',
	'Västra Storgatan 32',
	'0155291930',
	'Nyköping')

INSERT INTO Shops(
	[Shop_ID], 
	[Shop_Name],
	[Shop_Address],
	[Shop_ContactNumber],
	[Shop_Town]
	)
VALUES(
	'ENGSHO',
	'The English Bookshop',
	'Södermannagatan 22',
	'087905510',
	'Stockholm')

INSERT INTO Shops(
	[Shop_ID], 
	[Shop_Name],
	[Shop_Address],
	[Shop_ContactNumber],
	[Shop_Town]
	)
VALUES(
	'SFTORE',
	'SF Bookstore',
	'Västerlånggatan 48',
	'082135052',
	'Stockholm')

INSERT INTO Shops(
	[Shop_ID], 
	[Shop_Name],
	[Shop_Address],
	[Shop_ContactNumber],
	[Shop_Town]
	)
VALUES(
	'HEDDEL',
	'Hedengrens Bokhandel AB',
	'Grev Turegatan 13',
	'086115128',
	'Stockholm')

INSERT INTO Shops(
	[Shop_ID], 
	[Shop_Name],
	[Shop_Address],
	[Shop_ContactNumber],
	[Shop_Town]
	)
VALUES(
	'DROILD',
	'Drottninggatans Bok & Bild',
	'Drottninggatan 9',
	'08101507',
	'Stockholm'
	)

	GO

SELECT * FROM Shops

GO

--Info of singel shop
SELECT Shop_Name, Shop_Address, Shop_Town FROM Shops
WHERE Shop_Town = 'Nyköping'

GO
	
-- Adding FOREIGN KEYS 

ALTER TABLE Books
ADD FOREIGN KEY(Publishers_ID) REFERENCES Publishers(Publisher_ID)

GO
	
ALTER TABLE Books
ADD FOREIGN KEY(Author_ID) REFERENCES Authors(ID)

GO

ALTER TABLE Books
ADD FOREIGN KEY(Genre_ID) REFERENCES Genres(Genre_ID)

GO

ALTER TABLE Inventory
ADD FOREIGN KEY(Shop_ID) REFERENCES Shops(Shop_ID)

GO

-- Creating View to see total stock value per Author

CREATE OR ALTER VIEW [Titles_Per_Authors] AS
SELECT a.FirstName + ' ' + a.LastName AS 'Author',
DATEDIFF(YEAR, a.DateOfBirth, GetDate()) AS 'Age',
COUNT(DISTINCT b.Title ) AS 'Total Titles',
SUM(i.Quantity * b.[Price(SEK)]) AS 'Stock Value' 
FROM Authors a
INNER JOIN Books b ON b.Author_ID = a.ID
INNER JOIN Inventory i ON i.ISBN_ID = b.ISBN_ID
Group By FirstName, LastName, DateOfBirth

GO

SELECT * FROM Titles_Per_Authors
ORDER BY [Stock Value]

GO