---
title: "ISymUnmanagedWriter4::GetDebugInfoWithPadding Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 881e20ca-8131-4bd0-ba41-c2d6391b0fe2
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter4::GetDebugInfoWithPadding Method
Functions the same as [GetDebugInfo Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-getdebuginfo-method.md) except that the path string is padded with zeros following the terminating null character to make the string data a fixed size of `MAX_PATH`. Padding is only given if the path string length itself is less than `MAX_PATH`.  
  
 This makes it easier to write tools that difference PE files.  
  
## Syntax  
  
```idl  
HRESULT GetDebugInfoWithPadding(    [in, out] IMAGE_DEBUG_DIRECTORY *pIDD,    [in] DWORD cData,    [out] DWORD *pcData,    [out, size_is(cData), length_is(*pcData)] BYTE data[]);  
```  
  
#### Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|`pIDD`||  
|`cData`||  
|`pcData`||  
|`data`||  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter4 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter4-interface.md)
