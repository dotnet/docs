---
title: Azure Functions | Serverless apps. Architecture, patterns, and Azure implementation.
description: Azure functions provide serverless capabilities across multiple languages (C#, JavaScript, Java, and more) and platforms to provide event-driver instant scale code.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 4/4/2018
ms.prod: .net
ms.technology: dotnet
ms.topic: article
---
# Azure Functions

Azure functions provide a serverless compute experience. A function is invoked by a *trigger* (such as access to an HTTP endpoint or a timer) and executes a block of code or business logic. Functions also support specialized *bindings* that connect to resources like storage and queues.

![Azure functions logo](./media/azure-functions/azure-functions-logo.png)

There are two versions of the Azure Functions framework. The legacy version supports the full .NET Framework and the new runtime supports cross-platform .NET Core applications. Additional languages besides C# such as JavaScript, F#, and Java are supported. Functions created in the portal provide a rich scripting syntax. Functions created as standalone projects can be deployed with full platform support and capabilities.

For more information, see: [Azure Functions documentation](/azure/azure-functions).

## Functions v1 vs. v2

There are two versions of the Azure Functions runtime: 1.x and 2.x. Version 1.x is generally available. It supports .NET development from the portal or Windows machines and uses the .NET Framework. 1.x supports C#, JavaScript, and F#, with experimental support for Python, PHP, TypeScript, Batch, Bash, and PowerShell.

Version 2.x is in preview. It leverages .NET Core and supports cross-platform development on Windows, macOS, and Linux machines. 2.x adds first-class support for Java but does not yet directly support any of the experimental languages. Version 2.x uses a new binding extensibility model that enables third-party extensions to the platform, independent versioning of bindings, and a more streamlined execution environment.

> **There is a known issue in 1.x with [binding redirect support](https://github.com/Azure/azure-functions-host/issues/992).** The issue is specific to .NET development. Projects with dependencies on libraries that are a different version from the libraries included in the runtime are impacted. The functions team has committed to make concrete progress on the problem. The team will address binding redirects in 2.x before it goes into general availability.

For more information, see: [Compare 1.x and 2.x](/azure/azure-functions/functions-versions).

## Programming language support

The following languages are supported either in general availability, preview, or experimental.

|Language      |1.x         |2.x      |
|--------------|------------|---------|
|**C#**        |GA          |Preview  |
|**JavaScript**|GA          |Preview  |
|**F#**        |GA          |         |
|**Java**      |            |Preview  |
|**Python**    |Experimental|         |
|**PHP**       |Experimental|         |
|**TypeScript**|Experimental|         |
|**Batch**     |Experimental|         |
|**Bash**      |Experimental|         |
|**PowerShell**|Experimental|         |

For more information, see: [Supported languages](/azure/azure-functions/supported-languages).

## App service plans

Functions are backed by an *app service plan*. The plan defines the resources used by the functions app. You can assign plans to a region, determine the size and number of virtual machines that will be used, and pick a pricing tier. For a true serverless approach, function apps may use the **consumption** plan. The consumption plan will scale the backend automatically based on load.

For more information, see: [App service plans](/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview).

## Create your first function

There are three common ways you can create function apps.

* Script functions in the portal.
* Create the necessary resources using the Azure Command Line Interface (CLI).
* Build functions locally using your favorite IDE and publish them to Azure.

For more information on creating a scripted function in the portal, see: [Create your first function in the Azure portal](/azure/azure-functions/functions-create-first-azure-function).

To build from the Azure CLI, see: [Create your first function using the Azure CLI](/azure/azure-functions/functions-create-first-azure-function-azure-cli).

To create a function from Visual Studio, see: [Create your first function using Visual Studio](/azure/azure-functions/functions-create-your-first-function-visual-studio).

## Understand triggers and bindings

Functions are invoked by a *trigger* and can have exactly one. In addition to invoking the function, certain triggers also serve as bindings. You may also define multiple bindings in addition to the trigger. *Bindings* provide a declarative way to connect data to your code. They can be passed in (input) or receive data (output). Triggers and bindings make functions easy to work with. Bindings remove the overhead of manually creating database or file system connections. All of the information needed for the bindings is contained in a special `functions.json` file for scripts or declared with attributes in code.

Some common triggers include:

* Blob Storage: invoke your function when a file or folder is uploaded or changed in storage
* HTTP: invoke your function like a REST API
* Queue: invoke your function when items exist in a queue
* Timer: invoke your function on a regular cadence

Examples of bindings include:

* CosmosDB: easily connect to the database to load or save files
* Table Storage: work with key/value storage from your function app
* Queue Storage: easily retrieve items from a queue, or place new items on the queue

The following example `functions.json` file defines a trigger and a binding.

```json
{
  "bindings": [
    {
      "name": "myBlob",
      "type": "blobTrigger",
      "direction": "in",
      "path": "images/{name}",
      "connection": "AzureWebJobsStorage"
    },
    {
      "name": "$return",
      "type": "queue",
      "direction": "out",
      "queueName": "images",
      "connection": "AzureWebJobsStorage"
    }
  ],
  "disabled": false
}
```

In this example, the function is triggered by a change to blob storage in the `images` container. The information for the file is passed in, so the trigger also acts as a binding. Another binding exists to put information onto a queue named `images`.

Here is the C# script for the function.

```csharp
public static string Run(Stream myBlob, string name, TraceWriter log)
{
    log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
    return name;
}
```

The example is a simple function that takes the name of the file modified or uploaded to blob storage, and places it on a queue for later processing.

For a full list of triggers and bindings, see: [Azure Functions triggers and bindings concepts](/azure/azure-functions/functions-triggers-bindings).

## Proxies

Proxies provide redirect functionality for your application. Proxies expose an endpoint and map that endpoint to another resource. With proxies you can:

* Reroute an incoming request to another endpoint
* Modify the incoming request before it is passed along
* Modify or provide a response

Proxies are used for scenarios such as:

* Simplifying, shortening, or changing the URL
* Providing a consistent API prefix to multiple backend services
* Mocking a response to an endpoint being developed
* Providing a static response to well-known endpoint
* Keeping an API endpoint consistent while the backend is moved or migrated

Proxies are stored as JSON definitions. Here is an example:

```json
{
  "$schema": "http://json.schemastore.org/proxies",
  "proxies": {
    "Domain Redirect": {
      "matchCondition": {
        "route": "/{shortUrl}"
      },
      "backendUri": "http://%WEBSITE_HOSTNAME%/api/UrlRedirect/{shortUrl}"
    },
    "Root": {
      "matchCondition": {
        "route": "/"
      },
      "responseOverrides": {
        "response.statusCode": "301",
        "response.statusReason": "Moved Permanently",
        "response.headers.location": "https://docs.microsoft.com/"
      }
    }
  }
}
```

The `Domain Redirect` proxy takes a shortened route and maps it to the longer function resource. The transformation looks like:

`https://--shorturl--/123` -> `https://--longurl--.azurewebsites.net/api/UrlRedirect/123`

The `Root` proxy takes anything sent to the root URL (`https://--shorturl--/`) and redirects it to the documentation site.

An example of using proxies is shown in the video [Azure: Bring your app to the cloud with serverless Azure Functions](https://channel9.msdn.com/events/Connect/2017/E102). In real time, an ASP. NET Core application running on local SQL Server is migrated to the Azure Cloud. Proxies are used to help refactor a traditional Web API project to use functions.

For more information about Proxies, see: [Work with Azure Functions Proxies](/azure/azure-functions/functions-proxies).

>[!div class="step-by-step"]
[Previous] (./index.md)
[Next] (./application-insights.md)
