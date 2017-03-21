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
                // You can also inspect the bookmarks from the Idle handler
                // using e.Bookmarks

                idleEvent.Set();
            };

            // Run the workflow.
            wfApp.Run();

            // Wait for the workflow to go idle and give it a chance
            // to create the Bookmark.
            idleEvent.WaitOne();

            // Inspect the bookmarks
            foreach (BookmarkInfo info in wfApp.GetBookmarks())
            {
                Console.WriteLine("BookmarkName: {0} - OwnerDisplayName: {1}",
                    info.BookmarkName, info.OwnerDisplayName);
            }

            // Gather the user's input and resume the bookmark.
            wfApp.ResumeBookmark("UserName", Console.ReadLine());