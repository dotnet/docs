---
title: "How to: Determine if a .NET Standard object is serializable"
description: "Shows how to determine whether a .NET Standard type can be serialized at run time."
ms.custom: ""
ms.date: "10/20/2017"
ms.prod: ".net"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "serializing objects"
  - "objects, serializing steps"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Determine if a .NET Standard object is serializable

The .NET Standard is a specification that defines the types and members that must be present on specific .NET implementations that conform to that version of the standard. However, the .NET Standard does not define whether a type is serializable. The types defined in the .NET Standard Library are not marked with the <xref:System.SerializableAttribute> attribute. Instead, specific .NET implementations, such as the .NET Framework and .NET Core, are free to determine whether a particular type is serializable. 

If you've developed a library that targets the .NET Standard, your library can be consumed by any .NET implementation that supports the .NET Standard. This means that you cannot know in advance whether a particular type is serializable; you can only determine whether it is serializable at run time.

You can determine whether an object is serializable at runtime by retrieving the value of the <xref:System.Type.IsSerializable> property of a <xref:System.Type> object that represents that object's type. The following example provides one implementation. It defines an `IsSerializable(Object)` extension method that indicates whether any <xref:System.Object> instance can be serialized.

[!code-csharp[is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/csharp/program.cs#2)]
[!code-vb[is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/vb/library.vb#2)]

You can then pass any object to the method to determine whether it can be serialized and deserialized on the current .NET implementation, as the following example shows:

[!code-csharp[test-is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/csharp/program.cs#1)]
[!code-vb[test-is-a-type-serializable](~/samples/snippets/standard/serialization/is-serializable/vb/program.vb#1)]

# See also

[Binary serialization](binary-serialization.md)   
<xref:System.SerializableAttribute?displayProperty=nameWithType>    
<xref:System.Type.IsSerializable?displayProperty=nameWithType>   
