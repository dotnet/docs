---
description: "Learn more about security considerations that are specific to developing, deploying, and running Entity Framework applications."
title: "Security Considerations (Entity Framework)"
ms.date: "03/30/2017"
---
# Security Considerations (Entity Framework)

This article describes security considerations that are specific to developing, deploying, and running Entity Framework applications. You should also follow recommendations for creating secure .NET Framework applications. For more information, see [Security Overview](../security-overview.md).

## General Security Considerations

 The following security considerations apply to all applications that use Entity Framework.

### Use only trusted data source providers

 To communicate with the data source, a provider must do the following:

- Receive the connection string from Entity Framework.
- Translate the command tree to the data source's native query language.
- Assemble and return result sets.

 During the logon operation, information that is based on the user password is passed to the server through the network libraries of the underlying data source. A malicious provider can steal user credentials, generate malicious queries, or tamper with the result set.

### Encrypt your connection to protect sensitive data

 Entity Framework does not directly handle data encryption. If users access data over a public network, your application should establish an encrypted connection to the data source to increase security. For more information, see the security-related documentation for your data source.

### Secure the connection string

 Protecting access to your data source is one of the most important goals when securing an application. A connection string presents a potential vulnerability if it is not secured or if it is improperly constructed. When you store connection information in plain text or persist it in memory, you risk compromising your entire system. The following are the recommended methods for securing connection strings:

- Use Managed Identities for Azure resources when you connect to Azure SQL.

  For more information, see [Managed Identities for Azure resources](/sql/connect/ado-net/sql/azure-active-directory-authentication#using-managed-identity-authentication).

- Use Windows Authentication with an on-premises SQL Server data source.

  When you use Windows Authentication to connect to a SQL Server data source, the connection string does not contain logon and password information.

- Encrypt configuration file sections using protected configuration.

  ASP.NET provides a feature called protected configuration that enables you to encrypt sensitive information in a configuration file. Although primarily designed for ASP.NET, you can also use protected configuration to encrypt sections of configuration files in Windows applications.

- Store connection strings in secured configuration files.

  You should never embed connection strings in your source code. You can store connection strings in configuration files, which eliminates the need to embed them in your application's code. By default, the Entity Data Model Wizard stores connection strings in the application configuration file. You must secure this file to prevent unauthorized access.

- Use connection string builders when dynamically creating connections.

  If you must construct connection strings at run time, use the <xref:System.Data.EntityClient.EntityConnectionStringBuilder> class. This string builder class helps prevent connection string injection attacks by validating and escaping invalid input information. Also use the appropriate string builder class to construct the data source connection string that is part of the Entity Framework connection string. For information about connection string builders for ADO.NET providers, see [Connection String Builders](../connection-string-builders.md).

 For more information, see [Protecting Connection Information](../protecting-connection-information.md).

### Do not expose an EntityConnection to untrusted users

 An <xref:System.Data.EntityClient.EntityConnection> object exposes the connection string of the underlying connection. A user with access to an <xref:System.Data.EntityClient.EntityConnection> object can also change the <xref:System.Data.ConnectionState> of the underlying connection. The <xref:System.Data.EntityClient.EntityConnection> class is not thread safe.

### Do not pass connections outside the security context

 After a connection has been established, you must not pass it outside the security context. For example, one thread with permission to open a connection should not store the connection in a global location. If the connection is available in a global location, then another malicious thread can use the open connection without having that permission explicitly granted to it.

### Be aware that logon information and passwords may be visible in a memory dump

 When data source logon and password information is supplied in the connection string, this information is maintained in memory until garbage collection reclaims the resources. This makes it impossible to determine when a password string is no longer in memory. If an application crashes, a memory dump file may contain sensitive security information, and the user running the application and any user with administrative access to the computer can view the memory dump file. Use Windows Authentication for connections to Microsoft SQL Server.

### Grant users only the necessary permissions in the data source

 A data source administrator should grant only the necessary permissions to users. Even though Entity SQL does not support DML statements that modify data, such as INSERT, UPDATE, or DELETE, users can still access the connection to the data source. A malicious user could use this connection to execute DML statements in the native language of the data source.

### Run applications with the minimum permissions

 When you allow a managed application to run with full-trust permission, the .NET Framework does not limit the application's access to your computer. This may enable a security vulnerability in your application to compromise the entire system. To use code access security and other security mechanisms in the .NET Framework, you should run applications by using partial-trust permissions and with the minimum set of permissions that are needed to enable the application to function. The following code access permissions are the minimum permissions your Entity Framework application needs:

- <xref:System.Security.Permissions.FileIOPermission>: <xref:System.Security.Permissions.FileIOPermissionAccess.Write> to open the specified metadata files or <xref:System.Security.Permissions.FileIOPermissionAccess.PathDiscovery> to search a directory for metadata files.

- <xref:System.Security.Permissions.ReflectionPermission>: <xref:System.Security.Permissions.ReflectionPermissionFlag.RestrictedMemberAccess> to support LINQ to Entities queries.

- <xref:System.Transactions.DistributedTransactionPermission>: <xref:System.Security.Permissions.PermissionState.Unrestricted> to enlist in a <xref:System.Transactions><xref:System.Transactions.Transaction>.

- <xref:System.Security.Permissions.SecurityPermission>: <xref:System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter> to serialize exceptions by using the <xref:System.Runtime.Serialization.ISerializable> interface.

- Permission to open a database connection and execute commands against the database, such as <xref:System.Data.SqlClient.SqlClientPermission> for a SQL Server database.

 For more information, see [Code Access Security and ADO.NET](../code-access-security.md).

### Do not install untrusted applications

 Entity Framework does not enforce any security permissions and will invoke any user-supplied data object code in process regardless of whether it is trusted or not. Ensure that authentication and authorization of the client is performed by the data store and by your application.

### Restrict access to all configuration files

 An administrator must restrict write access to all files that specify configuration for an application, including to enterprisesec.config, security.config, machine.conf, and the application configuration file \<*application*>.exe.config.

 The provider invariant name is modifiable in the app.config. The client application must take responsibility for accessing the underlying provider through the standard provider factory model by using a strong name.

### Restrict permissions to the model and mapping files

 An administrator must restrict write access to the model and mapping files (.edmx, .csdl, .ssdl, and .msl) to only users who modify the model or mappings. Entity Framework only requires read access to these files at run time. An administrator should also restrict access to object layer and pre-compiled view source code files that are generated by the Entity Data Model tools.

## Security Considerations for Queries

 The following security considerations apply when querying a conceptual model. These considerations apply to Entity SQL queries using EntityClient and to object queries using LINQ, Entity SQL, and query builder methods.

### Prevent SQL injection attacks

 Applications frequently take external input (from a user or another external agent) and perform actions based on that input. Any input that is directly or indirectly derived from the user or an external agent might have content that uses the syntax of the target language in order to perform unauthorized actions. When the target language is a Structured Query Language (SQL), such as Transact-SQL, this manipulation is known as a SQL injection attack. A malicious user can inject commands directly into the query and drop a database table, cause a denial of service, or otherwise change the nature of the operation being performed.

- Entity SQL injection attacks:

     SQL injection attacks can be performed in Entity SQL by supplying malicious input to values that are used in a query predicate and in parameter names. To avoid the risk of SQL injection, you should never combine user input with Entity SQL command text.

     Entity SQL queries accept parameters everywhere that literals are accepted. You should use parameterized queries instead of injecting literals from an external agent directly into the query. You should also consider using [query builder methods](/previous-versions/dotnet/netframework-4.0/bb896238(v=vs.100)) to safely construct Entity SQL.

- LINQ to Entities injection attacks:

     Although query composition is possible in LINQ to Entities, it is performed through the object model API. Unlike Entity SQL queries, LINQ to Entities queries are not composed by using string manipulation or concatenation, and they are not susceptible to traditional SQL injection attacks.

### Prevent very large result sets

 A very large result set could cause the client system to shut down if the client is performing operations that consume resources proportional to the size of the result set. Unexpectedly large result sets can occur under the following conditions:

- In queries against a large database that do not include appropriate filter conditions.
- In queries that create Cartesian joins on the server.
- In nested Entity SQL queries.

 When accepting user input, you must make sure that the input cannot cause result sets to become larger than what the system can handle. You can also use the <xref:System.Linq.Queryable.Take%2A> method in LINQ to Entities or the [LIMIT](./language-reference/limit-entity-sql.md) operator in Entity SQL to limit the size of the result set.

### Avoid Returning IQueryable Results When Exposing Methods to Potentially Untrusted Callers

 Avoid returning <xref:System.Linq.IQueryable%601> types from methods that are exposed to potentially untrusted callers for the following reasons:

- A consumer of a query that exposes an <xref:System.Linq.IQueryable%601> type could call methods on the result that expose secure data or increase the size of the result set. For example, consider the following method signature:

    ```csharp
    public IQueryable<Customer> GetCustomer(int customerId)
    ```

    A consumer of this query could call `.Include("Orders")` on the returned `IQueryable<Customer>` to retrieve data that the query did not intend to expose. This can be avoided by changing the return type of the method to <xref:System.Collections.Generic.IEnumerable%601> and calling a method (such as `.ToList()`) that materializes the results.

- Because <xref:System.Linq.IQueryable%601> queries are executed when the results are iterated over, a consumer of a query that exposes an <xref:System.Linq.IQueryable%601> type could catch exceptions that are thrown. Exceptions could contain information not intended for the consumer.

## Security Considerations for Entities

 The following security considerations apply when generating and working with entity types.

### Do not share an ObjectContext across application domains

 Sharing an <xref:System.Data.Objects.ObjectContext> with more than one application domain may expose information in the connection string. Instead, you should transfer serialized objects or object graphs to the other application domain and then attach those objects to an <xref:System.Data.Objects.ObjectContext> in that application domain. For more information, see [Serializing Objects](/previous-versions/dotnet/netframework-4.0/bb738446(v=vs.100)).

### Prevent type safety violations

 If type safety is violated, Entity Framework cannot guarantee the integrity of data in objects. Type safety violations could occur if you allow untrusted applications to run with full-trust code access security.

### Handle exceptions

 Access methods and properties of an <xref:System.Data.Objects.ObjectContext> within a try-catch block. Catching exceptions prevents unhandled exceptions from exposing entries in the <xref:System.Data.Objects.ObjectStateManager> or model information (such as table names) to users of your application.

## Security Considerations for ASP.NET Applications

You should consider the following when you work with paths in ASP.NET applications.

### Verify whether your host performs path checks

 When the `|DataDirectory|` (enclosed in pipe symbols) substitution string is used, ADO.NET verifies that the resolved path is supported. For example, ".." is not allowed behind `DataDirectory`. That same check for resolving the Web application root operator (`~`) is performed by the process hosting ASP.NET. IIS performs this check; however, hosts other than IIS may not verify that the resolved path is supported. You should know the behavior of the host on which you deploy an Entity Framework application.

### Do not make assumptions about resolved path names

 Although the values to which the root operator (`~`) and the `DataDirectory` substitution string resolve should remain constant during the application's runtime, Entity Framework does not restrict the host from modifying these values.

### Verify the path length before deployment

 Before deploying an Entity Framework application, you should ensure that the values of the root operator (~) and `DataDirectory` substitution string do not exceed the limits of the path length in the operating system. ADO.NET data providers do not ensure that the path length is within valid limits.

## Security Considerations for ADO.NET Metadata

 The following security considerations apply when generating and working with model and mapping files.

### Do not expose sensitive information through logging

ADO.NET metadata service components do not log any private information. If there are results that cannot be returned because of access restrictions, database management systems and file systems should return zero results instead of raising an exception that could contain sensitive information.

### Do not accept MetadataWorkspace objects from untrusted sources

 Applications should not accept instances of the <xref:System.Data.Metadata.Edm.MetadataWorkspace> class from untrusted sources. Instead, you should explicitly construct and populate a workspace from such a source.

## See also

- [Securing ADO.NET Applications](../securing-ado-net-applications.md)
- [Deployment Considerations](deployment-considerations.md)
- [Migration Considerations](migration-considerations.md)
