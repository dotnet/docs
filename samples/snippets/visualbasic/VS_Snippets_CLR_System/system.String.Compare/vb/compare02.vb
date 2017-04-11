Option Strict On

' <Snippet18>
Public Module Example
   Public Sub Main()
      ' Create upper-case characters from their Unicode code units.
      Dim stringUpper As String = ChrW(&H41) + ChrW(&H42) + ChrW(&H43)

      ' Create lower-case characters from their Unicode code units.
      Dim stringLower As String = ChrW(&H61) + ChrW(&H62) + ChrW(&H63)

      ' Display the strings.
      Console.WriteLine("Comparing '{0}' and '{1}':", 
                        stringUpper, stringLower)

      ' Compare the uppercased strings; the result is true.
      Console.WriteLine("The Strings are equal when capitalized? {0}",
                        If(String.Compare(stringUpper.ToUpper(), stringLower.ToUpper()) = 0, 
                                          "true", "false"))

      ' The previous method call is equivalent to this Compare method, which ignores case.
      Console.WriteLine("The Strings are equal when case is ignored? {0}",
                        If(String.Compare(stringUpper, stringLower, true) = 0,
                                          "true", "false"))
   End Sub
End Module 
' The example displays the following output:
'       Comparing 'ABC' and 'abc':
'       The Strings are equal when capitalized? true
'       The Strings are equal when case is ignored? true
' </Snippet18>

