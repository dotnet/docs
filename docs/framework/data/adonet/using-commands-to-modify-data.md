---
title: "Using Commands to Modify Data"
ms.date: "03/30/2017"
ms.assetid: f4160389-b9ff-4b74-b655-437c76dcd586
---
# Using Commands to Modify Data
Using a .NET Framework data provider, you can execute stored procedures or data definition language statements (for example, CREATE TABLE and ALTER COLUMN) to perform schema manipulation on a database or catalog. These commands do not return rows as a query would, so the **Command** object provides an **ExecuteNonQuery** to process them.  
  
 In addition to using **ExecuteNonQuery** to modify schema, you can also use this method to process SQL statements that modify data but that do not return rows, such as INSERT, UPDATE, and DELETE.  
  
 Although rows are not returned by the **ExecuteNonQuery** method, input and output parameters and return values can be passed and returned via the **Parameters** collection of the **Command** object.  
  
## In This Section  
 [Updating Data in a Data Source](updating-data-in-a-data-source.md)  
 Describes how to execute commands or stored procedures that modify data in a database.  
  
 [Performing Catalog Operations](performing-catalog-operations.md)  
 Describes how to execute commands that modify database schema.  
  
## See also

- [Retrieving and Modifying Data in ADO.NET](retrieving-and-modifying-data.md)
- [Commands and Parameters](commands-and-parameters.md)
- [ADO.NET Overview](ado-net-overview.md)
