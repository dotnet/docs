---
description: "Learn more about: ICLRDataTarget::GetTLSValue Method"
title: "ICLRDataTarget::GetTLSValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget.GetTLSValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::GetTLSValue"
helpviewer_keywords: 
  - "GetTLSValue method [.NET Framework debugging]"
  - "ICLRDataTarget::GetTLSValue method [.NET Framework debugging]"
ms.assetid: 0d8a7730-edc9-4728-898f-41b219cf5a28
topic_type: 
  - "apiref"
---
# ICLRDataTarget::GetTLSValue Method

Gets a value from the thread local storage (TLS) of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.  
  
## Syntax  
  
```cpp  
HRESULT GetTLSValue (  
    [in] ULONG32            threadID,  
    [in] ULONG32            index,  
    [out] CLRDATA_ADDRESS   *value  
);  
```  
  
## Parameters  

 `threadID`  
 [in] The operating system identifier of a thread in the target process.  
  
 `index`  
 [in] The index of the location. This value must be a valid index in the local store of the specified thread.  
  
 `value`  
 [out] A pointer to a `CLRDATA_ADDRESS` value that specifies the value returned from the given TLS location.  
  
## Remarks  

 This method is implemented by the writer of the debugging application.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget Interface](iclrdatatarget-interface.md)
