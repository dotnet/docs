---
title: "ISymUnmanagedENCUpdate::InitializeForEnc Method | Microsoft Docs"
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
  - "ISymUnmanagedENCUpdate.InitializeForEnc"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate::InitializeForEnc"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ISymUnmanagedENCUpdate::InitializeForEnc method [.NET Framework debugging]"
  - "InitializeForEnc method [.NET Framework debugging]"
ms.assetid: 796b2154-b53c-4d07-9e67-80fd6064725a
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedENCUpdate::InitializeForEnc Method
Allows method boundaries to be computed before the first call to the [ISymUnmanagedENCUpdate::UpdateSymbolStore2](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedencupdate-updatesymbolstore2-method.md) method.  
  
## Syntax  
  
```  
HRESULT InitializeForEnc();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedENCUpdate Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedencupdate-interface.md)