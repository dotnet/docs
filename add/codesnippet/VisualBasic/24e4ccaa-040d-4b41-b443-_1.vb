 Private Sub PrintCount()
    Console.WriteLine("BindingContext.Count " _
       + CType(Me.BindingContext, ICollection).Count.ToString())
 End Sub 