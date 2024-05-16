---
title: "CoreResponseData.m_ResponseHeaders Field"
description: Understand the CoreResponseData.m_ResponseHeaders field in .NET. This field is a WebHeaderCollection type that has headers associated with the server response.
ms.date: "01/29/2018"
topic_type: 
  - "apiref"
api_name: 
  - "System.Net.CoreResponseData.m_ResponseHeaders"
api_location: 
  - "System.dll"
api_type: 
  - "Assembly"
author: "stevewhims"
---

# CoreResponseData.m\_ResponseHeaders Field

`CoreResponseData.m_ResponseHeaders` is a <xref:System.Net.WebHeaderCollection> of headers associated with the server response.

## Syntax
  
```csharp
public WebHeaderCollection m_ResponseHeaders
```

> [!WARNING]
> This API is not meant to be used directly in your code. Instead, you should use a <xref:System.Diagnostics.DiagnosticSource> to hook networking code. See [DiagnosticSource User's Guide](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md).
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
