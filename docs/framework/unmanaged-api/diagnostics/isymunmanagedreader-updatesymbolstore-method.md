---
title: "ISymUnmanagedReader::UpdateSymbolStore Method"
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
  - "ISymUnmanagedReader.UpdateSymbolStore"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::UpdateSymbolStore"
helpviewer_keywords: 
  - "UpdateSymbolStore method [.NET Framework debugging]"
  - "ISymUnmanagedReader::UpdateSymbolStore method [.NET Framework debugging]"
ms.assetid: 4a17d723-86b9-4f27-bd0d-b70c3259011c
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::UpdateSymbolStore Method
Updates the existing symbol store with a delta symbol store. This method is used in edit-and-continue scenarios to update the symbol store to match deltas to the original portable executable (PE) file.  
  
> [!NOTE]
>  You need specify only one of the `filename` or `pIStream` parameters, not both. If `filename` is specified, the symbol store will be updated with the symbols in that file. If `pIStream` is specified, the store will be updated with the data from the <xref:System.Runtime.InteropServices.ComTypes.IStream>.  
  
## Syntax  
  
```  
HRESULT UpdateSymbolStore (  
    [in] const WCHAR *filename,  
    [in] IStream *pIStream);  
```  
  
#### Parameters  
 `filename`  
 [in] The name of the file that contains the symbol store.  
  
 `pIStream`  
 [in] The file stream, used as an alternative to the `filename` parameter.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
