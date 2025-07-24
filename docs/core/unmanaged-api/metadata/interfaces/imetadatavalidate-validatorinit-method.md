---
description: "Learn more about: IMetaDataValidate::ValidatorInit Method"
title: "IMetaDataValidate::ValidatorInit Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataValidate.ValidatorInit"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataValidate::ValidatorInit"
  - "ValidatorInit method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataValidate::ValidatorInit Method

Sets a flag that specifies the type of the module in the current metadata scope, and registers the specified callback method for validation errors.

## Syntax

```cpp
HRESULT ValidatorInit (
   [in] DWORD       dwModuleType,
   [in] IUnknown    *pUnk
);
```

## Parameters

 `dwModule`
 [in] A value of the [CorValidatorModuleType](../enumerations/corvalidatormoduletype-enumeration.md) enumeration that specifies the type of the module in the current metadata scope.

 `pUnk`
 [in] A pointer to an [IUnknown](/cpp/atl/iunknown) instance that serves as a function callback for validation errors.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataValidate Interface](imetadatavalidate-interface.md)
