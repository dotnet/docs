---
title: CreateInstanceEnumWmi function (Unmanaged API Reference)
description: The  CreateInstanceEnumWmi function returns an enumerator containing instances of a specified class that meet selection criteria.
ms.date: "11/06/2017"
api_name:
  - "CreateInstanceEnumWmi"
api_location:
  - "WMINet_Utils.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "CreateInstanceEnumWmi"
helpviewer_keywords:
  - "CreateInstanceEnumWmi function [.NET WMI and performance counters]"
topic_type:
  - "Reference"
---

# CreateInstanceEnumWmi function

Returns an enumerator that returns the instances of a specified class that meet specified selection criteria.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
HRESULT CreateInstanceEnumWmi (
   [in] BSTR                    strFilter,
   [in] long                    lFlags,
   [in] IWbemContext*           pCtx,
   [out] IEnumWbemClassObject** ppEnum,
   [in] DWORD                   authLevel,
   [in] DWORD                   impLevel,
   [in] IWbemServices*          pCurrentNamespace,
   [in] BSTR                    strUser,
   [in] BSTR                    strPassword,
   [in] BSTR                    strAuthority
);
```

## Parameters

`strFilter`\
[in] The name of the class for which instances are desired. This parameter cannot be `null`.

`lFlags`\
[in] A combination of flags that affect the behavior of this function. The following values are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_USE_AMENDED_QUALIFIERS` | 0x20000 | If set, the function retrieves the amended qualifiers stored in the localized namespace of the current connection's locale. <br/> If not set, the function retrieves only the qualifiers stored in the immediate namespace. |
| `WBEM_FLAG_DEEP` | 0 | The enumeration includes this and all subclasses in the hierarchy. |
| `WBEM_FLAG_SHALLOW` | 1 | The enumeration includes only pure instances of this class and excludes all instances of subclasses that supply properties not found in this class. |
| `WBEM_FLAG_RETURN_IMMEDIATELY` | 0x10 | The flag causes a semisynchronous call. |
| `WBEM_FLAG_FORWARD_ONLY` | 0x20 | The function returns a forward-only enumerator. Typically, forward-only enumerators are faster and use less memory than conventional enumerators, but they do not allow calls to [Clone](clone.md). |
| `WBEM_FLAG_BIDIRECTIONAL` | 0 | WMI retains pointers to objects in the enumeration until they are released. |

The recommended flags are `WBEM_FLAG_RETURN_IMMEDIATELY` and `WBEM_FLAG_FORWARD_ONLY` for best performance.

`pCtx`\
[in] Typically, this value is `null`. Otherwise, it is a pointer to an [IWbemContext](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemcontext) instance that may be used by the provider that is providing the requested instances.

`ppEnum`\
[out] Receives the pointer to the enumerator.

`authLevel`\
[in] The authorization level.

`impLevel`\
[in] The impersonation level.

`pCurrentNamespace`\
[in] A pointer to an [IWbemServices](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemservices) object that represents the current namespace.

`strUser`\
[in] The user name. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

`strPassword`\
[in] The password. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

`strAuthority`\
[in] The domain name of the user. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_ACCESS_DENIED` | 0x80041003 | The user does not have permission to view instances of the specified class. |
| `WBEM_E_FAILED` | 0x80041001 | An unspecified error has occurred. |
| `WBEM_E_INVALID_CLASS` | 0x80041010 | `strFilter` does not exist. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_E_SHUTTING_DOWN` | 0x80041033 | WMI was probably stopped and restarting. Call [ConnectServerWmi](connectserverwmi.md) again. |
| `WBEM_E_TRANSPORT_FAILURE` | 0x80041015 | The remote procedure call (RPC) link between the current process and WMI has failed. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |

## Remarks

This function wraps a call to the [IWbemServices::CreateClassEnum](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemservices-createinstanceenum) method.

Note that the returned enumerator can have zero elements.

If the function call fails, you can obtain additional error information by calling the [GetErrorInfo](geterrorinfo.md) function.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** WMINet_Utils.idl

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
