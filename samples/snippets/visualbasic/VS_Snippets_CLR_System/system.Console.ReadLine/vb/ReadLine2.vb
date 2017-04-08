' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim line As String
      Console.WriteLine("Enter one or more lines of text (press CTRL+Z to exit):")
      Console.WriteLine()
      Do 
         Console.Write("   ")
         line = Console.ReadLine()
         If line IsNot Nothing Then Console.WriteLine("      " + line)
      Loop While line IsNot Nothing   
   End Sub
End Module
' The following displays possible output from this example:
'       Enter one or more lines of text (press CTRL+Z to exit):
'       
'          This is line #1.
'             This is line #1.
'          This is line #2
'             This is line #2
'          ^Z
'       
'       >
' </Snippet1>
