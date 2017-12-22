---
title: "ISymUnmanagedDocument::GetSourceLength Method"
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
  - "ISymUnmanagedDocument.GetSourceLength"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetSourceLength"
helpviewer_keywords: 
  - "GetSourceLength method [.NET Framework debugging]"
  - "ISymUnmanagedDocument::GetSourceLength method [.NET Framework debugging]"
ms.assetid: e087dbbb-f4fb-4fbe-8292-e4f1a14d0df2
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDocument::GetSourceLength Method
Gets the length, in bytes, of the embedded source.  
  
## Syntax  
  
```  
HRESULT GetSourceLength(  
    [out, retval]  ULONG32*  pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to a variable that indicates the length, in bytes, of the embedded source.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
