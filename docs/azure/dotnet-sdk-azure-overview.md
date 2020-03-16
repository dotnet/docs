---
title: Azure .NET APIs
description: Overview of the Azure APIs for .NET
ms.date: 10/19/2017
---

# Azure .NET APIs

The Azure .NET APIs let you use Azure services and manage Azure resources from your application code. The APIs are available as [NuGet packages](/dotnet/api/overview/azure/) for use in your .NET projects. 

## Manage Azure resources

The Azure libraries for .NET let you create and manage Azure resources from your .NET applications.

Many of the packages for managing Azure resources have a [fluent](dotnet-sdk-azure-concepts.md) interface to configure resources exactly to your specifications. For example, to create a Windows VM you would write the following code:

```csharp
var windowsVM = azure.VirtualMachines.Define(windowsVmName)
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .WithNewPrimaryNetwork("10.0.0.0/28")
    .WithPrimaryPrivateIPAddressDynamic()
    .WithNewPrimaryPublicIPAddress(publicIpDnsLabel)
    .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
    .WithAdminUsername(username)
    .WithAdminPassword(password)
    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
    .Create();
 ```

Review the [.NET service list](/dotnet/api/overview/azure/) to start using the libraries immediately with your projects. Then read the [get started article](dotnet-sdk-azure-get-started.md) to set up authentication and run sample code against your own Azure subscription.  The [concepts article](dotnet-sdk-azure-concepts.md) goes into the conventions the SDK uses and how to leverage them to simplify your application code. New features, breaking changes, and migration instructions are available in the [release notes](dotnet-sdk-azure-release-notes.md).

## Consume Azure services

In addition to using .NET APIs to create and programmatically manage resources within Azure, you can also then use .NET APIs to connect your applications to these resources and use them at runtime.  For example, you might connect to a SQL Database or store data within Azure Storage.  You can identify which NuGet package to use for a particular Azure service by browsing our [full list of service APIs](/dotnet/api/overview/azure/).  

## Samples

The following samples cover common automation tasks with the Azure libraries for .NET:

- [Virtual machines](dotnet-sdk-azure-virtual-machine-samples.md)
- [Web apps](dotnet-sdk-azure-web-apps-samples.md)
- [SQL Database](dotnet-sdk-azure-sql-database-samples.md)

A unified [reference](/dotnet/api/overview/azure/?view=azure-dotnet) is available for all packages in both the service and management libraries. New features, breaking changes, and migration instructions are available in the [release notes](dotnet-sdk-azure-release-notes.md).

[!include[Contribute and community](includes/contribute.md)]