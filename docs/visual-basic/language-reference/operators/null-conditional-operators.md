---
title: "Null-conditional Operators (Visual Basic)"
ms.date: 10/19/2018
helpviewer_keywords: 
  - "null-conditional operators [Visual Basic]"
  - "?. operator [Visual Basic]"
  - "?[] operator [C#]"
  - "?[] operator [Visual Basic]"
---
# ?. and ?() null-conditional operators (Visual Basic)

Tests the value of the left-hand operand for null (`Nothing`) before performing a member access (`?.`) or index (`?()`) operation; returns `Nothing` if the left-hand operand evaluates to `Nothing`. Note that, in the expressions that would ordinarily return value types, the null-conditional operator returns a <xref:System.Nullable%601>.

These operators help you write less code to handle null checks, especially when descending into data structures. For example:

```vb
Dim length As Integer? = customers?.Length  ' Nothing if customers is Nothing  
Dim first As Customer = customers?(0)  ' Nothing if customers is Nothing  
Dim count As Integer? = customers?(0)?.Orders?.Count()  ' Nothing if customers, the first customer, or Orders is Nothing  
```

For comparison, the alternative code for the first of these expressions without a null-conditional operator is:

```vb
Dim length As Integer
If customers IsNot Nothing Then
   length = customers.Length
End If
```

The null-conditional operators are short-circuiting.  If one operation in a chain of conditional member access and index operations returns Nothing, the rest of the chain’s execution stops.  In the following example, C(E) isn't evaluated if `A`, `B`, or `C` evaluates to Nothing.

```vb
A?.B?.C?(E);
```

Another use for null-conditional member access is to invoke delegates in a thread-safe way with much less code.  The old way requires code like the following:  

```vb  
Dim handler = AddressOf(Me.PropertyChanged)  
If handler IsNot Nothing  
    Call handler(…)  
```

The new way is much simpler:  

```vb
PropertyChanged?.Invoke(…)
```

The new way is thread-safe because the compiler generates code to evaluate `PropertyChanged` one time only, keeping the result in a temporary variable. You need to explicitly call the `Invoke` method because there is no null-conditional delegate invocation syntax `PropertyChanged?(e)`.  

## See also

- [Operators (Visual Basic)](index.md)
- [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)
- [Visual Basic Language Reference](../../../visual-basic/language-reference/index.md)  
