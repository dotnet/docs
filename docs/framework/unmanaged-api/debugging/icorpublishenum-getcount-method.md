---
title: "ICorPublishEnum::GetCount Method | Microsoft Docs"
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
  - "ICorPublishEnum.GetCount"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorPublishEnum::GetCount"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetCount method, ICorPublishEnum interface [.NET Framework debugging]"
  - "ICorPublishEnum::GetCount method [.NET Framework debugging]"
ms.assetid: d228f684-2be3-4029-93ae-31fe02213c1f
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorPublishEnum::GetCount Method
Gets the number of items in the enumeration.  
  
## Syntax  
  
```  
HRESULT GetCount (  
    [out] ULONG   *pcelt  
);  
```  
  
#### Parameters  
 `pcelt`  
 [out] A pointer to the number of items in the enumeration.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorPublishEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishenum-interface.md)