---
title: "Factory Model Overview"
ms.date: "03/30/2017"
ms.assetid: b5dc81c4-7554-44b9-b513-769bd61e2e7b
---
# Factory Model Overview
ADO.NET 2.0 introduced new base classes in the <xref:System.Data.Common> namespace. The base classes are abstract, which means that they can't be directly instantiated. They include <xref:System.Data.Common.DbConnection>, <xref:System.Data.Common.DbCommand>, and <xref:System.Data.Common.DbDataAdapter> and are shared by the .NET Framework data providers, such as <xref:System.Data.SqlClient> and <xref:System.Data.OleDb>. The addition of base classes simplifies adding functionality to the .NET Framework data providers without having to create new interfaces.  
  
 ADO.NET 2.0 also introduced abstract base classes, which enable a developer to write generic data access code that does not depend on a specific data provider.  
  
## The Factory Design Pattern  
 The programming model for writing provider-independent code is based on the use of the "factory" design pattern, which uses a single API to access databases across multiple providers. This pattern is aptly named, as it calls for the use of a specialized object solely to create other objects, much like a real-world factory. For a more detailed description of the factory design pattern, see [Writing Generic Data Access Code in ASP.NET 2.0 and ADO.NET 2.0](https://go.microsoft.com/fwlink/?LinkId=55915).
  
 Starting with ADO.NET 2.0, the <xref:System.Data.Common.DbProviderFactories> class provides `static` (or `Shared` in Visual Basic) methods for creating a <xref:System.Data.Common.DbProviderFactory> instance. The instance then returns a correct strongly typed object based on provider information and the connection string supplied at run time.  
  
## See also

- [Obtaining a DbProviderFactory](obtaining-a-dbproviderfactory.md)
- [DbConnection, DbCommand and DbException](dbconnection-dbcommand-and-dbexception.md)
- [Modifying Data with a DbDataAdapter](modifying-data-with-a-dbdataadapter.md)
- [ADO.NET Overview](ado-net-overview.md)
