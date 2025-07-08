---
description: "Learn more about REF CURSOR parameters in an OracleDataReader by studying an example that executes a PL/SQL stored procedure."
title: "REF CURSOR Parameters in an OracleDataReader"
ms.date: "03/30/2017"
dev_langs:
  - "vb"
---
# REF CURSOR Parameters in an OracleDataReader

This Visual Basic example executes a PL/SQL stored procedure that returns a REF CURSOR parameter and reads the value as an <xref:System.Data.OracleClient.OracleDataReader>.

```vb
Private Sub Button1_Click(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles Button1.Click

  Dim connString As New String("...")
  Using conn As New OracleConnection(connString)
    Dim cmd As New OracleCommand()
    Dim rdr As OracleDataReader

    conn.Open()
    cmd.Connection = conn
    cmd.CommandText = "CURSPKG.OPEN_ONE_CURSOR"
    cmd.CommandType = CommandType.StoredProcedure
    cmd.Parameters.Add(New OracleParameter(
      "N_EMPNO", OracleType.Number)).Value = 7369
    cmd.Parameters.Add(New OracleParameter(
      "IO_CURSOR", OracleType.Cursor)).Direction = ParameterDirection.Output

    rdr = cmd.ExecuteReader()
    While (rdr.Read())
        REM do something with the values
    End While

    rdr.Close()
  End Using
End Sub
```

## See also

- [Oracle REF CURSORs](oracle-ref-cursors.md)
- [ADO.NET Overview](ado-net-overview.md)
