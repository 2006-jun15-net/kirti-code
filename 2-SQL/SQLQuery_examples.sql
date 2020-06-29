SELECT 'Hello World!';

SELECT '9' + CONVERT(VARCHAR, 4 + 5);

SELECT * 
    FROM Employee;

SELECT FirstName, Lastname 
    FROM Employee;



-- in SQL, indexes start with 1
-- text comparison is case sensitive by default (controlled by COLLATION)
-- the LIKE operator takes a special templet string to compare with
--      _ means any one character
--      % means any characters
--      [abc] means one of a, b, or c.

SELECT FirstName, LastName 
    FROM Employee
    WHERE LastName >= 'p' AND LastName < 'q'; -- with all employees with last name first letter of P

SELECT FirstName, Lastname 
    FROM Employee
    WHERE SUBSTRING(LastName, 1, 1) = 'p'; -- with all employees with last name first letter of P

SELECT FirstName, LastName 
    FROM Employee
    WHERE LastName BETWEEN 'p' AND 'q'; -- inclusive of p and q

SELECT FirstName, LastName 
    FROM Employee
    WHERE LastName LIKE 'p%';




-- exercise set 1 problem 5
-- How many invoices were there in 2009, and what was the sales total for that year?
--    (extra challenge: find the invoice count sales total for every year, using one query)
SELECT COUNT(*) AS InvoiceCount, SUM(Total) AS SalesTotal
    FROM Invoice
    --WHERE InvoiceDate >= '2009' AND InvoiceDate < '2010';
    WHERE YEAR(InvoiceDate) = 2009; -- built-in functions to extract parts of a date

SELECT YEAR(InvoiceDate) AS InvoiceYear,
	COUNT(*) AS InvoiceCount, SUM(Total) AS SalesTotal
    FROM Invoice
    GROUP BY YEAR(InvoiceDate)
    ORDER BY InvoiceYear DESC,  SalesTotal DESC;




-- SQL has aggrigation functions
--      these are the once which accept many values and return one
--      there are: COUNT, SUM, AVG, MIN, MAX
-- If you use one of these in the SELECT list,
--      all rows will be reduced to one.
--      but that's only if you have no GROUP BY clause...
-- if you have one of those, it will instead reduce the rows in sets
-- defined by the columns listed in the GROUP BY

-- total number of customers
SELECT COUNT(*) FROM Customer;
-- total number of customers first name
SELECT COUNT(FirstName) FROM Customer;

-- total number of letters in customer first names
SELECT COUNT(LEN(FirstName)) FROM Customer;



-- any duplicate first names across customers
SELECT COUNT(*), FirstName
    FROM Customer
    GROUP BY FirstName
    HAVING COUNT(*) > 1; -- same as WHERE, but cant do COUNT() in WHERE so use HAVING



----------------------------------------------------------------------- JOIN ---------------------------------------------------------------------------------------
--CROSS JOIN joins everything with everything
--      cross join, each row with each row in the other table
-- 360 degree performance review?
SELECT * 
    FROM Employee AS e1
    CROSS JOIN Employee AS e2; 

-- if its not a cross join, you join ON as condition filtering the rows
-- display every track name with its genre
SELECT Track.Name AS 'Track Name', Genre.Name AS 'Genere'
    FROM Track 
    INNER JOIN Genre ON Track.GenreId = Genre.GenreId;

-- in SQL, all comparisons with NULL are false. so we use IS NULL and IS NOT NULL.
SELECT * FROM Track WHERE GenreId IS NULL;

-- all rock songs, shown in the format "artist - song"
-- COALESCE function will provide an alternate value in case of NULL
SELECT COALESCE(artist.Name, 'N/A') + ' - ' + track.Name
FROM Track AS track
    LEFT JOIN Genre AS genre ON track.GenreId = genre.GenreId
    LEFT JOIN ALBUM AS album ON track.AlbumId = album.AlbumId
    LEFT Join Artist AS artist ON album.ArtistId = artist.ArtistId
WHERE genre.Name = 'rock';

-- inner join = matching entry in both tables


----------------------------------------------------------------------- SET ---------------------------------------------------------------------------------------

-- SQL has some operators that combine entire queries (SELECT) into one query.
-- the set operators:
    -- UNION
        -- gives you all rows that are found in either query, without duplicates    
    -- UNION ALL
        -- gives you all rows found in either query, period, including duplicates.
        -- (faster to run, but have potentially more data)
    -- INTERSECT
        -- all rows that are in both queries. (no duplicates)
    -- EXCEPT
        -- "set difference"
        -- all rows that are in the first query but are not in the second query.
-- to use any of them, the two queries must have the same
-- number and type of columns.

-- UNION
-- all first names of employees and customers
SELECT FirstName FROM Employee
UNION
SELECT FirstName FROM Customer;

-- INTERSECT
-- names that a customer has and also an employee has
SELECT FirstName FROM Employee
INTERSECT
SELECT FirstName FROM Customer;

-- EXCEPT
-- name that employees have but customer do not have
SELECT FirstName FROM Employee
EXCEPT
SELECT FirstName FROM Customer;



----------------------------------------------------------------------- SUB-QUERY ---------------------------------------------------------------------------------------

-- sometimes the most natural way to express a query
-- is with a condition based on another query

-- we have some operators for subqueries --
    -- IN, NOT IN, EXISTS, ANY, ALL.

-- bit contrived example of ALL:
-- the artist who made the album with the longest title
SELECT * FROM Artist 
WHERE ArtistId = (
    SELECT ArtistId FROM Album WHERE
    LEN(Title) >= ALL(SELECT LEN(Title) FROM Album)
)

-- every track that has never been purchased
-- subquery version
SELECT * FROM Track 
WHERE TrackId NOT IN (
    SELECT TrackId FROM InvoiceLine
);

-- there is a syntax called "common table expression" (CTE)
    -- it lets you run one query in advance, put it in a temporary variable,
    -- and use it in main query
WITH purchased_tracks AS (
    SELECT TrackId FROM InvoiceLine
)
SELECT * FROM Track WHERE TrackId NOT IN (
    SELECT * FROM purchased_tracks
);

-- join version
SELECT Track.* FROM Track 
    LEFT JOIN InvoiceLine ON Track.TrackId = InvoiceLine.TrackId
WHERE InvoiceLine.InvoiceLineId IS NULL;

-- you can't do "= NULL" in SQL, it will always be false
-- - we have IS NULL and IS NOT NULL
