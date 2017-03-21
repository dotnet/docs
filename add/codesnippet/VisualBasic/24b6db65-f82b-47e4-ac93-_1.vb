    Public Function DetermineApplicationTrust(ByVal appContext As ActivationContext, ByVal context As TrustManagerContext) As ApplicationTrust Implements IApplicationTrustManager.DetermineApplicationTrust
        Dim trust As New ApplicationTrust(appContext.Identity)
        trust.IsApplicationTrustedToRun = False

        Dim asi As New ApplicationSecurityInfo(appContext)
        trust.DefaultGrantSet = New PolicyStatement(asi.DefaultRequestSet, _
        PolicyStatementAttribute.Nothing)
        If context.UIContext = TrustManagerUIContext.Run Then
            Dim message As String = "Do you want to run " + asi.ApplicationId.Name + " ?"
            Dim caption As String = "MyTrustManager"
            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim result As DialogResult

            ' Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons)

            If result = DialogResult.Yes Then
                trust.IsApplicationTrustedToRun = True
                If Not (context Is Nothing) Then
                    trust.Persist = context.Persist
                Else
                    trust.Persist = False
                End If
            End If
        End If
        Return trust

    End Function 'DetermineApplicationTrust
    