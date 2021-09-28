---
description: "Learn more about: ICLRDataTarget::SetTLSValue Method"
title: "ICLRDataTarget::SetTLSValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget.SetTLSValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::SetTLSValue"
helpviewer_keywords: 
  - "ICLRDataTarget::SetTLSValue method [.NET Framework debugging]"
  - "SetTLSValue method [.NET Framework debugging]"
ms.assetid: 4a2d6a24-749a-47ad-9f01-4517203d3f35
topic_type: 
  - "apiref"
---
# ICLRDataTarget::SetTLSValue Method

Sets a value in the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.  
  
## Syntax  
  
```cpp  
HRESULT SetTLSValue (  
    [in] ULONG32            threadID,  
    [in] ULONG32            index,  
    [in] CLRDATA_ADDRESS    value  
);  
```  
  
## Parameters  

 `threadID`  
 [in] The operating system identifier of a thread in the target process.  
  
 `index`  
 [in] The index of the location. This value must be a valid index in the local store of the specified thread.  
  
 `value`  
 [in] A `CLRDATA_ADDRESS` value that specifies the value to place in the given TLS location.  
  
## Remarks  

 This method is implemented by the writer of the debugging application.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget Interface](iclrdatatarget-interface.md)
