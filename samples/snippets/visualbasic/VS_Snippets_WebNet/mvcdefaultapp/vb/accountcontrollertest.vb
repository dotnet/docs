Imports System
Imports System.Security
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Security
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class AccountControllerTest

    <TestMethod()> Public Sub ChangePasswordGetReturnsView()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.ChangePassword(), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
    End Sub

    <TestMethod()> Public Sub ChangePasswordPostRedirectsOnSuccess()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As RedirectToRouteResult = CType(controller.ChangePassword("oldPass", "newPass", "newPass"), RedirectToRouteResult)

        ' Assert
        Assert.AreEqual("ChangePasswordSuccess", result.RouteValues("action"))
    End Sub

    <TestMethod()> Public Sub ChangePasswordPostReturnsViewIfCurrentPasswordNotSpecified()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.ChangePassword("", "newPassword", "newPassword"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("You must specify a current password.", result.ViewData.ModelState("currentPassword").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub ChangePasswordPostReturnsViewIfNewPasswordDoesNotMatchConfirmPassword()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.ChangePassword("currentPassword", "newPassword", "otherPassword"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("The new password and confirmation password do not match.", result.ViewData.ModelState("_FORM").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub ChangePasswordPostReturnsViewIfNewPasswordIsNothing()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.ChangePassword("currentPassword", Nothing, Nothing), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("You must specify a new password of 6 or more characters.", result.ViewData.ModelState("newPassword").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub ChangePasswordPostReturnsViewIfNewPasswordIsTooShort()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.ChangePassword("currentPassword", "12345", "12345"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("You must specify a new password of 6 or more characters.", result.ViewData.ModelState("newPassword").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub ChangePasswordPostReturnsViewIfProviderRejectsPassword()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.ChangePassword("oldPass", "badPass", "badPass"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("The current password is incorrect or the new password is invalid.", result.ViewData.ModelState("_FORM").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub ChangePasswordSuccess()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.ChangePasswordSuccess(), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()> Public Sub ConstructorSetsProperties()
        ' Arrange
        Dim formsAuth As IFormsAuthentication = New MockFormsAuthenticationService()
        Dim membershipService As IMembershipService = New AccountMembershipService()

        ' Act
        Dim controller As AccountController = New AccountController(formsAuth, membershipService)

        ' Assert
        Assert.AreEqual(formsAuth, controller.FormsAuth, "FormsAuth property did not match.")
        Assert.AreEqual(membershipService, controller.MembershipService, "MembershipService property did not match.")
    End Sub

    <TestMethod()> Public Sub ConstructorSetsPropertiesToDefaultValues()
        ' Act
        Dim controller As AccountController = New AccountController()

        ' Assert
        Assert.IsNotNull(controller.FormsAuth, "FormsAuth property is Nothing.")
        Assert.IsNotNull(controller.MembershipService, "MembershipService property is Nothing.")
    End Sub

    <TestMethod()> Public Sub LoginGet()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.LogOn(), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()> Public Sub LoginPostRedirectsHomeIfLoginSuccessfulButNoReturnUrlGiven()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As RedirectToRouteResult = CType(controller.LogOn("someUser", "goodPass", True, Nothing), RedirectToRouteResult)

        ' Assert
        Assert.AreEqual("Home", result.RouteValues("controller"))
        Assert.AreEqual("Index", result.RouteValues("action"))
    End Sub

    <TestMethod()> Public Sub LoginPostRedirectsToReturnUrlIfLoginSuccessfulAndReturnUrlGiven()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As RedirectResult = CType(controller.LogOn("someUser", "goodPass", False, "someUrl"), RedirectResult)

        ' Assert
        Assert.AreEqual("someUrl", result.Url)
    End Sub

    <TestMethod()> Public Sub LoginPostReturnsViewIfPasswordNotSpecified()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.LogOn("username", "", True, Nothing), ViewResult)

        ' Assert
        Assert.AreEqual("You must specify a password.", result.ViewData.ModelState("password").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub LoginPostReturnsViewIfUsernameNotSpecified()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.LogOn("", "somePass", False, Nothing), ViewResult)

        ' Assert
        Assert.AreEqual("You must specify a username.", result.ViewData.ModelState("username").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub LoginPostReturnsViewIfUsernameOrPasswordIsIncorrect()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.LogOn("someUser", "badPass", True, Nothing), ViewResult)

        ' Assert
        Assert.AreEqual("The username or password provided is incorrect.", result.ViewData.ModelState("_FORM").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub LogOff()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As RedirectToRouteResult = CType(controller.LogOff(), RedirectToRouteResult)

        ' Assert
        Assert.AreEqual("Home", result.RouteValues("controller"))
        Assert.AreEqual("Index", result.RouteValues("action"))
    End Sub

    <TestMethod()> Public Sub RegisterGet()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.Register(), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
    End Sub

    <TestMethod()> Public Sub RegisterPostRedirectsHomeIfRegistrationSuccessful()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As RedirectToRouteResult = CType(controller.Register("someUser", "email", "goodPass", "goodPass"), RedirectToRouteResult)

        ' Assert
        Assert.AreEqual("Home", result.RouteValues("controller"))
        Assert.AreEqual("Index", result.RouteValues("action"))
    End Sub

    <TestMethod()> Public Sub RegisterPostReturnsViewIfEmailNotSpecified()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.Register("username", "", "password", "password"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("You must specify an email address.", result.ViewData.ModelState("email").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub RegisterPostReturnsViewIfNewPasswordDoesNotMatchConfirmPassword()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.Register("username", "email", "password", "password2"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("The new password and confirmation password do not match.", result.ViewData.ModelState("_FORM").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub RegisterPostReturnsViewIfPasswordIsNothing()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.Register("username", "email", Nothing, Nothing), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("You must specify a password of 6 or more characters.", result.ViewData.ModelState("password").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub RegisterPostReturnsViewIfPasswordIsTooShort()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.Register("username", "email", "12345", "12345"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("You must specify a password of 6 or more characters.", result.ViewData.ModelState("password").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub RegisterPostReturnsViewIfRegistrationFails()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.Register("someUser", "DuplicateUserName", "badPass", "badPass"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("Username already exists. Please enter a different user name.", result.ViewData.ModelState("_FORM").Errors(0).ErrorMessage)
    End Sub

    <TestMethod()> Public Sub RegisterPostReturnsViewIfUsernameNotSpecified()
        ' Arrange
        Dim controller As AccountController = GetAccountController()

        ' Act
        Dim result As ViewResult = CType(controller.Register("", "email", "password", "password"), ViewResult)

        ' Assert
        Assert.AreEqual(6, result.ViewData("PasswordLength"))
        Assert.AreEqual("You must specify a username.", result.ViewData.ModelState("username").Errors(0).ErrorMessage)
    End Sub


    Private Shared Function GetAccountController() As AccountController
        Dim formsAuth As IFormsAuthentication = New MockFormsAuthenticationService()
        Dim membershipProvider As MembershipProvider = New MockMemberShipProvider()
        Dim membershipService As AccountMembershipService = New AccountMembershipService(membershipProvider)
        Dim controller As AccountController = New AccountController(formsAuth, membershipService)
        Dim controllerContext As ControllerContext = New ControllerContext(New MockHttpContext(), New RouteData(), controller)
        controller.ControllerContext = controllerContext
        Return controller
    End Function
End Class

Public Class MockFormsAuthenticationService
    Implements IFormsAuthentication

    Public Sub SignIn(ByVal userName As String, ByVal createPersistentCookie As Boolean) Implements IFormsAuthentication.SignIn

    End Sub

    Public Sub SignOut() Implements IFormsAuthentication.SignOut

    End Sub
End Class

Public Class MockIdentity
    Implements IIdentity

    Public ReadOnly Property AuthenticationType() As String Implements System.Security.Principal.IIdentity.AuthenticationType
        Get
            Return "MockAuthentication"
        End Get
    End Property

    Public ReadOnly Property IsAuthenticated() As Boolean Implements System.Security.Principal.IIdentity.IsAuthenticated
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name
        Get
            Return "someUser"
        End Get
    End Property
End Class

Public Class MockPrincipal
    Implements IPrincipal
    Private _identity As IIdentity

    Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            If (_identity Is Nothing) Then
                _identity = New MockIdentity()
            End If

            Return _identity
        End Get
    End Property

    Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
        Return False
    End Function
End Class

Public Class MockMembershipUser
    Inherits MembershipUser

    Public Overrides Function ChangePassword(ByVal oldPassword As String, ByVal newPassword As String) As Boolean
        Return newPassword.Equals("newPass")
    End Function
End Class

Public Class MockHttpContext
    Inherits HttpContextBase

    Private _user As IPrincipal

    Public Overrides Property User() As System.Security.Principal.IPrincipal
        Get
            If (_user Is Nothing) Then
                _user = New MockPrincipal()
            End If
            Return _user
        End Get
        Set(ByVal value As System.Security.Principal.IPrincipal)
            _user = value
        End Set
    End Property
End Class

Public Class MockMemberShipProvider
    Inherits MembershipProvider

    Private _applicationName As String

    Public Overrides Property ApplicationName() As String
        Get
            Return _applicationName
        End Get
        Set(ByVal value As String)
            _applicationName = value
        End Set
    End Property

    Public Overrides Function ChangePassword(ByVal username As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, ByVal password As String, ByVal newPasswordQuestion As String, ByVal newPasswordAnswer As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean, ByVal providerUserKey As Object, ByRef status As System.Web.Security.MembershipCreateStatus) As System.Web.Security.MembershipUser
        Dim user As MockMembershipUser = New MockMembershipUser()

        If username.Equals("someUser") And password.Equals("goodPass") And email.Equals("email") Then
            status = MembershipCreateStatus.Success
        Else
            ' the 'email' parameter contains the status we want to return to the user
            status = CType([Enum].Parse(GetType(MembershipCreateStatus), email), MembershipCreateStatus)
        End If

        Return user
    End Function

    Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Function FindUsersByEmail(ByVal emailToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overrides Function FindUsersByName(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetAllUsers(ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetNumberOfUsersOnline() As Integer
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function GetUser(ByVal username As String, ByVal userIsOnline As Boolean) As System.Web.Security.MembershipUser
        Return New MockMembershipUser()
    End Function

    Public Overrides Function GetUserNameByEmail(ByVal email As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
        Get
            Return 6
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
        Get
            Return 3
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
        Get
            Return MembershipPasswordFormat.Clear
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
        Get
            Return Nothing
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function UnlockUser(ByVal userName As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Sub UpdateUser(ByVal user As System.Web.Security.MembershipUser)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean
        Return password.Equals("goodPass")
    End Function
End Class
