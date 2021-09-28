---
title: GetPropertyOrigin function (Unmanaged API Reference)
description: The GetPropertyOrigin function determines the class in which a property is declared.
ms.date: "11/06/2017"
api_name:
  - "GetPropertyOrigin"
api_location:
  - "WMINet_Utils.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "GetPropertyOrigin"
helpviewer_keywords:
  - "GetPropertyOrigin function [.NET WMI and performance counters]"
topic_type:
  - "Reference"
---

# GetPropertyOrigin function

Determines the class in which a property is declared.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT GetPropertyOrigin (
   [in] int                 vFunc,
   [in] IWbemClassObject*   ptr,
   [in] LPCWSTR             wszMethodName,
   [out] BSTR*              pstrClassName
);
```

## Parameters

`vFunc`\
[in] This parameter is unused.

`ptr`\
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`wszMethodName`\
[in] The name of the property for the object whose owning class is being requested.

`pstrClassName`\
[out] Receives the name of the class that owns the property.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified property was not found. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |

## Remarks

This function wraps a call to the [IWbemClassObject::GetPropertyOrigin](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-getpropertyorigin) method.

Because a class can inherit properties from one or more base classes, developers often want to determine the property in which a given method is defined.

The `pstrClassName` parameter must not point to a valid `BSTR` before the function is called because this is an `out` parameter; this pointer is not deallocated after the function returns.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** WMINet_Utils.idl

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
