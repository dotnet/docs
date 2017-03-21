    ' Add "Imports System.ComponentModel" line 
    ' to the beginning of the file.
    Sub Main()
        Dim employee As Object = New ExpandoObject
        AddHandler CType(
            employee, INotifyPropertyChanged).PropertyChanged,
            AddressOf HandlePropertyChanges
        employee.Name = "John Smith"
    End Sub

    Private Sub HandlePropertyChanges(
           ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Console.WriteLine("{0} has changed.", e.PropertyName)
    End Sub