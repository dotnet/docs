---
title: "Collection Types in Data Contracts"
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
  - "collection types [WCF], data contracts"
  - "data contracts [WCF], collection types"
  - "collection types [WCF]"
ms.assetid: 9b45b28e-0a82-4ea3-8c33-ec0094aff9d5
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Collection Types in Data Contracts
A *collection* is a list of items of a certain type. In the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], such lists can be represented using arrays or a variety of other types (Generic List, Generic <xref:System.ComponentModel.BindingList%601>, <xref:System.Collections.Specialized.StringCollection>, or <xref:System.Collections.ArrayList>). For example, a collection may hold a list of Addresses for a given Customer. These collections are called *list collections*, regardless of their actual type.  
  
 A special form of collection exists that represents an association between one item (the "key") and another (the "value"). In the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], these are represented by types such as <xref:System.Collections.Hashtable> and the generic dictionary. For example, an association collection may map a city ("key") to its population ("value"). These collections are called *dictionary collections*, regardless of their actual type.  
  
 Collections receive special treatment in the data contract model.  
  
 Types that implement the <xref:System.Collections.IEnumerable> interface, including arrays and generic collections, are recognized as collections. Of those, types that implement the <xref:System.Collections.IDictionary> or Generic <xref:System.Collections.Generic.IDictionary%602> interfaces are dictionary collections; all others are list collections.  
  
 Additional requirements on collection types, such as having a method called `Add` and a default constructor, are discussed in detail in the following sections. This ensures that collection types can be both serialized and deserialized. This means that some collections are not directly supported, such as the Generic <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> (because it has no default constructor). However, for information about circumventing these restrictions, see the section "Using Collection Interface Types and Read-Only Collections" later in this topic.  
  
 The types contained in collections must be data contract types, or be otherwise serializable. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Types Supported by the Data Contract Serializer](../../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] what is and what is not considered a valid collection, as well as about how collections are serialized, see the information about serializing collections in the "Advanced Collection Rules" section of this topic.  
  
## Interchangeable Collections  
 All list collections of the same type are considered to have the same data contract (unless they are customized using the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute, as discussed later in this topic). Thus, for example, the following data contracts are equivalent.  
  
 [!code-csharp[c_collection_types_in_data_contracts#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#0)]
 [!code-vb[c_collection_types_in_data_contracts#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#0)]  
  
 Both data contracts result in XML similar to the following code.  
  
```xml  
<PurchaseOrder>  
    <customerName>...</customerName>  
    <items>  
        <Item>...</Item>  
        <Item>...</Item>  
        <Item>...</Item>  
        ...  
    </items>  
    <comments>  
        <string>...</string>  
        <string>...</string>  
        <string>...</string>  
        ...  
    </comments>  
</PurchaseOrder>  
```  
  
 Collection interchangeability allows you to use, for example, a collection type optimized for performance on the server and a collection type designed to be bound to user interface components on the client.  
  
 Similar to list collections, all dictionary collections that have the same key and value types are considered to have the same data contract (unless customized by the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute).  
  
 Only the data contract type matters as far as collection equivalence is concerned, not .NET types. That is, a collection of Type1 is considered equivalent to a collection of Type2 if Type1 and Type2 have equivalent data contracts.  
  
 Non-generic collections are considered to have the same data contract as generic collections of type `Object`. (For example, the data contracts for <xref:System.Collections.ArrayList> and Generic <xref:System.Collections.Generic.List%601> of `Object` are the same.)  
  
## Using Collection Interface Types and Read-Only Collections  
 Collection interface types (<xref:System.Collections.IEnumerable>, <xref:System.Collections.IDictionary>, generic <xref:System.Collections.Generic.IDictionary%602>, or interfaces derived from these interfaces) are also considered as having collection data contracts, equivalent to collection data contracts for actual collection types. Thus, it is possible to declare the type being serialized as a collection interface type and the results are the same as if an actual collection type had been used. For example, the following data contracts are equivalent.  
  
 [!code-csharp[c_collection_types_in_data_contracts#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#1)]
 [!code-vb[c_collection_types_in_data_contracts#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#1)]  
  
 During serialization, when the declared type is an interface, the actual instance type used can be any type that implements that interface. Restrictions discussed previously (having a default constructor and an `Add` method) do not apply. For example, you can set addresses in Customer2 to an instance of Generic <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> of Address, even though you cannot directly declare a data member of type Generic <xref:System.Collections.ObjectModel.ReadOnlyCollection%601>.  
  
 During deserialization, when the declared type is an interface, the serialization engine chooses a type that implements the declared interface, and the type is instantiated. The known types mechanism (described in [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md)) has no effect here; the choice of type is built into [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## Customizing Collection Types  
 You can customize collection types by using the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute, which has several uses.  
  
 Note that customizing collection types compromises collection interchangeability, so it is generally recommended to avoid applying this attribute whenever possible. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] this issue, see the "Advanced Collection Rules" section later in this topic.  
  
### Collection Data Contract Naming  
 The rules for naming collection types are similar to those for naming regular data contract types, as described in [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md), although some important differences exist:  
  
-   The <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute is used to customize the name, instead of the <xref:System.Runtime.Serialization.DataContractAttribute> attribute. The <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute also has `Name` and `Namespace` properties.  
  
-   When the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute is not applied, the default name and namespace for collection types depend on the names and namespaces of types contained within the collection. They are not affected by the name and namespace of the collection type itself. For an example, see the following types.  
  
    ```  
    public CustomerList1 : Collection<string> {}  
    public StringList1 : Collection<string> {}  
    ```  
  
 Both types’ data contract name is "ArrayOfstring" and not "CustomerList1" or "StringList1". This means that serializing any one of these types at the root level yields XML similar to the following code.  
  
```xml  
<ArrayOfstring>  
    <string>...</string>  
    <string>...</string>  
    <string>...</string>  
    ...  
</ArrayOfstring>  
```  
  
 This naming rule was chosen to ensure that any non-customized type that represents a list of strings has the same data contract and XML representation. This makes collection interchangeability possible. In this example, CustomerList1 and StringList1 are completely interchangeable.  
  
 However, when the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute is applied, the collection becomes a customized collection data contract, even if no properties are set on the attribute. The name and namespace of the collection data contract then depend on the collection type itself. For an example, see the following type.  
  
 [!code-csharp[c_collection_types_in_data_contracts#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#2)]
 [!code-vb[c_collection_types_in_data_contracts#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#2)]  
  
 When serialized, the resulting XML is similar to the following.  
  
```xml  
<CustomerList2>  
    <string>...</string>  
    <string>...</string>  
    <string>...</string>  
    ...  
</CustomerList2>  
```  
  
 Notice that this is no longer equivalent to the XML representation of the non-customized types.  
  
-   You can use the `Name` and `Namespace` properties to further customize the naming. See the following class.  
  
     [!code-csharp[c_collection_types_in_data_contracts#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#3)]
     [!code-vb[c_collection_types_in_data_contracts#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#3)]  
  
 The resulting XML is similar to the following.  
  
```xml  
<cust_list>  
    <string>...</string>  
    <string>...</string>  
    <string>...</string>  
    ...  
</cust_list>  
```  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the "Advanced Collection Rules" section later in this topic.  
  
### Customizing the Repeating Element Name in List Collections  
 List collections contain repeating entries. Normally, each repeating entry is represented as an element named according to the data contract name of the type contained in the collection.  
  
 In the `CustomerList` examples, the collections contained strings. The data contract name for the string primitive type is "string", so the repeating element was "\<string>".  
  
 However, using the <xref:System.Runtime.Serialization.CollectionDataContractAttribute.ItemName%2A> property on the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute, this repeating element name can be customized. For an example, see the following type.  
  
 [!code-csharp[c_collection_types_in_data_contracts#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#4)]
 [!code-vb[c_collection_types_in_data_contracts#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#4)]  
  
 The resulting XML is similar to the following.  
  
```xml  
<CustomerList4>  
    <customer>...</customer>  
    <customer>...</customer>  
    <customer>...</customer>  
    ...  
</CustomerList4>  
```  
  
 The namespace of the repeating element is always the same as the namespace of the collection data contract, which can be customized using the `Namespace` property, as described previously.  
  
### Customizing Dictionary Collections  
 Dictionary collections are essentially lists of entries, where each entry has a key followed by a value. Just as with regular lists, you can change the element name that corresponds to the repeating element by using the <xref:System.Runtime.Serialization.CollectionDataContractAttribute.ItemName%2A> property.  
  
 Additionally, you can change the element names that represent the key and the value by using the <xref:System.Runtime.Serialization.CollectionDataContractAttribute.KeyName%2A> and <xref:System.Runtime.Serialization.CollectionDataContractAttribute.ValueName%2A> properties. The namespaces for these elements are the same as the namespace of the collection data contract.  
  
 For an example, see the following type.  
  
 [!code-csharp[c_collection_types_in_data_contracts#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#5)]
 [!code-vb[c_collection_types_in_data_contracts#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#5)]  
  
 When serialized, the resulting XML is similar to the following.  
  
```xml  
<CountriesOrRegionsWithCapitals>  
    <entry>  
        <countryorregion>USA</countryorregion>  
        <capital>Washington</capital>  
    </entry>  
    <entry>  
        <countryorregion>France</countryorregion>  
        <capital>Paris</capital>  
    </entry>  
    ...  
</CountriesOrRegionsWithCapitals>  
```  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] dictionary collections, see the "Advanced Collection Rules" section later in this topic.  
  
## Collections and Known Types  
 You do not need to add collection types to known types when used polymorphically in place of other collections or collection interfaces. For example, if you declare a data member of type <xref:System.Collections.IEnumerable> and use it to send an instance of <xref:System.Collections.ArrayList>, you do not need to add <xref:System.Collections.ArrayList> to known types.  
  
 When you use collections polymorphically in place of non-collection types, they must be added to known types. For example, if you declare a data member of type `Object` and use it to send an instance of <xref:System.Collections.ArrayList>, add <xref:System.Collections.ArrayList> to known types.  
  
 This does not allow you to serialize any equivalent collection polymorphically. For example, when you add <xref:System.Collections.ArrayList> to the list of known types in the preceding example, this does not let you assign the `Array of Object` class, even though it has an equivalent data contract. This is no different from regular known types behavior on serialization for non-collection types, but it is especially important to understand in the case of collections because it is very common for collections to be equivalent.  
  
 During serialization, only one type can be known in any given scope for a given data contract, and equivalent collections all have the same data contracts. This means that, in the previous example, you cannot add both <xref:System.Collections.ArrayList> and `Array of Object` to known types at the same scope. Again, this is equivalent to known types behavior for non-collection types, but it is especially important to understand for collections.  
  
 Known types may also be required for contents of collections. For example, if an <xref:System.Collections.ArrayList> actually contains instances of `Type1` and `Type2`, both of these types should be added to known types.  
  
 The following example shows a properly constructed object graph using collections and known types. The example is somewhat contrived, because in an actual application you would normally not define the following data members as `Object`, and thus do not have any known type/polymorphism issues.  
  
 [!code-csharp[c_collection_types_in_data_contracts#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#6)]
 [!code-vb[c_collection_types_in_data_contracts#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#6)]  
  
 On deserialization, if the declared type is a collection type, the declared type is instantiated regardless of the type that was actually sent. If the declared type is a collection interface, the deserializer picks a type to be instantiated with no regard to known types.  
  
 Also on deserialization, if the declared type is not a collection type but a collection type is being sent, a matching collection type is picked out of the known types list. It is possible to add collection interface types to the list of known types on deserialization. In this case, the deserialization engine again picks a type to be instantiated.  
  
## Collections and the NetDataContractSerializer Class  
 When the <xref:System.Runtime.Serialization.NetDataContractSerializer> class is in use, non-customized collection types (without the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute) that are not arrays lose their special meaning.  
  
 Non-customized collection types marked with the <xref:System.SerializableAttribute> attribute can still be serialized by the <xref:System.Runtime.Serialization.NetDataContractSerializer> class according to the <xref:System.SerializableAttribute> attribute or the <xref:System.Runtime.Serialization.ISerializable> interface rules.  
  
 Customized collection types, collection interfaces, and arrays are still treated as collections, even when the <xref:System.Runtime.Serialization.NetDataContractSerializer> class is in use.  
  
## Collections and Schema  
 All equivalent collections have the same representation in XML Schema definition language (XSD) schema. Because of this, you normally do not get the same collection type in the generated client code as the one on the server. For example, the server may use a data contract with a Generic <xref:System.Collections.Generic.List%601> of Integer data member, but in the generated client code the same data member may become an array of integers.  
  
 Dictionary collections are marked with a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-specific schema annotation that indicate that they are dictionaries; otherwise, they are indistinguishable from simple lists that contain entries with a key and a value. For an exact description of how collections are represented in data contract schema, see [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md).  
  
 By default, types are not generated for non-customized collections in imported code. Data members of list collection types are imported as arrays, and data members of dictionary collection types are imported as Generic Dictionary.  
  
 However, for customized collections, separate types are generated, marked with the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute. (A customized collection type in the schema is one that does not use the default namespace, name, repeating element name, or key/value element names.) These types are empty types that derive from Generic <xref:System.Collections.Generic.List%601> for list types and Generic Dictionary for dictionary types.  
  
 For example, you may have the following types on the server.  
  
 [!code-csharp[c_collection_types_in_data_contracts#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#7)]
 [!code-vb[c_collection_types_in_data_contracts#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#7)]  
  
 When the schema is exported and imported back again, the generated client code is similar to the following (fields are shown instead of properties for ease of reading).  
  
 [!code-csharp[c_collection_types_in_data_contracts#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#8)]
 [!code-vb[c_collection_types_in_data_contracts#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#8)]  
  
 You may want to use different types in generated code than the default ones. For example, you may want to use Generic <xref:System.ComponentModel.BindingList%601> instead of regular arrays for your data members to make it easier to bind them to user interface components.  
  
 To choose collection types to generate, pass a list of collection types you want to use into the <xref:System.Runtime.Serialization.ImportOptions.ReferencedCollectionTypes%2A> property of the <xref:System.Runtime.Serialization.ImportOptions> object when importing schema. These types are called *referenced collection types*.  
  
 When generic types are being referenced, they must either be fully-open generics or fully-closed generics.  
  
> [!NOTE]
>  When using the Svcutil.exe tool, this reference can be accomplished by using the **/collectionType** command-line switch (short form: **/ct**). Keep in mind that you must also specify the assembly for the referenced collection types using the **/reference** switch (short form: **/r**). If the type is generic, it must be followed by a back quote and the number of generic parameters. The back quote (`) is not to be confused with the single quote (‘) character. You can specify multiple referenced collection types by using the **/collectionType** switch more than once.  
  
 For example, to cause all lists to be imported as Generic <xref:System.Collections.Generic.List%601>.  
  
```  
svcutil.exe MyService.wsdl MyServiceSchema.xsd /r:C:\full_path_to_system_dll\System.dll /ct:System.Collections.Generic.List`1  
```  
  
 When importing any collection, this list of referenced collection types is scanned, and the best-matching collection is used if one is found, either as a data member type (for non-customized collections) or as a base type to derive from (for customized collections). Dictionaries are only matched against dictionaries, while lists are matched against lists.  
  
 For example, if you add the Generic <xref:System.ComponentModel.BindingList%601> and <xref:System.Collections.Hashtable> to the list of referenced types, the generated client code for the preceding example is similar to the following.  
  
 [!code-csharp[c_collection_types_in_data_contracts#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#9)]
 [!code-vb[c_collection_types_in_data_contracts#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#9)]  
  
 You can specify collection interface types as part of your referenced collection types, but you cannot specify invalid collection types (such as ones with no `Add` method or public constructor).  
  
 A closed generic is considered to be the best match. (Non-generic types are considered equivalent to closed generics of `Object`). For example, if the types Generic <xref:System.Collections.Generic.List%601> of <xref:System.DateTime>, Generic <xref:System.ComponentModel.BindingList%601> (open generic), and <xref:System.Collections.ArrayList> are the referenced collection types, the following is generated.  
  
 [!code-csharp[c_collection_types_in_data_contracts#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#10)]
 [!code-vb[c_collection_types_in_data_contracts#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#10)]  
  
 For list collections, only the cases in the following table are supported.  
  
|Referenced type|Interface implemented by referenced type|Example|Type treated as:|  
|---------------------|----------------------------------------------|-------------|----------------------|  
|Non-generic or closed generic (any number of parameters)|Non-generic|`MyType : IList`<br /><br /> or<br /><br /> `MyType<T> : IList`<br /><br /> where T= `int`|Closed generic of `Object` (for example, `IList<object>`)|  
|Non-generic or closed generic (any number of parameters that do not necessarily match the collection type)|Closed generic|`MyType : IList<string>`<br /><br /> or<br /><br /> `MyType<T> : IList<string>` where T=`int`|Closed generic (for example, `IList<string>`)|  
|Closed generic with any number of parameters|Open generic using any one of the type’s parameters|`MyType<T,U,V> : IList<U>`<br /><br /> where T=`int`, U=`string`, V=`bool`|Closed generic (for example, `IList<string>`)|  
|Open generic with one parameter|Open generic using the type’s parameter|`MyType<T> : IList<T>`, T is open|Open generic (for example, `IList<T>`)|  
  
 If a type implements more than one list collection interface, the following restrictions apply:  
  
-   If the type implements Generic <xref:System.Collections.Generic.IEnumerable%601> (or its derived interfaces) multiple times for different types, the type is not considered a valid referenced collection type and is ignored. This is true even if some implementations are invalid or use open generics. For example, a type that implements Generic <xref:System.Collections.Generic.IEnumerable%601> of `int` and Generic <xref:System.Collections.Generic.IEnumerable%601> of T would never be used as a referenced collection of `int` or any other type, regardless of whether the type has an `Add` method accepting `int` or an `Add` method accepting a parameter of type T, or both.  
  
-   If the type implements a generic collection interface as well as <xref:System.Collections.IList>, the type is never used as a referenced collection type unless the generic collection interface is a closed generic of type <xref:System.Object>.  
  
 For dictionary collections, only the cases in the following table are supported.  
  
|Referenced type|Interface implemented by referenced type|Example|Type treated as|  
|---------------------|----------------------------------------------|-------------|---------------------|  
|Non-generic or closed generic (any number of parameters)|<xref:System.Collections.IDictionary>|`MyType : IDictionary`<br /><br /> or<br /><br /> `MyType<T> : IDictionary` where T=`int`|Closed generic `IDictionary<object,object>`|  
|Closed generic (any number of parameters)|<xref:System.Collections.Generic.IDictionary%602>, closed|`MyType<T> : IDictionary<string, bool>` where T=`int`|Closed generic (for example, `IDIctionary<string,bool>`)|  
|Closed generic (any number of parameters)|Generic <xref:System.Collections.Generic.IDictionary%602>, one of either key or value is closed, the other is open and uses one of type’s parameters|`MyType<T,U,V> : IDictionary<string,V>` where T=`int`, U=`float`,V=`bool`<br /><br /> or<br /><br /> `MyType<Z> : IDictionary<Z,bool>` where Z=`string`|Closed generic (For example, `IDictionary<string,bool>`)|  
|Closed generic (any number of parameters)|Generic <xref:System.Collections.Generic.IDictionary%602>, both key and value are open and each uses one of the type’s parameters|`MyType<T,U,V> : IDictionary<V,U>` where T=`int`, U=`bool`, V=`string`|Closed generic (for example, `IDictionary<string,bool>`)|  
|Open generic (two parameters)|Generic <xref:System.Collections.Generic.IDictionary%602>, open, uses both of the type’s generic parameters in the order they appear|`MyType<K,V> : IDictionary<K,V>`, K and V both open|Open generic (for example, `IDictionary<K,V>`)|  
  
 If the type implements both <xref:System.Collections.IDictionary> and Generic <xref:System.Collections.Generic.IDictionary%602>, only Generic <xref:System.Collections.Generic.IDictionary%602> is considered.  
  
 Referencing partial generic types is not supported.  
  
 Duplicates are not allowed, for example, you cannot add both the Generic <xref:System.Collections.Generic.List%601> of `Integer` and the Generic Collection of `Integer` to <xref:System.Runtime.Serialization.ImportOptions.ReferencedCollectionTypes%2A>, because this makes it impossible to determine which one to use when a list of integers is found in the schema. Duplicates are detected only if there is a type in the schema that exposes the duplicates problem. For example, if the schema being imported does not contain lists of integers, it is allowed to have both the Generic <xref:System.Collections.Generic.List%601> of `Integer` and the Generic Collection of `Integer` in the <xref:System.Runtime.Serialization.ImportOptions.ReferencedCollectionTypes%2A>, but neither has any effect.  
  
## Advanced Collection Rules  
  
### Serializing Collections  
 The following is a list of collection rules for serialization:  
  
-   Combining collection types (having collections of collections) is allowed. Jagged arrays are treated as collections of collections. Multidimensional arrays are not supported.  
  
-   Arrays of byte and arrays of <xref:System.Xml.XmlNode> are special array types that are treated as primitives, not collections. Serializing an array of byte results in a single XML element that contains a chunk of Base64-encoded data, instead of a separate element for each byte. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how an array of <xref:System.Xml.XmlNode> is treated, see [XML and ADO.NET Types in Data Contracts](../../../../docs/framework/wcf/feature-details/xml-and-ado-net-types-in-data-contracts.md). Of course, these special types can themselves participate in collections: an array of array of byte results in multiple XML elements, with each containing a chunk of Base64-encoded data.  
  
-   If the <xref:System.Runtime.Serialization.DataContractAttribute> attribute is applied to a collection type, the type is treated as a regular data contract type, not as a collection.  
  
-   If a collection type implements the <xref:System.Xml.Serialization.IXmlSerializable> interface, the following rules apply, given a type `myType:IList<string>, IXmlSerializable`:  
  
    -   If the declared type is `IList<string>`, the type is serialized as a list.  
  
    -   If the declared type is `myType`, it is serialized as `IXmlSerializable`.  
  
    -   If the declared type is `IXmlSerializable`, it is serialized as `IXmlSerializable`, but only if you add `myType` to the list of known types.  
  
-   Collections are serialized and deserialized using the methods shown in the following table.  
  
|Collection type implements|Method(s) called on serialization|Method(s) called on deserialization|  
|--------------------------------|-----------------------------------------|-------------------------------------------|  
|Generic <xref:System.Collections.Generic.IDictionary%602>|`get_Keys`, `get_Values`|Generic Add|  
|<xref:System.Collections.IDictionary>|`get_Keys`, `get_Values`|`Add`|  
|Generic <xref:System.Collections.Generic.IList%601>|Generic <xref:System.Collections.Generic.IList%601> indexer|Generic Add|  
|Generic <xref:System.Collections.Generic.ICollection%601>|Enumerator|Generic Add|  
|<xref:System.Collections.IList>|<xref:System.Collections.IList> Indexer|`Add`|  
|Generic <xref:System.Collections.Generic.IEnumerable%601>|`GetEnumerator`|A non-static method called `Add` that takes one parameter of the appropriate type (the type of the generic parameter or one of its base types). Such a method must exist for the serializer to treat a collection type as a collection during both serialization and deserialization.|  
|<xref:System.Collections.IEnumerable> (and thus <xref:System.Collections.ICollection>, which derives from it)|`GetEnumerator`|A non-static method called `Add` that takes one parameter of type `Object`. Such a method must exist for the serializer to treat a collection type as a collection during both serialization and deserialization.|  
  
 The preceding table lists collection interfaces in descending order of precedence. This means, for example, that if a type implements both <xref:System.Collections.IList> and Generic <xref:System.Collections.Generic.IEnumerable%601>, the collection is serialized and deserialized according to the <xref:System.Collections.IList> rules:  
  
-   At deserialization, all collections are deserialized by first creating an instance of the type by calling the default constructor, which must be present for the serializer to treat a collection type as a collection during both serialization and deserialization.  
  
-   If the same generic collection interface is implemented more than once (for example, if a type implements both Generic <xref:System.Collections.Generic.ICollection%601> of `Integer` and Generic <xref:System.Collections.Generic.ICollection%601> of <xref:System.String>) and no higher-precedence interface is found, the collection is not treated as a valid collection.  
  
-   Collection types can have the <xref:System.SerializableAttribute> attribute applied to them and can implement the <xref:System.Runtime.Serialization.ISerializable> interface. Both of these are ignored. However, if the type does not fully meet collection type requirements (for example, the `Add` method is missing), the type is not considered a collection type, and thus the <xref:System.SerializableAttribute> attribute and the <xref:System.Runtime.Serialization.ISerializable> interface are used to determine whether the type can be serialized.  
  
-   Applying the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute to a collection to customize it removes the <xref:System.SerializableAttribute> preceding fallback mechanism. Instead, if a customized collection does not meet collection type requirements, an <xref:System.Runtime.Serialization.InvalidDataContractException> exception is thrown. The exception string often contains information that explains why a given type is not considered a valid collection (no `Add` method, no default constructor, and so on), so it is often useful to apply the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute for debugging purposes.  
  
### Collection Naming  
 The following is a list of collection naming rules:  
  
-   The default namespace for all dictionary collection data contracts, as well as for list collection data contracts that contain primitive types, is http://schemas.microsoft.com/2003/10/Serialization/Arrays unless overridden using Namespace. Types that map to built-in XSD types, as well as `char`, `Timespan`, and `Guid` types, are considered primitives for this purpose.  
  
-   The default namespace for collection types that contain non-primitive types, unless it is overridden using Namespace, is the same as the data contract namespace of the type contained in the collection.  
  
-   The default name for list collection data contracts, unless overridden using Name, is the string "ArrayOf" combined with the data contract name of the type contained in the collection. For example, the data contract name for a Generic List of Integers is "ArrayOfint". Keep in mind that the data contract name of `Object` is "anyType", so the data contract name of non-generic lists like <xref:System.Collections.ArrayList> is "ArrayOfanyType".  
  
 The default name for dictionary collection data contracts, unless overridden using `Name`, is the string "ArrayOfKeyValueOf" combined with the data contract name of the key type followed by the data contract name of the value type. For example, the data contract name for a Generic Dictionary of String and Integer is "ArrayOfKeyValueOfstringint". Additionally, if either the key or the value types are not primitive types, a namespace hash of the data contract namespaces of the key and value types is appended to the name. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] namespace hashes, see [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md).  
  
 Each dictionary collection data contract has a companion data contract that represents one entry in the dictionary. Its name is the same as for the dictionary data contract, except for the "ArrayOf" prefix, and its namespace is the same as for the dictionary data contract. For example, for the "ArrayOfKeyValueOfstringint" dictionary data contract, the "KeyValueofstringint" data contract represents one entry in the dictionary. You can customize the name of this data contract by using the `ItemName` property, as described in the next section.  
  
 Generic type naming rules, as described in [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md), fully apply to collection types; that is, you can use curly braces within Name to indicate generic type parameters. However, numbers within the braces refer to generic parameters and not types contained within the collection.  
  
## Collection Customization  
 The following uses of the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute are forbidden and result in an <xref:System.Runtime.Serialization.InvalidDataContractException> exception:  
  
-   Applying the <xref:System.Runtime.Serialization.DataContractAttribute> attribute to a type to which the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute has been applied, or to one of its derived types.  
  
-   Applying the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute to a type that implements the <xref:System.Xml.Serialization.IXmlSerializable> interface.  
  
-   Applying the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute to a non-collection type.  
  
-   Attempting to set <xref:System.Runtime.Serialization.CollectionDataContractAttribute.KeyName%2A> or <xref:System.Runtime.Serialization.CollectionDataContractAttribute.ValueName%2A> on a <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute applied to a non-dictionary type.  
  
### Polymorphism Rules  
 As previously mentioned, customizing collections by using the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> attribute may interfere with collection interchangeability. Two customized collection types can only be considered equivalent if their name, namespace, item name, as well as key and value names (if these are dictionary collections) match.  
  
 Due to customizations, it is possible to inadvertently use one collection data contract where another is expected. This should be avoided. See the following types.  
  
 [!code-csharp[c_collection_types_in_data_contracts#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_collection_types_in_data_contracts/cs/program.cs#11)]
 [!code-vb[c_collection_types_in_data_contracts#11](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_collection_types_in_data_contracts/vb/program.vb#11)]  
  
 In this case, an instance of `Marks1` can be assigned to `testMarks`. However, `Marks2` should not be used because its data contract is not considered equivalent to the `IList<int>` data contract. The data contract name is "Marks2" and not "ArrayOfint", and the repeating element name is "\<mark>" and not "\<int>".  
  
 The rules in the following table apply to polymorphic assignment of collections.  
  
|Declared type|Assigning a non-customized collection|Assigning a customized collection|  
|-------------------|--------------------------------------------|---------------------------------------|  
|Object|Contract name is serialized.|Contract name is serialized.<br /><br /> Customization is used.|  
|Collection interface|Contract name is not serialized.|Contract name is not serialized.<br /><br /> Customization is not used.*|  
|Non-customized collection|Contract name is not serialized.|Contract name is serialized.<br /><br /> Customization is used.**|  
|Customized collection|Contract name is serialized. Customization is not used.**|Contract name is serialized.<br /><br /> Customization of the assigned type is used.**|  
  
 *With the <xref:System.Runtime.Serialization.NetDataContractSerializer> class, customization is used in this case. The <xref:System.Runtime.Serialization.NetDataContractSerializer> class also serializes the actual type name in this case, so deserialization works as expected.  
  
 **These cases result in schema-invalid instances and thus should be avoided.  
  
 In the cases where the contract name is serialized, the assigned collection type should be in the known types list. The opposite is also true: in the cases where the name is not serialized, adding the type to the known types list is not required.  
  
 An array of a derived type can be assigned to an array of a base type. In this case, the contract name for the derived type is serialized for each repeating element. For example, if a type `Book` derives from the type `LibraryItem`, you can assign an array of `Book` to an array of `LibraryItem`. This does not apply to other collection types. For example, you cannot assign a `Generic List of Book` to a `Generic List of LibraryItem`. You can, however, assign a `Generic List of LibraryItem` that contains `Book` instances. In both the array and the non-array case, `Book` should be in the known types list.  
  
## Collections and Object Reference Preservation  
 When a serializer functions in a mode where it preserves object references, object reference preservation also applies to collections. Specifically, object identity is preserved for both entire collections and individual items contained in collections. For dictionaries, object identity is preserved both for the key/value pair objects and the individual key and value objects.  
  
## See Also  
 <xref:System.Runtime.Serialization.CollectionDataContractAttribute>
