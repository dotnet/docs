' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Class MyArrayRankSample
    Public Shared Sub Main()
        Try
            Dim myArray(,,) As Integer = {{{12, 2, 35}, {300, 78, 33}}, {{92, 42, 135}, {30, 7, 3}}}
            Dim myType As Type = myArray.GetType()
            Console.WriteLine("Contents of myArray: {{{12,2,35},{300,78,33}},{{92,42,135},{30,7,3}}}")
            Console.WriteLine("myArray has {0} dimensions.", myType.GetArrayRank())
        Catch e As NotSupportedException
            Console.WriteLine("NotSupportedException raised.")
            Console.WriteLine(("Source: " + e.Source))
            Console.WriteLine(("Message: " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception raised.")
            Console.WriteLine(("Source: " + e.Source))
            Console.WriteLine(("Message: " + e.Message))
        End Try
    End Sub 'Main 
End Class 'MyArrayRankSample
' </Snippet1>