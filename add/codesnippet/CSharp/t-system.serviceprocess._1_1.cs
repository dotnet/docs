        // Handle a session change notice
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() +
                " - Session change notice received: " +
                changeDescription.Reason.ToString() + "  Session ID: " +
                changeDescription.SessionId.ToString());
#endif

            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    userCount += 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionLogon, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.SessionLogoff:

                    userCount -= 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionLogoff, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.RemoteConnect:
                    userCount += 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " RemoteConnect, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.RemoteDisconnect:
                    userCount -= 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " RemoteDisconnect, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.SessionLock:
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionLock");
#endif
                    break;
                case SessionChangeReason.SessionUnlock:
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionUnlock");
#endif
                    break;
                default:
                    break;
            }
        }