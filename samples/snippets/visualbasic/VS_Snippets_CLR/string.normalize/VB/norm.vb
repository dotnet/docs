'<snippet1>
Imports System.Text

Class Example
   Public Shared Sub Main()
      ' Character c; combining characters acute and cedilla; character 3/4
      Dim s1 = New [String](New Char() {ChrW(&H0063), ChrW(&H0301), ChrW(&H0327), ChrW(&H00BE)})
      Dim s2 As String = Nothing
      Dim divider = New [String]("-"c, 80)
      divider = [String].Concat(Environment.NewLine, divider, Environment.NewLine)
      
      Show("s1", s1)
      Console.WriteLine()
      Console.WriteLine("U+0063 = LATIN SMALL LETTER C")
      Console.WriteLine("U+0301 = COMBINING ACUTE ACCENT")
      Console.WriteLine("U+0327 = COMBINING CEDILLA")
      Console.WriteLine("U+00BE = VULGAR FRACTION THREE QUARTERS")

      Console.WriteLine(divider)
      
      Console.WriteLine("A1) Is s1 normalized to the default form (Form C)?: {0}", s1.IsNormalized())
      Console.WriteLine("A2) Is s1 normalized to Form C?:  {0}", s1.IsNormalized(NormalizationForm.FormC))
      Console.WriteLine("A3) Is s1 normalized to Form D?:  {0}", s1.IsNormalized(NormalizationForm.FormD))
      Console.WriteLine("A4) Is s1 normalized to Form KC?: {0}", s1.IsNormalized(NormalizationForm.FormKC))
      Console.WriteLine("A5) Is s1 normalized to Form KD?: {0}", s1.IsNormalized(NormalizationForm.FormKD))
      
      Console.WriteLine(divider)
      
      Console.WriteLine("Set string s2 to each normalized form of string s1.")
      Console.WriteLine()
      Console.WriteLine("U+1E09 = LATIN SMALL LETTER C WITH CEDILLA AND ACUTE")
      Console.WriteLine("U+0033 = DIGIT THREE")
      Console.WriteLine("U+2044 = FRACTION SLASH")
      Console.WriteLine("U+0034 = DIGIT FOUR")
      Console.WriteLine(divider)
      
      s2 = s1.Normalize()
      Console.Write("B1) Is s2 normalized to the default form (Form C)?: ")
      Console.WriteLine(s2.IsNormalized())
      Show("s2", s2)
      Console.WriteLine()
      
      s2 = s1.Normalize(NormalizationForm.FormC)
      Console.Write("B2) Is s2 normalized to Form C?: ")
      Console.WriteLine(s2.IsNormalized(NormalizationForm.FormC))
      Show("s2", s2)
      Console.WriteLine()
      
      s2 = s1.Normalize(NormalizationForm.FormD)
      Console.Write("B3) Is s2 normalized to Form D?: ")
      Console.WriteLine(s2.IsNormalized(NormalizationForm.FormD))
      Show("s2", s2)
      Console.WriteLine()
      
      s2 = s1.Normalize(NormalizationForm.FormKC)
      Console.Write("B4) Is s2 normalized to Form KC?: ")
      Console.WriteLine(s2.IsNormalized(NormalizationForm.FormKC))
      Show("s2", s2)
      Console.WriteLine()
      
      s2 = s1.Normalize(NormalizationForm.FormKD)
      Console.Write("B5) Is s2 normalized to Form KD?: ")
      Console.WriteLine(s2.IsNormalized(NormalizationForm.FormKD))
      Show("s2", s2)
      Console.WriteLine()
   End Sub 
   
   Private Shared Sub Show(title As String, s As String)
      Console.Write("Characters in string {0} = ", title)
      For Each x As Char In s
         Console.Write("{0:X4} ", AscW(x))
      Next 
      Console.WriteLine()
   End Sub 
End Class 
'This example produces the following results:
'
'Characters in string s1 = 0063 0301 0327 00BE
'
'U+0063 = LATIN SMALL LETTER C
'U+0301 = COMBINING ACUTE ACCENT
'U+0327 = COMBINING CEDILLA
'U+00BE = VULGAR FRACTION THREE QUARTERS
'
'--------------------------------------------------------------------------------
'
'A1) Is s1 normalized to the default form (Form C)?: False
'A2) Is s1 normalized to Form C?:  False
'A3) Is s1 normalized to Form D?:  False
'A4) Is s1 normalized to Form KC?: False
'A5) Is s1 normalized to Form KD?: False
'
'--------------------------------------------------------------------------------
'
'Set string s2 to each normalized form of string s1.
'
'U+1E09 = LATIN SMALL LETTER C WITH CEDILLA AND ACUTE
'U+0033 = DIGIT THREE
'U+2044 = FRACTION SLASH
'U+0034 = DIGIT FOUR
'
'--------------------------------------------------------------------------------
'
'B1) Is s2 normalized to the default form (Form C)?: True
'Characters in string s2 = 1E09 00BE
'
'B2) Is s2 normalized to Form C?: True
'Characters in string s2 = 1E09 00BE
'
'B3) Is s2 normalized to Form D?: True
'Characters in string s2 = 0063 0327 0301 00BE
'
'B4) Is s2 normalized to Form KC?: True
'Characters in string s2 = 1E09 0033 2044 0034
'
'B5) Is s2 normalized to Form KD?: True
'Characters in string s2 = 0063 0327 0301 0033 2044 0034
'
'</snippet1>