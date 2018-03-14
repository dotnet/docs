Option Strict On 

' <Snippet5>
Public Module Example
   Public Sub Main()
      ' Create a Unicode string with 5 Greek Alpha characters.
      Dim szGreekAlpha As New String(ChrW(&H0391), 5)

      ' Create a Unicode string with 3 Greek Omega characters.
      Dim szGreekOmega As String = ChrW(&H03A9) + ChrW(&H03A9)+
                                   ChrW(&H03A9)

      Dim szGreekLetters As String = String.Concat(szGreekOmega, szGreekAlpha, _
                                                   szGreekOmega.Clone())

      ' Display the entire string.
      Console.WriteLine(szGreekLetters)

      ' The first index of Alpha.
      Dim iAlpha As Integer = szGreekLetters.IndexOf(ChrW(&H0391))
      ' The first index of Omega.
      Dim iomega As Integer = szGreekLetters.IndexOf(ChrW(&H03A9))

      Console.WriteLine("First occurrence of the Greek letter Alpha: Index {0}", 
                        ialpha)
      Console.WriteLine("First occurrence of the Greek letter Omega: Index {0}", 
                        iomega)
   End Sub
End Module
' The example displays the following output:
'       The string: OOO?????OOO
'       First occurrence of the Greek letter Alpha: Index 3
'       First occurrence of the Greek letter Omega: Index 0
' </Snippet5>
