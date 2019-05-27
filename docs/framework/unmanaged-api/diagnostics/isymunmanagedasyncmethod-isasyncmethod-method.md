---
title: "ISymUnmanagedAsyncMethod::IsAsyncMethod Method"
ms.date: "03/30/2017"
ms.assetid: 670a7653-dac6-4171-98ee-d669e3adf4b2
author: "rpetrusha"
ms.author: "ronpet"
---
# ISymUnmanagedAsyncMethod::IsAsyncMethod Method
Checks if the method has async information or not.  
  
 If this method returns `FALSE` then it is invalid to call any other methods in this interface. They will all return `E_UNEXPECTED` in this case.  
  
## Syntax  
  
```idl  
HRESULT IsAsyncMethod(    [out, retval] BOOL* pRetVal);  
```  
  
## Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|`pRetVal`||  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedAsyncMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedasyncmethod-interface.md)
