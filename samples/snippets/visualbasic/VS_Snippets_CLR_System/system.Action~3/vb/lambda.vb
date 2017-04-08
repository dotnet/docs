Option Strict On

' <Snippet4>
Public Module TestLambda
   Public Sub Main()
      Dim ordinals() As String = {"First", "Second", "Third", "Fourth", "Fifth"}
      Dim copiedOrdinals(ordinals.Length - 1) As String           
      Dim copyOperation As Action(Of String(), String(), Integer) = _
                           Sub(s1, s2, pos) CopyStrings(s1, s2, pos) 
      copyOperation(ordinals, copiedOrdinals, 3)
      For Each ordinal As String In copiedOrdinals
         If String.IsNullOrEmpty(ordinal) Then
            Console.WriteLine("<None>")
         Else
            Console.WriteLine(ordinal)
         End If      
      Next   
   End Sub

   Private Function CopyStrings(source() As String, target() As String, startPos As Integer) As Integer
      If source.Length <> target.Length Then 
         Throw New IndexOutOfRangeException("The source and target arrays must have the same number of elements.")
      End If
      
      For ctr As Integer = startPos To source.Length - 1 
         target(ctr) = String.Copy(source(ctr))
      Next
      Return source.Length - startPos 
   End Function
End Module
' The example displays the following output:
'       <None>
'       <None>
'       <None>
'       Fourth
'       Fifth
' </Snippet4>
