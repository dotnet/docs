' Visual Basic .NET Document
Option Strict On

Public Class CustomFormatter : Implements IFormatProvider, ICustomFormatter
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      Return Me
   End Function
   
   Public Function Format(fmt As String, arg As Object, formatProvider As IFormatProvider) As String _
                   Implements ICustomFormatter.Format
      Dim s As String = String.Empty
      
      ' <Snippet1>
      If TypeOf(arg) Is IFormattable Then 
         s = DirectCast(arg, IFormattable).ToString(fmt, formatProvider)
      ElseIf arg IsNot Nothing Then    
         s = arg.ToString()
      End If
      ' </Snippet1>
      Return s      
   End Function
End Class

   

