    ' Implements the IWebEventCustomEvaluator.CanFire 
    ' method. It is called by the ASP.NET if this custom
    ' type is configured in the profile
    ' element of the healthMonitoring section.
    Public Function CanFire( _
    ByVal e As System.Web.Management.WebBaseEvent, _
    ByVal rule As RuleFiringRecord) As Boolean _
    Implements System.Web.Management.IWebEventCustomEvaluator.CanFire

        Dim fireEvent As Boolean
        Dim lastFired As String = _
            rule.LastFired.ToString()
        Dim timesRaised As String = _
            rule.TimesRaised.ToString()

        ' Fire every other event raised.
        fireEvent = _
        IIf(rule.TimesRaised Mod 2 = 0, True, False)

        If fireEvent Then
            firingRecordInfo = String.Format( _
            "Event last fired: {0}", lastFired) + _
            String.Format( _
            ". Times raised: {0}",  timesRaised) 
          
        Else
            firingRecordInfo = String.Format( _
            "Event not fired. Times raised: {0}", _
            timesRaised)
        End If

        Return fireEvent

    End Function 'CanFire
