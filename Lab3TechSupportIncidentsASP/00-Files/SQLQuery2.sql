USE TechSupport;

SELECT * FROM Incidents ORDER BY TechID;
SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Technicians;

SELECT * FROM States;
SELECT * FROM Registrations;

SELECT TechID, [Name] FROM Technicians;

SELECT IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, [Description] 
	FROM Incidents WHERE TechID = 11 AND DateClosed IS NULL
	ORDER BY DateOpened ASC;

SELECT * FROM Customers
	WHERE CustomerID = 1002;

SELECT IncidentID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, [Description] 
	FROM Incidents i 
		INNER JOIN Customers c ON c.CustomerID = i.CustomerID
	WHERE TechID = 11 AND DateClosed IS NULL
	ORDER BY DateOpened ASC;
