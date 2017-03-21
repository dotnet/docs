        // Invoked in case of events identified 
        // by their event code.and related event 
        // detailed code.
        public SampleWebRequestErrorEvent(
            string msg, object eventSource, 
            int eventCode, int detailedCode, 
            Exception e):
          base(msg, eventSource, 
            eventCode, detailedCode, e)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: ", EventTime.ToString()));
        }
