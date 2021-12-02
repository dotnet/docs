---
title: Migrating Modern Desktop applications
description: Everything you need to know about the migration process for modern desktop applications.
ms.date: 10/25/2021
---

# Migrating Modern Desktop applications

In this chapter, we're exploring the most common issues and challenges you can face when migrating an existing application from .NET Framework to .NET.

If you just want to update your application to the latest .NET version using a tool and not get into the details of what's happening behind the scenes, feel free to skip this chapter and find step-by-step instructions in the [Example of migrating to .NET](example-migration.md) chapter.

A complex desktop application doesn't work in isolation and needs some kind of interaction with subsystems that may reside on the local machine or on a remote server. It will probably need some kind of database to connect as a persistence
storage either locally or remotely. With the raise of Internet and service-oriented architectures, it's common to have your application connected to some sort of service residing on a remote server or in the cloud. You may need to access the machine file system to implement some functionality. Alternatively, maybe you're using a piece of functionality that resides inside a COM object outside your application, which is a common scenario if, for example, you're integrating Office assemblies in your app.

Besides, there are differences in the API surface that is exposed by .NET Framework and .NET, and some features that are available on .NET Framework aren't available on .NET. So, it's important for you to know and take them into account when planning a migration.

## Configuration files

Configuration files offer the possibility to store sets of properties that are read at run time and affect the behavior of our apps, such as where to locate a database or how many times to execute a loop. The beauty of this technique is that you can modify some aspects of the application without the need to recode and recompile. This comes in handy when, for example, the same app code runs on a development environment with a certain set of configuration values and in production with a different one.

### Configuration on .NET Framework

If you have a working .NET Framework desktop application, chances are you have an *app.config* file accessed through the <xref:System.Configuration.AppSettingsSection> class from the `System.Configuration` namespace.

Within the .NET Framework infrastructure, there's a hierarchy of configuration files that inherit properties from its parents. You can find a *machine.config* file that defines many properties and configuration sections that can be used
or overridden in any descendant configuration file.

### Configuration on .NET

In the .NET world, there's no *machine.config* file. And even though you can continue to use the old fashioned <xref:System.Configuration> namespace, you may consider switching to the modern <xref:Microsoft.Extensions.Configuration>, which offers a good number of enhancements.

The configuration API supports the concept of configuration provider, which defines the data source to be used to load the configuration. There are different kinds of built-in providers, such as:

- In-memory .NET objects
- INI files
- JSON files
- XML files
- Command-line arguments
- Environment variables
- Encrypted user store

 Or you can build your own.

The new configuration allows a list of name-value pairs that can be grouped into a multi-level hierarchy. Any stored value maps to a string, and there's built-in binding support that allows you to deserialize settings into a custom plain old CLR object (POCO).

The <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> object lets you add as many configuration providers you may need for your application, using a precedence rule to resolve preference. So, the last provider you add in your code will override the others. This is a great feature for managing different environments for execution since you can define different configurations for development, testing and production environments, and manage them on a single function inside your code.

### Migrating Configuration files

You can continue to use your existing app.config XML file. However, you could take this opportunity to migrate your configuration to benefit from the several enhancements made on .NET.

To migrate from an old-style *app.config* to a new configuration file, you should choose between an XML format and a JSON format.

If you choose XML, the conversion is straightforward. Since the content is the same, just save the *app.config* file with XML as type. Then, change the code that references AppSettings to use the `ConfigurationBuilder` class. This change should be easy.

If you want to use a JSON format and you don't want to migrate by hand, there's a tool called [dotnet-config2json](https://www.nuget.org/packages/dotnet-config2json/) available on .NET that can convert an *app.config* file to a JSON configuration file.

You may also come across some issues when using configuration sections that were defined in the *machine.config* file. For example, consider the following configuration:

```xml
<configuration>
    <system.diagnostics>
        <switches>
            <add name="General" value="4" />
        </switches>
        <trace autoflush="true" indentsize="2">
            <listeners>
                <add name="myListener"
                     type="System.Diagnostics.TextWriterTraceListener,
                           System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                     initializeData="MyListener.log"
                     traceOutputOptions="ProcessId, LogicalOperationStack, Timestamp, ThreadId, Callstack, DateTime" />
            </listeners>
        </trace>
    </system.diagnostics>
</configuration>
```

If you take this configuration to a .NET, you'll get an exception:

> Unrecognized configuration section System.Diagnostics

This exception occurs because that section and the assembly responsible for handling that section was defined in the *machine.config* file, which now doesn't exist.

To easily fix the issue, you can copy the section definition from your old *machine.config* to your new configuration file:

```xml
<configSections>
    <section name="system.diagnostics"
             type="System.Diagnostics.SystemDiagnosticsSection,
                   System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
</configSections>
```

## Accessing databases

Almost every desktop application needs some kind of database. For desktop, it's common to find client-server architectures with a direct connection between the desktop app and the database engine. These databases can be local or remote depending on the need to share information between different users.

From the code perspective, there have been many technologies and frameworks to give the developer the possibility to connect, query, and update a database.

The most common examples of database you can find when talking about Windows Desktop application are Microsoft Access and Microsoft SQL Server. If you have more than 20 years of experience programming for the desktop, names like ODBC, OLEDB, RDO, ADO, ADO.NET, LINQ, and Entity Framework will sound familiar.

### ODBC

You can continue to use ODBC on .NET since Microsoft is providing the `System.Data.Odbc` library compatible with .NET Standard 2.0.

### OLE DB

[OLE DB](/previous-versions/windows/desktop/ms722784(v=vs.85)) has been a great way to access various data sources in a uniform manner. But it was based on COM, which is a Windows-only technology, and as such wasn't the best fit for a cross-platform technology such as .NET. It's also unsupported in SQL Server versions 2014 and later. For those reasons, OLE DB won't be supported by .NET.

### ADO.NET

You can still use ADO.NET from your existing desktop code on .NET. You just need to update some NuGet packages.

### EF Core vs. EF6

There are two currently supported versions of Entity Framework (EF), Entity Framework 6 (EF6) and EF Core.

The latest technology released as part of the .NET Framework world is Entity Framework, with 6.4 being the latest version. With the launch of .NET Core, Microsoft also released a new data access stack based on Entity Framework and called Entity Framework Core.

You can use EF 6.4 and EF Core from both .NET Framework and .NET. So, what are the decision drivers to help to decide between the two?

EF 6.3 is the first version of EF6 that can run on .NET and work cross-platform. In fact, the main goal of this release was to make it easier to migrate existing applications that use EF6 to .NET.

EF Core was designed to provide a developer experience similar to EF6. Most of the top-level APIs remain the same, so EF Core will feel familiar to developers who have used EF6.

Although compatible, there are differences on the implementation you should check before making a decision.
For more information, see [Compare EF Core & EF6](/ef/efcore-and-ef6/).

The recommendation is to use EF Core if:

* The app needs the capabilities of .NET.
* EF Core supports all of the features that the app requires.

Consider using EF6 if both of the following conditions are true:

* The app will run on Windows and .NET Framework 4.0 or later.
* EF6 supports all of the features that the app requires.

### Relational databases

#### SQL Server

SQL Server has been one of the databases of choice if you were developing for the desktop some years ago. With the use of <xref:System.Data.SqlClient> in .NET Framework, you could access versions of SQL Server, which encapsulates database-specific protocols.

In .NET, you can find a new `SqlClient` class, fully compatible with the one existing in the .NET Framework but located in the <xref:Microsoft.Data.SqlClient> library. You just have to add a reference to the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient/) NuGet package and do some renaming for the namespaces and everything should work as expected.

#### Microsoft Access

Microsoft Access has been used for years when the sophisticated and more scalable SQL Server wasn't needed. You can still connect
to Microsoft Access using the <xref:System.Data.Odbc> library.

## Consuming services

With the rise of service-oriented architectures, desktop applications began to evolve from a client-server model to the three-layer approach. In the client-server approach, a direct database connection is established from the client holding the business logic, usually inside a single EXE file. On the other hand, the three-layer approach establishes an intermediate service layer implementing business logic and database access, allowing for better security, scalability, and reusability. Instead of working directly with underlying data, the layered approach relies on a set of services implementing contracts and typed objects for data transfer.

If you have a desktop application using a WCF service and you want to migrate it to .NET, there are some things to consider.

The first thing is how to resolve the configuration to access the service. Because the configuration is different on .NET, you'll need to make some updates in your configuration file.

Second, you'll need to regenerate the service client with the new tools present on Visual Studio 2019. In this step, you must consider activating the generation of the synchronous operations to make the client compatible with your existing code.

After the migration, if you find that there are libraries you need that aren't present on .NET, you can add a reference to the [Microsoft.Windows.Compatibility](https://www.nuget.org/packages/Microsoft.Windows.Compatibility) NuGet package and see if the missing functions are there.

If you're using the <xref:System.Net.WebRequest> class to perform web service calls, you may find some differences on .NET. The recommendation is to use the System.Net.Http.HttpClient instead.

## Consuming a COM Object

Currently, there's no way to add a reference to a COM object from Visual Studio 2019 to use with .NET. So, you have to manually modify the project file.

Insert a `COMReference` structure inside the project file like in the following example:

```xml
<ItemGroup>
    <COMReference Include="MSHTML">
        <Guid>{3050F1C5-98B5-11CF-BB82-00AA00BDCE0B}\</Guid>
        <VersionMajor>4</VersionMajor>
        <VersionMinor>0</VersionMinor>
        <Lcid>0</Lcid>
        <WrapperTool>primary</WrapperTool>
        <Isolated>false</Isolated>
    </COMReference>
</ItemGroup>
```

## More things to consider

Several technologies available to .NET Framework libraries aren't available for .NET Core or .NET 5. If your code relies on some of these technologies, consider the alternative approaches outlined in this section.

The [Windows Compatibility Pack](../../core/porting/windows-compat-pack.md) provides access to APIs that were previously available only for .NET Framework. It can be used on .NET Core and .NET Standard projects.

For more information on API compatibility, you can find documentation about breaking changes and deprecated/legacy APIs at
[https://docs.microsoft.com/dotnet/core/compatibility/fx-core](../../core/compatibility/fx-core.md).

### AppDomains

Application domains (AppDomains) isolate apps from one another. AppDomains require runtime support and are expensive. Creating additional app domains isn't supported. For code isolation, we recommend separate processes or using containers as an alternative. For the dynamic loading of assemblies, we recommend the new <xref:System.Runtime.Loader.AssemblyLoadContext> class.

To make code migration from .NET Framework easier, .NET exposes some of the `AppDomain` API surface. Some of the APIs function normally (for example, <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType>), some members do nothing (for example, <xref:System.AppDomain.SetCachePath%2A>), and some of them throw <xref:System.PlatformNotSupportedException> (for example, <xref:System.AppDomain.CreateDomain%2A>).

### Remoting

.NET Remoting was used for cross-AppDomain communication, which is no longer supported. Also, Remoting requires runtime support, which is expensive to maintain. For these reasons, .NET Remoting isn't supported on .NET.

For communication across processes, you should consider inter-process communication (IPC) mechanisms as an alternative to Remoting, such as the <xref:System.IO.Pipes?displayProperty=nameWithType> or the <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> class.

Across machines, use a network-based solution as an alternative. Preferably, use a low-overhead plaintext protocol, such as HTTP. The Kestrel web server, the web server used by ASP.NET Core, is an option here.

### Code Access Security (CAS)

Sandboxing, which relies on the runtime or the framework to constrain which resources a managed application or library uses or runs, isn't supported on .NET.

Use security boundaries that are provided by the operating system, such as virtualization, containers, or user accounts for running processes with the minimum set of privileges.

### Security Transparency

Similar to CAS, Security Transparency separates sandboxed code from security critical code in a declarative fashion but is no longer supported as a security boundary.

Use security boundaries that are provided by the operating system, such as virtualization, containers, or user accounts for running processes with the least set of privileges.

>[!div class="step-by-step"]
>[Previous](whats-new-dotnet.md )
>[Next](windows-migration.md)
