                ' Display properties for the Simple Service sample 
                ' from the ServiceBase example
                Dim sc As New ServiceController("Simple Service")
                Console.WriteLine("Status = " + sc.Status.ToString())
                Console.WriteLine("Can Pause and Continue = " + _
                    sc.CanPauseAndContinue.ToString())
                Console.WriteLine("Can ShutDown = " + sc.CanShutdown.ToString())
                Console.WriteLine("Can Stop = " + sc.CanStop.ToString())