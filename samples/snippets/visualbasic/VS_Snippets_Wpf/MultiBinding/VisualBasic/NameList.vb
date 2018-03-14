Imports System
Imports System.Collections.ObjectModel

'<Snippet1>
Public Class NameList
    Inherits ObservableCollection(Of PersonName)

    ' Methods
    Public Sub New()
        MyBase.Add(New PersonName("Willa", "Cather"))
        MyBase.Add(New PersonName("Isak", "Dinesen"))
        MyBase.Add(New PersonName("Victor", "Hugo"))
        MyBase.Add(New PersonName("Jules", "Verne"))
    End Sub

End Class

Public Class PersonName
    ' Methods
    Public Sub New(ByVal first As String, ByVal last As String)
        Me._firstName = first
        Me._lastName = last
    End Sub


    ' Properties
    Public Property FirstName() As String
        Get
            Return Me._firstName
        End Get
        Set(ByVal value As String)
            Me._firstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return Me._lastName
        End Get
        Set(ByVal value As String)
            Me._lastName = value
        End Set
    End Property


    ' Fields
    Private _firstName As String
    Private _lastName As String
End Class
'</Snippet1>

