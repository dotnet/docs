---
title: Azure management libraries for .NET usage concepts and patterns
description: 
ms.date: 10/19/2017
---

# Azure management library for .NET fluent concepts

This article will help you understand how to effectively use the fluent interface in the Azure management libraries for .NET.

## Building resources using a fluent interface

A fluent interface is a specific form of the builder pattern that creates objects through a method chain that enforces correct configuration of a resource. For example, the entry-point Azure object is created using a fluent interface:

```csharp
var azure = Azure
    .Configure()
    .Authenticate(credentials)
    .WithDefaultSubscription();
```

## Resource collections

The `Microsoft.Azure.Management.Fluent.Azure` object shown above is the entry point for all resource creation in the fluent management libraries. Select which type of resources to work with using the resource collections in the `Azure` object. For example, for SQL Database:

```csharp
var sql = azure.SqlServers.Define(sqlServerName)
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .WithAdministratorLogin(administratorLogin)
    .WithAdministratorPassword(administratorPassword)
    .Create();
```

As seen above, most fluent "conversations" you have with the API start with selecting the appropriate resource collection for the Azure resources you need to work with.  Intellisense in Visual Studio then guides you through the conversation. 

![GIF of Intellisense in Visual Studio driving a fluent conversation](media/dotnet-sdk-azure-concepts/vs-fluent.gif)   

## Lists and iterations

Every resource collection has a `List()` method to return every instance of that resource in your current subscription. For example, `Azure.SqlServers.List()` returns all SQL servers in the subscription.

Use the `ListByResourceGroup()` method to scope the returned List to a specific [Azure resource group](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-overview#resource-groups).  

Iterate over the returned collection just as you would a normal `List<T>`:

```csharp
var vmList = azure.VirtualMachines.List();
foreach(var vm in vmList)
{
    Console.WriteLine("VM Name: {0}", vm.Name);
}
```   

## Actionable verbs

Resource collection methods with verbs in their names take immediate action in Azure. These methods work synchronously and block execution in the current thread until they complete. 

| Verb   |  Sample usage |
|--------|---------------|
| Create | `azure.VirtualMachines.Create(listOfVMCreatables)` |
| Apply  | `virtualMachineScaleSet.Update().WithCapacity(6).Apply()` |
| Delete | `azure.Disks.DeleteById(id)` | 
| List   | `azure.SqlServers.List()` | 
| Get    | `var vm  = azure.VirtualMachines.GetByResourceGroup(group, vmName)` |

>[!NOTE]
> `Define()` and `Update()` are verbs but do not block unless followed by a `Create()` or `Apply()`.
 
Specific resource objects have verbs that change the state of the resource in Azure. For example:

```csharp
var vmToRestart = azure.VirtualMachines.GetById(id);
vmToRestart.Restart();
```

Most of the methods described in this section have an asynchronous version as well, denoted by the suffix `Async`.

```csharp
Task restartTask = azure.VirtualMachines.GetById(id).RestartAsync();
```

## Lazy resource creation

A challenge when creating Azure resources arises when a new resource depends on another resource that doesn't yet exist. An example is reserving a public IP address and setting up a disk when creating a new virtual machine. You don't want to verify reserving the address or the creating the disk, you just want to configure the virtual machine with those resources.

Use creatable objects to define Azure resources for use in your code but only create them when needed in Azure. Code written with creatable objects offloads resource creation in the Azure environment to the management API, boosting performance. 

Generate creatable objects through the resource collections' `Define()` verb without a `Create()` verb:

```csharp
// Init a creatable Public IP Address
var publicIpAddressCreatable = azure.PublicIPAddresses.Define("publicIPAddressName")
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName);
```

The Azure resource defined by the creatable object does not yet exist in your subscription. A creatable object is a local representation of a resource that the management API will create when it's needed (when `.Create()` is called). Use this creatable object in the definition of other Azure resources that need this resource. 

```csharp
// Init a creatable VM using the creatable Public IP Address
var vmCreatable = azure.VirtualMachines.Define("creatableVM")
    // ...
    .withNewPrimaryPublicIPAddress(publicIPAddressCreatable)
    // ...
```

Create the resources in your Azure subscription using the `Create()` method for the resource collection. 

```csharp
// Create the VM and its Public IP Address
var virtualMachine = azure.VirtualMachines.Create(vmCreatable);
```

Passing creatable objects to `Create()` returns a `ICreatedResources` object instead of a single resource object.  The `CreatedRelatedResource` object lets you access all resources created by the `Create()` call, not just the type from the resource collection. To access the public IP address created in Azure for the virtual machine created in the above example:

```csharp
var pip = virtualMachine.CreatedRelatedResource(publicIPAddressCreatable.Key()) as PublicIPAddress;;
```    

## Exception handling

The management API defines exception classes that extend `Microsoft.Rest.RestException`. Catch exceptions generated by management API, with a `catch (RestException exception)` block after the relevant `try` statement.

## Logs and tracing

Logging in the fluent Azure management libraries for .NET leverages the underlying [AutoRest](https://github.com/Azure/AutoRest) service client tracing.

Create a class that implements `Microsoft.Rest.IServiceClientTracingInterceptor`.  This class will be responsible for intercepting log messages and passing them to whatever logging mechanism you're using.  In this example, we're just writing messages to the console, but you could also pass them to Log4Net, `Microsoft.Extensions.Logging`, or any other logging framework.

```csharp
class ConsoleTracer : IServiceClientTracingInterceptor
{
    public void Information(string message)
    {
        Console.WriteLine(message);
    }

    public void TraceError(string invocationId, Exception exception)
    {
        Console.WriteLine("Exception in {0}: {1}", invocationId, exception);
    }

    public void ReceiveResponse(string invocationId, HttpResponseMessage response) { }

    public void SendRequest(string invocationId, HttpRequestMessage request) { }

    public void Configuration(string source, string name, string value) { }

    public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters) { }

    public void ExitMethod(string invocationId, object returnValue) { }
}
```

Before creating the `Microsoft.Azure.Management.Fluent.Azure` object, initialize the `IServiceClientTracingInterceptor` you created above by calling `ServiceClientTracing.AddTracingInterceptor()` and set `ServiceClientTracing.IsEnabled` to *true*.  When you create the `Azure` object, include the `.WithDelegatingHandler()` and `.WithLogLevel()` methods to wire up the client to AutoRest's service client tracing.

```csharp
ServiceClientTracing.AddTracingInterceptor(new ConsoleTracer());
ServiceClientTracing.IsEnabled = true;

var azure = Azure
    .Configure()
    .WithDelegatingHandler(new HttpLoggingDelegatingHandler())
    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
    .Authenticate(credentials)
    .WithDefaultSubscription();
```

The `HttpLoggingDelegatingHandler` log levels are defined as follows:

| Trace level | Logging enabled 
| ------------ | ---------------
| HttpLoggingDelegatingHandler.Level.None | No output
| HttpLoggingDelegatingHandler.Level.Basic | Logs the URLs to underlying REST calls, response codes and times
| HttpLoggingDelegatingHandler.Level.Body | Everything in Basic plus request and response bodies for the REST calls
| HttpLoggingDelegatingHandler.Level.Headers | Everything in Basic plus the request and response headers REST calls
| HttpLoggingDelegatingHandler.Level.BodyAndHeaders | Everything in both Body and Headers log level
