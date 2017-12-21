---
title: "Connection.m_WriteList Field"
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.technology: ""
ms.topic: "reference"
topic_type: 
  - "apiref"
api_name: 
  - "System.Net.Connection.m_WriteList"
api_location: 
  - "System.dll"
api_type: 
  - "Assembly"
ms.assetid: 235503c1-1d01-4f59-895f-ae2cf15b3345
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Connection.m\_WriteList Field

`Connection.m_WriteList` is an <xref:System.Collections.ArrayList> of <xref:System.Net.HttpWebRequest> objects that are queued up to be sent over HTTP.

## Syntax
  
```csharp  
private ArrayList m_WriteList
```

> [!WARNING]
> The `Connection.m_WriteList` field is private and not meant to be used directly in your code.
> 
> Microsoft does not support the use of this field in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
