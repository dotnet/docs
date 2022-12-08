---
title: "How to determine if a .NET Standard object is binary serializable"
description: "Shows how to determine whether a .NET Standard type can be binary serialized at run time."
ms.date: 11/15/2022
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "serializing objects"
  - "objects, serializing steps"
---
# How to determine if a .NET Standard object is binary serializable

.NET Standard is a specification that defines the types and members that must be present on specific .NET implementations that conform to that version of the standard. However, .NET Standard does not define whether a type is serializable. The types defined in the .NET Standard Library are not marked with the <xref:System.SerializableAttribute> attribute. Instead, specific .NET implementations, such as .NET Framework and .NET Core, are free to determine whether a particular type is binary serializable.

If you've developed a library that targets .NET Standard, your library can be consumed by any .NET implementation that supports .NET Standard. This means that you cannot know in advance whether a particular type is binary serializable; you can only determine that at run time.

You can determine whether an object is binary serializable at run time by retrieving the value of the <xref:System.Type.IsSerializable> property of a <xref:System.Type> object that represents that object's type. The following example provides one implementation. It defines an `IsSerializable(Object)` extension method that indicates whether any <xref:System.Object> instance can be binary serialized.

[!code-csharp[is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/csharp/program.cs#2)]
[!code-vb[is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/vb/library.vb#2)]

You can then pass any object to the method to determine whether it can be binary serialized and deserialized on the current .NET implementation, as the following example shows:

[!code-csharp[test-is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/csharp/program.cs#1)]
[!code-vb[test-is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/vb/program.vb#1)]

## See also

- [Binary serialization](binary-serialization.md)
- <xref:System.SerializableAttribute?displayProperty=nameWithType>
- <xref:System.Type.IsSerializable?displayProperty=nameWithType>
