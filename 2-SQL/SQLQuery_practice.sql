SELECT * FROM Track;

SELECT * FROM Track WHERE GenreId = 2;

SELECT Firstname, LastName, CustomerId, Country FROM Customer WHERE Country != 'USA';

SELECT Firstname,LastName, CustomerId, Country FROM Customer WHERE Country = 'Brazil';

SELECT * FROM Employee WHERE Title = 'Sales Support Agent';

SELECT BillingCountry FROM Invoice;

SELECT * FROM Invoice WHERE YEAR (InvoiceDate) = 2009;
SELECT YEAR (InvoiceDate) AS 'Year', COUNT(*) AS 'Total Sales' FROM Invoice GROUP BY YEAR(InvoiceDate);

SELECT SUM(Quantity) AS 'Line Items' FROM InvoiceLine WHERE InvoiceId = 37;

SELECT BillingCountry AS 'Country', COUNT(*) AS 'Invoices' FROM Invoice GROUP BY BillingCountry;

SELECT BillingCountry AS 'Country', COUNT(*) AS 'Invoices' FROM Invoice GROUP BY BillingCountry ORDER BY SUM(Total) DESC;

-- join exercises (Chinook database)
-- 1. show all invoices of customers from brazil (mailing address not billing)
SELECT * FROM Invoice 
LEFT JOIN Customer ON Customer.CustomerId = Invoice.InvoiceId
WHERE Customer.Country = 'Brazil';

-- 2. show all invoices together with the name of the sales agent of each one
SELECT Invoice.*, Employee.FirstName, Employee.LastName FROM Employee -- figure it out
	RIGHT JOIN Customer ON Employee.EmployeeId = Customer.CustomerId
	RIGHT JOIN Invoice ON Customer.SupportRepId = invoice.CustomerId;

SELECT i.*, e.FirstName, e.LastName
FROM Invoice AS i
	LEFT JOIN Customer AS c ON i.CustomerId = c.CustomerId
	LEFT JOIN Employee AS e ON c.SupportRepId = e.EmployeeId;

-- 3. show all playlists ordered by the total number of tracks they have
SELECT Playlist.PlaylistId, Playlist.Name, COUNT(*) AS 'Number of Tracks' 
FROM Playlist
	LEFT JOIN PlaylistTrack ON Playlist.PlaylistId = PlaylistTrack.PlaylistId
GROUP BY Playlist.PlaylistId, Playlist.Name;

-- 4. which sales agent made the most in sales in 2009?
SELECT Employee.FirstName AS 'Name', SUM(Invoice.Total) AS 'Total Sales' FROM Employee
	JOIN Customer ON Customer.SupportRepId = Employee.EmployeeId
	JOIN Invoice ON Invoice.CustomerId = Customer.CustomerId
GROUP BY Employee.FirstName;

-- 5. how many customers are assigned to each sales agent?
SELECT Employee.FirstName, COUNT(Customer.CustomerId) FROM Employee
	JOIN Customer ON Customer.SupportRepId = Employee.EmployeeId
GROUP BY Employee.FirstName;

-- 6. which track was purchased the most since 2010?
SELECT t.TrackId, count(t.TrackId) AS count
FROM InvoiceLine AS il
	JOIN Invoice AS i ON i.InvoiceId = il.InvoiceId
	JOIN Track AS t ON t.TrackId = il.TrackId
WHERE i.InvoiceDate between '2010-01-01' AND '2010-12-31'
GROUP BY t.TrackId
ORDER BY count DESC;

-- 7. show the top three best-selling artists.

-- 8. which customers have the same initials as at least one other customer?


-- 1. which artists did not make any albums at all?
 SELECT Name FROM Artist
 WHERE ArtistId NOT IN (
	 SELECT ArtistId FROM Album
 );

SELECT ArtistId FROM Artist
EXCEPT
SELECT ArtistId FROM Album; 


-- 2. which artists did not record any tracks of the Latin genre?



-- DML Exercises
-- 1. insert two new records into the employee table.
SELECT * FROM Employee;
INSERT INTO Employee (EmployeeId, FirstName, LastName) VALUES (9, 'Kirti', 'Patel'), (10, 'Yash', 'Patel');

-- 2. insert two new records into the tracks table.
SELECT * FROM Track;
INSERT INTO Track (TrackId, Name, AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice) 
VALUES (4000, 'Bollywood', 3, 3, 3, 'Kirti', 34567, 5678, 100), (5000, 'LOL', 4, 4, 4, 'Yash', 45678, 6789, 100);

-- 3. update customer Aaron Mitchell's name to Robert Walter
SELECT * FROM Customer;
UPDATE Customer
	SET FirstName = 'Robert', LastName = 'Walter'  -- Without WHERE, would modify every row
		WHERE CustomerId = 32;

-- 4. delete one of the employees you inserted.
DELETE FROM Employee
		WHERE EmployeeId = 10;

-- 5. delete customer Robert Walter.
	-- look at the git hub and do it 