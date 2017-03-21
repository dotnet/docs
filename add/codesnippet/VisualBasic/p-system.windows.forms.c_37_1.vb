 Private Sub GetControl(myBindings As ControlBindingsCollection)
     Dim c As Control = myBindings.Control
     Console.WriteLine(c.ToString())
 End Sub