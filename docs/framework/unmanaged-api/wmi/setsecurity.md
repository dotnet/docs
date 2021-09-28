---
title: SetSecurity function (Unmanaged API Reference)
description: The SetSecurity function retrieves the current thread's impersonation token.
ms.date: "11/06/2017"
api_name: 
  - "SetSecurity"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "SetSecurity"
helpviewer_keywords: 
  - "SetSecurity function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
---
# SetSecurity function

Retrieves the impersonation token associated with the current thread.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT SetSecurity (
   [out] boolean* pNeedToReset,
   [out] HANDLE* pCurrentThreadToken
);
```

## Parameters

`pNeedToReset`\
[out] When the function returns, contains a pointer to a `boolean` that indicates whether the token should be reset by calling the [ResetSecurity](resetsecurity.md) function.

`token`\
[out] When the function returns, contains a pointer to the handle of the impersonation token associated with the current thread. Its value can be `null` if there is no token associated with the current thread.

## Return value

If the function succeeds, the return value is `S_OK` (0).

If the function fails, the return value is a non-zero error code. To get extended error information, call the [GetErrorInfo](geterrorinfo.md) function.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** WMINet_Utils.idl

 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
