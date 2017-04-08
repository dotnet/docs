' <Snippet2>
Imports System.Globalization
Imports System.Threading

Public Class Example
   Public Shared Sub Main()
      Dim str1 As String = "æble"
      Dim str2 As String = "aeble"
      Dim find As Char = "æ"c

      ' Create CultureInfo objects representing the Danish (Denmark)
      ' and English (United States) cultures.
      Dim cultures() As CultureInfo = { CultureInfo.CreateSpecificCulture("da-DK"), 
                                        CultureInfo.CreateSpecificCulture("en-US") }

      For Each ci In cultures
         Thread.CurrentThread.CurrentCulture = ci
                                                  
         Dim result1 As Integer = ci.CompareInfo.IndexOf(str1, find)
         Dim result2 As Integer = ci.CompareInfo.IndexOf(str2, find)
         Dim result3 As Integer = ci.CompareInfo.IndexOf(str1, find, _ 
            CompareOptions.Ordinal)
         Dim result4 As Integer = ci.CompareInfo.IndexOf(str2, find, _
            CompareOptions.Ordinal)      
   
         Console.WriteLine("The current culture is {0}", 
                           CultureInfo.CurrentCulture.Name)
         Console.WriteLine()
         Console.WriteLine("   CompareInfo.IndexOf(string, char) method:")
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str1, result1)
         Console.WriteLine()
         Console.WriteLine("   CompareInfo.IndexOf(string, char) method:")
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str2, result2)
         Console.WriteLine()
         Console.WriteLine("   CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method")
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str1, result3)
         Console.WriteLine()
         Console.WriteLine("   CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method")
         Console.WriteLine("   Position of {0} in the string {1}: {2}", 
                           find, str2, result4)
         Console.WriteLine()
      Next
   End Sub
End Class
' The example displays the following output:
'    The current culture is da-DK
'    
'       CompareInfo.IndexOf(string, char) method:
'       Position of æ in the string æble: 0
'    
'       CompareInfo.IndexOf(string, char) method:
'       Position of æ in the string aeble: -1
'    
'       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
'       Position of æ in the string æble: 0
'    
'       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
'       Position of æ in the string aeble: -1
'    
'    The current culture is en-US
'    
'       CompareInfo.IndexOf(string, char) method:
'       Position of æ in the string æble: 0
'    
'       CompareInfo.IndexOf(string, char) method:
'       Position of æ in the string aeble: 0
'    
'       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
'       Position of æ in the string æble: 0
'    
'       CompareInfo.IndexOf(string, char, CompareOptions.Ordinal) method
'       Position of æ in the string aeble: -1
' </Snippet2>