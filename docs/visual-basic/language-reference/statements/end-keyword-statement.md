---
title: "End <keyword> Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.EndDefinition"
helpviewer_keywords: 
  - "End keyword [Visual Basic]"
ms.assetid: 42d6e088-ab0f-4cda-88e8-fdce3e5fcf4f
---
# End \<keyword> Statement (Visual Basic)

When followed by an additional keyword, terminates the definition of the statement block introduced by that keyword.

## Syntax

```vb
End AddHandler
End Class
End Enum
End Event
End Function
End Get
End If
End Interface
End Module
End Namespace
End Operator
End Property
End RaiseEvent  
End RemoveHandler  
End Select
End Set
End Structure
End Sub
End SyncLock
End Try
End While
End With  
```  
  
## Parts

|Part|Description|
|---|---|
|`End`|Required. Terminates the definition of the programming element.|
|`AddHandler`|Required to terminate an `AddHandler` accessor begun by a matching `AddHandler` statement in a custom [Event Statement](event-statement.md).|
|`Class`|Required to terminate a class definition begun by a matching [Class Statement](class-statement.md).|
|`Enum`|Required to terminate an enumeration definition begun by a matching [Enum Statement](enum-statement.md).|
|`Event`|Required to terminate a `Custom` event definition begun by a matching [Event Statement](event-statement.md).|  
|`Function`|Required to terminate a `Function` procedure definition begun by a matching [Function Statement](function-statement.md). If execution encounters an `End Function` statement, control returns to the calling code.|
|`Get`|Required to terminate a `Property` procedure definition begun by a matching [Get Statement](get-statement.md). If execution encounters an `End Get` statement, control returns to the statement requesting the property's value.|
|`If`|Required to terminate an `If`...`Then`...`Else` block definition begun by a matching `If` statement. See [If...Then...Else Statement](if-then-else-statement.md).|
|`Interface`|Required to terminate an interface definition begun by a matching [Interface Statement](interface-statement.md).|
|`Module`|Required to terminate a module definition begun by a matching [Module Statement](module-statement.md).|
|`Namespace`|Required to terminate a namespace definition begun by a matching [Namespace Statement](namespace-statement.md).|
|`Operator`|Required to terminate an operator definition begun by a matching [Operator Statement](operator-statement.md).|
|`Property`|Required to terminate a property definition begun by a matching [Property Statement](property-statement.md).|
|`RaiseEvent`|Required to terminate a `RaiseEvent` accessor begun by a matching `RaiseEvent` statement in a custom [Event Statement](event-statement.md).|
|`RemoveHandler`|Required to terminate a `RemoveHandler` accessor begun by a matching `RemoveHandler` statement in a custom [Event Statement](event-statement.md).|
|`Select`|Required to terminate a `Select`...`Case` block definition begun by a matching `Select` statement. See [Select...Case Statement](select-case-statement.md).  
|`Set`|Required to terminate a `Property` procedure definition begun by a matching [Set Statement](set-statement.md). If execution encounters an `End Set` statement, control returns to the statement setting the property's value.  
|`Structure`|Required to terminate a structure definition begun by a matching [Structure Statement](structure-statement.md).  
|`Sub`|Required to terminate a `Sub` procedure definition begun by a matching [Sub Statement](sub-statement.md). If execution encounters an `End Sub` statement, control returns to the calling code.  
|`SyncLock`|Required to terminate a `SyncLock` block definition begun by a matching `SyncLock` statement. See [SyncLock Statement](synclock-statement.md).  
|`Try`|Required to terminate a `Try`...`Catch`...`Finally` block definition begun by a matching `Try` statement. See [Try...Catch...Finally Statement](try-catch-finally-statement.md).  
|`While`|Required to terminate a `While` loop definition begun by a matching `While` statement. See [While...End While Statement](while-end-while-statement.md).  
|`With`| Required to terminate a `With` block definition begun by a matching `With` statement. See [With...End With Statement](with-end-with-statement.md).  
|||
  
## Directives

When preceded by a number sign (`#`), the `End` keyword terminates a preprocessing block introduced by the corresponding directive.  

```vb
#End ExternalSource
#End If
#End Region
```

|Part|Description|
|---|---|
|`#End`|Required. Terminates the definition of the preprocessing block.|
|`ExternalSource`|Required to terminate an external source block begun by a matching [#ExternalSource Directive](../directives/externalsource-directive.md).|
|`If`|Required to terminate a conditional compilation block begun by a matching `#If` directive. See [#If...Then...#Else Directives](../directives/if-then-else-directives.md).|
|`Region`|Required to terminate a source region block begun by a matching [#Region Directive](../directives/region-directive.md).|
|||

## Remarks

The [End Statement](end-statement.md), without an additional keyword, terminates execution immediately.

## Smart Device Developer Notes  

The `End` statement, without an additional keyword, is not supported.  
  
## See also

- [End Statement](end-statement.md)
