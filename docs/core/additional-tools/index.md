---
title: Additional tools
description: An overview of the additional tools you can install that support and extend .NET functionality.
author: mlacouture
ms.date: 02/13/2020
ms.custom: "mvc"
---
# .NET additional tools overview

This section compiles a list of tools that support and extend the .NET functionality, in addition to the .NET CLI.

## .NET Uninstall Tool

The [.NET Uninstall Tool](https://github.com/dotnet/cli-lab/releases) (`dotnet-core-uninstall`) lets you clean up .NET SDKs and Runtimes on a system such that only the specified versions remain. A collection of options is available to specify which versions are uninstalled.

## .NET diagnostic tools

[dotnet-counters](../diagnostics/dotnet-counters.md) is a performance monitoring tool for first-level health monitoring and performance investigation.

[dotnet-dump](../diagnostics/dotnet-dump.md) provides a way to collect and analyze Windows and Linux core dumps without a native debugger.

[dotnet-gcdump](../diagnostics/dotnet-gcdump.md) provides a way to collect GC (Garbage Collector) dumps of live .NET processes.

[dotnet-trace](../diagnostics/dotnet-trace.md) collects profiling data from your app that can help in scenarios where you need to find out what causes an app to run slow.

## .NET Install tool for extension authors

The [.NET Install tool for extension authors](https://github.com/dotnet/vscode-dotnet-runtime) is a Visual Studio Code extension that allows acquisition of the .NET runtime specifically for VS Code extension authors. This tool is intended to be leveraged in extensions that are written in .NET and require .NET to boot pieces of the extension (for example, a language server). The extension is not intended to be used directly by users to install .NET for development.

## WCF Web Service Reference tool

The WCF (Windows Communication Foundation) [Web Service Reference tool](wcf-web-service-reference-guide.md) is a Visual Studio connected service provider that made its debut in [Visual Studio 2017 version 15.5](/visualstudio/releasenotes/vs2017-relnotes-v15.5#WCFTools). This tool retrieves metadata from a web service in the current solution, on a network location, or from a WSDL file. It generates a source file compatible with .NET, defining a WCF proxy class with methods that you can use to access the web service operations.

## WCF dotnet-svcutil tool

The WCF [dotnet-svcutil tool](dotnet-svcutil-guide.md) is a .NET tool that retrieves metadata from a web service on a network location or from a WSDL file. It generates a source file compatible with .NET, defining a WCF proxy class with methods that you can use to access the web service operations.

The **dotnet-svcutil** tool is an alternative to the [**WCF Web Service Reference**](wcf-web-service-reference-guide.md) Visual Studio connected service provider, which first shipped with Visual Studio 2017 version 15.5. The **dotnet-svcutil** tool, as a .NET tool, is available on Linux, macOS, and Windows.

## WCF dotnet-svcutil.xmlserializer tool

On the .NET Framework, you can pre-generate a serialization assembly using the svcutil tool. The WCF [dotnet-svcutil.xmlserializer tool](dotnet-svcutil.xmlserializer-guide.md) provides similar functionality on .NET 5 (and .NET Core) and later versions. It pre-generates C# serialization code for the types in the client application that are used by the WCF Service Contract and that can be serialized by the <xref:System.Xml.Serialization.XmlSerializer>. This improves the startup performance of XML serialization when serializing or deserializing objects of those types.

## XML Serializer Generator

Like the [Xml Serializer Generator (sgen.exe)](../../standard/serialization/xml-serializer-generator-tool-sgen-exe.md) for the .NET Framework, the [Microsoft.XmlSerializer.Generator NuGet package](https://www.nuget.org/packages/Microsoft.XmlSerializer.Generator) is the solution for libraries that target .NET 5 (and .NET Core) and later versions. It creates an XML serialization assembly for types contained in an assembly to improve the startup performance of XML serialization when serializing or de-serializing objects of those types using <xref:System.Xml.Serialization.XmlSerializer>.

## Generating Self-Signed Certificates

You can use [dotnet dev-certs](self-signed-certificates-guide.md) to create self-signed certificates for development and testing scenarios.

## .NET code coverage tool

You can use [dotnet-coverage](dotnet-coverage.md) to collect [code coverage](../testing/unit-testing-code-coverage.md) from any .NET process.
