        ' Add the connection string.
        Dim csSection _
        As ConnectionStringsSection = _
        config.ConnectionStrings
        csSection.ConnectionStrings.Add( _
        New ConnectionStringSettings(csName, _
        "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" _
        + "Initial Catalog=aspnetdb", "System.Data.SqlClient"))