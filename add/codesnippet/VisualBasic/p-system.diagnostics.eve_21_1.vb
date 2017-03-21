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