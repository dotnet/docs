' <Snippet1>
Public Module Example
   Public Sub Main()
      Dim strFirst As String = "Goodbye"
      Dim strSecond As String = "Hello"
      Dim strThird As String = "a small string"
      Dim strFourth As String = "goodbye"

      ' Compare a string to itself.
      Console.WriteLine(CompareStrings(strFirst, strFirst))
        
      Console.WriteLine(CompareStrings(strFirst, strSecond))
      Console.WriteLine(CompareStrings(strFirst, strThird))
        
      ' Compare a string to another string that varies only by case.
      Console.WriteLine(CompareStrings(strFirst, strFourth))
      Console.WriteLine(CompareStrings(strFourth, strFirst))
   End Sub
    
   Private Function CompareStrings(str1 As String, str2 As String) As String
      Dim cmpVal As Integer = str1.CompareTo(str2)
      If cmpVal = 0 Then
         ' The values are the same.
         Return "The strings occur in the same position in the sort order."
      ElseIf cmpVal < 0 Then
         Return "The first string precedes the second in the sort order."
      Else
         Return "The first string follows the second in the sort order."
      End If
   End Function
End Module
' This example displays the following output:
'       The strings occur in the same position in the sort order.
'       The strings occur in the same position in the sort order.
'       The first string precedes the second in the sort order.
'       The first string follows the second in the sort order.
'       The first string follows the second in the sort order.
'       The first string precedes the second in the sort order.
' </Snippet1>