        // Handle a session change notice
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() +
                " - Session change notice received: " +
                changeDescription.Reason.ToString() + "  Session ID: " +
                changeDescription.SessionId.ToString());
#endif
