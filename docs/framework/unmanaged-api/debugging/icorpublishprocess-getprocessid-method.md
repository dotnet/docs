---
description: "Learn more about: ICorPublishProcess::GetProcessID Method"
title: "ICorPublishProcess::GetProcessID Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishProcess.GetProcessID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishProcess::GetProcessID"
helpviewer_keywords: 
  - "ICorPublishProcess::GetProcessID method [.NET Framework debugging]"
  - "GetProcessID method [.NET Framework debugging]"
ms.assetid: f31185e0-f01d-463a-b392-42163e39bfe9
topic_type: 
  - "apiref"
---
# ICorPublishProcess::GetProcessID Method

Gets the operating system identifier for this process.  
  
## Syntax  
  
```cpp  
HRESULT GetProcessID (  
    [out] unsigned   *pid  
);  
```  
  
## Parameters  

 `pid`  
 [out] A pointer to the identifier of the process represented by this [ICorPublishProcess](icorpublishprocess-interface.md) object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublishProcess Interface](icorpublishprocess-interface.md)
