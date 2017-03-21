        ' Initialize is used to initialize the properties and any state that the
        ' AccessProvider holds, but is not used to build the site map.
        ' The site map is built when the BuildSiteMap method is called.
        Public Overrides Sub Initialize(ByVal name As String, ByVal attributes As NameValueCollection)
            If IsInitialized Then
                Return
            End If
            MyBase.Initialize(name, attributes)

            ' Create and test the connection to the Microsoft Access database.
            ' Retrieve the Value of the Access connection string from the
            ' attributes NameValueCollection.
            Dim connectionString As String = attributes(AccessConnectionStringName)

            If Nothing = connectionString OrElse connectionString.Length = 0 Then
                Throw New Exception("The connection string was not found.")
            Else
                accessConnection = New OleDbConnection(connectionString)
            End If
            initialized = True
        End Sub 'Initialize