---
title: Resource management
description: Learn how to use the Azure SDK for .NET to manage Azure resources.
ms.date: 07/21/2020
ms.author: nickzhums
author: nickzhums
---
# Resource management using the Azure SDK for .NET

The next-generation .NET SDK's management (or "management plane") libraries, the names of which all begin with `Azure.ResourceManager` (for example: `Azure.ResourceManager.Compute`), help you create, provision, and otherwise manage Azure resources from .NET code. All Azure services have corresponding management libraries.

With the management libraries, you can write configuration and deployment programs to perform the same tasks that you can through the Azure portal, Azure CLI, or other resource management tools.

Those `Azure.ResourceManager.*` packages follow the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html). The guidelines enforce core capabilities that are shared amongst all Azure SDKs. For example:

- The intuitive Azure Identity library that provides authentication modules.
- User-friendly API design that resembles the Azure resource hierarchy.
- An HTTP pipeline with custom policies.
- Error handling.
- Distributed tracing.

> [!NOTE]
> *Azure.ResourceManager.** packages are currently in Public Preview and may be subject to breaking changes in the future.

## Get started

### Install the package

Install the Azure Resources management packages for .NET with [NuGet](https://www.nuget.org/).

For example:

```PowerShell
Install-Package Azure.ResourceManager -Version 1.0.0-beta.1
Install-Package Azure.ResourceManager.Compute -Version 1.0.0-beta.1
Install-Package Azure.ResourceManager.Network -Version 1.0.0-beta.1
Install-Package Azure.ResourceManager.Resources -Version 1.0.0-beta.1
```

### Prerequisites

Set up a way to authenticate to Azure with Azure Identity. Some options are:

- Through the [Azure CLI login](https://docs.microsoft.com/cli/azure/authenticate-azure-cli)
- Via [Visual Studio](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#authenticating-via-visual-studio&preserve-view=false)
- Setting [environment variables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager.Core/docs/AuthUsingEnvironmentVariables.md)

More information and different authentication approaches using Azure Identity can be found in [this document](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet&preserve-view=false).

### Authenticate the client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following:

```csharp
using Azure.Identity;
using Azure.ResourceManager;
using System;
using System.Threading.Tasks;

// Code omitted for brevity

var armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

### Understand Azure resource hierarchy

To reduce both the number of clients needed to perform common tasks and the amount of redundant parameters that each of those clients take, we have introduced an object hierarchy in the SDK that mimics the object hierarchy in Azure. Each resource client in the SDK has methods to access the resource clients of its children that is already scoped to the proper subscription and resource group.

To accomplish this, there are four standard types for all resources in Azure:

#### [Resource]Data

This represents the data that makes up a given resource. Typically, this is the response data from a service call such as HTTP GET and provides details about the underlying resource. Previously, this was represented by a **Model** class.

#### [Resource]Operations

This represents a service client that's scoped to a particular resource. You can directly execute all operations on that client without needing to pass in scope parameters such as subscription ID or resource name.

#### [Resource]Container

This represents the operations you can perform on a collection of resources belonging to a specific parent resource.
This mainly consists of List or Create operations. For most things, the parent will be a **ResourceGroup**. However, each parent / child relationship is represented this way. For example, a **Subnet** is a child of a **VirtualNetwork** and a **ResourceGroup** is a child of a **Subscription**.

#### [Resource]

This represents a full resource object which contains a `Data` property exposing the details as a `[Resource]Data` type. It also has access to all of the operations and like the `[Resource]Operations` object is already scoped to a specific resource in Azure.

### Structured resource identifier

Instead of implementing your own parsing logic, you can implicitly cast a resource identifier string into an object which will do the parsing for you.

There are three types of resource identifiers. The identifiers correspond to the level at which the resource lives. A resource that lives:

- On a tenant will have a `TenantResourceIdentifier`.
- Under a subscription will have a `SubscriptionResourceIdentifer`.
- Under a resource group will have a `ResourceGroupResourceIdentifier`.

You can usually tell by the ID string itself which type it is. If you're unsure, cast it to a `ResourceIdentifier` and use the `Try` methods to retrieve the values.

#### Cast to a specific type

```csharp
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
// We know the subnet is a resource group level identifier since it has a resource group name in its string
ResourceGroupResourceIdentifier id = resourceId;
Console.WriteLine($"Subscription: {id.SubscriptionId}");
Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```

#### Casting to the base resource identifier

```csharp
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
// Assume we don't know what type of resource id we have we can cast to the base type
ResourceIdentifier id = resourceId;
string property;
if (id.TryGetSubscriptionId(out property))
    Console.WriteLine($"Subscription: {property}");
if (id.TryGetResourceGroupName(out property))
    Console.WriteLine($"ResourceGroup: {property}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```

### Manage existing resources by ID

Performing operations on resources that already exist is a common use case when using the management SDK. In this scenario, you usually have the identifier of the resource you want to work on as a string. Although the new object hierarchy is great for provisioning and working within the scope of a given parent, it's a tad awkward when it comes to this specific scenario.  

The following example shows how to access an `AvailabilitySet` object and manage it directly with its ID:

```csharp
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Compute;
using System;
using System.Threading.Tasks;

// Code omitted for brevity

string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet";
// We know the availability set is a resource group level identifier since it has a resource group name in its string
ResourceGroupResourceIdentifier id = resourceId;
// We then construct a new armClient to work with
var armClient = new ArmClient(new DefaultAzureCredential());
// Next we get the specific subscription this resource belongs to
Subscription subscription = await armClient.GetSubscriptions().GetAsync(id.SubscriptionId);
// Next we get the specific resource group this resource belongs to
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(id.ResourceGroupName);
// Finally we get the resource itself
// Note: for this last stept in this example, Azure.ResourceManager.Compute is needed
AvailabilitySet availabilitySet = await resourceGroup.GetAvailabilitySets().GetAsync(id.Name);
```

However, this approach required a lot of code and three API calls to Azure. The same can be done with less code and without any API calls by using extension methods that we have provided on the client itself. These extension methods allow you to pass in a resource identifier and retrieve a scoped client. The object returned is a `[Resource]Operations` mentioned above, since it has not reached out to Azure to retrieve the data yet.

The previous example would end up looking like this:

```csharp
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet";
// We construct a new armClient to work with
var armClient = new ArmClient(new DefaultAzureCredential());
// Next we get the AvailabilitySetOperations object from the client
// The method takes in a ResourceIdentifier but we can use the implicit cast from string
AvailabilitySetOperations availabilitySetOperations = armClient.GetAvailabilitySetOperations(resourceId);
// Now if we want to retrieve the objects data we can simply call get
AvailabilitySet availabilitySet = await availabilitySetOperations.GetAsync();
```

### `TryGet` and `DoesExist` convenience methods

If you aren't sure whether a resource you want to get exists, or you just want to check if it exists, use the `TryGet` or `DoesExist` methods. The methods can be invoked from any `[Resource]Container` class.

The `TryGet` and `TryGetAsync` methods return a null object if the specified resource name or ID doesn't exist. On the other hand, the `DoesExist` and `DoesExistAsync` methods return a boolean indicating whether the specified resource exists.

You can find an example for these methods [below](#check-if-resource-group-exists).

## Examples

### Create a resource group

```csharp
// First, initialize the ArmClient and get the default subscription
var armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup container for that subscription
Subscription subscription = armClient.DefaultSubscription;
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
```

### List all resource groups

```csharp
// First, initialize the ArmClient and get the default subscription
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// Now we get a ResourceGroup container for that subscription
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With ListAsync(), we can get a list of the resources in the container
AsyncPageable<ResourceGroup> response = rgContainer.GetAllAsync();
await foreach (ResourceGroup rg in response)
{
    Console.WriteLine(rg.Data.Name);
}
```

### Update a resource group

```csharp
// Note: Resource group named 'myRgName' should exist for this example to work.
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
resourceGroup = await resourceGroup.AddTagAsync("key", "value");
```

### Delete a resource group

```csharp
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
await resourceGroup.DeleteAsync();
```

### Check if resource group exists

```csharp
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
string rgName = "myRgName";

var exists = await subscription.GetResourceGroups().CheckIfExistsAsync(rgName);

if (exists)
{
    Console.WriteLine($"Resource Group {rgName} exists.");

    // We can get the resource group now that we are sure it exists.
    var myRG = await subscription.GetResourceGroups().GetAsync(rgName);
}
else
{
    Console.WriteLine($"Resource Group {rgName} does not exist.");
}
```

Another way to do this is by calling `TryGetAsync`:

```csharp
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
string rgName = "myRgName";

var myRG = await subscription.GetResourceGroups().TryGetAsync(rgName);

if (myRG == null)
{
    Console.WriteLine($"Resource Group {rgName} does not exist.");
    return;
}

// At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
```

### Add a tag to a virtual machine

Imagine that our company requires all virtual machines to be tagged with the owner. We're tasked with writing a program to add the tag to any missing virtual machines in a given resource group.

```csharp
// First we construct our armClient
var armClient = new ArmClient(new DefaultAzureCredential());

// Next we get a resource group object
// ResourceGroup is a [Resource] object from above
ResourceGroup resourceGroup = await armClient.DefaultSubscription.GetResourceGroups().GetAsync("myRgName");

// Next we get the container for the virtual machines
// vmContainer is a [Resource]Container object from above
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();

// Next we loop over all vms in the container
// Each vm is a [Resource] object from above
await foreach(VirtualMachine vm in vmContainer.GetAllAsync())
{
    // We access the [Resource]Data properties from vm.Data
    if(!vm.Data.Tags.ContainsKey("owner"))
    {
        // We can also access all [Resource]Operations from vm since it is already scoped for us
        await vm.StartAddTag("owner", GetOwner()).WaitForCompletionAsync();
    }
}
```

For more detailed examples, see the [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager.Core/samples).

## Troubleshoot

- If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues).
- If you need help, check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.
- If having trouble with authentication, see the [DefaultAzureCredential documentation](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet&preserve-view=false).

## Next steps

### More sample code

- [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/samples/Sample2_ManagingResourceGroups.md)
- [Creating a Virtual Network](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/samples/Sample3_CreatingAVirtualNetwork.md)
- [.NET Management Library Code Samples](https://docs.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK)

### Additional resources

For more information on the Azure SDK, see [this website](https://azure.github.io/azure-sdk/).
