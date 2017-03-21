        // Invoked in case of events identified only 
        // by their event code.
        public SampleWebRequestEvent(
            string msg, 
            object eventSource, int eventCode): 
            base(msg, eventSource, eventCode)
        {
           
            // Perform custom initialization.
            customCreatedMsg =
              string.Format(
              "Event created at: {0}", 
              EventTime.ToString());
        }