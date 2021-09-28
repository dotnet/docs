---
description: "Learn more about: ISymUnmanagedReader::Initialize Method"
title: "ISymUnmanagedReader::Initialize Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.Initialize"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::Initialize"
helpviewer_keywords: 
  - "ISymUnmanagedReader::Initialize method [.NET Framework debugging]"
  - "Initialize method, ISymUnmanagedReader interface [.NET Framework debugging]"
ms.assetid: 8f0dd2fe-7df7-464e-91f4-5518c586bb5f
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader::Initialize Method

Initializes the symbol reader with the metadata importer interface that this reader will be associated with, along with the file name of the module.  
  
> [!NOTE]
> This method can be called only once, and must be called before any other reader methods.  
  
## Syntax  
  
```cpp  
HRESULT Initialize (  
    [in]  IUnknown     *importer,  
    [in]  const WCHAR  *filename,  
    [in]  const WCHAR  *searchPath,  
    [in]  IStream      *pIStream);  
```  
  
## Parameters  

 `importer`  
 [in] The metadata importer interface with which this reader will be associated.  
  
 `filename`  
 [in] The file name of the module. You can use the `pIStream` parameter instead.  
  
 `searchPath`  
 [in] The path to search. This parameter is optional.  
  
 `pIStream`  
 [in] The file stream, used as an alternative to the filename parameter.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Remarks  

 You need to specify only one of the `filename` or the `pIStream` parameters, not both. The `searchPath` parameter is optional.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)
