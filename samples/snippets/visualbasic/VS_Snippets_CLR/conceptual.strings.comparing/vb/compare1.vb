' <Snippet1>
Imports System.Globalization
Imports System.Threading

Public Class TestClass
   Public Shared Sub Main()
      Dim str1 As String = "Apple"
      Dim str2 As String = "Æble"
      
      ' Set the current culture to Danish in Denmark.
      Thread.CurrentThread.CurrentCulture = New CultureInfo("da-DK")
      Dim result1 As Integer = [String].Compare(str1, str2)
      Console.WriteLine("When the CurrentCulture is ""da-DK"",")
      Console.WriteLine("the result of comparing_{0} with {1} is: {2}", 
                        str1, str2, result1)
      
      ' Set the current culture to English in the U.S.
      Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
      Dim result2 As Integer = [String].Compare(str1, str2)
      Console.WriteLine("When the CurrentCulture is""en-US"",")
      Console.WriteLine("the result of comparing {0} with {1} is: {2}", 
                        str1, str2,result2)
   End Sub
End Class
' The example displays the following output:
'    When the CurrentCulture is "da-DK",
'    the result of comparing Apple with Æble is: -1
'    
'    When the CurrentCulture is "en-US",
'    the result of comparing Apple with Æble is: 1
' </Snippet1>