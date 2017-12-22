---
title: "ISymUnmanagedBinder::GetReaderForFile Method"
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
  - "ISymUnmanagedBinder.GetReaderForFile"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedBinder::GetReaderForFile"
helpviewer_keywords: 
  - "ISymUnmanagedBinder::GetReaderForFile method [.NET Framework debugging]"
  - "GetReaderForFile method [.NET Framework debugging]"
ms.assetid: 46c06258-831e-47c8-a50a-8650af6b637e
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedBinder::GetReaderForFile Method
Given a metadata interface and a file name, returns the correct <<!--zz xref:ISymUnmanagedReader --> `ISymUnmanagedReader`> structure that will read the debugging symbols associated with the module.  
  
 This method will open the program database (PDB) file only if it is next to the executable file. This change has been made for security purposes. If you need a more extensive search for the PDB file, use the [ISymUnmanagedBinder2::GetReaderForFile2](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder2-getreaderforfile2-method.md) method.  
  
## Syntax  
  
```  
HRESULT GetReaderForFile(  
    [in]  IUnknown     *importer,  
    [in]  const WCHAR  *fileName,  
    [in]  const WCHAR  *searchPath,  
    [out, retval] ISymUnmanagedReader  **pRetVal);  
```  
  
#### Parameters  
 `importer`  
 [in] A pointer to the metadata import interface.  
  
 `fileName`  
 [in] A pointer to the file name.  
  
 `searchPath`  
 [in] A pointer to the search path.  
  
 `pRetVal`  
 [out] A pointer that is set to the returned <<!--zz xref:ISymUnmanagedReader --> `ISymUnmanagedReader`> interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedBinder Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder-interface.md)  
 [GetReaderForFile2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder2-getreaderforfile2-method.md)
