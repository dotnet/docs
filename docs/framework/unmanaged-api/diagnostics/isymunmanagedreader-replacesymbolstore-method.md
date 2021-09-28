---
description: "Learn more about: ISymUnmanagedReader::ReplaceSymbolStore Method"
title: "ISymUnmanagedReader::ReplaceSymbolStore Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.ReplaceSymbolStore"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::ReplaceSymbolStore"
helpviewer_keywords: 
  - "ReplaceSymbolStore method [.NET Framework debugging]"
  - "ISymUnmanagedReader::ReplaceSymbolStore method [.NET Framework debugging]"
ms.assetid: 43257761-8cb1-4eaf-8fb5-1f3980cb66cd
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader::ReplaceSymbolStore Method

Replaces the existing symbol store with a delta symbol store. This method is similar to the [UpdateSymbolStore](isymunmanagedreader-updatesymbolstore-method.md) method, except that the given delta acts as a complete replacement rather than an update.  
  
> [!NOTE]
> You need specify only one of the `filename` or `pIStream` parameters, not both. If `filename` is specified, the symbol store will be updated with the symbols in that file. If `pIStream` is specified, the store will be updated with the data from the <xref:System.Runtime.InteropServices.ComTypes.IStream>.  
  
## Syntax  
  
```cpp  
HRESULT ReplaceSymbolStore (  
    [in] const WCHAR *filename,  
    [in] IStream *pIStream);  
```  
  
## Parameters  

 `filename`  
 [in] The name of the file containing the symbol store.  
  
 `pIStream`  
 [in] The file stream, used as an alternative to the `filename` parameter.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)
