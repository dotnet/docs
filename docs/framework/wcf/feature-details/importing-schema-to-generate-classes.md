---
title: "Importing Schema to Generate Classes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF, schema import and export"
  - "XsdDataContractImporter class"
ms.assetid: b9170583-8c34-43bd-97bb-6c0c8dddeee0
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Importing Schema to Generate Classes
To generate classes from schemas that are usable with [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], use the <xref:System.Runtime.Serialization.XsdDataContractImporter> class. This topic describes the process and variations.  
  
## The Import Process  
 The schema import process starts with an <xref:System.Xml.Schema.XmlSchemaSet> and produces a <xref:System.CodeDom.CodeCompileUnit>.  
  
 The `XmlSchemaSet` is a part of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]’s Schema Object Model (SOM) that represents a set of XML Schema definition language (XSD) schema documents. To create an `XmlSchemaSet` object from a set of XSD documents, deserialize each document into an <xref:System.Xml.Schema.XmlSchema> object (using the <xref:System.Xml.Serialization.XmlSerializer>) and add these objects to a new `XmlSchemaSet`.  
  
 The `CodeCompileUnit` is part of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]’s Code Document Object Model (CodeDOM) that represents [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] code in an abstract way. To generate the actual code from a `CodeCompileUnit`, use a subclass of the <xref:System.CodeDom.Compiler.CodeDomProvider> class, such as the <xref:Microsoft.CSharp.CSharpCodeProvider> or <xref:Microsoft.VisualBasic.VBCodeProvider> class.  
  
#### To import a schema  
  
1.  Create an instance of the <xref:System.Runtime.Serialization.XsdDataContractImporter>.  
  
2.  Optional. Pass a `CodeCompileUnit` in the constructor. The types generated during schema import are added to this `CodeCompileUnit` instance instead of starting with a blank `CodeCompileUnit`.  
  
3.  Optional. Call one of the <xref:System.Runtime.Serialization.XsdDataContractImporter.CanImport%2A> methods. The method determines whether the given schema is a valid data contract schema and can be imported. The `CanImport` method has the same overloads as `Import` (the next step).  
  
4.  Call one of the overloaded `Import` methods, for example, the <xref:System.Runtime.Serialization.XsdDataContractImporter.Import%28System.Xml.Schema.XmlSchemaSet%29> method.  
  
     The simplest overload takes an `XmlSchemaSet` and imports all types, including anonymous types, found in that schema set. Other overloads allow you to specify the XSD type or a list of types to import (in the form of an <xref:System.Xml.XmlQualifiedName> or a collection of `XmlQualifiedName` objects). In this case, only the specified types are imported. An overload takes an <xref:System.Xml.Schema.XmlSchemaElement> that imports a particular element out of the `XmlSchemaSet`, as well as its associated type (whether it is anonymous or not). This overload returns an `XmlQualifiedName`, which represents the data contract name of the type generated for this element.  
  
     Multiple calls of the `Import` method result in multiple items being added to the same `CodeCompileUnit`. A type is not generated into the `CodeCompileUnit` if it already exists there. Call `Import` multiple times on the same `XsdDataContractImporter` instead of using multiple `XsdDataContractImporter` objects. This is the recommended way to avoid duplicate types being generated.  
  
    > [!NOTE]
    >  If there is a failure during import, the `CodeCompileUnit` will be in an unpredictable state. Using a `CodeCompileUnit` resulting from a failed import could expose you to security vulnerabilities.  
  
5.  Access the `CodeCompileUnit` through the <xref:System.Runtime.Serialization.XsdDataContractImporter.CodeCompileUnit%2A> property.  
  
### Import Options: Customizing the Generated Types  
 You can set the <xref:System.Runtime.Serialization.XsdDataContractImporter.Options%2A> property of the <xref:System.Runtime.Serialization.XsdDataContractImporter> to an instance of the <xref:System.Runtime.Serialization.ImportOptions> class to control various aspects of the import process. A number of options directly influence the types that are generated.  
  
#### Controlling the Access Level (GenerateInternal or the /internal switch)  
 This corresponds to the **/internal** switch on the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md).  
  
 Normally, public types are generated from schema, with private fields and matching public data member properties. To generate internal types instead, set the <xref:System.Runtime.Serialization.ImportOptions.GenerateInternal%2A> property to `true`.  
  
 The following example shows a schema transformed into an internal class when the <xref:System.Runtime.Serialization.ImportOptions.GenerateInternal%2A> property is set to `true.`  
  
 [!code-csharp[c_SchemaImportExport#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#2)]
 [!code-vb[c_SchemaImportExport#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#2)]  
  
#### Controlling Namespaces (Namespaces or the /namespace switch)  
 This corresponds to the **/namespace** switch on the `Svcutil.exe` tool.  
  
 Normally, types generated from schema are generated into [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] namespaces, with each XSD namespace corresponding to a particular [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] namespace according to a mapping described in [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md). You can customize this mapping by the <xref:System.Runtime.Serialization.ImportOptions.Namespaces%2A> property to a <xref:System.Collections.Generic.Dictionary%602>. If a given XSD namespace is found in the dictionary, the matching [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] namespace is also taken from your dictionary.  
  
 For example, consider the following schema.  
  
 [!code-xml[c_SchemaImportExport#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/common/source.config#10)]  
  
 The following example uses the `Namespaces` property to map the "http://schemas.contoso.com/carSchema" namespace to "Contoso.Cars".  
  
 [!code-csharp[c_SchemaImportExport#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#8)]
 [!code-vb[c_SchemaImportExport#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#8)]  
  
#### Adding the SerializableAttribute (GenerateSerializable or the /serializable switch)  
 This corresponds to the **/serializable** switch on the `Svcutil.exe` tool.  
  
 Sometimes it is important for the types generated from the schema to be usable with [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] runtime serialization engines (for example, the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=nameWithType> and the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter> classes). This is useful when using types for [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] remoting. To enable this, you must apply the <xref:System.SerializableAttribute> attribute to the generated types in addition to the regular <xref:System.Runtime.Serialization.DataContractAttribute> attribute. The attribute is generated automatically if the `GenerateSerializable` import option is set to `true`.  
  
 The following example shows the `Vehicle` class generated with the `GenerateSerializable` import option set to `true`.  
  
 [!code-csharp[c_SchemaImportExport#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#4)]
 [!code-vb[c_SchemaImportExport#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#4)]  
  
#### Adding Data Binding Support (EnableDataBinding or the /enableDataBinding switch)  
 This corresponds to the **/enableDataBinding** switch on the Svcutil.exe tool.  
  
 Sometimes, you may want to bind the types generated from the schema to graphical user interface components so that any update to instances of these types will automatically update the UI. The `XsdDataContractImporter` can generate types that implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface in such a way that any property change triggers an event. If you are generating types for use with a client UI programming environment that supports this interface (such as [!INCLUDE[avalon1](../../../../includes/avalon1-md.md)]), set the <xref:System.Runtime.Serialization.ImportOptions.EnableDataBinding%2A> property to `true` to enable this feature.  
  
 The following example shows the `Vehicle` class generated with the <xref:System.Runtime.Serialization.ImportOptions.EnableDataBinding%2A> set to `true`.  
  
 [!code-csharp[C_SchemaImportExport#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#5)]
 [!code-vb[C_SchemaImportExport#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#5)]  
  
### Import Options: Choosing Collection Types  
 Two special patterns in XML represent collections of items: lists of items and associations between one item and another. The following is an example of a list of strings.  
  
 [!code-xml[C_SchemaImportExport#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/common/source.config#11)]  
  
 The following is an example of an association between a string and an integer (`city name` and `population`).  
  
 [!code-xml[C_SchemaImportExport#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/common/source.config#12)]  
  
> [!NOTE]
>  Any association could also be considered a list. For example, you can view the preceding association as a list of complex `city` objects that happen to have two fields (a string field and an integer field). Both patterns have a representation in the XSD Schema. There is no way to differentiate between a list and an association, so such patterns are always treated as lists unless a special annotation specific to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is present in the schema. The annotation indicates that a given pattern represents an association. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md).  
  
 Normally, a list is imported as a collection data contract that derives from a Generic List or as a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] array, depending on whether or not the schema follows the standard naming pattern for collections. This is described in more detail in [Collection Types in Data Contracts](../../../../docs/framework/wcf/feature-details/collection-types-in-data-contracts.md). Associations are normally imported as either a <xref:System.Collections.Generic.Dictionary%602> or a collection data contract that derives from the dictionary object. For example, consider the following schema.  
  
 [!code-xml[c_SchemaImportExport#13](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/common/source.config#13)]  
  
 This would be imported as follows (fields are shown instead of properties for readability).  
  
 [!code-csharp[c_SchemaImportExport#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#6)]
 [!code-vb[c_SchemaImportExport#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#6)]  
  
 It is possible to customize the collection types that are generated for such schema patterns. For example, you may want to generate collections deriving from the <xref:System.ComponentModel.BindingList%601> instead of the <xref:System.Collections.Generic.List%601> class in order to bind the type to a list box and have it be automatically updated when the contents of the collection change. To do this, set the <xref:System.Runtime.Serialization.ImportOptions.ReferencedCollectionTypes%2A> property of the <xref:System.Runtime.Serialization.ImportOptions> class to a list of collection types to be used (hereafter known as the referenced types). When importing any collection, this list of referenced collection types is scanned and the best-matching collection is used if one is found. Associations are matched only against types that implement either the generic or the nongeneric <xref:System.Collections.IDictionary> interface, while lists are matched against any supported collection type.  
  
 For example, if the <xref:System.Runtime.Serialization.ImportOptions.ReferencedCollectionTypes%2A> property is set to a <xref:System.ComponentModel.BindingList%601>, the `people` type in the preceding example is generated as follows.  
  
 [!code-csharp[C_SchemaImportExport#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#7)]
 [!code-vb[C_SchemaImportExport#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#7)]  
  
 A closed generic is considered the best match. For example, if the types `BindingList(Of Integer)` and <xref:System.Collections.ArrayList> are passed to the collection of referenced types, any lists of integers found in schema are imported as a `BindingList(Of Integer)`. Any other lists, for example, a `List(Of String)`, are imported as an `ArrayList`.  
  
 If a type that implements the generic `IDictionary` interface is added to the collection of referenced types, its type parameters must either be fully open or fully closed.  
  
 Duplicates are not allowed. For example, you cannot add both a `List(Of Integer)` and a `Collection(Of Integer)` to the referenced types. That would make it impossible to determine which should be used when a list of integers is found in schema. Duplicates will be detected only if there is a type in schema that exposes the duplicates problem. For example, if the imported schema does not contain lists of integers, it is allowed to have both the `List(Of Integer)` and the `Collection(Of Integer)` in the referenced types collection, but neither will have any effect.  
  
 The referenced collection types mechanism works equally well for collections of complex types (including collections of other collections), and not just for collections of primitives.  
  
 The `ReferencedCollectionTypes` property corresponds to the **/collectionType** switch on the SvcUtil.exe tool. Note that to reference multiple collection types, the **/collectionType** switch must be specified multiple times. If the type is not in the MsCorLib.dll, its assembly must also be referenced using the **/reference** switch.  
  
#### Import Options: Referencing Existing Types  
 Occasionally, types in schema correspond to existing [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types, and there is no need to generate these types from scratch. (This section applies only to noncollection types. For collection types, see the preceding section.)  
  
 For example, you may have a standard company-wide "Person" data contract type that you always want used when representing a person. Whenever some service makes use of this type, and its schema appears in the service metadata, you may want to reuse the existing `Person` type when importing this schema instead of generating a new one for every service.  
  
 To do this, pass a list of [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types that you want to reuse into the collection the <xref:System.Runtime.Serialization.ImportOptions.ReferencedTypes%2A> property returns on the <xref:System.Runtime.Serialization.ImportOptions> class. If any of these types have a data contract name and namespace that matches the name and namespace of a schema type, a structural comparison is performed. If it is determined that the types have both matching names and matching structures, the existing [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type is reused instead of generating a new one. If only the name matches but not the structure, an exception is thrown. Note that there is no allowance for versioning when referencing types (for example, adding new optional data members). The structures must match exactly.  
  
 It is legal to add multiple types with the same data contract name and namespace to the referenced types collection, as long as no schema types are imported with that name and namespace. This allows you to easily add all the types in an assembly to the collection without worrying about duplicates for types that do not actually occur in schema.  
  
 The `ReferencedTypes` property corresponds to the **/reference** switch in certain modes of operation of the Svcutil.exe tool.  
  
> [!NOTE]
>  When using the Svcutil.exe or (in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)]) the **Add Service Reference** tools, all of the types in MsCorLib.dll are automatically referenced.  
  
#### Import Options: Importing Non-DataContract Schema as IXmlSerializable types  
 The <xref:System.Runtime.Serialization.XsdDataContractImporter> supports a limited subset of the schema. If unsupported schema constructs are present (for example, XML attributes), the import attempt fails with an exception. However, setting the <xref:System.Runtime.Serialization.ImportOptions.ImportXmlType%2A> property to `true` extends the range of schema supported. When set to `true`, the <xref:System.Runtime.Serialization.XsdDataContractImporter> generates types that implement the <xref:System.Xml.Serialization.IXmlSerializable> interface. This enables direct access to the XML representation of these types.  
  
##### Design Considerations  
  
-   It may be difficult to work with the weakly typed XML representation directly. Consider using an alternative serialization engine, such as the <xref:System.Xml.Serialization.XmlSerializer>, to work with schema not compatible with data contracts in a strongly typed way. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using the XmlSerializer Class](../../../../docs/framework/wcf/feature-details/using-the-xmlserializer-class.md).  
  
-   Some schema constructs cannot be imported by the <xref:System.Runtime.Serialization.XsdDataContractImporter> even when the <xref:System.Runtime.Serialization.ImportOptions.ImportXmlType%2A> property is set to `true`. Again, consider using the <xref:System.Xml.Serialization.XmlSerializer> for such cases.  
  
-   The exact schema constructs that are supported both when <xref:System.Runtime.Serialization.ImportOptions.ImportXmlType%2A> is `true` or `false` are described in [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md).  
  
-   Schema for generated <xref:System.Xml.Serialization.IXmlSerializable> types do not retain fidelity when imported and exported. That is, exporting the schema from the generated types and importing as classes does not return the original schema.  
  
 It is possible to combine the <xref:System.Runtime.Serialization.ImportOptions.ImportXmlType%2A> option with the <xref:System.ServiceModel.Description.ServiceContractGenerator.ReferencedTypes%2A> option previously described. For types that have to be generated as <xref:System.Xml.Serialization.IXmlSerializable> implementations, the structural check is skipped when using the <xref:System.ServiceModel.Description.ServiceContractGenerator.ReferencedTypes%2A> feature.  
  
 The <xref:System.Runtime.Serialization.ImportOptions.ImportXmlType%2A> option corresponds to the **/importXmlTypes** switch on the Svcutil.exe tool.  
  
##### Working with Generated IXmlSerializable Types  
 The generated `IXmlSerializable` types contain a private field, named "nodesField," that returns an array of <xref:System.Xml.XmlNode> objects. When deserializing an instance of such a type, you can access the XML data directly through this field by using the XML Document Object Model. When serializing an instance of this type, you can set this field to the desired XML data and it will be serialized.  
  
 This is accomplished through the `IXmlSerializable` implementation. In the generated `IXmlSerializable` type, the <xref:System.Xml.Serialization.IXmlSerializable.ReadXml%2A> implementation calls the <xref:System.Runtime.Serialization.XmlSerializableServices.ReadNodes%2A> method of the <xref:System.Runtime.Serialization.XmlSerializableServices> class. The method is a helper method that converts XML provided through an <xref:System.Xml.XmlReader> to an array of <xref:System.Xml.XmlNode> objects. The <xref:System.Xml.Serialization.IXmlSerializable.WriteXml%2A> implementation does the opposite and converts the array of `XmlNode` objects to a sequence of <xref:System.Xml.XmlWriter> calls. This is accomplished using the <xref:System.Runtime.Serialization.XmlSerializableServices.WriteNodes%2A> method.  
  
 It is possible to run the schema export process on the generated `IXmlSerializable` classes. As previously stated, you will not get the original schema back. Instead, you will get the "anyType" standard XSD type, which is a wildcard for any XSD type.  
  
 This is accomplished by applying the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute to the generated `IXmlSerializable` classes and specifying a method that calls the <xref:System.Runtime.Serialization.XmlSerializableServices.AddDefaultSchema%2A> method to generate the "anyType" type.  
  
> [!NOTE]
>  The <xref:System.Runtime.Serialization.XmlSerializableServices> type exists solely to support this particular feature. It is not recommended for use for any other purpose.  
  
#### Import Options: Advanced Options  
 The following are advanced import options:  
  
-   <xref:System.Runtime.Serialization.ImportOptions.CodeProvider%2A> property. Specify the <xref:System.CodeDom.Compiler.CodeDomProvider> to use to generate the code for the generated classes. The import mechanism attempts to avoid features that the <xref:System.CodeDom.Compiler.CodeDomProvider> does not support. If the <xref:System.Runtime.Serialization.ImportOptions.CodeProvider%2A> is not set, the full set of [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] features is used with no restrictions.  
  
-   <xref:System.Runtime.Serialization.ImportOptions.DataContractSurrogate%2A> property. An <xref:System.Runtime.Serialization.IDataContractSurrogate> implementation can be specified with this property. The <xref:System.Runtime.Serialization.IDataContractSurrogate> customizes the import process. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Surrogates](../../../../docs/framework/wcf/extending/data-contract-surrogates.md). By default, no surrogate is used.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Runtime.Serialization.XsdDataContractImporter>  
 <xref:System.Runtime.Serialization.XsdDataContractExporter>  
 <xref:System.Runtime.Serialization.ImportOptions>  
 [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md)  
 [Data Contract Surrogates](../../../../docs/framework/wcf/extending/data-contract-surrogates.md)  
 [Schema Import and Export](../../../../docs/framework/wcf/feature-details/schema-import-and-export.md)  
 [Exporting Schemas from Classes](../../../../docs/framework/wcf/feature-details/exporting-schemas-from-classes.md)  
 [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md)
