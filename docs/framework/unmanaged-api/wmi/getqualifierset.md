---
title: GetQualifierSet function (Unmanaged API Reference)
description: The GetQualifierSet function retrieves the qualifier set for a class or instance.
ms.date: "11/06/2017"
api_name: 
  - "GetQualifierSet"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetQualifierSet"
helpviewer_keywords: 
  - "GetQualifierSet function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
---
# GetQualifierSet function

Retrieves the qualifier set for a class instance or a class definition.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax  
  
```cpp  
HRESULT GetQualifierSet (
   [in] int                 vFunc,
   [in] IWbemClassObject*   ptr,
   [out] IWbemQualifierSet  **ppQualSet
);
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`ppQualSet`  
[out] Receives the interface pointer that allows access to the qualifiers of the class object. `ppQualSet` cannot be `null`. If an error occurs, a new object is not returned, and the pointer is left unmodified.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified method does not exist. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is `null`. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::GetQualifierSet](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-getqualifierset) method.

The [IWbemQualifierSet pointer](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemqualifierset) lets the caller add, edit, or delete these qualifiers. Such added, edited, or deleted qualifiers apply to the entire instance or class definition.

## Requirements  

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
