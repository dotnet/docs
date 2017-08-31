-------------------------------------------------------------------------------
-- Stored Procedure
-------------------------------------------------------------------------------
EXEC InsertCurrency 'AAA', 'Currency Test'
SELECT * from Sales.Currency where CurrencyCode = 'AAA'


-------------------------------------------------------------------------------
-- Aggregate
-------------------------------------------------------------------------------
SELECT LastName, COUNT(LastName) AS CountOfLastName, dbo.CountVowels(LastName) AS CountOfVowels
FROM Person.Contact
GROUP BY LastName
ORDER BY LastName


-------------------------------------------------------------------------------
-- Trigger
-------------------------------------------------------------------------------
-- Insert one user name that is not an e-mail address and one that is
INSERT INTO Users(UserName, Pass) VALUES(N'someone', N'cnffjbeq')
INSERT INTO Users(UserName, Pass) VALUES(N'someone@example.com', N'cnffjbeq')

-- check the Users and UsersAudit tables to see the results of the trigger
select * from Users
select * from UsersAudit


-------------------------------------------------------------------------------
-- Function
-------------------------------------------------------------------------------
SELECT dbo.addTax(10)


-------------------------------------------------------------------------------
-- Type
-------------------------------------------------------------------------------
CREATE TABLE test_table (column1 Point)
go

INSERT INTO test_table (column1) VALUES ('1:2')
INSERT INTO test_table (column1) VALUES ('-2:3')
INSERT INTO test_table (column1) VALUES ('-3:-4')

select column1.Quadrant() from test_table
