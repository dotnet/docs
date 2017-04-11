' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
       ' Define a byte array.
       Dim bytes() As Byte = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }
       Console.WriteLine("The byte array: ")
       Console.WriteLine("   {0}", BitConverter.ToString(bytes))
       Console.WriteLine()
       
       ' Convert the array to a base 64 sring.
       Dim s As String = Convert.ToBase64String(bytes)
       Console.WriteLine("The base 64 string:{1}   {0}{1}", 
                         s, vbCrLf)
       
       ' Restore the byte array.
       Dim newBytes() As Byte = Convert.FromBase64String(s)
       Console.WriteLine("The restored byte array: ")
       Console.WriteLine("   {0}", BitConverter.ToString(newBytes))
       Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'     The byte array:
'        02-04-06-08-0A-0C-0E-10-12-14
'     
'     The base 64 string:
'        AgQGCAoMDhASFA==
'     
'     The restored byte array:
'        02-04-06-08-0A-0C-0E-10-12-14
' </Snippet1>
