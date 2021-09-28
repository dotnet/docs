---
description: "Learn more about: ISymUnmanagedBinder2::GetReaderForFile2 Method"
title: "ISymUnmanagedBinder2::GetReaderForFile2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedBinder2.GetReaderForFile2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedBinder2::GetReaderForFile2"
helpviewer_keywords: 
  - "ISymUnmanagedBinder2::GetReaderForFile2 method [.NET Framework debugging]"
  - "GetReaderForFile2 method [.NET Framework debugging]"
ms.assetid: dd92dcaf-403c-464d-a254-21594985dddd
topic_type: 
  - "apiref"
---
# ISymUnmanagedBinder2::GetReaderForFile2 Method

Given a metadata interface and a file name, returns the correct [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface that will read the debugging symbols associated with the module.  
  
 This method provides a more extensive search for the program database (PDB) file than the [ISymUnmanagedBinder::GetReaderForFile](isymunmanagedbinder-getreaderforfile-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT GetReaderForFile2(  
    [in]  IUnknown     *importer,  
    [in]  const WCHAR  *fileName,  
    [in]  const WCHAR  *searchPath,  
    [in]  ULONG32      searchPolicy,  
    [out,retval] ISymUnmanagedReader  **pRetVal);  
```  
  
## Parameters  

 `importer`  
 [in] A pointer to the metadata import interface.  
  
 `fileName`  
 [in] A pointer to the file name.  
  
 `searchPath`  
 [in] A pointer to the search path.  
  
 `searchPolicy`  
 [in] A value of the [CorSymSearchPolicyAttributes](corsymsearchpolicyattributes-enumeration.md) enumeration that specifies the policy to be used when doing a search for a symbol reader.  
  
 `pRetVal`  
 [out] A pointer that is set to the returned [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## Remarks  

 This version of the method can search for the PDB file in areas other than right next to the module. The search policy can be controlled by combining [CorSymSearchPolicyAttributes](corsymsearchpolicyattributes-enumeration.md). For example, `AllowReferencePathAccess | AllowSymbolServerAccess` looks for the PDB next to the executable file and on a symbol server, but does not query the registry or use the path in the executable file. If the `searchPath` parameter is provided, those directories will always be searched.  
  
## See also

- [ISymUnmanagedBinder2 Interface](isymunmanagedbinder2-interface.md)
- [GetReaderForFile Method](isymunmanagedbinder-getreaderforfile-method.md)
