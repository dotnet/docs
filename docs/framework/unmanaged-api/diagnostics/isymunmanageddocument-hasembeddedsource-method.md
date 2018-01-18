---
title: "ISymUnmanagedDocument::HasEmbeddedSource Method"
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
  - "ISymUnmanagedDocument.HasEmbeddedSource"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::HasEmbeddedSource"
helpviewer_keywords: 
  - "HasEmbeddedSource method [.NET Framework debugging]"
  - "ISymUnmanagedDocument::HasEmbeddedSource method [.NET Framework debugging]"
ms.assetid: 385fc4d3-365c-4645-b7b0-6c4c5344b79f
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDocument::HasEmbeddedSource Method
Returns `true` if the document has source embedded in the debugging symbols; otherwise, returns `false`.  
  
## Syntax  
  
```  
HRESULT HasEmbeddedSource(  
   [out, retval]  BOOL  *pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to a variable that indicates whether the document has source embedded in the debugging symbols.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
