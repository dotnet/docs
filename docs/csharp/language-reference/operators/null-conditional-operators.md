---
title: "Null-conditional Operators (C# and Visual Basic)"
ms.date: 04/03/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "null-conditional operators [C#]"
  - "null-conditional operators [Visual Basic]"
  - "?. operator [C#]"
  - "?. operator [Visual Basic]"
  - "?[] operator [C#]"
  - "?[] operator [Visual Basic]"
ms.assetid: 9c7b2c8f-a785-44ca-836c-407bfb6d27f5
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# ?. and ?[] null-conditional Operators (C# and Visual Basic)
Used to test for null before performing a member access (`?.`) or index (`?[]`) operation.  These operators help you write less code to handle null checks, especially for descending into data structures.  
  
```csharp  
int? length = customers?.Length; // null if customers is null   
Customer first = customers?[0];  // null if customers is null  
int? count = customers?[0]?.Orders?.Count();  // null if customers, the first customer, or Orders is null  
```  
  
```vb  
Dim length = customers?.Length  ' null if customers is null  
Dim first as Customer = customers?(0)  ' null if customers is null  
Dim count as Integer? = customers?(0)?.Orders?.Count()  ' null if customers, the first customer, or Orders is null  
```  
  
 The null-condition operators are short-circuiting.  If one operation in a chain of conditional member access and index operation returns null, then the rest of the chain’s execution stops.  In the following example, `E` doesn't execute if `A`, `B`, or `C` evaluates to null.
  
```csharp
A?.B?.C?.Do(E);
A?.B?.C?[E];
```

```vb
A?.B?.C?.Do(E);
A?.B?.C?(E);
```  
  
 Another use for the null-condition member access is invoking delegates in a thread-safe way with much less code.  The old way requires code like the following:  
  
```csharp  
var handler = this.PropertyChanged;  
if (handler != null)  
    handler(…);
```  
  
```vb  
Dim handler = AddressOf(Me.PropertyChanged)  
If handler IsNot Nothing  
    Call handler(…)  
```  
  
 The new way is much simpler:  
  
```csharp
PropertyChanged?.Invoke(e)  
```  

```vb
PropertyChanged?.Invoke(e)
```  
  
 The new way is thread-safe because the compiler generates code to evaluate `PropertyChanged` one time only, keeping the result in a temporary variable.  
  
 You need to explicitly call the `Invoke` method because there is no null-conditional delegate invocation syntax `PropertyChanged?(e)`.  
  
## Language Specifications  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
 For more information, see the [Visual Basic Language Reference](../../../visual-basic/language-reference/index.md).  
  
## See Also  
 [?? (null-coalescing operator)](null-conditional-operator.md)  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Visual Basic Language Reference](../../../visual-basic/language-reference/index.md)  
 [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)
