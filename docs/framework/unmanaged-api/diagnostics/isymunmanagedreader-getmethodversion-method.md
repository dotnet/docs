---
title: "ISymUnmanagedReader::GetMethodVersion Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetMethodVersion"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetMethodVersion"
helpviewer_keywords: 
  - "GetMethodVersion method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetMethodVersion method [.NET Framework debugging]"
ms.assetid: d6f9ac84-302a-4f5e-b990-e76f4269fceb
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedReader::GetMethodVersion Method
Gets the method version. The method version starts at 1 and is incremented each time the method is recompiled. Recompilation can happen without changes to the method.  
  
## Syntax  
  
```  
HRESULT GetMethodVersion (  
    [in]  ISymUnmanagedMethod* pMethod,  
    [out] int* version);  
```  
  
#### Parameters  
 `pMethod`  
 [in] The method for which to get the version.  
  
 `version`  
 [out] A pointer to a variable that receives the method version.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also
- [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
