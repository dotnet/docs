---
description: "Learn more about: ICLRHostProtectionManager Interface"
title: "ICLRHostProtectionManager Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRHostProtectionManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRHostProtectionManager"
helpviewer_keywords:
  - "ICLRHostProtectionManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRHostProtectionManager Interface

Enables the host to block specific managed classes, methods, properties, and fields from running in partially trusted code.

## Methods

|Method|Description|
|------------|-----------------|
|[SetEagerSerializeGrantSets](iclrhostprotectionmanager-seteagerserializegrantsets-method.md)|Provides a guarantee that certain rare race conditions that can cause fatal common language runtime (CLR) errors will never arise.|
|[SetProtectedCategories Method](iclrhostprotectionmanager-setprotectedcategories-method.md)|Specifies the categories of managed types and members that should be blocked from running in partially trusted code.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EApiCategories Enumeration](eapicategories-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
