  Sub notify(ByVal company As String, Optional ByVal office As String = "QJZ")
      If office = "QJZ" Then
          Debug.WriteLine("office not supplied -- using Headquarters")
          office = "Headquarters"
      End If
      ' Insert code to notify headquarters or specified office.
  End Sub