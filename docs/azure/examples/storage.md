---
title: Provision Azure Storage with the Azure libraries for Python
description: Use the Azure SDK for Python libraries to provision a blob container in an Azure Storage account and then upload a file to that container.
ms.date: 05/29/2020
ms.topic: conceptual
---

# Example: Use the Azure libraries with Azure Storage

In this article, you learn how to use the Azure management libraries in a Python script to provision a resource group that contains and Azure Storage account and a Blob storage container. ([Equivalent Azure CLI commands](#for-reference-equivalent-azure-cli-commands) are given later in this article.)

After provisioning the resources, see [Example: Use Azure Storage](azure-sdk-example-storage-use.md) to use the Azure client libraries in Python application code to upload a file to the Blob storage container.

All the commands in this article work the same in Linux/Mac OS bash and Windows command shells unless noted.

## 1: Set up your local development environment

If you haven't already, follow all the instructions on [Configure your local Python dev environment for Azure](configure-local-development-environment.md).

Be sure to create a service principal for local development, and create and activate a virtual environment for this project.

## 2: Install the needed Azure library packages

1. Create a *requirements.txt* file that lists the management libraries used in this example:

    ```txt
    azure-mgmt-resource
    azure-mgmt-storage
    azure-cli-core
    ```

1. In your terminal with the virtual environment activated, install the requirements:

    ```cmd
    pip install -r requirements.txt
    ```

## 3: Write code to provision storage resources

This section describes how to provision storage resources from Python code. If you prefer, you can also provision resources through the Azure portal or through the [equivalent Azure CLI commands](#for-reference-equivalent-azure-cli-commands).

Create a Python file named *provision_blob.py* with the following code. The comments explain the details:

```python
import os, random

# Import the needed management objects from the libraries. The azure.common library
# is installed automatically with the other libraries.
from azure.common.client_factory import get_client_from_cli_profile
from azure.mgmt.resource import ResourceManagementClient
from azure.mgmt.storage import StorageManagementClient

# Obtain the management object for resources, using the credentials from the CLI login.
resource_client = get_client_from_cli_profile(ResourceManagementClient)

# Constants we need in multiple places: the resource group name and the region
# in which we provision resources. You can change these values however you want.
RESOURCE_GROUP_NAME = "PythonAzureExample-Storage-rg"
LOCATION = "centralus"

# Step 1: Provision the resource group.
rg_result = resource_client.resource_groups.create_or_update(RESOURCE_GROUP_NAME,
    { "location": LOCATION })

print(f"Provisioned resource group {rg_result.name}")

# For details on the previous code, see Example: Provision a resource group
# at https://docs.microsoft.com/azure/developer/python/azure-sdk-example-resource-group

# Step 2: Provision the storage account, starting with a management object.

storage_client = get_client_from_cli_profile(StorageManagementClient)

# This example uses the CLI profile credentials because we assume the script
# is being used to provision the resource in the same way the Azure CLI would be used.

STORAGE_ACCOUNT_NAME = f"pythonazurestorage{random.randint(1,100000):05}"

# You can replace the storage account here with any unique name. A random number is used
# by default, but note that the name changes every time you run this script.
# The name must be 3-24 lower case letters and numbers only.


# Check if the account name is available. Storage account names must be unique across
# Azure because they're used in URLs.
availability_result = storage_client.storage_accounts.check_name_availability(STORAGE_ACCOUNT_NAME)

if not availability_result.name_available:
    print(f"Storage name {STORAGE_ACCOUNT_NAME} is already in use. Try another name.")
    exit()

# The name is available, so provision the account
poller = storage_client.storage_accounts.create(RESOURCE_GROUP_NAME, STORAGE_ACCOUNT_NAME,
    {
        "location" : LOCATION,
        "kind": "StorageV2",
        "sku": {"name": "Standard_LRS"}
    }
)

# Long-running operations return a poller object; calling poller.result()
# waits for completion.
account_result = poller.result()
print(f"Provisioned storage account {account_result.name}")

# Step 3: Retrieve the account's primary access key and generate a connection string.
keys = storage_client.storage_accounts.list_keys(RESOURCE_GROUP_NAME, STORAGE_ACCOUNT_NAME)

print(f"Primary key for storage account: {keys.keys[0].value}")

conn_string = f"DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName={STORAGE_ACCOUNT_NAME};AccountKey={keys.keys[0].value}"

print(f"Connection string: {conn_string}")

# Step 4: Provision the blob container in the account (this call is synchronous)
CONTAINER_NAME = "blob-container-01"
container = storage_client.blob_containers.create(RESOURCE_GROUP_NAME, STORAGE_ACCOUNT_NAME, CONTAINER_NAME, {})

# The fourth argument is a required BlobContainer object, but because we don't need any
# special values there, so we just pass empty JSON.

print(f"Provisioned blob container {container.name}")
```

This code uses the CLI-based authentication methods (`get_client_from_cli_profile`) because it demonstrates actions that you might otherwise do with the Azure CLI directly. In both cases you're using the same identity for authentication.

To use such code in a production script, you should instead use `DefaultAzureCredential` (recommended) or a service principal based method as describe in [How to authenticate Python apps with Azure services](azure-sdk-authenticate.md).

### Reference links for classes used in the code

- [ResourceManagementClient (azure.mgmt.resource)](/python/api/azure-mgmt-resource/azure.mgmt.resource.resourcemanagementclient?view=azure-python)
- [StorageManagementClient (azure.mgmt.storage)](/python/api/azure-mgmt-storage/azure.mgmt.storage.storagemanagementclient?view=azure-python)

## 4. Run the script

```cmd
python provision_blob.py
```

The script will take a minute or two to complete.

## 5: Verify the resources

1. Open the [Azure portal](https://portal.azure.com) to verify that the resource group and storage account were provisioned as expected. You may need to select **Show hidden types** in the resource group to see a storage account provisioned from a Python script:

    ![Azure portal page for the new resource group, showing the storage account](media/azure-sdk-example-storage/portal-show-hidden-types.png)

1. Select the storage account, then select **Blob service** > **Containers** in the left-hand menu to verify that the "bloc-container-01" appears:

    ![Azure portal page for the storage account showing the blob container](media/azure-sdk-example-storage/portal-show-blob-containers.png)

1. If you want to try using these provisioned resources from application code, continue with [Example: Use Azure Storage](azure-sdk-example-storage-use.md).

For an additional example of using the Azure Storage management library, see the [Manage Python Storage sample](https://docs.microsoft.com/samples/azure-samples/storage-python-manage/storage-python-manage/).

### For reference: equivalent Azure CLI commands

The following Azure CLI commands complete the same provisioning steps as the Python script:

# [cmd](#tab/cmd)

```azurecli
rem Provision the resource group

az group create -n PythonAzureExample-Storage-rg -l centralus

rem Provision the storage account

az storage account create -g PythonAzureExample-Storage-rg -l centralus ^
    -n pythonazurestorage12345 --kind StorageV2 --sku Standard_LRS

rem Retrieve the connection string

az storage account show-connection-string -g PythonAzureExample-Storage-rg ^
    -n pythonazurestorage12345

rem Provision the blob container; NOTE: this command assumes you have an environment variable
rem named AZURE_STORAGE_CONNECTION_STRING with the connection string for the storage account.

set AZURE_STORAGE_CONNECTION_STRING=<connection_string>
az storage container create --account-name pythonazurestorage12345 -n blob-container-01
```

# [bash](#tab/bash)

```azurecli
# Provision the resource group

az group create -n PythonAzureExample-Storage-rg -l centralus

# Provision the storage account

az storage account create -g PythonAzureExample-Storage-rg -l centralus \
    -n pythonazurestorage12345 --kind StorageV2 --sku Standard_LRS

# Retrieve the connection string

az storage account show-connection-string -g PythonAzureExample-Storage-rg \
    -n pythonazurestorage12345

# Provision the blob container; NOTE: this command assumes you have an environment variable
# named AZURE_STORAGE_CONNECTION_STRING with the connection string for the storage account.

AZURE_STORAGE_CONNECTION_STRING=<connection_string>
az storage container create --account-name pythonazurestorage12345 -n blob-container-01
```

---

## 6: Clean up resources

Leave the resources in place if you want to follow the article [Example: Use Azure Storage](azure-sdk-example-storage-use.md) to use these resources in app code.

Otherwise, run the following command to avoid ongoing charges in your subscription.

```azurecli
az group delete -n PythonAzureExample-Storage-rg
```

You can also use the [`ResourceManagementClient.resource_groups.delete`](/python/api/azure-mgmt-resource/azure.mgmt.resource.resources.v2019_10_01.operations.resourcegroupsoperations?view=azure-python#delete-resource-group-name--custom-headers-none--raw-false--polling-true----operation-config-) method to delete a resource group from code.

## See also

- [Example: Use Azure Storage](azure-sdk-example-storage-use.md)
- [Example: Provision a resource group](azure-sdk-example-resource-group.md)
- [Example: Provision a web app and deploy code](azure-sdk-example-web-app.md)
- [Example: Provision and query a database](azure-sdk-example-database.md)
- [Example: Provision a virtual machine](azure-sdk-example-virtual-machines.md)
