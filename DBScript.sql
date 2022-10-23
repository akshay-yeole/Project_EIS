USE EIS;

GO
CREATE TABLE Employees
(
	empid INT NOT NULL,
	firstname VARCHAR(100),
	lastname VARCHAR(100),
	city VARCHAR(100),
	contact VARCHAR(12),
	department VARCHAR(100),
	salary MONEY
);

--Insert Employee
GO
CREATE PROCEDURE sp_AddEmployee
(
	@empid int,
	@firstname varchar(100),
	@lastname VARCHAR(100),
	@city VARCHAR(100),
	@contact VARCHAR(12),
	@department VARCHAR(100),
	@salary MONEY
)
AS
BEGIN
	INSERT INTO Employees VALUES(@empid, @firstname, @lastname, @city, @contact, @department, @salary);
END;

--All Employees
GO
CREATE PROCEDURE sp_AllEmployees
AS
BEGIN
	SELECT * FROM Employees;
END;

exec sp_AllEmployees

--get employee by id
GO
CREATE PROCEDURE sp_getEmployeeByID
	@empid int
AS
BEGIN
	SELECT * FROM Employees WHERE empid=@empid; 
END;

exec sp_AllEmployees 

--Update Employee details
GO
CREATE PROCEDURE sp_UpdateEmployeeDetails
(
	@empid int,
	@firstname varchar(100),
	@lastname VARCHAR(100),
	@city VARCHAR(100),
	@contact VARCHAR(12),
	@department VARCHAR(100),
	@salary MONEY
)
AS
BEGIN
	Update Employees 
		SET firstname=@firstname,lastname=@lastname,city=@city,contact=@contact,department=@department,salary=@salary
		WHERE empid=@empid;
END;

--Remove Employee
GO
CREATE PROCEDURE sp_DeleteEmployee
@empid int
AS
BEGIN
	DELETE FROM Employees
		WHERE empid=@empid; 
END;
