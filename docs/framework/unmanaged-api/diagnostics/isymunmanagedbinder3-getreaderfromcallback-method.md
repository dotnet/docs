---
title: "ISymUnmanagedBinder3::GetReaderFromCallback Method"
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
  - "ISymUnmanagedBinder3.GetReaderFromCallback"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedBinder3::GetReaderFromCallback"
helpviewer_keywords: 
  - "GetReaderFromCallback method [.NET Framework debugging]"
  - "ISymUnmanagedBinder3::GetReaderFromCallback method [.NET Framework debugging]"
ms.assetid: 4ef83bd2-3d8e-499e-8a12-d9d6fd6ced30
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedBinder3::GetReaderFromCallback Method
Allows the user to implement or supply via callback either an `IID_IDiaReadExeAtRVACallback` or `IID_IDiaReadExeAtOffsetCallback` to obtain the debug directory information from memory.  
  
## Syntax  
  
```  
HRESULT GetReaderFromCallback(  
    [in]  IUnknown     *importer,  
    [in]  const WCHAR  *fileName,  
    [in]  const WCHAR  *searchPath,  
    [in]  ULONG32      searchPolicy,  
    [in]  IUnknown     *callback,  
    [out,retval] ISymUnmanagedReader  **pRetVal);  
```  
  
#### Parameters  
 `importer`  
 [in] A pointer to the metadata import interface.  
  
 `fileName`  
 [in] A pointer to the file name.  
  
 `searchPath`  
 [in] A pointer to the search path.  
  
 `searchPolicy`  
 [in] A value of the [CorSymSearchPolicyAttributes](../../../../docs/framework/unmanaged-api/diagnostics/corsymsearchpolicyattributes-enumeration.md) enumeration that specifies the policy to be used when doing a search for a symbol reader.  
  
 `callback`  
 [in] A pointer to the callback function.  
  
 `pRetVal`  
 [out] A pointer that is set to the returned [ISymUnmanagedReader](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md) interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl  
  
## See Also  
 [ISymUnmanagedBinder3 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder3-interface.md)
