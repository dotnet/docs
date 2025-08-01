---
description: "Learn more about secure data access and understand the security mechanisms available in the underlying data store or database."
title: "Secure Data Access"
ms.date: "03/30/2017"
ms.assetid: 473ebd69-21a3-4627-b95e-4e04d035c56f
ms.custom: sfi-ropc-nochange
---
# Secure data access

To write secure ADO.NET code, you have to understand the security mechanisms available in the underlying data store, or database. You also need to consider the security implications of other features or components that your application might contain.

## Authentication, Authorization, and Permissions

When connecting to Microsoft SQL Server, you can use Windows Authentication, also known as Integrated Security, which uses the identity of the current active Windows user rather than passing a user ID and password. Using Windows Authentication is recommended for on-premises databases because user credentials aren't exposed in the connection string. If you can't use Windows Authentication to connect to SQL Server, then consider creating connection strings at run time using the <xref:System.Data.SqlClient.SqlConnectionStringBuilder>.

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

 The credentials used for authentication need to be handled differently based on the type of application. For example, in a Windows Forms application, the user can be prompted to supply authentication information, or the user's Windows credentials can be used. However, a Web application often accesses data using credentials supplied by the application itself rather than by the user.

 Once users have been authenticated, the scope of their actions depends on the permissions that have been granted to them. Always follow the principle of least privilege and grant only permissions that are absolutely necessary.

 For more information, see the following resources.

|Resource|Description|
|--------------|-----------------|
|[Protecting Connection Information](protecting-connection-information.md)|Describes security best practices and techniques for protecting connection information, such as using protected configuration to encrypt connection strings.|
|[Connection String Builders](connection-string-builders.md)|Describes how to build connection strings from user input at run time.|
|[Security for SQL Server Database Engine and Azure SQL Database](/sql/relational-databases/security/security-center-for-sql-server-database-engine-and-azure-sql-database)|Provides links to help you locate information about security and protection in the SQL Server Database Engine and Azure SQL Database.|

## Parameterized Commands and SQL Injection

 Using parameterized commands helps guard against SQL injection attacks, in which an attacker "injects" a command into a SQL statement that compromises security on the server. Parameterized commands guard against a SQL injection attack by ensuring that values received from an external source are passed as values only, and not part of the Transact-SQL statement. As a result, Transact-SQL commands inserted into a value are not executed at the data source. Rather, they are evaluated solely as a parameter value. In addition to the security benefits, parameterized commands provide a convenient method for organizing values passed with a Transact-SQL statement or to a stored procedure.

 For more information on using parameterized commands, see the following resources.

|Resource|Description|
|--------------|-----------------|
|[DataAdapter Parameters](dataadapter-parameters.md)|Describes how to use parameters with a `DataAdapter`.|
|[Modifying Data with Stored Procedures](modifying-data-with-stored-procedures.md)|Describes how to specify parameters and obtain a return value.|
|[Stored procedures (Database Engine)](/sql/relational-databases/stored-procedures/stored-procedures-database-engine)|Describes the benefits of using stored procedures and the different types of stored procedures.|

## Probing Attacks

 Attackers often use information from an exception, such as the name of your server, database, or table, to mount an attack on your system. Because exceptions can contain specific information about your application or data source, you can help keep your application and data source better protected by only exposing essential information to the client.

 For more information, see the following resources.

|Resource|Description|
|--------------|-----------------|
|[Handling and throwing exceptions in .NET](../../../standard/exceptions/index.md)|Describes the basic forms of try/catch/finally structured exception handling.|
|[Best Practices for Exceptions](../../../standard/exceptions/best-practices-for-exceptions.md)|Describes best practices for handling exceptions.|

## Protect Microsoft Access and Excel Data Sources

 Microsoft Access and Microsoft Excel can act as a data store for an ADO.NET application when security requirements are minimal or nonexistent. Their security features are effective for deterrence, but should not be relied upon to do more than discourage meddling by uninformed users. The physical data files for Access and Excel exist on the file system, and must be accessible to all users. This makes them vulnerable to attacks that could result in theft or data loss since the files can be easily copied or altered. When robust security is required, use SQL Server or another server-based database where the physical data files are not readable from the file system.

## Enterprise Services

 COM+ contains its own security model that relies on Windows accounts and process/thread impersonation. The <xref:System.EnterpriseServices> namespace provides wrappers that allow .NET applications to integrate managed code with COM+ security services through the <xref:System.EnterpriseServices.ServicedComponent> class.

## Interoperate with Unmanaged Code

.NET Framework provides for interaction with unmanaged code, including COM components, COM+ services, external type libraries, and many operating system services. Working with unmanaged code involves going outside the security perimeter for managed code. Both your code and any code that calls it must have unmanaged code permission (<xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> flag specified). Unmanaged code can introduce unintended security vulnerabilities into your application. Therefore, you should avoid interoperating with unmanaged code unless it is absolutely necessary.

For more information, see [Interoperating with Unmanaged Code](../../interop/index.md).

## See also

- [Securing ADO.NET Applications](securing-ado-net-applications.md)
- [Protecting Connection Information](protecting-connection-information.md)
- [Connection String Builders](connection-string-builders.md)
- [ADO.NET Overview](ado-net-overview.md)
