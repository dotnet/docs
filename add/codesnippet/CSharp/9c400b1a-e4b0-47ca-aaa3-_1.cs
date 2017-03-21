        //
        // Event handler for HttpApplication.ReleaseRequestState
        //

        private void OnReleaseRequestState(object source, EventArgs args)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;
            string sessionID;

            // Read the session state from the context
            HttpSessionStateContainer stateProvider =
              (HttpSessionStateContainer)(SessionStateUtility.GetHttpSessionStateFromContext(context));

            // If Session.Abandon() was called, remove the session data from the local Hashtable
            // and execute the Session_OnEnd event from the Global.asax file.
            if (stateProvider.IsAbandoned)
            {
                try
                {
                    pHashtableLock.AcquireWriterLock(Int32.MaxValue);

                    sessionID = pSessionIDManager.GetSessionID(context);
                    pSessionItems.Remove(sessionID);
                }
                finally
                {
                    pHashtableLock.ReleaseWriterLock();
                }

                SessionStateUtility.RaiseSessionEnd(stateProvider, this, EventArgs.Empty);
            }

            SessionStateUtility.RemoveHttpSessionStateFromContext(context);
        }