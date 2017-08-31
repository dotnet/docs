---
title: "fixed Statement (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "fixed_CSharpKeyword"
  - "fixed"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "fixed keyword [C#]"
ms.assetid: 7ea6db08-ad49-4a7a-b934-d8c4acad1c3a
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# fixed Statement (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `fixed` statement prevents the garbage collector from relocating a movable variable. The `fixed` statement is only permitted in an [unsafe](../../../csharp/language-reference/keywords/unsafe.md) context. `Fixed` can also be used to create [fixed size buffers](../../../csharp/programming-guide/unsafe-code-pointers/fixed-size-buffers.md).  
  
 The `fixed` statement sets a pointer to a managed variable and "pins" that variable during the execution of the statement. Without `fixed`, pointers to movable managed variables would be of little use since garbage collection could relocate the variables unpredictably. The C# compiler only lets you assign a pointer to a managed variable in a `fixed` statement.  
  
 [!code-csharp[csrefKeywordsFixedLock#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsFixedLock/CS/csrefKeywordsFixedLock.cs#1)]  
  
 You can initialize a pointer by using an array, a string, a fixed-size buffer, or the address of a variable. The following example illustrates the use of variable addresses, arrays, and strings. For more information about fixed-size buffers, see [Fixed Size Buffers](../../../csharp/programming-guide/unsafe-code-pointers/fixed-size-buffers.md).  
  
 [!code-csharp[csrefKeywordsFixedLock#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsFixedLock/CS/csrefKeywordsFixedLock.cs#2)]  
  
 You can initialize multiple pointers, as long as they are all of the same type.  
  
```  
fixed (byte* ps = srcarray, pd = dstarray) {...}  
```  
  
 To initialize pointers of different types, simply nest `fixed` statements, as shown in the following example.  
  
 [!code-csharp[csrefKeywordsFixedLock#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsFixedLock/CS/csrefKeywordsFixedLock.cs#3)]  
  
 After the code in the statement is executed, any pinned variables are unpinned and subject to garbage collection. Therefore, do not point to those variables outside the `fixed` statement.  
  
> [!NOTE]
>  Pointers initialized in fixed statements cannot be modified.  
  
 In unsafe mode, you can allocate memory on the stack, where it is not subject to garbage collection and therefore does not need to be pinned. For more information, see [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md).  
  
## Example  
 [!code-csharp[csrefKeywordsFixedLock#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsFixedLock/CS/csrefKeywordsFixedLock.cs#4)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)   
 [Fixed Size Buffers](../../../csharp/programming-guide/unsafe-code-pointers/fixed-size-buffers.md)