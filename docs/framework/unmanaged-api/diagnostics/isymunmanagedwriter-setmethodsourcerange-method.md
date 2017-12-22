---
title: "ISymUnmanagedWriter::SetMethodSourceRange Method"
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
  - "ISymUnmanagedWriter.SetMethodSourceRange"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::SetMethodSourceRange"
helpviewer_keywords: 
  - "SetMethodSourceRange method [.NET Framework debugging]"
  - "ISymUnmanagedWriter::SetMethodSourceRange method [.NET Framework debugging]"
ms.assetid: c698b86e-ace7-4b21-9549-f52d6a034959
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::SetMethodSourceRange Method
Specifies the true start and end of a method within a source file. Use this method to specify the extent of a method independently of the sequence points that exist within the method.  
  
## Syntax  
  
```  
HRESULT SetMethodSourceRange(  
    [in] ISymUnmanagedDocumentWriter  *startDoc,  
    [in] ULONG32                      startLine,  
    [in] ULONG32                      startColumn,  
    [in] ISymUnmanagedDocumentWriter  *endDoc,  
    [in] ULONG32                      endLine,  
    [in] ULONG32                      endColumn);  
```  
  
#### Parameters  
 `startDoc`  
 [in] A pointer to the document containing the starting position.  
  
 `startLine`  
 [in] The starting line number.  
  
 `startColumn`  
 [in] The starting column.  
  
 `endDoc`  
 [in] A pointer to the document containing the ending position.  
  
 `endLine`  
 [in] The ending line number.  
  
 `endColumn`  
 [in] The ending column number.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
