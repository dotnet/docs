Public Function MyCreateUser(username As String, password As String, email As String, _
                             question As String, answer As String) As MembershipUser

  Dim status As MembershipCreateStatus

  Dim u As MembershipUser = Membership.CreateUser(username, password, email, question, _
                                                  answer, True, status)
  If u Is Nothing Then
    Throw New MembershipCreateUserException(GetErrorMessage(status))
  End If

  Return u
End Function


Public Function GetErrorMessage(status As MembershipCreateStatus) As String

   Select Case status
      Case MembershipCreateStatus.DuplicateUserName
        Return "Username already exists. Please enter a different user name."

      Case MembershipCreateStatus.DuplicateEmail
        Return "A username for that e-mail address already exists. Please enter a different e-mail address."

      Case MembershipCreateStatus.InvalidPassword
        Return "The password provided is invalid. Please enter a valid password value."

      Case MembershipCreateStatus.InvalidEmail
        Return "The e-mail address provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidAnswer
        Return "The password retrieval answer provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidQuestion
        Return "The password retrieval question provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.InvalidUserName
        Return "The user name provided is invalid. Please check the value and try again."

      Case MembershipCreateStatus.ProviderError
        Return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

      Case MembershipCreateStatus.UserRejected
        Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

      Case Else
        Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
   End Select
End Function