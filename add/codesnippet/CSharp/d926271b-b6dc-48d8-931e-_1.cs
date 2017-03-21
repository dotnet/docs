        // Invoked in case of events identified by their event code and 
        // related event detailed code.
        public SampleWebBaseErrorEvent(string msg, object eventSource, 
            int eventCode, int detailedCode, Exception e):
          base(msg, eventSource, eventCode, detailedCode, e)
        {
            // Perform custom initialization.
            customCreatedMsg =
              string.Format("Event created at: {0}", 
              DateTime.Now.TimeOfDay.ToString());
        }
