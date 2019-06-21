---
title: Infrastructure As Code
description: Architecting Cloud Native .NET Apps for Azure | Infrastructure As Code
ms.date: 06/30/2019
---

# Infrastructure As Code

Cloud Native Applications tend to make use of all sorts of fantastic Platform as a Service components. On a cloud platform like Azure these components might include things like storage, Service Bus and the SignalR service. As applications become more complicated the number of these services in use is likely to grow. Just as how continuous delivery broke the traditional model of deploying to an environment manually the rapid pace of change also broke the model of having a centralized IT group manage environments.

Building environments can, and should, also be automated. There is a wide range of very well thought out tools which can make the process easy.

## Azure Resource Manager Templates

Also known as ARM Template, Azure Resource Manager Templates are a JSON-based language for defining various resources in Azure. The basic schema looks something like Figure 11-10.

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

**Figure 11-10** - The schema for an ARM template

Within this template one might define a storage container inside the resources section like so
 
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

**Figure 11-11** - An example of a storage account defined in an ARM template

The templates can be parameterized so that one template can be reused with different settings to define develop, QA and production environments. This helps eliminate surprises when migrating to a higher environment that is set up differently from the lower environments. The resources defined in a template are typically all created within a single resource group on Azure (it is possible to define multiple resource groups in a single ARM template but unusual). This makes it very easy to delete an environment by simply deleting the resource group as a whole. Cost analysis can also be run at the resource group level allowing for quick accounting of how much each environment is costing.

There are many example templates defined in the [Azure Quickstart Templates](https://github.com/Azure/azure-quickstart-templates) project on GitHub which will give a leg up when starting on a new template or adding to an existing one.

ARM templates can be run in a variety of ways. Perhaps the simplest way is to simply paste them into the Azure Portal. For experimental deployments this can be very quick. They can also be run as part of a build or release process in Azure DevOps. There are tasks which will leverage connections into Azure to run the templates. Changes to ARM templates are applied incrementally meaning that to add a new resource requires just adding it to the template. The tooling will handle diffing the current resource group with the desired resource group defined in the template. Resources will then be created or altered so they match what is defined in the template.  

## Terraform

A perceived disadvantage of ARM templates is that they are specific to the Azure cloud. It is quite unusual to create applications which include resources from more than one cloud but in cases where the business relies on spectacular uptime the cost of supporting multiple clouds might be worthwhile. If there were one templating language which could be used across every cloud then it would also allow for developer skills to be much more portable.

Several technologies exist which do just that! The most mature offering in that space is known as [Terraform](https://www.terraform.io/). It supports every major cloud player from Azure to GCP to AWS to AliCloud as well as literally dozens of minor players such as Heroku and DigitalOcean. Instead of using JSON as the template definition language it makes use of the slightly more terse YAML. 

An example Terraform file which performs the same as the previous ARM template (Figure 11-11) is shown in Figure 11-12

```json
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

**Figure 11-12** - An example ARM template

Terraform does a better job of providing sensible error messages when a resource cannot be deployed due to an error in the template. This is an area where ARM templates have some ongoing challenges. There is also a very handy validate task which can be used in the build phase to catch template errors early.

Just as with ARM templates there are command line tools which can be used to deploy Terraform templates. Of course, there are also community created tasks in Azure pipelines which can validate and apply Terraform templates.

In the event that the Terraform or ARM template outputs interesting values such as the connection string to a newly created database they can be captured in the build pipeline and used in subsequent tasks.

>[!div class="step-by-step"]
>[Previous](cloud-native-devops.md)
>[Next](cloud-native-application-bundles.md)

