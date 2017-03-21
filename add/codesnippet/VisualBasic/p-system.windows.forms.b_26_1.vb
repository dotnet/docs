    Private Sub PrintPropertyNameAndIsBinding
        Dim thisControl As Control
        Dim thisBinding As Binding
        For Each thisControl In Me.Controls
            For Each thisBinding In thisControl.DataBindings
                Console.WriteLine(ControlChars.CrLf & thisControl.ToString)
                ' Print the PropertyName value for each binding.
                Console.WriteLine(thisBinding.PropertyName)
            Next
        Next
    End Sub