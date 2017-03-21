            
            //sharing a channel cache between two workflow applications in a single app-domain.
            sharedChannelCache = new SendMessageChannelCache(new ChannelCacheSettings { MaxItemsInCache = 5 }, new ChannelCacheSettings { MaxItemsInCache = 5 });

            WorkflowApplication workflowApp1 = new WorkflowApplication(workflow);
            workflowApp1.Completed = new Action<WorkflowApplicationCompletedEventArgs>(OnCompleted);
            workflowApp1.Extensions.Add(sharedChannelCache);

            WorkflowApplication workflowApp2 = new WorkflowApplication(workflow);
            workflowApp2.Completed = new Action<WorkflowApplicationCompletedEventArgs>(OnCompleted);
            workflowApp2.Extensions.Add(sharedChannelCache);

            //disabling the channel cache so that channels are closed after being used.
            SendMessageChannelCache disabledChannelCache = new SendMessageChannelCache(new ChannelCacheSettings { MaxItemsInCache = 0 }, new ChannelCacheSettings { MaxItemsInCache = 0 });
            
            WorkflowApplication workflowApp3 = new WorkflowApplication(workflow);
            workflowApp3.Completed = new Action<WorkflowApplicationCompletedEventArgs>(OnCompleted);
            workflowApp3.Extensions.Add(disabledChannelCache);
