' <Snippet3>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Public Class TextToFile   
   Public Shared Sub Main()
      ' Creates and initializes a new array to store 
      ' these date/time objects.
      Dim stringArray() As String = { "Apple", "Æble", "Zebra"}
      
      ' Displays the values of the array.
      Console.WriteLine("The original string array:")
      PrintIndexAndValues(stringArray)
      
      ' Set the CurrentCulture to "en-US".
      Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
      ' Sort the values of the Array.
      Array.Sort(stringArray)
      
      ' Display the values of the array.
      Console.WriteLine("After sorting for the ""en-US"" culture:")
      PrintIndexAndValues(stringArray)
      
      ' Set the CurrentCulture to "da-DK".
      Thread.CurrentThread.CurrentCulture = New CultureInfo("da-DK")
      ' Sort the values of the Array.
      Array.Sort(stringArray)
      
      ' Displays the values of the Array.
      Console.WriteLine("After sorting for the culture ""da-DK"":")
      PrintIndexAndValues(stringArray)
   End Sub

   Public Shared Sub PrintIndexAndValues(myArray() As String)
      For i As Integer = myArray.GetLowerBound(0) To myArray.GetUpperBound(0)
         Console.WriteLine("[{0}]: {1}", i, myArray(i))
      Next
      Console.WriteLine()
   End Sub 
End Class
' The example displays the following output:
'       The original string array:
'       [0]: Apple
'       [1]: Æble
'       [2]: Zebra
'       
'       After sorting for the "en-US" culture:
'       [0]: Æble
'       [1]: Apple
'       [2]: Zebra
'       
'       After sorting for the culture "da-DK":
'       [0]: Apple
'       [1]: Zebra
'       [2]: Æble
' </Snippet3>