' <Snippet1>
Imports System
Imports System.Text
Imports System.Collections.Generic
Public Class Example

    Public Shared Sub Main()
        ' <Snippet2>
        ' Create the link list.
        Dim words() As String = {"the", "fox", _
            "jumped", "over", "the", "dog"}
        Dim sentence As New LinkedList(Of String)(words)
        Console.WriteLine("sentence.Contains(""jumped"") = {0}", _
            sentence.Contains("jumped"))
        ' </Snippet2>
        Display(sentence, "The linked list values:")
        ' Add the word 'today' to the beginning of the linked list.
        sentence.AddFirst("today")
        Display(sentence, "Test 1: Add 'today' to beginning of the list:")
        ' <Snippet3>
        ' Move the first node to be the last node.
        Dim mark1 As LinkedListNode(Of String) = sentence.First
        sentence.RemoveFirst()
        sentence.AddLast(mark1)
        ' </Snippet3>
        Display(sentence, "Test 2: Move first node to be last node:")
        ' Change the last node be 'yesterday'.
        sentence.RemoveLast()
        sentence.AddLast("yesterday")
        Display(sentence, "Test 3: Change the last node to 'yesterday':")
        ' <Snippet4>
        ' Move the last node to be the first node.
        mark1 = sentence.Last
        sentence.RemoveLast()
        sentence.AddFirst(mark1)
        ' </Snippet4>
        Display(sentence, "Test 4: Move last node to be first node:")
        ' <Snippet12>
        ' Indicate, by using parentheisis, the last occurence of 'the'.
        sentence.RemoveFirst()
        Dim current As LinkedListNode(Of String) = sentence.FindLast("the")
        ' </Snippet12>
        IndicateNode(current, "Test 5: Indicate last occurence of 'the':")
        ' <Snippet5>
        ' Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
        sentence.AddAfter(current, "old")
        sentence.AddAfter(current, "lazy")
        ' </Snippet5>
        IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':")
        ' <Snippet6>
        ' Indicate 'fox' node.
        current = sentence.Find("fox")
        IndicateNode(current, "Test 7: Indicate the 'fox' node:")
        ' Add 'quick' and 'brown' before 'fox':
        sentence.AddBefore(current, "quick")
        sentence.AddBefore(current, "brown")
        ' </Snippet6>
        IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':")
        ' Keep a reference to the current node, 'fox',
        ' and to the previous node in the list. Indicate the 'dog' node.
        mark1 = current
        Dim mark2 As LinkedListNode(Of String) = current.Previous
        current = sentence.Find("dog")
        IndicateNode(current, "Test 9: Indicate the 'dog' node:")
        ' The AddBefore method throws an InvalidOperationException
        ' if you try to add a node that already belongs to a list.
        Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:")
        Try
            sentence.AddBefore(current, mark1)
        Catch ex As InvalidOperationException
            Console.WriteLine("Exception message: {0}", ex.Message)
        End Try
        Console.WriteLine()
        ' <Snippet7>
        ' Remove the node referred to by mark1, and then add it
        ' before the node referred to by current.
        ' Indicate the node referred to by current.
        sentence.Remove(mark1)
        sentence.AddBefore(current, mark1)
        ' </Snippet7>
        IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):")
        ' <Snippet8>
        ' Remove the node referred to by current. 
        sentence.Remove(current)
        ' </Snippet8>
        IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:")
        ' Add the node after the node referred to by mark2.
        sentence.AddAfter(mark2, current)
        IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):")
        ' The Remove method finds and removes the
        ' first node that that has the specified value.
        sentence.Remove("old")
        Display(sentence, "Test 14: Remove node that has the value 'old':")
        ' <Snippet9>
        ' When the linked list is cast to ICollection(Of String),
        ' the Add method adds a node to the end of the list.
        sentence.RemoveLast()
        Dim icoll As ICollection(Of String) = sentence
        icoll.Add("rhinoceros")
        ' </Snippet9>
        Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':")
        Console.WriteLine("Test 16: Copy the list to an array:")
        '<Snippet10>
        ' Create an array with the same number of
        ' elements as the inked list.
        Dim sArray() As String = New String((sentence.Count) - 1) {}
        sentence.CopyTo(sArray, 0)
        For Each s As String In sArray
            Console.WriteLine(s)
        Next
        '</Snippet10>

        '<Snippet11>
        ' Release all the nodes.
        sentence.Clear()
        Console.WriteLine()
        Console.WriteLine("Test 17: Clear linked list. Contains 'jumped' = {0}", sentence.Contains("jumped"))
        '</Snippet11>
        Console.ReadLine()
    End Sub

    Private Shared Sub Display(ByVal words As LinkedList(Of String), ByVal test As String)
        Console.WriteLine(test)
        For Each word As String In words
            Console.Write((word + " "))
        Next
        Console.WriteLine()
        Console.WriteLine()
    End Sub

    Private Shared Sub IndicateNode(ByVal node As LinkedListNode(Of String), ByVal test As String)
        Console.WriteLine(test)
        If IsNothing(node.List) Then
            Console.WriteLine("Node '{0}' is not in the list." & vbLf, node.Value)
            Return
        End If
        Dim result As StringBuilder = New StringBuilder(("(" _
                        + (node.Value + ")")))
        Dim nodeP As LinkedListNode(Of String) = node.Previous

        While (Not (nodeP) Is Nothing)
            result.Insert(0, (nodeP.Value + " "))
            nodeP = nodeP.Previous

        End While
        node = node.Next

        While (Not (node) Is Nothing)
            result.Append((" " + node.Value))
            node = node.Next

        End While
        Console.WriteLine(result)
        Console.WriteLine()
    End Sub
End Class
'This code example produces the following output:
'
'The linked list values:
'the fox jumped over the dog 
'Test 1: Add 'today' to beginning of the list:
'today the fox jumped over the dog 
'Test 2: Move first node to be last node:
'the fox jumped over the dog today 
'Test 3: Change the last node to 'yesterday':
'the fox jumped over the dog yesterday 
'Test 4: Move last node to be first node:
'yesterday the fox jumped over the dog 
'Test 5: Indicate last occurence of 'the':
'the fox jumped over (the) dog
'Test 6: Add 'lazy' and 'old' after 'the':
'the fox jumped over (the) lazy old dog
'Test 7: Indicate the 'fox' node:
'the (fox) jumped over the lazy old dog
'Test 8: Add 'quick' and 'brown' before 'fox':
'the quick brown (fox) jumped over the lazy old dog
'Test 9: Indicate the 'dog' node:
'the quick brown fox jumped over the lazy old (dog)
'Test 10: Throw exception by adding node (fox) already in the list:
'Exception message: The LinkedList node belongs a LinkedList.
'Test 11: Move a referenced node (fox) before the current node (dog):
'the quick brown jumped over the lazy old fox (dog)
'Test 12: Remove current node (dog) and attempt to indicate it:
'Node 'dog' is not in the list.
'Test 13: Add node removed in test 11 after a referenced node (brown):
'the quick brown (dog) jumped over the lazy old fox
'Test 14: Remove node that has the value 'old':
'the quick brown dog jumped over the lazy fox 
'Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
'the quick brown dog jumped over the lazy rhinoceros 
'Test 16: Copy the list to an array:
'the
'quick
'brown
'dog
'jumped
'over
'the
'lazy
'rhinoceros
'Test 17: Clear linked list. Contains 'jumped' = False
'
' </Snippet1>

