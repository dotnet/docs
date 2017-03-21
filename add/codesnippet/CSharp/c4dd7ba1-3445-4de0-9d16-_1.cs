        // Invoked in case of events identified by their event code and 
        // event detailed code.
        public SampleWebFailureAuditEvent(string msg, object eventSource,
            int eventCode, int detailedCode):
        base(msg, eventSource, eventCode, detailedCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
            string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }
