---
title: "ServicePointManager.s_ServicePointTable Field"
description: Read about the ServicePointManager.s_ServicePointTable field in .NET. This hash table field contains active HTTP connections (ServicePoints) in the AppDomain.
ms.date: "05/01/2017"
topic_type: 
  - "apiref"
api_name: 
  - "System.Net.ServicePointManager.s_ServicePointTable"
api_location: 
  - "System.dll"
api_type: 
  - "Assembly"
ms.assetid: 24459679-291c-401a-9def-e42b29466fcf
---
# ServicePointManager.s\_ServicePointTable Field

`ServicePointManager.s_ServicePointTable` is a <xref:System.Collections.Hashtable> that contains the list of active HTTP connections (<xref:System.Net.ServicePoint>s) in the <xref:System.AppDomain>.

## Syntax
  
```csharp  
private static Hashtable s_ServicePointTable
```

> [!WARNING]
> The `ServicePointManager.s_ServicePointTable` field is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this field in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
