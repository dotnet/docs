---
description: "Learn more about: ICLRMetaHostPolicy::GetRequestedRuntime Method"
title: "ICLRMetaHostPolicy::GetRequestedRuntime Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRMetaHostPolicy.GetRequestedRuntime"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRMetaHostPolicy::GetRequestedRuntime"
helpviewer_keywords:
  - "GetRequestedRuntime method [.NET Framework hosting]"
  - "ICLRMetaHostPolicy::GetRequestedRuntime method [.NET Framework hosting]"
ms.assetid: 59ec1832-9cc1-4b5c-983d-03407e51de56
topic_type:
  - "apiref"
---

# ICLRMetaHostPolicy::GetRequestedRuntime Method

Provides an interface to a preferred version of the common language runtime (CLR) based on a hosting policy, managed assembly, version string, and configuration stream. This method does not actually load or activate the CLR, but simply returns the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface that represents the policy result. This method supersedes the [GetRequestedRuntimeInfo](getrequestedruntimeinfo-function.md), [GetRequestedRuntimeVersion](getrequestedruntimeversion-function.md), [CorBindToRuntimeHost](corbindtoruntimehost-function.md), [CorBindToRuntimeByCfg](corbindtoruntimebycfg-function.md), and [GetCORRequiredVersion](getcorrequiredversion-function.md) methods.

## Syntax

```cpp
HRESULT GetRequestedRuntime(
    [in]  METAHOST_POLICY_FLAGS dwPolicyFlags,
    [in]  LPCWSTR pwzBinary,
    [in]  IStream *pCfgStream,
    [in, out, size_is(*pcchVersion)] LPWSTR pwzVersion,
    [in, out]  DWORD *pcchVersion,
    [out, size_is(*pcchImageVersion)] LPWSTR pwzImageVersion,
    [in, out]  DWORD *pcchImageVersion,
    [out] DWORD *pdwConfigFlags,
    [in]  REFIID  riid
    [out, iid_is(riid), retval] LPVOID *ppRuntime);
```

## Parameters

|Name|Description|
|----------|-----------------|
|`dwPolicyFlags`|[in] Required. Specifies a member of the [METAHOST_POLICY_FLAGS](metahost-policy-flags-enumeration.md) enumeration, representing a binding policy, and any number of modifiers. The only policy that is currently available is [METAHOST_POLICY_HIGHCOMPAT](metahost-policy-flags-enumeration.md).<br /><br /> Modifiers include [METAHOST_POLICY_EMULATE_EXE_LAUNCH](metahost-policy-flags-enumeration.md), [METAHOST_POLICY_APPLY_UPGRADE_POLICY](metahost-policy-flags-enumeration.md), [METAHOST_POLICY_SHOW_ERROR_DIALOG](metahost-policy-flags-enumeration.md), [METAHOST_POLICY_USE_PROCESS_IMAGE_PATH](metahost-policy-flags-enumeration.md), and [METAHOST_POLICY_ENSURE_SKU_SUPPORTED](metahost-policy-flags-enumeration.md).|
|`pwzBinary`|[in] Optional. Specifies the assembly file path.|
|`pCfgStream`|[in] Optional. Specifies the configuration file as a <xref:System.Runtime.InteropServices.ComTypes.IStream?displayProperty=nameWithType>.|
|`pwzVersion`|[in, out] Optional. Specifies or returns the preferred CLR version to be loaded.|
|`pcchVersion`|[in, out] Required. Specifies the expected size of `pwzVersion` as input, to avoid buffer overruns. If `pwzVersion` is null, `pcchVersion` contains the expected size of `pwzVersion` when `GetRequestedRuntime` returns, to allow pre-allocation; otherwise, `pcchVersion` contains the number of characters written to `pwzVersion`.|
|`pwzImageVersion`|[out] Optional. When `GetRequestedRuntime` returns, contains the CLR version corresponding to the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface that is returned.|
|`pcchImageVersion`|[in, out] Optional. Specifies the size of `pwzImageVersion` as input to avoid buffer overruns. If `pwzImageVersion` is null, `pcchImageVersion` contains the required size of `pwzImageVersion` when `GetRequestedRuntime` returns, to allow pre-allocation.|
|`pdwConfigFlags`|[out] Optional. If `GetRequestedRuntime` uses a configuration file during the binding process, when it returns, `pdwConfigFlags` contains a [METAHOST_CONFIG_FLAGS](metahost-config-flags-enumeration.md) value that indicates whether the [\<startup>](../../configure-apps/file-schema/startup/startup-element.md) element has the `useLegacyV2RuntimeActivationPolicy` attribute set, and the value of the attribute. Apply the [METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_MASK](metahost-config-flags-enumeration.md) mask to `pdwConfigFlags` to get the values relevant to `useLegacyV2RuntimeActivationPolicy`.|
|`riid`|[in] Specifies the interface identifier IID_ICLRRuntimeInfo for the requested [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface.|
|`ppRuntime`|[out] When `GetRequestedRuntime` returns, contains a pointer to the corresponding [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface.|

## Remarks

When this method succeeds, it has the side effect of combining additional flags with the current default startup flags of the returned runtime interface, if and only if one or more of the following elements exist in the configuration stream within the `<configuration><runtime>` section:

- `<gcServer enabled="true"/>` causes `STARTUP_SERVER_GC` to be set.

- `<etwEnable enabled="true"/>` causes `STARTUP_ETW` to be set.

- `<appDomainResourceMonitoring enabled="true"/>` causes `STARTUP_ARM` to be set.

The resulting default `STARTUP_FLAGS` value is the bitwise OR combination of the values that are set from the preceding list with the default startup flags.

## Return Value

This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method completed successfully.|
|E_POINTER|`pwzVersion` is not null and `pcchVersion` is null.<br /><br /> -or-<br /><br /> `pwzImageVersion` is not null and `pcchImageVersion` is null.|
|E_INVALIDARG|`dwPolicyFlags` does not specify `METAHOST_POLICY_HIGHCOMPAT`.|
|ERROR_INSUFFICIENT_BUFFER|The memory allocated to `pwzVersion` is inadequate.<br /><br /> -or-<br /><br /> The memory allocated to `pwzImageVersion` is inadequate.|
|CLR_E_SHIM_RUNTIMELOAD|`dwPolicyFlags` includes METAHOST_POLICY_APPLY_UPGRADE_POLICY, and both `pwzVersion` and `pcchVersion` are null.|

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** MetaHost.h

**Library:** Included as a resource in MSCorEE.dll

**.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [ICLRMetaHostPolicy Interface](iclrmetahostpolicy-interface.md)
- [CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5](clr-hosting-interfaces-added-in-the-net-framework-4-and-4-5.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
