---
title: GetMethod function (Unmanaged API Reference)
description: The GetMethod function retrieves information about a method.
ms.date: "11/06/2017"
api_name:
  - "GetMethod"
api_location:
  - "WMINet_Utils.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "GetMethod"
helpviewer_keywords:
  - "GetMethod function [.NET WMI and performance counters]"
topic_type:
  - "Reference"
---

# GetMethod function

Retrieves information about the specified method.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT GetMethod (
   [in] int                vFunc,
   [in] IWbemClassObject*   ptr,
   [in] LPCWSTR             wszName,
   [in] LONG                lFlags,
   [out] IWbemClassObject** ppInSignature,
   [out] IWbemClassObject** ppOutSignature
);
```

## Parameters

`vFunc`\
[in] This parameter is unused.

`ptr`\
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`wszName`\
[in] The method name. This parameter cannot be `null` and must point to a valid `LPCWSTR`.

`lFlags`\
[in] Reserved. This parameter must be 0.

`ppInSignature`\
[out] A pointer to the address of an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance that describes the in parameters to the method. This parameter is ignored if it is set to `null`.

`ppOutSignature`\
[out] A pointer to the address of an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance that describes the out parameters to the method. This parameter is ignored if it is set to `null`.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified property was not found. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |

## Remarks

This function wraps a call to the [IWbemClassObject::GetMethod](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-getmethod) method.

Windows Management can set the [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) pointer to `null` if the method has no in parameters.

In `ppInSignature` and `ppOutSignature` describe in and out parameters, respectively, as properties in a `IWbemClassObject` instance of the system class [_Parameters](/windows/desktop/WmiSdk/--parameters). The properties in `ppInSignature` are named `Param`*n*, where *n* is the position of the parameter in the method signature (such as `Param1`, `Param2`, etc.). The properties in `ppOutSignature` are also named `Param`*n*, and the return value is named `ReturnValue`. For more information and an example, see [IWbemClassObject::GetMethod method](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-getmethod).

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** WMINet_Utils.idl

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
