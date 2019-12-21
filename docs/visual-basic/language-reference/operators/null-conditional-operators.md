---
title: "Null-conditional Operators"
ms.date: 10/19/2018
helpviewer_keywords:
  - "null-conditional operators [Visual Basic]"
  - "?. operator [Visual Basic]"
  - "?[] operator [C#]"
  - "?[] operator [Visual Basic]"
---
# ?. and ?() null-conditional operators (Visual Basic)

Tests the value of the left-hand operand for null (`Nothing`) before performing a member access (`?.`) or index (`?()`) operation; returns `Nothing` if the left-hand operand evaluates to `Nothing`. Note that in expressions that ordinarily return value types, the null-conditional operator returns a <xref:System.Nullable%601>.

These operators help you write less code to handle null checks, especially when descending into data structures. For example:

```vb
' Nothing if customers is Nothing
Dim length As Integer? = customers?.Length

' Nothing if customers is Nothing
Dim first As Customer = customers?(0)

' Nothing if customers, the first customer, or Orders is Nothing
Dim count As Integer? = customers?(0)?.Orders?.Count()
```

For comparison, the alternative code for the first of these expressions without a null-conditional operator is:

```vb
Dim length As Integer
If customers IsNot Nothing Then
   length = customers.Length
End If
```

Sometimes you need to take an action on an object that may be null, based on the value of a Boolean member on that object (like the Boolean property `IsAllowedFreeShipping` in the following example):

```vb
Dim customer = FindCustomerByID(123) 'customer will be Nothing if not found.

If customer IsNot Nothing AndAlso customer.IsAllowedFreeShipping Then
  ApplyFreeShippingToOrders(customer)
End If
```

You can shorten your code and avoid manually checking for null by using the null-conditional operator as follows:

```vb
Dim customer = FindCustomerByID(123) 'customer will be Nothing if not found.

If customer?.IsAllowedFreeShipping Then ApplyFreeShippingToOrders(customer)
```

The null-conditional operators are short-circuiting.  If one operation in a chain of conditional member access and index operations returns `Nothing`, the rest of the chain’s execution stops.  In the following example, `C(E)` isn't evaluated if `A`, `B`, or `C` evaluates to `Nothing`.

```vb
A?.B?.C?(E)
```

Another use for null-conditional member access is to invoke delegates in a thread-safe way with much less code.  The following example defines two types, a `NewsBroadcaster` and a `NewsReceiver`. News items are sent to the receiver by the `NewsBroadcaster.SendNews` delegate.

```vb
Public Module NewsBroadcaster
   Dim SendNews As Action(Of String)

   Public Sub Main()
      Dim rec As New NewsReceiver()
      Dim rec2 As New NewsReceiver()
      SendNews?.Invoke("Just in: A newsworthy item...")
   End Sub

   Public Sub Register(client As Action(Of String))
      SendNews = SendNews.Combine({SendNews, client})
   End Sub
End Module

Public Class NewsReceiver
   Public Sub New()
      NewsBroadcaster.Register(AddressOf Me.DisplayNews)
   End Sub

   Public Sub DisplayNews(newsItem As String)
      Console.WriteLine(newsItem)
   End Sub
End Class
```

If there are no elements in the `SendNews` invocation list, the `SendNews` delegate throws a <xref:System.NullReferenceException>. Before
null conditional operators, code like the following ensured that the delegate invocation list was not `Nothing`:

```vb
SendNews = SendNews.Combine({SendNews, client})
If SendNews IsNot Nothing Then
   SendNews("Just in...")
End If
```

The new way is much simpler:

```vb
SendNews = SendNews.Combine({SendNews, client})
SendNews?.Invoke("Just in...")
```

The new way is thread-safe because the compiler generates code to evaluate `SendNews` one time only, keeping the result in a temporary variable. You need to explicitly call the `Invoke` method because there is no null-conditional delegate invocation syntax `SendNews?(String)`.

## See also

- [Operators (Visual Basic)](index.md)
- [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)
- [Visual Basic Language Reference](../../../visual-basic/language-reference/index.md)
