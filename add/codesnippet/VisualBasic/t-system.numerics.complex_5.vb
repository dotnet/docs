Imports System.Numerics

Public Class ComplexFormatter 
             Implements IFormatProvider, ICustomFormatter
   
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If
   End Function
   
   Public Function Format(fmt As String, arg As Object, 
                          provider As IFormatProvider) As String _
                   Implements ICustomFormatter.Format
      If TypeOf arg Is Complex Then
         Dim c1 As Complex = DirectCast(arg, Complex)
         ' Check if the format string has a precision specifier.
         Dim precision As Integer
         Dim fmtString As String = String.Empty
         If fmt.Length > 1 Then
            Try
               precision = Int32.Parse(fmt.Substring(1))
            Catch e As FormatException
               precision = 0
            End Try
            fmtString = "N" + precision.ToString()
         End If
         If fmt.Substring(0, 1).Equals("I", StringComparison.OrdinalIgnoreCase) Then
            Return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "i"
         ElseIf fmt.Substring(0, 1).Equals("J", StringComparison.OrdinalIgnoreCase) Then
            Return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "j"
         Else
            Return c1.ToString(fmt, provider)
         End If
      Else
         If Typeof arg Is IFormattable Then
            Return DirectCast(arg, IFormattable).ToString(fmt, provider)
         ElseIf arg IsNot Nothing Then
            Return arg.ToString()
         Else
            Return String.Empty
         End If   
      End If                        
   End Function
End Class