---
title: "Connection Strings in ADO.NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 745c5f95-2f02-4674-b378-6d51a7ec2490
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Connection Strings in ADO.NET
The .NET Framework 2.0 introduced new capabilities for working with connection strings, including the introduction of new keywords to the connection string builder classes, which facilitate creating valid connection strings at run time.  
  
 A connection string contains initialization information that is passed as a parameter from a data provider to a data source. The syntax depends on the data provider, and the connection string is parsed during the attempt to open a connection. Syntax errors generate a run-time exception, but other errors occur only after the data source receives connection information. Once validated, the data source applies the options specified in the connection string and opens the connection.  
  
 The format of a connection string is a semicolon-delimited list of key/value parameter pairs:  
  
 `keyword1=value; keyword2=value;`  
  
 Keywords are not case sensitive, and spaces between key/value pairs are ignored. However, values may be case sensitive, depending on the data source. Any values containing a semicolon, single quotation marks, or double quotation marks must be enclosed in double quotation marks.  
  
 Valid connection string syntax depends on the provider, and has evolved over the years from earlier APIs like ODBC. The .NET Framework Data Provider for SQL Server (SqlClient) incorporates many elements from older syntax and is generally more flexible with common connection string syntax. There are frequently equally valid synonyms for connection string syntax elements, but some syntax and spelling errors can cause problems. For example, "`Integrated Security=true`" is valid, whereas "`IntegratedSecurity=true`" causes an error. In addition, connection strings constructed at run time from unvalidated user input can lead to string injection attacks, jeopardizing security at the data source.  
  
 To address these problems, ADO.NET 2.0 introduced new connection string builders for each .NET Framework data provider. Keywords are exposed as properties, enabling connection string syntax to be validated before submission to the data source.  
  
## In This Section  
 [Connection String Builders](../../../../docs/framework/data/adonet/connection-string-builders.md)  
 Demonstrates how to use the `ConnectionStringBuilder` classes to construct valid connection strings at run time.  
  
 [Connection Strings and Configuration Files](../../../../docs/framework/data/adonet/connection-strings-and-configuration-files.md)  
 Demonstrates how to store and retrieve connection strings in configuration files.  
  
 [Connection String Syntax](../../../../docs/framework/data/adonet/connection-string-syntax.md)  
 Describes how to configure provider-specific connection strings for `SqlClient`, `OracleClient`, `OleDb`, and `Odbc`.  
  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)  
 Demonstrates techniques for protecting information used to connect to a data source.  
  
## See Also  
 [Connecting to a Data Source](/cpp/data/odbc/connecting-to-a-data-source)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
