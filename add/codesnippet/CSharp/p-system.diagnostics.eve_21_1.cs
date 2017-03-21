            EventSourceCreationData mySourceData = new EventSourceCreationData("", "");
            bool registerSource = true;

            // Process input parameters.
            if (args.Length > 0)
            {
                // Require at least the source name.

                mySourceData.Source = args[0];

                if (args.Length > 1)
                {
                    mySourceData.LogName = args[1];
                }

                if (args.Length > 2)
                {
                    mySourceData.MachineName = args[2];
                }
                if ((args.Length > 3) && (args[3].Length > 0))
                {
                    mySourceData.MessageResourceFile = args[3];
                }
            }
            else 
            {
                // Display a syntax help message.
                Console.WriteLine("Input:");
                Console.WriteLine(" source [event log] [machine name] [resource file]");

                registerSource = false;
            }

            // Set defaults for parameters missing input.
            if (mySourceData.MachineName.Length == 0)
            {
                // Default to the local computer.
                mySourceData.MachineName = ".";
            }
            if (mySourceData.LogName.Length == 0)
            {
                // Default to the Application log.
                mySourceData.LogName = "Application";
            }