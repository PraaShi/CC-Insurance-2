-- UserInfo Table
CREATE TABLE UserInfo (
    userId INT PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
	role VARCHAR(50) NOT NULL
)

-- Client Table
CREATE TABLE Client (
    clientId INT PRIMARY KEY,
    clientName VARCHAR(100) NOT NULL,
    contactInfo VARCHAR(200) NOT NULL,	
    policyId INT,
)


-- Claim Table
CREATE TABLE Claim (
    claimId INT PRIMARY KEY,
    claimNumber BIGINT,
    dateFiled DATE,
    claimAmount DECIMAL(10, 2) NOT NULL,
    status VARCHAR(50) NOT NULL,
    policyId INT,
    clientId INT,
    FOREIGN KEY (clientId) REFERENCES Client(clientId)
)

-- Payment Table
CREATE TABLE Payment (
    paymentId INT PRIMARY KEY,
    paymentDate DATE,
    paymentAmount DECIMAL(10, 2) NOT NULL,
    clientId INT,
    FOREIGN KEY (clientId) REFERENCES Client(clientId)
)

-- Policy Table
CREATE TABLE Policy (
    policyId INT PRIMARY KEY,
    policyName VARCHAR(200) NOT NULL
)

-- Inserting sample data into UserInfo table
INSERT INTO UserInfo (userId, username, password, role)
VALUES 
    (1, 'geetha', 'abc123', 'admin'),
    (2, 'mohan', '123abc', 'user'),
    (3, 'ram', 'abdcfe456', 'user')

-- Inserting sample data into Client table
INSERT INTO Client (clientId, clientName, contactInfo, policyId)
VALUES 
    (1, 'janu', '8374938374', 1),
    (2, 'menu', '9876543210', 2),
    (3, 'shivam', '9555555555', 3)

-- Inserting sample data into Claim table
INSERT INTO Claim (claimId, claimNumber, dateFiled, claimAmount, status, policyId, clientId)
VALUES 
    (1, 1001, '2024-05-01', 500.00, 'Pending', 1, 1),
    (2, 1002, '2024-04-15', 1000.00, 'Approved', 2, 2)

-- Inserting sample data into Payment table
INSERT INTO Payment (paymentId, paymentDate, paymentAmount, clientId)
VALUES 
    (1, '2024-05-10', 200.00, 1),
    (2, '2024-05-12', 300.00, 2)

-- Inserting sample data into Policy table
INSERT INTO Policy (policyId, policyName)
VALUES 
    (1, 'Life Insurance'),
    (2, 'Vehical Insurance'),
	(3, 'Property Insurance')

	select * from Policy