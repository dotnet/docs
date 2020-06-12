'<snippet23>
Imports System.Collections.Generic

Class AdvantageGenerics
    Public Shared Sub Main()
        Dim myArray() As String = _
            {"First String", "test string", "Last String"}

        '<snippet24>
        Dim llist As New LinkedList(Of String)()
        '</snippet24>

        For Each item As String In myArray
            llist.AddLast(item)
        Next item
        Dim found As LinkedListNode(Of String) = llist.Find("test string")
        If Not (found Is Nothing) Then
            Console.WriteLine("Item found: {0}", found.Value)
        End If
        '<snippet25>
        Dim index0 As Integer = Array.BinarySearch(myArray, "test string")
        Dim index1 As Integer = Array.BinarySearch(Of String)(myArray, "test string")
        '</snippet25>

        Console.WriteLine("Indexes for binary searches: {0}, {1}", index0, index1)
    End Sub
End Class
'</snippet23>
