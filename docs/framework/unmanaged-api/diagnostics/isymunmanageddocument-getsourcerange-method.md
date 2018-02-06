---
title: "ISymUnmanagedDocument::GetSourceRange Method"
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
  - "ISymUnmanagedDocument.GetSourceRange"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetSourceRange"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetSourceRange method [.NET Framework debugging]"
  - "GetSourceRange method [.NET Framework debugging]"
ms.assetid: 20fefee7-1040-41ba-93dc-bd42f68b90c2
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDocument::GetSourceRange Method
Returns the specified range of the embedded source into the given buffer. The buffer must be large enough to hold the source.  
  
## Syntax  
  
```  
HRESULT GetSourceRange(  
    [in]  ULONG32  startLine,  
    [in]  ULONG32  startColumn,  
    [in]  ULONG32  endLine,  
    [in]  ULONG32  endColumn,  
    [in]  ULONG32  cSourceBytes,  
    [out] ULONG32  *pcSourceBytes,  
    [out, size_is(cSourceBytes),  
        length_is(*pcSourceBytes)] BYTE source[]);  
```  
  
#### Parameters  
 `startLine`  
 [in] The starting line in the current document.  
  
 `startColumn`  
 [in] The starting column in the current document.  
  
 `endLine`  
 [in] The final line in the current document.  
  
 `endColumn`  
 [in] The final column in the current document.  
  
 `cSourceBytes`  
 [in] The size of the source, in bytes.  
  
 `pcSourceBytes`  
 [out] A pointer to a variable that receives the source size.  
  
 `source`  
 [out] The size and length of the specified range of the source document, in bytes.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
