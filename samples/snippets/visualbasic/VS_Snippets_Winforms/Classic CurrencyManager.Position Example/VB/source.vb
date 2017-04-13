imports System
imports System.Windows.Forms


Public Class Form1

 Protected textBox1 As TextBox
' <Snippet1>
Private Sub MoveNext(ByVal myCurrencyManager As CurrencyManager)
    If myCurrencyManager.Count = 0 Then
       Console.WriteLine("No records to move to.")
       Exit Sub
    End If
 
    If myCurrencyManager.Position = myCurrencyManager.Count - 1 Then 
       MessageBox.Show("You're at end of the records")
    Else
       myCurrencyManager.Position += 1
    End If
 End Sub
 
 Private Sub MoveFirst(ByVal myCurrencyManager As CurrencyManager)
    If myCurrencyManager.Count = 0 Then
       Console.WriteLine("No records to move to.")
       Exit Sub
    End If
 
    myCurrencyManager.Position = 0
 End Sub
 
 Private Sub MovePrevious(ByVal myCurrencyManager As CurrencyManager)
    If myCurrencyManager.Count = 0 Then
       Console.WriteLine("No records to move to.")
       Exit Sub
    End If
 
    If myCurrencyManager.Position = 0 Then
       MessageBox.Show("You're at the beginning of the records.")
    Else
       myCurrencyManager.Position -= 1
    End if
 End Sub
 
 Private Sub MoveLast(ByVal myCurrencyManager As CurrencyManager)
    If myCurrencyManager.Count = 0 Then
       Console.WriteLine("No records to move to.")
       Exit Sub
    End If
 
    myCurrencyManager.Position = myCurrencyManager.Count - 1
 End Sub
   
' </Snippet1>
End Class
