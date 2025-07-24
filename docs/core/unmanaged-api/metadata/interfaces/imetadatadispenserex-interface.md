---
description: "Learn more about: IMetaDataDispenserEx Interface"
title: "IMetaDataDispenserEx Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenserEx"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenserEx"
topic_type:
  - "apiref"
---
# IMetaDataDispenserEx Interface

Extends the [IMetaDataDispenser Interface](imetadatadispenser-interface.md) interface to provide the capability to control how the metadata APIs operate on the current metadata scope.

## Methods

|Method|Description|
|------------|-----------------|
|[FindAssembly Method](imetadatadispenserex-findassembly-method.md)|This method is not implemented. If called, it returns E_NOTIMPL.|
|[FindAssemblyModule Method](imetadatadispenserex-findassemblymodule-method.md)|This method is not implemented. If called, it returns E_NOTIMPL.|
|[GetCORSystemDirectory Method](imetadatadispenserex-getcorsystemdirectory-method.md)|Gets the directory that holds the current common language runtime (CLR). This method is supported only for use by out-of-process debuggers. If called from another component, it will return E_NOTIMPL.|
|[GetOption Method](imetadatadispenserex-getoption-method.md)|Gets the value of the specified option for the current metadata scope. The option controls how calls to the current metadata scope are handled.|
|[OpenScopeOnITypeInfo Method](imetadatadispenserex-openscopeonitypeinfo-method.md)|This method is not implemented. If called, it returns E_NOTIMPL.|
|[SetOption Method](imetadatadispenserex-setoption-method.md)|Sets the specified option to a given value for the current metadata scope. The option controls how calls to the current metadata scope are handled.|

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetadata interfaces](imetadata-interfaces.md)
- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
