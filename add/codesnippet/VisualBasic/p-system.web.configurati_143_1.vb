         ' Get the current ComAuthenticationLevel property value.
            Dim comAuthLevel _
            As ProcessModelComAuthenticationLevel = _
            processModelSection.ComAuthenticationLevel
         
         ' Set the ComAuthenticationLevel property to
         ' ProcessModelComAuthenticationLevel.Call.
            processModelSection.ComAuthenticationLevel = _
            ProcessModelComAuthenticationLevel.Call

         