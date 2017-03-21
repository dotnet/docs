        '
        ' Event handler for HttpApplication.ReleaseRequestState
        '
        Private Sub OnReleaseRequestState(ByVal [source] As Object, ByVal args As EventArgs)
            Dim app As HttpApplication = CType([source], HttpApplication)
            Dim context As HttpContext = app.Context
            Dim sessionID As String

            ' Read the session state from the context
            Dim stateProvider As HttpSessionStateContainer = _
               CType(SessionStateUtility.GetHttpSessionStateFromContext(context), HttpSessionStateContainer)

            ' If Session.Abandon() was called, remove the session data from the local Hashtable
            ' and execute the Session_OnEnd event from the Global.asax file.
            If stateProvider.IsAbandoned Then
                Try
                    pHashtableLock.AcquireWriterLock(Int32.MaxValue)

                    sessionID = pSessionIDManager.GetSessionID(context)
                    pSessionItems.Remove(sessionID)
                Finally
                    pHashtableLock.ReleaseWriterLock()
                End Try

                SessionStateUtility.RaiseSessionEnd(stateProvider, Me, EventArgs.Empty)
            End If

          SessionStateUtility.RemoveHttpSessionStateFromContext(context)
        End Sub