---
title: GetPropertyHandle function (Unmanaged API Reference)
description: The GetPropertyHandle function returns a unique handle that identifies a property.
ms.date: "11/06/2017"
api_name:
  - "GetPropertyHandle"
api_location:
  - "WMINet_Utils.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "GetPropertyHandle"
helpviewer_keywords:
  - "GetPropertyHandle function [.NET WMI and performance counters]"
topic_type:
  - "Reference"
---

# GetPropertyHandle function

Returns a unique handle that identifies a property.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT GetPropertyHandle (
   [in] int                  vFunc,
   [in] IWbemObjectAccess*   ptr,
   [in] LPCWSTR              wszPropertyName,
   [out] CIMTYPE*            pType,
   [out] long*               pHandle
);
```

## Parameters

`vFunc`\
[in] This parameter is unused.

`ptr`\
[in] A pointer to an [IWbemObjectAccess](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemobjectaccess) instance.

`wszPropertyName`\
[in] A null-terminated string of UTF16-encoded characters that contains the property name.

`pType`\
[out] A pointer to a [`CIMTYPE`](/windows/win32/api/wbemcli/ne-wbemcli-cimtype_enumeration) enumeration member that represents the CIM type of the property.

`pHandle`\
[out] A pointer to an integer that contains the property handle.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified property name was not found. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
|`WBEM_E_NOT_SUPPORTED` | 0x8004100c | The requested property is of type are `CIM_OBJECT` or `CIM_ARRAY`. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |

## Remarks

This function wraps a call to the [IWbemClassObject::GetPropertyHandle](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemobjectaccess-getpropertyhandle) method.

You can use this handle to identify properties when using  [IWbemObjectAccess](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemobjectaccess) methods to read or write property values.

Handles can be retrieved for properties of all data types other than `CIM_OBJECT` and `CIM_ARRAY`. Returned handles work across all instances of a class.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** WMINet_Utils.idl

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
