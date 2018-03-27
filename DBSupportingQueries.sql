USE [InternationalCookies]

CREATE TABLE StoreDetails
(
	StoreID INT PRIMARY KEY IDENTITY(1,1),
	StoreName nvarchar(50),
	StoreLocation nvarchar(50)
)

CREATE TABLE CookieOrders 
(
	OrderID INT PRIMARY KEY IDENTITY(1,1),
	StoreID INT,
	CookiesRequired INT,
	OrderedDate DATETIME,
	CONSTRAINT FKey FOREIGN KEY(StoreID) REFERENCES StoreDetails(StoreID)
)
