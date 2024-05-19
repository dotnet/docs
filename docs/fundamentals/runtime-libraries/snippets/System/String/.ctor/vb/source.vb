Option Strict On 

Imports System.Text

Class ConsoleApp
   <STAThread> Public Shared Sub Main()
      ' <Snippet1>
      ' Unicode Mathematical operators
      Dim charArr1() As Char = {ChrW(&H2200), ChrW(&H2202), _
                                ChrW(&H200F), ChrW(&H2205)}
      Dim szMathSymbols As New String(charArr1)

      ' Unicode Letterlike Symbols
      Dim charArr2() As Char = {ChrW(&H2111), ChrW(&H2118), _
                                ChrW(&H2122), ChrW(&H2126)}
      Dim szLetterLike As New String(charArr2)

      ' Compare Strings - the result is false
      Console.WriteLine("The strings are equal? " & _
              CStr(szMathSymbols.Equals(szLetterLike))) 
      ' </Snippet1>

      ' <Snippet3>
      ' Create a Unicode String with 5 Greek Alpha characters
      Dim szGreekAlpha As New String(ChrW(&H0391), 5)
      ' Create a Unicode String with a Greek Omega character
      Dim szGreekOmega As New String(New Char() {ChrW(&H03A9), ChrW(&H03A9), _
                                                 ChrW(&H03A9)}, 2, 1)

      Dim szGreekLetters As String = String.Concat(szGreekOmega, szGreekAlpha, _
                                                   szGreekOmega.Clone())

      ' Examine the result
      Console.WriteLine(szGreekLetters)

      ' The first index of Alpha
      Dim iAlpha As Integer = szGreekLetters.IndexOf(ChrW(&H0391))
      ' The last index of Omega
      Dim iomega As Integer = szGreekLetters.LastIndexOf(ChrW(&H03A9))

      Console.WriteLine("The Greek letter Alpha first appears at index {0}.", _ 
                        ialpha)
      Console.WriteLIne("The Greek letter Omega last appears at index {0}.", _
                        iomega)
      ' </Snippet3>
   End Sub
End Class
