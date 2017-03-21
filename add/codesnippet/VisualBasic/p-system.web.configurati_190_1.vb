                    ' Get the first client target 
                    ' in the collection.
                    clientTarget = clientTargets(0)

                    ' Get he user agent.
                    userAgent = clientTarget.UserAgent

                    msg = String.Format( _
                    "User Agent: {0}" + ControlChars.Lf, userAgent)
