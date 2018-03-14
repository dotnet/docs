  Public Class hasDefault
    Default Public ReadOnly Property index(ByVal s As String) As Integer
      Get
        Return 32768 + AscW(s)
      End Get
    End Property
  End Class
  Public Class testHasDefault
    Public Sub compareAccess()
      Dim hD As hasDefault = New hasDefault()
      MsgBox("Traditional access returns " & hD.index("X") & vbCrLf & 
        "Default property access returns " & hD("X") & vbCrLf & 
        "Dictionary access returns " & hD!X)
    End Sub
  End Class