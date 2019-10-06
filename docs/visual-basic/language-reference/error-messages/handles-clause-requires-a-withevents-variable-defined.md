---
title: "Handles clause requires a WithEvents variable defined in the containing type or one of its base types"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc30506"
  - "bc30506"
helpviewer_keywords: 
  - "BC30506"
ms.assetid: 5b66f6a8-f050-4e03-a57f-a64e85f80cb5
---
# Handles clause requires a WithEvents variable defined in the containing type or one of its base types
You did not supply a `WithEvents` variable in your `Handles` clause. The `Handles` keyword at the end of a procedure declaration causes it to handle events raised by an object variable declared using the `WithEvents` keyword.
  
 **Error ID:** BC30506

## To correct this error
  
- Supply the necessary `WithEvents` variable.
  
## Example

In the following example, Visual Basic generates compiler error `BC30506` because the [WithEvents](../modifiers/withevents.md) keyword is not used in the definition of the <xref:System.Timers.Timer?displayProperty=nameWithType> instance.

```vb
Imports System.Timers

Module Module1
    Private _timer1 As New Timer() With {.Interval = 1000, .Enabled = True}
    
    Sub Main()
        Console.WriteLine("Press any key to start the timer...")
        Console.ReadKey()
        _timer1.Start()
        Console.ReadKey()
    End Sub

    Private Sub Timer1_Tick(sender As Object, args As EventArgs) Handles _timer1.Elapsed
        Console.WriteLine("Press any key to terminate...")
    End Sub
End Module
```

The following example compiles successfully because the `_timer1` variable is defined with the `WithEvents` keyword:

```vb
Imports System.Timers

Module Module1
    Private WithEvents _timer1 As New Timer() With {.Interval = 1000}

    Sub Main()
        Console.WriteLine("Press any key to start the timer...")
        Console.ReadKey()
        _timer1.Start()
        Console.ReadKey()
    End Sub

    Private Sub Timer1_Tick(sender As Object, args As EventArgs) Handles _timer1.Elapsed
        Console.WriteLine("Press any key to terminate...")
    End Sub

End Module
```

## See also

- [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)
