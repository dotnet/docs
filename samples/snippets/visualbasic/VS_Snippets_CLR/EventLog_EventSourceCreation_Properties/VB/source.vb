
'<Snippet1>
Imports System
Imports System.Globalization
Imports System.Diagnostics

Namespace EventLogSamples
    Class CreateSourceSample

        Public Shared Sub Main(ByVal args() As String)
        
            '<Snippet2>
            Dim mySourceData As EventSourceCreationData = new EventSourceCreationData("", "")
            Dim registerSource As Boolean = True

            ' Process input parameters.
            If args.Length > 0
                ' Require at least the source name.

                mySourceData.Source = args(0)

                If args.Length > 1
   
                    mySourceData.LogName = args(1)
    
                End If
                If args.Length > 2
   
                    mySourceData.MachineName = args(2)
    
                End If
                If args.Length > 3 AndAlso args(3).Length > 0
   
                    mySourceData.MessageResourceFile = args(3)
    
                End If

            Else 
                ' Display a syntax help message.
                Console.WriteLine("Input:")
                Console.WriteLine(" source [event log] [machine name] [resource file]")

                registerSource = False
            End If

            ' Set defaults for parameters missing input.
            If mySourceData.MachineName.Length = 0
            
                ' Default to the local computer.
                mySourceData.MachineName = "."
            End If
            If mySourceData.LogName.Length = 0
                ' Default to the Application log.
                mySourceData.LogName = "Application"
            End If
            '</Snippet2>

            ' Determine if the source exists on the specified computer.
            If Not EventLog.SourceExists(mySourceData.Source, _
                                       mySourceData.MachineName)
                ' The source does not exist.  

                ' Verify that the message file exists
                ' and the event log is local.
                If mySourceData.MessageResourceFile <> Nothing AndAlso _
                   mySourceData.MessageResourceFile.Length > 0
                   
                    If mySourceData.MachineName = "."
                        If Not System.IO.File.Exists(mySourceData.MessageResourceFile)

                            Console.WriteLine("File {0} not found - message file not set for source.", _
                                mySourceData.MessageResourceFile)
                            registerSource = False
                        End If
                    Else
                        ' For simplicity, do not allow setting the message
                        ' file for a remote event log.  To set the message
                        ' for a remote event log, and for source registration,
                        ' the file path should be specified with system-wide
                        ' environment variables that are valid on the remote
                        ' computer, such as
                        ' "%SystemRoot%\system32\myresource.dll".

                        Console.WriteLine("Message resource file ignored for remote event log.")
                        registerSource = False

                    End If
                End If
            Else 
                ' Do not register the source, it already exists.
                registerSource = False

                ' Get the event log corresponding to the existing source.
                Dim sourceLog As string
                sourceLog = EventLog.LogNameFromSourceName(mySourceData.Source, _
                                mySourceData.MachineName)

                ' Determine if the event source is registered for the 
                ' specified log.

                If sourceLog.ToUpper(CultureInfo.InvariantCulture) <> mySourceData.LogName.ToUpper(CultureInfo.InvariantCulture)

                    ' An existing source is registered 
                    ' to write to a different event log.

                    Console.WriteLine("Warning: source {0} is already registered to write to event log {1}", _
                        mySourceData.Source, sourceLog)
                Else 
                    ' The source is already registered 
                    ' to write to the specified event log.

                    Console.WriteLine("Source {0} already registered to write to event log {1}", _
                        mySourceData.Source, sourceLog)

                End If
            End If

            If registerSource
                ' Register the new event source for the specified event log.

                Console.WriteLine("Registering new source {0} for event log {1}.", _
                    mySourceData.Source, mySourceData.LogName)
                EventLog.CreateEventSource(mySourceData)
                Console.WriteLine("Event source was registered successfully!")
            End If

        End Sub 'Main
    End Class 'CreateSourceSample
End Namespace 'EventLogSamples
'</Snippet1>
