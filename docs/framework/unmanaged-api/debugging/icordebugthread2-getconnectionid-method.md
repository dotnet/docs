---
title: "ICorDebugThread2::GetConnectionID Method"
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
  - "ICorDebugThread2.GetConnectionID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread2::GetConnectionID"
helpviewer_keywords: 
  - "ICorDebugThread2::GetConnectionID method [.NET Framework debugging]"
  - "GetConnectionID method [.NET Framework debugging]"
ms.assetid: 9c76b587-f941-4fa1-8b86-f3494fb10c8e
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread2::GetConnectionID Method
Gets the connection identifier for this ICorDebugThread2 object.  
  
## Syntax  
  
```  
HRESULT GetConnectionID (  
    [out] CONNID *pdwConnectionId  
);  
```  
  
#### Parameters  
 `pdwConnectionId`  
 [out] A `CONNID` that represents the connection identifier.  
  
## Remarks  
 The `GetConnectionID` method returns zero in the `pdwConnectionId` parameter, if this thread is not part of a connection.  
  
 If this thread is connected to an instance of Microsoft SQL Server 2005 Analysis Services (SSAS), the `CONNID` maps to a server process identifier (SPID).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
