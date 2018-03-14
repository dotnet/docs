'<Snippet9>
Imports System.Web.Profile
Imports System.Configuration.Provider
Imports System.Collections.Specialized
Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Configuration
Imports System.Diagnostics
Imports System.Web
Imports System.Collections
Imports Microsoft.VisualBasic

'
'
' This provider works with the following schema for the table of user data.
' 
' CREATE TABLE Profiles
' (
'   UniqueID AutoIncrement NOT NULL PRIMARY KEY,
'   Username Text (255) NOT NULL,
'   ApplicationName Text (255) NOT NULL,
'   IsAnonymous YesNo, 
'   LastActivityDate DateTime,
'   LastUpdatedDate DateTime,
'     CONSTRAINT PKProfiles UNIQUE (Username, ApplicationName)
' )
' 
' CREATE TABLE StockSymbols
' (
'   UniqueID Integer,
'   StockSymbol Text (10),
'     CONSTRAINT FKProfiles1 FOREIGN KEY (UniqueID)
'       REFERENCES Profiles
' )
' 
' CREATE TABLE ProfileData
' (
'   UniqueID Integer,
'   ZipCode Text (10),
'     CONSTRAINT FKProfiles2 FOREIGN KEY (UniqueID)
'       REFERENCES Profiles
' )
' 
' 


Namespace Samples.AspNet.Profile

 Public NotInheritable Class OdbcProfileProvider
  Inherits ProfileProvider
  
  '
  ' Global connection string, generic exception message, event log info.
  '

  Private eventSource As String = "OdbcProfileProvider"
  Private eventLog As String = "Application"
  Private exceptionMessage As String = "An exception occurred. Please check the event log."
  Private connectionString As String


  '
  ' If false, exceptions are thrown to the caller. If true,
  ' exceptions are written to the event log.
  '

  Private pWriteExceptionsToEventLog As Boolean

  Public Property WriteExceptionsToEventLog As Boolean
    Get
      Return pWriteExceptionsToEventLog
    End Get
    Set
      pWriteExceptionsToEventLog = value
    End Set
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
      name = "OdbcProfileProvider"

    If String.IsNullOrEmpty(config("description")) Then
      config.Remove("description")
      config.Add("description", "Sample ODBC Profile provider")
    End If

    ' Initialize the abstract base class.
    MyBase.Initialize(name, config)


    If config("applicationName") Is Nothing OrElse config("applicationName").Trim() = "" Then
      pApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath
    Else
      pApplicationName = config("applicationName")
    End If


    '
    ' Initialize connection string.
    '

    Dim pConnectionStringSettings As ConnectionStringSettings = _
      ConfigurationManager.ConnectionStrings(config("connectionStringName"))

    If pConnectionStringSettings Is Nothing OrElse _
        pConnectionStringSettings.ConnectionString.Trim() = "" _
    Then
      Throw New ProviderException("Connection String cannot be blank.")
    End If

    connectionString = pConnectionStringSettings.ConnectionString
  End Sub


  '
  ' System.Configuration.SettingsProvider.ApplicationName
  '

  Private pApplicationName As String

  Public Overrides Property ApplicationName As String  
    Get
      Return pApplicationName
    End Get
    Set
      pApplicationName = value
    End Set
  End Property



  '
  ' System.Configuration.SettingsProvider methods.
  '

  '
  ' SettingsProvider.GetPropertyValues
  '

  Public Overrides Function GetPropertyValues(context As SettingsContext, _
                ppc As SettingsPropertyCollection) _
                As SettingsPropertyValueCollection

    ' The serializeAs attribute is ignored in this provider implementation.
   
    Dim username As String = CType(context("UserName"), String)
    Dim isAuthenticated As Boolean = CType(context("IsAuthenticated"), Boolean)

    Dim svc As SettingsPropertyValueCollection = New SettingsPropertyValueCollection()

    For Each prop As SettingsProperty In ppc    
      Dim pv As SettingsPropertyValue = New SettingsPropertyValue(prop)

      Select Case prop.Name      
        Case "StockSymbols"
          pv.PropertyValue = GetStockSymbols(username, isAuthenticated)
        Case "ZipCode"
          pv.PropertyValue = GetZipCode(username, isAuthenticated)
        Case Else
          Throw New ProviderException("Unsupported property.")
      End Select

      svc.Add(pv)
    Next

    UpdateActivityDates(username, isAuthenticated, True)

    Return svc

  End Function



  '
  ' SettingsProvider.SetPropertyValues
  '

  Public Overrides Sub SetPropertyValues(context As SettingsContext, _
                 ppvc As SettingsPropertyValueCollection)

    ' The serializeAs attribute is ignored in this provider implementation.
  
    Dim username As String = CType(context("UserName"), String)
    Dim isAuthenticated As Boolean = CType(context("IsAuthenticated"), Boolean)

    Dim uniqueID As Integer = GetUniqueID(username, isAuthenticated, False)
    If uniqueID = 0 Then uniqueID = CreateProfileForUser(username, isAuthenticated)

    For Each pv As SettingsPropertyValue In ppvc    
      Select Case pv.Property.Name      
        Case "StockSymbols"
          SetStockSymbols(uniqueID, CType(pv.PropertyValue, ArrayList))
        Case "ZipCode"
          SetZipCode(uniqueID, CType(pv.PropertyValue, String))
        Case Else
          Throw New ProviderException("Unsupported property.")
      End Select
    Next

    UpdateActivityDates(username, isAuthenticated, False)
  End Sub


  '
  ' UpdateActivityDates
  '   Updates LastActivityDate and LastUpdatedDate when profile properties are accessed
  ' by GetPropertyValues and SetPropertyValues. Specifying activityOnly as true will update
  ' only the LastActivityDate.
  '

  Private Sub UpdateActivityDates(username As String, isAuthenticated As Boolean, activityOnly As Boolean)
  
    Dim activityDate As DateTime = DateTime.Now

    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    Dim cmd As OdbcCommand = New OdbcCommand()
    cmd.Connection = conn

    If activityOnly Then    
      cmd.CommandText = "UPDATE Profiles Set LastActivityDate = ? " & _
            "WHERE Username = ? AND ApplicationName = ? AND IsAnonymous = ?"
      cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = activityDate
      cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
      cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
      cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = Not isAuthenticated
    Else
      cmd.CommandText = "UPDATE Profiles Set LastActivityDate = ?, LastUpdatedDate = ? " & _
            "WHERE Username = ? AND ApplicationName = ? AND IsAnonymous = ?"
      cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = activityDate
      cmd.Parameters.Add("@LastUpdatedDate", OdbcType.DateTime).Value = activityDate
      cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
      cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
      cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = Not isAuthenticated
    End If

    Try
      conn.Open()

      cmd.ExecuteNonQuery()
    Catch e As OdbcException
      If WriteExceptionsToEventLog Then
        WriteToEventLog(e, "UpdateActivityDates")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      conn.Close()
    End Try
  End Sub


  '
  ' GetStockSymbols
  ' Retrieves stock symbols from the database during the 
  ' call to GetPropertyValues.
  '

  Private Function GetStockSymbols(username As String, isAuthenticated As Boolean) As ArrayList
  
   Dim conn As OdbcConnection = New OdbcConnection(connectionString)
   Dim cmd As OdbcCommand = New OdbcCommand("SELECT StockSymbol FROM Profiles " & _
        "INNER JOIN StockSymbols ON Profiles.UniqueID = StockSymbols.UniqueID " & _
        "WHERE Username = ? AND ApplicationName = ? And IsAnonymous = ?", conn)
    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
    cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = Not isAuthenticated

    Dim outList As ArrayList = New ArrayList()

    Dim reader As OdbcDataReader = Nothing

    Try
      conn.Open()

      reader = cmd.ExecuteReader()

      Do While reader.Read()      
          outList.Add(reader.GetString(0))
      Loop
    Catch e As OdbcException
      If WriteExceptionsToEventLog Then      
        WriteToEventLog(e, "GetStockSymbols")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
          If Not reader Is Nothing Then reader.Close()

      conn.Close()
    End Try

    Return outList
  End Function



  '
  ' SetStockSymbols
  ' Inserts stock symbol values into the database during 
  ' the call to SetPropertyValues.
  '

  Private Sub SetStockSymbols(uniqueID As Integer, stocks As ArrayList)
    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    Dim cmd As OdbcCommand = New OdbcCommand("DELETE FROM StockSymbols WHERE UniqueID = ?", conn)
    cmd.Parameters.Add("@UniqueID", OdbcType.Int).Value = uniqueID

    Dim cmd2 As OdbcCommand =  New OdbcCommand("INSERT INTO StockSymbols (UniqueID, StockSymbol) " & _
                       "Values(?, ?)", conn)
    cmd2.Parameters.Add("@UniqueID", OdbcType.Int).Value = uniqueID
    cmd2.Parameters.Add("@StockSymbol", OdbcType.VarChar, 10)

    Dim tran As OdbcTransaction = Nothing

    Try
      conn.Open()
      tran = conn.BeginTransaction()
      cmd.Transaction = tran
      cmd2.Transaction = tran

      ' Delete any existing values.
      cmd.ExecuteNonQuery()

      For Each o As Object In Stocks
        cmd2.Parameters("@StockSymbol").Value = o.ToString()
        cmd2.ExecuteNonQuery()
      Next

      tran.Commit()
    Catch e As OdbcException
      Try
        tran.Rollback()
      Catch
      End Try

      If WriteExceptionsToEventLog Then
        WriteToEventLog(e, "SetStockSymbols")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      conn.Close()
    End Try
  End Sub


  '
  ' GetZipCode
  ' Retrieves ZipCode value from the database during 
  ' the call to GetPropertyValues.
  '

  Private Function GetZipCode(username As String, isAuthenticated As Boolean) As String
  
    Dim zipCode As String = ""

    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    Dim cmd As OdbcCommand = New OdbcCommand("SELECT ZipCode FROM Profiles " & _
          "INNER JOIN ProfileData ON Profiles.UniqueID = ProfileData.UniqueID " & _
          "WHERE Username = ? AND ApplicationName = ? And IsAnonymous = ?", conn)
    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
    cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = Not isAuthenticated

    Try
      conn.Open()
      
      zipCode = CType(cmd.ExecuteScalar(), String)
    Catch e As OdbcException
      If WriteExceptionsToEventLog Then
        WriteToEventLog(e, "GetZipCode")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      conn.Close()
    End Try

    Return zipCode
  End Function


  '
  ' SetZipCode
  ' Inserts the zip code value into the database during 
  ' the call to SetPropertyValues.
  '

  Private Sub SetZipCode(uniqueID As Integer, zipCode As String)
    If zipCode Is Nothing Then zipCode = String.Empty

    Dim conn As OdbcConnection = New OdbcConnection(connectionString)

    Dim cmd As OdbcCommand = New OdbcCommand("DELETE FROM ProfileData WHERE UniqueID = ?", conn)
    cmd.Parameters.Add("@UniqueID", OdbcType.Int).Value = uniqueID

    Dim cmd2 As OdbcCommand= New OdbcCommand("INSERT INTO ProfileData (UniqueID, ZipCode) " & _
                  "Values(?, ?)", conn)
    cmd2.Parameters.Add("@UniqueID", OdbcType.Int).Value = uniqueID
    cmd2.Parameters.Add("@ZipCode", OdbcType.VarChar, 10).Value = zipCode

    Dim tran As OdbcTransaction = Nothing

    Try
      conn.Open()
      tran = conn.BeginTransaction()
      cmd.Transaction = tran
      cmd2.Transaction = tran
      
      ' Delete any existing values.
      cmd.ExecuteNonQuery()
      cmd2.ExecuteNonQuery()

      tran.Commit()
    Catch e As OdbcException
      Try
        tran.Rollback()
      Catch
      End Try

      If WriteExceptionsToEventLog Then
        WriteToEventLog(e, "SetZipCode")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      conn.Close()
    End Try
  End Sub


  '
  ' GetUniqueID
  ' Retrieves the uniqueID from the database for 
  ' the current user and application.
  '

  Private Function GetUniqueID(username As String, isAuthenticated As Boolean, _
          ignoreAuthenticationType As Boolean) As Integer
  
    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    Dim cmd As OdbcCommand = New OdbcCommand("SELECT UniqueID FROM Profiles " & _
            "WHERE Username = ? AND ApplicationName = ?", conn)
    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

    If Not ignoreAuthenticationType Then
      cmd.CommandText &= " AND IsAnonymous = ?"
      cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = Not isAuthenticated
    End If

    Dim uniqueID As Integer = 0
    Dim reader As OdbcDataReader = Nothing

    Try
      conn.Open()

      reader = cmd.ExecuteReader(CommandBehavior.SingleRow)
      If reader.HasRows Then _
        uniqueID = reader.GetInt32(0)
    Catch e As OdbcException
      If WriteExceptionsToEventLog Then      
        WriteToEventLog(e, "GetUniqueID")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      If reader IsNot Nothing Then reader.Close()
      conn.Close()
    End Try

    Return uniqueID
  End Function


  '
  ' CreateProfileForUser
  ' If no user currently exists in the database, 
  ' a user record is created during the call to the 
  ' GetUniqueID Private method.
  '

  Private Function CreateProfileForUser(username As String, isAuthenticated As Boolean) As Integer
    ' Check for valid user name.

    If username Is Nothing Then _
      Throw New ArgumentNullException("username")
    If username.Length > 255 Then _
      Throw New ArgumentException("User name exceeds 255 characters.")
    If username.Contains(",") Then _
      Throw New ArgumentException("User name cannot contain a comma (,).")


    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    Dim cmd As OdbcCommand = New OdbcCommand("INSERT INTO Profiles (Username, " & _
            "ApplicationName, LastActivityDate, LastUpdatedDate, "  & _
            "IsAnonymous) Values(?, ?, ?, ?, ?)", conn)
    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username
    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
    cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now
    cmd.Parameters.Add("@LastUpdatedDate", OdbcType.VarChar).Value = DateTime.Now
    cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = Not isAuthenticated

    Dim cmd2 As OdbcCommand = New OdbcCommand("SELECT @@IDENTITY", conn)

    Dim uniqueID As Integer = 0

    Try
      conn.Open()

      cmd.ExecuteNonQuery()

      uniqueID = CType(cmd2.ExecuteScalar(), Integer)
    Catch e As OdbcException
      If WriteExceptionsToEventLog Then      
        WriteToEventLog(e, "CreateProfileForUser")
        Throw New HttpException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      conn.Close()
    End Try

    Return uniqueID
  End Function


  '
  ' ProfileProvider.DeleteProfiles(ProfileInfoCollection)
  '

  Public Overrides Function DeleteProfiles(profiles As ProfileInfoCollection) As Integer
    Dim deleteCount As Integer = 0

    Dim conn As OdbcConnection  = New OdbcConnection(connectionString)
    Dim tran As OdbcTransaction = Nothing

    Try
      conn.Open()
      tran = conn.BeginTransaction()
    
      For Each p As ProfileInfo In profiles    
        If DeleteProfile(p.UserName, conn, tran) Then deleteCount += 1
      Next

      tran.Commit()
    Catch e As Exception
      Try
        tran.Rollback()
      Catch
      End Try

      If WriteExceptionsToEventLog Then
        WriteToEventLog(e, "DeleteProfiles(String())")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      conn.Close()
    End Try

    Return deleteCount
  End Function


  '
  ' ProfileProvider.DeleteProfiles(string())
  '

  Public Overrides Function DeleteProfiles(usernames As String()) As Integer
    Dim deleteCount As Integer = 0

    Dim conn As OdbcConnection  = New OdbcConnection(connectionString)
    Dim tran As OdbcTransaction = Nothing

    Try
      conn.Open()
      tran = conn.BeginTransaction()
    
      For Each user As String In usernames
        If (DeleteProfile(user, conn, tran)) Then deleteCount += 1
      Next

      tran.Commit()
    Catch e As Exception
      Try
        tran.Rollback()
      Catch
      End Try

      If WriteExceptionsToEventLog Then
        WriteToEventLog(e, "DeleteProfiles(String())")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      conn.Close()
    End Try

    Return deleteCount
  End Function



  '
  ' ProfileProvider.DeleteInactiveProfiles
  '

  Public Overrides Function DeleteInactiveProfiles( _
    authenticationOption As ProfileAuthenticationOption, _
    userInactiveSinceDate As DateTime) As Integer
  
    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    Dim cmd As OdbcCommand = New OdbcCommand("SELECT Username FROM Profiles " & _
            "WHERE ApplicationName = ? AND " & _
            " LastActivityDate <= ?", conn)
    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
    cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = userInactiveSinceDate

    Select Case authenticationOption    
      Case ProfileAuthenticationOption.Anonymous
        cmd.CommandText &= " AND IsAnonymous = ?"
        cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = True
      Case ProfileAuthenticationOption.Authenticated
        cmd.CommandText &= " AND IsAnonymous = ?"
        cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = False
    End Select

    Dim reader As OdbcDataReader = Nothing
    Dim usernames As String = ""

    Try
      conn.Open()

      reader = cmd.ExecuteReader()

      Do While reader.Read()      
        usernames &= reader.GetString(0) + ","
      Loop
    Catch e As OdbcException
      If WriteExceptionsToEventLog Then      
        WriteToEventLog(e, "DeleteInactiveProfiles")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      If Not reader Is Nothing Then reader.Close()

      conn.Close()
    End Try

    If usernames.Length > 0 Then    
      ' Remove trailing comma.
      usernames = usernames.Substring(0, usernames.Length - 1)
    End If


    ' Delete profiles.
    Return DeleteProfiles(usernames.Split(CChar(",")))
  End Function


  '
  '
  ' DeleteProfile
  ' Deletes profile data from the database for the specified user name. Expects an OdbcConnection and 
  ' an OdbcTransaction as it supports deleting multiple profiles in a transaction.
  '

  Private Function DeleteProfile(username As String, conn As OdbcConnection, tran As OdbcTransaction) As Boolean
    ' Check for valid user name.
    If username Is Nothing Then _
      Throw New ArgumentNullException("username")
    If username.Length > 255 Then _
      Throw New ArgumentException("User name exceeds 255 characters.")
    If username.Contains(",") Then _
      Throw New ArgumentException("User name cannot contain a comma (,).")

    Dim uniqueID As Integer = GetUniqueID(username, False, True)

    Dim cmd1 As OdbcCommand = New OdbcCommand("DELETE * FROM ProfileData WHERE UniqueID = ?", conn)
    cmd1.Parameters.Add("@UniqueID", OdbcType.Int).Value = uniqueID
    Dim cmd2 As OdbcCommand = New OdbcCommand("DELETE * FROM StockSymbols WHERE UniqueID = ?", conn)
    cmd2.Parameters.Add("@UniqueID", OdbcType.Int).Value = uniqueID
    Dim cmd3 As OdbcCommand = New OdbcCommand("DELETE * FROM Profiles WHERE UniqueID = ?", conn)
    cmd3.Parameters.Add("@UniqueID", OdbcType.Int).Value = uniqueID

    cmd1.Transaction = tran
    cmd2.Transaction = tran
    cmd3.Transaction = tran

    Dim numDeleted As Integer = 0

    ' Exceptions will be caught by the calling method.
    numDeleted += cmd1.ExecuteNonQuery()
    numDeleted += cmd2.ExecuteNonQuery()
    numDeleted += cmd3.ExecuteNonQuery()

    If numDeleted = 0 Then
      Return False
    Else
      Return True
    End If
  End Function


  '
  ' ProfileProvider.FindProfilesByUserName
  '

  Public Overrides Function FindProfilesByUserName( _
    authenticationOption As ProfileAuthenticationOption, _
    usernameToMatch As String, _
    pageIndex As Integer, _
    pageSize As Integer, _
    ByRef totalRecords As Integer) As ProfileInfoCollection
  
    CheckParameters(pageIndex, pageSize)

    Return GetProfileInfo(authenticationOption, usernameToMatch, Nothing, _ 
          pageIndex, pageSize, totalRecords)
  End Function


  '
  ' ProfileProvider.FindInactiveProfilesByUserName
  '

  Public Overrides Function FindInactiveProfilesByUserName( _
    authenticationOption As ProfileAuthenticationOption, _
    usernameToMatch As String, _
    userInactiveSinceDate As DateTime, _
    pageIndex As Integer, _
    pageSize As Integer, _
    ByRef totalRecords As Integer) As ProfileInfoCollection
  
    CheckParameters(pageIndex, pageSize)

    Return GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate, _
          pageIndex, pageSize, totalRecords)
  End Function


  '
  ' ProfileProvider.GetAllProfiles
  '

  Public Overrides Function GetAllProfiles( _
    authenticationOption As ProfileAuthenticationOption, _
    pageIndex As Integer, _
    pageSize As Integer, _
    ByRef totalRecords As Integer) As ProfileInfoCollection
  
    CheckParameters(pageIndex, pageSize)

    Return GetProfileInfo(authenticationOption, Nothing, Nothing, _
          pageIndex, pageSize, totalRecords)
  End Function


  '
  ' ProfileProvider.GetAllInactiveProfiles
  '

  Public Overrides Function GetAllInactiveProfiles( _
    authenticationOption As ProfileAuthenticationOption, _
    userInactiveSinceDate As DateTime, _
    pageIndex As Integer, _
    pageSize As Integer, _
    ByRef totalRecords As Integer) As ProfileInfoCollection
  
    CheckParameters(pageIndex, pageSize)

    Return GetProfileInfo(authenticationOption, Nothing, userInactiveSinceDate, _ 
          pageIndex, pageSize, totalRecords)
  End Function



  '
  ' ProfileProvider.GetNumberOfInactiveProfiles
  '

  Public Overrides Function GetNumberOfInactiveProfiles( _
    authenticationOption As ProfileAuthenticationOption, _
    userInactiveSinceDate As DateTime) As Integer
  
    Dim inactiveProfiles As Integer = 0

    Dim profiles As ProfileInfoCollection =  _
      GetProfileInfo(authenticationOption, Nothing, userInactiveSinceDate, _
          0, 0, inactiveProfiles)

    Return inactiveProfiles
  End Function



  '
  ' CheckParameters
  ' Verifies input parameters for page size and page index. 
  ' Called by GetAllProfiles, GetAllInactiveProfiles, 
  ' FindProfilesByUserName, and FindInactiveProfilesByUserName.
  '

  Private Sub CheckParameters(pageIndex As Integer, pageSize As Integer)
    If pageIndex < 0 Then _
      Throw New ArgumentException("Page index must 0 or greater.")
    If pageSize < 1 Then _
      Throw New ArgumentException("Page size must be greater than 0.")
  End Sub


  '
  ' GetProfileInfo
  ' Retrieves a count of profiles and creates a 
  ' ProfileInfoCollection from the profile data in the database. 
  ' Called by GetAllProfiles, GetAllInactiveProfiles,
  ' FindProfilesByUserName, FindInactiveProfilesByUserName, 
  ' and GetNumberOfInactiveProfiles.
  ' Specifying a pageIndex of 0 retrieves a count of the results only.
  '

  Private Function GetProfileInfo( _
    authenticationOption As ProfileAuthenticationOption, _
    usernameToMatch As String, _
    userInactiveSinceDate As Object, _
    pageIndex As Integer, _
    pageSize As Integer, _
    ByRef totalRecords As Integer) As ProfileInfoCollection
  
    Dim conn As OdbcConnection = New OdbcConnection(connectionString)

    ' Command to retrieve the total count.

    Dim cmd As OdbcCommand = New OdbcCommand("SELECT COUNT(*) FROM Profiles WHERE ApplicationName = ? ", conn)
    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


    ' Command to retrieve the profile data.

    Dim cmd2 As OdbcCommand = New OdbcCommand("SELECT Username, LastActivityDate, LastUpdatedDate, " & _
            "IsAnonymous FROM Profiles WHERE ApplicationName = ? ", conn)
    cmd2.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName


    ' If searching for a user name to match, 
    ' add the command text and parameters.

    If Not usernameToMatch Is Nothing Then    
      cmd.CommandText &= " AND Username LIKE ? "
      cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = usernameToMatch
      
      cmd2.CommandText &= " AND Username LIKE ? "
      cmd2.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = usernameToMatch
    End If


    ' If searching for inactive profiles, 
    ' add the command text and parameters.

    If Not userInactiveSinceDate Is Nothing Then
      cmd.CommandText &= " AND LastActivityDate <= ? "
      cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = _
          CType(userInactiveSinceDate, DateTime)
      
      cmd2.CommandText &= " AND LastActivityDate <= ? "
      cmd2.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = _
          CType(userInactiveSinceDate, DateTime)
    End If


    ' If searching for a anonymous or authenticated profiles, add the command text 
    ' and parameters.

    Select Case authenticationOption    
      Case ProfileAuthenticationOption.Anonymous
        cmd.CommandText &= " AND IsAnonymous = ?"
        cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = True
        cmd2.CommandText &= " AND IsAnonymous = ?"
        cmd2.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = True
      Case ProfileAuthenticationOption.Authenticated
        cmd.CommandText &= " AND IsAnonymous = ?"
        cmd.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = False
        cmd2.CommandText &= " AND IsAnonymous = ?"
        cmd2.Parameters.Add("@IsAnonymous", OdbcType.Bit).Value = False
    End Select


    ' Get the data.

    Dim reader As OdbcDataReader = Nothing
    Dim profiles As ProfileInfoCollection = New ProfileInfoCollection()

    Try
      conn.Open()
      ' Get the profile count.
      totalRecords = CType(cmd.ExecuteScalar(), Integer) 
      ' No profiles found.
      If totalRecords <= 0 Then Return profiles
      ' Count profiles only.
      If pageSize = 0 Then Return profiles


      reader = cmd2.ExecuteReader()

      Dim counter As Integer = 0
      Dim startIndex As Integer = pageSize * (pageIndex - 1)
      Dim endIndex As Integer = startIndex + pageSize - 1

      Do While reader.Read()      
        If counter >= startIndex Then        
          Dim p As ProfileInfo = GetProfileInfoFromReader(reader)
          profiles.Add(p)
        End If

        If counter >= endIndex Then cmd.Cancel()

        counter += 1
      Loop
    Catch e As OdbcException
      If WriteExceptionsToEventLog Then
        WriteToEventLog(e, "GetProfileInfo")
        Throw New ProviderException(exceptionMessage)
      Else
        Throw e
      End If
    Finally
      If Not reader Is Nothing Then reader.Close()

      conn.Close()
    End Try

    Return profiles
  End Function

  '
  ' GetProfileInfoFromReader
  ' Takes the current row from the OdbcDataReader
  ' and populates a ProfileInfo object from the values. 
  '

  Private Function GetProfileInfoFromReader(reader As OdbcDataReader) As ProfileInfo 
  
    Dim username As String = reader.GetString(0)

    Dim lastActivityDate As DateTime = New DateTime()
    If Not reader.GetValue(1) Is DBNull.Value Then _
      lastActivityDate = reader.GetDateTime(1)

    Dim lastUpdatedDate As DateTime = New DateTime()
    If Not reader.GetValue(2) Is DBNull.Value Then _
      lastUpdatedDate = reader.GetDateTime(2)

    Dim isAnonymous As Boolean = reader.GetBoolean(3)
      
    ' ProfileInfo.Size not currently implemented.
    Dim p As ProfileInfo = New ProfileInfo(username, _
        isAnonymous,lastActivityDate,lastUpdatedDate, 0)

    Return p
  End Function


  '
  ' WriteToEventLog
  ' A helper function that writes exception detail to the
  ' event log. Exceptions are written to the event log as
  ' a security measure to prevent Private database details 
  ' from being returned to the browser. If a method does not 
  ' return a status or Boolean value indicating whether the action 
  ' succeeded or failed, the caller also throws a generic exception.
  '

  Private Sub WriteToEventLog(e As Exception, action As String)
  
    Dim log As EventLog = New EventLog()
    log.Source = eventSource
    log.Log = eventLog

    Dim message As String = "An exception occurred communicating with the data source." & vbCrLf & vbCrLf
    message &= "Action: " & action & vbCrLf & vbCrLf
    message &= "Exception: " & e.ToString()

    log.WriteEnTry(message)
  End Sub
 End Class
End Namespace
'</Snippet9>
