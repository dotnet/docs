---
description: "Learn more about: CorBindToRuntimeByCfg Function"
title: "CorBindToRuntimeByCfg Function"
ms.date: "03/30/2017"
api_name:
  - "CorBindToRuntimeByCfg"
api_location:
  - "mscoree.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "CorBindToRuntimeByCfg"
helpviewer_keywords:
  - "CorBindToRuntimeByCfg function [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# CorBindToRuntimeByCfg Function

Loads the common language runtime (CLR) into a process by using version information that is read from an XML file.

 This function has been deprecated in the .NET Framework 4.

## Syntax

```cpp
HRESULT CorBindToRuntimeByCfg (
    [in]  IStream     *pCfgStream,
    [in]  DWORD        reserved,
    [in]  DWORD        startupFlags,
    [in]  REFCLSID     rclsid,
    [in]  REFIID       riid,
    [out] LPVOID FAR*  ppv
);
```

## Parameters

 `pCfgStream`
 [in] A pointer to an `IStream` object that reads the XML file.

 `reserved`
 [in] Reserved for future use. Use 0 (zero) as value.

 `startupFlags`
 [in] A value of the [STARTUP_FLAGS](startup-flags-enumeration.md) enumeration that specifies the startup behavior of the CLR.

 `rclsid`
 [in] The `CLSID` of the coclass that implements either the [ICorRuntimeHost](icorruntimehost-interface.md) or the [ICLRRuntimeHost](iclrruntimehost-interface.md) interface. Supported values are CLSID_CorRuntimeHost or CLSID_CLRRuntimeHost.

 `riid`
 [in] The `IID` of either the `ICorRuntimeHost` or the `ICLRRuntimeHost` interface. Supported values are IID_ICorRuntimeHost or IID_ICLRRuntimeHost.

 `ppv`
 [out] A pointer to the address of the returned interface.

## Remarks

 The format of the XML file is modeled after the standard application configuration file. For more information about XML files, see [Configuration File Schema](../../../framework/configure-apps/file-schema/index.md).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [CorBindToCurrentRuntime Function](corbindtocurrentruntime-function.md)
- [CorBindToRuntime Function](corbindtoruntime-function.md)
- [CorBindToRuntimeEx Function](corbindtoruntimeex-function.md)
- [CorBindToRuntimeHost Function](corbindtoruntimehost-function.md)
- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
