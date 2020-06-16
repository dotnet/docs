' <snippet3>
Imports System.ComponentModel

Namespace SimpleMVVM.ViewModel

    Public MustInherit Class ViewModelBase
        Implements INotifyPropertyChanged

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Protected Overridable Sub OnPropertyChanged(propname As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propname))
        End Sub
    End Class
End Namespace
' </snippet3>
