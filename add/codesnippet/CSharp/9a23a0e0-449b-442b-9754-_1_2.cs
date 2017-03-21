            Variable<string> name = new Variable<string>();

            Activity wf = new Sequence
            {
                Variables = { name },
                Activities =
                 {
                     new WriteLine
                     {
                         Text = "What is your name?"
                     },
                     new ReadLine
                     {
                         BookmarkName = "UserName",
                         Result = new OutArgument<string>(name)

                     },
                     new WriteLine
                     {
                         Text = new InArgument<string>((env) => 
                             ("Hello, " + name.Get(env)))
                     }
                 }
            };

            // Create a WorkflowApplication instance.
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            // Workflow lifecycle events omitted except idle.
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            wfApp.Idle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
            };

            // Run the workflow.
            wfApp.Run();

            // Wait for the workflow to go idle before gathering
            // the user's input.
            idleEvent.WaitOne();

            // Gather the user's input and resume the bookmark.
            // Bookmark resumption only occurs when the workflow
            // is idle. If a call to ResumeBookmark is made and the workflow
            // is not idle, ResumeBookmark blocks until the workflow becomes
            // idle before resuming the bookmark.
            BookmarkResumptionResult result = wfApp.ResumeBookmark("UserName", 
                Console.ReadLine());

            // Possible BookmarkResumptionResult values:
            // Success, NotFound, or NotReady
            Console.WriteLine("BookmarkResumptionResult: {0}", result);