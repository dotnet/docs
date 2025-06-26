---
description: "Learn more about: ICLRMetaHost Interface"
title: "ICLRMetaHost Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRMetaHost"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRMetaHost"
helpviewer_keywords:
  - "ICLRMetaHost interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRMetaHost Interface

Provides methods that return a specific version of the common language runtime (CLR) based on its version number, list all installed CLRs, list all runtimes that are loaded in a specified process, discover the CLR version used to compile an assembly, exit a process with a clean runtime shutdown, and query legacy API binding.

## Methods

|Method|Description|
|------------|-----------------|
|[EnumerateInstalledRuntimes Method](iclrmetahost-enumerateinstalledruntimes-method.md)|Returns an enumeration that contains a valid [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface pointer for each CLR version that is installed on a computer.|
|[EnumerateLoadedRuntimes Method](iclrmetahost-enumerateloadedruntimes-method.md)|Returns an enumeration that contains a valid [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface pointer for each CLR that is loaded in a given process. This method supersedes [GetVersionFromProcess](getversionfromprocess-function.md).|
|[ExitProcess Method](iclrmetahost-exitprocess-method.md)|Attempts to shut down all loaded runtimes gracefully and then terminates the process. Supersedes the [CorExitProcess](corexitprocess-function.md) function.|
|[GetRuntime Method](iclrmetahost-getruntime-method.md)|Gets the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface that corresponds to a particular CLR version. This method supersedes the [CorBindToRuntimeEx](corbindtoruntimeex-function.md) function used with the [STARTUP_LOADER_SAFEMODE](startup-flags-enumeration.md) flag.|
|[GetVersionFromFile Method](iclrmetahost-getversionfromfile-method.md)|Gets the assembly's original .NET Framework compilation version (stored in the metadata), given its file path. This method supersedes [GetFileVersion](getfileversion-function.md).|
|[QueryLegacyV2RuntimeBinding Method](iclrmetahost-querylegacyv2runtimebinding-method.md)|Returns an interface that represents a runtime to which legacy activation policy has been bound, for example by using the `useLegacyV2RuntimeActivationPolicy` attribute on the [\<startup> Element](../../../framework/configure-apps/file-schema/startup/startup-element.md) configuration file entry, by direct use of the legacy activation APIs, or by calling the [ICLRRuntimeInfo::BindAsLegacyV2Runtime](iclrruntimeinfo-bindaslegacyv2runtime-method.md) method.|
|[RequestRuntimeLoadedNotification Method](iclrmetahost-requestruntimeloadednotification-method.md)|Guarantees a callback to the specified function pointer when a CLR version is first loaded, but not yet started. This method supersedes [LockClrVersion](lockclrversion-function.md)|

## Remarks

 The only way to get an instance of this interface is by calling the [CLRCreateInstance](clrcreateinstance-function.md) function as follows:

```cpp
ICLRMetaHost *pMetaHost = NULL;
HRESULT hr = CLRCreateInstance(CLSID_CLRMetaHost,
                   IID_ICLRMetaHost, (LPVOID*)&pMetaHost);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
