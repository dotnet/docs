---
title: "ICorDebugProcess2::GetVersion Method | Microsoft Docs"
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
  - "ICorDebugProcess2.GetVersion"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugProcess2::GetVersion"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetVersion method, ICorDebugProcess2 nterface [.NET Framework debugging]"
  - "ICorDebugProcess2::GetVersion method [.NET Framework debugging]"
ms.assetid: e11d5a75-61d9-4548-aedf-79c26079bd17
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugProcess2::GetVersion Method
Gets the version number of the common language runtime (CLR) that is running in this process.  
  
## Syntax  
  
```  
HRESULT GetVersion (  
    [out] COR_VERSION     *version  
);  
```  
  
#### Parameters  
 `version`  
 [out] A pointer to a COR_VERSION structure that stores the version number of the runtime.  
  
## Remarks  
 The `GetVersion` method returns an error code if no runtime has been loaded in the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]