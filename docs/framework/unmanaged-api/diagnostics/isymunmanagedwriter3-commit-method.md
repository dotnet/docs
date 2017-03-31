---
title: "ISymUnmanagedWriter3::Commit Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ISymUnmanagedWriter3.Commit"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedWriter3::Commit"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "Commit method, ISymUnmanagedWriter3 interface [.NET Framework debugging]"
  - "ISymUnmanagedWriter3::Commit method [.NET Framework debugging]"
ms.assetid: f6961922-46ec-4d2c-8369-85f880731f37
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedWriter3::Commit Method
Commits the changes written so far to the stream.  
  
## Syntax  
  
```  
HRESULT Commit();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl , CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter3 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter3-interface.md)