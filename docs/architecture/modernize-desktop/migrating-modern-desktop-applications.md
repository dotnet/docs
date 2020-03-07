---
title: Migrating Modern Desktop Applications
description: Everything you need to know about the migration process for modern desktop applications.
ms.date: 09/16/2019
---

# Migrating Modern Desktop Applications

In this chapter, we are exploring the most common issues and challenges you can
face when migrating an existing application from .NET Framework to .NET Core.

A complex desktop application does not work in isolation and needs some kind of
interaction with subsystems that may reside on the local machine or on a remote
server. It will probably need some kind of database to connect as a persistence
storage either local or remotely. With the raise of Internet and
service-oriented architectures, it's common to have your application
connected to some sort of service residing on a remote server or in the cloud.
You may need to access the machine file system to implement some functionality.
Alternatively, maybe you are using a piece of functionality that resides inside
a COM object outside your application that is a common scenario if, for
example, you are integrating Office assemblies in your app.

Besides, there are differences in the surface of the APIs exposed by .NET
Framework and .NET Core and some parts of what is existing on .NET Framework is
no longer available on .NET Core, so it is important for you to know and take
into account when planning a migration.

## Configuration files

Configuration files offer the possibility to store sets of properties that are
read at runtime affecting the behavior of our apps like where to locate a
database or how many times to execute a loop. The beauty of this technique is
that you can modify some aspects of the application without the need to recode
and recompile. This comes in handy when, for example,  the same app code runs on a
development environment with a certain set of configuration values and in
production with a different one.

### Configuration on .NET Framework

If you have a working .NET Framework desktop application chances are you have an
app.config file accessed through the AppSettings class from System.Configuration
namespace.

Within the .NET Framework infrastructure, there is a hierarchy of configuration
files that inherit properties from its parents. You can find a machine.config
that defines a bunch of properties and configuration sections that can be used
or overridden in any descendant configuration file.

### Configuration on .NET Core

In the .NET Core world, there is no machine.config and although you can continue
to use the old fashioned System.Configuration you may consider to switch to the
modern Microsoft.Extensions.Configuration, which offers a good number of enhancements.

The configuration API supports the concept of configuration provider that
defines the source of data to be used to load the configuration. There are a
variety of built-in providers like in-memory .NET objects, INI files, JSON
files, XML files, command-line arguments, environment variables and encrypted
user store, or you can build your own.

The new configuration allows a list of name-value pairs, which can be grouped
into a multi-level hierarchy. Any stored value maps to a string, and there is
built-in binding support that allows you to deserialize settings into a custom
POCO object.

The ConfigurationBuilder object lets you add as many configuration providers you
may need for your application, using a precedence rule to resolve preference.
So, the last provider you add in your code will override the others. This is a
great feature for managing different environments for execution since you can
define different configurations for development, testing and production
environments, and managed them on a single function inside your code.

### Migrating Configuration files

You can remain using the old app.config XML files for configuration or proceed a
migration to benefit from the wonderful enhancements waiting for you on .NET
Core.

To perform a migration from an old-style app.config to a new configuration file,
you should choose between an XML format and a JSON format. For XML, the
conversion is straight forward since the content is the same just a rename to a
file with XML extension. Then you need to migrate from AppSettings lines of code
to Configuration builder, but that should be easy.

In the case, you want to use a JSON format and you don't want to migrate by hand
there is a tool called **dotnet-config2json** available on .NET Core that will
output a JSON configuration file from an old App.Config XML file.

You may also encounter some issues when using configuration sections that were
defined in the machine.config. For example, consider this configuration:

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

If you take this configuration to a .NET Core, you will get an exception:

Unrecognized configuration section system.diagnostics

This is because that section and the assembly responsible for handling it was
defined in the machine.config, which now does not exist.

To easily fix the issue, you can copy the section definition from your old
machine.config to your new configuration file:

```xml
<configSections>
    <section name="system.diagnostics"
             type="System.Diagnostics.SystemDiagnosticsSection,
                   System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
</configSections>
```

## Accessing Databases

Almost every desktop application needs some kind of database. For desktop is
common to find client-server architectures with a direct connection between the
desktop app and the database engine. These databases can be local or remote
depending on the need to share information between different users.

From the code perspective, there have been many technologies and frameworks to
give the developer the possibility to connect, query, and update a database.

The most common examples of database you can find when talking about Windows
Desktop application are Microsoft Access and Microsoft SQL Server. If you have
more than 20 years of experience programming for the desktop the names, ODBC,
OLEDB, RDO, ADO and ADO.NET, LINQ and Entity Framework will sound familiar.

### ODBC

You can continue to use ODBC on .NET Core since Microsoft is providing the
`System.Data.Odbc` library compatible with .NET Standard 2.0.

### OLE DB

[OLE DB](https://msdn.microsoft.com/library/ms722784(v=vs.85).aspx) has
been a great way to access various data sources in a uniform manner, but it was
based on COM, which is a Windows-only technology, and as such was not the best
fit for a cross-platform technology such as .NET Core. It is also unsupported in
SQL Server versions 2014 and later. For those reasons, OLE DB will not be
supported by .NET Core.

### ADO.NET

You can still use ADO.NET from your existing desktop code on .NET Core. You will
just need to update some NuGet packages.

### EF Core vs EF 6

There are two versions of Entity Framework, Entity Framework 6 and Entity
Framework Core.

The latest technology released as part of the .NET Framework world is Entity
Framework, with 6.3 being the latest version. With the launch of .NET Core,
Microsoft also released a new data access stack based on Entity Framework and
called Entity Framework Core.

You can use EF 6.3 and EF Core from both .NET Framework and .NET Core, so what
are the decision drivers to help to decide between the two?

EF 6.3 will be the first version of EF 6 that can run on .NET Core and work
cross-platform. In fact, the main goal of this release is to facilitate
migrating existing applications that use EF 6 to .NET Core 3.0.

EF Core was designed to provide a developer experience similar to EF6. Most of
the top-level APIs remain the same, so EF Core will feel familiar to developers
who have used EF6.

Although compatible, there are differences on the implementation you should
check before making a decision.
(<https://docs.microsoft.com/ef/efcore-and-ef6/>)

The recommendation is to use EF Core if:

* The app needs the capabilities of .NET Core.
* EF Core supports all of the features that the app requires

Consider using EF6 if both of the following conditions are true:

* The app will run on Windows and the .NET Framework 4.0 or later.
* EF6 supports all of the features that the app requires.

### **Relational databases**

#### SQL Server

SQL Server has been one of the databases of choice if you were developing for
the desktop some years ago. With the use of `System.Data.SqlClient` in .NET
Framework, you could access versions of SQL Server, which encapsulates
database-specific protocols.

In .NET Core, you can find a new `SqlClient` fully compatible with the one
existing in the .NET Framework but located in the `Microsoft.Data.SqlClient`
library. You just have to add a dependency for this package and do some renaming
for the namespaces and everything should work as expected.

#### Microsoft Access

have been used for years when the
sophisticated and more scalable SQL Server was not needed. You can still connect
to Microsoft Access using the `System.Data.Odbc` library.

## Consuming services

With the raise of service-oriented architectures, desktop applications begin to
evolve from a client-server model to the three-layer approach. In the
client-server approach, a direct database connection is established from the
client holding the business logic usually inside a single EXE file. On the other
hand, the three-layer approach establishes an intermediate service layer
implementing business logic and database access allowing for better security,
scalability, and reusability. Instead of working directly with datasets of data,
the layer approach relies in a set of services implementing contracts and types
objects as a way to implement data transfer.

If you have a desktop application using a WCF service and you want to migrate it
to .NET Core, there are some things to consider.

The first thing is how to resolve the configuration to access the service.
Because the configuration is different on .NET Core and you will need to make
some updates in your configuration file.

Second, you will need to regenerate the service client with the new tools
present on Visual Studio 2019. In this step, you must consider activating the
generation of the synchronous operations to make the client compatible with your
existing code.

If you find that after migration, there are libraries you need that aren't
present on .NET Core you can add a reference to Microsoft.Windows.Compatibility
and see if the missing functions are there.

If you are using the WebRequest class to perform Web Service calls, you may
encounter some differences on .NET Core. The recommendation is to use the
System.Net.Http.HttpClient instead.

## Consuming a COM Object

Currently there is no way to add a reference to a COM object from Visual Studio
2019 for using with .NET Core so you have to follow some manual steps and modify
the .csproj file for the project.

You need to insert a COMReference structure inside the Project file like:

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

## **More things to consider**

Several technologies available to .NET Framework libraries aren't available for
use with .NET Core. If your code relies on some of these technologies, consider
the alternative approaches outlined below.

The Windows Compatibility Pack provides access to APIs that were previously
available only for .NET Framework. It can be used from both .NET Core as well as
.NET Standard.

For more information on API compatibility, the CoreFX team maintains a list of
behavioral changes/compat breaks and deprecated/legacy APIs at GitHub.
<https://github.com/dotnet/corefx/wiki/ApiCompat>)

### AppDomains

Application domains (AppDomains) isolate apps from one another. AppDomains
require runtime support and are expensive. Creating additional
app domains is not supported. For code isolation, we recommend separate
processes or using containers as an alternative. For the dynamic loading of
assemblies, we recommend the new AssemblyLoadContext class.

To make code migration from .NET Framework easier, .NET Core exposes some of
the AppDomain API surface. Some of the APIs function normally (for
example, AppDomain.UnhandledException), some members do nothing (for
example, SetCachePath), and some of them throw
PlatformNotSupportedException (for example, CreateDomain).

### Remoting

.NET Remoting was used for cross-AppDomain communication, which is no longer
supported. Also, Remoting requires runtime support, which is expensive to
maintain. For these reasons, .NET Remoting is not supported on .NET Core.

For communication across processes, you should consider inter-process
communication (IPC) mechanisms as an alternative to Remoting, such as
the System.IO.Pipes or the MemoryMappedFile class.

Across machines, use a network-based solution as an alternative. Preferably, use
a low-overhead plain text protocol, such as HTTP. The Kestrel web server, the
web server used by ASP.NET Core, is an option here.

### Code Access Security

Sandboxing, which relies on the runtime or the framework to constrain which
resources a managed application or library uses or runs is not supported on .NET
Core.

Use security boundaries provided by the operating system, such as
virtualization, containers, or user accounts for running processes with the
minimum set of privileges.

### Security Transparency

Similar to CAS (Code Access Security), Security Transparency separates sandboxed
code from security critical code in a declarative fashion but is no longer
supported as a security boundary.

Use security boundaries provided by the operating system, such as
virtualization, containers, or user accounts for running processes with the
least set of privileges.
