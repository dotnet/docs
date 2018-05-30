---
title: Microsoft WCF dotnet-svcutil Tool
description: An overview of the Microsoft WCF dotnet-svcutil Tool that adds functionality for .NET Core and ASP.NET Core projects, similar to the WCF svcutil tool for .NET Framework projects.
author: mlacouture
ms.author: 
ms.date: 
ms.custom: 
---
# Microsoft WCF dotnet-svcutil Tool

The Windows Communication Foundation (WCF) **dotnet-svcutil** tool is a .NET Core CLI tool that retrieves metadata from a web service on a network location or from a WSDL file, and generates a WCF class containing client proxy methods that you can use to access the web service operations.

Similarly to the [**Service Model Metadata - svcutil**](dotnet/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe) tool for .NET Framework projects, the **dotnet-svcutil** is a command line tool for generating a web service reference compatible with .NET Core and .NET Standard projects.

The **dotnet-svcutil** tool is an alternative option to the [**WCF Web Service Reference**](/dotnet/core/additional-tools/wcf-web-service-reference-guide) Visual Studio connected service provider which first shipped with Visual Studio 2017 v15.5. The **dotnet-svcutil** tool as a .NET Core CLI tool, however, can be run across platforms like Linux and MacOS in addition to Windows.

> [!IMPORTANT]
> You should only reference services from a trusted source. Adding references from an untrusted source may compromise security. 

## Prerequisites

* [.NET Core SDK](https://www.microsoft.com/net/download/windows) v1.0.4 or higher versions

## Getting Started

The following example walks you through the steps required to add a web service reference to a .NET Core console project and invoke the service.  You will create a .NET Core console application named _HelloSvcutil_ and will add a reference to a web service that implements the following contract:

```
[ServiceContract]
public interface ISayHello
{
    [OperationContract]
    string Hello(string name);
}
```
The web service address will be assumed to be the following: _http://myhost/SayHello.svc_

From a command window perform the following steps:

1. Create a folder for the new project and navigate to it
```
mkdir HelloSvcutil
cd HelloSvcutil
```

2. Create a .NET Core console application
```
dotnet new console
```

3. Edit the _HelloSvcutil.csproj_ project file and add the _dotnet-svcutil_ package as a CLI tool reference, it should look like the following:
```
<ItemGroup>
  <DotNetCliToolReference Include="dotnet-svcutil" Version="1.0.0-preview-20522-1161" />
</ItemGroup>
```

4. Restore the project in order to invoke the _dotnet-svcutil_ tool
```
dotnet restore
```

5. Run _dotnet_ with the _svcutil_ command to generate the web service reference file which by default will be _SayHello.cs_
```
dotnet svcutil http://myhost/SayHello.svc
```

6. Now restore the WCF packages for the project
```
dotnet restore
```

7. Add Code to invoke the web service. Edit the _Main_ method of the _program.cs_ file to look like the following:
```
static void Main(string[] args)
{
    var client = new SayHelloClient();
    Console.WriteLine(client.HelloAsync("dotnet-svcutil").Result);
}
```

8. Finally, run the project
```
dotnet run
"Hello dotnet-svcutil!"
```

For a detailed description of the tool parameters invoke the tool passing the help parameter as follows:
```
dotnet svcutil --help
```

## Next steps

### Feedback & questions
If you have any questions or feedback, [open an issue on GitHub](https://github.com/dotnet/wcf/issues/new). You can also review any existing questions or issues [at the WCF repo on GitHub](https://github.com/dotnet/wcf/issues?utf8=%E2%9C%93&q=is:issue%20label:tooling).

### Release notes
* Refer to the [Release notes](https://github.com/dotnet/wcf/blob/master/release-notes/dotnet-svcutil-notes.md) for updated release information, including known issues. 

### Information
* [NuGet Package](https://nuget.org/packages/dotnet-svcutil)
