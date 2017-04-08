' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim current As CultureInfo = CultureInfo.CurrentCulture
      Console.WriteLine("The current culture is {0}", current.Name)
      Dim newCulture As CultureInfo
      If current.Name.Equals("fr-FR") Then
         newCulture = New CultureInfo("fr-LU")
      Else   
         newCulture = new CultureInfo("fr-FR")
      End If
      
      CultureInfo.CurrentCulture = newCulture
      Console.WriteLine("The current culture is now {0}", 
                        CultureInfo.CurrentCulture.Name)   
   End Sub
End Module
' The example displays output like the following:
'     The current culture is en-US
'     The current culture is now fr-FR
' </Snippet3>

