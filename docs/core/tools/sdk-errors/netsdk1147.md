---
title: "NETSDK1147: Missing workload for specified target framework"
description: Missing workload for specified target framework
author: tdykstra
ms.author: tdykstra
ms.topic: error-reference
ms.date: 07/14/2021
f1_keywords:
- NETSDK1147
---
# NETSDK1147: Missing workload for specified target framework

This error is caused by trying to compile a project that requires an optional workload, but you don't have the workload installed. The full error message is similar to the following example:

> NETSDK1147: To build this project, the following workloads must be installed: \<workload ID>
>
> To install these workloads, run the following command: dotnet workload install \<workload ID>

For example, if your project targets `net6.0-android`, you might have to run the [`dotnet workload install`](../dotnet-workload-install.md) command and specify workload ID `android`:

```dotnetcli
dotnet workload install android
```

For more information, see [`dotnet workload install`](../dotnet-workload-install.md).
