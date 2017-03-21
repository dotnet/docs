        //
        // Event handler for HttpApplication.AcquireRequestState
        //

        private void OnAcquireRequestState(object source, EventArgs args)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;
            bool isNew = false;
            string sessionID;
            SessionItem sessionData = null;
            bool supportSessionIDReissue = true;

            pSessionIDManager.InitializeRequest(context, false, out supportSessionIDReissue);
            sessionID = pSessionIDManager.GetSessionID(context);


            if (sessionID != null)
            {
                try
                {
                    pHashtableLock.AcquireReaderLock(Int32.MaxValue);
                    sessionData = (SessionItem)pSessionItems[sessionID];

                    if (sessionData != null)
                       sessionData.Expires = DateTime.Now.AddMinutes(pTimeout);
                }
                finally
                {
                    pHashtableLock.ReleaseReaderLock();
                }
            }
            else
            {
                bool redirected, cookieAdded;

                sessionID = pSessionIDManager.CreateSessionID(context);
                pSessionIDManager.SaveSessionID(context, sessionID, out redirected, out cookieAdded);

                if (redirected)
                    return;
            }

            if (sessionData == null)
            {
                // Identify the session as a new session state instance. Create a new SessionItem
                // and add it to the local Hashtable.

                isNew = true;

                sessionData = new SessionItem();

                sessionData.Items = new SessionStateItemCollection();
                sessionData.StaticObjects = SessionStateUtility.GetSessionStaticObjects(context);
                sessionData.Expires = DateTime.Now.AddMinutes(pTimeout);

                try
                {
                    pHashtableLock.AcquireWriterLock(Int32.MaxValue);
                    pSessionItems[sessionID] = sessionData;
                }
                finally
                {
                    pHashtableLock.ReleaseWriterLock();
                }
            }

            // Add the session data to the current HttpContext.
            SessionStateUtility.AddHttpSessionStateToContext(context,
                             new HttpSessionStateContainer(sessionID,
                                                          sessionData.Items,
                                                          sessionData.StaticObjects,
                                                          pTimeout,
                                                          isNew,
                                                          pCookieMode,
                                                          SessionStateMode.Custom,
                                                          false));

            // Execute the Session_OnStart event for a new session.
            if (isNew && Start != null)
            {
                Start(this, EventArgs.Empty);
            }
        }

        //
        // Event for Session_OnStart event in the Global.asax file.
        //

        public event EventHandler Start;