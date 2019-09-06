---
title: "Side-by-Side Execution in ADO.NET"
ms.date: "03/30/2017"
ms.assetid: 9f9ba96d-9f89-4f65-bb2f-6860879f4393
---
# Side-by-Side Execution in ADO.NET
Side-by-side execution in the .NET Framework is the ability to execute an application on a computer that has multiple versions of the .NET Framework installed, exclusively using the version for which the application was compiled. For detailed information about configuring side-by-side execution, see [Side-by-Side Execution](../../deployment/side-by-side-execution.md).  
  
 An application compiled by using one version of the .NET Framework can run on a different version of the .NET Framework. However, we recommend that you compile a version of the application for each installed version of the .NET Framework, and run them separately. In either scenario, you should be aware of changes in ADO.NET between releases that can affect the forward compatibility or backward compatibility of your application.  
  
## Forward Compatibility and Backward Compatibility  
 Forward compatibility means that an application can be compiled with an earlier version of the .NET Framework, but will still run successfully on a later version of the .NET Framework. ADO.NET code written for the .NET Framework version 1.1 is forward compatible with later versions.  
  
 Backward compatibility means that an application is compiled for a newer version of the .NET Framework, but continues to run on earlier versions of the .NET Framework without any loss of functionality. Of course, this will not be the case for features introduced in a new version of the .NET Framework.  
  
## The .NET Framework Data Provider for ODBC  
 Starting with version 1.1, the .NET Framework Data Provider for ODBC (<xref:System.Data.Odbc>) is included as a part of the .NET Framework. The ODBC data provider is available to .NET Framework version 1.0 developers as a Web download from the [Data Access and Storage Developer Center](https://go.microsoft.com/fwlink/?linkid=4173). The namespace for the downloaded .NET Framework Data Provider for ODBC is **Microsoft.Data.Odbc**.  
  
 If you have an application developed for the .NET Framework version 1.0 that uses the ODBC data provider to connect to your data source, and you want to run that application on the .NET Framework version 1.1 or a later version, you must update the namespace for the ODBC data provider to **System.Data.Odbc**. You then must recompile it for the newer version of the .NET Framework.  
  
 If you have an application developed for the .NET Framework version 2.0 or later that uses the ODBC data provider to connect to your data source, and you want to run that application on the .NET Framework version 1.0, you must download the ODBC data provider and install it on the .NET Framework version 1.0 system. You then must change the namespace for the ODBC data provider to **Microsoft.Data.Odbc**, and recompile the application for the .NET Framework version 1.0.  
  
## The .NET Framework Data Provider for Oracle  
 Starting with version 1.1, the .NET Framework Data Provider for Oracle (<xref:System.Data.OracleClient>) is included as a part of the .NET Framework. The data provider is available to .NET Framework version 1.0 developers as a Web download from the [Data Access and Storage Developer Center](https://go.microsoft.com/fwlink/?linkid=4173).  
  
 If you have an application developed for the .NET Framework version 2.0 or later that uses the data provider to connect to your data source, and you want to run that application on the .NET Framework version 1.0, you must download the data provider and install it on the .NET Framework version 1.0 system.  
  
## Code Access Security  
 The .NET Framework data providers in the .NET Framework version 1.0 (<xref:System.Data.SqlClient>, <xref:System.Data.OleDb>) are required to run with FullTrust permission. Any attempt to use the .NET Framework k data providers from the .NET Framework version 1.0 in a zone with less than FullTrust permission causes a <xref:System.Security.SecurityException>.  
  
 However, starting with the .NET Framework version 2.0, all of the .NET Framework data providers can be used in partially trusted zones. In addition, a new security feature was added to the .NET Framework data providers in the .NET Framework version 1.1. This feature enables you to restrict what connection strings can be used in a particular security zone. You can also disable the use of blank passwords for a particular security zone. For more information, see [Code Access Security and ADO.NET](code-access-security.md).  
  
 Because each installation of the .NET Framework has a separate Security.config file, there are no compatibility issues with security settings. However, if your application depends on the additional security capabilities of ADO.NET included in the .NET Framework version 1.1 and later, you will not be able to distribute it to a version 1.0 system.  
  
## SqlCommand Execution  
 Starting with the .NET Framework version 1.1, the way that <xref:System.Data.SqlClient.SqlCommand.ExecuteReader%2A> executes commands at the data source was changed.  
  
 In the .NET Framework version 1.0, <xref:System.Data.SqlClient.SqlCommand.ExecuteReader%2A> executed all commands in the context of the **sp_executesql** stored procedure. As a result, commands that affect the state of the connection (for example, SET NOCOUNT ON), only apply to the execution of the current command. The state of the connection is not modified for any subsequent commands executed while the connection is open.  
  
 In the .NET Framework version 1.1 and later, <xref:System.Data.SqlClient.SqlCommand.ExecuteReader%2A> only executes a command in the context of the **sp_executesql** stored procedure if the command contains parameters, which provides a performance benefit. As a result, if a command affecting the state of the connection is included in a non-parameterized command, it modifies the state of the connection for all subsequent commands executed while the connection is open.  
  
 Consider the following batch of commands executed in a call to <xref:System.Data.SqlClient.SqlCommand.ExecuteReader%2A>.  
  
```sql
SET NOCOUNT ON;  
SELECT * FROM dbo.Customers;  
```  
  
 In the .NET Framework version 1.1 and later, NOCOUNT will remain ON for any subsequent commands executed while the connection is open. In the .NET Framework version 1.0, NOCOUNT is only ON for the current command execution.  
  
 This change can affect both the forward and backward compatibility of your application if you depend on the behavior of <xref:System.Data.SqlClient.SqlCommand.ExecuteReader%2A> for either version of the .NET Framework.  
  
 For applications that run on both earlier and later versions of the .NET Framework, you can write your code to make sure that the behavior is the same regardless of the version you are running on. If you want to make sure that a command modifies the state of the connection for all subsequent commands, we recommend that you execute your command using <xref:System.Data.SqlClient.SqlCommand.ExecuteNonQuery%2A>. If you want to make sure that a command does not modify the connection for all subsequent commands, we recommend that you include the commands to reset the state of the connection in your command. For example:  
  
```sql
SET NOCOUNT ON;  
SELECT * FROM dbo.Customers;  
SET NOCOUNT OFF;  
```  
  
## See also

- [ADO.NET Overview](ado-net-overview.md)
- [Retrieving and Modifying Data in ADO.NET](retrieving-and-modifying-data.md)
- [ADO.NET Managed Providers and DataSet Developer Center](https://go.microsoft.com/fwlink/?LinkId=217917)
