        // Invoked in case of events identified only by their event code.
        public SampleWebBaseErrorEvent(string msg, 
            object eventSource, int eventCode, Exception e):
          base(msg, eventSource, eventCode, e)
        {
            // Perform custom initialization.
            customCreatedMsg =
              string.Format("Event created at: {0}", 
              DateTime.Now.TimeOfDay.ToString());
        }