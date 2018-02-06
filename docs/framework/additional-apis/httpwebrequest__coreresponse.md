---
title: "HttpWebRequest._CoreResponse Field"
ms.date: "01/29/2018"
ms.prod: ".net-framework"
ms.technology: ""
ms.topic: "reference"
topic_type: 
  - "apiref"
api_name: 
  - "System.Net.HttpWebRequest._CoreResponse"
api_location: 
  - "System.dll"
api_type: 
  - "Assembly"
author: "stevewhims"
ms.author: "stwhi"
manager: "markl"
ms.workload: 
  - "dotnet"
---

# HttpWebRequest.\_CoreResponse Field

`HttpWebRequest._CoreResponse` is an object (either a [CoreResponseData](coreresponsedata.md) or an <xref:System.Exception>) containing the result of HTTP response parsing.

## Syntax
  
```csharp
private object _CoreResponse
```

> [!WARNING]
> This API is not meant to be used directly in your code. Instead, you should use a <xref:System.Diagnostics.DiagnosticSource> to hook networking code. See [DiagnosticSource User's Guide](https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md).
> 
> Microsoft does not support the use of this class in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
