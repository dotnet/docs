---
title: "ISymUnmanagedWriter::Close Method"
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
  - "ISymUnmanagedWriter.Close"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::Close"
helpviewer_keywords: 
  - "Close method, ISymUnmanagedWriter interface [.NET Framework debugging]"
  - "ISymUnmanagedWriter::Close method [.NET Framework debugging]"
ms.assetid: 4cce59e1-80b9-4fc4-b3aa-126f1c5876bc
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::Close Method
Closes the symbol writer after committing the symbols to the symbol store.  
  
## Syntax  
  
```  
HRESULT Close();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Remarks  
 After this call, the symbol writer becomes invalid for further updates. To close the symbol writer without committing the symbols, use the [ISymUnmanagedWriter::Abort](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-abort-method.md) method instead.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
