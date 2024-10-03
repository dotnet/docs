---
description: "Learn more about: ICorDebugSymbolProvider Interface"
title: "ICorDebugSymbolProvider Interface"
ms.date: "03/30/2017"
ms.assetid: 85b24196-b6c6-4bda-9de3-47180bd6ff96
---
# ICorDebugSymbolProvider Interface

Provides methods that can be used to retrieve debug symbol information.

## Methods

|Method|Description|
|------------|-----------------|
|[GetAssemblyImageBytes Method](icordebugsymbolprovider-getassemblyimagebytes-method.md)|Reads data from a merged assembly given a relative virtual address (RVA) in the merged assembly.|
|[GetAssemblyImageMetadata Method](icordebugsymbolprovider-getassemblyimagemetadata-method.md)|Returns the metadata from a merged assembly.|
|[GetCodeRange Method](icordebugsymbolprovider-getcoderange-method.md)|Gets the method start address and size given a relative virtual address (RVA) in a method.|
|[GetInstanceFieldSymbols Method](icordebugsymbolprovider-getinstancefieldsymbols-method.md)|Gets the instance field symbols that correspond to a typespec signature.|
|[GetMergedAssemblyRecords Method](icordebugsymbolprovider-getmergedassemblyrecords-method.md)|Gets the symbol records for all the merged assemblies.|
|[GetMethodLocalSymbols Method](icordebugsymbolprovider-getmethodlocalsymbols-method.md)|Gets a method's local symbols given the relative virtual address (RVA) of that method.|
|[GetMethodParameterSymbols Method](icordebugsymbolprovider-getmethodparametersymbols-method.md)|Gets a method's parameter symbols given the relative virtual address (RVA) of that method.|
|[GetMethodProps Method](icordebugsymbolprovider-getmethodprops-method.md)|Returns information about method properties, such as the method's metadata token and information about its generic parameters, given a relative virtual address (RVA) in that method.|
|[GetObjectSize Method](icordebugsymbolprovider-getobjectsize-method.md)|Returns the object size for an object based on its typespec signature.|
|[GetStaticFieldSymbols Method](icordebugsymbolprovider-getstaticfieldsymbols-method.md)|Gets the static field symbols that correspond to a typespec signature.|
|[GetTypeProps Method](icordebugsymbolprovider-gettypeprops-method.md)|Returns information about a type's properties, such as the number of signature of its generic parameters, given a relative virtual address (RVA) in a vtable.|

## Remarks

> [!NOTE]
> This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
