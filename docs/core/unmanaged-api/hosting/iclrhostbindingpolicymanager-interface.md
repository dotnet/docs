---
description: "Learn more about: ICLRHostBindingPolicyManager Interface"
title: "ICLRHostBindingPolicyManager Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRHostBindingPolicyManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRHostBindingPolicyManager"
helpviewer_keywords:
  - "ICLRHostBindingPolicyManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRHostBindingPolicyManager Interface

Provides methods for the host to evaluate current binding policy and communicate policy changes for a specified assembly.

## Methods

|Method|Description|
|------------|-----------------|
|[EvaluatePolicy Method](iclrhostbindingpolicymanager-evaluatepolicy-method.md)|Evaluates binding policy on behalf of the host.|
|[ModifyApplicationPolicy Method](iclrhostbindingpolicymanager-modifyapplicationpolicy-method.md)|Modifies the binding policy for the specified assembly, and creates a new version of the policy.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [IHostAssemblyStore Interface](ihostassemblystore-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
