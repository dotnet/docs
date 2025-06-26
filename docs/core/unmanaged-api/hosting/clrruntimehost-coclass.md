---
description: "Learn more about: CLRRuntimeHost Coclass"
title: "CLRRuntimeHost Coclass"
ms.date: "03/30/2017"
api_name:
  - "CLRRuntimeHost Coclass"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRRuntimeHost"
helpviewer_keywords:
  - "CLRRuntimeHost coclass [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# CLRRuntimeHost Coclass

Provides interfaces for managing code execution by the runtime.

## Syntax

```cpp
coclass CLRRuntimeHost {
    [default] interface  ICLRRuntimeHost;
    interface            ICLRValidator;
};
```

## Interfaces

|Interface|Description|
|---------------|-----------------|
|[ICLRRuntimeHost Interface](iclrruntimehost-interface.md)|Provides methods for controlling the execution of applications by the runtime.|
|[ICLRValidator Interface](iclrvalidator-interface.md)|Provides methods for validation of portable executable images and for detailed reporting of validation errors.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.idl

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Coclasses](hosting-coclasses.md)
