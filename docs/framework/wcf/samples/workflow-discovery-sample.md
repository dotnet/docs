---
description: "Learn more about: Workflow Discovery Sample"
title: "Workflow Discovery Sample"
ms.date: "03/30/2017"
ms.assetid: 82cc43f1-3c8f-4771-ac19-a75ac936e2c3
---
# Workflow Discovery Sample

The [WorkflowDiscovery sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to make a workflow service discoverable and how to author a custom code activity that searches for a particular service.

## Demonstrates

Discovery Find Activity and Workflow Usage

## Discussion

In the first part of the sample, a workflow service is made discoverable using configuration. Configuration can also be used to apply the service appropriately with custom metadata (such as scopes). On the client, the sample uses a custom code activity, which uses Discovery to search for a service matching a particular contract. The code activity outputs a URI, which is later used by a send activity.

#### To set up, build, and run the sample

1. This sample uses HTTP endpoints, which must have proper URL ACLs to run (see [Configuring HTTP and HTTPS](../feature-details/configuring-http-and-https.md) for details). Executing the following command at an elevated command prompt should add the appropriate ACLs. If your shell does not understand the variable format, substitute your Domain and Username for the following arguments.

    `netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%`
