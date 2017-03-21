        // Invoked in case of events 
        // identified only by their event code.
        public SampleWebRequestErrorEvent(string msg, 
            object eventSource, int eventCode, 
            Exception e):
          base(msg, eventSource, eventCode, e)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: ", EventTime.ToString()));
        }