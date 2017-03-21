            wfApp.Idle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                foreach (BookmarkInfo info in e.Bookmarks)
                {
                    Console.WriteLine("BookmarkName: {0} - OwnerDisplayName: {1}",
                        info.BookmarkName, info.OwnerDisplayName);
                }

                idleEvent.Set();
            };