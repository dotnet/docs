---
title: "IXCLRDataProcess::GetAppDomainByUniqueId Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess::GetAppDomainByUniqueId Method"
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

Gets an `AppDomain` in a process based on its unique identifier.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

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

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 20th slot of the virtual method table. The `IXCLRDataAppDomain*` returned is used for interaction with other APIs.

## Requirements
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See Also
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [IXCLRDataProcess Interface](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-interface.md)
