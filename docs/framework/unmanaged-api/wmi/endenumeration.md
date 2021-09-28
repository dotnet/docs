---
title: EndEnumeration function (Unmanaged API Reference)
description: The EndEnumeration function terminates an enumeration.
ms.date: "11/06/2017"
api_name:
  - "EndEnumeration"
api_location:
  - "WMINet_Utils.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "EndEnumeration"
helpviewer_keywords:
  - "EndEnumeration function [.NET WMI and performance counters]"
topic_type:
  - "Reference"
---

# EndEnumeration function

Terminates an enumeration sequence started with a call to the [BeginEnumeration function](beginenumeration.md).

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT EndEnumeration (
   [in] int               vFunc,
   [in] IWbemClassObject* ptr
);
```

## Parameters

`vFunc`\
[in] This parameter is unused.

`ptr`\
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |

## Remarks

This function wraps a call to the [IWbemClassObject::EndEnumeration](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) method.

A call to the `EndEnumeration` function is not required, but it is recommended because it releases resources associated with the enumeration. However, the resources are deallocated automatically when the next enumeration is started or the object is released.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** WMINet_Utils.idl

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
