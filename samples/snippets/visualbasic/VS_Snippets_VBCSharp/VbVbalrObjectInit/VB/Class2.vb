'***********************************************************
Option Infer On
Imports System.Collections.Generic

Module Module1

    Sub Main()
        '<Snippet20>
        Dim student0 As New Student
        With student0
            .First = "Michael"
            .Last = "Tucker"
        End With
        '</Snippet20>

        '<Snippet21>
        Dim student1 As New Student With {.First = "Michael", 
                                          .Last = "Tucker"}
        '</Snippet21>

        '<Snippet22>
        Dim student2 As Student = New Student With {.First = "Michael", 
                                                    .Last = "Tucker"}
        '</Snippet22>

        '<Snippet23>
        Dim student3 = New Student With {.First = "Michael", 
                                         .Last = "Tucker"}
        '</Snippet23>

    End Sub
    ' Function GetStudents returns a list of Student objects.
    Function GetStudents() As IEnumerable(Of Student)
        Dim studentList As New System.Collections.Generic.List(Of Student)
        Dim student0 As New Student With {.First = "Michael", 
                                          .Last = "Tucker", 
                                          .Year = "Junior", 
                                          .Rank = 10}
        Dim student1 As New Student With {.First = "Svetlana", 
                                          .Last = "Omelchenko", 
                                          .Year = "Senior", 
                                          .Rank = 2}
        Dim student2 As New Student With {.First = "Michiko", 
                                          .Last = "Osada", 
                                          .Year = "Senior", 
                                          .Rank = 7}
        Dim student3 As New Student With {.First = "Sven", 
                                          .Last = "Mortensen", 
                                          .Year = "Freshman", 
                                          .Rank = 53}
        Dim student4 As New Student With {.First = "Hugo", 
                                          .Last = "Garcia", 
                                          .Year = "Junior", 
                                          .Rank = 16}
        Dim student5 As New Student With {.First = "Cesar", 
                                          .Last = "Garcia", 
                                          .Year = "Freshman", 
                                          .Rank = 4}
        Dim student6 As New Student With {.First = "Fadi", 
                                          .Last = "Fakhouri", 
                                          .Year = "Senior", 
                                          .Rank = 72}
        Dim student7 As New Student With {.First = "Hanying", 
                                          .Last = "Feng", 
                                          .Year = "Senior", 
                                          .Rank = 11}
        Dim student8 As New Student With {.First = "Debra", 
                                          .Last = "Garcia", 
                                          .Year = "Junior", 
                                          .Rank = 41}
        Dim student9 As New Student With {.First = "Lance", 
                                          .Last = "Tucker", 
                                          .Year = "Junior", 
                                          .Rank = 60}
        Dim student10 As New Student With {.First = "Terry", 
                                           .Last = "Adams", 
                                           .Year = "Senior", 
                                           .Rank = 6}
        studentList.Add(student0)
        studentList.Add(student1)
        studentList.Add(student2)
        studentList.Add(student3)
        studentList.Add(student4)
        studentList.Add(student5)
        studentList.Add(student6)
        studentList.Add(student7)
        studentList.Add(student8)
        studentList.Add(student9)
        studentList.Add(student10)
        Return studentList
    End Function

    ' Each student has a first name, a last name, a class year, and 
    ' a rank that indicates academic ranking in the student body.
    Public Class Student
        Private _first As String
        Public Property First() As String
            Get
                Return _first
            End Get
            Set(ByVal value As String)
                _first = value
            End Set
        End Property
        Private _last As String
        Public Property Last() As String
            Get
                Return _last
            End Get
            Set(ByVal value As String)
                _last = value
            End Set
        End Property
        Private _year As String
        Public Property Year() As String
            Get
                Return _year
            End Get
            Set(ByVal value As String)
                _year = value
            End Set
        End Property
        Private _rank As Integer
        Public Property Rank() As Integer
            Get
                Return _rank
            End Get
            Set(ByVal value As Integer)
                _rank = value
            End Set
        End Property
    End Class
End Module

