Public Class Temperature 
   Private temp As Decimal
   
   Public Sub New(temperature As Decimal)
      Me.temp = temperature
   End Sub
   
   Public Overrides Function ToString() As String
      Return ToString("C")
   End Function
   
   Public Overloads Function ToString(format As String) As String
      If String.IsNullOrEmpty(format) Then format = "G"
      
      Select Case format
         Case "G", "C"
            Return temp.ToString("N") + "  °C"
         Case "F"
            Return (9 * temp / 5 + 32).ToString("N") + "  °F"
         Case "K" 
            Return (temp + 273.15d).ToString("N") + "  °K" 
         Case Else
            Throw New FormatException(String.Format("The '{0}' format specifier is not supported", _
                                                    format))
      End Select                                                         
   End Function         
   
   Public Sub Display(<[ParamArray]()> formats() As String)
      If formats.Length = 0 Then
         Console.WriteLine(Me.ToString("G"))
      Else   
         For Each format As String In formats
            Try
               Console.WriteLine(Me.ToString(format))
            ' If there is an exception, do nothing.
            Catch
            End Try   
         Next
      End If
   End Sub
End Class