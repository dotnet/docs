        // Invoked in case of events identified by their 
        // event code.and related event detailed code.
        public SampleWebApplicationLifetimeEvent(string msg, 
            object eventSource, int eventCode, 
            int eventDetailCode):
          base(msg, eventSource, eventCode, eventDetailCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
             string.Format("Event created at: {0}",
             DateTime.Now.TimeOfDay.ToString());
        }
