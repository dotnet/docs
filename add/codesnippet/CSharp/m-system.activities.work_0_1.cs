            WorkflowApplication application = new WorkflowApplication(activity);

            application.InstanceStore = instanceStore;

            //returning IdleAction.Unload instructs the WorkflowApplication to persists application state and remove it from memory  
            application.PersistableIdle = (e) =>
            {
                return PersistableIdleAction.Unload;
            };

            application.Unloaded = (e) =>
            {
                instanceUnloaded.Set();
            };


            //This call is not required 
            //Calling persist here captures the application durably before it has been started
            application.Persist();
            id = application.Id;
            application.Run();

            instanceUnloaded.WaitOne();