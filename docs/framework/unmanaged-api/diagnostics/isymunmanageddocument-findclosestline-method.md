---
title: "ISymUnmanagedDocument::FindClosestLine Method"
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
  - "ISymUnmanagedDocument.FindClosestLine"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::FindClosestLine"
helpviewer_keywords: 
  - "FindClosestLine method [.NET Framework debugging]"
  - "ISymUnmanagedDocument::FindClosestLine method [.NET Framework debugging]"
ms.assetid: 628f2a04-e529-407d-841e-3b3da219a9cb
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDocument::FindClosestLine Method
Returns the closest line that is a sequence point, given a line in this document that may or may not be a sequence point.  
  
## Syntax  
  
```  
HRESULT FindClosestLine(  
    [in]  ULONG32  line,  
    [out, retval] ULONG32*  pRetVal);  
```  
  
#### Parameters  
 `line`  
 [in] A line in this document.  
  
 `pRetVal`  
 [out] A pointer to a variable that receives the line.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, an error code.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
