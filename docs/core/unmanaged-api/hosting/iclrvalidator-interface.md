---
description: "Learn more about: ICLRValidator Interface"
title: "ICLRValidator Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRValidator"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRValidator"
helpviewer_keywords:
  - "ICLRValidator interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRValidator Interface

Provides methods for validating portable executable (PE) images and reporting validation errors.

## Methods

|Method|Description|
|------------|-----------------|
|[FormatEventInfo Method](iclrvalidator-formateventinfo-method.md)|Gets a detailed message about the specified validation error.|
|[Validate Method](iclrvalidator-validate-method.md)|Validates the portable executable or common intermediate language (CIL) in the specified file.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** IValidator.idl, IValidator.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRErrorReportingManager Interface](iclrerrorreportingmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [CLRRuntimeHost Coclass](clrruntimehost-coclass.md)
