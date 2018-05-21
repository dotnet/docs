  Public Sub setJobString(ByVal g As Integer)
      Dim title As String
      Dim jobTitle As System.Data.SqlTypes.SqlString
      Select Case g
          Case 1
              title = "President"
          Case 2
              title = "Vice President"
          Case 3
              title = "Director"
          Case 4
              title = "Manager"
          Case Else
              title = "Worker"
      End Select
      jobTitle = CType(title, SqlString)
      MsgBox("Group " & CStr(g) & " generates title """ &
            CType(jobTitle, String) & """")
  End Sub