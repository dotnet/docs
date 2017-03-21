    Private Function GetMruList(selectedValue As String) As String
       Dim state As StateBag = ViewState
       If state.Count > 0 Then
          Dim upperBound As Integer = state.Count
          Dim keys(upperBound) As String
          Dim values(upperBound) As StateItem
          state.Keys.CopyTo(keys, 0)
          state.Values.CopyTo(values, 0)
          Dim options As New StringBuilder()
          Dim i As Integer
          For i = 0 To upperBound - 1
             options.AppendFormat("<option {0} value={1}>{2}",IIf(selectedValue = keys(i), "selected", ""), keys(i), values(i).Value) 
          Next i
          Return options.ToString()
       End If
       Return ""
    End Function 'GetMruList