---
description: "Learn more about: EBindPolicyLevels Enumeration"
title: "EBindPolicyLevels Enumeration"
ms.date: "03/30/2017"
api_name:
  - "EBindPolicyLevels"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "EBindPolicyLevels"
helpviewer_keywords:
  - "EBindPolicyLevels enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# EBindPolicyLevels Enumeration

Provides flags to specify the level at which to apply or modify assembly policy.

## Syntax

```cpp
typedef enum {
    ePolicyLevelNone         = 0x0,
    ePolicyLevelRetargetable = 0x1,
    ePolicyUnifiedToCLR      = 0x2,
    ePolicyLevelApp          = 0x4,
    ePolicyLevelPublisher    = 0x8,
    ePolicyLevelHost         = 0x10,
    ePolicyLevelAdmin        = 0x20
    ePolicyPortability       = 0x40
} EBindPolicyLevels;
```

## Members

|Member|Description|
|------------|-----------------|
|`ePolicyLevelAdmin`|Specifies that policy should be applied at the administrator level.|
|`ePolicyLevelApp`|Specifies that policy should be applied at the application level.|
|`ePolicyLevelHost`|Specifies that policy should be applied at the host level.|
|`ePolicyLevelNone`|Specifies no policy-level flags.|
|`ePolicyLevelPublisher`|Specifies that policy should be applied at the publisher level.|
|`ePolicyLevelRetargetable`|Specifies that policy should be applicable at variable levels.|
|`ePolicyPortability`|Specifies that policy should support portability between implementations of a .NET Framework assembly. See the [\<supportPortability>](../../../framework/configure-apps/file-schema/runtime/supportportability-element.md) configuration file element.|
|`ePolicyUnifiedToCLR`|Specifies that policy should be unified to that of the common language runtime (CLR).|

## Remarks

 This enumeration is passed to methods of the [ICLRHostBindingPolicyManager](iclrhostbindingpolicymanager-interface.md) interface to specify changes in application policy.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
