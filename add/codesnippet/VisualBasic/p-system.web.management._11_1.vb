   ' Get the impersonation mode.
   Public Function GetThreadImpersonation() As String
        Return String.Format( _
        "Is impersonating: {0}", _
        ThreadInformation.IsImpersonating.ToString())
   End Function 'GetThreadImpersonation
   