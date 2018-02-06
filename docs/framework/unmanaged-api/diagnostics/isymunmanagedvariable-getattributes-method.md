---
title: "ISymUnmanagedVariable::GetAttributes Method"
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
  - "ISymUnmanagedVariable.GetAttributes"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetAttributes"
helpviewer_keywords: 
  - "GetAttributes method [.NET Framework debugging]"
  - "ISymUnmanagedVariable::GetAttributes method [.NET Framework debugging]"
ms.assetid: 80f168af-a6a6-4c8f-b9e6-8a82dc834ed5
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedVariable::GetAttributes Method
Gets the attribute flags for this variable.  
  
## Syntax  
  
```  
HRESULT GetAttributes(  
    [out, retval] ULONG32* pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the attributes. The returned value will be one of the values defined in the [CorSymVarFlag](../../../../docs/framework/unmanaged-api/diagnostics/corsymvarflag-enumeration.md) enumeration.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedVariable Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-interface.md)
