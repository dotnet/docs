' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Define names.
      Dim names() As String = { "Adam", "Ignatius", "Batholomew", 
                                "Gregory", "Clement", "Frances",  
                                "Harold", "Dalmatius", "Edgar",    
                                "John", "Benedict", "Paul", "George" } 
      Dim sortKeys(names.Length - 1) As SortKey
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo

      For ctr As Integer = 0 To names.Length - 1
         sortKeys(ctr) = ci.GetSortKey(names(ctr), CompareOptions.IgnoreCase)         
      Next   
      
      ' Sort array based on value of sort keys.
      Array.Sort(names, sortKeys)
      
      Console.WriteLine("Sorted array: ")
      For Each name In names
         Console.WriteLine(name)
      Next          
      Console.WriteLine()
      
      Dim namesToFind() As String = { "Paul", "PAUL", "Wilberforce" }
      
      Console.WriteLine("Searching an array:")
      For Each nameToFind In namesToFind
         Dim searchKey As SortKey = ci.GetSortKey(nameToFind, CompareOptions.IgnoreCase)
         Dim index As Integer = Array.FindIndex(sortKeys, 
                                                Function(x) x.Equals(searchKey)) 
         If index >= 0 Then
            Console.WriteLine("{0} found at index {1}: {2}", nameToFind,
                              index, names(index))
         Else
            Console.WriteLine("{0} not found", nameToFind)
         End If                     
      Next                     
   End Sub
End Module
' The example displays the following output:
'       Sorted array:
'       Adam
'       Batholomew
'       Benedict
'       Clement
'       Dalmatius
'       Edgar
'       Frances
'       George
'       Gregory
'       Harold
'       Ignatius
'       John
'       Paul
'       
'       Searching an array:
'       Paul found at index 12: Paul
'       PAUL found at index 12: Paul
'       Wilberforce not found
' </Snippet1>
