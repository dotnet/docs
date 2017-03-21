        // Invoked in case of events identified only by their event code.
        public SampleWebSuccessAuditEvent(string msg, 
            object eventSource, int eventCode)
            :
        base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
                string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }