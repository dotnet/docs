Imports System.ComponentModel

'<SnippetDataObject>
Public Class MyData
    Implements INotifyPropertyChanged

    ' Events
    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    ' Methods
    Public Sub New()
    End Sub

    Public Sub New(ByVal dateTime As DateTime)
        Me.MyDataProperty = ("Last bound time was " & dateTime.ToLongTimeString)
    End Sub

    Private Sub OnPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub


    ' Properties
    Public Property MyDataProperty As String
        Get
            Return Me._myDataProperty
        End Get
        Set(ByVal value As String)
            Me._myDataProperty = value
            Me.OnPropertyChanged("MyDataProperty")
        End Set
    End Property


    ' Fields
    Private _myDataProperty As String
End Class
'</SnippetDataObject>

