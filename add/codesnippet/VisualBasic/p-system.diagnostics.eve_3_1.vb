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