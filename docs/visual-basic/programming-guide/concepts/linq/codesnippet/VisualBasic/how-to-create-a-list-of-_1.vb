Module Module1

    Sub Main()
        ' Create a list of students.
        Dim students = GetStudents()
        ' Display the names in the list.
        DisplayList(students)
        ' ****Paste query and query execution code from the walkthrough,
        ' ****or any code of your own, here in Main.
        Console.ReadLine()
    End Sub

    ' Call DisplayList to see the names of the students in the list.
    ' You can expand this method to see other student properties.
    Sub DisplayList(ByVal studentCol As IEnumerable(Of Student))
        For Each st As Student In studentCol
            Console.WriteLine("First Name: " & st.First)
            Console.WriteLine(" Last Name: " & st.Last)
            Console.WriteLine()
        Next
    End Sub

    ' Function GetStudents returns a list of Student objects.
    Function GetStudents() As IEnumerable(Of Student)
        Return New List(Of Student) From
            {
             New Student("Michael", "Tucker", "Junior", 10),
             New Student("Svetlana", "Omelchenko", "Senior", 2),
             New Student("Michiko", "Osada", "Senior", 7),
             New Student("Sven", "Mortensen", "Freshman", 53),
             New Student("Hugo", "Garcia", "Junior", 16),
             New Student("Cesar", "Garcia", "Freshman", 4),
             New Student("Fadi", "Fakhouri", "Senior", 72),
             New Student("Hanying", "Feng", "Senior", 11),
             New Student("Debra", "Garcia", "Junior", 41),
             New Student("Lance", "Tucker", "Junior", 60),
             New Student("Terry", "Adams", "Senior", 6)
            }
    End Function

    ' Each student has a first name, a last name, a class year, and 
    ' a rank that indicates academic ranking in the student body.
    Public Class Student
        Public Property First As String
        Public Property Last As String
        Public Property Year As String
        Public Property Rank As Integer

        Public Sub New()

        End Sub

        Public Sub New(ByVal firstName As String,
                       ByVal lastName As String,
                       ByVal studentYear As String,
                       ByVal studentRank As Integer)
            First = firstName
            Last = lastName
            Year = studentYear
            Rank = studentRank
        End Sub
    End Class
End Module