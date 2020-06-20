---
title: Provision and deploy a web app using the Azure SDK libraries
description: Use the management libraries in the Azure SDK libraries for Python to provision a web app and then deploy app code from a GitHub repository.
ms.date: 05/29/2020
ms.topic: conceptual
---

# Example: Use the Azure libraries to provision and deploy a web app

This example demonstrates how to use the Azure SDK management libraries in a Python script to provision a web app on Azure App Service and deploy app code from a GitHub repository. ([Equivalent Azure CLI commands](#for-reference-equivalent-azure-cli-commands) are given at later in this article.)

All the commands in this article work the same in Linux/Mac OS bash and Windows command shells unless noted.

## 1: Set up your local development environment

If you haven't already, follow all the instructions on [Configure your local Python dev environment for Azure](configure-local-development-environment.md).

Be sure to create a service principal for local development, and create and activate a virtual environment for this project.

## 2: Install the needed Azure library packages

Create a file named *requirements.txt* with the following contents:

```text
azure-mgmt-resource
azure-mgmt-web
azure-cli-core
```

In a terminal or command prompt with the virtual environment activated, install the requirements:

```cmd
pip install -r requirements.txt
```

## 3: Fork the sample repository

Visit [https://github.com/Azure-Samples/python-docs-hello-world](https://github.com/Azure-Samples/python-docs-hello-world) and fork the repository into your own GitHub account. You use a fork to ensure that you have permissions to deploy the repository to Azure.

![Forking the sample repository on GitHub](media/azure-sdk-example-web-app/fork-github-repository.png)

Then create an environment variable named `REPO_URL` with the URL of your fork. The example code in the next section depends on this environment variable:

# [cmd](#tab/cmd)

```cmd
set REPO_URL=<url_of_your_fork>
```

# [bash](#tab/bash)

```bash
REPO_URL=<url_of_your_fork>
```

---

## 4: Write code to provision and deploy a web app

Create a Python file named *provision_deploy_webapp.py* with the following code. The comments explain the details:

```python
import random, os
from azure.common.client_factory import get_client_from_cli_profile
from azure.mgmt.resource import ResourceManagementClient
from azure.mgmt.web import WebSiteManagementClient

# Retrieve subscription ID from environment variable
subscription_id = os.environ["AZURE_SUBSCRIPTION_ID"]

# Constants we need in multiple places: the resource group name and the region
# in which we provision resources. You can change these values however you want.
RESOURCE_GROUP_NAME = 'PythonAzureExample-WebApp-rg'
LOCATION = "centralus"

# Step 1: Provision the resource group.
resource_client = get_client_from_cli_profile(ResourceManagementClient)

rg_result = resource_client.resource_groups.create_or_update(RESOURCE_GROUP_NAME,
    { "location": LOCATION })

print(f"Provisioned resource group {rg_result.name}")

# For details on the previous code, see Example: Provision a resource group
# at https://docs.microsoft.com/azure/developer/python/azure-sdk-example-resource-group


#Step 2: Provision the App Service plan, which defines the underlying VM for the web app.

# Names for the App Service plan and App Service. We use a random number with the
# latter to create a reasonably unique name. If you've already provisioned a
# web app and need to re-run the script, set the WEB_APP_NAME environment 
# variable to that name instead.
SERVICE_PLAN_NAME = 'PythonAzureExample-WebApp-plan'
WEB_APP_NAME = os.environ.get("WEB_APP_NAME", f"PythonAzureExample-WebApp-{random.randint(1,100000):05}")

# Obtain the client object
app_service_client = get_client_from_cli_profile(WebSiteManagementClient)

# Provision the plan; Linux is the default
poller = app_service_client.app_service_plans.create_or_update(RESOURCE_GROUP_NAME,
    SERVICE_PLAN_NAME,
    {
        "location": LOCATION,
        "reserved": True,
        "sku" : {"name" : "B1"}
    }
)

plan_result = poller.result()

print(f"Provisioned App Service plan {plan_result.name}")


# Step 3: With the plan in place, provision the web app itself, which is the process that can host
# whatever code we want to deploy to it.

poller = app_service_client.web_apps.create_or_update(RESOURCE_GROUP_NAME,
    WEB_APP_NAME,
    {
        "location": LOCATION,
        "server_farm_id": plan_result.id,
        "site_config": {
            "linux_fx_version": "python|3.8"
        }
    }
)

web_app_result = poller.result()

print(f"Provisioned web app {web_app_result.name} at {web_app_result.default_host_name}")

# Step 4: deploy code from a GitHub repository. For Python code, App Service on Linux runs
# the code inside a container that makes certain assumptions about the structure of the code.
# For more information, see How to configure Python apps,
# https://docs.microsoft.com/azure/app-service/containers/how-to-configure-python.
#
# The create_or_update_source_control method doesn't provision a web app. It only sets the
# source control configuration for the app. In this case we're simply pointing to
# a GitHub repository.
#
# You can call this method again to change the repo.

REPO_URL = 'https://github.com/kraigb/python-docs-hello-world'

poller = app_service_client.web_apps.create_or_update_source_control(RESOURCE_GROUP_NAME,
    WEB_APP_NAME,
    {
        "location": "GitHub",
        "repo_url": REPO_URL,
        "branch": "master"
    }
)

sc_result = poller.result()

print(f"Set source control on web app to {sc_result.branch} branch of {sc_result.repo_url}")
```

This code uses the CLI-based authentication methods (`get_client_from_cli_profile`) because it demonstrates actions that you might otherwise do with the Azure CLI directly. In both cases you're using the same identity for authentication.

To use such code in a production script, you should instead use `DefaultAzureCredential` (recommended) or a service principal based method as describe in [How to authenticate Python apps with Azure services](azure-sdk-authenticate.md).

### Reference links for classes used in the code

- [ResourceManagementClient (azure.mgmt.resource)](/python/api/azure-mgmt-resource/azure.mgmt.resource.resourcemanagementclient?view=azure-python)
- [WebSiteManagementClient (azure.mgmt.web import)](/python/api/azure-mgmt-web/azure.mgmt.web.websitemanagementclient?view=azure-python)

## 5: Run the script

```cmd
python provision_deploy_web_app.py
```

## 6: Verify the web app deployment

1. Visit the deployed web site by running the following command:

    ```azurecli
    az webapp browse -n PythonAzureExample-WebApp-12345
    ```

    Replace "PythonAzureExample-WebApp-12345" with the specific name of your web app.

    You should see "Hello World!" in the browser.

1. Visit the [Azure portal](https://portal.azure.com), select **Resource groups**, and check that "PythonAzureExample-WebApp-rg" is listed. Then Navigate into that list to verify the expected resources exist, namely the App Service Plan and the App Service.

## 7: Clean up resources

```azurecli
az group delete -n PythonAzureExample-WebApp-rg
```

Run this command if you don't need to keep the resources provisioned in this example and would like to avoid ongoing charges in your subscription.

You can also use the [`ResourceManagementClient.resource_groups.delete`](/python/api/azure-mgmt-resource/azure.mgmt.resource.resources.v2019_10_01.operations.resourcegroupsoperations?view=azure-python#delete-resource-group-name--custom-headers-none--raw-false--polling-true----operation-config-) method to delete a resource group from code.

### For reference: equivalent Azure CLI commands

The following Azure CLI commands complete the same provisioning steps as the Python script:

# [cmd](#tab/cmd)

```azurecli
az group create -l centralus -n PythonAzureExample-WebApp-rg

az appservice plan create -n PythonAzureExample-WebApp-plan --is-linux --sku F1

az webapp create -g PythonAzureExample-WebApp-rg -n PythonAzureExample-WebApp-12345 ^
    --plan PythonAzureExample-WebApp-plan --runtime "python|3.8"

rem You can use --deployment-source-url with the first create command. It's shown here
rem to match the sequence of the Python code.

az webapp create -n PythonAzureExample-WebApp-12345 --plan PythonAzureExample-WebApp-plan ^
    --deployment-source-url https://github.com/<your_fork>/python-docs-hello-world

rem Replace <your_fork> with the specific URL of your forked repository.
```

# [bash](#tab/bash)

```azurecli
az group create -l centralus -n PythonAzureExample-WebApp-rg

az appservice plan create -n PythonAzureExample-WebApp-plan --is-linux --sku F1

az webapp create -g PythonAzureExample-WebApp-rg -n PythonAzureExample-WebApp-12345 \
    --plan PythonAzureExample-WebApp-plan --runtime "python|3.8"

# You can use --deployment-source-url with the first create command. It's shown here
# to match the sequence of the Python code.

az webapp create -n PythonAzureExample-WebApp-12345 --plan PythonAzureExample-WebApp-plan \
    --deployment-source-url https://github.com/<your_fork>/python-docs-hello-world

# Replace <your_fork> with the specific URL of your forked repository.
```

---

## See also

- [Example: Provision a resource group](azure-sdk-example-resource-group.md)
- [Example: Provision Azure Storage](azure-sdk-example-storage.md)
- [Example: Use Azure Storage](azure-sdk-example-storage-use.md)
- [Example: Provision and use a MySQL database](azure-sdk-example-database.md)
- [Example: Provision a virtual machine](azure-sdk-example-virtual-machines.md)
