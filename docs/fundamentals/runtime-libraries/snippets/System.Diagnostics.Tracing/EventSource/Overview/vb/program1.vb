'<Snippet1>
Imports System.Diagnostics.Tracing

Enum MyColor
    Red
    Yellow
    Blue
End Enum 'MyColor
<EventSource(Name:="MyCompany")>
Class MyCompanyEventSource1
    Inherits EventSource

    '<Snippet2>
    '<Snippet3>
    Public Class Keywords
        Public Const Page As EventKeywords = CType(1, EventKeywords)
        Public Const DataBase As EventKeywords = CType(2, EventKeywords)
        Public Const Diagnostic As EventKeywords = CType(4, EventKeywords)
        Public Const Perf As EventKeywords = CType(8, EventKeywords)
    End Class
    '</Snippet3>

    '<Snippet4>
    Public Class Tasks
        Public Const Page As EventTask = CType(1, EventTask)
        Public Const DBQuery As EventTask = CType(1, EventTask)
    End Class
    '</Snippet2>
    '</Snippet4>

    '<Snippet5>
    <[Event](1, Message:="Application Failure: {0}", Level:=EventLevel.Error, Keywords:=Keywords.Diagnostic)>
    Public Sub Failure(ByVal message As String)
        WriteEvent(1, message)
    End Sub
    '</Snippet5>

    '<Snippet6>
    <[Event](2, Message:="Starting up.", Keywords:=Keywords.Perf, Level:=EventLevel.Informational)>
    Public Sub Startup()
        WriteEvent(2)
    End Sub
    '</Snippet6>

    '<Snippet7>
    <[Event](3, Message:="loading page {1} activityID={0}", Opcode:=EventOpcode.Start, Task:=Tasks.Page, Keywords:=Keywords.Page, Level:=EventLevel.Informational)>
    Public Sub PageStart(ByVal ID As Integer, ByVal url As String)
        If IsEnabled() Then
            WriteEvent(3, ID, url)
        End If
    End Sub
    '</Snippet7>

    '<Snippet8>
    <[Event](4, Opcode:=EventOpcode.Stop, Task:=Tasks.Page, Keywords:=Keywords.Page, Level:=EventLevel.Informational)>
    Public Sub PageStop(ByVal ID As Integer)
        If IsEnabled() Then
            WriteEvent(4, ID)
        End If
    End Sub
    '</Snippet8>

    '<Snippet9>
    <[Event](5, Opcode:=EventOpcode.Start, Task:=Tasks.DBQuery, Keywords:=Keywords.DataBase, Level:=EventLevel.Informational)>
    Public Sub DBQueryStart(ByVal sqlQuery As String)
        WriteEvent(5, sqlQuery)
    End Sub
    '</Snippet9>

    '<Snippet10>
    <[Event](6, Opcode:=EventOpcode.Stop, Task:=Tasks.DBQuery, Keywords:=Keywords.DataBase, Level:=EventLevel.Informational)>
    Public Sub DBQueryStop()
        WriteEvent(6)
    End Sub
    '</Snippet10>

    '<Snippet11>
    <[Event](7, Level:=EventLevel.Verbose, Keywords:=Keywords.DataBase)>
    Public Sub Mark(ByVal ID As Integer)
        If IsEnabled() Then
            WriteEvent(7, ID)
        End If
    End Sub
    '</Snippet11>

    '<Snippet12>
    <[Event](8)>
    Public Sub LogColor(ByVal color As MyColor)
        WriteEvent(8, Fix(color))
    End Sub
    '</Snippet12>
    Public Shared Log As New MyCompanyEventSource1()
End Class

Class Program1

    Shared Sub Main(ByVal args() As String)
        '<Snippet13>
        MyCompanyEventSource1.Log.Startup()
        Console.WriteLine("Starting up")
        MyCompanyEventSource1.Log.DBQueryStart("Select * from MYTable")
        Dim url As String = "http:'localhost"
        Dim i As Integer
        For i = 0 To 9
            MyCompanyEventSource1.Log.PageStart(i, url)
            MyCompanyEventSource1.Log.Mark(i)
            MyCompanyEventSource1.Log.PageStop(i)
        Next i
        MyCompanyEventSource1.Log.DBQueryStop()
        MyCompanyEventSource1.Log.LogColor(MyColor.Blue)

        MyCompanyEventSource1.Log.Failure("This is a failure 1")
        MyCompanyEventSource1.Log.Failure("This is a failure 2")
        MyCompanyEventSource1.Log.Failure("This is a failure 3")
        '</Snippet13>
    End Sub
End Class
'</Snippet1>
