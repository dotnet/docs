 Private Sub AddEventHandler()
     AddHandler textBox1.BindingContextChanged, _
        AddressOf BindingContext_Changed
 End Sub    
    
 Private Sub BindingContext_Changed(sender As Object, e As EventArgs)
     Console.WriteLine("BindingContext changed")
 End Sub