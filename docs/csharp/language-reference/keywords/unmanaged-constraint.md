---
title: "unmanaged (type parameter constraint) (C# Reference)"
ms.date: 10/28/2018
f1_keywords: 
  - "unmanagedconstraint_CSharpKeyword"
  - "unmanagedconstraint"
helpviewer_keywords: 
  - "unmanaged (constraint) [C#]"
---
# unmanaged (constraint) (C# Reference)

Beginning with C# 7.3, you can use the 'unmanaged' clause to specify that the type parameter must be an unmanaged type. An unmanaged type is a type that is not a reference type and doesn't contain reference type fields at any level of nesting. The unmanaged constraint enables you to write reusable routines to work with types that can be manipulated as blocks of memory, as shown in the following example:

[!code-csharp[using an unmanaged constraint](/codesnippet/CSharp/unmanaged-constraint.cs)]



