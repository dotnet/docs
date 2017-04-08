---
title: "IManagedObject::GetSerializedBuffer Method | Microsoft Docs"
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
  - "IManagedObject.GetSerializedBuffer"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "GetSerializedBuffer"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "IManagedObject::GetSerializedBuffer method [.NET Framework hosting]"
  - "GetSerializedBuffer method [.NET Framework hosting]"
ms.assetid: c17105bb-b49f-434e-8f9b-77f8c85b9220
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# IManagedObject::GetSerializedBuffer Method
Gets the string representation of this managed object.  
  
## Syntax  
  
```  
HRESULT GetSerializedBuffer (  
    [out] BSTR *pBSTR  
);  
```  
  
#### Parameters  
 `pBSTR`  
 [out] A pointer to a string that is the serialized object.  
  
## Remarks  
 The `GetSerializedBuffer` method serializes the object so it can be marshaled to the client.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IManagedObject Interface](../../../../docs/framework/unmanaged-api/hosting/imanagedobject-interface.md)