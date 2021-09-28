---
description: "Learn more about: _EFN_GetManagedObjectFieldInfo Function"
title: "_EFN_GetManagedObjectFieldInfo Function"
ms.date: "03/30/2017"
api_name: 
  - "_EFN_GetManagedObjectFieldInfo"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "_EFN_GetManagedObjectFieldInfo"
helpviewer_keywords: 
  - "_EFN_GetManagedObjectFieldInfo function [.NET Framework debugging]"
ms.assetid: 3b93bcff-62a4-47b2-babc-6bcf4216119a
topic_type: 
  - "apiref"
---
# \_EFN\_GetManagedObjectFieldInfo Function

Gets the offset from the start of an object to a field and the field's value, using the provided object pointer and field name.  
  
## Syntax  
  
```cpp  
HRESULT _EFN_GetManagedObjectFieldInfo(  
    [in]  PDEBUG_CLIENT Client,  
    [in]  ULONG64       objAddr,  
    [in]  __out_ecount (mdNameLen) PSTR szFieldName,  
    [out] PULONG64      pValue,  
    [out] PULONG        pOffset  
);  
```  
  
## Parameters  

 `Client`  
 [in] A pointer to the debug client.  
  
 `objAddr`  
 [in] A managed object pointer.  
  
 szFieldName  
 [in] A managed object pointer to the field name.  
  
 `pValue`  
 [out] The field value. This parameter can be null.  
  
 `pOffset`  
 [out] The offset from `objAddr` to the field. This parameter can be null.  
  
## Remarks  

 If the offset is 0, no offset is written.  
  
 If there is no managed code on the thread currently in context, the function returns HRESULT SOS_E_NOMANAGEDCODE with a facility value of 0xa0 and an error code of 0x1000.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** SOS_Stacktrace.h  
  
 **.NET Framework Version:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Global Static Functions](debugging-global-static-functions.md)
