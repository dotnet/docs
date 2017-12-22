---
title: "ISymUnmanagedReader::GetSymbolStoreFileName Method"
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
  - "ISymUnmanagedReader.GetSymbolStoreFileName"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetSymbolStoreFileName"
helpviewer_keywords: 
  - "GetSymbolStoreFileName method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetSymbolStoreFileName method [.NET Framework debugging]"
ms.assetid: c84f4846-9bc8-44a4-9a76-e39106d6d8b2
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::GetSymbolStoreFileName Method
Provides the on-disk file name of the symbol store.  
  
## Syntax  
  
```  
HRESULT GetSymbolStoreFileName (  
    [in]  ULONG32 cchName,  
    [out] ULONG32 *pcchName,  
    [out, size_is (cchName),  
        length_is (*pcchName)] WCHAR szName[]);  
```  
  
#### Parameters  
 `cchName`  
 [in] The size of the `szName` buffer.  
  
 `pcchName`  
 [out] A pointer to the variable that receives the length of the name returned in `szName`, including the null termination.  
  
 `szName`  
 [out] A pointer to the variable that receives the file name of the symbol store.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
