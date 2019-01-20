---
title: "IXCLRDataModule::GetMethodDefinitionByToken Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataModule::GetMethodDefinitionByToken Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::GetMethodDefinitionByToken Method"
helpviewer.keywords:
  - "IXCLRDataModule::GetMethodDefinitionByToken Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataModule::GetMethodDefinitionByToken Method

Gets the method definition corresponding to a given metadata token.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT GetMethodDefinitionByToken(
    [in] mdMethodDef token,
    [out] IXCLRDataMethodDefinition** methodDefinition
);
```

### Parameters

`token`
[in] The method token.

`methodDefinition`
[out] The method definition.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 25th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  
 
## See Also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [IXCLRDataModule Interface](../../../../docs/framework/unmanaged-api/debugging/ixclrdatamodule-interface.md)
