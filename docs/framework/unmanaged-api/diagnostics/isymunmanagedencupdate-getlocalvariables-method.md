---
title: "ISymUnmanagedENCUpdate::GetLocalVariables Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ISymUnmanagedENCUpdate.GetLocalVariables"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate::GetLocalVariables"
helpviewer_keywords: 
  - "ISymUnmanagedENCUpdate::GetLocalVariables method [.NET Framework debugging]"
  - "GetLocalVariables method [.NET Framework debugging]"
ms.assetid: 5c8840be-ffea-447f-9c8d-178f1eaf8d06
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedENCUpdate::GetLocalVariables Method
Gets the local variables.  
  
## Syntax  
  
```  
HRESULT GetLocalVariables(  
    [in]  mdMethodDef  mdMethodToken,  
    [in]  ULONG        cLocals,  
    [out, size_is(cLocals), length_is(*pceltFetched)]  
        ISymUnmanagedVariable *rgLocals[],  
    [out] ULONG        *pceltFetched);  
```  
  
#### Parameters  
 `mdMethodToken`  
 [in] The metadata token of the method.  
  
 `cLocals`  
 [in] A `ULONG` that indicates the size of the `rgLocals` parameter.  
  
 `rgLocals`  
 [out] The returned array of <!--zz<xref:ISymUnmanagedVariable>--> `ISymUnmanagedVariable`  instances.  
  
 `pceltFetched`  
 [out] A pointer to a `ULONG` that receives the size of the `rgLocals` buffer required to contain the locals.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedENCUpdate Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedencupdate-interface.md)
