---
title: Infrastructure as code
description: Architecting Cloud Native .NET Apps for Azure | Infrastructure As Code
ms.date: 06/30/2019
---

# Infrastructure as code

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Cloud-native applications tend to make use of all sorts of fantastic platform as a service (PaaS) components. On a cloud platform like Azure, these components might include things like storage, Service Bus, and the SignalR service. As applications become more complicated, the number of these services in use is likely to grow. Just as how continuous delivery broke the traditional model of deploying to an environment manually, the rapid pace of change also broke the model of having a centralized IT group manage environments.

Building environments can, and should, also be automated. There's a wide range of well thought out tools that can make the process easy.

## Azure Resource Manager templates

Azure Resource Manager templates are a JSON-based language for defining various resources in Azure. The basic schema looks something like Figure 11-10.

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

**Figure 11-10** - The schema for a Resource Manager template

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

**Figure 11-11** - An example of a storage account defined in a Resource Manager template

The templates can be parameterized so that one template can be reused with different settings to define development, QA, and production environments. This helps eliminate surprises when migrating to a higher environment that is set up differently from the lower environments. The resources defined in a template are typically all created within a single resource group on Azure (it's possible to define multiple resource groups in a single Resource Manager template but unusual). This makes it very easy to delete an environment by just deleting the resource group as a whole. Cost analysis can also be run at the resource group level, allowing for quick accounting of how much each environment is costing.

There are many example templates defined in the [Azure Quickstart Templates](https://github.com/Azure/azure-quickstart-templates) project on GitHub that will give a leg up when starting on a new template or adding to an existing one.

Resource Manager templates can be run in a variety of ways. Perhaps the simplest way is to simply paste them into the Azure portal. For experimental deployments, this method can be very quick. They can also be run as part of a build or release process in Azure DevOps. There are tasks that will leverage connections into Azure to run the templates. Changes to Resource Manager templates are applied incrementally, meaning that to add a new resource requires just adding it to the template. The tooling will handle diffing the current resource group with the desired resource group defined in the template. Resources will then be created or altered so they match what is defined in the template.  

## Terraform

A perceived disadvantage of Resource Manager templates is that they are specific to the Azure cloud. It's unusual to create applications that include resources from more than one cloud, but in cases where the business relies on spectacular uptime, the cost of supporting multiple clouds might be worthwhile. If there were one templating language that could be used across every cloud, then it would also allow for developer skills to be much more portable.

Several technologies exist which do just that! The most mature offering in that space is known as [Terraform](https://www.terraform.io/). Terraform supports every major cloud player such as Azure, Google Cloud Platform, AWS, and AliCloud, and it also supports dozens of minor players such as Heroku and DigitalOcean. Instead of using JSON as the template definition language, it uses the slightly more terse YAML. 

An example Terraform file that does the same as the previous Resource Manager template (Figure 11-11) is shown in Figure 11-12:

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

**Figure 11-12** - An example of a Resource Manager template

Terraform does a better job of providing sensible error messages when a resource can't be deployed because of an error in the template. This is an area where Resource Manager templates have some ongoing challenges. There's also a very handy validate task that can be used in the build phase to catch template errors early.

As with Resource Manager templates, there are command-line tools that can be used to deploy Terraform templates. There are also community-created tasks in Azure Pipelines that can validate and apply Terraform templates.

In the event that the Terraform or Resource Manager template outputs interesting values such as the connection string to a newly created database they can be captured in the build pipeline and used in subsequent tasks.

>[!div class="step-by-step"]
>[Previous](devops.md)
>[Next](application-bundles.md)
