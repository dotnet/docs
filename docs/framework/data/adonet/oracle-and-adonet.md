---
title: "Oracle and ADO.NET"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 8ee8e389-53cf-45cf-80bd-1df63ef34f2e
---
# Oracle and ADO.NET
> [!NOTE]
> The types in <xref:System.Data.OracleClient> are deprecated. The types remain supported in the current version of.NET Framework but will be removed in a future release. Microsoft recommends that you use a third-party Oracle provider.  
  
 This section describes features and behaviors that are specific to the .NET Framework Data Provider for Oracle.  
  
 The .NET Framework Data Provider for Oracle provides access to an Oracle database using the Oracle Call Interface (OCI) as provided by Oracle Client software. The functionality of the data provider is designed to be similar to that of the .NET Framework data providers for SQL Server, OLE DB, and ODBC.  
  
 To use the .NET Framework Data Provider for Oracle, an application must reference the <xref:System.Data.OracleClient> namespace as follows:  
  
```vb  
Imports System.Data.OracleClient  
```  
  
```csharp  
using System.Data.OracleClient;  
```  
  
 You also must include a reference to the DLL when you compile your code. For example, if you are compiling a C# program, your command line should include:  
  
```  
csc /r:System.Data.OracleClient.dll  
```  
  
## In This Section  
 [System Requirements](system-requirements-for-the-dotnet-data-provider-for-oracle.md)  
 Describes requirements for using the .NET Framework Data Provider for Oracle, and describes a number of issues to be aware when using it.  
  
 [Oracle BFILEs](oracle-bfiles.md)  
 Describes the <xref:System.Data.OracleClient.OracleBFile> class, which is used to work with the Oracle BFILE data type.  
  
 [Oracle LOBs](oracle-lobs.md)  
 Describes the <xref:System.Data.OracleClient.OracleLob> class, which is used to work with Oracle LOB data types.  
  
 [Oracle REF CURSORs](oracle-ref-cursors.md)  
 Describes support for the Oracle REF CURSOR data type.  
  
 [OracleTypes](oracletypes.md)  
 Describes structures you can use to work with Oracle data types, including <xref:System.Data.OracleClient.OracleNumber> and <xref:System.Data.OracleClient.OracleString>.  
  
 [Oracle Sequences](oracle-sequences.md)  
 Describes support for retrieving the server-generated key Oracle Sequence values.  
  
 [Oracle Data Type Mappings](oracle-data-type-mappings.md)  
 Lists Oracle data types and their mappings to the <xref:System.Data.OracleClient.OracleDataReader>.  
  
 [Oracle Distributed Transactions](oracle-distributed-transactions.md)  
 Describes how the <xref:System.Data.OracleClient.OracleConnection> object automatically enlists in an existing distributed transaction if it determines that a transaction is active.  
  
## Related Sections  
 [Securing ADO.NET Applications](securing-ado-net-applications.md)  
 Describes secure coding practices when using ADO.NET.  
  
 [DataSets, DataTables, and DataViews](./dataset-datatable-dataview/index.md)  
 Describes how to create and use `DataSets`, typed `DataSets`, `DataTables`, and `DataViews`.  
  
 [Retrieving and Modifying Data in ADO.NET](retrieving-and-modifying-data.md)  
 Describes how to work with data in ADO.NET.  
  
 [SQL Server and ADO.NET](./sql/index.md)  
 Describes how to work with features and functionality that are specific to SQL Server.  
  
 [DbProviderFactories](dbproviderfactories.md)  
 Describes generic classes that allow you to write provider-independent code in ADO.NET.  
  
## See also

- [ADO.NET](index.md)
- [ADO.NET Managed Providers and DataSet Developer Center](https://go.microsoft.com/fwlink/?LinkId=217917)
