---
title: GetPropertyQualifierSet function (Unmanaged API Reference)
description: The GetPropertyQualifierSet function retrieves the qualifier set for a property.
ms.date: "11/06/2017"
api_name:
  - "GetPropertyQualifierSet"
api_location:
  - "WMINet_Utils.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "GetPropertyQualifierSet"
helpviewer_keywords:
  - "GetPropertyQualifierSet function [.NET WMI and performance counters]"
topic_type:
  - "Reference"
---

# GetPropertyQualifierSet function

Retrieves the qualifier set for a particular property.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT GetPropertyQualifierSet (
   [in] int                 vFunc,
   [in] IWbemClassObject*   ptr,
   [in] LPCWSTR             wszProperty,
   [out] IWbemQualifierSet  **ppQualSet
);
```

## Parameters

`vFunc`\
[in] This parameter is unused.

`ptr`\
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`wszMethod`\
[in] The property  name. `wszProperty` must point to a valid `LPCWSTR`.

`ppQualSet`\
[out] Receives the interface pointer that allows access to the qualifiers of the property. `ppQualSet` cannot be `null`. If an error occurs, a new object is not returned, and the pointer is set to point to `null`.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
| `WBEM_E_NOT_FOUND` | 0x80041002 | The specified method does not exist. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is `null`. |
| `WBEM_E_SYSTEM_PROPERTY` | 0x80041030 | The function attempts to get qualifiers of a system property. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |

## Remarks

This function wraps a call to the [IWbemClassObject::GetPropertyQualifierSet](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-getpropertyqualifierset) method.

A call to this function is supported only if the current object is a CIM class definition. Method manipulation is not available for [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) pointers that point to CIM instances.

Because each method may have its own qualifiers, the [IWbemQualifierSet pointer](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemqualifierset) lets the caller add, edit, or delete these qualifiers.

Because system properties have no qualifiers, the function returns `WBEM_E_SYSTEM_PROPERTY` if you attempt to obtain a [IWbemQualifierSet](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemqualifierset) pointer for a system property.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** WMINet_Utils.idl

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
