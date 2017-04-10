' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      ' Change the current culture if the language is not French.
      Dim current As CultureInfo = Thread.CurrentThread.CurrentUICulture
      If current.TwoLetterISOLanguageName <> "fr" Then
         Dim newCulture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
         Thread.CurrentThread.CurrentUICulture = newCulture
         ' Make current UI culture consistent with current culture.
         Thread.CurrentThread.CurrentCulture = newCulture
      End If
      Console.WriteLine("The current UI culture is {0} [{1}]",
                        Thread.CurrentThread.CurrentUICulture.NativeName,
                        Thread.CurrentThread.CurrentUICulture.Name)
      Console.WriteLine("The current culture is {0} [{1}]",
                        Thread.CurrentThread.CurrentUICulture.NativeName,
                        Thread.CurrentThread.CurrentUICulture.Name)
   End Sub
End Module
' The example displays output like the following:
'     The current UI culture is English (United States) [en-US]
'     The current culture is English (United States) [en-US]
' </Snippet1>
