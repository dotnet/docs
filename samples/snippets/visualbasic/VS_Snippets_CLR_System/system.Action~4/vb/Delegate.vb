' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Delegate Sub StringCopy(stringArray1() As String, _
                        stringArray2() As String, _
                        indexToStart As Integer, _
                        numberToCopy As Integer)

Module TestDelegate
   Public Sub Main()
      Dim ordinals() As String = {"First", "Second", "Third", "Fourth", _
                                  "Fifth", "Sixth", "Seventh", "Eighth", _
                                  "Ninth", "Tenth"}
      Dim copiedOrdinals(ordinals.Length - 1) As String
      Dim copyOperation As StringCopy = AddressOf CopyStrings
      copyOperation(ordinals, copiedOrdinals, 3, 5)
      For Each ordinal As String In copiedOrdinals
         Console.WriteLine(ordinal)
      Next    
   End Sub
   
   Private Sub CopyStrings(source() As String, target() As String, _
                           startPos As Integer, number As Integer)
      If source.Length <> target.Length Then 
         Throw New IndexOutOfRangeException("The source and target arrays" & _
                   " must have the same number of elements.")
      End If
      For ctr As Integer = startPos to startpos + number  - 1
         target(ctr) = String.Copy(source(ctr))
      Next
   End Sub
End Module
' </Snippet1>

