---
description: "Learn more about: How to: Return Rowsets"
title: "How to: Return Rowsets"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 725718f5-da29-4841-9f53-aafef64ba977
---
# How to: Return Rowsets

This example returns a rowset from the database, and includes an input parameter to filter the result.  
  
 When you execute a stored procedure that returns a rowset, you use a *result* class that stores the returns from the stored procedure. For more information, see [Analyzing LINQ to SQL Source Code](analyzing-linq-to-sql-source-code.md).  
  
## Example  

 The following example represents a stored procedure that returns rows of customers and uses an input parameter to return only those rows that list "London" as the customer city. The example assumes an enumerable `CustomersByCityResult` class.  
  
```sql  
CREATE PROCEDURE [dbo].[Customers By City]  
    (@param1 NVARCHAR(20))  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
    SELECT CustomerID, ContactName, CompanyName, City from Customers  
        as c where c.City=@param1  
END  
```  
  
 [!code-csharp[DLinqSprox#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSprox/cs/northwind-sprox.cs#1)]
 [!code-vb[DLinqSprox#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSprox/vb/northwind-sprox.vb#1)]  
  
## See also

- [Stored Procedures](stored-procedures.md)
- [Downloading Sample Databases](downloading-sample-databases.md)
