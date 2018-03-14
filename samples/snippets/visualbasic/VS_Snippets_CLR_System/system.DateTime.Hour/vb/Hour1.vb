' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      ' <Snippet1>
      Dim date1 As Date = #04/01/2008 6:53:00PM#
      Console.WriteLine(date1.ToString("%h"))      ' Displays 6
      Console.WriteLine(date1.ToString("h tt"))    ' Displays 6 PM
      ' </Snippet1>
   End Sub
End Module

