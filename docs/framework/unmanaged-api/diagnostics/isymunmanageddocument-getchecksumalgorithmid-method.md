---
title: "ISymUnmanagedDocument::GetCheckSumAlgorithmId Method"
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
  - "ISymUnmanagedDocument.GetCheckSumAlgorithmId"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetCheckSumAlgorithmId"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetCheckSumAlgorithmId method [.NET Framework debugging]"
  - "GetCheckSumAlgorithmId method [.NET Framework debugging]"
ms.assetid: c7f941cd-e25b-4b85-b1ce-5f77c9208fa9
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDocument::GetCheckSumAlgorithmId Method
Gets the checksum algorithm identifier, or returns a GUID of all zeros if there is no checksum.  
  
## Syntax  
  
```  
HRESULT GetCheckSumAlgorithmId(  
    [out, retval] GUID*  pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to a variable that receives the checksum algorithm identifier.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
