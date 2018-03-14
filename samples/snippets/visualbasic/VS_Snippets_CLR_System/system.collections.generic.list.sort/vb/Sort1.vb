' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim names() As String = { "Samuel", "Dakota", "Koani", "Saya",
                                "Vanya", "Yiska", "Yuma", "Jody",
                                "Nikita" }
      Dim nameList As New List(Of String)()
      nameList.AddRange(names)
      Console.WriteLine("List in unsorted order: ")
      For Each name In nameList
         Console.Write("   {0}", name)
      Next
      Console.WriteLine(vbCrLf)

      nameList.Sort()
      Console.WriteLine("List in sorted order: ")
      For Each name In nameList
         Console.Write("   {0}", name)
      Next
      Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    List in unsorted order:
'       Samuel   Dakota   Koani   Saya   Vanya   Yiska   Yuma   Jody   Nikita
'
'    List in sorted order:
'       Dakota   Jody   Koani   Nikita   Samuel   Saya   Vanya   Yiska   Yuma
' </Snippet2>
