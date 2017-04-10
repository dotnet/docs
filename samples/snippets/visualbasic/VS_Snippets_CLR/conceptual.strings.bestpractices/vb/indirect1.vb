' Visual Basic .NET Document
Option Strict On

Class modMain
   Public Shared Sub Main()

   End Sub

   ' <Snippet7>
   ' Incorrect.
   Dim storedNames() As String
   
   Public Sub StoreNames(names() As String)
      Dim index As Integer = 0
      ReDim storedNames(names.Length - 1)
      
      For Each name As String In names
         Me.storedNames(index) = name
         index+= 1
      Next
      
      Array.Sort(names)          ' Line A.
   End Sub
   
   Public Function DoesNameExist(name As String) As Boolean
      Return Array.BinarySearch(Me.storedNames, name) >= 0      ' Line B.
   End Function
   ' </Snippet7>
End Class

Public Class Class8
   ' <Snippet8>
   ' Correct.
   Dim storedNames() As String
   
   Public Sub StoreNames(names() As String)
      Dim index As Integer = 0
      ReDim storedNames(names.Length - 1)
      
      For Each name As String In names
         Me.storedNames(index) = name
         index+= 1
      Next
      
      Array.Sort(names, StringComparer.Ordinal)           ' Line A.
   End Sub
   
   Public Function DoesNameExist(name As String) As Boolean
      Return Array.BinarySearch(Me.storedNames, name, StringComparer.Ordinal) >= 0      ' Line B.
   End Function
   ' </Snippet8>
End Class

Public Class Class9
   ' <Snippet9>
   ' Correct.
   Dim storedNames() As String
   
   Public Sub StoreNames(names() As String)
      Dim index As Integer = 0
      ReDim storedNames(names.Length - 1)
      
      For Each name As String In names
         Me.storedNames(index) = name
         index+= 1
      Next
      
      Array.Sort(names, StringComparer.InvariantCulture)           ' Line A.
   End Sub
   
   Public Function DoesNameExist(name As String) As Boolean
      Return Array.BinarySearch(Me.storedNames, name, StringComparer.InvariantCulture) >= 0      ' Line B.
   End Function
   ' </Snippet9>
End Class
