---
title: "ServicePoint.m_ConnectionGroupList Field"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: ""
ms.topic: "reference"
topic_type: 
  - "apiref"
api_name: 
  - "System.Net.ServicePoint.m_ConnectionGroupList"
api_location: 
  - "System.dll"
api_type: 
  - "Assembly"
ms.assetid: df8afb59-f0f6-4ddc-b3c1-839b9fc601d8
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# ServicePoint.m\_ConnectionGroupList Field

`ServicePoint.m_ConnectionGroupList` is a <xref:System.Collections.Hashtable> of connection groups, each holding a connection for the <xref:System.Net.ServicePoint>'s URI.

## Syntax
  
```csharp  
private Hashtable m_ConnectionGroupList
```

> [!WARNING]
> The `ServicePoint.m_ConnectionGroupList` field is private and not meant to be used directly in your code.
> 
> Microsoft does not support the use of this field in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
