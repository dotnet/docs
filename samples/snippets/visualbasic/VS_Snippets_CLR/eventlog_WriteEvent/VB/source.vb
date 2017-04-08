
'<Snippet1>
Imports System
Imports System.Diagnostics

Namespace EventLogSamples
    Class WriteEvent

        '<Snippet2>

        ' The following constants match the message definitions
        ' in the message resource file. They are used to specify
        ' the resource identifier for a localized string in the 
        ' message resource file.

        ' The message file is an .mc file built into a 
        ' Win32 resource file using the message compiler (MC) tool.
        ' mc.exe.

        '<Snippet3>
        Private Const InstallCategory As Long = 1
        Private Const QueryCategoryMsgId As Long = 2
        Private Const RefreshCategoryMsgId As Long  = 3
        
        Private Const CategoryCount As Short  = 3
        '</Snippet3>

        '<Snippet4>
        ' Define the resource identifiers for the event messages.
        ' Resource identifiers combine the message ID and the severity field.
        Private Const AuditSuccessMsgId As Long  = 1000L
        Private Const AuditFailedMsgId As Long  = 1001L + &H80000000L
        Private Const InformationMsgId As Long  = 1002L
        Private Const WarningMsgId As Long  = 1003L + &H80000000L
        Private Const UpdateCycleCompleteMsgId As Long = 1004L
        Private Const ServerConnectionDownMsgId As Long = 1005L + &H80000000L
        '</Snippet4>

        '<Snippet5>
        Private Const DisplayNameMsgId As Long  = 5001
        Private Const ServiceNameMsgId As Long  = 5002
        '</Snippet5>

        '</Snippet2>
        '<Snippet6>
        Public Shared Sub CreateEventSourceSample1(ByVal messageFile As String)

            Dim myLogName As String
            Dim sourceName As String = "SampleApplicationSource"

            ' Create the event source if it does not exist.
            If Not EventLog.SourceExists(sourceName)
            
                ' Create a new event source for the custom event log
                ' named "myNewLog."  

                myLogName = "myNewLog"
                Dim mySourceData As EventSourceCreationData = New EventSourceCreationData(sourceName, myLogName)

                ' Set the message resource file that the event source references.
                ' All event resource identifiers correspond to text in this file.
                If Not System.IO.File.Exists(messageFile)

                    Console.WriteLine("Input message resource file does not exist - {0}", _
                        messageFile)
                    messageFile = ""
                Else 
                    ' Set the specified file as the resource
                    ' file for message text, category text and 
                    ' message parameters strings.

                    mySourceData.MessageResourceFile = messageFile
                    mySourceData.CategoryResourceFile = messageFile
                    mySourceData.CategoryCount = CategoryCount
                    mySourceData.ParameterResourceFile = messageFile

                    Console.WriteLine("Event source message resource file set to {0}", _
                        messageFile)
                End If

                Console.WriteLine("Registering new source for event log.")
                EventLog.CreateEventSource(mySourceData)
            Else
                ' Get the event log corresponding to the existing source.
                myLogName = EventLog.LogNameFromSourceName(sourceName,".")
            End If

            ' Register the localized name of the event log.
            ' For example, the actual name of the event log is "myNewLog," but
            ' the event log name displayed in the Event Viewer might be
            ' "Sample Application Log" or some other application-specific
            ' text.
            Dim myEventLog As EventLog = New EventLog(myLogName, ".", sourceName)
            
            If messageFile.Length > 0
                myEventLog.RegisterDisplayName(messageFile, DisplayNameMsgId)
            End If
        End Sub
        '</Snippet6>

        Public Shared Sub WriteEventSample1()
        '<Snippet7>

            Dim sourceName As String = "SampleApplicationSource"

            ' Create the event source if it does not exist.
            If Not EventLog.SourceExists(sourceName)
   
                ' Call a local method to register the event log source
                ' for the event log "myNewLog."  Use the resource file
                ' EventLogMsgs.dll in the current directory for message text.

                Dim messageFile As String =  String.Format("{0}\\{1}", _
                    System.Environment.CurrentDirectory, _
                    "EventLogMsgs.dll")

                CreateEventSourceSample1(messageFile)
            End If 

            ' Get the event log corresponding to the existing source.
            Dim myLogName As String = EventLog.LogNameFromSourceName(sourceName,".")
        
            Dim myEventLog As EventLog = new EventLog(myLogName, ".", sourceName)

            ' Define two audit events.
            Dim myAuditSuccessEvent As EventInstance = new EventInstance(AuditSuccessMsgId, 0, EventLogEntryType.SuccessAudit)
            Dim myAuditFailEvent As EventInstance = new EventInstance(AuditFailedMsgId, 0, EventLogEntryType.FailureAudit)

            ' Insert the method name into the event log message.
            Dim insertStrings() As String = {"EventLogSamples.WriteEventSample1"}
            
            ' Write the events to the event log.

            myEventLog.WriteEvent(myAuditSuccessEvent, insertStrings)

            ' Append binary data to the audit failure event entry.
            Dim binaryData() As Byte = { 7, 8, 9, 10 }
            myEventLog.WriteEvent(myAuditFailEvent, binaryData, insertStrings)
 
        '</Snippet7>
        End Sub

        Public Shared Sub WriteEventSample2()
        '<Snippet8>
            Dim sourceName As String = "SampleApplicationSource"
            If EventLog.SourceExists(sourceName)
   
                ' Define an informational event and a warning event.

                ' The message identifiers correspond to the message text in the
                ' message resource file defined for the source.
                Dim myInfoEvent As EventInstance = new EventInstance(InformationMsgId, 0, EventLogEntryType.Information)
                Dim myWarningEvent As EventInstance = new EventInstance(WarningMsgId, 0, EventLogEntryType.Warning)

                ' Insert the method name into the event log message.
                Dim insertStrings() As String = {"EventLogSamples.WriteEventSample2"}
            
                ' Write the events to the event log.

                EventLog.WriteEvent(sourceName, myInfoEvent, insertStrings)

                ' Append binary data to the warning event entry.
                Dim binaryData() As Byte = { 7, 8, 9, 10 }
                EventLog.WriteEvent(sourceName, myWarningEvent, binaryData, insertStrings)
            Else 
                Console.WriteLine("Warning - event source {0} not registered", _
                    sourceName)
            End If
 
        '</Snippet8>
        End Sub

        Public Shared Sub EventInstanceSamples()
            '<Snippet9>
            ' Ensure that the source has already been registered using
            ' EventLogInstaller or EventLog.CreateEventSource.
            Dim sourceName as String = "SampleApplicationSource"
            If EventLog.SourceExists(sourceName)
                
                ' Define an informational event with no category.
                ' The message identifier corresponds to the message text in the
                ' message resource file defined for the source.
                Dim myEvent As EventInstance = New EventInstance(UpdateCycleCompleteMsgId, 0)
                ' Write the event to the event log using the registered source.
                EventLog.WriteEvent(sourceName, myEvent)

                ' Reuse the event data instance for another event entry.
                ' Set the entry category and message identifiers for
                ' the appropriate resource identifiers in the resource files
                ' for the registered source.  Set the event type to Warning.

                myEvent.CategoryId = RefreshCategoryMsgId
                myEvent.EntryType = EventLogEntryType.Warning
                myEvent.InstanceId = ServerConnectionDownMsgId

                ' Write the event to the event log using the registered source.
                ' Insert the machine name into the event message text.
                EventLog.WriteEvent(sourceName, myEvent, Environment.MachineName)

            Else 
                Console.WriteLine("Warning - event source {0} not registered", _
                    sourceName)
            End If

            '</Snippet9>
            '<Snippet10>
            ' Get the event log corresponding to the existing source.
            Dim myLogName As String = EventLog.LogNameFromSourceName(sourceName,".")
        
            ' Find each instance of a specific event log entry in a
            ' particular event log.

            Dim myEventLog As EventLog = new EventLog(myLogName, ".", sourceName)
            Dim count As Integer = 0

            Console.WriteLine("Searching event log entries for the event ID {0}...", _
               ServerConnectionDownMsgId.ToString())
            
            ' Search for the resource ID, display the event text,
            ' and display the number of matching entries.

            Dim entry As EventLogEntry
            For Each entry In  myEventLog.Entries
                If entry.InstanceId = ServerConnectionDownMsgId
                    count = count + 1
                    Console.WriteLine()
                    Console.WriteLine("Entry ID    = {0}", _
                        entry.InstanceId.ToString())
                    Console.WriteLine("Reported at {0}", _
                        entry.TimeWritten.ToString())
                    Console.WriteLine("Message text:")
                    Console.WriteLine(ControlChars.Tab + entry.Message)
                End If
            Next entry

            Console.WriteLine()
            Console.WriteLine("Found {0} events with ID {1} in event log {2}", _
                count.ToString(), ServerConnectionDownMsgId.ToString(), myLogName)

            '</Snippet10>

        End Sub

        Public Shared Sub CleanUp()

            Dim sourceName As String = "SampleApplicationSource"

            ' Delete the event source in order to re-register
            ' the source with the latest configuration properties.

            If EventLog.SourceExists(sourceName) Then
           
                Console.WriteLine("Deleting event source {0}.", _
                    sourceName)
                EventLog.DeleteEventSource(sourceName)
            End If

        End Sub

        Public Shared Sub Main(ByVal args() As String)
        
            Dim messageFile As String

            If args.Length > 0
                ' Use the input argument as the message resource file.
                messageFile = args(0)
            Else 
                messageFile = String.Format("{0}\\{1}", _
                        System.Environment.CurrentDirectory, _
                        "EventLogMsgs.dll")
            End If

            CleanUp()

            CreateEventSourceSample1(messageFile)
            WriteEventSample1()
            WriteEventSample2()

            EventInstanceSamples()
        
        End Sub 'Main

    End Class 'WriteEvent
End Namespace 'EventLogSamples
'</Snippet1>
