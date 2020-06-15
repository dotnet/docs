Imports System.Resources
' <Snippet2>
Imports MyCompany.Employees
Imports System.Collections.Generic

Module Module1

    Sub Main()
        ' Get the data from some data source.
        Dim employees = InitializeData()

        ' Display application title.
        Dim title As String = UILibrary.GetTitle()
        Dim start As Integer = (Console.WindowWidth + title.Length) \ 2
        Dim titlefmt As String = String.Format("{{0,{0}{1}", start, "}")
        Console.WriteLine(titlefmt, title)
        Console.WriteLine()

        ' Retrieve resources.
        Dim fields() As String = UILibrary.GetFieldNames()
        Dim lengths() As Integer = UILibrary.GetFieldLengths()
        Dim fmtString As String = String.Empty
        ' Create format string for field headers and data.
        For ctr = 0 To fields.Length - 1
            fmtString += String.Format("{{{0},-{1}{2}{3}   ", ctr, lengths(ctr), IIf(ctr >= 2, ":d", ""), "}")
        Next
        ' Display the headers.
        Console.WriteLine(fmtString, fields)
        Console.WriteLine()
        ' Display the data.
        For Each e In employees
            Console.WriteLine(fmtString, e.Item1, e.Item2, e.Item3, e.Item4)
        Next
        Console.ReadLine()
    End Sub

    Private Function InitializeData() As List(Of Tuple(Of String, String, Date, Date))
        Dim employees As New List(Of Tuple(Of String, String, Date, Date))
        Dim t1 = Tuple.Create("John", "16302", #8/18/1954#, #9/8/2006#)
        employees.Add(t1)
        t1 = Tuple.Create("Alice", "19745", #5/10/1995#, #10/17/2012#)
        employees.Add(t1)
        Return employees
    End Function
End Module
' </Snippet2>


Namespace MyCompany.Employees
    Public Class UILibrary
        Private Shared rm As ResourceManager
        Private Const nFields As Integer = 4

        Shared Sub New()
            rm = New ResourceManager("MyCompany.Employees.LibResources", GetType(UILibrary).Assembly)
            ' rm = New ResourceManager(GetType(LibResources))
        End Sub

        Public Shared Function GetTitle() As String
            Dim retval As String = rm.GetString("Title")
            If String.IsNullOrEmpty(retval) Then retval = "<No value>"

            Return retval
        End Function

        Public Shared Function GetFieldNames() As String()
            Dim fieldnames(nFields - 1) As String
            fieldnames(0) = rm.GetString("Name")
            fieldnames(1) = rm.GetString("ID")
            fieldnames(2) = rm.GetString("Born")
            fieldnames(3) = rm.GetString("Hired")
            Return fieldnames
        End Function

        Public Shared Function GetFieldLengths() As Integer()
            Dim fieldLengths(nFields - 1) As Integer
            fieldLengths(0) = Int32.Parse(rm.GetString("NameLength"))
            fieldLengths(1) = Int32.Parse(rm.GetString("IDLength"))
            fieldLengths(2) = Int32.Parse(rm.GetString("BornLength"))
            fieldLengths(3) = Int32.Parse(rm.GetString("HiredLength"))
            Return fieldLengths
        End Function
    End Class
End Namespace
