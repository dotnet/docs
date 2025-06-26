---
description: "Learn more about: ICLRErrorReportingManager::BeginCustomDump Method"
title: "ICLRErrorReportingManager::BeginCustomDump Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRErrorReportingManager.BeginCustomDump"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRErrorReportingManager::BeginCustomDump"
helpviewer_keywords:
  - "ICLRErrorReportingManager::BeginCustomDump method [.NET Framework hosting]"
  - "BeginCustomDump method"
topic_type:
  - "apiref"
---
# ICLRErrorReportingManager::BeginCustomDump Method

Specifies the configuration of custom heap dumps for error reporting.

## Syntax

```cpp
HRESULT BeginCustomDump (
    [in] ECustomDumpFlavor dwFlavor,
    [in] DWORD dwNumItems,
    [in, size_is(dwNumItems), length_is(dwNumItems)] CustomDumpItem items[],
    DWORD dwReserved
);
```

## Parameters

 `dwFlavor`
 [in] A [ECustomDumpFlavor](ecustomdumpflavor-enumeration.md) value that indicates the kind of heap dump upon which to build the custom heap dump.

 `dwNumItems`
 [in] The length of the `items` array. If `dwFlavor` is not DUMP_FLAVOR_Mini, `dwNumItems` should be zero.

 `items`
 [in] An array of [CustomDumpItem](customdumpitem-structure.md) instances, specifying the items to add to the mini-dump. If `dwFlavor` is not DUMP_FLAVOR_Mini, `items` should be null.

 `dwReserved`
 [in] Reserved for future use.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The `BeginCustomDump` method sets custom heap dump configuration. The [EndCustomDump](iclrerrorreportingmanager-endcustomdump-method.md) method clears the custom heap dump configuration and frees any associated state. It should be called after the custom heap dump is complete.

> [!IMPORTANT]
> Failure to call `EndCustomDump` causes memory to leak.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [CustomDumpItem Structure](customdumpitem-structure.md)
- [ECustomDumpFlavor Enumeration](ecustomdumpflavor-enumeration.md)
- [ICLRErrorReportingManager Interface](iclrerrorreportingmanager-interface.md)
