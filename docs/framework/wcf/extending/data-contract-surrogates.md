---
title: "Data Contract Surrogates"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "data contracts [WCF], surrogates"
ms.assetid: 8c31134c-46c5-4ed7-94af-bab0ac0dfce5
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Contract Surrogates
The data contract *surrogate* is an advanced feature built upon the Data Contract model. This feature is designed to be used for type customization and substitution in situations where users want to change how a type is serialized, deserialized or projected into metadata. Some scenarios where a surrogate may be used is when a data contract has not been specified for the type, fields and properties are not marked with the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute or users wish to dynamically create schema variations.  
  
 Serialization and deserialization are accomplished with the data contract surrogate when using <xref:System.Runtime.Serialization.DataContractSerializer> to convert from .NET Framework to a suitable format, such as XML. Data contract surrogate can also be used to modify the metadata exported for types, when producing metadata representations such as XML Schema Documents (XSD). Upon import, code is created from metadata and the surrogate can be used in this case to customize the generated code as well.  
  
## How the Surrogate Works  
 A surrogate works by mapping one type (the "original" type) to another type (the "surrogated" type). The following example shows the original type `Inventory` and a new surrogate `InventorySurrogated` type. The `Inventory` type is not serializable but the `InventorySurrogated` type is:  
  
 [!code-csharp[C_IDataContractSurrogate#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#1)]  
  
 Because a data contract has not been defined for this class, convert the class to a surrogate class with a data contract. The surrogated class is shown in the following example:  
  
 [!code-csharp[C_IDataContractSurrogate#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#2)]  
  
## Implementing the IDataContractSurrogate  
 To use the data contract surrogate, implement the <xref:System.Runtime.Serialization.IDataContractSurrogate> interface.  
  
 The following is an overview of each method of <xref:System.Runtime.Serialization.IDataContractSurrogate> with a possible implementation.  
  
### GetDataContractType  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetDataContractType%2A> method maps one type to another. This method is required for serialization, deserialization, import, and export.  
  
 The first task is defining what types will be mapped to other types. For example:  
  
 [!code-csharp[C_IDataContractSurrogate#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#3)]  
  
-   On serialization, the mapping returned by this method is subsequently used to transform the original instance to a surrogated instance by calling the <xref:System.Runtime.Serialization.IDataContractSurrogate.GetObjectToSerialize%2A> method.  
  
-   On deserialization, the mapping returned by this method is used by the serializer to deserialize into an instance of the surrogate type. It subsequently calls <xref:System.Runtime.Serialization.IDataContractSurrogate.GetDeserializedObject%2A> to transform the surrogated instance into an instance of the original type.  
  
-   On export, the surrogate type returned by this method is reflected to get the data contract to use for generating metadata.  
  
-   On import, the initial type is changed to a surrogate type that is reflected to get the data contract to use for purposes like referencing support.  
  
 The <xref:System.Type> parameter is the type of the object that is being serialized, deserialized, imported, or exported. The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetDataContractType%2A> method must return the input type if the surrogate does not handle the type. Otherwise, return the appropriate surrogated type. If several surrogate types exist, numerous mappings can be defined in this method.  
  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetDataContractType%2A> method is not called for built-in data contract primitives, such as <xref:System.Int32> or <xref:System.String>. For other types, such as arrays, user-defined types, and other data structures, this method will be called for each type.  
  
 In the previous example, the method checks if the `type` parameter and `Inventory` are comparable. If so, the method maps it to `InventorySurrogated`. Whenever a serialization, deserialization, import schema, or export schema is called, this function is called first to determine the mapping between types.  
  
### GetObjectToSerialize Method  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetObjectToSerialize%2A> method converts the original type instance to the surrogated type instance. The method is required for serialization.  
  
 The next step is to define the way the physical data will be mapped from the original instance to the surrogate by implementing the <xref:System.Runtime.Serialization.IDataContractSurrogate.GetObjectToSerialize%2A> method. For example:  
  
 [!code-csharp[C_IDataContractSurrogate#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#4)]  
  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetObjectToSerialize%2A> method is called when an object is serialized. This method transfers data from the original type to the fields of the surrogated type. Fields can be directly mapped to surrogate fields, or manipulations of the original data may be stored in the surrogate. Some possible uses include: directly mapping the fields, performing operations on the data to be stored in the surrogated fields, or storing the XML of the original type in the surrogated field.  
  
 The `targetType` parameter refers to the declared type of the member. This parameter is the surrogated type returned by the <xref:System.Runtime.Serialization.IDataContractSurrogate.GetDataContractType%2A> method. The serializer does not enforce that the object returned is assignable to this type. The `obj` parameter is the object to serialize, and will be converted to its surrogate if necessary. This method must return the input object if the surrogated does not handle the object. Otherwise, the new surrogate object will be returned. The surrogate is not called if the object is null. Numerous surrogate mappings for different instances may be defined within this method.  
  
 When creating a <xref:System.Runtime.Serialization.DataContractSerializer>, you can instruct it to preserve object references. ([!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Serialization and Deserialization](../../../../docs/framework/wcf/feature-details/serialization-and-deserialization.md).) This is done by setting the `preserveObjectReferences` parameter in its constructor to `true`. In that case, the surrogate is called only once for an object since all subsequent serializations just write the reference into the stream. If `preserveObjectReferences` is set to `false`, then the surrogate is called every time an instance is encountered.  
  
 If the type of the instance serialized differs from the declared type, type information is written into the stream, for example, `xsi:type` to allow the instance to be deserialized at the other end. This process occurs whether the object is surrogated or not.  
  
 The example above converts the data of the `Inventory` instance to that of `InventorySurrogated`. It checks the type of the object and performs the necessary manipulations to convert to the surrogated type. In this case, the fields of the `Inventory` class are directly copied over to the `InventorySurrogated` class fields.  
  
### GetDeserializedObject Method  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetDeserializedObject%2A> method converts the surrogated type instance to the original type instance. It is required for deserialization.  
  
 The next task is to define the way the physical data will be mapped from the surrogate instance to the original. For example:  
  
 [!code-csharp[C_IDataContractSurrogate#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#5)]  
  
 This method is called only during the deserialization of an object. It provides reverse data mapping for the deserialization from the surrogate type back to its original type. Similar to the `GetObjectToSerialize` method, some possible uses may be to directly exchange field data, perform operations on the data, and store XML data. When  deserializing, you may not always obtain the exact data values from original due to manipulations in the data conversion.  
  
 The `targetType` parameter refers to the declared type of the member. This parameter is the surrogated type returned by the `GetDataContractType` method. The `obj` parameter refers to the object that has been deserialized. The object can be converted back to its original type if it is surrogated. This method returns the input object if the surrogate does not handle the object. Otherwise, the deserialized object will be returned once its conversion has been completed. If several surrogate types exist, you may provide data conversion from surrogate to primary type for each by indicating each type and its conversion.  
  
 When returning an object, the internal object tables are updated with the object returned by this surrogate. Any subsequent references to an instance will obtain the surrogated instance from the object tables.  
  
 The previous example converts objects of type `InventorySurrogated` back to the initial type `Inventory`. In this case, data is directly transferred back from `InventorySurrogated` to its corresponding fields in `Inventory`. Because there are no data manipulations, the each of the member fields will contain the same values as before the serialization.  
  
### GetCustomDataToExport Method  
 When exporting a schema, the <xref:System.Runtime.Serialization.IDataContractSurrogate.GetCustomDataToExport%2A> method is optional. It is used to insert additional data or hints into the exported schema. Additional data can be inserted at the member level or type level. For example:  
  
 [!code-csharp[C_IDataContractSurrogate#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#6)]  
  
 This method (with two overloads) enables the inclusion of extra information into the metadata either at the member or type level. It is possible to include hints about whether a member is public or private, and comments which would be preserved throughout the export and import of the schema. Such information would be lost without this method. This method does not cause the insertion or deletion of members or types, but rather adds additional data to the schemas at either of these levels.  
  
 The method is overloaded and can take either a `Type` (`clrtype` parameter) or <xref:System.Reflection.MemberInfo> (`memberInfo` parameter). The second parameter is always a `Type` (`dataContractType` parameter). This method is called for every member and type of the surrogated `dataContractType` type.  
  
 Either of these overloads must return either `null` or a serializable object. A non-null object will be serialized as annotation into the exported schema. For the `Type` overload, each type that is exported to schema is sent to this method in the first parameter along with the surrogated type as the `dataContractType` parameter. For the `MemberInfo` overload, each member that is exported to schema sends its information as the `memberInfo` parameter with the surrogated type in the second parameter.  
  
#### GetCustomDataToExport Method (Type, Type)  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetCustomDataToExport%28System.Type%2CSystem.Type%29?displayProperty=nameWithType> method is called during schema export for every type definition. The method adds information to the types within the schema when exporting. Each type defined is sent to this method to determine whether there is any additional data that needs to be included in the schema.  
  
#### GetCustomDataToExport Method (MemberInfo, Type)  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.GetCustomDataToExport%28System.Reflection.MemberInfo%2CSystem.Type%29?displayProperty=nameWithType> is called during export for every member in the types that are exported. This function enables you to customize any comments for the members that will be included in the schema upon export. The information for every member within the class is sent to this method to check whether any additional data need to be added in the schema.  
  
 The example above searches through the `dataContractType` for each member of the surrogate. It then returns the appropriate access modifier for each field. Without this customization, the default value for access modifiers is public. Therefore, all members would be defined as public in the code generated using the exported schema no matter what their actual access restrictions are. When not using this implementation, the member `numpens` would be public in the exported schema even though it was defined in the surrogate as private. Through the use of this method, in the exported schema, the access modifier can be generated as private.  
  
### GetReferencedTypeOnImport Method  
 This method maps the <xref:System.Type> of the surrogate to the original type. This method is optional for schema importation.  
  
 When creating a surrogate that imports a schema and generates code for it, the next task is to define the type of a surrogate instance to its original type.  
  
 If the generated code needs to reference an existing user type, this is done by implementing the <xref:System.Runtime.Serialization.IDataContractSurrogate.GetReferencedTypeOnImport%2A> method.  
  
 When importing a schema, this method is called for every type declaration to map the surrogated data contract to a type. The string parameters `typeName` and `typeNamespace` define the name and namespace of the surrogated type. The return value for <xref:System.Runtime.Serialization.IDataContractSurrogate.GetReferencedTypeOnImport%2A> is used to determine whether a new type needs to be generated. This method must return either a valid type or null. For valid types, the type returned will be used as a referenced type in the generated code. If null is returned, no type will be referenced and a new type must be created. If several surrogates exist, it is possible to perform the mapping for each surrogate type back to its initial type.  
  
 The `customData` parameter is the object originally returned from <xref:System.Runtime.Serialization.IDataContractSurrogate.GetCustomDataToExport%2A>. This `customData` is used when surrogate authors want to insert extra data/hints into the metadata to use during import to generate code.  
  
### ProcessImportedType Method  
 The <xref:System.Runtime.Serialization.IDataContractSurrogate.ProcessImportedType%2A> method customizes any type created from schema importation. This method is optional.  
  
 When importing a schema, this method allows for any imported type and compilation information to be customized. For example:  
  
 [!code-csharp[C_IDataContractSurrogate#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#7)]  
  
 During import, this method is called for every type generated. Change the specified <xref:System.CodeDom.CodeTypeDeclaration> or modify the <xref:System.CodeDom.CodeCompileUnit>. This includes changing the name, members, attributes, and many other properties of the `CodeTypeDeclaration`. By processing the `CodeCompileUnit`, it is possible to modify the directives, namespaces, referenced assemblies, and several other aspects.  
  
 The `CodeTypeDeclaration` parameter contains the code DOM type declaration. The `CodeCompileUnit` parameter allows for modification for processing the code.  Returning `null` results in the type declaration being discarded. Conversely, when returning a `CodeTypeDeclaration`, the modifications are preserved.  
  
 If custom data is inserted during metadata export, it needs to be provided to the user during import so that it can be used. This custom data can be used for programming model hints, or other comments. Each `CodeTypeDeclaration` and <xref:System.CodeDom.CodeTypeMember> instance includes custom data as the <xref:System.CodeDom.CodeObject.UserData%2A> property, cast to the `IDataContractSurrogate` type.  
  
 The example above performs some changes on the schema imported. The code preserves private members of the original type by using a surrogate. The default access modifier when importing a schema is `public`. Therefore, all members of the surrogate schema will be public unless modified, as in this example. During export, custom data is inserted into the metadata about which members are private. The example looks up the custom data, checks whether the access modifier is private, and then modifies the appropriate member to be private by setting its attributes. Without this customization, the `numpens` member would be defined as public instead of private.  
  
### GetKnownCustomDataTypes Method  
 This method obtains custom data types defined from the schema. The method is optional for schema importation.  
  
 The method is called at the beginning of schema export and import. The method returns the custom data types used in the schema exported or imported. The method is passed a <xref:System.Collections.ObjectModel.Collection%601> (the `customDataTypes` parameter), which is a collection of types. The method should add additional known types to this collection. The known custom data types are needed to enable serialization and deserialization of custom data using the <xref:System.Runtime.Serialization.DataContractSerializer>. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md).  
  
## Implementing a Surrogate  
 To use the data contract surrogate within [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], you must follow a few special procedures.  
  
### To Use a Surrogate for Serialization and Deserialization  
 Use the <xref:System.Runtime.Serialization.DataContractSerializer> to perform serialization and deserialization of data with the surrogate. The <xref:System.Runtime.Serialization.DataContractSerializer> is created by the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>. The surrogate must also be specified.  
  
##### To implement serialization and deserialization  
  
1.  Create an instance of the <xref:System.ServiceModel.ServiceHost> for your service. For complete instructions, see [Basic WCF Programming](../../../../docs/framework/wcf/basic-wcf-programming.md).  
  
2.  For every <xref:System.ServiceModel.Description.ServiceEndpoint> of the specified service host, find its <xref:System.ServiceModel.Description.OperationDescription>.  
  
3.  Search through the operation behaviors to determine if an instance of the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> is found.  
  
4.  If a <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> is found, set its <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior.DataContractSurrogate%2A> property to a new instance of the surrogate. If no <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> is found, then create a new instance and set the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior.DataContractSurrogate%2A> member of the new behavior to a new instance of the surrogate.  
  
5.  Finally, add this new behavior to the current operation behaviors, as shown in the following example:  
  
     [!code-csharp[C_IDataContractSurrogate#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#8)]  
  
### To Use a Surrogate for Metadata Import  
 When importing metadata like WSDL and XSD to generate client-side code, the surrogate needs to be added to the component responsible for generating code from XSD schema, <xref:System.Runtime.Serialization.XsdDataContractImporter>. To do this, directly modify the <xref:System.ServiceModel.Description.WsdlImporter> used to import metadata.  
  
##### To implement a surrogate for metadata importation  
  
1.  Import the metadata using the <xref:System.ServiceModel.Description.WsdlImporter> class.  
  
2.  Use the <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> method to check whether an <xref:System.Runtime.Serialization.XsdDataContractImporter> has been defined.  
  
3.  If the <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> method returns `false`, create a new <xref:System.Runtime.Serialization.XsdDataContractImporter> and set its <xref:System.Runtime.Serialization.XsdDataContractImporter.Options%2A> property to a new instance of the <xref:System.Runtime.Serialization.ImportOptions> class. Otherwise, use the importer returned by the `out` parameter of the <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> method.  
  
4.  If the <xref:System.Runtime.Serialization.XsdDataContractImporter> has no <xref:System.Runtime.Serialization.ImportOptions> defined, then set the property to be a new instance of the <xref:System.Runtime.Serialization.ImportOptions> class.  
  
5.  Set the <xref:System.Runtime.Serialization.ImportOptions.DataContractSurrogate%2A> property of the <xref:System.Runtime.Serialization.ImportOptions> of the <xref:System.Runtime.Serialization.XsdDataContractImporter> to a new instance of the surrogate.  
  
6.  Add the <xref:System.Runtime.Serialization.XsdDataContractImporter> to the collection returned by the <xref:System.ServiceModel.Description.MetadataExporter.State%2A> property of the <xref:System.ServiceModel.Description.WsdlImporter> (inherited from the <xref:System.ServiceModel.Description.MetadataExporter> class.)  
  
7.  Use the <xref:System.ServiceModel.Description.WsdlImporter.ImportAllContracts%2A> method of the <xref:System.ServiceModel.Description.WsdlImporter> to import all of the data contracts within the schema. During the last step, code is generated from the schemas loaded by calling into the surrogate.  
  
     [!code-csharp[C_IDataContractSurrogate#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#9)]  
  
### To Use a surrogate for Metadata Export  
 By default, when exporting metadata from [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] for a service, both WSDL and XSD schema needs to be generated. The surrogate needs to be added to the component responsible for generating XSD schema for data contract types, <xref:System.Runtime.Serialization.XsdDataContractExporter>. To do this, either use a behavior that implements <xref:System.ServiceModel.Description.IWsdlExportExtension> to modify the <xref:System.ServiceModel.Description.WsdlExporter>, or directly modify the <xref:System.ServiceModel.Description.WsdlExporter> used to export metadata.  
  
##### To use a surrogate for metadata export  
  
1.  Create a new <xref:System.ServiceModel.Description.WsdlExporter> or use the `wsdlExporter` parameter passed to the <xref:System.ServiceModel.Description.IWsdlExportExtension.ExportContract%2A> method.  
  
2.  Use the <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> function to check whether an <xref:System.Runtime.Serialization.XsdDataContractExporter> has been defined.  
  
3.  If <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> returns `false`, create a new <xref:System.Runtime.Serialization.XsdDataContractExporter> with the generated XML schemas from the <xref:System.ServiceModel.Description.WsdlExporter>, and add it to the collection returned by the <xref:System.ServiceModel.Description.MetadataExporter.State%2A> property of the <xref:System.ServiceModel.Description.WsdlExporter>. Otherwise, use the exporter returned by the `out` parameter of the <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> method.  
  
4.  If the <xref:System.Runtime.Serialization.XsdDataContractExporter> has no <xref:System.Runtime.Serialization.ExportOptions> defined, then set the <xref:System.Runtime.Serialization.XsdDataContractExporter.Options%2A> property to a new instance of the <xref:System.Runtime.Serialization.ExportOptions> class.  
  
5.  Set the <xref:System.Runtime.Serialization.ExportOptions.DataContractSurrogate%2A> property of the <xref:System.Runtime.Serialization.ExportOptions> of the <xref:System.Runtime.Serialization.XsdDataContractExporter> to a new instance of the surrogate. Subsequent steps for exporting metadata do not require any changes.  
  
     [!code-csharp[C_IDataContractSurrogate#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_idatacontractsurrogate/cs/source.cs#10)]  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Runtime.Serialization.IDataContractSurrogate>  
 <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>  
 <xref:System.Runtime.Serialization.ImportOptions>  
 <xref:System.Runtime.Serialization.ExportOptions>  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)
