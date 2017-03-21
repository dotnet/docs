Public Sub AddOracleParameters()
    ' ...
    ' create dataSet and adapter
    ' ...
adapter.SelectCommand.Parameters.Add("pEName", OracleType.VarChar, 80).Value = "Smith"
adapter.SelectCommand.Parameters.Add("pEmpNo", OracleType.Int32).Value = 7369
adapter.Fill(dataSet)
End Sub 