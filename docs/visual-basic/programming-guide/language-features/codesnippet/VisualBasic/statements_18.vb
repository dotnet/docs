    cmd.CommandText = 
        "SELECT * FROM Titles JOIN Publishers " &
        "ON Publishers.PubId = Titles.PubID " &
        "WHERE Publishers.State = 'CA'"