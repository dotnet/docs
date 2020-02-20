---
title: "ISymUnmanagedAsyncMethodPropertiesWriter::DefineKickoffMethod Method"
ms.date: "03/30/2017"
ms.assetid: 4662f70d-817b-4374-8da8-e0545585939f
---
# ISymUnmanagedAsyncMethodPropertiesWriter::DefineKickoffMethod Method
Sets the starting method that initiates the async operation.  
  
## Syntax  
  
```idl  
HRESULT DefineKickoffMethod(    [in] mdToken kickoffMethod);  
```  
  
## Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|`kickoffMethod`||  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedAsyncMethodPropertiesWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedasyncmethodpropertieswriter-interface.md)
