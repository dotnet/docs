' ***********************************************************
Option Infer On
Imports System.Collections.Generic
Imports System.Diagnostics

Module Module1

    Sub Main()
        ' Create a list of students.
        Dim students = GetStudents()
        ' Display the names in the list.
        DisplayList(students)

        '<Snippet1>
        ' ****Paste query and query execution code from the walkthrough,
        ' ****or any code of your own, here in Main.
        '</Snippet1>

        '<Snippet2>
        Dim studentQuery = From currentStudent In students
                           Where currentStudent.Rank <= 10
                           Select currentStudent
        '</Snippet2>

        '<Snippet3>
        For Each studentRecord In studentQuery
            Console.WriteLine(studentRecord.Last & ", " & studentRecord.First)
        Next
        '</Snippet3>

        'Test Order By examples
        Dim studentQ1 = From currentStudent In students
                        Where currentStudent.Rank <= 10
                        Order By currentStudent.Last Ascending
                        Select currentStudent
        Dim studentQ2 = From currentStudent In students
                        Where currentStudent.Rank <= 10
                        Order By currentStudent.Last Ascending,
                        currentStudent.First Ascending
                        Select currentStudent

        '<Snippet4>
        Dim studentQuery2 =
                From currentStudent In students
                Let name = currentStudent.Last & ", " & currentStudent.First
                Where currentStudent.Year = "Senior" And currentStudent.Rank <= 10
                Order By name Ascending
                Select currentStudent

        ' If you see too many results, comment out the previous
        ' For Each loop.
        For Each studentRecord In studentQuery2
            Console.WriteLine(studentRecord.Last & ", " & studentRecord.First)
        Next
        '</Snippet4>

        '<Snippet5>
        Dim studentQuery3 = From currentStudent In students
                            Where currentStudent.Last = "Garcia"
                            Select currentStudent.First

        ' If you see too many results, comment out the previous
        ' For Each loops.
        For Each studentRecord In studentQuery3
            Console.WriteLine(studentRecord)
        Next
        '</Snippet5>

        '<Snippet6>
        Dim studentQuery4 =
                From currentStudent In students
                Where currentStudent.Year = "Senior" And currentStudent.Rank <= 10
                Order By currentStudent.Rank Ascending
                Select currentStudent.First, currentStudent.Last, currentStudent.Rank

        ' If you see too many results, comment out the previous
        ' For Each loops.
        For Each studentRecord In studentQuery4
            Console.WriteLine(studentRecord.Last & ", " & studentRecord.First &
                              ":  " & studentRecord.Rank)
        Next
        '</Snippet6>

        '<Snippet7>
        ' Find all students who are seniors.
        Dim q1 = From currentStudent In students
                 Where currentStudent.Year = "Senior"
                 Select currentStudent

        ' Write a For Each loop to execute the query.
        For Each q In q1
            Console.WriteLine(q.First & " " & q.Last)
        Next

        ' Find all students with a first name beginning with "C".
        Dim q2 = From currentStudent In students
                 Where currentStudent.First.StartsWith("C")
                 Select currentStudent

        ' Find all top ranked seniors (rank < 40).
        Dim q3 = From currentStudent In students
                 Where currentStudent.Rank < 40 And currentStudent.Year = "Senior"
                 Select currentStudent

        ' Find all seniors with a lower rank than a student who 
        ' is not a senior.
        Dim q4 = From student1 In students, student2 In students
                 Where student1.Year = "Senior" And student2.Year <> "Senior" And
                       student1.Rank > student2.Rank
                 Select student1
                 Distinct

        ' Retrieve the full names of all students, sorted by last name.
        Dim q5 = From currentStudent In students
                 Order By currentStudent.Last
                 Select Name = currentStudent.First & " " & currentStudent.Last

        ' Determine how many students are ranked in the top 20.
        Dim q6 = Aggregate currentStudent In students
                 Where currentStudent.Rank <= 20
                 Into Count()

        ' Count the number of different last names in the group of students.
        Dim q7 = Aggregate currentStudent In students
                 Select currentStudent.Last
                 Distinct
                 Into Count()

        ' Create a list box to show the last names of students.
        Dim lb As New System.Windows.Forms.ListBox
        Dim q8 = From currentStudent In students
                 Order By currentStudent.Last
                 Select currentStudent.Last Distinct

        For Each nextName As String In q8
            lb.Items.Add(nextName)
        Next

        ' Find every process that has a lowercase "h", "l", or "d" in its name.
        Dim letters() As String = {"h", "l", "d"}
        Dim q9 = From proc In System.Diagnostics.Process.GetProcesses,
                 letter In letters
                 Where proc.ProcessName.Contains(letter)
                 Select proc

        For Each proc In q9
            Console.WriteLine(proc.ProcessName & ", " & proc.WorkingSet64)
        Next
        '</Snippet7>

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
        Public Property First As String
        Public Property Last As String
        Public Property Year As String
        Public Property Rank As Integer
    End Class
End Module
