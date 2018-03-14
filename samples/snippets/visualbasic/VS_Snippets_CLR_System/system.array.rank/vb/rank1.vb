' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim array1(9) As Integer 
      Dim array2(9,2) As Integer  
      Dim array3(9)() As Integer 
      
      Console.WriteLine("{0}: {1} dimension(s)", 
                        array1.ToString(), array1.Rank)
      Console.WriteLine("{0}: {1} dimension(s)", 
                        array2.ToString(), array2.Rank)
      Console.WriteLine("{0}: {1} dimension(s)", 
                        array3.ToString(), array3.Rank)
   End Sub
End Module
' The example displays the following output:
'       System.Int32[]: 1 dimension
'       System.Int32[,]: 2 dimension
'       System.Int32[][]: 1 dimension
' </Snippet1>

