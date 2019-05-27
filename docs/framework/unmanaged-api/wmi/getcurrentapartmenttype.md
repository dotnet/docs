---
title: GetCurrentApartmentType function (Unmanaged API Reference)
description: The GetCurrentApartmentType function retrieves the type of apartment in which the caller is executing.
ms.date: "11/06/2017"
api_name: 
  - "GetCurrentApartmentType"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetCurrentApartmentType"
helpviewer_keywords: 
  - "GetCurrentApartmentType function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
---
# GetCurrentApartmentType function
Retrieves the type of apartment in which the caller is executing.   
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT GetCurrentApartmentType (
   [in] int                   vFunc, 
   [in] IComThreadingInfo*    ptr, 
   [out] APTTYPE*             aptType
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IComThreadingInfo](/windows/desktop/api/objidlbase/nn-objidlbase-icomthreadinginfo) instance.

`aptType`  
[out] A pointer to an [APTTYPE](/windows/desktop/api/objidlbase/ne-objidlbase-_apttype) enumeration value that indicates the caller's apartment.

## Return value

|Constant  |Value  |Description  |
|---------|---------|---------|
| `S_OK` | 0 | The function completed successfully. |
| `E_FAIL` | 0x80000008 | The caller is not executing in an apartment. |
  
## Remarks

This function wraps a call to the [IComThreadingInfo::GetCurrentApartmentType](/windows/desktop/api/objidlbase/nf-objidlbase-icomthreadinginfo-getcurrentapartmenttype) method.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
