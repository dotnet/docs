---
title: "CorSymVarFlag Enumeration | Microsoft Docs"
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
  - "CorSymVarFlag"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "CorSymVarFlag"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "CorSymVarFlag enumeration [.NET Framework debugging]"
ms.assetid: c3f7d307-4047-4f9a-be8c-f152fca42fd0
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# CorSymVarFlag Enumeration
Indicates whether a variable is compiler-generated.  
  
## Syntax  
  
```  
typedef enum CorSymVarFlag   
{  
    VAR_IS_COMP_GEN = 1  
} CorSymVarFlag;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`VAR_IS_COMP_GEN`|Indicates that the given variable is compiler-generated.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [Diagnostics Symbol Store Enumerations](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-enumerations.md)