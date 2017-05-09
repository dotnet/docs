 '*
'  *File name: WebBaseEventCollection.cs
'  *Purpose:   This little contrived example shows how to use the 
'  *           WebBaseEventCollection. 
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management
Imports System.Collections


' Implements a custom WebBaseEvent class. 
' Everytime this class is instantiated a WebBaseEvent is 
' created. This event object is then added to the static 
' simulatedEvents array list.

Public Class SampleWebBaseEventCollection
    Inherits System.Web.Management.WebBaseEvent
    Private customCreatedMsg As String
    
    Private Shared simulatedEvents As New ArrayList()
    Private Shared events _
    As System.Web.Management.WebBaseEventCollection
    
    
    ' Create a new WebBaseEvent and add it to the 
    ' static array list simulatedEvents.
    Public Sub New(ByVal msg As String, ByVal eventSource As Object, _
    ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)

        customCreatedMsg = String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

        simulatedEvents.Add(Me)

    End Sub 'New
     
    
    ' <Snippet3>
    ' Get the event with the specified index.
    Public Shared Function GetItem(ByVal index _
    As Integer) As WebBaseEvent
        Return events(index)

    End Function 'GetItem
    
    ' </Snippet3>
    ' <Snippet4>
    ' Get the index of the specified event.
    Public Shared Function GetIndexOf(ByVal ev _
    As WebBaseEvent) As Integer
        Return events.IndexOf(ev)

    End Function 'GetIndexOf
    
    ' </Snippet4>
    ' <Snippet5>
    ' Chek if the specified event is in the collection.
    Public Shared Function ContainsEvent(ByVal ev _
    As WebBaseEvent) As Boolean
        Return events.Contains(ev)

    End Function 'ContainsEvent
    
    ' </Snippet5>
    ' <Snippet2>
    ' Create an event collection.
    ' Add to it the created simulatedEvents.
    Public Shared Sub AddEvents() 
        events = _
        New System.Web.Management.WebBaseEventCollection(simulatedEvents)
    
    End Sub 'AddEvents
    
    
    ' </Snippet2>
    ' Display the events contained in the collection.
    Public Overrides Sub FormatCustomEventDetails(ByVal formatter _
    As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)
        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        formatter.AppendLine("**SampleWebBaseEventCollection Data Start **")
        Dim ev As WebBaseEvent
        For Each ev In events
            formatter.AppendLine(String.Format("Message:   {0}", _
            ev.Message))
            formatter.AppendLine(String.Format("Source:    {0}", _
            ev.EventSource.ToString()))
            formatter.AppendLine(String.Format("Code:      {0}", _
            ev.EventCode.ToString()))
        Next ev

        formatter.AppendLine("**SampleWebBaseEventCollection Data End **")

        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails 
End Class 'SampleWebBaseEventCollection

' </Snippet1>