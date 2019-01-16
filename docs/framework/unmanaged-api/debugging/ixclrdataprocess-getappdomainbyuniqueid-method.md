---
title: "IXCLRDataProcess::GetAppDomainByUniqueId Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataProcess::GetAppDomainByUniqueId"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::GetAppDomainByUniqueId Method"
helpviewer.keywords:
  - "IXCLRDataProcess::GetAppDomainByUniqueId Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::GetAppDomainByUniqueId Method
Get the AppDomain by its unique id.

## Syntax
```
HRESULT GetAppDomainByUniqueID(
    [in] ULONG64               id,
    [out] IXCLRDataAppDomain **appDomain
);
```

### Parameters
`id`
[in] The unique identifier of the AppDomain

`appDomain`
[out] The AppDomain
