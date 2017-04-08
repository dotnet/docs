'<snippet1>
' Sample for String.ToLower(CultureInfo)
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Class Sample
   Public Shared Sub Main()
      Dim str1 As [String] = "INDIGO"
      ' str2 = str1, except each 'I' is '\u0130' (Unicode LATIN CAPITAL I WITH DOT ABOVE).
      Dim str2 As New [String](New [Char]() {ChrW(&H0130), "N"c, "D"c, ChrW(&H0130), "G"c, "O"c})
      Dim str3, str4 As [String]

      Console.WriteLine()
      Console.WriteLine("str1 = '{0}'", str1)

      Console.WriteLine()
      Console.WriteLine("str1 is {0} to str2.", _
                         IIf(0 = [String].CompareOrdinal(str1, str2), "equal", "not equal"))
      CodePoints("str1", str1)
      CodePoints("str2", str2)

      Console.WriteLine()
      ' str3 is a lower case copy of str2, using English-United States culture.
      Console.WriteLine("str3 = Lower case copy of str2 using English-United States culture.")
      str3 = str2.ToLower(New CultureInfo("en-US", False))

      ' str4 is a lower case copy of str2, using Turkish-Turkey culture.
      Console.WriteLine("str4 = Lower case copy of str2 using Turkish-Turkey culture.")
      str4 = str2.ToLower(New CultureInfo("tr-TR", False))

      ' Compare the code points in str3 and str4.
      Console.WriteLine()
      Console.WriteLine("str3 is {0} to str4.", _
                         IIf(0 = [String].CompareOrdinal(str3, str4), "equal", "not equal"))
      CodePoints("str3", str3)
      CodePoints("str4", str4)
   End Sub 'Main

   Public Shared Sub CodePoints(title As [String], s As [String])
      Console.Write("{0}The code points in {1} are: {0}", Environment.NewLine, title)
      Dim c As Char
      For Each c In  s
         Console.Write("{0:x4} ", AscW(c))
      Next c
      Console.WriteLine()
   End Sub 'CodePoints
End Class 'Sample
'
'str1 = 'INDIGO'
'
'str1 is not equal to str2.
'
'The code points in str1 are:
'0049 004e 0044 0049 0047 004f
'
'The code points in str2 are:
'0130 004e 0044 0130 0047 004f
'
'str3 = Lower case copy of str2 using English-United States culture.
'str4 = Lower case copy of str2 using Turkish-Turkey culture.
'
'str3 is equal to str4.
'
'The code points in str3 are:
'0069 006e 0064 0069 0067 006f
'
'The code points in str4 are:
'0069 006e 0064 0069 0067 006f
'</snippet1>