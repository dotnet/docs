 '*
'  *File name: WebBaseErrorEvent.cs
'  *Purpose: Implements a custom SampleWebBaseErrorEvent type
'  *by inheriting from the System.Web.Management.WebBaseErrorEvent class.
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom WebBaseErrorEvent.

Public Class SampleWebBaseErrorEvent
    Inherits System.Web.Management.WebBaseErrorEvent
    Private customCreatedMsg, customRaisedMsg As String
    
    
    ' <Snippet2>
    ' Invoked in case of events identified only by their event code.
    Public Sub New(ByVal msg As String, ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal e As Exception)
        MyBase.New(msg, eventSource, eventCode, e)
        ' Perform custom initialization.
        customCreatedMsg = String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
    
    ' </Snippet2>
    
    ' <Snippet3>
    ' Invoked in case of events identified by their event code and 
    ' related event detailed code.
    Public Sub New(ByVal msg As String, ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal detailedCode As Integer, _
    ByVal e As Exception)
        MyBase.New(msg, eventSource, eventCode, detailedCode, e)
        ' Perform custom initialization.
        customCreatedMsg = String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
    
    
    ' </Snippet3>
    
    ' <Snippet4>
    ' Raises the SampleWebBaseErrorEvent.
    Public Overrides Sub Raise() 
        ' Perform custom processing.
        customRaisedMsg = String.Format("Event raised at: {0}", _
        DateTime.Now.TimeOfDay.ToString())
        
        ' Raise the event.
        MyBase.Raise()
    
    End Sub 'Raise
    
    ' </Snippet4>
    
    ' <Snippet5>
    ' Obtains the current thread information.
    Public Function GetErrorException() As Exception 
        Return ErrorException
    
    End Function 'GetErrorException
    
    ' </Snippet5>
    
    ' <Snippet6>
    'Formats Web request event information.
    'This method is invoked indirectly by the provider using one of the
    'overloaded ToString methods.
    Public Overrides Sub FormatCustomEventDetails(ByVal formatter _
    As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        formatter.AppendLine("** SampleWebBaseErrrorEvent Information Start **")
        formatter.AppendLine(String.Format("Error message:      {0}", _
        ErrorException.Message))
        formatter.AppendLine(String.Format("Error source:       {0}", _
        ErrorException.Source))

        ' Display custom event timing.
        formatter.AppendLine(customCreatedMsg)
        formatter.AppendLine(customRaisedMsg)

        formatter.AppendLine("** SampleWebBaseErrrorEvent Information End **")

        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails 
    ' </Snippet6>

End Class 'SampleWebBaseErrorEvent
' </Snippet1>