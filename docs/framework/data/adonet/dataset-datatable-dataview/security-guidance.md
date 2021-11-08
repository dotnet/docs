---
description: "Learn more about: DataSet and DataTable security guidance"
title: DataSet and DataTable security guidance
ms.date: 07/14/2020
dev_langs:
  - "csharp"
---
# DataSet and DataTable security guidance

This article applies to:

* .NET Framework (all versions)
* .NET Core and later
* .NET 5 and later

The [DataSet](/dotnet/api/system.data.dataset) and [DataTable](/dotnet/api/system.data.datatable) types are legacy .NET components that allow representing data sets as managed objects. These components were introduced in .NET Framework 1.0 as part of the original [ADO.NET infrastructure](./index.md). Their goal was to provide a managed view over a relational data set, abstracting away whether the underlying source of the data was XML, SQL, or another technology.

For more information on ADO.NET, including more modern data view paradigms, see [the ADO.NET documentation](../index.md).

## Default restrictions when deserializing a DataSet or DataTable from XML

On all supported versions of .NET Framework, .NET Core, and .NET, `DataSet` and `DataTable` place the following restrictions on what types of objects may be present in the deserialized data. By default, this list is restricted to:

* Primitives and primitive equivalents: `bool`, `char`, `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, `DateTime`, `DateTimeOffset`, `TimeSpan`, `string`, `Guid`, `SqlBinary`, `SqlBoolean`, `SqlByte`, `SqlBytes`, `SqlChars`, `SqlDateTime`, `SqlDecimal`, `SqlDouble`, `SqlGuid`, `SqlInt16`, `SqlInt32`, `SqlInt64`, `SqlMoney`, `SqlSingle`, and `SqlString`.
* Commonly used non-primitives: `Type`, `Uri`, and `BigInteger`.
* Commonly used _System.Drawing_ types: `Color`, `Point`, `PointF`, `Rectangle`, `RectangleF`, `Size`, and `SizeF`.
* `Enum` types.
* Arrays and lists of the above types.

If the incoming XML data contains an object whose type is not in this list:

* An exception is thrown with the following message and stack trace.
Error Message:
System.InvalidOperationException : Type '\<Type Name\>, Version=\<n.n.n.n\>, Culture=\<culture\>, PublicKeyToken=\<token value\>' is not allowed here.
Stack Trace:
at System.Data.TypeLimiter.EnsureTypeIsAllowed(Type type, TypeLimiter capturedLimiter)
at System.Data.DataColumn.UpdateColumnType(Type type, StorageType typeCode)
at System.Data.DataColumn.set_DataType(Type value)

* The deserialization operation fails.

When loading XML into an existing `DataSet` or `DataTable` instance, the existing column definitions are also taken into account. If the table already contains a column definition of a custom type, that type is temporarily added to the allow list for the duration of the XML deserialization operation.

> [!NOTE]
> Once you add columns to a `DataTable`, `ReadXml` will not read the schema from the XML, and if the schema does not match it will also not read in the records, so you will need to add all the columns yourself to use this method.

```csharp
XmlReader xmlReader = GetXmlReader();

// Assume the XML blob contains data for type MyCustomClass.
// The following call to ReadXml fails because MyCustomClass isn't in the allowed types list.

DataTable table = new DataTable("MyDataTable");
table.ReadXml(xmlReader);

// However, the following call to ReadXml succeeds, since the DataTable instance
// already defines a column of type MyCustomClass.

DataTable table = new DataTable("MyDataTable");
table.Columns.Add("MyColumn", typeof(MyCustomClass));
table.ReadXml(xmlReader); // this call will succeed
```

The object type restrictions also apply when using `XmlSerializer` to deserialize an instance of `DataSet` or `DataTable`. However, they may not apply when using `BinaryFormatter` to deserialize an instance of `DataSet` or `DataTable`.

The object type restrictions don't apply when using `DataAdapter.Fill`, such as when a `DataTable` instance is populated directly from a database without using the XML deserialization APIs.

### Extend the list of allowed types

An app can extend the allowed types list to include custom types in addition to the built-in types listed above. If extending the allowed types list, the change affects _all_ `DataSet` and `DataTable` instances within the app. Types cannot be removed from the built-in allowed types list.

#### Extend through configuration (.NET Framework 4.0 - 4.8)

_App.config_ can be used to extend the allowed types list. To extend the allowed types list:

* Use the `<configSections>` element to add a reference to the _System.Data_ configuration section.
* Use `<system.data.dataset.serialization>`/`<allowedTypes>` to specify additional types.

Each `<add>` element must specify only one type by using its assembly qualified type name. To add additional types to the allowed types list, use multiple `<add>` elements.

The following sample shows extending the allowed types list by adding the custom type `Fabrikam.CustomType`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <sectionGroup name="system.data.dataset.serialization" type="System.Data.SerializationSettingsSectionGroup, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
      <section name="allowedTypes" type="System.Data.AllowedTypesSectionHandler, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
    </sectionGroup>
  </configSections>
  <system.data.dataset.serialization>
    <allowedTypes>
      <!-- <add type="assembly qualified type name" /> -->
      <add type="Fabrikam.CustomType, Fabrikam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2b3831f2f2b744f7" />
      <!-- additional <add /> elements as needed -->
    </allowedTypes>
  </system.data.dataset.serialization>
</configuration>
```

To retrieve the assembly qualified name of a type, use the [Type.AssemblyQualifiedName](/dotnet/api/system.type.assemblyqualifiedname) property, as demonstrated in the following code.

```csharp
string assemblyQualifiedName = typeof(Fabrikam.CustomType).AssemblyQualifiedName;
```

<a name="etc"></a>

#### Extend through configuration (.NET Framework 2.0 - 3.5)

If your app targets .NET Framework 2.0 or 3.5, you can still use the above _App.config_ mechanism to extend the allowed types list. However, your `<configSections>` element will look slightly different, as shown in the following code:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <!-- The below <sectionGroup> and <section> are specific to .NET Framework 2.0 and 3.5. -->
    <sectionGroup name="system.data.dataset.serialization" type="System.Data.SerializationSettingsSectionGroup, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
      <section name="allowedTypes" type="System.Data.AllowedTypesSectionHandler, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
    </sectionGroup>
  </configSections>
  <system.data.dataset.serialization>
    <allowedTypes>
      <!-- <add /> elements, as demonstrated in the .NET Framework 4.0 - 4.8 sample code above. -->
    </allowedTypes>
  </system.data.dataset.serialization>
</configuration>
```

#### Extend programmatically (.NET Framework, .NET Core, .NET 5+)

The list of allowed types can also be extended programmatically by using [AppDomain.SetData](/dotnet/api/system.appdomain.setdata) with the well-known key _System.Data.DataSetDefaultAllowedTypes_, as shown in the following code.

```csharp
Type[] extraAllowedTypes = new Type[]
{
    typeof(Fabrikam.CustomType),
    typeof(Contoso.AdditionalCustomType)
};

AppDomain.CurrentDomain.SetData("System.Data.DataSetDefaultAllowedTypes", extraAllowedTypes);
```

If using the extension mechanism, the value associated with the key _System.Data.DataSetDefaultAllowedTypes_ must be of type `Type[]`.

On .NET Framework, the list of allowed types may be extended both with _App.config_ and `AppDomain.SetData`. In this case, `DataSet` and `DataTable` will allow an object to be deserialized as part of the data if its type is present in either list.

### Run an app in audit mode (.NET Framework)

In .NET Framework, `DataSet` and `DataTable` provide an audit mode capability. When audit mode is enabled, `DataSet` and `DataTable` compare the types of incoming objects against the allowed types list. However, if an object whose type is not allowed is seen, an exception is **not** thrown. Instead, `DataSet` and `DataTable` notify any attached `TraceListener` instances that a suspicious type is present, allowing the `TraceListener` to log this information. No exception is thrown and the deserialization operation continues.

> [!WARNING]
> Running an app in "audit mode" should only be a temporary measure used for testing. When audit mode is enabled, `DataSet` and `DataTable` do not enforce type restrictions, which can introduce a security hole inside your app. For more information, see the sections titled [Removing all type restrictions](#ratr) and [Safety with regard to untrusted input](#swr).

Audit mode can be enabled through _App.config_:

* See the [Extending through configuration](#etc) section in this document for information on the proper value to put for the `<configSections>` element.
* Use `<allowedTypes auditOnly="true">` to enable audit mode, as shown in the following markup.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <!-- See the section of this document titled "Extending through configuration" for the appropriate
         <sectionGroup> and <section> elements to put here, depending on whether you're running .NET
         Framework 2.0 - 3.5 or 4.0 - 4.8. -->
  </configSections>
  <system.data.dataset.serialization>
    <allowedTypes auditOnly="true"> <!-- setting auditOnly="true" enables audit mode -->
      <!-- Optional <add /> elements as needed. -->
    </allowedTypes>
  </system.data.dataset.serialization>
</configuration>
```

Once audit mode is enabled, you can use _App.config_ to connect your preferred `TraceListener` to the `DataSet` built-in `TraceSource.` The name of the built-in trace source is _System.Data.DataSet_. The following sample demonstrates writing trace events to the console _and_ to a log file on disk.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <system.diagnostics>
    <sources>
      <source name="System.Data.DataSet"
              switchType="System.Diagnostics.SourceSwitch"
              switchValue="Warning">
        <listeners>
          <!-- write to the console -->
          <add name="console"
               type="System.Diagnostics.ConsoleTraceListener" />
          <!-- *and* write to a log file on disk -->
          <add name="filelog"
               type="System.Diagnostics.TextWriterTraceListener"
               initializeData="c:\logs\mylog.txt" />
        </listeners>
      </source>
    </sources>
  </system.diagnostics>
</configuration>
```

For more information on `TraceSource` and `TraceListener`, see the document [How to: Use TraceSource and Filters with Trace Listeners](../../../debug-trace-profile/how-to-use-tracesource-and-filters-with-trace-listeners.md).

> [!NOTE]
> Running an app in audit mode is not available in .NET Core or in .NET 5 and later.

<a name="ratr"></a>

### Remove all type restrictions

If an app must remove all type limiting restrictions from `DataSet` and `DataTable`:

* There are several options to suppress type limiting restrictions.
* The options available depend on the framework the app targets.

> [!WARNING]
> Removing all type restrictions can introduce a security hole inside the app. When using this mechanism, ensure the app does **not** use `DataSet` or `DataTable` to read untrusted input. For more information, see [CVE-2020-1147](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2020-1147) and the following section titled [Safety with regard to untrusted input](#swr).

#### Through AppContext configuration (.NET Framework 4.6 - 4.8, .NET Core 2.1 and later, .NET 5 and later)

The `AppContext` switch, `Switch.System.Data.AllowArbitraryDataSetTypeInstantiation`, when set to `true` removes all type limiting restrictions from `DataSet` and `DataTable`.

In .NET Framework, this switch can be enabled via _App.config_, as shown in the following configuration:

```xml
<configuration>
   <runtime>
      <!-- Warning: setting the following switch can introduce a security problem. -->
      <AppContextSwitchOverrides value="Switch.System.Data.AllowArbitraryDataSetTypeInstantiation=true" />
   </runtime>
</configuration>
```

In ASP.NET, the `<AppContextSwitchOverrides>` element is not available. Instead, the switch can be enabled via _Web.config_, as shown in the following configuration:

```xml
<configuration>
    <appSettings>
        <!-- Warning: setting the following switch can introduce a security problem. -->
        <add key="AppContext.SetSwitch:Switch.System.Data.AllowArbitraryDataSetTypeInstantiation" value="true" />
    </appSettings>
</configuration>
```

For more information, see the [\<AppContextSwitchOverrides>](../../../configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element.

In .NET Core, .NET 5, and ASP.NET Core, this setting is controlled by _runtimeconfig.json_, as shown in the following JSON:

```json
{
  "runtimeOptions": {
    "configProperties": {
      "Switch.System.Data.AllowArbitraryDataSetTypeInstantiation": true
    }
  }
}
```

For more information, see [".NET Core runtime configuration settings"](../../../../core/run-time-config/index.md).

`AllowArbitraryDataSetTypeInstantiation` can also be set programmatically via [AppContext.SetSwitch](/dotnet/api/system.appcontext.setswitch) instead of using a configuration file, as shown in the following code:

```csharp
// Warning: setting the following switch can introduce a security problem.
AppContext.SetSwitch("Switch.System.Data.AllowArbitraryDataSetTypeInstantiation", true);
```

 If you choose the preceding programmatic approach, the call to `AppContext.SetSwitch` should occur early in the apps startup.

#### Through the machine-wide registry (.NET Framework 2.0 - 4.8)

If `AppContext` is not available, type limiting checks can be disabled with the Windows registry:

* An administrator must configure the registry.
* Using the registry is a machine-wide change and will affect _all_ apps running on the machine.

| Type  |  Value |
|---|---|
| **Registry key** | `HKLM\SOFTWARE\Microsoft\.NETFramework\AppContext` |
| **Value name** | `Switch.System.Data.AllowArbitraryDataSetTypeInstantiation` |
| **Value type** | `REG_SZ` |
| **Value data** | `true` |

On a 64-bit operating system, this value my need to be added for both the 64-bit key (shown above) and the 32-bit key. The 32-bit key is located at `HKLM\SOFTWARE\WOW6432Node\Microsoft\.NETFramework\AppContext`.

For more information on using the registry to configure `AppContext`, see ["AppContext for library consumers"](/dotnet/api/system.appcontext#appcontext-for-library-consumers).

<a name="swr"></a>

## Safety with regard to untrusted input

While `DataSet` and `DataTable` do impose default limitations on the types that are allowed to be present while deserializing XML payloads, __`DataSet` and `DataTable` are in general not safe when populated with untrusted input.__ The following is a non-exhaustive list of ways that a `DataSet` or `DataTable` instance might read untrusted input.

* A `DataAdapter` references a database, and the `DataAdapter.Fill` method is used to populate a `DataSet` with the contents of a database query.
* The `DataSet.ReadXml` or `DataTable.ReadXml` method is used to read an XML file containing column and row information.
* A `DataSet` or `DataTable` instance is serialized as part of a ASP.NET (SOAP) web services or WCF endpoint.
* A serializer such as `XmlSerializer` is used to deserialize a `DataSet` or `DataTable` instance from an XML stream.
* A serializer such as `JsonConvert` is used to deserialize a `DataSet` or `DataTable` instance from a JSON stream. `JsonConvert` is a method in the popular third-party [Newtonsoft.Json](https://www.newtonsoft.com/json) library.
* A serializer such as `BinaryFormatter` is used to deserialize a `DataSet` or `DataTable` instance from a raw byte stream.

This document discusses safety considerations for the preceding scenarios.

## Use `DataAdapter.Fill` to populate a `DataSet` from an untrusted data source

A `DataSet` instance can be populated from a `DataAdapter` by using [the `DataAdapter.Fill` method](/dotnet/api/system.data.common.dataadapter.fill), as shown in the following example.

```csharp
// Assumes that connection is a valid SqlConnection object.
string queryString =
  "SELECT CustomerID, CompanyName FROM dbo.Customers";
SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

DataSet customers = new DataSet();
adapter.Fill(customers, "Customers");
```

(The code sample above is part of a larger sample found at [Populating a DataSet from a DataAdapter](../populating-a-dataset-from-a-dataadapter.md).)

> Most apps can simplify and assume that their database layer is trusted. However, if you are in the habit of [threat modeling](https://www.microsoft.com/securityengineering/sdl/threatmodeling) your apps, your threat model may consider there to be a trust boundary between the application (client) and database layer (server). Using [mutual authentication](/sql/relational-databases/native-client/features/service-principal-name-spn-support-in-client-connections) or [AAD authentication](/azure/azure-sql/database/authentication-aad-overview) between client and server is one way to help address the risks associated with this. The remainder of this section discusses the possible result of a client connecting to an untrusted server.

The consequences of pointing a `DataAdapter` at an untrusted data source depend on the implementation of the `DataAdapter` itself.

### SqlDataAdapter

For the built-in type [SqlDataAdapter](/dotnet/api/microsoft.data.sqlclient.sqldataadapter), referencing an untrusted data source could result in a denial of service (DoS) attack. The DoS attack could result in the app becoming unresponsive or crashing. If an attacker can plant a DLL alongside the app, they may also be able to achieve local code execution.

### Other DataAdapter types

Third-party `DataAdapter` implementations must make their own assessments about what security guarantees they provide in the face of untrusted inputs. .NET cannot make any safety guarantees regarding these implementations.

<a name="dsrdtr"></a>

## DataSet.ReadXml and DataTable.ReadXml

The `DataSet.ReadXml` and `DataTable.ReadXml` methods are not safe when used with untrusted input. We strongly recommend that consumers instead consider using one of the alternatives outlined later in this document.

The implementations of `DataSet.ReadXml` and `DataTable.ReadXml` were originally created before serialization vulnerabilities were a well-understood threat category. As a result, the code does not follow current security best practices. These APIs can be used as vectors for attackers to perform DoS attacks against web apps. These attacks might render the web service unresponsive or result in unexpected process termination. The framework does not provide mitigations for these attack categories and .NET considers this behavior "by design".

.NET has released security updates to mitigate some issues such as information disclosure or remote code execution in `DataSet.ReadXml` and `DataTable.ReadXml`. The .NET security updates may not provide complete protection against these threat categories. Consumers should assess their individual scenarios and consider their potential exposure to these risks.

Consumers should be aware that security updates to these APIs may impact application compatibility in some situations. Furthermore, the possibility exists that a novel vulnerability in these APIs will be discovered for which .NET can't practically publish a security update.

We recommend that consumers of these APIs either:

* Consider using one of the alternatives outlined later in this document.
* Perform individual risk assessments on their apps.

It is the consumer's sole responsibility to determine whether to utilize these APIs. Consumers should assess any security, technical, and legal risks, including regulatory requirements, that may accompany using these APIs.

## DataSet and DataTable via ASP.NET web services or WCF

It is possible to accept a `DataSet` or a `DataTable` instance in an ASP.NET (SOAP) web service, as demonstrated in the following code:

```csharp
using System.Data;
using System.Web.Services;

[WebService(Namespace = "http://contoso.com/")]
public class MyService : WebService
{
    [WebMethod]
    public string MyWebMethod(DataTable dataTable)
    {
        /* Web method implementation. */
    }
}
```

A variation on this is not to accept `DataSet` or `DataTable` directly as a parameter, but instead to accept it as part of the overall SOAP serialized object graph, as shown in the following code:

```csharp
using System.Data;
using System.Web.Services;

[WebService(Namespace = "http://contoso.com/")]
public class MyService : WebService
{
    [WebMethod]
    public string MyWebMethod(MyClass data)
    {
        /* Web method implementation. */
    }
}

public class MyClass
{
    // Property of type DataTable, automatically serialized and
    // deserialized as part of the overall MyClass payload.
    public DataTable MyDataTable { get; set; }
}
```

Or, using WCF instead of ASP.NET web services:

```csharp
using System.Data;
using System.ServiceModel;

[ServiceContract(Namespace = "http://contoso.com/")]
public interface IMyContract
{
    [OperationContract]
    string MyMethod(DataTable dataTable);
    [OperationContract]
    string MyOtherMethod(MyClass data);
}

public class MyClass
{
    // Property of type DataTable, automatically serialized and
    // deserialized as part of the overall MyClass payload.
    public DataTable MyDataTable { get; set; }
}
```

In all of these cases, the threat model and security guarantees are the same as the [DataSet.ReadXml and DataTable.ReadXml section](#dsrdtr).

## Deserialize a DataSet or DataTable via XmlSerializer

Developers can use `XmlSerializer` to deserialize `DataSet` and `DataTable` instances, as shown in the following code:

```csharp
using System.Data;
using System.IO;
using System.Xml.Serialization;

public DataSet PerformDeserialization1(Stream stream) {
    XmlSerializer serializer = new XmlSerializer(typeof(DataSet));
    return (DataSet)serializer.Deserialize(stream);
}

public MyClass PerformDeserialization2(Stream stream) {
    XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
    return (MyClass)serializer.Deserialize(stream);
}

public class MyClass
{
    // Property of type DataTable, automatically serialized and
    // deserialized as part of the overall MyClass payload.
    public DataTable MyDataTable { get; set; }
}
```

In these cases, the threat model and security guarantees are the same as the [DataSet.ReadXml and DataTable.ReadXml section](#dsrdtr)

## Deserialize a DataSet or DataTable via JsonConvert

The popular third-party Newtonsoft library [Json.NET](https://www.newtonsoft.com/json) can be used to deserialize `DataSet` and `DataTable` instances, as shown in the following code:

```csharp
using System.Data;
using Newtonsoft.Json;

public DataSet PerformDeserialization1(string json) {
    return JsonConvert.DeserializeObject<DataSet>(data);
}

public MyClass PerformDeserialization2(string json) {
    return JsonConvert.DeserializeObject<MyClass>(data);
}

public class MyClass
{
    // Property of type DataTable, automatically serialized and
    // deserialized as part of the overall MyClass payload.
    public DataTable MyDataTable { get; set; }
}
```

Deserializing a `DataSet` or `DataTable` in this manner from an untrusted JSON blob is not safe. This pattern is vulnerable to a denial of service attack. Such an attack could crash the app or render it unresponsive.

> [!NOTE]
> Microsoft does not warrant or support the implementation of third-party libraries like _Newtonsoft.Json_. This information is provided for completeness and is accurate as of the time of this writing.

## Deserialize a DataSet or DataTable via BinaryFormatter

Developers must never use `BinaryFormatter`, `NetDataContractSerializer`, `SoapFormatter`, or related ***unsafe*** formatters to deserialize a `DataSet` or `DataTable` instance from an untrusted payload:

* This is susceptible to a full remote code execution attack.
* Using a custom `SerializationBinder` is not sufficient to prevent such an attack.

## Safe replacements

For apps that either:

* Accept `DataSet` or `DataTable` through an .asmx SOAP endpoint or a WCF endpoint.
* Deserialize untrusted data into an instance of `DataSet` or `DataTable`.

Consider replacing the object model to use [Entity Framework](/ef). Entity Framework:

* Is a rich, modern, object-oriented framework that can represent relational data.
* Brings [a diverse ecosystem](/ef/core/providers/) of database providers to make it easy to project database queries via your Entity Framework object models.
* Offers built-in protections when deserializing data from untrusted sources.

For apps that use `.aspx` SOAP endpoints, consider changing those endpoints to use [WCF](../../../wcf/index.md). WCF is a more fully featured replacement for `.asmx` web services. WCF endpoints [can be exposed via SOAP](../../../wcf/feature-details/how-to-expose-a-contract-to-soap-and-web-clients.md) for compatibility with existing callers.

## Code analyzers

Code analyzer security rules, which run when your source code is compiled, can help to find vulnerabilities related to this security issue in C# and Visual Basic code. Microsoft.CodeAnalysis.FxCopAnalyzers is a NuGet package of code analyzers that's distributed on [nuget.org](https://www.nuget.org/).

For an overview of code analyzers, see [Overview of source code analyzers](/visualstudio/code-quality/roslyn-analyzers-overview).

Enable the following Microsoft.CodeAnalysis.FxCopAnalyzers rules:

- [CA2350](/visualstudio/code-quality/ca2350): Do not use DataTable.ReadXml() with untrusted data
- [CA2351](/visualstudio/code-quality/ca2351): Do not use DataSet.ReadXml() with untrusted data
- [CA2352](/visualstudio/code-quality/ca2352): Unsafe DataSet or DataTable in serializable type can be vulnerable to remote code execution attacks
- [CA2353](/visualstudio/code-quality/ca2353): Unsafe DataSet or DataTable in serializable type
- [CA2354](/visualstudio/code-quality/ca2354): Unsafe DataSet or DataTable in deserialized object graph can be vulnerable to remote code execution attacks
- [CA2355](/visualstudio/code-quality/ca2355): Unsafe DataSet or DataTable type found in deserializable object graph
- [CA2356](/visualstudio/code-quality/ca2356): Unsafe DataSet or DataTable type in web deserializable object graph
- [CA2361](/visualstudio/code-quality/ca2361): Ensure autogenerated class containing DataSet.ReadXml() is not used with untrusted data
- [CA2362](/visualstudio/code-quality/ca2362): Unsafe DataSet or DataTable in autogenerated serializable type can be vulnerable to remote code execution attacks

For more information about configuring rules, see [Use code analyzers](/visualstudio/code-quality/use-roslyn-analyzers).

The new security rules are available in the following NuGet packages:

- Microsoft.CodeAnalysis.FxCopAnalyzers 3.3.0: for Visual Studio 2019 version 16.3 or later
- Microsoft.CodeAnalysis.FxCopAnalyzers 2.9.11: for Visual Studio 2017 version 15.9 or later
