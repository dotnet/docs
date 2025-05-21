---
title: "Access attributes using reflection"
description: Use reflection to get information defined with custom attributes in C# by using the GetCustomAttributes method.
ms.date: 03/15/2023
ms.topic: how-to
---
# Access attributes using reflection

The fact that you can define custom attributes and place them in your source code would be of little value without some way of retrieving that information and acting on it. By using reflection, you can retrieve the information that was defined with custom attributes. The key method is `GetCustomAttributes`, which returns an array of objects that are the run-time equivalents of the source code attributes. This method has many overloaded versions. For more information, see <xref:System.Attribute>.

An attribute specification such as:

```csharp
[Author("P. Ackerman", Version = 1.1)]
class SampleClass { }
```

is conceptually equivalent to the following code:

```csharp
var anonymousAuthorObject = new Author("P. Ackerman")
{
    Version = 1.1
};
```

However, the code isn't executed until `SampleClass` is queried for attributes. Calling `GetCustomAttributes` on `SampleClass` causes an `Author` object to be constructed and initialized. If the class has other attributes, other attribute objects are constructed similarly. `GetCustomAttributes` then returns the `Author` object and any other attribute objects in an array. You can then iterate over this array, determine what attributes were applied based on the type of each array element, and extract information from the attribute objects.

Here's a complete example. A custom attribute is defined, applied to several entities, and retrieved via reflection.

:::code language="csharp" source="./snippets/conceptual/ReadAttributes.cs" id="DefineAndReadAttribute":::

## See also

- <xref:System.Reflection>
- <xref:System.Attribute>
- [Retrieving Information Stored in Attributes](../../../standard/attributes/retrieving-information-stored-in-attributes.md)
