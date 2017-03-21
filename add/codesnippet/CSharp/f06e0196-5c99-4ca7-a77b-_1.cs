        // Invoked in case of events identified only by their event code.
        public SampleWebAuthenticationSuccessAuditEvent(
            string msg, object eventSource, 
            int eventCode, string userName):
        base(msg, eventSource, eventCode, userName)
        {
            // Perform custom initialization.
            customCreatedMsg =
                string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }