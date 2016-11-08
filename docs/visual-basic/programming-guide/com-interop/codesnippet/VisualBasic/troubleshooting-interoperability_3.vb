    ' Class level variable.
    Shared DBEngine As New DAO.DBEngine

    Sub DAOOpenRecordset()
        Dim db As DAO.Database
        Dim rst As DAO.Recordset
        Dim fld As DAO.Field
        ' Open the database.
        db = DBEngine.OpenDatabase("C:\nwind.mdb")

        ' Open the Recordset.
        rst = db.OpenRecordset(
            "SELECT * FROM Customers WHERE Region = 'WA'",
            DAO.RecordsetTypeEnum.dbOpenForwardOnly,
            DAO.RecordsetOptionEnum.dbReadOnly)
        ' Print the values for the fields in the debug window.
        For Each fld In rst.Fields
            Debug.WriteLine(fld.Value.ToString & ";")
        Next
        Debug.WriteLine("")
        ' Close the Recordset.
        rst.Close()
    End Sub