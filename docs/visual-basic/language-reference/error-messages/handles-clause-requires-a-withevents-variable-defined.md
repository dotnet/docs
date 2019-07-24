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
In the following example, we create a timer and use its `Tick` event to repeat some action. The error `BC30506` is produced when `WithEvents` isn't supplied to the timer variable.

```vb
Public Class Form1
    ' This line will cause an error in the Handles clause.
    Private _timer1 As New Timer() With {.Interval = 1000, .Enabled = True}
    ' Use this line instead.
    'Private WithEvents _timer1 As New Timer() With {.Interval = 1000, .Enabled = True}

    Private Sub Timer1_Tick(sender As Object, args As EventArgs) Handles _timer1.Tick
        ' Do something.
        MessageBox.Show("I'm repeated every one second")
    End Sub
End Class
```

## See also

- [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)
