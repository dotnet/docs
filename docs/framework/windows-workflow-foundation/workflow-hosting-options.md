---
description: "Learn more about: Workflow Hosting Options"
title: "Workflow Hosting Options"
ms.date: "03/30/2017"
ms.assetid: 37bcd668-9c5c-4e7c-81da-a1f1b3a16514
---
# Workflow Hosting Options

Most of the Windows Workflow Foundation (WF) samples use workflows that are hosted in a console application, but this isn't a realistic scenario for real-world workflows. Workflows in actual business applications will be hosted in persistent processes- either a Windows service authored by the developer, or a server application such as IIS 7.0 or AppFabric. The differences between these approaches are as follows.

## Hosting workflows in IIS with Windows AppFabric

Using IIS with AppFabric is the preferred host for workflows. The host application for workflows using AppFabric is Windows Activation Service, which removes the dependency on HTTP over IIS alone.

## Hosting workflows in IIS alone

Using IIS 7.0 alone is not recommended, as there are management and monitoring tools available with AppFabric that facilitate maintenance of running applications. Workflows should only be hosted in IIS 7.0 alone if there are infrastructure concerns with moving to AppFabric.

> [!WARNING]
> IIS 7.0 recycles application pools periodically for various reasons. When an application pool is recycled, IIS stops accepting messages to the old pool, and instantiates a new application pool to accept new requests. If a workflow continues working after sending a response, IIS 7.0 will not be aware of the work being done, and may recycle the hosting application pool. If this happens, the workflow will abort, and tracking services will record a [1004 - WorkflowInstanceAborted](1004-workflowinstanceaborted.md) message with an empty Reason field.
>
> If persistence is used, the host must explicitly restart aborted instances from the last persistence point.
>
> If AppFabric is used, the workflow management service will eventually resume the workflow from the last successful persistence point if persistence is used. If no persistence is used, and the workflow performs operations outside a Request/Response pattern, data will be lost when the workflow aborts.

## Hosting a workflow in a custom Windows Service

Creating a custom workflow service to host the workflow will require the developer to duplicate a lot of the functionality provided out-of-box by AppFabric, but will allow for more flexibility with custom functionality. This option should only be considered if AppFabric proves to not be an option.
