---
title: "ISymUnmanagedAsyncMethod::IsAsyncMethod Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 670a7653-dac6-4171-98ee-d669e3adf4b2
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedAsyncMethod::IsAsyncMethod Method
Checks if the method has async information or not.  
  
 If this method returns `FALSE` then it is invalid to call any other methods in this interface. They will all return `E_UNEXPECTED` in this case.  
  
## Syntax  
  
```idl  
HRESULT IsAsyncMethod(    [out, retval] BOOL* pRetVal);  
```  
  
#### Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|`pRetVal`||  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedAsyncMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedasyncmethod-interface.md)
