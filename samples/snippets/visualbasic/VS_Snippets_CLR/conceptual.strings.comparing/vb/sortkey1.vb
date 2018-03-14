' <Snippet4>
Imports System.Globalization
Imports System.Threading

Public Class SortKeySample
   Public Shared Sub Main()
      Dim str1 As [String] = "Apple"
      Dim str2 As [String] = "Æble"
      
      ' Set the CurrentCulture to "da-DK".
      Dim dk As New CultureInfo("da-DK")
      Thread.CurrentThread.CurrentCulture = dk
      
      ' Create a culturally sensitive sort key for str1.
      Dim sc1 As SortKey = dk.CompareInfo.GetSortKey(str1)
      ' Create a culturally sensitive sort key for str2.
      Dim sc2 As SortKey = dk.CompareInfo.GetSortKey(str2)
      
      ' Compare the two sort keys and display the results.
      Dim result1 As Integer = SortKey.Compare(sc1, sc2)
      Console.WriteLine("When the  current culture is ""da-DK"",")
      Console.WriteLine("the result of comparing {0} with {1} is: {2}", 
                        str1, str2, result1)
      Console.WriteLine()
      
      ' Set the CurrentCulture to "en-US".
      Dim enus As New CultureInfo("en-US")
      Thread.CurrentThread.CurrentCulture = enus
      
      ' Create a culturally sensitive sort key for str1.
      Dim sc3 As SortKey = enus.CompareInfo.GetSortKey(str1)
      ' Create a culturally sensitive sort key for str1.
      Dim sc4 As SortKey = enus.CompareInfo.GetSortKey(str2)
      
      ' Compare the two sort keys and display the results.
      Dim result2 As Integer = SortKey.Compare(sc3, sc4)
      Console.WriteLine("When the CurrentCulture is ""en-US"",")
      Console.WriteLine("the result of comparing {0} with {1} is: {2}", 
                        str1, str2, result2)
   End Sub
End Class
' The example displays the following output:
'       When the  current culture is "da-DK",
'       the result of comparing Apple with Æble is: -1
'       
'       When the CurrentCulture is "en-US",
'       the result of comparing Apple with Æble is: 1
' </Snippet4>