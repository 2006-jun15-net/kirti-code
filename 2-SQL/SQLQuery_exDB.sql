CREATE TABLE PDepartment
(
    ID int NOT NULL PRIMARY KEY,
    Name varchar (255) NOT NULL,
    Location varchar
);

CREATE TABLE PEmployee
(
    ID int NOT NULL PRIMARY KEY,
    FirstName varchar NOT NULL,
    LatName varchar NOT NULL,
    SSN varchar NOT NULL,
    DeptID int NOT NULL,
    FOREIGN KEY (DeptID) REFERENCES PDepartment (ID)
);

CREATE TABLE PEmpDetails
(
    ID int NOT NULL PRIMARY KEY,
    EmployeeID int NOT NULL,
    Salary float NOT NULL,
    Address1 varchar,
    Address2 varchar,
    City varchar,
    State varchar,
    Country varchar
    FOREIGN KEY (EmployeeID) REFERENCES PDepartment (ID)
);

-- edit the datatype of a column
ALTER TABLE PDepartment ALTER COLUMN Name varchar (255);
ALTER TABLE PEmpDetails ALTER COLUMN Address2 varchar (255);


-- add 3 records in each table
INSERT INTO PDepartment (ID, Name) 
    VALUES (2, 'b'), (3, 'c');

INSERT INTO PEmployee (ID, FirstName, LatName, SSN, DeptID) 
    VALUES (1, 'k', 'p', 123456789, 1), (2, 'y', 'p', 123456789, 2), (3, 'p', 'p', 123456789, 3);    

INSERT INTO PEmpDetails (ID, EmployeeID, Salary) 
    VALUES (1, 1, 54000), (2, 2, 26000), (3, 3, 55000);    

-- add employee Tina Smith
INSERT INTO PEmployee (ID, FirstName, LatName, SSN, DeptID) 
    VALUES (4, 'T', 'S', 123456789, 1);  

-- add department markething
INSERT INTO PDepartment (ID, Name) 
    VALUES (5, 'Marketing');

-- list all employees in Marketing


