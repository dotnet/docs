---
title: Using F# on Azure
description: Guide to using Azure services with F#
author: sylvanc
ms.date: 07/29/2020
ms.custom: "devx-track-fsharp"
---

# Using F# on Azure

F# is a superb language for cloud programming and is frequently used to write web applications, cloud services, cloud-hosted microservices, and for scalable data processing.

In the following sections, you will find resources on how to use a range of Azure services with F#.

> [!NOTE]
> If a particular Azure service isn't in this documentation set, please consult either the Azure Functions or .NET documentation for that service. Some Azure services are language-independent and require no language-specific documentation and are not listed here.

## Using Azure Virtual Machines with F\#

Azure supports a wide range of virtual machine (VM) configurations, see [Linux and Azure Virtual Machines](https://azure.microsoft.com/services/virtual-machines/).

To install F# on a virtual machine for execution, compilation and/or scripting see [Using F# on Linux](https://fsharp.org/use/linux) and [Using F# on Windows](https://fsharp.org/use/windows).

## Using Azure Functions with F\#

[Azure Functions](https://azure.microsoft.com/services/functions/) is a solution for easily running small pieces of code, or "functions," in the cloud. You can write just the code you need for the problem at hand, without worrying about a whole application or the infrastructure to run it. Your functions are connected to events in Azure storage and other cloud-hosted resources. Data flows into your F# functions via function arguments. You can use your development language of choice, trusting Azure to scale as needed.

Azure Functions support F# as a first-class language with efficient, reactive, scalable execution of F# code. See the [Azure Functions F# Developer Reference](/azure/azure-functions/functions-reference-fsharp) for reference documentation on how to use F# with Azure Functions.

Other resources for using Azure Functions and F#:

* [Scale Up Azure Functions in F# Using Suave](https://blog.tamizhvendan.in/blog/2016/09/19/scale-up-azure-functions-in-f-number-using-suave/)
* [How to create Azure function in F#](https://www.mnie.me/azurefunctions)
* [Using the Azure Type Provider with Azure Functions](https://compositional-it.com/blog/2017/08-30-using-the-azure-type-provider-with-azure-functions/index.html)

## Using Azure Storage with F\#

Azure Storage is a base layer of storage services for modern applications that rely on durability, availability, and scalability to meet the needs of customers. F# programs can interact directly with Azure storage services, using the techniques described in the following articles.

* [Get started with Azure Blob Storage using F#](blob-storage.md)
* [Get started with Azure File Storage using F#](file-storage.md)
* [Get started with Azure Queue Storage using F#](queue-storage.md)
* [Get started with Azure Table Storage using F#](table-storage.md)

Azure Storage can also be used in conjunction with Azure Functions through declarative configuration rather than explicit API calls. See [Azure Functions triggers and bindings for Azure Storage](/azure/azure-functions/functions-bindings-storage) which includes F# examples.

## Using Azure App Service with F\#

[Azure App Service](https://azure.microsoft.com/services/app-service/) is a cloud platform to build powerful web and mobile apps that connect to data anywhere, in the cloud or on-premises.

* [F# Azure Web API example](https://github.com/fsprojects/azure-webapi-example)
* [Hosting F# in a web application on Azure](https://github.com/isaacabraham/fsharp-demonstrator)

## Using Apache Spark with F# on Azure HDInsight or Azure Databricks

[Apache Spark for Azure HDInsight](/azure/hdinsight/spark/apache-spark-overview) is an open source processing framework that runs large-scale data analytics applications. [Azure Databricks](/azure/databricks/scenarios/what-is-azure-databricks) is an Apache Spark-based analytics platform optimized for the Microsoft Azure cloud services platform. Azure makes Apache Spark easy and cost effective to deploy. Develop your Spark application in F# using [.NET for Apache Spark](../../spark/what-is-apache-spark-dotnet.md), a set of .NET bindings for Apache Spark.

* [.NET for Apache Spark F# samples](https://github.com/dotnet/spark/tree/main/examples/Microsoft.Spark.FSharp.Examples)
* [Install .NET Interactive Jupyter notebooks in Azure HDInsight](../../spark/how-to-guides/hdinsight-notebook-installation.md)
* [Submit Apache Spark jobs to Azure HDInsight](../../spark/how-to-guides/hdinsight-deploy-methods.md)
* [Submit Apache Spark jobs to Azure Databricks](../../spark/how-to-guides/databricks-deploy-methods.md)

## Using Azure Cosmos DB with F\#

[Azure Cosmos DB](https://azure.microsoft.com/services/cosmos-db) is a NoSQL service for highly available, globally distributed apps.

Azure Cosmos DB can be used with F# in two ways:

1. Through the creation of F# Azure Functions which react to or cause changes to Azure Cosmos DB collections. See [Azure Cosmos DB bindings for Azure Functions](/azure/azure-functions/functions-bindings-cosmosdb), or
2. By using the [Azure Cosmos DB .NET SDK for SQL API](/azure/cosmos-db/sql-api-sdk-dotnet). The related samples are in C#.

## Using Azure Event Hubs with F\#

[Azure Event Hubs](https://azure.microsoft.com/services/event-hubs/) provide cloud-scale telemetry ingestion from websites, apps, and devices.

Azure Event Hubs can be used with F# in two ways:

1. Through the creation of F# Azure Functions which are triggered by events. See [Azure Function triggers for Event Hubs](/azure/azure-functions/functions-bindings-event-hubs), or
2. By using the [.NET SDK for Azure](/azure/event-hubs/event-hubs-csharp-ephcs-getstarted). Note these examples are in C#.

## Using Azure Notification Hubs with F\#

[Azure Notification Hubs](/azure/notification-hubs/) are multiplatform, scaled-out push infrastructure that enable you to send mobile push notifications from any backend (in the cloud or on-premises) to any mobile platform.

Azure Notification Hubs can be used with F# in two ways:

1. Through the creation of F# Azure Functions which send results to a notification hub. See [Azure Function output triggers for Notification Hubs](/azure/azure-functions/functions-bindings-notification-hubs), or
2. By using the [.NET SDK for Azure](/archive/blogs/azuremobile/push-notifications-using-notification-hub-and-net-backend). Note these examples are in C#.

## Implementing WebHooks on Azure with F\#

A [Webhook](https://en.wikipedia.org/wiki/Webhook) is a callback triggered via a web request. Webhooks are used by sites such as GitHub to signal events.

Webhooks can be implemented in F# and hosted on Azure via an [Azure Function in F# with a Webhook Binding](/azure/azure-functions/functions-bindings-http-webhook).

## Using Webjobs with F\#

[Webjobs](/azure/app-service-web/web-sites-create-web-jobs) are programs you can run in your App Service web app in three ways: on demand, continuously, or on a schedule.

[Example F# Webjob](https://github.com/jrr/webjob-project-examples)

## Implementing Timers on Azure with F\#

Timer triggers call functions based on a schedule, one time or recurring.

Timers can be implemented in F# and hosted on Azure via an [Azure Function in F# with a Timer Trigger](/azure/azure-functions/functions-bindings-timer).

## Deploying and Managing Azure Resources with F# Scripts

Azure VMs may be programmatically deployed and managed from F# scripts by using the Microsoft.Azure.Management packages and APIs. For example, see [Get Started with the Management Libraries for .NET](/previous-versions/azure/dn722415(v=azure.100)) and [Using Azure Resource Manager](/azure/azure-resource-manager/resource-manager-deployment-model).

Likewise, other Azure resources may also be deployed and managed from F# scripts using the same components. For example, you can create storage accounts, deploy Azure Cloud Services, create Azure Cosmos DB instances and manage Azure Notification Hubs programmatically from F# scripts.

Using F# scripts to deploy and manage resources is not normally necessary. For example, Azure resources may also be deployed directly from JSON template descriptions, which can be parameterized. See [Azure Resource Manager Templates](/azure/azure-resource-manager/resource-manager-template-best-practices) including examples such as the [Azure Quickstart Templates](https://azure.microsoft.com/resources/templates/).

## Other resources

* [Full documentation on all Azure services](/azure/)
