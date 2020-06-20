---
title: Provision a resource group using the Azure libraries for Python
description: Use the resource management library in the Azure SDK for Python to create a resource group from Python code.
ms.date: 05/29/2020
ms.topic: conceptual
---

# Example: Use the Azure libraries to provision a resource group

This example demonstrates how to use the Azure SDK management libraries in a Python script to provision a resource group. (The [Equivalent Azure CLI command](#for-reference-equivalent-azure-cli-commands) is given later in this article.)

All the commands in this article work the same in Linux/Mac OS bash and Windows command shells unless noted.

## 1: Set up your local development environment

If you haven't already, follow all the instructions on [Configure your local Python dev environment for Azure](configure-local-development-environment.md).

Be sure to create a service principal for local development, and create and activate a virtual environment for this project.

## 2: Install the Azure library packages

Create a file named *requirements.txt* with the following contents:

```text
azure-mgmt-resource
azure-cli-core
```

In a terminal or command prompt with the virtual environment activated, install the requirements:

```cmd
pip install -r requirements.txt
```

## 3: Write code to provision a resource group

Create a Python file named *provision_rg.py* with the following code. The comments explain the details:

```python
# Import the needed management objects from the libraries. The azure.common library
# is installed automatically with the other libraries.
from azure.common.client_factory import get_client_from_cli_profile
from azure.mgmt.resource import ResourceManagementClient

# Obtain the management object for resources, using the credentials from the CLI login.
resource_client = get_client_from_cli_profile(ResourceManagementClient)

# Provision the resource group.
rg_result = resource_client.resource_groups.create_or_update(
    "PythonAzureExample-ResourceGroup-rg",
    {
        "location": "centralus"
    }
)

# Within the ResourceManagementClient is an object named resource_groups,
# which is of class ResourceGroupsOperations, which contains methods like
# create_or_update.
#
# The second parameter to create_or_update here is technically a ResourceGroup
# object. You can create the object directly using ResourceGroup(location=LOCATION)
# or you can express the object as inline JSON as shown here. For details,
# see Inline JSON pattern for object arguments at
# https://docs.microsoft.com/azure/developer/python/azure-sdk-overview#inline-json-pattern-for-object-arguments.

print(f"Provisioned resource group {rg_result.name} in the {rg_result.location} region")

# The return value is another ResourceGroup object with all the details of the
# new group. In this case the call is synchronous: the resource group has been
# provisioned by the time the call returns.

# Optional line to delete the resource group
#resource_client.resource_groups.delete("PythonAzureExample-ResourceGroup-rg")
```

This code uses the CLI-based authentication methods (`get_client_from_cli_profile`) because it demonstrates actions that you might otherwise do with the Azure CLI directly. In both cases you're using the same identity for authentication.

To use such code in a production script, you should instead use `DefaultAzureCredential` (recommended) or a service principal based method as describe in [How to authenticate Python apps with Azure services](azure-sdk-authenticate.md).

### Reference links for classes used in the code

- [ResourceManagementClient (azure.mgmt.resource)](/python/api/azure-mgmt-resource/azure.mgmt.resource.resourcemanagementclient?view=azure-python)

## 4: Run the script

```cmd
python provision_rg.py
```

## 5: Verify the resource group

You can verify that the group exists through the Azure portal or the Azure CLI.

- Azure portal: open the [Azure portal](https://portal.azure.com), select **Resource groups**, and check that the group is listed. If you've already had the portal open, use the **Refresh** command to update the list.

- Azure CLI: run the following command:

    ```azurecli
    az group show -n PythonAzureExample-ResourceGroup-rg
    ```

## 6: Clean up resources

```azurecli
az group delete -n PythonAzureExample-ResourceGroup-rg
```

Run this command if you don't need to keep the resource group provisioned in this example. Resource groups don't incur any ongoing charges in your subscription, but it's a good practice to clean up any group that you aren't actively using.

You can also use the [`ResourceManagementClient.resource_groups.delete`](/python/api/azure-mgmt-resource/azure.mgmt.resource.resources.v2019_10_01.operations.resourcegroupsoperations?view=azure-python#delete-resource-group-name--custom-headers-none--raw-false--polling-true----operation-config-) method to delete a resource group from code.

### For reference: equivalent Azure CLI commands

The following Azure CLI commands complete the same provisioning steps as the Python script:

```azurecli
az group create -n PythonAzureExample-ResourceGroup-rg -l centralus
```

## See also

- [Example: Provision Azure Storage](azure-sdk-example-storage.md)
- [Example: Use Azure Storage](azure-sdk-example-storage-use.md)
- [Example: Provision a web app and deploy code](azure-sdk-example-web-app.md)
- [Example: Provision and query a database](azure-sdk-example-database.md)
- [Example: Provision a virtual machine](azure-sdk-example-virtual-machines.md)
