---
title: "ISymUnmanagedDocument::GetURL Method"
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
  - "ISymUnmanagedDocument.GetURL"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetURL"
helpviewer_keywords: 
  - "GetURL method [.NET Framework debugging]"
  - "ISymUnmanagedDocument::GetURL method [.NET Framework debugging]"
ms.assetid: 60600178-c2b5-4cab-b3a5-f0f61acebaf1
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDocument::GetURL Method
Returns the uniform resource locator (URL) for this document.  
  
## Syntax  
  
```  
HRESULT GetURL(  
    [in]  ULONG32  cchUrl,  
    [out] ULONG32  *pcchUrl,  
    [out, size_is(cchUrl), length_is(*pcchUrl)] WCHAR szUrl[]);  
```  
  
#### Parameters  
 `cchUrl`  
 [in] The size, in characters, of the `szURL` buffer.  
  
 `pcchUrl`  
 [out] A pointer to a variable that receives the size of the URL, including the null termination.  
  
 `szUrl`  
 [out] The buffer containing the URL.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, an error code.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
