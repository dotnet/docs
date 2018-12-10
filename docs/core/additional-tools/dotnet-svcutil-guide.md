---
title: WCF svcutil tool overview
description: An overview of the Microsoft WCF dotnet-svcutil tool that adds functionality for .NET Core and ASP.NET Core projects, similar to the WCF svcutil tool for .NET Framework projects.
author: mlacouture
ms.author: jralexander
ms.date: 08/20/2018
ms.custom: "seodec18"
---
# WCF dotnet-svcutil tool for .NET Core

The Windows Communication Foundation (WCF) **dotnet-svcutil** tool is a .NET Core CLI tool that retrieves metadata from a web service on a network location or from a WSDL file, and generates a WCF class containing client proxy methods that access the web service operations.

Similar to the [**Service Model Metadata - svcutil**](../../framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool for .NET Framework projects, the **dotnet-svcutil** is a command-line tool for generating a web service reference compatible with .NET Core and .NET Standard projects.

The **dotnet-svcutil** tool is an alternative option to the [**WCF Web Service Reference**](wcf-web-service-reference-guide.md) Visual Studio connected service provider that first shipped with Visual Studio 2017 v15.5. The **dotnet-svcutil** tool as a .NET Core CLI tool, is available cross-platform on Linux, macOS, and Windows.

> [!IMPORTANT]
> You should only reference services from a trusted source. Adding references from an untrusted source may compromise security.

## Prerequisites

* [.NET Core SDK](https://dotnet.microsoft.com/download) v1.0.4 or later versions
* Your favorite code editor

## Getting started

The following example walks you through the steps required to add a web service reference to a .NET Core console project and invoke the service. You will create a .NET Core console application named _HelloSvcutil_ and will add a reference to a web service that implements the following contract:

```csharp
[ServiceContract]
public interface ISayHello
{
    [OperationContract]
    string Hello(string name);
}
```

For this example, the web service will be assumed to be hosted at the following address: `http://contoso.com/SayHello.svc`

From a Windows, macOS, or Linux command window perform the following steps:

1. Create a directory named _HelloSvcutil_ for your project and make it your current directory, as in the following example:

```console
mkdir HelloSvcutil
cd HelloSvcutil
```

2. Create a new C# console project in that directory using the [`dotnet new`](../tools/dotnet-new.md) command as follows:

```console
dotnet new console
```

3. Open the `HelloSvcutil.csproj` project file in your editor, edit the `Project` element, and add the [`dotnet-svcutil` NuGet package](https://nuget.org/packages/dotnet-svcutil) as a CLI tool reference, using the following code:

```xml
<ItemGroup>
  <DotNetCliToolReference Include="dotnet-svcutil" Version="1.0.*" />
</ItemGroup>
```

4. Restore the _dotnet-svcutil_ package using the [`dotnet restore`](../tools/dotnet-restore.md) command as follows:

```console
dotnet restore
```

5. Run _dotnet_ with the _svcutil_ command to generate the web service reference file as follows:

```console
dotnet svcutil http://contoso.com/SayHello.svc
```
The generated file is saved as _HelloSvcutil/ServiceReference1/Reference.cs_. The _dotnet_svcutil_ tool also adds to the project the appropriate WCF packages required by the proxy code as package references.

6. Restore the WCF packages using the [`dotnet restore`](../tools/dotnet-restore.md) command as follows:

```console
dotnet restore
```

7. Open the `Program.cs` file in your editor, edit the `Main()` method, and replace the auto-generated code with the following code to invoke the web service:

```csharp
static void Main(string[] args)
{
    var client = new SayHelloClient();
    Console.WriteLine(client.HelloAsync("dotnet-svcutil").Result);
}
```

8. Run the application using the [`dotnet run`](../tools/dotnet-run.md) command as follows:

```console
dotnet run
```
You should see the following output:
"Hello dotnet-svcutil!"

For a detailed description of the `dotnet-svcutil` tool parameters, invoke the tool passing the help parameter as follows:

```console
dotnet svcutil --help
```

## Next steps

### Feedback & questions

If you have any questions or feedback, [open an issue on GitHub](https://github.com/dotnet/wcf/issues/new). You can also review any existing questions or issues [at the WCF repo on GitHub](https://github.com/dotnet/wcf/issues?utf8=%E2%9C%93&q=is:issue%20label:tooling).

### Release notes

* Refer to the [Release notes](https://github.com/dotnet/wcf/blob/master/release-notes/dotnet-svcutil-notes.md) for updated release information, including known issues.

### Information

* [dotnet-svcutil NuGet Package](https://nuget.org/packages/dotnet-svcutil)
