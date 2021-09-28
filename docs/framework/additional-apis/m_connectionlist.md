---
title: "ConnectionGroup.m_ConnectionList Field"
description: Learn about the ConnectionGroup.m_ConnectionList field in .NET, which contains connection objects that serve the same URI and share values for other properties.
ms.date: "05/01/2017"
topic_type: 
  - "apiref"
api_name: 
  - "System.Net.ConnectionGroup.m_ConnectionList"
api_location: 
  - "System.dll"
api_type: 
  - "Assembly"
ms.assetid: 186083cf-8dff-4600-a2ab-6fed4b4de6af
---
# ConnectionGroup.m\_ConnectionList Field

`ConnectionGroup.m_ConnectionList` is an <xref:System.Collections.ArrayList> of connection objects that serves the same URI and share the same values for some other properties like expiration and authentication.

## Syntax
  
```csharp  
private ArrayList m_ConnectionList
```

> [!WARNING]
> The `ConnectionGroup.m_ConnectionList` field is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this field in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
