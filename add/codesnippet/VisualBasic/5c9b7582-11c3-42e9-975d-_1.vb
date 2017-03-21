        '
        ' Event handler for HttpApplication.AcquireRequestState
        '
        Private Sub OnAcquireRequestState(ByVal [source] As Object, ByVal args As EventArgs)
            Dim app As HttpApplication = CType([source], HttpApplication)
            Dim context As HttpContext = app.Context
            Dim isNew As Boolean = False
            Dim sessionID As String
            Dim sessionData As SessionItem = Nothing
            Dim supportSessionIDReissue As Boolean = True

            pSessionIDManager.InitializeRequest(context, False, supportSessionIDReissue)
            sessionID = pSessionIDManager.GetSessionID(context)


            If Not (sessionID Is Nothing) Then
                Try
                    pHashtableLock.AcquireReaderLock(Int32.MaxValue)
                    sessionData = CType(pSessionItems(sessionID), SessionItem)

                    If Not (sessionData Is Nothing) Then
                        sessionData.Expires = DateTime.Now.AddMinutes(pTimeout)
                    End If
                Finally
                    pHashtableLock.ReleaseReaderLock()
                End Try
            Else
                Dim redirected, cookieAdded As Boolean

                sessionID = pSessionIDManager.CreateSessionID(context)
                pSessionIDManager.SaveSessionID(context, sessionID, redirected, cookieAdded)

                If redirected Then Return
            End If
            If sessionData Is Nothing Then
                ' Identify the session as a new session state instance. Create a new SessionItem
                ' and add it to the local Hashtable.
                isNew = True

                sessionData = New SessionItem()

                sessionData.Items = New SessionStateItemCollection()
                sessionData.StaticObjects = SessionStateUtility.GetSessionStaticObjects(context)
                sessionData.Expires = DateTime.Now.AddMinutes(pTimeout)

                Try
                    pHashtableLock.AcquireWriterLock(Int32.MaxValue)
                    pSessionItems(sessionID) = sessionData
                Finally
                    pHashtableLock.ReleaseWriterLock()
                End Try
            End If

            ' Add the session data to the current HttpContext.
            SessionStateUtility.AddHttpSessionStateToContext(context, _
                             New HttpSessionStateContainer(sessionID, _
                                                          sessionData.Items, _
                                                          sessionData.StaticObjects, _
                                                          pTimeout, _
                                                          isNew, _
                                                          pCookieMode, _
                                                          SessionStateMode.Custom, _
                                                          False))

            ' Execute the Session_OnStart event for a new session.
            If isNew Then RaiseEvent Start(Me, EventArgs.Empty)
        End Sub


        '
        ' Event for Session_OnStart event in the Global.asax file.
        '
	Public Event Start As EventHandler