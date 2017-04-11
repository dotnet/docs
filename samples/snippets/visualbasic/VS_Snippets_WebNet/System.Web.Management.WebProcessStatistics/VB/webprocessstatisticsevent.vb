 '*
'  *File name: WebprocessStatistics.cs
'  *Purpose: Implements a custom WebBaseEvent type 
'  *that uses the webProcessStattistics
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom WebBaseEvent type that 
' uses the WebProcessStatistics.

Public Class SampleWebProcessStatistics
    Inherits WebBaseEvent
    Private eventInfo As StringBuilder
    Private Shared processStatistics As WebProcessStatistics

 ' <Snippet2>
    ' Instantiate the SampleWebProcessStatistics
    ' type.
    Public Sub New(ByVal msg As String, ByVal eventSource As Object, ByVal eventCode As Integer) 
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        Dim customMsg As String = String.Format("Event created at: {0}", EventTime.ToString())
        
        eventInfo = New StringBuilder()
        eventInfo.AppendLine(customMsg)
        
        ' Instantiate the WebProcessStatistics 
        ' type.
        processStatistics = New WebProcessStatistics()
    
    End Sub 'New
     
    ' </Snippet2>

    ' <Snippet3>

    ' </Snippet3>
    ' <Snippet4>
    ' Raises the event.
    Public Overrides Sub Raise()
        ' Perform custom processing. 
        eventInfo.Append(String.Format( _
        "Event raised at: {0}" + _
        ControlChars.Lf, EventTime.ToString()))
        ' Raise the event.
        MyBase.Raise()
    End Sub 'Raise

    ' </Snippet4>
    ' <Snippet5>
    Public Function GetAppDomainCount() As String
        ' Get the app domain count.
        Return String.Format( _
        "Application domain count: {0}", _
        processStatistics.AppDomainCount.ToString())
    End Function 'GetAppDomainCount


    ' </Snippet5>
    ' <Snippet6>
    Public Function GetManagedHeapSize() As String
        ' Get the mamaged heap size.
        Return String.Format( _
        "Managed heap size: {0}", _
        processStatistics.ManagedHeapSize.ToString())
    End Function 'GetManagedHeapSize


    ' </Snippet6>
    ' <Snippet7>
    Public Function GetPeakWorkingSet() As String
        ' Get the peak working set.
        Return String.Format( _
        "Peak working set: {0}", _
        processStatistics.PeakWorkingSet.ToString())
    End Function 'GetPeakWorkingSet


    ' </Snippet7>
    ' <Snippet8>
    Public Function GetProcessStartTime() As String
        ' Get the process start time.
        Return String.Format( _
        "Process start time: {0}", _
        processStatistics.ProcessStartTime.ToString())
    End Function 'GetProcessStartTime


    ' </Snippet8>
    ' <Snippet9>
    Public Function GetRequestsExecuting() As String
        ' Get the requests in execution.
        Return String.Format( _
        "Requests executing: {0}", _
        processStatistics.RequestsExecuting.ToString())
    End Function 'GetRequestsExecuting


    ' </Snippet9>

    ' <Snippet10>
    Public Function GetRequestsQueued() As String
        ' Get the requests queued.
        Return String.Format( _
        "Requests queued: {0}", _
        processStatistics.RequestsQueued.ToString())
    End Function 'GetRequestsQueued


    ' </Snippet10>
    ' <Snippet11>
    Public Function GetRequestsRejected() As String
        ' Get the requests rejected.
        Return String.Format( _
        "Requests rejected: {0}", _
        processStatistics.RequestsRejected.ToString())
    End Function 'GetRequestsRejected


    ' </Snippet11>
    ' <Snippet12>
    Public Function GetThreadCount() As String
        ' Get the thread count.
        Return String.Format( _
        "Thread count: {0}", _
        processStatistics.ThreadCount.ToString())
    End Function 'GetThreadCount


    ' </Snippet12>
    ' <Snippet13>
    Public Function GetWorkingSet() As String
        ' Get the working set.
        Return String.Format( _
        "Working set: {0}", _
        processStatistics.WorkingSet.ToString())
    End Function 'GetWorkingSet


    ' </Snippet13>

    ' <Snippet14>
    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")
        formatter.AppendLine("Custom Process Statistics:")

        formatter.IndentationLevel += 1

        ' Get the process statistics.
        formatter.AppendLine(GetAppDomainCount())
        formatter.AppendLine(GetManagedHeapSize())
        formatter.AppendLine(GetPeakWorkingSet())
        formatter.AppendLine(GetProcessStartTime())
        formatter.AppendLine(GetRequestsExecuting())
        formatter.AppendLine(GetRequestsQueued())
        formatter.AppendLine(GetRequestsRejected())
        formatter.AppendLine(GetThreadCount())
        formatter.AppendLine(GetWorkingSet())

        formatter.IndentationLevel -= 1

        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatCustomEventDetails 
End Class 'SampleWebEventHelper
' </Snippet14>


' </Snippet1>