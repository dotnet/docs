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
helpviewer_keywords:
  - "IMetaDataValidate::ValidatorInit method [.NET Framework metadata]"
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
 [in] A value of the [CorValidatorModuleType](corvalidatormoduletype-enumeration.md) enumeration that specifies the type of the module in the current metadata scope.

 `pUnk`
 [in] A pointer to an [IUnknown](/cpp/atl/iunknown) instance that serves as a function callback for validation errors.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataValidate Interface](imetadatavalidate-interface.md)
