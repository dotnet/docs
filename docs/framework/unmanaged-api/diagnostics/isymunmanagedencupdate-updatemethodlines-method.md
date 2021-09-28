---
description: "Learn more about: ISymUnmanagedENCUpdate::UpdateMethodLines Method"
title: "ISymUnmanagedENCUpdate::UpdateMethodLines Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedENCUpdate.UpdateMethodLines"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate::UpdateMethodLines"
helpviewer_keywords: 
  - "UpdateMethodLines method [.NET Framework debugging]"
  - "ISymUnmanagedENCUpdate::UpdateMethodLines method [.NET Framework debugging]"
ms.assetid: 275ef87b-0b53-49f9-af6b-58506335dc06
topic_type: 
  - "apiref"
---
# ISymUnmanagedENCUpdate::UpdateMethodLines Method

Allows updating the line information for a method that has not been recompiled, but whose lines have moved independently. A delta for each statement is allowed.  
  
## Syntax  
  
```cpp  
HRESULT UpdateMethodLines(  
    [in]  mdMethodDef  mdMethodToken,  
    [in, size_is(cDeltas)] INT32*  pDeltas,  
    [in]  ULONG        cDeltas);  
```  
  
## Parameters  

 `mdMethodToken`  
 [in] The metadata of the method token.  
  
 `pDeltas`  
 [in] An array of `INT32` values that indicates deltas for each sequence point in the method.  
  
 `cDeltas`  
 [in] A `ULONG` containing the size of the `pDeltas` parameter.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedENCUpdate Interface](isymunmanagedencupdate-interface.md)
