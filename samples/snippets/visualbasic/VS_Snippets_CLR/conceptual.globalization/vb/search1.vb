' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL")
      Dim composite As String = ChrW(&h0041) + ChrW(&H0300) 
      Console.WriteLine("Comparing using Char:   {0}", composite.IndexOf(ChrW(&h00C0)))
      Console.WriteLine("Comparing using String: {0}", composite.IndexOf(ChrW(&h00C0).ToString()))
   End Sub 
End Module
' The example displays the following output:
'       Comparing using Char:   -1
'       Comparing using String: 0
' </Snippet18>
