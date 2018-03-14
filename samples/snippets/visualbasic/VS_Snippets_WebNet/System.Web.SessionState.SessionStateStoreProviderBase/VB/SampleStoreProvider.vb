'<Snippet1>
Imports System
Imports System.Web
Imports System.Web.Configuration
Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Web.SessionState
Imports System.Data
Imports System.Data.Odbc
Imports System.Diagnostics
Imports System.IO


' This session state store provider supports the following schema:
' 
'   CREATE TABLE Sessions
'   (
'     SessionId       Text(80)  NOT NULL,
'     ApplicationName Text(255) NOT NULL,
'     Created         DateTime  NOT NULL,
'     Expires         DateTime  NOT NULL,
'     LockDate        DateTime  NOT NULL,
'     LockId          Integer   NOT NULL,
'     Timeout         Integer   NOT NULL,
'     Locked          YesNo     NOT NULL,
'     SessionItems    Memo,
'     Flags           Integer   NOT NULL,
'       CONSTRAINT PKSessions PRIMARY KEY (SessionId, ApplicationName)
'   )
' 
' This session state store provider does not automatically clean up 
' expired session item data. It is recommended
' that you periodically delete expired session information from the
' data store with the following code (where 'conn' is the OdbcConnection
' for the session state store provider):
' 
'   Dim commandString As String = "DELETE FROM Sessions WHERE Expires < ?"
'   Dim conn As OdbcConnection = New OdbcConnection(connectionString)
'   Dim cmd As OdbcCommand = New OdbcCommand(commandString, conn)
'   cmd.Parameters.Add("@Expires", OdbcType.DateTime).Value = DateTime.Now
'   conn.Open()
'   cmd.ExecuteNonQuery()
'   conn.Close()


Namespace Samples.AspNet.Session

  Public NotInheritable Class OdbcSessionStateStore
    Inherits SessionStateStoreProviderBase

    Private pConfig As SessionStateSection = Nothing
    Private connectionString As String
    Private pConnectionStringSettings As ConnectionStringSettings 
    Private eventSource As String = "OdbcSessionStateStore"
    Private eventLog As String = "Application"
    Private exceptionMessage As String = _
      "An exception occurred. Please contact your administrator."
    Private pApplicationName As String


    '
    ' If False, exceptions are thrown to the caller. If True,
    ' exceptions are written to the event log.
    '

    Private pWriteExceptionsToEventLog As Boolean = False

    Public Property WriteExceptionsToEventLog As Boolean
      Get
        Return pWriteExceptionsToEventLog
      End Get
      Set
        pWriteExceptionsToEventLog = value
      End Set
    End Property


    '
    ' The ApplicationName property is used to differentiate sessions
    ' in the data source by application.
    '

    Public ReadOnly Property ApplicationName As String
      Get
        Return pApplicationName
      End Get
    End Property


    '
    ' ProviderBase members
    '


    Public Overrides Sub Initialize(name As String, config As NameValueCollection)

      '
      ' Initialize values from web.config.
      '

      If config Is Nothing Then _
        Throw New ArgumentNullException("config")

      If name Is Nothing OrElse name.Length = 0 Then _
        name = "OdbcSessionStateStore"

      If String.IsNullOrEmpty(config("description")) Then
        config.Remove("description")
        config.Add("description", "Sample ODBC Session State Store provider")
      End If

      ' Initialize the abstract base class.
      MyBase.Initialize(name, config)


      '
      ' Initialize the ApplicationName property.
      '

      pApplicationName = _
        System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath


      '
      ' Get <sessionState> configuration element.
      '
    
      Dim cfg As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration(ApplicationName)
      pConfig = _
        CType(cfg.GetSection("system.web/sessionState"), SessionStateSection)

      
      '
      ' Initialize OdbcConnection.
      '

      pConnectionStringSettings = _
        ConfigurationManager.ConnectionStrings(config("connectionStringName"))

      If pConnectionStringSettings Is Nothing OrElse _
        pConnectionStringSettings.ConnectionString.Trim() = "" Then
      
        Throw New HttpException("Connection string cannot be blank.")
      End If

      connectionString = pConnectionStringSettings.ConnectionString


      '
      ' Initialize WriteExceptionsToEventLog
      '

      pWriteExceptionsToEventLog = False

      If Not config("writeExceptionsToEventLog") Is Nothing Then      
        If config("writeExceptionsToEventLog").ToUpper() = "TRUE" Then _
          pWriteExceptionsToEventLog = True
      End If
    End Sub


    '
    ' SessionStateStoreProviderBase members
    '

    Public Overrides Sub Dispose()
    
    End Sub


    '
    ' SessionStateProviderBase.SetItemExpireCallback
    '

    Public Overrides Function SetItemExpireCallback( _
      expireCallback As SessionStateItemExpireCallback) As Boolean
    
      Return False
    End Function


    '
    ' SessionStateProviderBase.SetAndReleaseItemExclusive
    '

    Public Overrides Sub SetAndReleaseItemExclusive(context As HttpContext, _
      id As String, _
      item As SessionStateStoreData, _
      lockId As Object, _
      newItem As Boolean)                                           
    
      ' Serialize the SessionStateItemCollection as a string.
      Dim sessItems As String = Serialize(CType(item.Items, SessionStateItemCollection))

      Dim conn As OdbcConnection = New OdbcConnection(connectionString)
      Dim cmd As OdbcCommand
      Dim deleteCmd As OdbcCommand = Nothing

      If newItem Then      
        ' OdbcCommand to clear an existing expired session if it exists.
        deleteCmd = New OdbcCommand("DELETE FROM Sessions " & _
          "WHERE SessionId = ? AND ApplicationName = ? AND Expires < ?", conn)
        deleteCmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
        deleteCmd.Parameters.Add( _
          "@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
        deleteCmd.Parameters.Add( _
          "@Expires", OdbcType.DateTime).Value = DateTime.Now

        ' OdbcCommand to insert the New session item.
        cmd = New OdbcCommand("INSERT INTO Sessions " & _
          " (SessionId, ApplicationName, Created, Expires, " & _
          "  LockDate, LockId, Timeout, Locked, SessionItems, Flags) " & _
          " Values(?, ?, ?, ?, ?, ? , ?, ?, ?, ?)", conn)
        cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
        cmd.Parameters.Add( _
          "@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
        cmd.Parameters.Add( _
          "@Created", OdbcType.DateTime).Value = DateTime.Now
        cmd.Parameters.Add( _
          "@Expires", OdbcType.DateTime).Value = DateTime.Now.AddMinutes(CDbl(item.Timeout))
        cmd.Parameters.Add( _
          "@LockDate", OdbcType.DateTime).Value = DateTime.Now
        cmd.Parameters.Add("@LockId", OdbcType.Int).Value = 0
        cmd.Parameters.Add( _
          "@Timeout", OdbcType.Int).Value = item.Timeout
        cmd.Parameters.Add("@Locked", OdbcType.Bit).Value = False
        cmd.Parameters.Add( _
          "@SessionItems", OdbcType.VarChar, sessItems.Length).Value = sessItems
        cmd.Parameters.Add("@Flags", OdbcType.Int).Value = 0
      Else
      
        ' OdbcCommand to update the existing session item.
        cmd = New OdbcCommand( _
          "UPDATE Sessions SET Expires = ?, SessionItems = ?, Locked = ? " & _
          " WHERE SessionId = ? AND ApplicationName = ? AND LockId = ?", conn)
        cmd.Parameters.Add("@Expires", OdbcType.DateTime).Value = _
          DateTime.Now.AddMinutes(CDbl(item.Timeout))
        cmd.Parameters.Add("@SessionItems", _
          OdbcType.VarChar, sessItems.Length).Value = sessItems
        cmd.Parameters.Add("@Locked", OdbcType.Bit).Value = False
        cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
        cmd.Parameters.Add( _
          "@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName
        cmd.Parameters.Add("@LockId", OdbcType.Int).Value = lockId
      End If

      Try
        conn.Open()

        If Not deleteCmd Is Nothing Then _
          deleteCmd.ExecuteNonQuery()

        cmd.ExecuteNonQuery()
      Catch e As OdbcException
        If WriteExceptionsToEventLog Then
          WriteToEventLog(e, "SetAndReleaseItemExclusive")
          Throw New Exception(exceptionMessage)
        Else
          Throw e
        End If
      Finally
        conn.Close()
      End Try
    End Sub


    '
    ' SessionStateProviderBase.GetItem
    '

    Public Overrides Function GetItem(context As HttpContext, _
      id As String, _
      ByRef locked As Boolean, _
      ByRef lockAge As TimeSpan, _
      ByRef lockId As Object, _
      ByRef actionFlags As SessionStateActions) _
      As SessionStateStoreData 
    
      Return GetSessionStoreItem(False, context, id, locked, lockAge, lockId, actionFlags)
    End Function


    '
    ' SessionStateProviderBase.GetItemExclusive
    '

    Public Overrides Function GetItemExclusive(context As HttpContext, _
      id As String, _
      ByRef locked As Boolean, _
      ByRef lockAge As TimeSpan, _
      ByRef lockId As Object, _
      ByRef actionFlags As SessionStateActions) _
      As SessionStateStoreData 
    
      Return GetSessionStoreItem(True, context, id, locked, lockAge, lockId, actionFlags)
    End Function


    '
    ' GetSessionStoreItem is called by both the GetItem and 
    ' GetItemExclusive methods. GetSessionStoreItem retrieves the 
    ' session data from the data source. If the lockRecord parameter
    ' is True (in the case of GetItemExclusive), then GetSessionStoreItem
    ' locks the record and sets a New LockId and LockDate.
    '

    Private Function GetSessionStoreItem(lockRecord As Boolean, _
      context As HttpContext,  _
      id As String, _
      ByRef locked As Boolean, _
      ByRef lockAge As TimeSpan, _
      ByRef lockId As Object, _
      ByRef actionFlags As SessionStateActions) _
      As SessionStateStoreData 
    
      ' Initial values for Return value and out parameters.
      Dim item As SessionStateStoreData = Nothing
      lockAge = TimeSpan.Zero
      lockId = Nothing
      locked = False
      actionFlags = 0

      ' Connection to ODBC database.
      Dim conn As OdbcConnection = New OdbcConnection(connectionString)
      ' OdbcCommand for database commands.
      Dim cmd As OdbcCommand = Nothing              
      ' DataReader to read database record.
      Dim reader As OdbcDataReader = Nothing  
      ' DateTime to check if current session item is expired.
      Dim expires As DateTime         
      ' String to hold serialized SessionStateItemCollection.
      Dim serializedItems As String = ""
      ' True if a record is found in the database.
      Dim foundRecord As Boolean = False    
      ' True if the returned session item is expired and needs to be deleted.
      Dim deleteData As Boolean = False             
      ' Timeout value from the data store.
      Dim timeout As Integer = 0               

      Try
        conn.Open()

        ' lockRecord is True when called from GetItemExclusive and
        ' False when called from GetItem.
        ' Obtain a lock if possible. Ignore the record if it is expired.
        If lockRecord Then        
          cmd = New OdbcCommand( _
            "UPDATE Sessions SET" & _
            " Locked = ?, LockDate = ? " & _
            " WHERE SessionId = ? AND ApplicationName = ? AND Locked = ? AND Expires > ?", conn)
          cmd.Parameters.Add("@Locked", OdbcType.Bit).Value = True
          cmd.Parameters.Add("@LockDate", OdbcType.DateTime).Value = _
            DateTime.Now
          cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
          cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, _
            255).Value = ApplicationName
          cmd.Parameters.Add("@Locked", OdbcType.Int).Value = False
          cmd.Parameters.Add( _
            "@Expires", OdbcType.DateTime).Value = DateTime.Now

          If cmd.ExecuteNonQuery() = 0 Then
            ' No record was updated because the record was locked or not found.
            locked = True             
          Else
            ' The record was updated.
            locked = False
          End If
        End If

        ' Retrieve the current session item information.
        cmd = New OdbcCommand( _
          "SELECT Expires, SessionItems, LockId, LockDate, Flags, Timeout " & _
          "  FROM Sessions " & _
          "  WHERE SessionId = ? AND ApplicationName = ?", conn)
        cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
        cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, _
          255).Value = ApplicationName

        ' Retrieve session item data from the data source.
        reader = cmd.ExecuteReader(CommandBehavior.SingleRow)

        Do While reader.Read()        
          expires = reader.GetDateTime(0)

          If expires < DateTime.Now Then          
            ' The record was expired. Mark it as not locked.
            locked = False     
            ' The session was expired. Mark the data for deletion.
            deleteData = True
          Else
            foundRecord = True
          End If

          serializedItems = reader.GetString(1)
          lockId = reader.GetInt32(2)
          lockAge = DateTime.Now.Subtract(reader.GetDateTime(3))
          actionFlags = CType(reader.GetInt32(4), SessionStateActions)
          timeout = reader.GetInt32(5)
        Loop

        reader.Close()


        ' If the returned session item is expired, 
        ' delete the record from the data source.
        If deleteData Then        
          cmd = New OdbcCommand("DELETE FROM Sessions " & _
            "WHERE SessionId = ? AND ApplicationName = ?", conn)
          cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
          cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, _
            255).Value = ApplicationName

          cmd.ExecuteNonQuery()
        End If

        ' The record was not found. Ensure that locked is False.
        If Not foundRecord Then _
          locked = False
        
        ' If the record was found and you obtained a lock, then set 
        ' the lockId, clear the actionFlags,
        ' and create the SessionStateStoreItem to return.
        If foundRecord AndAlso Not locked Then        
          lockId = CInt(lockId) + 1

          cmd = New OdbcCommand("UPDATE Sessions SET" & _
            " LockId = ?, Flags = 0 " & _
            " WHERE SessionId = ? AND ApplicationName = ?", conn)
          cmd.Parameters.Add("@LockId", OdbcType.Int).Value = lockId
          cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
          cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName

          cmd.ExecuteNonQuery()

          ' If the actionFlags parameter is not InitializeItem, 
          ' deserialize the stored SessionStateItemCollection.
          If actionFlags = SessionStateActions.InitializeItem Then
            item = CreateNewStoreData(context, pConfig.Timeout.TotalMinutes)
          Else
            item = Deserialize(context, serializedItems, timeout)
          End If
        End If
      Catch e As OdbcException
        If WriteExceptionsToEventLog Then
          WriteToEventLog(e, "GetSessionStoreItem")
          Throw New Exception(exceptionMessage)
        Else
          Throw e
        End If
      Finally
        If Not reader Is Nothing Then reader.Close()
        conn.Close()
      End Try

      Return item
    End Function




    '
    ' Serialize is called by the SetAndReleaseItemExclusive method to 
    ' convert the SessionStateItemCollection into a Base64 string to    
    ' be stored in an Access Memo field.
    '

    Private Function Serialize(items As SessionStateItemCollection) As String
      Dim ms As MemoryStream = New MemoryStream()
      Dim writer As BinaryWriter = New BinaryWriter(ms)

      If Not items Is Nothing Then _
        items.Serialize(writer)

      writer.Close()

      Return Convert.ToBase64String(ms.ToArray())
    End Function

    '
    ' Deserialize is called by the GetSessionStoreItem method to 
    ' convert the Base64 string stored in the Access Memo field to a 
    ' SessionStateItemCollection.
    '

    Private Function Deserialize(context As HttpContext, _
      serializedItems As String, timeout As Integer) As SessionStateStoreData
    
      Dim ms As MemoryStream = _
        New MemoryStream(Convert.FromBase64String(serializedItems))

      Dim sessionItems As SessionStateItemCollection = _
        New SessionStateItemCollection()

      If ms.Length > 0 Then
        Dim reader As BinaryReader = New BinaryReader(ms)
        sessionItems = SessionStateItemCollection.Deserialize(reader)
      End If

      Return New SessionStateStoreData(sessionItems, _
        SessionStateUtility.GetSessionStaticObjects(context), _
        timeout)
    End Function

    '
    ' SessionStateProviderBase.ReleaseItemExclusive
    '

    Public Overrides Sub ReleaseItemExclusive(context As HttpContext, _
      id As String, _
      lockId As Object)
    
      Dim conn As OdbcConnection = New OdbcConnection(connectionString)
      Dim cmd As OdbcCommand = _
        New OdbcCommand("UPDATE Sessions SET Locked = 0, Expires = ? " & _
        "WHERE SessionId = ? AND ApplicationName = ? AND LockId = ?", conn)
      cmd.Parameters.Add("@Expires", OdbcType.DateTime).Value = _
        DateTime.Now.AddMinutes(pConfig.Timeout.TotalMinutes)
      cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
      cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, _
        255).Value = ApplicationName
      cmd.Parameters.Add("@LockId", OdbcType.Int).Value = lockId

      Try
        conn.Open()

        cmd.ExecuteNonQuery()
      Catch e As OdbcException
        If WriteExceptionsToEventLog Then
          WriteToEventLog(e, "ReleaseItemExclusive")
          Throw New Exception(exceptionMessage)
        Else
          Throw e
        End If
      Finally
        conn.Close()
      End Try    
    End Sub


    '
    ' SessionStateProviderBase.RemoveItem
    '

    Public Overrides Sub RemoveItem(context As HttpContext, _
      id As String, _
      lockId As Object, _
      item As SessionStateStoreData)
    
      Dim conn As OdbcConnection = New OdbcConnection(connectionString)
      Dim cmd As OdbcCommand = New OdbcCommand("DELETE * FROM Sessions " & _
        "WHERE SessionId = ? AND ApplicationName = ? AND LockId = ?", conn)
      cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
      cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, _
        255).Value = ApplicationName
      cmd.Parameters.Add("@LockId", OdbcType.Int).Value = lockId

      Try
        conn.Open()

        cmd.ExecuteNonQuery()
      Catch e As OdbcException
        If WriteExceptionsToEventLog Then
          WriteToEventLog(e, "RemoveItem")
          Throw New Exception(exceptionMessage)
        Else
          Throw e
        End If
      Finally
        conn.Close()
      End Try
    End Sub



    '
    ' SessionStateProviderBase.CreateUninitializedItem
    '

    Public Overrides Sub CreateUninitializedItem(context As HttpContext, _
      id As String, _
      timeout As Integer)
    
      Dim conn As OdbcConnection = New OdbcConnection(connectionString)
      Dim cmd As OdbcCommand = New OdbcCommand("INSERT INTO Sessions " & _
         " (SessionId, ApplicationName, Created, Expires, " & _
         "  LockDate, LockId, Timeout, Locked, SessionItems, Flags) " & _
         " Values(?, ?, ?, ?, ?, ? , ?, ?, ?, ?)", conn)
      cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
      cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, _
        255).Value = ApplicationName
      cmd.Parameters.Add("@Created", OdbcType.DateTime).Value = _
        DateTime.Now
      cmd.Parameters.Add("@Expires", OdbcType.DateTime).Value = _
        DateTime.Now.AddMinutes(CDbl(timeout))
      cmd.Parameters.Add("@LockDate", OdbcType.DateTime).Value = _
        DateTime.Now
      cmd.Parameters.Add("@LockId", OdbcType.Int).Value = 0
      cmd.Parameters.Add("@Timeout", OdbcType.Int).Value = timeout
      cmd.Parameters.Add("@Locked", OdbcType.Bit).Value = False
      cmd.Parameters.Add("@SessionItems", OdbcType.VarChar, 0).Value = ""
      cmd.Parameters.Add("@Flags", OdbcType.Int).Value = 1

      Try
        conn.Open()

        cmd.ExecuteNonQuery()
      Catch e As OdbcException
        If WriteExceptionsToEventLog Then
          WriteToEventLog(e, "CreateUninitializedItem")
          Throw New Exception(exceptionMessage)
        Else
          Throw e
        End If
      Finally
        conn.Close()
      End Try
    End Sub


    '
    ' SessionStateProviderBase.CreateNewStoreData
    '

    Public Overrides Function CreateNewStoreData( _
      context As HttpContext, _
      timeout As Double) As SessionStateStoreData
    
      Return New SessionStateStoreData(New SessionStateItemCollection(), _
        SessionStateUtility.GetSessionStaticObjects(context), _
        timeout)
    End Function



    '
    ' SessionStateProviderBase.ResetItemTimeout
    '

    Public Overrides Sub ResetItemTimeout(context As HttpContext, _
                                          id As String)    
      Dim conn As OdbcConnection = New OdbcConnection(connectionString)
      Dim cmd As OdbcCommand = _
        New OdbcCommand("UPDATE Sessions SET Expires = ? " & _
        "WHERE SessionId = ? AND ApplicationName = ?", conn)
      cmd.Parameters.Add("@Expires", OdbcType.DateTime).Value = _
        DateTime.Now.AddMinutes(pConfig.Timeout.TotalMinutes)
      cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id
      cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, _
        255).Value = ApplicationName

      Try
        conn.Open()

        cmd.ExecuteNonQuery()
      Catch e As OdbcException
        If WriteExceptionsToEventLog Then
          WriteToEventLog(e, "ResetItemTimeout")
          Throw New Exception(exceptionMessage)
        Else
          Throw e
        End If
      Finally
        conn.Close()
      End Try
    End Sub


    '
    ' SessionStateProviderBase.InitializeRequest
    '

    Public Overrides Sub InitializeRequest(context As HttpContext)
    
    End Sub


    '
    ' SessionStateProviderBase.EndRequest
    '

    Public Overrides Sub EndRequest(context As HttpContext)
    
    End Sub


    '
    ' WriteToEventLog
    ' This is a helper function that writes exception detail to the 
    ' event log. Exceptions are written to the event log as a security
    ' measure to ensure Private database details are not returned to 
    ' browser. If a method does not Return a status or Boolean
    ' indicating the action succeeded or failed, the caller also 
    ' throws a generic exception.
    '

    Private Sub WriteToEventLog(e As Exception, action As String) 
      Dim log As EventLog = New EventLog()
      log.Source = eventSource
      log.Log = eventLog

      Dim message As String =  _
        "An exception occurred communicating with the data source." & vbCrLf & vbCrLf
      message &= "Action: " & action & vbCrLf & vbCrLf
      message &= "Exception: " & e.ToString()

      log.WriteEntry(message)
    End Sub
  End Class
End Namespace
'</Snippet1>
