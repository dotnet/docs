' <Snippet2>
Public Class Order
    
    Public itemId As Integer
    Public quantity As Integer
    Public address As String
    
    
    Public Sub ShipItems()
        
        Console.WriteLine("Order Placed:")
        Console.WriteLine(ControlChars.Tab & "Item ID  : {0}", itemId)
        Console.WriteLine(ControlChars.Tab & "Quantity : {0}", quantity)
        Console.WriteLine(ControlChars.Tab & "Ship To  : {0}", address)

        ' Add order to the database.
        ' Insert code here.
 
    End Sub
End Class
' </Snippet2>
