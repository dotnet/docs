---
title: "ISymUnmanagedENCUpdate::UpdateMethodLines Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ISymUnmanagedENCUpdate.UpdateMethodLines"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate::UpdateMethodLines"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "UpdateMethodLines method [.NET Framework debugging]"
  - "ISymUnmanagedENCUpdate::UpdateMethodLines method [.NET Framework debugging]"
ms.assetid: 275ef87b-0b53-49f9-af6b-58506335dc06
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedENCUpdate::UpdateMethodLines Method
Allows updating the line information for a method that has not been recompiled, but whose lines have moved independently. A delta for each statement is allowed.  
  
## Syntax  
  
```  
HRESULT UpdateMethodLines(  
    [in]  mdMethodDef  mdMethodToken,  
    [in, size_is(cDeltas)] INT32*  pDeltas,  
    [in]  ULONG        cDeltas);  
```  
  
#### Parameters  
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
  
## See Also  
 [ISymUnmanagedENCUpdate Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedencupdate-interface.md)