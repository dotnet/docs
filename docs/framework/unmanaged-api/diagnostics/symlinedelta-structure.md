---
title: "SYMLINEDELTA Structure | Microsoft Docs"
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
  - "SYMLINEDELTA"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "SYMLINEDELTA"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "SYMLINEDELTA structure [.NET Framework debugging]"
ms.assetid: 9634e995-d46d-4397-ab66-cc5781d11e4e
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# SYMLINEDELTA Structure
Provides information to the symbol handler about methods that were moved as a result of edits.  
  
## Syntax  
  
```  
typedef struct _SYMLINEDELTA  
    {  
        mdMethodDef  mdMethod;  
        INT32        delta;  
    } SYMLINEDELTA;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`mdMethod`|The method's metadata token.|  
|`delta`|The number of lines the method was moved.|  
  
## Requirements  
 **Header:** CorSym.idl  
  
## See Also  
 [Diagnostics Symbol Store Structures](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-structures.md)