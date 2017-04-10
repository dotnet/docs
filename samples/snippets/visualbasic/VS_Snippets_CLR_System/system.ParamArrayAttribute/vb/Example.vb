' <Snippet1>
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
' </Snippet1>

' <Snippet2>
Public Module Example
   Public Sub Main()
      Dim temp1 As New Temperature(100)
      Dim formats() As String = { "C", "G", "F", "K" } 

      ' Call Display method with a string array.
      Console.WriteLine("Calling Display with a string array:")
      temp1.Display(formats)
      Console.WriteLine()
      
      ' Call Display method with individual string arguments.
      Console.WriteLine("Calling Display with individual arguments:")
      temp1.Display("C", "F", "K", "G")
      Console.WriteLine()
      
      ' Call parameterless Display method.
      Console.WriteLine("Calling Display with an implicit parameter array:")
      temp1.Display()
   End Sub
End Module
' The example displays the following output:
'       Calling Display with a string array:
'       100.00  °C
'       100.00  °C
'       212.00  °F
'       373.15  °K
'       
'       Calling Display with individual arguments:
'       100.00  °C
'       212.00  °F
'       373.15  °K
'       100.00  °C
'       
'       Calling Display with an implicit parameter array:
'       100.00  °C
' </Snippet2>
