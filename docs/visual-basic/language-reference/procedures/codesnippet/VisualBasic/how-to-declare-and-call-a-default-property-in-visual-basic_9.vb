  Sub Test()
      Dim x As New class1(3)
      x(1) = "Hello"
      x(2) = " "
      x(3) = "World"
      MsgBox(x(1) & x(2) & x(3))
  End Sub