' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim s As String = "AaBbCcDd"
      Dim chars() = s.ToCharArray()
      Console.WriteLine("Original string: {0}", s)
      Console.WriteLine("Character array:")
      For ctr = 0 to chars.Length - 1
         Console.WriteLine("   {0}: {1}", ctr, chars(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'     Original string: AaBbCcDd
'     Character array:
'        0: A
'        1: a
'        2: B
'        3: b
'        4: C
'        5: c
'        6: D
'        7: d
' </Snippet1>
