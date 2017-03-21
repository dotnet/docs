            wfApp.PersistableIdle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                // Instruct the runtime to persist and unload the workflow
                return PersistableIdleAction.Unload;
            };