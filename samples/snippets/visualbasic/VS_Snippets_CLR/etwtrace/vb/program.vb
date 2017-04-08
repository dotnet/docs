'<Snippet1>
Imports System
Imports System.Diagnostics.Tracing


Enum MyColor
    Red
    Yellow
    Blue
End Enum 'MyColor 
<EventSource(Name:="MyCompany")> _
Class MyCompanyEventSource
    Inherits EventSource

    '<Snippet2>
    '<Snippet3>
    Public Class Keywords
        Public Const Page As EventKeywords = CType(1, EventKeywords)
        Public Const DataBase As EventKeywords = CType(2, EventKeywords)
        Public Const Diagnostic As EventKeywords = CType(4, EventKeywords)
        Public Const Perf As EventKeywords = CType(8, EventKeywords)
    End Class 'Keywords
    '</Snippet3>

    '<Snippet4>
    Public Class Tasks
        Public Const Page As EventTask = CType(1, EventTask)
        Public Const DBQuery As EventTask = CType(1, EventTask)
    End Class 'Tasks
    '</Snippet2>
    '</Snippet4>

    '<Snippet5>
    <[Event](1, Message:="Application Failure: {0}", Level:=EventLevel.Error, Keywords:=Keywords.Diagnostic)> _
    Public Sub Failure(ByVal message As String)
        WriteEvent(1, message)
    End Sub 'Failure
    '</Snippet5>

    '<Snippet6>
    <[Event](2, Message:="Starting up.", Keywords:=Keywords.Perf, Level:=EventLevel.Informational)> _
    Public Sub Startup()
        WriteEvent(2)
    End Sub 'Startup
    '</Snippet6>

    '<Snippet7>
    <[Event](3, Message:="loading page {1} activityID={0}", Opcode:=EventOpcode.Start, Task:=Tasks.Page, Keywords:=Keywords.Page, Level:=EventLevel.Informational)> _
    Public Sub PageStart(ByVal ID As Integer, ByVal url As String)
        If IsEnabled() Then
            WriteEvent(3, ID, url)
        End If
    End Sub 'PageStart
    '</Snippet7>

    '<Snippet8>
    <[Event](4, Opcode:=EventOpcode.Stop, Task:=Tasks.Page, Keywords:=Keywords.Page, Level:=EventLevel.Informational)> _
    Public Sub PageStop(ByVal ID As Integer)
        If IsEnabled() Then
            WriteEvent(4, ID)
        End If
    End Sub 'PageStop
    '</Snippet8>

    '<Snippet9>
    <[Event](5, Opcode:=EventOpcode.Start, Task:=Tasks.DBQuery, Keywords:=Keywords.DataBase, Level:=EventLevel.Informational)> _
    Public Sub DBQueryStart(ByVal sqlQuery As String)
        WriteEvent(5, sqlQuery)
    End Sub 'DBQueryStart
    '</Snippet9>

    '<Snippet10>
    <[Event](6, Opcode:=EventOpcode.Stop, Task:=Tasks.DBQuery, Keywords:=Keywords.DataBase, Level:=EventLevel.Informational)> _
    Public Sub DBQueryStop()
        WriteEvent(6)
    End Sub 'DBQueryStop
    '</Snippet10>

    '<Snippet11>
    <[Event](7, Level:=EventLevel.Verbose, Keywords:=Keywords.DataBase)> _
    Public Sub Mark(ByVal ID As Integer)
        If IsEnabled() Then
            WriteEvent(7, ID)
        End If
    End Sub 'Mark
    '</Snippet11>

    '<Snippet12>
    <[Event](8)> _
    Public Sub LogColor(ByVal color As MyColor)
        WriteEvent(8, Fix(color))
    End Sub 'LogColor 
    '</Snippet12>
    Public Shared Log As New MyCompanyEventSource()
End Class 'MyCompanyEventSource


Class Program

    Shared Sub Main(ByVal args() As String)
        '<Snippet13>
        MyCompanyEventSource.Log.Startup()
        Console.WriteLine("Starting up")
        MyCompanyEventSource.Log.DBQueryStart("Select * from MYTable")
        Dim url As String = "http:'localhost"
        Dim i As Integer
        For i = 0 To 9
            MyCompanyEventSource.Log.PageStart(i, url)
            MyCompanyEventSource.Log.Mark(i)
            MyCompanyEventSource.Log.PageStop(i)
        Next i
        MyCompanyEventSource.Log.DBQueryStop()
        MyCompanyEventSource.Log.LogColor(MyColor.Blue)

        MyCompanyEventSource.Log.Failure("This is a failure 1")
        MyCompanyEventSource.Log.Failure("This is a failure 2")
        MyCompanyEventSource.Log.Failure("This is a failure 3")
        '</Snippet13>
    End Sub 'Main
End Class 'Program
'</Snippet1>