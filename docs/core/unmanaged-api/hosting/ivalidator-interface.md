---
description: "Learn more about: IValidator Interface"
title: "IValidator Interface"
ms.date: "03/30/2017"
api_name:
  - "IValidator"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IValidator"
helpviewer_keywords:
  - "IValidator interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IValidator Interface

Provides methods for validating portable executable (PE) images and reporting validation errors.

## Methods

|Method|Description|
|------------|-----------------|
|Validate|Validates the specified PE or common intermediate language (CIL) file.|
|FormatEventInfo|Gets the error message corresponding to the specified validation error.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** IValidator.idl, IValidator.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Interfaces](hosting-interfaces.md)
- [CorRuntimeHost Coclass](corruntimehost-coclass.md)
