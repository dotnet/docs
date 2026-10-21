---
title: "Obtaining a DbProviderFactory"
description: Learn how to obtain a DbProviderFactory from the DbProviderFactories class to work with specific data sources in .NET Framework.
ms.date: "10/19/2026"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
---
# Obtaining a DbProviderFactory

The process of obtaining a <xref:System.Data.Common.DbProviderFactory> involves passing information about a data provider to the <xref:System.Data.Common.DbProviderFactories> class. Based on this information, the <xref:System.Data.Common.DbProviderFactories.GetFactory*> method returns a strongly typed provider factory. For example, after you register <xref:Microsoft.Data.SqlClient.SqlClientFactory>, pass `GetFactory` the provider name `Microsoft.Data.SqlClient`. Another overload of `GetFactory` takes a <xref:System.Data.DataRow>. Once you obtain the provider factory, you can then use its methods to create additional objects. Some of the methods of a `SqlClientFactory` include <xref:Microsoft.Data.SqlClient.SqlClientFactory.CreateConnection*>, <xref:Microsoft.Data.SqlClient.SqlClientFactory.CreateCommand*>, and <xref:Microsoft.Data.SqlClient.SqlClientFactory.CreateDataAdapter*>.

> [!NOTE]
> The <xref:System.Data.OracleClient.OracleClientFactory>, <xref:System.Data.Odbc.OdbcFactory>, and <xref:System.Data.OleDb.OleDbFactory> classes also provide similar functionality.

## Registering DbProviderFactories

Install the [Microsoft.Data.SqlClient NuGet package](https://www.nuget.org/packages/Microsoft.Data.SqlClient) before you register its factory.

On .NET Framework, add the following `system.data` section inside the `configuration` element of your application's `app.config` or `web.config` file. The `remove` element avoids duplicate registrations inherited from another configuration file.

```xml
<system.data>
  <DbProviderFactories>
    <remove invariant="Microsoft.Data.SqlClient" />
    <add name="Microsoft SqlClient Data Provider"
     invariant="Microsoft.Data.SqlClient"
     description="Microsoft SqlClient Data Provider for SQL Server"
     type="Microsoft.Data.SqlClient.SqlClientFactory, Microsoft.Data.SqlClient"
    />
  </DbProviderFactories>
</system.data>
```

On modern .NET, configuration files don't register provider factories. Before you call `GetFactory`, call <xref:System.Data.Common.DbProviderFactories.RegisterFactory(System.String,System.Data.Common.DbProviderFactory)> with `Microsoft.Data.SqlClient` as the provider name and <xref:Microsoft.Data.SqlClient.SqlClientFactory.Instance> as the factory instance. `RegisterFactory` isn't available on .NET Framework.

The following examples register the factory in code for modern .NET. For .NET Framework, use the previous configuration entry and omit any `RegisterFactory` call.

The invariant provider name identifies the underlying data provider. Use the same name for factory lookups and the `providerName` attribute of a connection string.

## Retrieving Provider Information

 You can retrieve information about registered data providers by using the <xref:System.Data.Common.DbProviderFactories.GetFactoryClasses*> method. It returns a <xref:System.Data.DataTable> named `DbProviderFactories` that contains the columns described in the following table. The example values correspond to the .NET Framework configuration entry shown previously; assembly version details depend on the installed package.

| Column ordinal | Column name     | Example output                             | Description                               |
|----------------|-----------------|--------------------------------------------|-------------------------------------------|
| 0              | `Name`        | Microsoft SqlClient Data Provider                    | Readable name for the data provider       |
| 1              | `Description` | Microsoft SqlClient Data Provider for SQL Server | Readable description of the data provider |
| 2              | `InvariantName` | Microsoft.Data.SqlClient | Name that can be used programmatically to refer to the data provider|
| 3              | `AssemblyQualifiedName` | Microsoft.Data.SqlClient.SqlClientFactory, Microsoft.Data.SqlClient | Assembly-qualified name of the factory class |

 This `DataTable` can be used to enable a user to select a <xref:System.Data.DataRow> at runtime. The selected `DataRow` can then be passed to the <xref:System.Data.Common.DbProviderFactories.GetFactory*> method to create a strongly typed <xref:System.Data.Common.DbProviderFactory>. A selected <xref:System.Data.DataRow> can be passed to the `GetFactory` method to create the desired `DbProviderFactory` object.

## Listing the Installed Provider Factory Classes

 This example demonstrates how to use the <xref:System.Data.Common.DbProviderFactories.GetFactoryClasses*> method to return a <xref:System.Data.DataTable> containing information about the installed providers. The code iterates through each row in the `DataTable`, displaying information for each installed provider in the console window.

 [!code-csharp[DataWorks DbProviderFactories#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DbProviderFactories/CS/source.cs#1)]
 [!code-vb[DataWorks DbProviderFactories#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DbProviderFactories/VB/source.vb#1)]

## Using Application Configuration Files to Store Factory Information

 The design pattern used for working with factories entails storing provider and connection string information in an application configuration file, such as **app.config** for a Windows application, and **web.config** for an ASP.NET application.

 The following configuration file fragment demonstrates how to save two named connection strings: "NorthwindSQL" for a connection to the Northwind database in SQL Server, and "NorthwindAccess" for a connection to the Northwind database in Access/Jet. The `invariant` name is used for the `providerName` attribute.

```xml
<configuration>
  <connectionStrings>
    <clear/>
    <add name="NorthwindSQL"
     providerName="Microsoft.Data.SqlClient"
     connectionString=
     "Data Source=&lt;server&gt;;Initial Catalog=Northwind;Integrated Security=true;Encrypt=true"
    />

    <add name="NorthwindAccess"
     providerName="System.Data.OleDb"
     connectionString=
     "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Northwind.mdb;"
    />
  </connectionStrings>
</configuration>
```

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

### Retrieve a Connection String by Provider Name

 To create a connection through a provider factory, supply a connection string as well as the provider name. This example demonstrates how to retrieve a connection string from an application configuration file by passing the invariant provider name, such as `Microsoft.Data.SqlClient`. The code iterates through the <xref:System.Configuration.ConnectionStringSettingsCollection>. It returns the matching connection string on success; otherwise `null` (`Nothing` in Visual Basic). If there are multiple entries for a provider, the first one found is returned. For more information and examples of retrieving connection strings from configuration files, see [Connection Strings and Configuration Files](connection-strings-and-configuration-files.md).

> [!NOTE]
> A reference to `System.Configuration.dll` is required in order for the code to run.

 [!code-csharp[DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider/CS/source.cs#1)]
 [!code-vb[DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks ConnectionStringSettings.RetrieveFromConfigByProvider/VB/source.vb#1)]

## Creating the DbProviderFactory and DbConnection

 This example demonstrates how to create a <xref:System.Data.Common.DbProviderFactory> and <xref:System.Data.Common.DbConnection> object by passing it the invariant provider name, such as `Microsoft.Data.SqlClient`, and a connection string. A `DbConnection` object is returned on success; `null` (`Nothing` in Visual Basic) on any error.

 The code obtains the `DbProviderFactory` by calling <xref:System.Data.Common.DbProviderFactories.GetFactory*>. Then the <xref:System.Data.Common.DbProviderFactory.CreateConnection*> method creates the <xref:System.Data.Common.DbConnection> object and the <xref:System.Data.Common.DbConnection.ConnectionString> property is set to the connection string.

 [!code-csharp[DataWorks DbProviderFactories.GetFactory#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DbProviderFactories.GetFactory/CS/source.cs#1)]
 [!code-vb[DataWorks DbProviderFactories.GetFactory#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DbProviderFactories.GetFactory/VB/source.vb#1)]

## See also

- [DbProviderFactories](dbproviderfactories.md)
- [Connection Strings](connection-strings.md)
- [Using the Configuration Classes](/previous-versions/aspnet/ms228063(v=vs.100))
- [ADO.NET Overview](ado-net-overview.md)
