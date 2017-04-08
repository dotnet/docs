Option Strict On
Option Infer On

' <Snippet1>
Imports System.Globalization

Public Module Example
   Public Sub Main()
      Dim str1 As String = "indigo"
      Dim str2, str3 As String
      
      ' str2 is an uppercase copy of str1, using English-United States culture.
      str2 = str1.ToUpper(New CultureInfo("en-US", False))
      
      ' str3 is an uppercase copy of str1, using Turkish-Turkey culture.
      str3 = str1.ToUpper(New CultureInfo("tr-TR", False))
      
      ' Compare the code points and compare the uppercase strings.
      ShowCodePoints("str1", str1)
      ShowCodePoints("str2", str2)
      ShowCodePoints("str3", str3)
      Console.WriteLine("str2 is {0} to str3.", _
                        IIf(String.CompareOrdinal(str2, str3) = 0, "equal", "not equal"))
   End Sub
   
   Public Sub ShowCodePoints(varName As String, s As String)
      Console.Write("{0} = {1}: ", varName, s)
      For Each c In s
         Console.Write("{0:X4} ", AscW(c))
      Next
      Console.WriteLine() 
   End Sub 
End Module
' The example displays the following output:
'       str1 = indigo: 0069 006E 0064 0069 0067 006F
'       str2 = INDIGO: 0049 004E 0044 0049 0047 004F
'       str3 = İNDİGO: 0130 004E 0044 0130 0047 004F
'       str2 is not equal to str3.
' </Snippet1>
