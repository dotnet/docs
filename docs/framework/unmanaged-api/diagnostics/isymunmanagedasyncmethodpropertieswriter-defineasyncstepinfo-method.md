---
title: "ISymUnmanagedAsyncMethodPropertiesWriter::DefineAsyncStepInfo Method"
ms.date: "03/30/2017"
ms.assetid: f738a6ed-7cd9-4106-a5cd-355481e5771c
author: "rpetrusha"
ms.author: "ronpet"
---
# ISymUnmanagedAsyncMethodPropertiesWriter::DefineAsyncStepInfo Method
Define a group of async await operations in the current method.  
  
 Each yield offset matches an await's return instruction, identifying a potential yield. Each `breakpointMethod`/`breakpointOffset` pair tells us where the asynchronous operation will resume which could be in a different method.  
  
## Syntax  
  
```idl  
HRESULT DefineAsyncStepInfo(    [in] ULONG32 count,    [in, size_is(count)] ULONG32 yieldOffsets[],    [in, size_is(count)] ULONG32 breakpointOffset[],     [in, size_is(count)] mdToken breakpointMethod[]);  
```  
  
## Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|`count`||  
|`yieldOffsets`||  
|`breakpointOffset`||  
|`breakpointMethod`||  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedAsyncMethodPropertiesWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedasyncmethodpropertieswriter-interface.md)
