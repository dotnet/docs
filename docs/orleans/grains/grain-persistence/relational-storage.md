---
title: ADO.NET grain persistence
description: Learn about ADO.NET grain persistence in .NET Orleans.
ms.date: 07/03/2024
ms.topic: article
---

# ADO.NET grain persistence

Relational storage backend code in Orleans is built on generic ADO.NET functionality and is consequently database vendor agnostic. The Orleans data storage layout has been explained already in runtime tables. Setting up the connection strings is done as explained in [Orleans Configuration Guide](../../host/configuration-guide/index.md).

To make Orleans code function with a given relational database backend, the following is required:

1. The appropriate ADO.NET library must be loaded into the process. This should be defined as usual, e.g. via the [DbProviderFactories](../../../framework/data/adonet/obtaining-a-dbproviderfactory.md) element in the application configuration.
2. Configure the ADO.NET invariant via the `Invariant` property in the options.
3. The database needs to exist and be compatible with the code. This is done by running a vendor-specific database creation script. For more information, see [ADO.NET Configuration](../../host/configuration-guide/adonet-configuration.md).

The ADO .NET grain storage provider allows you to store the grain state in relational databases.
Currently, the following databases are supported:

* SQL Server
* MySQL/MariaDB
* PostgreSQL
* Oracle

First, install the base package:

```powershell
Install-Package Microsoft.Orleans.Persistence.AdoNet
```

Read the [ADO.NET configuration](../../host/configuration-guide/adonet-configuration.md) article for information on configuring your database, including the corresponding ADO.NET Invariant and the setup scripts.

The following is an example of how to configure an ADO.NET storage provider via <xref:Orleans.Hosting.ISiloHostBuilder>:

```csharp
var siloHostBuilder = new HostBuilder()
    .UseOrleans(c =>
    {
        c.AddAdoNetGrainStorage("OrleansStorage", options =>
        {
            options.Invariant = "<Invariant>";
            options.ConnectionString = "<ConnectionString>";
            options.UseJsonFormat = true;
        });
    });
```

Essentially, you only need to set the database-vendor-specific connection string and an
`Invariant` (see [ADO.NET Configuration](../../host/configuration-guide/adonet-configuration.md)) that identifies the vendor. You may also choose the format in which the data is saved, which may be either binary (default), JSON, or XML. While binary is the most compact option, it is opaque, and you will not be able to read or work with the data. JSON is the recommended option.

You can set the following properties via <xref:Orleans.Configuration.AdoNetGrainStorageOptions>:

```csharp
/// <summary>
/// Options for AdoNetGrainStorage
/// </summary>
public class AdoNetGrainStorageOptions
{
    /// <summary>
    /// Define the property of the connection string
    /// for AdoNet storage.
    /// </summary>
    [Redact]
    public string ConnectionString { get; set; }

    /// <summary>
    /// Set the stage of the silo lifecycle where storage should
    /// be initialized.  Storage must be initialized prior to use.
    /// </summary>
    public int InitStage { get; set; } = DEFAULT_INIT_STAGE;
    /// <summary>
    /// Default init stage in silo lifecycle.
    /// </summary>
    public const int DEFAULT_INIT_STAGE =
        ServiceLifecycleStage.ApplicationServices;

    /// <summary>
    /// The default ADO.NET invariant will be used for
    /// storage if none is given.
    /// </summary>
    public const string DEFAULT_ADONET_INVARIANT =
        AdoNetInvariants.InvariantNameSqlServer;

    /// <summary>
    /// Define the invariant name for storage.
    /// </summary>
    public string Invariant { get; set; } =
        DEFAULT_ADONET_INVARIANT;

    /// <summary>
    /// Determine whether the storage string payload should be formatted in JSON.
    /// <remarks>If neither <see cref="UseJsonFormat"/> nor <see cref="UseXmlFormat"/> is set to true, then BinaryFormatSerializer will be configured to format the storage string payload.</remarks>
    /// </summary>
    public bool UseJsonFormat { get; set; }
    public bool UseFullAssemblyNames { get; set; }
    public bool IndentJson { get; set; }
    public TypeNameHandling? TypeNameHandling { get; set; }

    public Action<JsonSerializerSettings> ConfigureJsonSerializerSettings { get; set; }

    /// <summary>
    /// Determine whether storage string payload should be formatted in Xml.
    /// <remarks>If neither <see cref="UseJsonFormat"/> nor <see cref="UseXmlFormat"/> is set to true, then BinaryFormatSerializer will be configured to format storage string payload.</remarks>
    /// </summary>
    public bool UseXmlFormat { get; set; }
}
```

The ADO.NET persistence has the functionality to version data and define arbitrary (de)serializers with arbitrary application rules and streaming, but currently, there is no method to expose it to application code.

## ADO.NET persistence rationale

The principles for ADO.NET backed persistence storage are:

1. Keep business-critical data safe and accessible while data, the format of data, and the code evolve.
2. Take advantage of vendor-specific and storage-specific functionality.

In practice, this means adhering to ADO.NET implementation goals, and some added implementation logic in ADO.NET-specific storage providers that allow evolving the shape of the data in the storage.

In addition to the usual storage provider capabilities, the ADO.NET provider has built-in capability to:

1. Change storage data from one format to another (e.g. from JSON to binary) when round-tripping state.
2. Shape the type to be saved or read from the storage in arbitrary ways. This allows the version of the state to evolve.
3. Stream data out of the database.

Both `1.` and `2.` can be applied based on arbitrary decision parameters, such as *grain ID*, *grain type*, *payload data*.

This is the case so that you can choose a serialization format, e.g. [Simple Binary Encoding (SBE)](https://github.com/real-logic/simple-binary-encoding) and implements <xref:Orleans.Storage.IStorageDeserializer> and <xref:Orleans.Storage.IStorageSerializer>. The built-in serializers have been built using this method:

- <xref:Orleans.Storage.OrleansStorageDefaultXmlSerializer>
- <xref:Orleans.Storage.OrleansStorageDefaultXmlDeserializer>
- <xref:Orleans.Storage.OrleansStorageDefaultJsonSerializer>
- <xref:Orleans.Storage.OrleansStorageDefaultJsonDeserializer>
- <xref:Orleans.Storage.OrleansStorageDefaultBinarySerializer>
- <xref:Orleans.Storage.OrleansStorageDefaultBinaryDeserializer>

When the serializers have been implemented, they need to be added to the <xref:Orleans.Storage.AdoNetGrainStorage.StorageSerializationPicker%2A> property in <xref:Orleans.Storage.AdoNetGrainStorage>. Here is an implementation of `IStorageSerializationPicker`. By default, `StorageSerializationPicker` will be used. An example of changing the data storage format or using serializers can be seen at [RelationalStorageTests](https://github.com/dotnet/orleans/blob/main/test/Extensions/TesterAdoNet/StorageTests/Relational/RelationalStorageTests.cs).

Currently, there is no method to expose the serialization picker to the Orleans application as there is no method to access the framework-created `AdoNetGrainStorage`.

## Goals of the design

### 1. Allow the use of any backend that has an ADO.NET provider

This should cover the broadest possible set of backends available for .NET, which is a factor in on-premises installations. Some providers are listed at [ADO.NET overview](../../../framework/data/adonet/ado-net-overview.md), but not all are listed, such as [Teradata](https://downloads.teradata.com/download/connectivity/net-data-provider-for-teradata).

### 2. Maintain the potential to tune queries and database structure as appropriate, even while a deployment is running

In many cases, the servers and databases are hosted by a third party in contractual relation with the client. It is not an unusual
situation to find a hosting environment that is virtualized, and where performance fluctuates due to unforeseen factors, such as noisy neighbors or faulty hardware. It may not be possible to alter and re-deploy either Orleans binaries (for contractual reasons) or even application binaries, but it is usually possible to tweak the database deployment parameters. Altering *standard components*, such as Orleans binaries, requires a lengthier procedure for optimizing in a given situation.

### 3. Allow you to make use of vendor-specific and version-specific abilities

Vendors have implemented different extensions and features within their products. It's sensible to make use of these features when they're available. These are features such as [native UPSERT](https://www.postgresql.org/about/news/1636/) or [PipelineDB](https://github.com/pipelinedb/pipelinedb/blob/master/README.md) in PostgreSQL, and [PolyBase](/sql/relational-databases/polybase/get-started-with-polybase) or [natively compiled tables and stored procedures](/sql/relational-databases/in-memory-oltp/native-compilation-of-tables-and-stored-procedures) in SQL Server.

### 4. Make it possible to optimize hardware resources

When designing an application, it is often possible to anticipate which data needs to be inserted faster than other data, and which data could more likely be put into *cold storage*, which is cheaper (e.g. splitting data between SSD and HDD). Additional considerations include the physical location of the data (some data could be more expensive (e.g. SSD RAID viz HDD RAID), or more secured), or some other decision basis. Related to *point 3.*, some databases offer special partitioning schemes, such as SQL Server [Partitioned Tables and Indexes](/sql/relational-databases/partitions/partitioned-tables-and-indexes).

These principles apply throughout the application life-cycle. Considering that one of the principles of Orleans itself is high availability, it should be possible to adjust the storage system without interruption to the Orleans deployment, or it should be possible to adjust the queries according to data and other application parameters. An example of dynamic changes may be seen in Brian Harry's [blog post](https://devblogs.microsoft.com/bharry/a-bit-more-on-the-feb-3-and-4-incidents/):

> When a table is small, it almost doesn't matter what the query plan is. When it's medium, an OK query plan is fine, but when it's huge (millions upon millions or billions of rows), even a slight variation in the query plan can kill you. For this reason, we hint our sensitive queries heavily.

### 5. No assumptions on what tools, libraries, or deployment processes are used in organizations

Many organizations have familiarity with a certain set of database tools, examples being [Dacpac](/sql/relational-databases/data-tier-applications/data-tier-applications) or [Red Gate](https://www.red-gate.com/). It may be that deploying a database requires either permission or a person, such as someone in a DBA role, to do it. Usually, this means also having the target database layout and a rough sketch of the queries the application will produce for use in estimating the load. There might be processes, perhaps influenced by industry standards, which mandate script-based deployment. Having the queries and database structures in an external script makes this possible.

### 6. Use the minimum set of interface functionality needed to load the ADO.NET libraries and functionality

This is both fast and has less surface exposed to the ADO.NET library implementation discrepancies.

### 7. Make the design shardable

When it makes sense, for instance in a relational storage provider, make the design readily shardable. For instance, this means using no database-dependent data (e.g. `IDENTITY`). Information that distinguishes row data should build on only data from the actual parameters.

### 8. Make the design easy to test

Creating a new backend should ideally be as easy as translating one of the existing deployment scripts into the SQL dialect of the backend you are trying to target, adding a new connection string to the tests (assuming default
parameters), checking to see if a given database is installed, and then running the tests against it.

### 9. Taking into account the previous points, make both porting scripts for new backends and modifying already-deployed backend scripts as transparent as possible

## Realization of the goals

The Orleans framework does not know about deployment-specific hardware (which hardware may change during active deployment), the change of data during the deployment life-cycle, or certain vendor-specific features which are only usable in certain situations. For this reason, the interface between the database and Orleans should adhere to the minimum set of abstractions and rules to meet these goals, make it robust against misuse, and make it easy to test if needed. Runtime Tables, Cluster Management and the concrete [membership protocol implementation](https://github.com/dotnet/orleans/blob/main/src/Orleans.Core/SystemTargetInterfaces/IMembershipTable.cs). Also, the SQL Server implementation contain SQL Server edition-specific tuning. The interface contract between the database and Orleans is defined as follows:

1. The general idea is that data is read and written through Orleans-specific queries.
   Orleans operates on column names and types when reading, and on parameter names and types when writing.
2. The implementations **must** preserve input and output names and types. Orleans uses these parameters to read query results by name and type.
   Vendor-specific and deployment-specific tuning is allowed, and contributions are encouraged as long as the interface contract is maintained.
3. The implementation across vendor-specific scripts **should** preserve the constraint names.
   This simplifies troubleshooting, by virtue of uniform naming across concrete implementations.
4. **Version** &ndash; or **ETag** in application code &ndash; for Orleans, this represents a unique version.
   The type of its actual implementation is not important as long as it represents a unique version. In the implementation, Orleans code expects a signed 32-bit integer.
5. For the sake of being explicit and removing ambiguity, Orleans expects some queries to return either **TRUE as > 0** value
   or **FALSE as = 0** value. That is, the number of affected or returned rows does not matter. If an error is raised or an exception is thrown,
   the query **must** ensure the entire transaction is rolled back and may either return FALSE or propagate the exception.
6. Currently, all but one query are single-row inserts or updates (note, one could replace `UPDATE` queries with `INSERT`, provided the associated
   `SELECT` queries performed the last write).

Database engines support in-database programming. This is similar to the idea of loading an executable script and invoking it to execute database operations. In pseudocode it could be depicted as:

```csharp
const int Param1 = 1;
const DateTime Param2 = DateTime.UtcNow;
const string queryFromOrleansQueryTableWithSomeKey =
    "SELECT column1, column2 "+
    "FROM <some Orleans table> " +
    "WHERE column1 = @param1 " +
    "AND column2 = @param2;";
TExpected queryResult =
    SpecificQuery12InOrleans<TExpected>(query, Param1, Param2);
```

These principles are also [included in the database scripts](../../host/configuration-guide/adonet-configuration.md).

## Some ideas on applying customized scripts

1. Alter scripts in `OrleansQuery` for grain persistence with `IF ELSE`
   so that some state is saved using the default `INSERT`, while some grain states may use [memory optimized tables](/sql/relational-databases/in-memory-oltp/memory-optimized-tables).
   The `SELECT` queries need to be altered accordingly.
2. The idea in `1.` can be used to take advantage of another deployment- or vendor-specific aspects, such as splitting data between `SSD` or `HDD`, putting some data in encrypted tables,
   or perhaps inserting statistics data via SQL-Server-to-Hadoop, or even [linked servers](/sql/relational-databases/linked-servers/linked-servers-database-engine).

The altered scripts can be tested by running the Orleans test suite, or straight in the database using, for instance, [SQL Server Unit Test Project](/previous-versions/sql/sql-server-data-tools/jj851212(v=vs.103)).

## Guidelines for adding new ADO.NET providers

1. Add a new database setup script according to the [Realization of the goals](#realization-of-the-goals) section above.
2. Add the vendor ADO invariant name to <xref:Orleans.SqlUtils.AdoNetInvariants> and ADO.NET provider-specific data to [DbConstantsStore](https://github.com/dotnet/orleans/blob/main/src/AdoNet/Shared/Storage/DbConstantsStore.cs). These are (potentially) used in some query operations. e.g. to select the correct statistics insert mode (i.e. the `UNION ALL` with or without `FROM DUAL`).
3. Orleans has comprehensive tests for all system stores: membership, reminders and statistics. Adding tests for the new database script is done by copy-pasting existing test classes and changing the ADO invariant name. Also, derive from [RelationalStorageForTesting](https://github.com/dotnet/orleans/blob/main/test/Extensions/TesterAdoNet/RelationalUtilities/RelationalStorageForTesting.cs) in order to define test functionality for the ADO invariant.
