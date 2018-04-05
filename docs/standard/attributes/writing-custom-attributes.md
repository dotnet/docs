---
title: "Writing Custom Attributes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "multiple attribute instances"
  - "AttributeTargets enumeration"
  - "attributes [.NET Framework], custom"
  - "AllowMultiple property"
  - "custom attributes"
  - "AttributeUsageAttribute class, custom attributes"
  - "Inherited property"
  - "attribute classes, declaring"
ms.assetid: 97216f69-bde8-49fd-ac40-f18c500ef5dc
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Writing Custom Attributes
To design your own custom attributes, you do not need to master many new concepts. If you are familiar with object-oriented programming and know how to design classes, you already have most of the knowledge needed. Custom attributes are essentially traditional classes that derive directly or indirectly from <xref:System.Attribute?displayProperty=nameWithType>. Just like traditional classes, custom attributes contain methods that store and retrieve data.  
  
 The primary steps to properly design custom attribute classes are as follows:  
  
-   [Applying the AttributeUsageAttribute](#cpconapplyingattributeusageattribute)  
  
-   [Declaring the attribute class](#cpcondeclaringattributeclass)  
  
-   [Declaring constructors](#cpcondeclaringconstructors)  
  
-   [Declaring properties](#cpcondeclaringproperties)  
  
 This section describes each of these steps and concludes with a [custom attribute example](#cpconcustomattributeexample).  
  
<a name="cpconapplyingattributeusageattribute"></a>   
## Applying the AttributeUsageAttribute  
 A custom attribute declaration begins with the **AttributeUsageAttribute**, which defines some of the key characteristics of your attribute class. For example, you can specify whether your attribute can be inherited by other classes or specify which elements the attribute can be applied to. The following code fragment demonstrates how to use the **AttributeUsageAttribute**.  
  
 [!code-cpp[Conceptual.Attributes.Usage#5](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#5)]
 [!code-csharp[Conceptual.Attributes.Usage#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#5)]
 [!code-vb[Conceptual.Attributes.Usage#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#5)]  
  
 The <xref:System.AttributeUsageAttribute?displayProperty=nameWithType> has three members that are important for the creation of custom attributes: [AttributeTargets](#cpconwritingcustomattributesanchor1), [Inherited](#cpconwritingcustomattributesanchor2), and [AllowMultiple](#cpconwritingcustomattributesanchor3).  
  
<a name="cpconwritingcustomattributesanchor1"></a>   
### AttributeTargets Member  
 In the previous example, **AttributeTargets.All** is specified, indicating that this attribute can be applied to all program elements. Alternatively, you can specify **AttributeTargets.Class**, indicating that your attribute can be applied only to a class, or **AttributeTargets.Method**, indicating that your attribute can be applied only to a method. All program elements can be marked for description by a custom attribute in this manner.  
  
 You can also pass multiple instances of <xref:System.AttributeTargets>. The following code fragment specifies that a custom attribute can be applied to any class or method.  
  
 [!code-cpp[Conceptual.Attributes.Usage#6](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#6)]
 [!code-csharp[Conceptual.Attributes.Usage#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#6)]
 [!code-vb[Conceptual.Attributes.Usage#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#6)]  
  
<a name="cpconwritingcustomattributesanchor2"></a>   
### Inherited Property  
 The <xref:System.AttributeUsageAttribute.Inherited%2A?displayProperty=nameWithType> property indicates whether your attribute can be inherited by classes that are derived from the classes to which your attribute is applied. This property takes either a **true** (the default) or **false** flag. For example, in the following example, `MyAttribute` has a default <xref:System.AttributeUsageAttribute.Inherited%2A> value of **true**, while `YourAttribute` has an <xref:System.AttributeUsageAttribute.Inherited%2A> value of **false**.  
  
 [!code-cpp[Conceptual.Attributes.Usage#7](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#7)]
 [!code-csharp[Conceptual.Attributes.Usage#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#7)]
 [!code-vb[Conceptual.Attributes.Usage#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#7)]  
  
 The two attributes are then applied to a method in the base class `MyClass`.  
  
 [!code-cpp[Conceptual.Attributes.Usage#9](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#9)]
 [!code-csharp[Conceptual.Attributes.Usage#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#9)]
 [!code-vb[Conceptual.Attributes.Usage#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#9)]  
  
 Finally, the class `YourClass` is inherited from the base class `MyClass`. The method `MyMethod` shows `MyAttribute`, but not `YourAttribute`.  
  
 [!code-cpp[Conceptual.Attributes.Usage#10](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#10)]
 [!code-csharp[Conceptual.Attributes.Usage#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#10)]
 [!code-vb[Conceptual.Attributes.Usage#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#10)]  
  
<a name="cpconwritingcustomattributesanchor3"></a>   
### AllowMultiple Property  
 The <xref:System.AttributeUsageAttribute.AllowMultiple%2A?displayProperty=nameWithType> property indicates whether multiple instances of your attribute can exist on an element. If set to **true**, multiple instances are allowed; if set to **false** (the default), only one instance is allowed.  
  
 In the following example, `MyAttribute` has a default <xref:System.AttributeUsageAttribute.AllowMultiple%2A> value of **false**, while `YourAttribute` has a value of **true**.  
  
 [!code-cpp[Conceptual.Attributes.Usage#11](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#11)]
 [!code-csharp[Conceptual.Attributes.Usage#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#11)]
 [!code-vb[Conceptual.Attributes.Usage#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#11)]  
  
 When multiple instances of these attributes are applied, `MyAttribute` produces a compiler error. The following code example shows the valid use of `YourAttribute` and the invalid use of `MyAttribute`.  
  
 [!code-cpp[Conceptual.Attributes.Usage#13](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#13)]
 [!code-csharp[Conceptual.Attributes.Usage#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#13)]
 [!code-vb[Conceptual.Attributes.Usage#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#13)]  
  
 If both the <xref:System.AttributeUsageAttribute.AllowMultiple%2A> property and the <xref:System.AttributeUsageAttribute.Inherited%2A> property are set to **true**, a class that is inherited from another class can inherit an attribute and have another instance of the same attribute applied in the same child class. If <xref:System.AttributeUsageAttribute.AllowMultiple%2A> is set to **false**, the values of any attributes in the parent class will be overwritten by new instances of the same attribute in the child class.  
  
<a name="cpcondeclaringattributeclass"></a>   
## Declaring the Attribute Class  
 After you apply the <xref:System.AttributeUsageAttribute>, you can begin to define the specifics of your attribute. The declaration of an attribute class looks similar to the declaration of a traditional class, as demonstrated by the following code.  
  
 [!code-cpp[Conceptual.Attributes.Usage#14](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#14)]
 [!code-csharp[Conceptual.Attributes.Usage#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#14)]
 [!code-vb[Conceptual.Attributes.Usage#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#14)]  
  
 This attribute definition demonstrates the following points:  
  
-   Attribute classes must be declared as public classes.  
  
-   By convention, the name of the attribute class ends with the word **Attribute**. While not required, this convention is recommended for readability. When the attribute is applied, the inclusion of the word Attribute is optional.  
  
-   All attribute classes must inherit directly or indirectly from **System.Attribute**.  
  
-   In Microsoft Visual Basic, all custom attribute classes must have the **AttributeUsageAttribute** attribute.  
  
<a name="cpcondeclaringconstructors"></a>   
## Declaring Constructors  
 Attributes are initialized with constructors in the same way as traditional classes. The following code fragment illustrates a typical attribute constructor. This public constructor takes a parameter and sets its value equal to a member variable.  
  
 [!code-cpp[Conceptual.Attributes.Usage#15](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#15)]
 [!code-csharp[Conceptual.Attributes.Usage#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#15)]
 [!code-vb[Conceptual.Attributes.Usage#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#15)]  
  
 You can overload the constructor to accommodate different combinations of values. If you also define a [property](https://msdn.microsoft.com/library/8f1a1ff1-0f05-40e0-bfdf-80de8fff7d52) for your custom attribute class, you can use a combination of named and positional parameters when initializing the attribute. Typically, you define all required parameters as positional and all optional parameters as named. In this case, the attribute cannot be initialized without the required parameter. All other parameters are optional. Note that in Visual Basic, constructors for an attribute class should not use a ParamArray argument.  
  
 The following code example shows how an attribute that uses the previous constructor can be applied using optional and required parameters. It assumes that the attribute has one required Boolean value and one optional string property.  
  
 [!code-cpp[Conceptual.Attributes.Usage#17](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#17)]
 [!code-csharp[Conceptual.Attributes.Usage#17](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#17)]
 [!code-vb[Conceptual.Attributes.Usage#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#17)]  
  
<a name="cpcondeclaringproperties"></a>   
## Declaring Properties  
 If you want to define a named parameter or provide an easy way to return the values stored by your attribute, declare a [property](https://msdn.microsoft.com/library/8f1a1ff1-0f05-40e0-bfdf-80de8fff7d52). Attribute properties should be declared as public entities with a description of the data type that will be returned. Define the variable that will hold the value of your property and associate it with the **get** and **set** methods. The following code example demonstrates how to implement a simple property in your attribute.  
  
 [!code-cpp[Conceptual.Attributes.Usage#16](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#16)]
 [!code-csharp[Conceptual.Attributes.Usage#16](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#16)]
 [!code-vb[Conceptual.Attributes.Usage#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#16)]  
  
<a name="cpconcustomattributeexample"></a>   
## Custom Attribute Example  
 This section incorporates the previous information and shows how to design a simple attribute that documents information about the author of a section of code. The attribute in this example stores the name and level of the programmer, and whether the code has been reviewed. It uses three private variables to store the actual values to save. Each variable is represented by a public property that gets and sets the values. Finally, the constructor is defined with two required parameters.  
  
 [!code-cpp[Conceptual.Attributes.Usage#4](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#4)]
 [!code-csharp[Conceptual.Attributes.Usage#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#4)]
 [!code-vb[Conceptual.Attributes.Usage#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#4)]  
  
 You can apply this attribute using the full name, `DeveloperAttribute`, or using the abbreviated name, `Developer`, in one of the following ways.  
  
 [!code-cpp[Conceptual.Attributes.Usage#12](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source2.cpp#12)]
 [!code-csharp[Conceptual.Attributes.Usage#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source2.cs#12)]
 [!code-vb[Conceptual.Attributes.Usage#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source2.vb#12)]  
  
 The first example shows the attribute applied with only the required named parameters, while the second example shows the attribute applied with both the required and optional parameters.  
  
## See Also  
 <xref:System.Attribute?displayProperty=nameWithType>  
 <xref:System.AttributeUsageAttribute>  
 [Attributes](../../../docs/standard/attributes/index.md)
