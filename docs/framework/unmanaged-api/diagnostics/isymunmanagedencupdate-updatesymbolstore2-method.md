---
title: "ISymUnmanagedENCUpdate::UpdateSymbolStore2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedENCUpdate.UpdateSymbolStore2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate::UpdateSymbolStore2"
helpviewer_keywords: 
  - "ISymUnmanagedENCUpdate::UpdateSymbolStore2 method [.NET Framework debugging]"
  - "UpdateSymbolStore2 method [.NET Framework debugging]"
ms.assetid: 35588317-6184-485c-ab41-4b15fc1765d9
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedENCUpdate::UpdateSymbolStore2 Method
Allows a compiler to omit functions that have not been modified from the program database (PDB) stream, provided the line information meets the requirements. The correct line information can be determined with the old PDB line information and one delta for all lines in the function.  
  
## Syntax  
  
```  
HRESULT UpdateSymbolStore2(  
    [in]  IStream      *pIStream,  
    [in]  SYMLINEDELTA* pDeltaLines,  
    [in]  ULONG         cDeltaLines);  
```  
  
#### Parameters  
 `pIStream`  
 [in] A pointer to an [IStream](/windows/desktop/api/objidl/nn-objidl-istream) that contains the line information.  
  
 `pDeltaLines`  
 [in] A pointer to a [SYMLINEDELTA](../../../../docs/framework/unmanaged-api/diagnostics/symlinedelta-structure.md) structure that contains the lines that have changed.  
  
 `cDeltaLines`  
 [in] A `ULONG` that represents the number of lines that have changed.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also
 [ISymUnmanagedENCUpdate Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedencupdate-interface.md)
