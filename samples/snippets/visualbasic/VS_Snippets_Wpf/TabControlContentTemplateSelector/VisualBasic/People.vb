Imports System
Imports System.Collections.ObjectModel

Public Class People
    Inherits ObservableCollection(Of Person)

    ' Methods
    Public Sub New()
        MyBase.Add(New Person("Michael", "Alexander", "Boston"))
        MyBase.Add(New Person("Timothy", "Sneath", "Seattle"))
        MyBase.Add(New Person("Christina", "Lee", "New York"))
        MyBase.Add(New Person("Samantha", "Smith", "Seattle"))
        MyBase.Add(New Person("Jeff", "Hay", "Los Angeles"))
    End Sub

End Class


