---
title: "Data Contract Known Types"
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
  - "data contracts [WCF], known types"
  - "KnownTypeAttribute [WCF]"
  - "KnownTypes [WCF]"
ms.assetid: 1a0baea1-27b7-470d-9136-5bbad86c4337
caps.latest.revision: 42
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Contract Known Types
The <xref:System.Runtime.Serialization.KnownTypeAttribute> class allows you to specify, in advance, the types that should be included for consideration during deserialization. For a working example, see the [Known Types](../../../../docs/framework/wcf/samples/known-types.md) example.  
  
 Normally, when passing parameters and return values between a client and a service, both endpoints share all of the data contracts of the data to be transmitted. However, this is not the case in the following circumstances:  
  
-   The sent data contract is derived from the expected data contract. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the section about inheritance in [Data Contract Equivalence](../../../../docs/framework/wcf/feature-details/data-contract-equivalence.md)). In that case, the transmitted data does not have the same data contract as expected by the receiving endpoint.  
  
-   The declared type for the information to be transmitted is an interface, as opposed to a class, structure, or enumeration. Therefore, it cannot be known in advance which type that implements the interface is actually sent and therefore, the receiving endpoint cannot determine in advance the data contract for the transmitted data.  
  
-   The declared type for the information to be transmitted is <xref:System.Object>. Because every type inherits from <xref:System.Object>, and it cannot be known in advance which type is actually sent, the receiving endpoint cannot determine in advance the data contract for the transmitted data. This is a special case of the first item: Every data contract derives from the default, a blank data contract that is generated for <xref:System.Object>.  
  
-   Some types, which include [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types, have members that are in one of the preceding three categories. For example, <xref:System.Collections.Hashtable> uses <xref:System.Object> to store the actual objects in the hash table. When serializing these types, the receiving side cannot determine in advance the data contract for these members.  
  
## The KnownTypeAttribute Class  
 When data arrives at a receiving endpoint, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime attempts to deserialize the data into an instance of a common language runtime (CLR) type. The type that is instantiated for deserialization is chosen by first inspecting the incoming message to determine the data contract to which the contents of the message conform. The deserialization engine then attempts to find a CLR type that implements a data contract compatible with the message contents. The set of candidate types that the deserialization engine allows for during this process is referred to as the deserializer's set of "known types."  
  
 One way to let the deserialization engine know about a type is by using the <xref:System.Runtime.Serialization.KnownTypeAttribute>. The attribute cannot be applied to individual data members, only to whole data contract types. The attribute is applied to an *outer type* that can be a class or a structure. In its most basic usage, applying the attribute specifies a type as a "known type." This causes the known type to be a part of the set of known types whenever an object of the outer type or any object referred to through its members is being deserialized. More than one <xref:System.Runtime.Serialization.KnownTypeAttribute> attribute can be applied to the same type.  
  
## Known Types and Primitives  
 Primitive types, as well as certain types treated as primitives (for example, <xref:System.DateTime> and <xref:System.Xml.XmlElement>) are always "known" and never have to be added through this mechanism. However, arrays of primitive types have to be added explicitly. Most collections are considered equivalent to arrays. (Non-generic collections are considered equivalent to arrays of <xref:System.Object>). For an example of the using primitives, primitive arrays, and primitive collections, see Example 4.  
  
> [!NOTE]
>  Unlike other primitive types, the <xref:System.DateTimeOffset> structure is not a known type by default, so it must be manually added to the list of known types.  
  
## Examples  
 The following examples show the <xref:System.Runtime.Serialization.KnownTypeAttribute> class in use.  
  
#### Example 1  
 There are three classes with an inheritance relationship.  
  
 [!code-csharp[C_KnownTypeAttribute#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#1)]
 [!code-vb[C_KnownTypeAttribute#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#1)]  
  
 The following `CompanyLogo` class can be serialized, but cannot be deserialized if the `ShapeOfLogo` member is set to either a `CircleType` or a `TriangleType` object, because the deserialization engine does not recognize any types with data contract names "Circle" or "Triangle."  
  
 [!code-csharp[C_KnownTypeAttribute#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#2)]
 [!code-vb[C_KnownTypeAttribute#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#2)]  
  
 The correct way to write the `CompanyLogo` type is shown in the following code.  
  
 [!code-csharp[C_KnownTypeAttribute#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#3)]
 [!code-vb[C_KnownTypeAttribute#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#3)]  
  
 Whenever the outer type `CompanyLogo2` is being deserialized, the deserialization engine knows about `CircleType` and `TriangleType` and, therefore, is able to find matching types for the "Circle" and "Triangle" data contracts.  
  
#### Example 2  
 In the following example, even though both `CustomerTypeA` and `CustomerTypeB` have the `Customer` data contract, an instance of `CustomerTypeB` is created whenever a `PurchaseOrder` is deserialized, because only `CustomerTypeB` is known to the deserialization engine.  
  
 [!code-csharp[C_KnownTypeAttribute#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#4)]
 [!code-vb[C_KnownTypeAttribute#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#4)]  
  
#### Example 3  
 In the following example, a <xref:System.Collections.Hashtable> stores its contents internally as <xref:System.Object>. To successfully deserialize a hash table, the deserialization engine must know the set of possible types that can occur there. In this case, we know in advance that only `Book` and `Magazine` objects are stored in the `Catalog`, so those are added using the <xref:System.Runtime.Serialization.KnownTypeAttribute> attribute.  
  
 [!code-csharp[C_KnownTypeAttribute#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#5)]
 [!code-vb[C_KnownTypeAttribute#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#5)]  
  
#### Example 4  
 In the following example, a data contract stores a number and an operation to perform on the number. The `Numbers` data member can be an integer, an array of integers, or a <xref:System.Collections.Generic.List%601> that contains integers.  
  
> [!CAUTION]
>  This will only work on the client side if SVCUTIL.EXE is used to generate a WCF proxy. SVCUTIL.EXE retrieves metadata from the service including any known types. Without this information a client will not be able to deserialize the types.  
  
 [!code-csharp[C_KnownTypeAttribute#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#6)]
 [!code-vb[C_KnownTypeAttribute#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#6)]  
  
 This is the application code.  
  
 [!code-csharp[C_KnownTypeAttribute#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#7)]
 [!code-vb[C_KnownTypeAttribute#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#7)]  
  
## Known Types, Inheritance, and Interfaces  
 When a known type is associated with a particular type using the `KnownTypeAttribute` attribute, the known type is also associated with all of the derived types of that type. For example, see the following code.  
  
 [!code-csharp[C_KnownTypeAttribute#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#8)]
 [!code-vb[C_KnownTypeAttribute#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#8)]  
  
 The `DoubleDrawing` class does not require the `KnownTypeAttribute` attribute to use `Square` and `Circle` in the `AdditionalShape` field, because the base class (`Drawing`) already has these attributes applied.  
  
 Known types can be associated only with classes and structures, not interfaces.  
  
## Known Types Using Open Generic Methods  
 It may be necessary to add a generic type as a known type. However, an open generic type cannot be passed as a parameter to the `KnownTypeAttribute` attribute.  
  
 This problem can be solved by using an alternative mechanism: Write a method that returns a list of types to add to the known types collection. The name of the method is then specified as a string argument to the `KnownTypeAttribute` attribute due to some restrictions.  
  
 The method must exist on the type to which the `KnownTypeAttribute` attribute is applied, must be static, must accept no parameters, and must return an object that can be assigned to <xref:System.Collections.IEnumerable> of <xref:System.Type>.  
  
 You cannot combine the `KnownTypeAttribute` attribute with a method name and `KnownTypeAttribute` attributes with actual types on the same type. Furthermore, you cannot apply more than one `KnownTypeAttribute` with a method name to the same type.  
  
 See the following class.  
  
 [!code-csharp[C_KnownTypeAttribute#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#9)]
 [!code-vb[C_KnownTypeAttribute#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#9)]  
  
 The `theDrawing` field contains instances of a generic class `ColorDrawing` and a generic class `BlackAndWhiteDrawing`, both of which inherit from a generic class `Drawing`. Normally, both must be added to known types, but the following is not valid syntax for attributes.  
  
```csharp  
// Invalid syntax for attributes:  
// [KnownType(typeof(ColorDrawing<T>))]  
// [KnownType(typeof(BlackAndWhiteDrawing<T>))]  
```  
  
```vb  
' Invalid syntax for attributes:  
' <KnownType(GetType(ColorDrawing(Of T))), _  
' KnownType(GetType(BlackAndWhiteDrawing(Of T)))>  
```  
  
 Thus, a method must be created to return these types. The correct way to write this type, then, is shown in the following code.  
  
 [!code-csharp[C_KnownTypeAttribute#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_knowntypeattribute/cs/source.cs#10)]
 [!code-vb[C_KnownTypeAttribute#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_knowntypeattribute/vb/source.vb#10)]  
  
## Additional Ways to Add Known Types  
 Additionally, known types can be added through a configuration file. This is useful when you do not control the type that requires known types for proper deserialization, such as when using third-party type libraries with [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)].  
  
 The following configuration file shows how to specify a known type in a configuration file.  
  
 `<configuration>`  
  
 `<system.runtime.serialization>`  
  
 `<dataContractSerializer>`  
  
 `<declaredTypes>`  
  
 `<add type="MyCompany.Library.Shape,`  
  
 `MyAssembly, Version=2.0.0.0, Culture=neutral,`  
  
 `PublicKeyToken=XXXXXX, processorArchitecture=MSIL">`  
  
 `<knownType type="MyCompany.Library.Circle,`  
  
 `MyAssembly, Version=2.0.0.0, Culture=neutral,`  
  
 `PublicKeyToken=XXXXXX, processorArchitecture=MSIL"/>`  
  
 `</add>`  
  
 `</declaredTypes>`  
  
 `</dataContractSerializer>`  
  
 `</system.runtime.serialization>`  
  
 `</configuration>`  
  
 In the preceding configuration file a data contract type called `MyCompany.Library.Shape` is declared to have `MyCompany.Library.Circle` as a known type.  
  
## See Also  
 <xref:System.Runtime.Serialization.KnownTypeAttribute>  
 <xref:System.Collections.Hashtable>  
 <xref:System.Object>  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Runtime.Serialization.DataContractSerializer.KnownTypes%2A>  
 [Known Types](../../../../docs/framework/wcf/samples/known-types.md)  
 [Data Contract Equivalence](../../../../docs/framework/wcf/feature-details/data-contract-equivalence.md)  
 [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md)
