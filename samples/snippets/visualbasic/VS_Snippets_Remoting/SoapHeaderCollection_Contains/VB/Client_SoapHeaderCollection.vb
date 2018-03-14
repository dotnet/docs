' This program is used as a client of the client proxy class. 

Imports System
Imports MicroSoft.VisualBasic

Public Class Client
   Public Shared Sub Main()
      Dim myService As New MathService()
      Console.WriteLine(ControlChars.NewLine + "The sum of 10 and 10 is : {0}", _
                                       myService.Add(10, 10).ToString())
   End Sub 'Main
End Class 'Client