         ' Get the current ComImpersonationLevel property value.
            Dim comImpLevel _
            As ProcessModelComImpersonationLevel = _
            processModelSection.ComImpersonationLevel
         
         ' Set the ComImpersonationLevel property to
         ' ProcessModelComImpersonationLevel.Anonymous.
            processModelSection.ComImpersonationLevel = _
            ProcessModelComImpersonationLevel.Anonymous
         