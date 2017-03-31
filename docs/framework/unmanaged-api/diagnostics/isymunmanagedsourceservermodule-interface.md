---
title: "ISymUnmanagedSourceServerModule Interface | Microsoft Docs"
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
  - "ISymUnmanagedSourceServerModule"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedSourceServerModule"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ISymUnmanagedSourceServerModule interface [.NET Framework debugging]"
ms.assetid: a19b23bd-2061-476e-b67d-252f57404f8b
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedSourceServerModule Interface
Provides source server data for a module. Obtain this interface by calling `QueryInterface` on an object that implements the [ISymUnmanagedReader](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md) interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetSourceServerData Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedsourceservermodule-getsourceserverdata-method.md)|Returns the source server data for the module.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [Diagnostics Symbol Store Interfaces](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-interfaces.md)