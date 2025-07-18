---
description: "Learn more about: IMetaDataEmit Interface"
title: "IMetaDataEmit Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit"
helpviewer_keywords:
  - "IMetaDataEmit interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit Interface

Provides methods to create, modify, and save metadata about the assembly in the currently defined scope. The metadata can be stored in memory or saved to disk.

## Methods

|Method|Description|
|------------|-----------------|
|[ApplyEditAndContinue Method](imetadataemit-applyeditandcontinue-method.md)|Updates the current assembly scope with the changes made in the specified `pImport`.|
|[DefineCustomAttribute Method](imetadataemit-definecustomattribute-method.md)|Creates a definition for a custom attribute with the specified metadata signature, to be attached to the specified object, and gets a token to that custom attribute definition.|
|[DefineEvent Method](imetadataemit-defineevent-method.md)|Creates a definition for an event with the specified metadata signature, and gets a token to that event definition.|
|[DefineField Method](imetadataemit-definefield-method.md)|Creates a definition for a field with the specified metadata signature, and gets a token to that field definition.|
|[DefineImportMember Method](imetadataemit-defineimportmember-method.md)|Creates a definition for a member of a type that is defined in a module outside the current scope, and gets a token for that reference definition.|
|[DefineImportType Method](imetadataemit-defineimporttype-method.md)|Creates a definition for a reference to a type that is defined in a module outside the current scope, and gets a token to that reference definition.|
|[DefineMemberRef Method](imetadataemit-definememberref-method.md)|Creates a definition for a reference to a member of a module outside the current scope, and gets a token to that reference definition.|
|[DefineMethod Method](imetadataemit-definemethod-method.md)|Creates a definition for a method with the specified signature, and returns a token to that method definition.|
|[DefineMethodImpl Method](imetadataemit-definemethodimpl-method.md)|Creates a definition for implementation of a method inherited from an interface, and returns a token to that method-implementation definition.|
|[DefineModuleRef Method](imetadataemit-definemoduleref-method.md)|Creates the metadata signature for a module with the specified name.|
|[DefineNestedType Method](imetadataemit-definenestedtype-method.md)|Creates the metadata signature of a type definition and returns an `mdTypeDef` token for that type, additionally specifying that the defined type is a member of the type referenced by `tdEncloser`.|
|[DefineParam Method](imetadataemit-defineparam-method.md)|Creates a parameter definition with the specified signature for the method referenced by the specified token, and gets a token for that parameter definition.|
|[DefinePermissionSet Method](imetadataemit-definepermissionset-method.md)|Creates a definition for a permission set with the specified metadata signature, and gets a token to that permission set definition.|
|[DefinePinvokeMap Method](imetadataemit-definepinvokemap-method.md)|Sets features of the PInvoke signature of the method referenced by the specified token.|
|[DefineProperty Method](imetadataemit-defineproperty-method.md)|Creates a property definition for the specified type, with the specified `get` and `set` method accessors, and gets a token to that property definition.|
|[DefineSecurityAttributeSet Method](imetadataemit-definesecurityattributeset-method.md)|Creates a set of security permissions to attach to the object referenced by the specified token.|
|[DefineTypeDef Method](imetadataemit-definetypedef-method.md)|Creates a type definition for a common language runtime type, and gets a metadata token to that type definition.|
|[DefineTypeRefByName Method](imetadataemit-definetyperefbyname-method.md)|Gets a metadata token for a type that is defined in another module outside the current scope.|
|[DefineUserString Method](imetadataemit-defineuserstring-method.md)|Gets a metadata token for the specified literal string.|
|[DeleteClassLayout Method](imetadataemit-deleteclasslayout-method.md)|Destroys the class layout metadata signature for the type referenced by the specified token.|
|[DeleteFieldMarshal Method](imetadataemit-deletefieldmarshal-method.md)|Destroys the PInvoke marshalling metadata signature for the object referenced by the specified token.|
|[DeletePinvokeMap Method](imetadataemit-deletepinvokemap-method.md)|Destroys the PInvoke mapping metadata for the object referenced by the specified token.|
|[DeleteToken Method](imetadataemit-deletetoken-method.md)|Deletes the specified token from the current metadata scope.|
|[GetSaveSize Method](imetadataemit-getsavesize-method.md)|Gets the estimated binary size of the assembly in the current scope.|
|[GetTokenFromSig Method](imetadataemit-gettokenfromsig-method.md)|Gets a token for the specified metadata signature.|
|[GetTokenFromTypeSpec Method](imetadataemit-gettokenfromtypespec-method.md)|Gets a metadata token for the type with the specified metadata signature.|
|[Merge Method](imetadataemit-merge-method.md)|Adds the specified imported scope to the list of scopes to be merged.|
|[MergeEnd Method](imetadataemit-mergeend-method.md)|Merges into the current scope all the metadata scopes specified by one or more prior calls to `IMetaDataEmit::Merge`.|
|[Save Method](imetadataemit-save-method.md)|Saves all metadata in the current scope to the file at the specified address.|
|[SaveToMemory Method](imetadataemit-savetomemory-method.md)|Saves all metadata in the current scope to the specified area of memory.|
|[SaveToStream Method](imetadataemit-savetostream-method.md)|Saves all metadata in the current scope to the specified `IStream`.|
|[SetClassLayout Method](imetadataemit-setclasslayout-method.md)|Sets or updates the class layout signature of a type defined by a prior call to `IMetaDataEmit::DefineTypeDef`.|
|[SetCustomAttributeValue Method](imetadataemit-setcustomattributevalue-method.md)|Sets or updates the value of a custom attribute defined by a prior call to `IMetaDataEmit::DefineCustomAttribute`.|
|[SetEventProps Method](imetadataemit-seteventprops-method.md)|Sets or updates the specified feature of an event defined by a prior call to `IMetaDataEmit::DefineEvent`.|
|[SetFieldMarshal Method](imetadataemit-setfieldmarshal-method.md)|Sets the PInvoke marshalling information for the field, method return, or method parameter referenced by the specified token.|
|[SetFieldProps Method](imetadataemit-setfieldprops-method.md)|Sets or updates the default value for the field referenced by the specified field token.|
|[SetFieldRVA Method](imetadataemit-setfieldrva-method.md)|Sets a global variable value for the relative virtual address of the field referenced by the specified token.|
|[SetHandler Method](imetadataemit-sethandler-method.md)|Sets the method referenced by the specified `IUnknown` pointer as a notification callback for token remaps.|
|[SetMethodImplFlags Method](imetadataemit-setmethodimplflags-method.md)|Sets or updates the metadata signature of the inherited method implementation referenced by the specified token.|
|[SetMethodProps Method](imetadataemit-setmethodprops-method.md)|Sets or updates the feature, stored at the specified relative virtual address, of a method defined by a prior call to `IMetaDataEmit::DefineMethod`.|
|[SetModuleProps Method](imetadataemit-setmoduleprops-method.md)|Updates references to a module defined by a prior call to `IMetaDataEmit::DefineModuleRef`.|
|[SetParamProps Method](imetadataemit-setparamprops-method.md)|Sets or changes features of a method parameter that was defined by a prior call to `IMetaDataEmit::DefineParam`.|
|[SetParent Method](imetadataemit-setparent-method.md)|Establishes that the specified member, as defined by a prior call to `IMetaDataEmit::DefineMemberRef`, is a member of the specified type, as defined by a prior call to `IMetaDataEmit::DefineTypeDef`.|
|[SetPermissionSetProps Method](imetadataemit-setpermissionsetprops-method.md)|Sets or updates features of the metadata signature of a permission set defined by a prior call to `IMetaDataEmit::DefinePermissionSet`.|
|[SetPinvokeMap Method](imetadataemit-setpinvokemap-method.md)|Sets or changes features of a method's PInvoke signature, as defined by a prior call to `IMetaDataEmit::DefinePinvokeMap`.|
|[SetPropertyProps Method](imetadataemit-setpropertyprops-method.md)|Sets the features stored in metadata for a property defined by a prior call to `IMetaDataEmit::DefineProperty`.|
|[SetRVA Method](imetadataemit-setrva-method.md)|Sets the relative virtual address of the specified method.|
|[SetTypeDefProps Method](imetadataemit-settypedefprops-method.md)|Sets features of a type defined by a prior call to `IMetaDataEmit::DefineTypeDef`.|
|[TranslateSigWithScope Method](imetadataemit-translatesigwithscope-method.md)|Imports an assembly into the current scope and gets a new metadata signature for the merged scope.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Interfaces](metadata-interfaces.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
