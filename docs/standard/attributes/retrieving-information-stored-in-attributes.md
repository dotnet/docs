---
title: "Retrieving Information Stored in Attributes"
description: Learn to retrieve information stored in attributes, including for an attribute instance, multiple instances for the same scope, multiple instances for different scopes, and attributes applied to class members.
ms.date: "08/05/2022"
ms.custom: devdivchpfy22
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "retrieving attributes"
  - "multiple attribute instances"
  - "attributes [.NET], retrieving"
ms.topic: how-to
---
# Retrieving Information Stored in Attributes

Retrieving a custom attribute is a simple process. First, declare an instance of the attribute you want to retrieve. Then, use the <xref:System.Attribute.GetCustomAttribute%2A?displayProperty=nameWithType> method to initialize the new attribute to the value of the attribute you want to retrieve. Once the new attribute is initialized, you can use its properties to get the values.

> [!IMPORTANT]
> This article describes how to retrieve attributes for code loaded into the execution context. To retrieve attributes for code loaded into the reflection-only context, you must use the <xref:System.Reflection.CustomAttributeData> class, as shown in [How to: Load Assemblies into the Reflection-Only Context](../../framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md).

 This section describes the following ways to retrieve attributes:

- [Retrieving a single instance of an attribute](#cpconretrievingsingleinstanceofattribute)

- [Retrieving multiple instances of an attribute applied to the same scope](#cpconretrievingmultipleinstancesofattributeappliedtosamescope)

- [Retrieving multiple instances of an attribute applied to different scopes](#cpconretrievingmultipleinstancesofattributeappliedtodifferentscopes)

<a name="cpconretrievingsingleinstanceofattribute"></a>

## Retrieving a Single Instance of an Attribute

 In the following example, the `DeveloperAttribute` (described in the previous section) is applied to the `MainApp` class on the class level. The `GetAttribute` method uses `GetCustomAttribute` to retrieve the values stored in `DeveloperAttribute` on the class level before displaying them to the console.

 [!code-csharp[Conceptual.Attributes.Usage#18](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source3.cs#18)]
 [!code-vb[Conceptual.Attributes.Usage#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source3.vb#18)]

 The execution of the preceding program displays the following text:

```console
The Name Attribute is: Joan Smith.
The Level Attribute is: 42.
The Reviewed Attribute is: True.
```

 If the attribute isn't found, the `GetCustomAttribute` method initializes `MyAttribute` to a null value. This example checks `MyAttribute` for such an instance and notifies the user if the attribute isn't found. If `DeveloperAttribute` isn't found in the class scope, the console displays the following message:

```console
The attribute was not found.
```

 The preceding example assumes that the attribute definition is in the current namespace. Remember to import the namespace in which the attribute definition resides if it isn't in the current namespace.

<a name="cpconretrievingmultipleinstancesofattributeappliedtosamescope"></a>

## Retrieving Multiple Instances of an Attribute Applied to the Same Scope

 In the preceding example, the class to inspect and the specific attribute to find are passed to the <xref:System.Attribute.GetCustomAttribute%2A> method. That code works well if only one instance of an attribute is applied on the class level. However, if multiple instances of an attribute are applied on the same class level, the `GetCustomAttribute` method doesn't retrieve all the information. In cases where multiple instances of the same attribute are applied to the same scope, you can use <xref:System.Attribute.GetCustomAttributes%2A?displayProperty=nameWithType> method to place all instances of an attribute into an array. For example, if two instances of `DeveloperAttribute` are applied on the class level of the same class, the `GetAttribute` method can be modified to display the information found in both attributes. Remember, to apply multiple attributes on the same level. The attribute must be defined with the `AllowMultiple` property set to `true` in the <xref:System.AttributeUsageAttribute> class.

 The following code example shows how to use the `GetCustomAttributes` method to create an array that references all instances of `DeveloperAttribute` in any given class. The code then outputs the values of all the attributes to the console.

 [!code-csharp[Conceptual.Attributes.Usage#19](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source3.cs#19)]
 [!code-vb[Conceptual.Attributes.Usage#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source3.vb#19)]

 If no attributes are found, this code alerts the user. Otherwise, the information contained in both instances of `DeveloperAttribute` is displayed.

<a name="cpconretrievingmultipleinstancesofattributeappliedtodifferentscopes"></a>

## Retrieving Multiple Instances of an Attribute Applied to Different Scopes

 The <xref:System.Attribute.GetCustomAttributes%2A> and <xref:System.Attribute.GetCustomAttribute%2A> methods don't search an entire class and return all instances of an attribute in that class. Rather, they search only one specified method or member at a time. If you have a class with the same attribute applied to every member and you want to retrieve the values in all the attributes applied to those members, you must supply every method or member individually to `GetCustomAttributes` and `GetCustomAttribute`.

 The following code example takes a class as a parameter and searches for the `DeveloperAttribute` (defined previously) on the class level and on every individual method of that class:

 [!code-csharp[Conceptual.Attributes.Usage#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source3.cs#20)]
 [!code-vb[Conceptual.Attributes.Usage#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source3.vb#20)]

 If no instances of the `DeveloperAttribute` are found on the method level or class level, the `GetAttribute` method notifies the user that no attributes were found and displays the name of the method or class that doesn't contain the attribute. If an attribute is found, the console displays the `Name`, `Level`, and `Reviewed` fields.

 You can use the members of the <xref:System.Type> class to get the individual methods and members in the passed class. This example first queries the `Type` object to get attribute information for the class level. Next, it uses <xref:System.Type.GetMethods%2A?displayProperty=nameWithType> to place instances of all methods into an array of <xref:System.Reflection.MemberInfo?displayProperty=nameWithType> objects to retrieve attribute information for the method level. You can also use the <xref:System.Type.GetProperties%2A?displayProperty=nameWithType> method to check for attributes on the property level or <xref:System.Type.GetConstructors%2A?displayProperty=nameWithType> to check for attributes on the constructor level.

## Retrieving Attributes from Class Members

In addition to retrieving attributes at the class level, attributes can also be applied to individual members such as methods, properties, and fields. The `GetCustomAttribute` and `GetCustomAttributes` methods can be used to retrieve these attributes.

### Example

The following example demonstrates how to retrieve an attribute applied to a method:

[!code-csharp[Conceptual.Attributes.Usage#21](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source4.cs#21)]

## See also

- <xref:System.Type?displayProperty=nameWithType>
- <xref:System.Attribute.GetCustomAttribute%2A?displayProperty=nameWithType>
- <xref:System.Attribute.GetCustomAttributes%2A?displayProperty=nameWithType>
- [Attributes](index.md)
