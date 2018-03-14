' The following code example creates a LinkedList node, adds it to a LinkedList, and tracks the values of its properties as the LinkedList changes.

' <snippet1>
Imports System
Imports System.Collections.Generic

Public Class GenericCollection

    Public Shared Sub Main()

        ' Create a new LinkedListNode of type String and displays its properties.
        Dim lln As New LinkedListNode(Of String)("orange")
        Console.WriteLine("After creating the node ....")
        DisplayProperties(lln)

        ' Create a new LinkedList.
        Dim ll As New LinkedList(Of String)

        ' Add the "orange" node and display its properties.
        ll.AddLast(lln)
        Console.WriteLine("After adding the node to the empty LinkedList ....")
        DisplayProperties(lln)

        ' Add nodes before and after the "orange" node and display the "orange" node's properties.
        ll.AddFirst("red")
        ll.AddLast("yellow")
        Console.WriteLine("After adding red and yellow ....")
        DisplayProperties(lln)

    End Sub 'Main

    Public Shared Sub DisplayProperties(lln As LinkedListNode(Of String))

        If lln.List Is Nothing Then
            Console.WriteLine("   Node is not linked.")
        Else
            Console.WriteLine("   Node belongs to a linked list with {0} elements.", lln.List.Count)
        End If 

        If lln.Previous Is Nothing Then
            Console.WriteLine("   Previous node is null.")
        Else
            Console.WriteLine("   Value of previous node: {0}", lln.Previous.Value)
        End If 

        Console.WriteLine("   Value of current node:  {0}", lln.Value)
        
        If lln.Next Is Nothing Then
            Console.WriteLine("   Next node is null.")
        Else
            Console.WriteLine("   Value of next node:     {0}", lln.Next.Value)
        End If 

        Console.WriteLine()

    End Sub 'DisplayProperties 

End Class 'GenericCollection


'This code produces the following output.
'
'After creating the node ....
'   Node is not linked.
'   Previous node is null.
'   Value of current node:  orange
'   Next node is null.
'
'After adding the node to the empty LinkedList ....
'   Node belongs to a linked list with 1 elements.
'   Previous node is null.
'   Value of current node:  orange
'   Next node is null.
'
'After adding red and yellow ....
'   Node belongs to a linked list with 3 elements.
'   Value of previous node: red
'   Value of current node:  orange
'   Value of next node:     yellow

' </snippet1>