    cmd.CommandText = _
        "SELECT * FROM Titles JOIN Publishers " _
        & "ON Publishers.PubId = Titles.PubID " _
        & "WHERE Publishers.State = 'CA'"