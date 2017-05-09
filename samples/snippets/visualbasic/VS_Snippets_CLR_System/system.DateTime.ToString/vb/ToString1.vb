' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module DateToStringExample
   Public Sub Main()
      Dim currentCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
      Dim exampleDate As Date = #05/01/2008 6:32:06PM#
      
      ' Display the date using the current (en-US) culture.
      Console.WriteLine(exampleDate.ToString())

      ' Change the current culture to fr-FR and display the date.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR")
      Console.WriteLine(exampleDate.ToString())

      ' Change the current culture to ja-JP and display the date.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ja-JP")
      Console.WriteLine(exampleDate.ToString())
      
      ' Restore the original culture
      Thread.CurrentThread.CurrentCulture = currentCulture
   End Sub
End Module
' The example displays the following output to the console:
'       5/1/2008 6:32:06 PM
'       01/05/2008 18:32:06
'       2008/05/01 18:32:06
' </Snippet1>
