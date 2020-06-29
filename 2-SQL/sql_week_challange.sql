CREATE DATABASE sql_week_challange;

-- DROP TABLE Store.Customer
CREATE TABLE Customer (
    CustomerId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(26) NOT NULL,
    LastName NVARCHAR(26) NOT NULL,
    CardNumber NVARCHAR(50) NOT NULL,
);

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ProductId INT NOT NULL,
    CustomerId INT NOT NULL,
    CONSTRAINT FK_ProductId_Product FOREIGN KEY (ProductId) 
        REFERENCES Product (ProductId)
            ON DELETE CASCADE,
    CONSTRAINT FK_CustomerId_Customer FOREIGN KEY (CustomerId) 
        REFERENCES Customer (CustomerId)
            ON DELETE CASCADE
);

CREATE TABLE Product (
    ProductId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Price DECIMAL (9,2) NOT NULL CHECK(Price > 0),
);

INSERT INTO Customer (FirstName, LastName, CardNumber)
VALUES ('Kirti', 'Patel', 1234456778914792), ('Yash', 'Patel', 1234456778915792), ('Pooja', 'Patel', 1234456778916792);

INSERT INTO Product (ProductName, Price)
VALUES ('Airpods', 129.89), ('iPhone-charger', 29.99), ('HDMI-cord', 30.45);

INSERT INTO Orders (ProductId, CustomerId) VALUES (3, 3), (2, 2), (1, 1); 

INSERT INTO Product (ProductName, Price) VALUES ('iPhone', 200);

INSERT INTO Customer (FirstName, LastName, CardNumber) VALUES ('Tina', 'Smith', 1234456778915764);

-- SELECT * FROM Product;
-- SELECT * FROM Customer;

INSERT INTO Orders (ProductId, CustomerId) VALUES (4, 4);

SELECT * FROM Orders WHERE CustomerId = 4;

SELECT SUM(Price) AS Revenue FROM Orders LEFT JOIN Product ON Product.ProductId = Orders.OrderId;

UPDATE Product SET Price = 250 WHERE ProductName = 'iPhone';