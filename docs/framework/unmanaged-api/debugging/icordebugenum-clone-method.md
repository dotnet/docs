---
title: "ICorDebugEnum::Clone Method | Microsoft Docs"
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
  - "ICorDebugEnum.Clone"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugEnum::Clone"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "Clone method, ICorDebugEnum interface [.NET Framework debugging]"
  - "ICorDebugEnum::Clone method [.NET Framework debugging]"
ms.assetid: 57eefaf3-75cf-4496-bc94-88c0706861b7
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugEnum::Clone Method
Creates a copy of this ICorDebugEnum object.  
  
## Syntax  
  
```  
HRESULT Clone (  
    [out] ICorDebugEnum **ppEnum  
);  
```  
  
#### Parameters  
 `ppEnum`  
 [out] A pointer to the address of an `ICorDebugEnum` object that is a copy of this `ICorDebugEnum` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]