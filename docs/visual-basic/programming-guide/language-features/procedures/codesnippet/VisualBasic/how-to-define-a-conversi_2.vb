  Public Sub consumeDigit()
      Dim d1 As New digit(4)
      Dim d2 As New digit(7)
      Dim d3 As digit = CType(CByte(3), digit)
      Dim s As String = "Initial 4 generates " & CStr(CType(d1, Byte)) &
            vbCrLf & "Initial 7 generates " & CStr(CType(d2, Byte)) &
            vbCrLf & "Converted 3 generates " & CStr(CType(d3, Byte))
      Try
          Dim d4 As digit
          d4 = CType(CType(d1, Byte) + CType(d2, Byte), digit)
      Catch e4 As System.Exception
          s &= vbCrLf & "4 + 7 generates " & """" & e4.Message & """"
      End Try
      Try
          Dim d5 As digit = CType(CByte(10), digit)
      Catch e5 As System.Exception
          s &= vbCrLf & "Initial 10 generates " & """" & e5.Message & """"
      End Try
      MsgBox(s)
  End Sub