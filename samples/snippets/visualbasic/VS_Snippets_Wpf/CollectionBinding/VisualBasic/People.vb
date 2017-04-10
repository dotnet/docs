Imports System
Imports System.Collections.ObjectModel

    Public Class People
        Inherits ObservableCollection(Of Person)

        ' Methods
        Public Sub New()
            MyBase.Add(New Person("Michael", "Alexander", "Bellevue"))
            MyBase.Add(New Person("Jeff", "Hay", "Redmond"))
            MyBase.Add(New Person("Christina", "Lee", "Kirkland"))
            MyBase.Add(New Person("Samantha", "Smith", "Seattle"))
        End Sub

    End Class


