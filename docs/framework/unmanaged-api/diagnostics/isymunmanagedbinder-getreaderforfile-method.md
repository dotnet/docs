---
description: "Learn more about: ISymUnmanagedBinder::GetReaderForFile Method"
title: "ISymUnmanagedBinder::GetReaderForFile Method"
ms.date: "03/30/2017"
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
---
# ISymUnmanagedBinder::GetReaderForFile Method

Given a metadata interface and a file name, returns the correct [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface that will read the debugging symbols associated with the module.  
  
 This method will open the program database (PDB) file only if it is next to the executable file. This change has been made for security purposes. If you need a more extensive search for the PDB file, use the [ISymUnmanagedBinder2::GetReaderForFile2](isymunmanagedbinder2-getreaderforfile2-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT GetReaderForFile(  
    [in]  IUnknown     *importer,  
    [in]  const WCHAR  *fileName,  
    [in]  const WCHAR  *searchPath,  
    [out, retval] ISymUnmanagedReader  **pRetVal);  
```  
  
## Parameters  

 `importer`  
 [in] A pointer to the metadata import interface.  
  
 `fileName`  
 [in] A pointer to the file name.  
  
 `searchPath`  
 [in] A pointer to the search path.  
  
 `pRetVal`  
 [out] A pointer that is set to the returned [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedBinder Interface](isymunmanagedbinder-interface.md)
- [GetReaderForFile2 Method](isymunmanagedbinder2-getreaderforfile2-method.md)
