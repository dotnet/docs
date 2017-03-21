        // Invoked in case of events identified by their event code.and 
        // event detailed code.
        public SampleWebAuthenticationSuccessAuditEvent(
            string msg, object eventSource,
            int eventCode, int detailedCode, string userName):
        base(msg, eventSource, eventCode, detailedCode, userName)
        {
            // Perform custom initialization.
            customCreatedMsg =
            string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }
