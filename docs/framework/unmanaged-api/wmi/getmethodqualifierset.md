---
title: GetMethodQualifierSet function (Unmanaged API Reference)
description: The GetMethodQualifierSet function retrieves a method's qualifier set.
ms.date: "11/06/2017"
api_name:
  - "GetMethodQualifierSet"
api_location:
  - "WMINet_Utils.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "GetMethodQualifierSet"
helpviewer_keywords:
  - "GetMethodQualifierSet function [.NET WMI and performance counters]"
topic_type:
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
---

# GetMethodQualifierSet function

Retrieves the qualifier set for a particular method.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT GetMethodQualifierSet (
   [in] int                 vFunc,
   [in] IWbemClassObject*   ptr,
   [in] LPCWSTR             wszMethod,
   [out] IWbemQualifierSet  **ppQualSet
);
```

## Parameters

`vFunc`\
[in] This parameter is unused.

`ptr`\
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`wszMethod`\
[in] The method  name. `wszMethod` must point to a valid `LPCWSTR`.

`ppQualSet`\
[out] Receives the interface pointer that allows access to the qualifiers of the method. `ppQualSet` cannot be `null`. If an error occurs, a new object is not returned, and the pointer is set to point to `null`.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified method does not exist. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is `null`. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |

## Remarks

This function wraps a call to the [IWbemClassObject::GetMethodQualifierSet](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-getmethodqualifierset) method.

A call to this function is supported only if the current object is a CIM class definition. Method manipulation is not available for [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) pointers that point to CIM instances.

Because each method may have its own qualifiers, the [IWbemQualifierSet pointer](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemqualifierset) lets the caller add, edit, or delete these qualifiers.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).

**Header:** WMINet_Utils.idl

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)