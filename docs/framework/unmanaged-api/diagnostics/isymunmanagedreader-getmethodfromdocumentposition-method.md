---
title: "ISymUnmanagedReader::GetMethodFromDocumentPosition Method"
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
  - "ISymUnmanagedReader.GetMethodFromDocumentPosition"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetMethodFromDocumentPosition"
helpviewer_keywords: 
  - "GetMethodFromDocumentPosition method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetMethodFromDocumentPosition method [.NET Framework debugging]"
ms.assetid: 55773dbc-9053-46e3-8a3c-86caa9d91fb4
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::GetMethodFromDocumentPosition Method
Returns the method that contains the breakpoint at the given position in a document.  
  
## Syntax  
  
```  
HRESULT GetMethodFromDocumentPosition (  
    [in]  ISymUnmanagedDocument*  document,  
    [in]  ULONG32  line,  
    [in]  ULONG32  column,  
    [out, retval] ISymUnmanagedMethod**  pRetVal);  
```  
  
#### Parameters  
 `document`  
 [in] The specified document.  
  
 `line`  
 [in] The line of the specified document.  
  
 `column`  
 [in] The column of the specified document.  
  
 `pRetVal`  
 [out] A pointer to the address of a [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md) object that represents the method containing the breakpoint.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
