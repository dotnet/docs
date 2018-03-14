'<Snippet1>
Imports System
Imports System.Collections

' Simple business object.
Public Class Person

    Public Sub New(ByVal fName As String, ByVal lName As String)
        Me.firstName = fName
        Me.lastName = lName
    End Sub


    Public firstName As String
    Public lastName As String
End Class

' Collection of Person objects, which implements IEnumerable so that
' it can be used with ForEach syntax.
Public Class People
    Implements IEnumerable

    Private _people() As Person

    Public Sub New(ByVal pArray() As Person)
        _people = New Person(pArray.Length - 1) {}

        Dim i As Integer
        For i = 0 To pArray.Length - 1
            _people(i) = pArray(i)
        Next i
    End Sub

    ' Implementation of GetEnumerator.
    Public Function GetEnumerator() As IEnumerator _
      Implements IEnumerable.GetEnumerator

        Return New PeopleEnum(_people)
    End Function

End Class

' <Snippet2>
' When you implement IEnumerable, you must also implement IEnumerator.
Public Class PeopleEnum
    Implements IEnumerator

    Public _people() As Person

    ' Enumerators are positioned before the first element
    ' until the first MoveNext() call.
    Dim position As Integer = -1

    Public Sub New(ByVal list() As Person)
        _people = list
    End Sub

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        position = position + 1
        Return (position < _people.Length)
    End Function

    Public Sub Reset() Implements IEnumerator.Reset
        position = -1
    End Sub

    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
        Get
            Try
                Return _people(position)
            Catch ex As IndexOutOfRangeException
                Throw New InvalidOperationException()
            End Try
        End Get
    End Property
End Class
' </Snippet2>

Class App
    Shared Sub Main()
        Dim peopleArray() As Person = { _
            New Person("John", "Smith"), _
            New Person("Jim", "Johnson"), _
            New Person("Sue", "Rabon")}

        Dim peopleList As New People(peopleArray)
        Dim p As Person
        For Each p In peopleList
            Console.WriteLine(p.firstName + " " + p.lastName)
        Next

    End Sub
End Class

' This code produces output similar to the following:
' 
' John Smith
' Jim Johnson
' Sue Rabon

'</Snippet1>