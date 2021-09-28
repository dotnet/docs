Option Explicit On
Option Strict On

Imports System.Data
Imports System.data.SqlTypes


Module Module1

    Sub Main()
        CompareNulls()
        Console.ReadLine()
    End Sub
    ' <Snippet1>
    Private Sub CompareNulls()
        ' Create two new null strings.
        Dim a As New SqlString
        Dim b As New SqlString

        ' Compare nulls using static/shared SqlString.Equals.
        Console.WriteLine("SqlString.Equals shared/static method:")
        Console.WriteLine("  Two nulls={0}", SqlStringEquals(a, b))

        ' Compare nulls using instance method String.Equals.
        Console.WriteLine()
        Console.WriteLine("String.Equals instance method:")
        Console.WriteLine("  Two nulls={0}", StringEquals(a, b))

        ' Make them empty strings.
        a = ""
        b = ""

        ' When comparing two empty strings (""), both the shared/static and
        ' the instance Equals methods evaluate to true.
        Console.WriteLine()
        Console.WriteLine("SqlString.Equals shared/static method:")
        Console.WriteLine("  Two empty strings={0}", SqlStringEquals(a, b))

        Console.WriteLine()
        Console.WriteLine("String.Equals instance method:")
        Console.WriteLine("  Two empty strings={0}", StringEquals(a, b))
    End Sub

    Private Function SqlStringEquals(ByVal string1 As SqlString, _
        ByVal string2 As SqlString) As String

        ' SqlString.Equals uses database semantics for evaluating nulls.
        Dim returnValue As String = SqlString.Equals(string1, string2).ToString()
        Return returnValue
    End Function

    Private Function StringEquals(ByVal string1 As SqlString, _
        ByVal string2 As SqlString) As String

        ' String.Equals uses CLR type semantics for evaluating nulls.
        Dim returnValue As String = string1.Equals(string2).ToString()
        Return returnValue
    End Function
    ' </Snippet1>
End Module
