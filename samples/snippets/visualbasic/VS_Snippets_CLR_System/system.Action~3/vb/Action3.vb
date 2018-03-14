' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module TestAction3
   Public Sub Main()
      Dim ordinals() As String = {"First", "Second", "Third", "Fourth", "Fifth"}
      Dim copiedOrdinals(ordinals.Length - 1) As String
      Dim copyOperation As Action(Of String(), String(), Integer) = AddressOf CopyStrings
      copyOperation(ordinals, copiedOrdinals, 3)
      For Each ordinal As String In copiedOrdinals
         Console.WriteLine(ordinal)
      Next    
   End Sub
   
   Private Sub CopyStrings(source() As String, target() As String, startPos As Integer)
      If source.Length <> target.Length Then 
         Throw New IndexOutOfRangeException("The source and target arrays must have the same number of elements.")
      End If
      For ctr As Integer = startPos to source.Length - 1
         target(ctr) = String.Copy(source(ctr))
      Next
   End Sub
End Module
' </Snippet2>

