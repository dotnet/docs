---
title: "ISymUnmanagedWriter::RemapToken Method"
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
  - "ISymUnmanagedWriter.RemapToken"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::RemapToken"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::RemapToken method [.NET Framework debugging]"
  - "RemapToken method [.NET Framework debugging]"
ms.assetid: bca92682-ee1e-467f-8fb0-d8d4617f82fe
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::RemapToken Method
Notifies the symbol writer that a metadata token has been remapped as the metadata was emitted. If the symbol writer has stored the old token within the symbol store, it must either update the stored token with the new value, or it must save the map for the corresponding symbol reader to remap during the read phase.  
  
## Syntax  
  
```  
HRESULT RemapToken(  
    [in] mdToken  oldToken,  
    [in] mdToken  newToken);  
```  
  
#### Parameters  
 `oldToken`  
 [in] The metadata token that was remapped.  
  
 `newToken`  
 [in] The new metadata token to which `oldToken` was remapped.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
