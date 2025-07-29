---
description: "Learn more about: IMetaDataImport2 Interface"
title: "IMetaDataImport2 Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2"
topic_type:
  - "apiref"
---
# IMetaDataImport2 Interface

Extends the [IMetaDataImport](imetadataimport-interface.md) interface to provide the capability of working with generic types.

## Methods

|Method|Description|
|------------|-----------------|
|[EnumGenericParamConstraints Method](imetadataimport2-enumgenericparamconstraints-method.md)|Gets an enumerator for an array of generic parameter constraints associated with the generic parameter represented by the specified token.|
|[EnumGenericParams Method](imetadataimport2-enumgenericparams-method.md)|Gets an enumerator for an array of generic parameter tokens associated with the specified TypeDef or MethodDef token.|
|[EnumMethodSpecs Method](imetadataimport2-enummethodspecs-method.md)|Gets an enumerator for an array of MethodSpec tokens associated with the specified MethodDef or MemberRef token.|
|[GetGenericParamConstraintProps Method](imetadataimport2-getgenericparamconstraintprops-method.md)|Gets the metadata associated with the generic parameter constraint represented by the specified constraint token.|
|[GetGenericParamProps Method](imetadataimport2-getgenericparamprops-method.md)|Gets the metadata associated with the generic parameter represented by the specified token.|
|[GetMethodSpecProps Method](imetadataimport2-getmethodspecprops-method.md)|Gets the metadata signature of the method referenced by the specified MethodSpec token.|
|[GetPEKind Method](imetadataimport2-getpekind-method.md)|Gets a value identifying the nature of the code in a portable executable (PE) file, typically a DLL or EXE file, defined in the current metadata scope|
|[GetVersionString Method](imetadataimport2-getversionstring-method.md)|Gets the version number of the runtime that was used to build the assembly.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- <xref:System.Reflection.PortableExecutableKinds>
- [Metadata Interfaces](metadata-interfaces.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
