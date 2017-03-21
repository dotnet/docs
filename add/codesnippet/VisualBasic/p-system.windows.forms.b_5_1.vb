    Private Sub PrintBoundControls()
        Dim myBindingBase As BindingManagerBase = Me.BindingContext(ds, "customers")
        Dim b As Binding
        For Each b In  myBindingBase.Bindings
            Console.WriteLine(b.Control.ToString())
        Next b
    End Sub 'PrintBoundControls