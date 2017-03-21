   Public Function GetAccountName() As String
      ' Get the name of the account.
        Return String.Format("Account name: {0}", _
        processInformation.AccountName)
   End Function 'GetAccountName
   