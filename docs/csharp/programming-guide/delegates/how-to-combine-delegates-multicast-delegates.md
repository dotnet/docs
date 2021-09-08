---
title: "How to combine delegates (Multicast Delegates) - C# Programming Guide"
description: Learn how to combine delegates to create multicast delegates. See a code example and view additional available resources.
ms.topic: how-to
ms.date: 07/20/2015
helpviewer_keywords: 
  - "delegates [C#], combining"
  - "multicast delegates [C#]"
ms.assetid: 4e689450-6d0c-46de-acfd-f961018ae5dd
---
# How to combine delegates (Multicast Delegates) (C# Programming Guide)

This example demonstrates how to create multicast delegates. A useful property of [delegate](../../language-reference/builtin-types/reference-types.md) objects is that multiple objects can be assigned to one delegate instance by using the `+` operator. The multicast delegate contains a list of the assigned delegates. When the multicast delegate is called, it invokes the delegates in the list, in order. Only delegates of the same type can be combined.  
  
 The `-` operator can be used to remove a component delegate from a multicast delegate.  
  
## Example  

 [!code-csharp[csProgGuideDelegates#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#11)]  
  
## See also

- <xref:System.MulticastDelegate>
- [C# Programming Guide](../index.md)
- [Events](../events/index.md)
