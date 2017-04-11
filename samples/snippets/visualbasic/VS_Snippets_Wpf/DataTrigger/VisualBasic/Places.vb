Imports System
Imports System.Collections.ObjectModel

'<Snippet2>
Public Class Place
    ' Methods
    Public Sub New(ByVal name As String, ByVal state As String)
        Me._name = name
        Me._state = state
    End Sub


    ' Properties
    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return Me._state
        End Get
        Set(ByVal value As String)
            Me._state = value
        End Set
    End Property

    ' Fields
    Private _name As String
    Private _state As String
End Class

Public Class Places
    Inherits ObservableCollection(Of Place)

    ' Methods
    Public Sub New()
        MyBase.Add(New Place("Bellevue", "WA"))
        MyBase.Add(New Place("Gold Beach", "OR"))
        MyBase.Add(New Place("Kirkland", "WA"))
        MyBase.Add(New Place("Los Angeles", "CA"))
        MyBase.Add(New Place("Portland", "ME"))
        MyBase.Add(New Place("Portland", "OR"))
        MyBase.Add(New Place("Redmond", "WA"))
        MyBase.Add(New Place("San Diego", "CA"))
        MyBase.Add(New Place("San Francisco", "CA"))
        MyBase.Add(New Place("San Jose", "CA"))
        MyBase.Add(New Place("Seattle", "WA"))
    End Sub

End Class
'</Snippet2>

