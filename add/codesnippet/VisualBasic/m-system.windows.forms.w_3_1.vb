        Private cookie As AxHost.ConnectionPointCookie
        Private helper As WebBrowser2EventHelper

        <PermissionSetAttribute(SecurityAction.LinkDemand, _
        Name := "FullTrust")> Protected Overrides Sub CreateSink()

            MyBase.CreateSink()

            ' Create an instance of the client that will handle the event
            ' and associate it with the underlying ActiveX control.
            helper = New WebBrowser2EventHelper(Me)
            cookie = New AxHost.ConnectionPointCookie( _
                Me.ActiveXInstance, helper, GetType(DWebBrowserEvents2))
        End Sub

        <PermissionSetAttribute(SecurityAction.LinkDemand, _
        Name := "FullTrust")> Protected Overrides Sub DetachSink()

            ' Disconnect the client that handles the event
            ' from the underlying ActiveX control.
            If cookie IsNot Nothing Then
                cookie.Disconnect()
                cookie = Nothing
            End If
            MyBase.DetachSink()

        End Sub