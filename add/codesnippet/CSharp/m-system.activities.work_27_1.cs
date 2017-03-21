        // single interaction with the user. The user enters a string in the console and that
        // string is used to resume the ReadLine activity bookmark
        static void Interact(WorkflowApplication application, AutoResetEvent resetEvent)
        {
            Console.WriteLine("Workflow is ready for input");
            Console.WriteLine("Special commands: 'unload', 'exit'");

            bool done = false;
            while (!done)
            {
                Console.Write("> ");
                string s = Console.ReadLine();
                if (s.Equals("unload"))
                {
                    try
                    {
                        // attempt to unload will fail if the workflow is idle within a NoPersistZone
                        application.Unload(TimeSpan.FromSeconds(5));
                        done = true;
                    }
                    catch (TimeoutException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (s.Equals("exit"))
                {
                    application.ResumeBookmark("inputBookmark", s);
                    done = true;
                }
                else
                {
                    application.ResumeBookmark("inputBookmark", s);
                }
            }
            resetEvent.WaitOne();
        }