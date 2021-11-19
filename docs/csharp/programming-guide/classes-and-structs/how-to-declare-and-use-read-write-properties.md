---
title: "How to declare and use read write properties - C# Programming Guide"
description: Learn how to use read/write properties in C#. This sample includes two properties, each of which has get and set accessors, so the properties are read/write.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "get accessor [C#], declaring properties"
  - "set accessor [C#]"
  - "properties [C#], declaring"
  - "read/write properties [C#]"
  - "accessors [C#], declaring properties with"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: a4962fef-af7e-4c4b-a929-4ae4d646ab8a
---
# How to declare and use read write properties (C# Programming Guide)

Properties provide the convenience of public data members without the risks that come with unprotected, uncontrolled, and unverified access to an object's data. This is accomplished through *accessors*: special methods that assign and retrieve values from the underlying data member. The [set](../../language-reference/keywords/set.md) accessor enables data members to be assigned, and the [get](../../language-reference/keywords/get.md) accessor retrieves data member values.  
  
 This sample shows a `Person` class that has two properties: `Name` (string) and `Age` (int). Both properties provide `get` and `set` accessors, so they are considered read/write properties.  
  
## Example  

 [!code-csharp[properties#1](snippets/how-to-declare-and-use-read-write-properties/Program.cs#1)]
  
## Robust Programming  

 In the previous example, the `Name` and `Age` properties are [public](../../language-reference/keywords/public.md) and include both a `get` and a `set` accessor. This allows any object to read and write these properties. It is sometimes desirable, however, to exclude one of the accessors. Omitting the `set` accessor, for example, makes the property read-only:  
  
 [!code-csharp[properties#2](snippets/how-to-declare-and-use-read-write-properties/Program.cs#2)]
  
 Alternatively, you can expose one accessor publicly but make the other private or protected. For more information, see [Asymmetric Accessor Accessibility](./restricting-accessor-accessibility.md).  
  
 Once the properties are declared, they can be used as if they were fields of the class. This allows for a very natural syntax when both getting and setting the value of a property, as in the following statements:  
  
 [!code-csharp[properties#3](snippets/how-to-declare-and-use-read-write-properties/Program.cs#3)]
  
 Note that in a property `set` method a special `value` variable is available. This variable contains the value that the user specified, for example:  
  
 [!code-csharp[properties#4](snippets/how-to-declare-and-use-read-write-properties/Program.cs#4)]
  
 Notice the clean syntax for incrementing the `Age` property on a `Person` object:  
  
 [!code-csharp[properties#5](snippets/how-to-declare-and-use-read-write-properties/Program.cs#5)]
  
 If separate `set` and `get` methods were used to model properties, the equivalent code might look like this:  
  
```csharp  
person.SetAge(person.GetAge() + 1);
```  
  
 The `ToString` method is overridden in this example:  
  
 [!code-csharp[properties#6](snippets/how-to-declare-and-use-read-write-properties/Program.cs#6)]
  
 Notice that `ToString` is not explicitly used in the program. It is invoked by default by the `WriteLine` calls.  
  
## See also

- [C# Programming Guide](../index.md)
- [Properties](./properties.md)
- [The C# type system](../../fundamentals/types/index.md)
