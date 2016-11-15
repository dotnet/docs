  Dim firstName, lastName As String
  Property fullName() As String
      Get
        If lastName = "" Then
            Return firstName
        Else
            Return firstName & " " & lastName
        End If

      End Get
      Set(ByVal Value As String)
          Dim space As Integer = Value.IndexOf(" ")
          If space < 0 Then
              firstName = Value
              lastName = ""
          Else
              firstName = Value.Substring(0, space)
              lastName = Value.Substring(space + 1)
          End If
      End Set
  End Property