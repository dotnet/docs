---
description: "Learn more about: IMetaDataImport Interface"
title: "IMetaDataImport Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport"
helpviewer_keywords:
  - "IMetaDataImport interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport Interface

Provides methods for importing and manipulating existing metadata from a portable executable (PE) file or other source, such as a type library or a stand-alone, run-time metadata binary.

## Methods

|Method|Description|
|------------|-----------------|
|[CloseEnum Method](imetadataimport-closeenum-method.md)|Closes the enumerator with the specified handle.|
|[CountEnum Method](imetadataimport-countenum-method.md)|Gets the number of elements in the enumerator with the specified handle.|
|[EnumCustomAttributes Method](imetadataimport-enumcustomattributes-method.md)|Enumerates a list of custom attribute-definition tokens associated with the specified type or member.|
|[EnumEvents Method](imetadataimport-enumevents-method.md)|Enumerates event definition tokens for the specified TypeDef token.|
|[EnumFields Method](imetadataimport-enumfields-method.md)|Enumerates FieldDef tokens for the type referenced by the specified TypeDef token.|
|[EnumFieldsWithName Method](imetadataimport-enumfieldswithname-method.md)|Enumerates FieldDef tokens of the specified type with the specified name.|
|[EnumInterfaceImpls Method](imetadataimport-enuminterfaceimpls-method.md)|Enumerates MethodDef tokens representing interface implementations.|
|[EnumMemberRefs Method](imetadataimport-enummemberrefs-method.md)|Enumerates MemberRef tokens representing members of the specified type.|
|[EnumMembers Method](imetadataimport-enummembers-method.md)|Enumerates MemberDef tokens representing members of the specified type.|
|[EnumMembersWithName Method](imetadataimport-enummemberswithname-method.md)|Enumerates MemberDef tokens representing members of the specified type with the specified name.|
|[EnumMethodImpls Method](imetadataimport-enummethodimpls-method.md)|Enumerates MethodBody and MethodDeclaration tokens representing methods of the specified type.|
|[EnumMethods Method](imetadataimport-enummethods-method.md)|Enumerates MethodDef tokens representing methods of the specified type.|
|[EnumMethodSemantics Method](imetadataimport-enummethodsemantics-method.md)|Enumerates the properties and the property-change events to which the specified method is related.|
|[EnumMethodsWithName Method](imetadataimport-enummethodswithname-method.md)|Enumerates methods that have the specified name and that are defined by the type referenced by the specified TypeDef token.|
|[EnumModuleRefs Method](imetadataimport-enummodulerefs-method.md)|Enumerates ModuleRef tokens that represent imported modules.|
|[EnumParams Method](imetadataimport-enumparams-method.md)|Enumerates ParamDef tokens representing the parameters of the method referenced by the specified MethodDef token.|
|[EnumPermissionSets Method](imetadataimport-enumpermissionsets-method.md)|Enumerates permissions for the objects in a specified metadata scope.|
|[EnumProperties Method](imetadataimport-enumproperties-method.md)|Enumerates PropertyDef tokens representing the properties of the type referenced by the specified TypeDef token.|
|[EnumSignatures Method](imetadataimport-enumsignatures-method.md)|Enumerates Signature tokens representing stand-alone signatures in the current scope.|
|[EnumTypeDefs Method](imetadataimport-enumtypedefs-method.md)|Enumerates TypeDef tokens representing all types within the current scope.|
|[EnumTypeRefs Method](imetadataimport-enumtyperefs-method.md)|Enumerates TypeRef tokens defined in the current metadata scope.|
|[EnumTypeSpecs Method](imetadataimport-enumtypespecs-method.md)|Enumerates TypeSpec tokens defined in the current metadata scope.|
|[EnumUnresolvedMethods Method](imetadataimport-enumunresolvedmethods-method.md)|Enumerates MemberDef tokens representing the unresolved methods in the current metadata scope.|
|[EnumUserStrings Method](imetadataimport-enumuserstrings-method.md)|Enumerates String tokens representing hard-coded strings in the current metadata scope.|
|[FindField Method](imetadataimport-findfield-method.md)|Gets the FieldDef token for the field that is a member of the specified type, and has the specified name and metadata signature.|
|[FindMember Method](imetadataimport-findmember-method.md)|Gets a pointer to the MemberDef token for the member defined by the specified type with the specified name and metadata signature.|
|[FindMemberRef Method](imetadataimport-findmemberref-method.md)|Gets a pointer to the MemberRef token for the member defined by the specified type with the specified name and metadata signature.|
|[FindMethod Method](imetadataimport-findmethod-method.md)|Gets a pointer to the MethodDef token for the method defined by the specified type with the specified name and metadata signature.|
|[FindTypeDefByName Method](imetadataimport-findtypedefbyname-method.md)|Gets a pointer to the TypeDef metadata token for the type with the specified name.|
|[FindTypeRef Method](imetadataimport-findtyperef-method.md)|Gets a pointer to the TypeRef metadata token that references the type in the specified search scope with the specified name.|
|[GetClassLayout Method](imetadataimport-getclasslayout-method.md)|Gets layout information for the class referenced by the specified TypeDef token.|
|[GetCustomAttributeByName Method](imetadataimport-getcustomattributebyname-method.md)|Gets the value of the custom attribute, given its name.|
|[GetCustomAttributeProps Method](imetadataimport-getcustomattributeprops-method.md)|Gets the value of the custom attribute, given its metadata token.|
|[GetEventProps Method](imetadataimport-geteventprops-method.md)|Gets metadata information (including the declaring type, the add and remove methods for delegates, and any flags and other associated data) for the event represented by the specified event token.|
|[GetFieldMarshal Method](imetadataimport-getfieldmarshal-method.md)|Gets a pointer to the native, unmanaged type of the field represented by the specified Field metadata token.|
|[GetFieldProps Method](imetadataimport-getfieldprops-method.md)|Gets metadata associated with the field referenced by the specified FieldDef token.|
|[GetInterfaceImplProps Method](imetadataimport-getinterfaceimplprops-method.md)|Gets a pointer to the metadata tokens for the type that implements the specified method and for the interface that declares that method.|
|[GetMemberProps Method](imetadataimport-getmemberprops-method.md)|Gets metadata information (including the name, binary signature, and relative virtual address) of the type member referenced by the specified metadata token.|
|[GetMemberRefProps Method](imetadataimport-getmemberrefprops-method.md)|Gets metadata associated with the member referenced by the specified token.|
|[GetMethodProps Method](imetadataimport-getmethodprops-method.md)|Gets the metadata associated with the method referenced by the specified MethodDef token.|
|[GetMethodSemantics Method](imetadataimport-getmethodsemantics-method.md)|Gets a pointer to the relationship between the method referenced by the specified MethodDef token and the paired property and event referenced by the specified EventProp token.|
|[GetModuleFromScope Method](imetadataimport-getmodulefromscope-method.md)|Gets a pointer to the metadata token for the module referenced in the current metadata scope.|
|[GetModuleRefProps Method](imetadataimport-getmodulerefprops-method.md)|Gets the name of the module referenced by the specified metadata token.|
|[GetNameFromToken Method](imetadataimport-getnamefromtoken-method.md)|Gets the UTF-8 name of the object referenced by the specified metadata token.|
|[GetNativeCallConvFromSig Method](imetadataimport-getnativecallconvfromsig-method.md)|Gets the native calling convention for the method that is represented by the specified signature pointer.|
|[GetNestedClassProps Method](imetadataimport-getnestedclassprops-method.md)|Gets the TypeDef token for the enclosing parent type of the specified nested type.|
|[GetParamForMethodIndex Method](imetadataimport-getparamformethodindex-method.md)|Gets a pointer to the token that represents the parameter at the specified ordinal position in the sequence of method parameters for the method represented by the specified MethodDef token.|
|[GetParamProps Method](imetadataimport-getparamprops-method.md)|Gets metadata values for the parameter referenced by the specified ParamDef token.|
|[GetPermissionSetProps Method](imetadataimport-getpermissionsetprops-method.md)|Gets the metadata associated with the System.Security.PermissionSet represented by the specified Permission token.|
|[GetPinvokeMap](imetadataimport-getpinvokemap-method.md)|Gets a ModuleRef token to represent the target assembly of a PInvoke call.|
|[GetPropertyProps Method](imetadataimport-getpropertyprops-method.md)|Gets the metadata associated with the property represented by the specified token.|
|[GetRVA Method](imetadataimport-getrva-method.md)|Gets the offset of the relative virtual address of the code object represented by the specified token.|
|[GetScopeProps Method](imetadataimport-getscopeprops-method.md)|Gets the name and optionally the version identifier of the assembly or module in the current metadata scope.|
|[GetSigFromToken Method](imetadataimport-getsigfromtoken-method.md)|Gets the binary metadata signature associated with the specified token.|
|[GetTypeDefProps Method](imetadataimport-gettypedefprops-method.md)|Returns metadata information for the type represented by the specified TypeDef token.|
|[GetTypeRefProps Method](imetadataimport-gettyperefprops-method.md)|Gets the metadata associated with the type referenced by the specified TypeRef token.|
|[GetTypeSpecFromToken Method](imetadataimport-gettypespecfromtoken-method.md)|Gets the binary metadata signature of the type specification represented by the specified token.|
|[GetUserString Method](imetadataimport-getuserstring-method.md)|Gets the literal string represented by the specified metadata token.|
|[IsGlobal Method](imetadataimport-isglobal-method.md)|Gets a value indicating whether the field, method, or type represented by the specified metadata token has global scope.|
|[IsValidToken Method](imetadataimport-isvalidtoken-method.md)|Gets a value indicating whether the specified token holds a valid reference to a code object.|
|[ResetEnum Method](imetadataimport-resetenum-method.md)|Resets the specified enumerator to the specified position.|
|[ResolveTypeRef Method](imetadataimport-resolvetyperef-method.md)|Gets type information for the type referenced by the specified TypeRef token.|

## Remarks

 The design of the `IMetaDataImport` interface is intended primarily to be used by tools and services that will be importing type information (for example, development tools) or managing deployed components (for example, resolution/activation services). The methods in `IMetaDataImport` fall into the following task categories:

- Enumerating collections of items in the metadata scope.

- Finding an item that has a specific set of characteristics.

- Getting properties of a specified item.

- The Get methods are specifically designed to return single-valued properties of a metadata item. When the property is a reference to another item, a token for that item is returned. Any pointer input type can be NULL to indicate that the particular value is not being requested. To obtain properties that are essentially collection objects (for example, the collection of interfaces that a class implements), use the enumeration methods.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Interfaces](metadata-interfaces.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
