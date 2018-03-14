---
title: "ISymUnmanagedReader::GetMethodByVersion Method"
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
  - "ISymUnmanagedReader.GetMethodByVersion"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetMethodByVersion"
helpviewer_keywords: 
  - "ISymUnmanagedReader::GetMethodByVersion method [.NET Framework debugging]"
  - "GetMethodByVersion method [.NET Framework debugging]"
ms.assetid: 6ddb0631-4569-41b3-93e4-50fdfaa486dc
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::GetMethodByVersion Method
Gets a symbol reader method, given a method token and an edit-and-copy version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-copy operation.  
  
## Syntax  
  
```  
HRESULT GetMethodByVersion (  
    [in]  mdMethodDef  token,  
    [in]  int  version,  
    [out, retval] ISymUnmanagedMethod** pRetVal);  
```  
  
#### Parameters  
 `token`  
 [in] The method token.  
  
 `version`  
 [in] The method version.  
  
 `pRetVal`  
 [out] A pointer to the returned interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
