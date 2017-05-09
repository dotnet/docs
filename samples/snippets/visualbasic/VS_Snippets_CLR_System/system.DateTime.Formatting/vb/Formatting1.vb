' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   Public Sub Main()
      ShowDefaultToString()
      ShowCultureSpecificToString()
      ShowDefaultFullDateAndTime()
      ShowCultureSpecificFullDateAndTime()
   End Sub
   
   Private Sub ShowDefaultToString()
      ' <Snippet1>
      Dim date1 As Date = #3/1/2008 7:00AM#
      Console.WriteLine(date1.ToString())
      ' For en-US culture, displays 3/1/2008 7:00:00 AM
      ' </Snippet1>
   End Sub
   
   Private Sub ShowCultureSpecificToString()
      ' <Snippet2>
      Dim date1 As Date = #3/1/2008 7:00AM#
      Console.WriteLine(date1.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")))
      ' Displays 01/03/2008 07:00:00
      ' </Snippet2>
   End Sub   
   
   Private Sub ShowDefaultFullDateAndTime()
      ' <Snippet3>
      Dim date1 As Date = #3/1/2008 7:00AM#
      Console.WriteLine(date1.ToString("F"))
      ' Displays Saturday, March 01, 2008 7:00:00 AM
      ' </Snippet3>
   End Sub
   
   Private Sub ShowCultureSpecificFullDateAndTime()
      ' <Snippet4>
      Dim date1 As Date = #3/1/2008 7:00AM#
      Console.WriteLine(date1.ToString("F", New System.Globalization.CultureInfo("fr-FR")))
      ' Displays samedi 1 mars 2008 07:00:00
      ' </Snippet4>
   End Sub
End Module


