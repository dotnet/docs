Imports System.Web.Security
Imports System.Configuration.Provider
Imports System.Collections.Specialized
Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Configuration
Imports System.Diagnostics
Imports System.Web
Imports System.Globalization
Imports System.Web.Configuration
Imports System.Security.Cryptography
Imports System.Text


'
' This provider works with the following schema for the table of user data.
' 
' CREATE TABLE Users
' (
'   PKID Guid NOT NULL PRIMARY KEY,
'   Username Text (255) NOT NULL,
'   ApplicationName Text (255) NOT NULL,
'   Email Text (128) NOT NULL,
'   Comment Text (255),
'   Password Text (128) NOT NULL,
'   PasswordQuestion Text (255),
'   PasswordAnswer Text (128),
'   IsApproved YesNo, 
'   LastActivityDate DateTime,
'   LastLoginDate DateTime,
'   LastPasswordChangedDate DateTime,
'   CreationDate DateTime, 
'   IsOnLine YesNo,
'   IsLockedOut YesNo,
'   LastLockedOutDate DateTime,
'   FailedPasswordAttemptCount Integer,
'   FailedPasswordAttemptWindowStart DateTime,
'   FailedPasswordAnswerAttemptCount Integer,
'   FailedPasswordAnswerAttemptWindowStart DateTime
' )
'  


Namespace Samples.AspNet.Membership

  Public NotInheritable Class OdbcMembershipProvider
  Inherits MembershipProvider
  

  Private newPasswordLength As Integer = 8

  '
  ' Used when determining encryption key values.
  '

  Private machineKey As MachineKeySection



  '
  ' Database connection string.
  '

  Private pConnectionStringSettings As ConnectionStringSettings 

  Public ReadOnly Property ConnectionString As String 
    Get
  Return pConnectionStringSettings.ConnectionString
    End Get
  End Property





  '
  ' System.Configuration.Provider.ProviderBase.Initialize Method
  '

Public Overrides Sub Initialize(name As String, config As NameValueCollection)
  

      '
      ' Initialize values from web.config.
      '

      If config Is Nothing Then _
        Throw New ArgumentNullException("config")

      If name Is Nothing OrElse name.Length = 0 Then _
        name = "OdbcMembershipProvider"

      If String.IsNullOrEmpty(config("description")) Then
        config.Remove("description")
        config.Add("description", "Sample ODBC Membership provider")
      End If

      ' Initialize the abstract base class.
      MyBase.Initialize(name, config)


      pApplicationName           = GetConfigValue(config("applicationName"), _
                                     System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath)
      pMaxInvalidPasswordAttempts  = Convert.ToInt32(GetConfigValue(config("maxInvalidPasswordAttempts"), "5"))
      pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config("passwordAttemptWindow"), "10"))
      pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config("minRequiredAlphaNumericCharacters"), "1"))
      pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config("minRequiredPasswordLength"), "7"))
      pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config("passwordStrengthRegularExpression"), ""))
      pEnablePasswordReset       = Convert.ToBoolean(GetConfigValue(config("enablePasswordReset"), "True"))      
      pEnablePasswordRetrieval   = Convert.ToBoolean(GetConfigValue(config("enablePasswordRetrieval"), "True"))
      pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config("requiresQuestionAndAnswer"), "False"))
      pRequiresUniqueEmail       = Convert.ToBoolean(GetConfigValue(config("requiresUniqueEmail"), "True"))

      Dim temp_format As String = config("passwordFormat")
      If temp_format Is Nothing Then      
        temp_format = "Hashed"
      End If

      Select Case temp_format      
        Case "Hashed"
          pPasswordFormat = MembershipPasswordFormat.Hashed
        Case "Encrypted"
          pPasswordFormat = MembershipPasswordFormat.Encrypted
        Case "Clear"
          pPasswordFormat = MembershipPasswordFormat.Clear
        Case Else
          Throw New ProviderException("Password format not supported.")
      End Select
    '
    ' Initialize OdbcConnection.
    '

    pConnectionStringSettings = ConfigurationManager.ConnectionStrings(config("connectionStringName"))

  If pConnectionStringSettings Is Nothing OrElse pConnectionStringSettings.ConnectionString.Trim() = "" Then
    Throw New ProviderException("Connection string cannot be blank.")
    End If


    ' Get encryption and decryption key information from the configuration.
    Dim cfg As System.Configuration.Configuration = _
      WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath)
    machineKey = CType(cfg.GetSection("system.web/machineKey"), MachineKeySection)
End Sub

    '
    ' A helper function to retrieve config values from the configuration file.
    '

    Private Function GetConfigValue(configValue As String, defaultValue As String) As String
      If configValue Is Nothing OrElse configValue.Trim() = "" Then _
        Return defaultValue

      Return configValue
    End Function


  '
  ' System.Web.Security.MembershipProvider properties.
  '

    Private pRequiresUniqueEmail       As Boolean

    Public Overrides ReadOnly Property RequiresUniqueEmail As Boolean    
      Get
        Return pRequiresUniqueEmail
      End Get
    End Property

    Private pMaxInvalidPasswordAttempts  As Integer

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts As Integer
      Get
        Return pMaxInvalidPasswordAttempts
      End Get
    End Property

    Private pPasswordAttemptWindow     As Integer

    Public Overrides ReadOnly Property PasswordAttemptWindow As Integer
      Get
        Return pPasswordAttemptWindow
      End Get
    End Property

    Private pPasswordFormat            As MembershipPasswordFormat

    Public Overrides ReadOnly Property PasswordFormat As MembershipPasswordFormat
      Get
        Return pPasswordFormat
      End Get
    End Property

    Private pMinRequiredNonAlphanumericCharacters As Integer

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
      Get
        Return pMinRequiredNonAlphanumericCharacters
      End Get
    End Property

    Private pMinRequiredPasswordLength As Integer

    Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
      Get
        Return pMinRequiredPasswordLength
      End Get
    End Property

    Private pPasswordStrengthRegularExpression As String

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
      Get
        Return pPasswordStrengthRegularExpression
      End Get
    End Property
  
' - 17>
Private pApplicationName As String

Public Overrides Property ApplicationName As String
  Get
  Return pApplicationName
  End Get
  Set
    pApplicationName = value
  End Set
End Property
' - /17>

' - 1>
Private pEnablePasswordReset As Boolean

Public Overrides ReadOnly Property EnablePasswordReset As Boolean
  Get
  Return pEnablePasswordReSet
  End Get
End Property
' - /1>

' - 2>
Private pEnablePasswordRetrieval As Boolean

Public Overrides ReadOnly Property EnablePasswordRetrieval As Boolean
  Get
  Return pEnablePasswordRetrieval
  End Get
End Property
' - /2>


' - 3>
Private pRequiresQuestionAndAnswer As Boolean

Public Overrides ReadOnly Property RequiresQuestionAndAnswer As Boolean
  Get
  Return pRequiresQuestionAndAnswer
  End Get
End Property
' - /3>


  '
  ' System.Web.Security.MembershipProvider methods.
  '

  '
  ' MembershipProvider.ChangePassword
  '

' - 4>
Public Overrides Function ChangePassword(username As String, _
                                         oldPwd As String, _
                                         newPwd As String) As Boolean
  
  If Not ValidateUser(username, oldPwd) Then
    Throw New MembershipPasswordException("Password validation failed.")
  End If

  Dim args As ValidatePasswordEventArgs = _
    New ValidatePasswordEventArgs(username, newPwd, True)

  OnValidatingPassword(args)
  
  If args.Cancel Then
    If Not args.FailureInformation Is Nothing Then
      Throw args.FailureInformation
    Else
      Throw New Exception("Change password canceled due to New password validation failure.")
    End If
  End If

  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("UPDATE Users " & _
                                 " SET Password = ?, LastPasswordChangedDate = ? " & _
                                 " WHERE Username = ? AND Password = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = newPwd
            cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@OldPassword", OdbcType.VarChar, 128).Value = oldPwd
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


            Dim rowsAffected As Integer = 0

            Try
                conn.Open()

                rowsAffected = cmd.ExecuteNonQuery()
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            If rowsAffected > 0 Then Return True

            Return False
        End Function
        ' - /4>



        '
        ' MembershipProvider.ChangePasswordQuestionAndAnswer
        '

        ' - 5>
        Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, _
        ByVal password As String, _
        ByVal newPwdQuestion As String, _
        ByVal newPwdAnswer As String) _
                                                                  As Boolean

            If Not ValidateUser(username, password) Then Return False

            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("UPDATE Users " & _
                                  " SET PasswordQuestion = ?, PasswordAnswer = ?" & _
                                 " WHERE Username = ? AND Password = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Question", OdbcType.VarChar, 255).Value = newPwdQuestion
            cmd.Parameters.Add("@Answer", OdbcType.VarChar, 128).Value = newPwdAnswer
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = password
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


            Dim rowsAffected As Integer = 0

            Try
                conn.Open()

                rowsAffected = cmd.ExecuteNonQuery()
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            If rowsAffected > 0 Then Return True

            Return False
        End Function
' - /5>




  '
  ' MembershipProvider.CreateUser
  '

' - 6>
Public Overrides Function CreateUser(username As String, _
         password As String, _
         email As String, _
         passwordQuestion As String, _
         passwordAnswer As String, _
         isApproved As Boolean, _
         providerUserKey As Object, _
         ByRef status As MembershipCreateStatus) As MembershipUser 
    
  Dim Args As ValidatePasswordEventArgs = _
    New ValidatePasswordEventArgs(username, password, True)

  OnValidatingPassword(args)
  
  If args.Cancel Then
    If Not args.FailureInformation Is Nothing Then
      Throw args.FailureInformation
    Else
      Throw New Exception("Create user canceled due to password validation failure.")
    End If
  End If


  If RequiresUniqueEmail AndAlso GetUserNameByEmail(email) <> "" Then      
    status = MembershipCreateStatus.DuplicateEmail
    Return Nothing
  End If

  Dim u As MembershipUser = GetUser(username, False)

  If u Is Nothing Then      
    Dim createDate As DateTime = DateTime.Now

    If providerUserKey Is Nothing Then        
      providerUserKey = Guid.NewGuid()
    Else        
      If Not TypeOf providerUserKey Is Guid Then          
        status = MembershipCreateStatus.InvalidProviderUserKey
        Return Nothing
      End If
    End If

    Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
                Dim cmd As OdbcCommand = New OdbcCommand("INSERT INTO Users " & _
                      " (PKID, Username, Password, Email, PasswordQuestion, " & _
                      " PasswordAnswer, IsApproved," & _
                      " Comment, CreationDate, LastPasswordChangedDate, LastActivityDate," & _
                      " ApplicationName, IsLockedOut, LastLockedOutDate," & _
                      " FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, " & _
                      " FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)" & _
                      " Values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", conn)

                cmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey
                cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
                cmd.Parameters.Add("@Password", OdbcType.VarChar, 255).Value = EncodePassword(password)
                cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = email
                cmd.Parameters.Add("@PasswordQuestion", OdbcType.VarChar, 255).Value = passwordQuestion
                cmd.Parameters.Add("@PasswordAnswer", OdbcType.VarChar, 128).Value = passwordAnswer
                cmd.Parameters.Add("@IsApproved", OdbcType.Bit).Value = isApproved
                cmd.Parameters.Add("@Comment", OdbcType.VarChar, 255).Value = ""
                cmd.Parameters.Add("@CreationDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName
                cmd.Parameters.Add("@IsLockedOut", OdbcType.Bit).Value = False
                cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@FailedPasswordAttemptCount", OdbcType.Int).Value = 0
                cmd.Parameters.Add("@FailedPasswordAttemptWindowStart", OdbcType.DateTime).Value = createDate
                cmd.Parameters.Add("@FailedPasswordAnswerAttemptCount", OdbcType.Int).Value = 0
                cmd.Parameters.Add("@FailedPasswordAnswerAttemptWindowStart", OdbcType.DateTime).Value = createDate

                Try
                    conn.Open()

                    Dim recAdded As Integer = cmd.ExecuteNonQuery()

                    If recAdded > 0 Then
                        status = MembershipCreateStatus.Success
                    Else
                        status = MembershipCreateStatus.UserRejected
                    End If
                Catch e As OdbcException
                    ' Handle exception.

                    status = MembershipCreateStatus.ProviderError
                Finally
                    conn.Close()
                End Try


                Return GetUser(username, False)
            Else
                status = MembershipCreateStatus.DuplicateUserName
            End If

            Return Nothing
        End Function
        ' - /6>



        '
        ' MembershipProvider.DeleteUser
        '

        ' - 7>
        Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean

            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("DELETE FROM Users " & _
                                       " WHERE Username = ? AND Applicationname = ?", conn)

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


            Dim rowsAffected As Integer = 0

            Try
                conn.Open()

                rowsAffected = cmd.ExecuteNonQuery()

                If deleteAllRelatedData Then
                    ' Process commands to delete all data for the user in the database.
                End If
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            If rowsAffected > 0 Then Return True

            Return False
        End Function
' - /7>




  '
  ' MembershipProvider.GetAllUsers
  '


Public Overrides Function GetAllUsers(pageIndex As Integer, _
                                      pageSize As Integer, _
                                      ByRef totalRecords As Integer) _
                                      As MembershipUserCollection 
  
  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Count(*) FROM Users  " & _
                                                     "WHERE ApplicationName = ?", conn)
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim users As MembershipUserCollection = New MembershipUserCollection()

            Dim reader As OdbcDataReader = Nothing
            totalRecords = 0

            Try
                conn.Open()
                totalRecords = CType(cmd.ExecuteScalar(), Integer)

                If totalRecords <= 0 Then Return users

                cmd.CommandText = "SELECT Username, Email, PasswordQuestion," & _
                                  " Comment, IsApproved, CreationDate, LastLoginDate," & _
                                  " LastActivityDate, LastPasswordChangedDate " & _
                                  " FROM Users  " & _
                                  " WHERE ApplicationName = ? " & _
                                  " ORDER BY Username Asc"

                reader = cmd.ExecuteReader()

                Dim counter As Integer = 0
                Dim startIndex As Integer = pageSize * pageIndex
                Dim endIndex As Integer = startIndex + pageSize - 1

                Do While reader.Read()
                    If counter >= startIndex Then
                        Dim u As MembershipUser = GetUserFromReader(reader)
                        users.Add(u)
                    End If

                    If counter >= endIndex Then cmd.Cancel()

                    counter += 1
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

  Return users
End Function






  '
  ' MembershipProvider.GetNumberOfUsersOnline
  '

' - 8>
Public Overrides Function GetNumberOfUsersOnline() As Integer

  Dim onlineSpan As TimeSpan = New TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0)
  Dim compareTime As DateTime = DateTime.Now.Subtract(onlineSpan)

  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Count(*) FROM Users " & _
                                         " WHERE LastActivityDate > ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@CompareDate", OdbcType.DateTime).Value = compareTime
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim numOnline As Integer = 0

            Try
                conn.Open()

                numOnline = CType(cmd.ExecuteScalar(), Integer)
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            Return numOnline
        End Function
        ' - /8>




        '
        ' MembershipProvider.GetPassword
        '

        ' - 9>
        Public Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String

            If Not EnablePasswordRetrieval Then
                Throw New ProviderException("Password retrieval is not enabled.")
            End If

            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Password, PasswordAnswer FROM Users " & _
                                                     " WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


            Dim password As String = ""
            Dim passwordAnswer As String = ""
            Dim reader As OdbcDataReader = Nothing

            Try
                conn.Open()

                reader = cmd.ExecuteReader(CommandBehavior.SingleRow)

                If reader.HasRows Then
                    reader.Read()
                    password = reader.GetString(0)
                    passwordAnswer = reader.GetString(1)
                End If
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            If RequiresQuestionAndAnswer AndAlso _
                  String.Compare(passwordAnswer, answer, True, CultureInfo.InvariantCulture) <> 0 Then
                Throw New MembershipPasswordException("Incorrect password answer.")
            End If

            Return password
        End Function
' - /9>



  '
  ' MembershipProvider.GetUser
  '

' - 10>
Public Overrides Function GetUser(username As String, userIsOnline As Boolean) As MembershipUser
  
  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT PKID, Username, Email, PasswordQuestion," & _
                  " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," & _
                  " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate" & _
                  " FROM Users  WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

            Dim u As MembershipUser = Nothing
            Dim reader As OdbcDataReader = Nothing

            Try
                conn.Open()

                reader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    u = GetUserFromReader(reader)

                    If userIsOnline Then
                        Dim updateCmd As OdbcCommand = New OdbcCommand("UPDATE Users  " & _
                                  "SET LastActivityDate = ? " & _
                                  "WHERE Username = ? AND Applicationname = ?", conn)

                        updateCmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now
                        updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
                        updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

                        updateCmd.ExecuteNonQuery()
                    End If
                End If
            Catch e As OdbcException
                ' Handle Exception
            Finally
                If Not reader Is Nothing Then reader.Close()

                conn.Close()
            End Try

  Return u      
End Function


' - /10>



  '
  ' MembershipProvider.GetUserNameByEmail
  '

' - 11>
Public Overrides Function GetUserNameByEmail(email As String) As String
  
  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Username" & _
                             " FROM Users  WHERE Email = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = email
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim username As String = ""

            Try
                conn.Open()

                username = CType(cmd.ExecuteScalar(), String)
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            Return username
        End Function
        ' - /11>





        '
        ' MembershipProvider.ResetPassword
        '


        ' - 12>
        Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String

            If Not EnablePasswordReset Then
                Throw New NotSupportedException("Password reSet is not enabled.")
            End If

            If answer Is Nothing AndAlso RequiresQuestionAndAnswer Then
                Throw New ProviderException("A password answer is required to reSet the password.")
            End If

            Dim newPassword As String = _
              System.Web.Security.Membership.GeneratePassword(newPasswordLength, pMinRequiredNonAlphanumericCharacters)


            Dim Args As ValidatePasswordEventArgs = _
              New ValidatePasswordEventArgs(username, newPassword, True)

            OnValidatingPassword(args)

            If args.Cancel Then
                If Not args.FailureInformation Is Nothing Then
                    Throw args.FailureInformation
                Else
                    Throw New Exception("Reset password canceled due to password validation failure.")
                End If
            End If


            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("UPDATE Users " & _
                                 " SET Password = ?, LastPasswordChangedDate = ?" & _
                                 " WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Password", OdbcType.VarChar, 128).Value = newPassword
            cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            If RequiresQuestionAndAnswer Then
                cmd.CommandText &= " AND PasswordAnswer = ?"
                cmd.Parameters.Add("@PasswordAnswer", OdbcType.VarChar, 128).Value = answer
            End If

            Dim rowsAffected As Integer = 0

            Try
                conn.Open()

                rowsAffected = cmd.ExecuteNonQuery()
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            If rowsAffected > 0 Then
                Return newPassword
            Else
                Throw New MembershipPasswordException("Invalid password answer for userid. Password not reset.")
            End If
        End Function
' - /12>



  '
  ' MembershipProvider.UpdateUser
  '

' - 13>
Public Overrides Sub UpdateUser(user As MembershipUser)
  
  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("UPDATE Users " & _
                                                   " SET Email = ?, Comment = ?," & _
                                                   " IsApproved = ?" & _
                                                   " WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = user.Email
            cmd.Parameters.Add("@Comment", OdbcType.VarChar, 255).Value = user.Comment
            cmd.Parameters.Add("@IsApproved", OdbcType.Bit).Value = user.IsApproved
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = user.UserName
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


            Try
                conn.Open()

                cmd.ExecuteNonQuery()
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try
        End Sub
        ' - /13>



        '
        ' MembershipProvider.ValidateUser
        '

        ' - 14>
        Public Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean

            Dim isValid As Boolean = False

            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Password, IsApproved FROM Users " & _
                                                     " WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

            Dim reader As OdbcDataReader = Nothing
            Dim isApproved As Boolean = False
            Dim pwd As String = ""

            Try
                conn.Open()

                reader = cmd.ExecuteReader(CommandBehavior.SingleRow)

                If reader.HasRows Then
                    reader.Read()
                    pwd = reader.GetString(0)
                    isApproved = reader.GetBoolean(1)
                End If

                If isApproved AndAlso (password = pwd) Then
                    isValid = True

                    Dim updateCmd As OdbcCommand = New OdbcCommand("UPDATE Users  SET LastLoginDate = ?" & _
                                                                   " WHERE Username = ? AND ApplicationName = ?", conn)

                    updateCmd.Parameters.Add("@LastLoginDate", OdbcType.DateTime).Value = DateTime.Now
                    updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
                    updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

                    updateCmd.ExecuteNonQuery()
                End If
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            Return isValid
        End Function
        ' - /14>


        Public Overrides Function FindUsersByName(ByVal usernameToMatch As String, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer, _
                                                  ByRef totalRecords As Integer) _
                                                  As MembershipUserCollection

            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Count(*) FROM Users  " & _
                                                     "WHERE Username LIKE ? AND ApplicationName = ?", conn)
            cmd.Parameters.Add("@UsernameSearch", OdbcType.VarChar, 255).Value = usernameToMatch
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim users As MembershipUserCollection = New MembershipUserCollection()

            Dim reader As OdbcDataReader = Nothing
            totalRecords = 0

            Try
                conn.Open()
                totalRecords = CType(cmd.ExecuteScalar(), Integer)

                If totalRecords <= 0 Then Return users

                cmd.CommandText = "SELECT Username, Email, PasswordQuestion," & _
                                  " Comment, IsApproved, CreationDate, LastLoginDate," & _
                                  " LastActivityDate, LastPasswordChangedDate " & _
                                  " FROM Users  " & _
                                  " WHERE Username LIKE ? AND ApplicationName = ? " & _
                                  " ORDER BY Username Asc"

                reader = cmd.ExecuteReader()

                Dim counter As Integer = 0
                Dim startIndex As Integer = pageSize * pageIndex
                Dim endIndex As Integer = startIndex + pageSize - 1

                Do While reader.Read()
                    If counter >= startIndex Then
                        Dim u As MembershipUser = GetUserFromReader(reader)
                        users.Add(u)
                    End If

                    If counter >= endIndex Then cmd.Cancel()

                    counter += 1
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            Return users
        End Function

        '<Snippet18>
        Public Overrides Function FindUsersByEmail(ByVal emailToMatch As String, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer, _
                                                   ByRef totalRecords As Integer) _
                                                   As MembershipUserCollection

            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT Count(*) FROM Users  " & _
                                                     "WHERE Email LIKE ? AND ApplicationName = ?", conn)
            cmd.Parameters.Add("@EmailSearch", OdbcType.VarChar, 255).Value = emailToMatch
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

            Dim users As MembershipUserCollection = New MembershipUserCollection()

            Dim reader As OdbcDataReader = Nothing
            totalRecords = 0

            Try
                conn.Open()
                totalRecords = CType(cmd.ExecuteScalar(), Integer)

                If totalRecords <= 0 Then Return users

                cmd.CommandText = "SELECT Username, Email, PasswordQuestion," & _
                                  " Comment, IsApproved, CreationDate, LastLoginDate," & _
                                  " LastActivityDate, LastPasswordChangedDate " & _
                                  " FROM Users  " & _
                                  " WHERE Email LIKE ? AND ApplicationName = ? " & _
                                  " ORDER BY Username Asc"

                reader = cmd.ExecuteReader()

                Dim counter As Integer = 0
                Dim startIndex As Integer = pageSize * pageIndex
                Dim endIndex As Integer = startIndex + pageSize - 1

                Do While reader.Read()
                    If counter >= startIndex Then
                        Dim u As MembershipUser = GetUserFromReader(reader)
                        users.Add(u)
                    End If

                    If counter >= endIndex Then cmd.Cancel()

                    counter += 1
                Loop
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

            Return users
        End Function


        '
        ' GetUserFromReader
        ' A helper function that takes the current row from the OdbcDataReader
        ' and populates a MembershipUser object with the values. Called by the 
        ' MembershipUser.GetUser implementation.
        '

        Public Function GetUserFromReader(ByVal reader As OdbcDataReader) As MembershipUser

            Dim providerUserKey As Object = reader.GetValue(0)
            Dim username As String = reader.GetString(1)
            Dim email As String = reader.GetString(2)

            Dim passwordQuestion As String = ""
            If Not reader.GetValue(3) Is DBNull.Value Then _
              passwordQuestion = reader.GetString(3)

            Dim comment As String = ""
            If Not reader.GetValue(4) Is DBNull.Value Then _
              comment = reader.GetString(4)

            Dim isApproved As Boolean = reader.GetBoolean(5)
            Dim isLockedOut As Boolean = reader.GetBoolean(6)
            Dim creationDate As DateTime = reader.GetDateTime(7)

            Dim lastLoginDate As DateTime = New DateTime()
            If Not reader.GetValue(8) Is DBNull.Value Then _
              lastLoginDate = reader.GetDateTime(8)

            Dim lastActivityDate As DateTime = reader.GetDateTime(9)
            Dim lastPasswordChangedDate As DateTime = reader.GetDateTime(10)

            Dim lastLockedOutDate As DateTime = New DateTime()
            If Not reader.GetValue(11) Is DBNull.Value Then _
              lastLockedOutDate = reader.GetDateTime(11)

            Dim u As MembershipUser = New MembershipUser(Me.Name, _
                                                  username, _
                                                  providerUserKey, _
                                                  email, _
                                                  passwordQuestion, _
                                                  comment, _
                                                  isApproved, _
                                                  isLockedOut, _
                                                  creationDate, _
                                                  lastLoginDate, _
                                                  lastActivityDate, _
                                                  lastPasswordChangedDate, _
                                                  lastLockedOutDate)

            Return u
        End Function
        '</Snippet18>

        '
        ' MembershipProvider.UnlockUser
        '

        Public Overrides Function UnlockUser(ByVal username As String) As Boolean
            Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("UPDATE Users  " & _
                                              " SET IsLockedOut = False, LastLockedOutDate = ? " & _
                                              " WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = DateTime.Now
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

            Dim rowsAffected As Integer = 0

            Try
                conn.Open()

                rowsAffected = cmd.ExecuteNonQuery()
            Catch e As OdbcException
                ' Handle exception.
            Finally
                conn.Close()
            End Try

            If rowsAffected > 0 Then _
              Return True

            Return False
        End Function


'
' MembershipProvider.GetUser(Object, Boolean)
'

Public Overrides Function GetUser(providerUserKey As Object, _
                                  userIsOnline As Boolean) As MembershipUser
    
  Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT PKID, Username, Email, PasswordQuestion," & _
                  " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," & _
                  " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate" & _
                  " FROM Users  WHERE PKID = ?", conn)

            cmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey

            Dim u As MembershipUser = Nothing
            Dim reader As OdbcDataReader = Nothing

            Try
                conn.Open()

                reader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    u = GetUserFromReader(reader)

                    If userIsOnline Then
                        Dim updateCmd As OdbcCommand = New OdbcCommand("UPDATE Users  " & _
                                  "SET LastActivityDate = ? " & _
                                  "WHERE PKID = ?", conn)

                        updateCmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now
                        updateCmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey

                        updateCmd.ExecuteNonQuery()
                    End If
                End If
            Catch e As OdbcException
                ' Handle exception.
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try

  Return u      
End Function


    '
    ' UpdateFailureCount
    '   A helper method that performs the checks and updates associated with
    ' password failure tracking.
    '

    Private Sub UpdateFailureCount(username As String, failureType As String)
    
      Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
            Dim cmd As OdbcCommand = New OdbcCommand("SELECT FailedPasswordAttemptCount, " & _
                                              "  FailedPasswordAttemptWindowStart, " & _
                                              "  FailedPasswordAnswerAttemptCount, " & _
                                              "  FailedPasswordAnswerAttemptWindowStart " & _
                                              "  FROM Users  " & _
                                              "  WHERE Username = ? AND ApplicationName = ?", conn)

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

            Dim reader As OdbcDataReader = Nothing
            Dim windowStart As DateTime = New DateTime()
            Dim failureCount As Integer = 0

            Try
                conn.Open()

                reader = cmd.ExecuteReader(CommandBehavior.SingleRow)

                If reader.HasRows Then
                    reader.Read()

                    If failureType = "password" Then
                        failureCount = reader.GetInt32(0)
                        windowStart = reader.GetDateTime(1)
                    End If

                    If failureType = "passwordAnswer" Then
                        failureCount = reader.GetInt32(2)
                        windowStart = reader.GetDateTime(3)
                    End If
                End If

                reader.Close()

                Dim windowEnd As DateTime = windowStart.AddMinutes(PasswordAttemptWindow)

                If failureCount = 0 OrElse DateTime.Now > windowEnd Then
                    ' First password failure or outside of PasswordAttemptWindow. 
                    ' Start a New password failure count from 1 and a New window starting now.

                    If failureType = "password" Then _
                      cmd.CommandText = "UPDATE Users  " & _
                                        "  SET FailedPasswordAttemptCount = ?, " & _
                                        "      FailedPasswordAttemptWindowStart = ? " & _
                                        "  WHERE Username = ? AND ApplicationName = ?"

                    If failureType = "passwordAnswer" Then _
                      cmd.CommandText = "UPDATE Users  " & _
                                        "  SET FailedPasswordAnswerAttemptCount = ?, " & _
                                        "      FailedPasswordAnswerAttemptWindowStart = ? " & _
                                        "  WHERE Username = ? AND ApplicationName = ?"

                    cmd.Parameters.Clear()

                    cmd.Parameters.Add("@Count", OdbcType.Int).Value = 1
                    cmd.Parameters.Add("@WindowStart", OdbcType.DateTime).Value = DateTime.Now
                    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
                    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

                    If cmd.ExecuteNonQuery() < 0 Then _
                      Throw New Exception("Unable to update failure count and window start.")
                Else
                    failureCount += 1

                    If failureCount >= MaxInvalidPasswordAttempts Then
                        ' Password attempts have exceeded the failure threshold. Lock out
                        ' the user.

                        cmd.CommandText = "UPDATE Users  " & _
                                          "  SET IsLockedOut = ?, LastLockedOutDate = ? " & _
                                          "  WHERE Username = ? AND ApplicationName = ?"

                        cmd.Parameters.Clear()

                        cmd.Parameters.Add("@IsLockedOut", OdbcType.Bit).Value = True
                        cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = DateTime.Now
                        cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
                        cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

                        If cmd.ExecuteNonQuery() < 0 Then _
                          Throw New Exception("Unable to lock out user.")
                    Else
                        ' Password attempts have not exceeded the failure threshold. Update
                        ' the failure counts. Leave the window the same.

                        If failureType = "password" Then _
                          cmd.CommandText = "UPDATE Users  " & _
                                            "  SET FailedPasswordAttemptCount = ?" & _
                                            "  WHERE Username = ? AND ApplicationName = ?"

                        If failureType = "passwordAnswer" Then _
                          cmd.CommandText = "UPDATE Users  " & _
                                            "  SET FailedPasswordAnswerAttemptCount = ?" & _
                                            "  WHERE Username = ? AND ApplicationName = ?"

                        cmd.Parameters.Clear()

                        cmd.Parameters.Add("@Count", OdbcType.Int).Value = failureCount
                        cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
                        cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName

                        If cmd.ExecuteNonQuery() < 0 Then _
                          Throw New Exception("Unable to update failure count.")
                    End If
                End If
            Catch e As OdbcException
                ' Handle Exception
            Finally
                If Not reader Is Nothing Then reader.Close()
                conn.Close()
            End Try
    End Sub


    '
    ' CheckPassword
    '   Compares password values based on the MembershipPasswordFormat.
    '

    Private Function CheckPassword(password As String, dbpassword As String) As Boolean    
      Dim pass1 As String = password
      Dim pass2 As String = dbpassword

      Select Case PasswordFormat      
        Case MembershipPasswordFormat.Encrypted
          pass2 = UnEncodePassword(dbpassword)
        Case MembershipPasswordFormat.Hashed
          pass1 = EncodePassword(password)
        Case Else
      End Select

      If pass1 = pass2 Then     
        Return True
      End If

      Return False
    End Function


    '
    ' EncodePassword
    '   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
    '

    Private Function EncodePassword(password As String) As String
      Dim encodedPassword As String = password

      Select Case PasswordFormat
        Case MembershipPasswordFormat.Clear

        Case MembershipPasswordFormat.Encrypted
          encodedPassword = _
            Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)))
        Case MembershipPasswordFormat.Hashed
          Dim hash As HMACSHA1 = New HMACSHA1()
          hash.Key = HexToByte(machineKey.ValidationKey)
          encodedPassword = _
            Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)))
        Case Else
          Throw New ProviderException("Unsupported password format.")
      End Select

      Return encodedPassword
    End Function


    '
    ' UnEncodePassword
    '   Decrypts or leaves the password clear based on the PasswordFormat.
    '

    Private Function UnEncodePassword(encodedPassword As String) As String
      Dim password As String = encodedPassword

      Select Case PasswordFormat
        Case MembershipPasswordFormat.Clear

        Case MembershipPasswordFormat.Encrypted
          password = _
            Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)))
        Case MembershipPasswordFormat.Hashed
          Throw New ProviderException("Cannot unencode a hashed password.")
        Case Else
          throw new ProviderException("Unsupported password format.")
      End Select

      Return password
    End Function

    '
    ' HexToByte
    '   Converts a hexadecimal string to a byte array. Used to convert encryption
    ' key values from the configuration.
    '

    Private Function HexToByte(hexString As String) As Byte()
      Dim ReturnBytes(hexString.Length \ 2) As Byte
      For i As Integer = 0 To ReturnBytes.Length - 1
        ReturnBytes(i) = Convert.ToByte(hexString.Substring(i*2, 2), 16)
      Next
      Return ReturnBytes
    End Function



  End Class
End Namespace
