---
description: "Learn more about: IManagedObject::GetSerializedBuffer Method"
title: "IManagedObject::GetSerializedBuffer Method"
ms.date: "03/30/2017"
api_name: 
  - "IManagedObject.GetSerializedBuffer"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetSerializedBuffer"
helpviewer_keywords: 
  - "IManagedObject::GetSerializedBuffer method [.NET Framework hosting]"
  - "GetSerializedBuffer method [.NET Framework hosting]"
ms.assetid: c17105bb-b49f-434e-8f9b-77f8c85b9220
topic_type: 
  - "apiref"
---
# IManagedObject::GetSerializedBuffer Method

Gets the string representation of this managed object.  
  
## Syntax  
  
```cpp  
HRESULT GetSerializedBuffer (  
    [out] BSTR *pBSTR  
);  
```  
  
## Parameters  

 `pBSTR`  
 [out] A pointer to a string that is the serialized object.  
  
## Remarks  

 The `GetSerializedBuffer` method serializes the object so it can be marshaled to the client.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IManagedObject Interface](imanagedobject-interface.md)
