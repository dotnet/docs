---
title: "How to initialize a dictionary with a collection initializer - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "collection initializers [C#], with Dictionary"
ms.assetid: 25283922-f8ee-40dc-a639-fac30804ec71
---
# How to initialize a dictionary with a collection initializer (C# Programming Guide)

A <xref:System.Collections.Generic.Dictionary%602> contains a collection of key/value pairs. Its <xref:System.Collections.Generic.Dictionary%602.Add*> method takes two parameters, one for the key and one for the value. To initialize a <xref:System.Collections.Generic.Dictionary%602>, or any collection whose `Add` method takes multiple parameters, enclose each set of parameters in braces as shown in the following example.

## Example

In the following code example, a <xref:System.Collections.Generic.Dictionary%602> is initialized with instances of type `StudentName`.  
  
[!code-csharp[csProgGuideLINQ#34](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-initialize-a-dictionary-with-a-collection-initializer_1.cs)]

Note the two pairs of braces in each element of the collection. The innermost braces enclose the object initializer for the `StudentName`, and the outermost braces enclose the initializer for the key/value pair that will be added to the `students` <xref:System.Collections.Generic.Dictionary%602>. Finally, the whole collection initializer for the dictionary is enclosed in braces.

## Compiling the code

To run this code, copy and paste the class into a Visual C# console application project that has been created in Visual Studio. By default, this project targets version 3.5 of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)], and it has a reference to System.Core.dll and a using directive for System.Linq. If one or more of these requirements are missing from the project, you can add them manually.

## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Object and Collection Initializers](../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md)
