---
title: Use Azure Storage with the Azure SDK for Python
description: Use the Azure SDK for Python libraries to access a pre-provisioned blob container in an Azure Storage account and then upload a file to that container.
ms.date: 06/15/2020
ms.topic: conceptual
---

# Example: Use the Azure libraries with Azure Storage

This example demonstrated how to use the Azure client libraries in Python application code to upload a file to that Blob storage container. The example assumes you have provisioned the resources shown in [Example: Provision Azure Storage](azure-sdk-example-storage.md).

All the commands in this article work the same in Linux/Mac OS bash and Windows command shells unless noted.

## 1: Set up your local development environment

If you haven't already, follow all the instructions on [Configure your local Python dev environment for Azure](configure-local-development-environment.md).

Be sure to create a service principal for local development, and create and activate a virtual environment for this project.

## 2: Install library packages

1. In your *requirements.txt* file, add line for the needed client library package and save the file:

    ```text
    azure-storage-blob
    azure-identity
    ```

1. In your terminal or command prompt, reinstall requirements:

    ```cmd
    pip install -r requirements.txt
    ```

## 3: Create a file to upload

Create a source file named *sample-source.txt* (as the code expects), with contents like the following:

```text
Hello there, Azure Storage. I'm a friendly file ready to be stored in a blob.
```

## 4: Use blob storage from app code

The following sections (numbered 4a and 4b) demonstrate two means to access the blob container provisioned through [Example: Provision Azure Storage](azure-sdk-example-storage.md).

The [first method (section 4a below)](#4a-use-blob-storage-with-authentication) authenticates the app with `DefaultAzureCredential` as described in [How to authenticate Python apps](azure-sdk-authenticate.md#authenticate-with-defaultazurecredential). With this method you must first assign the appropriate permissions to the app identity, which is the recommended practice.

The [second method (section 4b below)](#4b-use-blob-storage-with-a-connection-string) uses a connection string to access the storage account directly. Although this method seems simpler, it has two significant drawbacks:

- A connection string inherently authenticates the connecting agent with the Storage *account* rather than with individual resources within that account. As a result, a connection string provides grants broader authorization than may be required.

- A connection string contains an access key in plain text and therefore presents potential vulnerabilities if it's improperly constructed or improperly secured. If such a connection string is exposed it can be used to access a wide range of resources within the Storage account.

For these reasons, we recommend using the authentication method in production code.

### 4a: Use blob storage with authentication

1. Create an environment variable named `STORAGE_BLOB_URL`:

    # [cmd](#tab/cmd)

    ```cmd
    set STORAGE_BLOB_URL=https://pythonazurestorage12345.blob.core.windows.net
    ```

    # [bash](#tab/bash)

    ```bash
    STORAGE_BLOB_URL=https://pythonazurestorage12345.blob.core.windows.net
    ```

    ---

    Replace "pythonazurestorage12345" with the name of your specific storage account.

    This environment variable is used only by this example and it not used by the Azure libraries.

1. Create a file named *use_blob_auth.py* with the following code. The comments explain the steps.

    ```python
    import os
    from azure.identity import DefaultAzureCredential

    # Import the client object from the Azure library
    from azure.storage.blob import BlobClient

    credential = DefaultAzureCredential()

    # Retrieve the storage blob service URL, which is of the form
    # https://pythonazurestorage12345.blob.core.windows.net/
    storage_url = os.environ["STORAGE_BLOB_URL"]

    # Create the client object using the storage URL and the credential
    blob_client = BlobClient(storage_url, container_name="blob-container-01", blob_name="sample-blob.txt", credential=credential)

    # Open a local file and upload its contents to Blob Storage
    with open("./sample-source.txt", "rb") as data:
        blob_client.upload_blob(data)
    ```

    Reference links:
      - [DefaultAzureCredential (azure.identity)](/python/api/azure-identity/azure.identity.defaultazurecredential?view=azure-python)
      - [BlobClient (azure.storage.blob)](/python/api/azure-storage-blob/azure.storage.blob.blobclient?view=azure-python)

1. Attempt to run the code (which fails intentionally):

    ```cmd
    python use_blob_auth.py
    ```

    Because the local service principal that you're using does not have permission to access the blob container, you see the error: "This request is not authorized to perform this operation using this permission."

1. Grant container permissions fto the service principal using the Azure CLI command [az role assignment create](/cli/azure/role/assignment?view=azure-cli-latest#az-role-assignment-create) (it's a long one!):

    # [cmd](#tab/cmd)

    ```azurecli
    az role assignment create --assignee %AZURE_CLIENT_ID% ^
        --role "Storage Blob Data Contributor" ^
        --scope "/subscriptions/%AZURE_SUBSCRIPTION_ID%/resourceGroups/PythonAzureExample-Storage-rg/providers/Microsoft.Storage/storageAccounts/pythonazurestorage12345/blobServices/default/containers/blob-container-01"
    ```

    # [bash](#tab/bash)

    ```azurecli
    az role assignment create --assignee $AZURE_CLIENT_ID \
        --role "Storage Blob Data Contributor" \
        --scope "/subscriptions/$AZURE_SUBSCRIPTION_ID/resourceGroups/PythonAzureExample-Storage-rg/providers/Microsoft.Storage/storageAccounts/pythonazurestorage12345/blobServices/default/containers/blob-container-01"
    ```

    ---

    The `--scope` argument identifies where this role assignment applies. In this example, you grant the "Storage Blob Data Contributor" role to the *specific* container named "blob-container-01".

    Replace `pythonazurestorage12345` with the exact name of your storage account. You can also adjust the name of the resource group and blob container, if necessary. If you use the wrong name, you see the error, "Can not perform requested operation on nested resource. Parent resource 'pythonazurestorage12345' not found."

    The `--scope` argument in this command also uses the AZURE_CLIENT_ID and AZURE_SUBSCRIPTION_ID environment variables, which you should already have set in your local environment for your service principal by following [Configure your local Python dev environment for Azure](configure-local-development-environment.md).

1. After waiting a minute or two for the permissions to propagate, run the code again to verify that it now works. If you see the permissions error again, wait a little longer, then try the code again.

For more information on scopes and role assignments, see [How to assign role permissions](how-to-assign-role-permissions.md).

### 4b: Use blob storage with a connection string

1. Create an environment variable named `AZURE_STORAGE_CONNECTION_STRING`, the value of which is the full connection string for the storage account. (This environment variable is also used by various Azure CLI comments.)

1. Create a Python file named *use_blob_conn_string.py* with the following code. The comments explain the steps.

    ```python
    import os

    # Import the client object from the Azure library
    from azure.storage.blob import BlobClient

    # Retrieve the connection string from an environment variable.
    conn_string = os.environ["AZURE_STORAGE_CONNECTION_STRING"]

    # Create the client object for the resource identified by the connection string,
    # indicating also the blob container and the name of the specific blob we want.
    blob_client = BlobClient.from_connection_string(conn_string, container_name="blob-container-01", blob_name="sample-blob.txt")

    # Open a local file and upload its contents to Blob Storage
    with open("./sample-source.txt", "rb") as data:
        blob_client.upload_blob(data)
    ```

1. Run the code:

    ```bash
    python use_blob_conn_string.py
    ```

Again, although this method is simple, a connection string authorizes all operations in a storage account. With production code it's better to use specific permissions as described in the previous section.

## 5. Verify blob creation

After running the code of either method, go to the [Azure portal](https://portal.azure.com), navigate into the blob container to verify that a new blob exists named *sample-blob.txt* with the same contents as the *sample-source.txt* file:

![Azure portal page for the blob container, showing the uploaded file](media/azure-sdk-example-storage/portal-blob-container-file.png)

## 6: Clean up resources

```azurecli
az group delete -n PythonAzureExample-Storage-rg
```

Run this command if you don't need to keep the resources provisioned in this example and would like to avoid ongoing charges in your subscription.

You can also use the [`ResourceManagementClient.resource_groups.delete`](/python/api/azure-mgmt-resource/azure.mgmt.resource.resources.v2019_10_01.operations.resourcegroupsoperations?view=azure-python#delete-resource-group-name--custom-headers-none--raw-false--polling-true----operation-config-) method to delete a resource group from code.

## See also

- [Example: Provision a resource group](azure-sdk-example-resource-group.md)
- [Example: Provision a web app and deploy code](azure-sdk-example-web-app.md)
- [Example: Provision Azure Storage](azure-sdk-example-storage.md)
- [Example: Provision and query a database](azure-sdk-example-database.md)
- [Example: Provision a virtual machine](azure-sdk-example-virtual-machines.md)
