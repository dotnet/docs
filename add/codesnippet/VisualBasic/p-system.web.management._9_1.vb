   ' Get the account name.
   Public Function GetThreadAccountName() As String
        Return String.Format( _
        "Request user host address: {0}", _
        ThreadInformation.ThreadAccountName)
   End Function 'GetThreadAccountName
   