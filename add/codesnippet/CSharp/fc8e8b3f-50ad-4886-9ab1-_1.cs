        // Invoked in case of events identified by their 
        // event code.and related event detailed code.
        public SampleWebBaseEvent(string msg, object eventSource, 
            int eventCode, int eventDetailCode):
          base(msg, eventSource, eventCode, eventDetailCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
             string.Format("Event created at: {0}",
             EventTime.ToString());
        }
