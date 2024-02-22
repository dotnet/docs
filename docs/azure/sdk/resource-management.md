---
title: Resource management
description: Learn how to use the Azure SDK for .NET to manage Azure resources.
ms.date: 01/26/2024
---

# Resource management using the Azure SDK for .NET

The Azure SDK for .NET management plane libraries will help you create, provision, and manage Azure resources from within .NET applications. All Azure services have corresponding management libraries.

With the management libraries (namespaces beginning with `Azure.ResourceManager`, for example, `Azure.ResourceManager.Compute`), you can write configuration and deployment programs to perform the same tasks that you can through the Azure portal, Azure CLI, or other resource management tools.

Those packages follow the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), which provide [core capabilities](https://azure.github.io/azure-sdk/general_azurecore.html) that are shared amongst all Azure SDKs, including:

- The intuitive Azure Identity library.
- An HTTP pipeline with custom policies.
- Error handling.
- Distributed tracing.

> [!NOTE]
> You may notice that some packages are still pre-release version, phased releases of additional Azure services' management plane libraries are in process. If you are looking for a stable version package for a particular azure resource and currently only a pre-release version is available, please raise an issue in [Azure SDK for .NET Github repo](https://github.com/Azure/azure-sdk-for-net/issues/new?assignees=&labels=&template=02_feature_request.yml&title=%5BFEATURE+REQ%5D)

## Get started

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- A [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=false) implementation, such as an [Azure Identity library credential type](/dotnet/api/overview/azure/Identity-readme#credential-classes).

### Install the package

Install the Azure Identity and Azure resource management NuGet packages for .NET. For example:

# [PowerShell](#tab/PowerShell)

```PowerShell
Install-Package Azure.Identity
Install-Package Azure.ResourceManager
Install-Package Azure.ResourceManager.Resources
Install-Package Azure.ResourceManager.Compute
Install-Package Azure.ResourceManager.Network
```

# [.NET CLI](#tab/dotnetcli)

```dotnetcli
dotnet add package Azure.Identity
dotnet add package Azure.ResourceManager
dotnet add package Azure.ResourceManager.Resources
dotnet add package Azure.ResourceManager.Compute
dotnet add package Azure.ResourceManager.Network
```

---

### Authenticate the client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate with Azure and create an `ArmClient`, instantiate an `ArmClient` given credentials:

```csharp
using Azure.Identity;
using Azure.ResourceManager;
using System;
using System.Threading.Tasks;

// Code omitted for brevity

ArmClient client = new ArmClient(new DefaultAzureCredential());
```

For more information about the `Azure.Identity.DefaultAzureCredential` class, see [DefaultAzureCredential Class](/dotnet/api/azure.identity.defaultazurecredential).

### Management SDK Cheat Sheet

To get started with the Azure management SDK for .NET, imagine you have a task to create/list/update/delete a typical Azure service bus namespace, follow these steps:

1. Authenticate to the subscription and resource group that you want to work on.

```csharp
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ServiceBus;

ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = client.GetDefaultSubscription();
ResourceGroupResource resourceGroup =
    client.GetDefaultSubscription().GetResourceGroup(resourceGroupName);
```

1. Find the corresponding method to manage your Azure resource.

| Operation | Method |
|-|-|
| Get a resource with resource identifier | `client.GetServiceBusQueueResource(ResourceIdentifier resourceIdentifier)` |
| List| `resourceGroup.GetServiceBusNamespaces()` |
| Index | `resourceGroup.GetServiceBusNamespace(string servicebusNamespaceName)` |
| Add/Update | `resourceGroup.GetServiceBusNamespaces().CreateOrUpdate(Azure.WaitUntil waitUntil, string name, ServiceBusNamespaceData data)` |
| Contains | `resourceGroup.GetServiceBusNamespaces().Exists(string servicebusNamespaceName)` |
| Delete |  `client.GetServiceBusQueueResource(ResourceIdentifior resourceIdentifior).Delete()` or `resourceGroup.GetServiceBusNamespace(string servicebusNamespaceName).Delete()`|

Remember, all the Azure resources, including the resource group itself, can be managed by their corresponding management SDK using code similar to the above example. To find the correct Azure management SDK package, look for packages named with the following pattern `Azure.ResourceManager.{ResourceProviderName}`.

To learn more about the ResourceIdentifier, please refer to [Structured Resource Identifier](#structured-resource-identifier).

## Key concepts

### Understanding Azure Resource Hierarchy

To reduce the number of clients needed to perform common tasks and the number of redundant parameters that each of those clients take, we've introduced an object hierarchy in the SDK that mimics the object hierarchy in Azure. Each resource client in the SDK has methods to access the resource clients of its children that are already scoped to the proper subscription and resource group.

To accomplish this, we're introducing three standard types for all resources in Azure:

#### **{ResourceName}Resource** class

This type represents a full resource client object that contains a **Data** property exposing the details as a **{ResourceName}Data** type.
It also has access to all of the operations on that resource without needing to pass in scope parameters such as subscription ID or resource name. This makes it convenient to directly execute operations on the result of list calls, since everything is returned as a full resource client now.

```csharp
ArmClient client = new ArmClient(new DefaultAzureCredential());
string resourceGroupName = "myResourceGroup";
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(resourceGroupName);
await foreach (VirtualMachineResource virtualMachine in resourceGroup.GetVirtualMachinesAsync())
{
    //previously we would have to take the resourceGroupName and the vmName from the vm object
    //and pass those into the powerOff method as well as we would need to execute that on a separate compute client
    await virtualMachine.PowerOffAsync(WaitUntil.Completed);
}
```

#### **{ResourceName}Data** class

This type represents the model that makes up a given resource. Typically, this is the response data from a service call such as HTTP GET and provides details about the underlying resource. Previously, this was represented by a **Model** class.

#### **{ResourceName}Collection** class

This type represents the operations you can perform on a collection of resources belonging to a specific parent resource.
This object provides most of the logical collection operations.

| Collection Behavior | Collection Method |
|-|-|
| Iterate/List | GetAll() |
| Index | Get(string name) |
| Add | CreateOrUpdate(Azure.WaitUntil waitUntil, string name, {ResourceName}Data data) |
| Contains | Exists(string name) |

In most cases, parent of a resource is **ResourceGroup**, but in some cases, a resource itself has sub resource, for example a **Subnet** is a child of a **VirtualNetwork**. **ResourceGroup** itself is a child of a **Subscription**

### Putting it all together

Imagine that our company requires all virtual machines to be tagged with the owner. We're tasked with writing a program to add the tag to any missing virtual machines in a given resource group.

 ```csharp
// First we construct our armClient
ArmClient client = new ArmClient(new DefaultAzureCredential());

// Next we get a resource group object
// ResourceGroup is a {ResourceName}Resource object from above
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupResource resourceGroup =
    await subscription.GetResourceGroupAsync("myRgName");

// Next we get the collection for the virtual machines
// vmCollection is a {ResourceName}Collection object from above
VirtualMachineCollection virtualMachineCollection = await resourceGroup.GetVirtualMachines();

// Next we loop over all vms in the collection
// Each vm is a {ResourceName}Resource object from above
await foreach(VirtualMachineResource virtualMachine in virtualMachineCollection)
{
    // We access the {ResourceName}Data properties from vm.Data
    if(!virtualMachine.Data.Tags.ContainsKey("owner"))
    {
        // We can also access all operations from vm since it is already scoped for us
        await virtualMachine.AddTagAsync("owner", GetOwner());
    }
}
 ```

### Structured Resource Identifier

Resource IDs contain useful information about the resource itself, but they're plain strings that have to be parsed. Instead of implementing your own parsing logic, you can use a `ResourceIdentifier` object that will do the parsing for you.

#### Example: Parsing an ID using a ResourceIdentifier object

```csharp
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
ResourceIdentifier id = new ResourceIdentifier(resourceId);
Console.WriteLine($"Subscription: {id.SubscriptionId}");
Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```

However, keep in mind that some of those properties could be null. You can usually tell by the ID string itself which type a resource ID is. But if you're unsure, check if the properties are null.

#### Example: Resource Identifier Generator

You may not want to manually create the `resourceId` from a pure `string`. Each `{ResourceName}Resource` class has a static method that can help you create the resource identifier string.

```csharp
ResourceIdentifier resourceId =
    AvailabilitySetResource.CreateResourceIdentifier(
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        "resourceGroupName",
        "resourceName");
```

#### Manage existing resources

Performing operations on resources that already exist is a common use case when using the management client libraries. In this scenario, you usually have the identifier of the resource you want to work on as a string. Although the new object hierarchy is great for provisioning and working within the scope of a given parent, it is not the most efficient when it comes to this specific scenario.

Here's an example how you can access an `AvailabilitySetResource` object and manage it directly with its resource identifier:

```csharp
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Compute;
using System;
using System.Threading.Tasks;

// Code omitted for brevity

ResourceIdentifier subscriptionId =
    SubscriptionResource.CreateResourceIdentifier("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");

ResourceIdentifier resourceId =
    AvailabilitySetResource.CreateResourceIdentifier(
        subscriptionId.SubscriptionId,
        "resourceGroupName",
        "resourceName");

// We construct a new armClient to work with
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Next we get the specific subscription this resource belongs to
SubscriptionResource subscription = client.GetSubscriptionResource(subscriptionId);
// Next we get the specific resource group this resource belongs to
ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(resourceId.ResourceGroupName);
// Finally we get the resource itself
// Note: for this last step in this example, Azure.ResourceManager.Compute is needed
AvailabilitySetResource availabilitySet = await resourceGroup.GetAvailabilitySetAsync(resourceId.Name);
```

This approach required a lot of code and three API calls are made to Azure. The same can be done with less code and without any API calls by using extension methods that we've provided on the client itself. These extension methods allow you to pass in a resource identifier and retrieve a scoped resource client. The object returned is a [{ResourceName}Resource](#resourcenameresource-class). Since it hasn't reached out to Azure to retrieve the data yet, calling the `Data` property will throw exception, you can either use `HasData` property to tell if the resource instance contains a data or call the `Get` or `GetAsync` method on the resource to retrieve the resource data.

So, the previous example would end up looking like this:

```csharp
ResourceIdentifier resourceId =
    AvailabilitySetResource.CreateResourceIdentifier(
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        "resourceGroupName",
        "resourceName");
// We construct a new armClient to work with
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Next we get the AvailabilitySet resource client from the armClient
// The method takes in a ResourceIdentifier but we can use the implicit cast from string
AvailabilitySetResource availabilitySet = client.GetAvailabilitySetResource(resourceId);
// At this point availabilitySet.Data will be null and trying to access it will throw exception
// If we want to retrieve the objects data we can simply call get
availabilitySet = await availabilitySet.GetAsync();
// we now have the data representing the availabilitySet
Console.WriteLine(availabilitySet.Data.Name);
```

### Check if a Resource exists

If you aren't sure if a resource you want to get exists, or you just want to check if it exists, you can use `Exists()` or `ExistsAsync()` methods, which can be invoked from any `{ResourceName}Collection` class.

`Exists()` returns a `Response<bool>` while `ExistsAsync()` as its async version returns a `Task<Response<bool>>`. In the `Response<bool>` object, you can visit its `Value` property to check if a resource exists. The `Value` is `false` if the resource does not exist and vice versa.

In previous versions of packages, you would have to catch the `RequestFailedException` and inspect the status code for 404. With this new API, we hope that this can boost the developer productivity and optimize resource access.

```csharp
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
string resourceGroupName = "myRgName";

try
{
    ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(resourceGroupName);
    // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine($"Resource Group {resourceGroupName} does not exist.");
}
```

Now with these convenience methods, we can simply do the following.

```csharp
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
string resourceGroupName = "myRgName";

bool exists = await subscription.GetResourceGroups().ExistsAsync(resourceGroupName).Value;

if (exists)
{
    Console.WriteLine($"Resource Group {resourceGroupName} exists.");

    // We can get the resource group now that we know it exists.
    // This does introduce a small race condition where resource group could have been deleted between the check and the get.
    ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(resourceGroupName);
}
else
{
    Console.WriteLine($"Resource Group {rgName} does not exist.");
}
```

## Examples

### Create a resource group

```csharp
// First, initialize the ArmClient and get the default subscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroupCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string resourceGroupName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ResourceGroupData resourceGroupData = new ResourceGroupData(location);
ResourceGroupResource resourceGroup = (await resourceGroupCollection.CreateOrUpdateAsync(resourceGroupName, resourceGroupData)).Value;
```

### List all resource groups

```csharp
// First, initialize the ArmClient and get the default subscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
// Now we get a ResourceGroup collection for that subscription
ResourceGroupCollection resourceGroupCollection = subscription.GetResourceGroups();
// With GetAllAsync(), we can get a list of the resources in the collection
await foreach (ResourceGroupResource resourceGroup in resourceGroupCollection)
{
    Console.WriteLine(resourceGroup.Data.Name);
}
```

### Update a resource group

```csharp
// Note: Resource group named 'myRgName' should exist for this example to work.
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
string resourceGroupName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(resourceGroupName);
resourceGroup = await resourceGroup.AddTagAsync("key", "value");
```

### Delete a resource group

```csharp
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
string resourceGroupName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(resourceGroupName);
await resourceGroup.DeleteAsync();
```

For more detailed examples, take a look at [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager/samples) we have available.

## Troubleshooting

- If you have a bug to report or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and make sure you add the "Preview" label to the issue.
- If you need help, check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net), or ask new ones on StackOverflow using Azure and .NET tags.
- If having trouble with authentication, see the [DefaultAzureCredential documentation](/dotnet/api/azure.identity.defaultazurecredential).

## Next steps

### More sample code

- [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/samples/DocSamples/Sample2_ManagingResourceGroups.cs)
- [Creating a Virtual Network](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/samples/DocSamples/Sample3_CreatingAVirtualNetwork.cs)
- [.NET Management Library Code Samples](/samples/browse/?languages=csharp&terms=managing%20using%20Azure%20.NET%20SDK)

### Additional Documentation

If you're migrating from the old SDK to this preview, check out this [Migration guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/MigrationGuide.md).

For more information on Azure SDK, see [Azure SDK Releases](https://azure.github.io/azure-sdk/).
