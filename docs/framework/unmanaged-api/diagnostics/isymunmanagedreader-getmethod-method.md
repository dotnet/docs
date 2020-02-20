---
title: "ISymUnmanagedReader::GetMethod Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetMethod"
helpviewer_keywords: 
  - "GetMethod method, ISymUnmanagedReader interface [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetMethod method [.NET Framework debugging]"
ms.assetid: ae6cfb29-bc2c-4606-af86-1d32ebd31020
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader::GetMethod Method
Gets a symbol reader method, given a method token.  
  
## Syntax  
  
```cpp  
HRESULT GetMethod (  
    [in]  mdMethodDef  token,  
    [out, retval] ISymUnmanagedMethod**  pRetVal);  
```  
  
## Parameters  
 `token`  
 [in] The method token.  
  
 `pRetVal`  
 [out] A pointer to the returned interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
