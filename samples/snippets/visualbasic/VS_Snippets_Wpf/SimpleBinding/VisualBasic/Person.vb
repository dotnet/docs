'<SnippetPersonClass>
Imports System.ComponentModel

' This class implements INotifyPropertyChanged
' to support one-way and two-way bindings
' (such that the UI element updates when the source
' has been changed dynamically)
Public Class Person
    Implements INotifyPropertyChanged

    Private personName As String

    Sub New()
    End Sub

    Sub New(ByVal Name As String)
        Me.personName = Name
    End Sub

    ' Declare the event
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property Name() As String
        Get
            Return personName
        End Get
        Set(ByVal value As String)
            personName = value
            ' Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged("Name")
        End Set
    End Property

    ' Create the OnPropertyChanged method to raise the event
    Protected Sub OnPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

End Class
'</SnippetPersonClass>