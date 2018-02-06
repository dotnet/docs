---
title: "ISymUnmanagedWriter::Abort Method"
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
  - "ISymUnmanagedWriter.Abort"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::Abort"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::Abort method [.NET Framework debugging]"
  - "Abort method, ISymUnmanagedWriter interface [.NET Framework debugging]"
ms.assetid: 416b220f-38d4-48e0-bb49-d2faa7366702
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::Abort Method
Closes the symbol writer without committing the symbols to the symbol store. After this call, the symbol writer becomes invalid for further updates. To commit the symbols and close the symbol writer, use the [ISymUnmanagedWriter::Close](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-close-method.md) method instead.  
  
## Syntax  
  
```  
HRESULT Abort();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
