---
title: "ISymUnmanagedReader::GetMethod Method | Microsoft Docs"
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
  - "ISymUnmanagedReader.GetMethod"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetMethod"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetMethod method, ISymUnmanagedReader interface [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetMethod method [.NET Framework debugging]"
ms.assetid: ae6cfb29-bc2c-4606-af86-1d32ebd31020
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedReader::GetMethod Method
Gets a symbol reader method, given a method token.  
  
## Syntax  
  
```  
HRESULT GetMethod (  
    [in]  mdMethodDef  token,  
    [out, retval] ISymUnmanagedMethod**  pRetVal);  
```  
  
#### Parameters  
 `token`  
 [in] The method token.  
  
 `pRetVal`  
 [out] A pointer to the returned interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)