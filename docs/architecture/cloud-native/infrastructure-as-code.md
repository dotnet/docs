---
title: Infrastructure as code
description: Architecting Cloud Native .NET Apps for Azure | Infrastructure As Code
ms.date: 05/03/2020
---

# Infrastructure as code

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Cloud-native applications favor platform as a service (PaaS) resources. In the Azure cloud, these services include things like storage, Service Bus, and the SignalR service. As applications become more complex, the number of services they consume will grow. Just as continuous delivery automated the traditional model of manual deployments, Infrastructure as Code (IaC) is evolving how application environments are managed.

Building environments can, and should, also be automated. There's a wide range of well thought out tools that can make the process easy.

## Azure Resource Manager templates

ARM stands for Azure Resource Manager. It's an API provisioning engine that is built into Azure and exposed as an API service. ARM enables you to deploy, update, delete, and manage the resources contained in Azure resource group in a single, coordinated operation. You provide the engine with a JSON-based template that specifies the resources you require and their configuration. ARM automatically orchestrates the deployment in the correct order respecting dependencies. The engine ensures idempotency. If a desired resource already exists with the same configuration, provisioning will be ignored.

Azure Resource Manager templates are a JSON-based language for defining various resources in Azure. The basic schema looks something like Figure 11-14.

```json
{
  "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
  "contentVersion": "",
  "apiProfile": "",
  "parameters": {  },
  "variables": {  },
  "functions": [  ],
  "resources": [  ],
  "outputs": {  }
}
```

**Figure 11-14** - The schema for a Resource Manager template

Within this template, one might define a storage container inside the resources section like so:

```json
"resources": [
    {
      "type": "Microsoft.Storage/storageAccounts",
      "name": "[variables('storageAccountName')]",
      "location": "[parameters('location')]",
      "apiVersion": "2018-07-01",
      "sku": {
        "name": "[parameters('storageAccountType')]"
      },
      "kind": "StorageV2",
      "properties": {}
    }
  ],
```

**Figure 11-15** - An example of a storage account defined in a Resource Manager template

An ARM template can be parameterized with dynamic environment and configuration information. Doing so enables it to be reused to define different environments, such as development, QA, or production. Normally, the template creates all resources within a single Azure resource group. It's possible to define multiple resource groups in a single Resource Manager template, if needed. You can delete all resources in an environment by deleting the resource group itself. Cost analysis can also be run at the resource group level, allowing for quick accounting of how much each environment is costing.

There are many examples or ARM templates available in the [Azure Quickstart Templates](https://github.com/Azure/azure-quickstart-templates) project on GitHub. They can help accelerate creating a new template or modifying an existing one.

Resource Manager templates can be run in many of ways. Perhaps the simplest way is to simply paste them into the Azure portal. For experimental deployments, this method can be quick. They can also be run as part of a build or release process in Azure DevOps. There are tasks that will leverage connections into Azure to run the templates. Changes to Resource Manager templates are applied incrementally, meaning that to add a new resource requires just adding it to the template. The tooling will reconcile differences between the current resources and those defined in the template. Resources will then be created or altered so they match what is defined in the template.  

## Terraform

A disadvantage of ARM templates is that they're specific to the Azure cloud. It's not common to create a single application that includes resources from more than one cloud. But, when spectacular uptime is required, the cost of supporting multiple clouds might be justified. If only there were a single templating tool that could be used across every major cloud platform?

Several technologies exist which do just that! The most mature offering in that space is known as [Terraform](https://www.terraform.io/). Terraform supports every major cloud player, including Azure, Google Cloud Platform, AWS, and AliCloud. Instead of using JSON as the template definition language, it uses the slightly more terse YAML.

An example Terraform file that does the same as the previous Resource Manager template (Figure 11-15) is shown in Figure 11-16:

```terraform
provider "azurerm" {
  version = "=1.28.0"
}

resource "azurerm_resource_group" "test" {
  name     = "production"
  location = "West US"
}

resource "azurerm_storage_account" "testsa" {
  name                     = "${var.storageAccountName}"
  resource_group_name      = "${azurerm_resource_group.testrg.name}"
  location                 = "${var.region}"
  account_tier             = "${var.tier}"
  account_replication_type = "${var.replicationType}"

}
```

**Figure 11-16** - An example of a Resource Manager template

Terraform also provides more sensible error messages for problem templates. There's even a handy validate task that can be used in the build phase to catch template errors early. Errors with ARM can be challenging to understand.

As with Resource Manager templates, command-line tools are available to deploy Terraform templates. There are also community-created tasks in Azure Pipelines that can validate and apply Terraform templates.

Sometimes Terraform and ARM templates output meaningful values, such as a connection string to a newly created database. This information can be captured in the build pipeline and used in subsequent tasks.

## Azure CLI Scripts and Tasks

Finally, you could leverage Azure CLI scripts to script your application environment. Scripts can be created, found, and shared to provision and configure almost any Azure resource. The CLI is simple to use with a gentle learning curve. Scripts are executed within either PowerShell or Bash. They're also straightforward to debug, especially when compared with ARM templates.

Azure CLI scripts work well when you need to tear down and redeploy your infrastructure. Updating an existing environment is another story. To start, many CLI commands aren't idempotent. That means they'll recreate the resource each time they're run, even if the resource already exists. It's always possible to add code that checks for the existence of each resource before creating it. But, doing so, your script can become bloated and difficult to manage.

These scripts can also be embedded in Azure DevOps pipelines as `Azure CLI tasks`. Executing the pipeline invokes the script.

Figure 11-17 shows a YAML snippet that lists the version of Azure CLI and the details of the subscription. Note how Azure CLI commands are included in an inline script.

```yaml
- task: AzureCLI@2
  displayName: Azure CLI
  inputs:
    azureSubscription: <Name of the Azure Resource Manager service connection>
    scriptType: ps
    scriptLocation: inlineScript
    inlineScript: |
      az --version
      az account show
```

**Figure 11-17** - Azure CLI script

>[!div class="step-by-step"]
>[Previous](feature-flags.md)
>[Next](application-bundles.md)
