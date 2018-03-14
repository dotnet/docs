' <snippet100>
Imports System.ComponentModel

Public Class BusinessObjectBase
    Implements INotifyPropertyChanged

#Region "INotifyPropertyChanged Members"

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        OnPropertyChanged(New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub

#End Region

End Class
' </snippet100>
