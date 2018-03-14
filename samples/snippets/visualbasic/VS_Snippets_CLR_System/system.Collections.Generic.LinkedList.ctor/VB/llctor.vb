' The following code example creates and initializes a LinkedList of type String and then displays its contents.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class GenericCollection

    Public Shared Sub Main()

        ' Create and initialize a new LinkedList.
        Dim ll As New LinkedList(Of String)()
        ll.AddLast("red")
        ll.AddLast("orange")
        ll.AddLast("yellow")
        ll.AddLast("orange")

        ' Display the contents of the LinkedList.
        If ll.Count > 0 Then
            Console.WriteLine("The first item in the list is {0}.", ll.First.Value)
            Console.WriteLine("The last item in the list is {0}.", ll.Last.Value)

            Console.WriteLine("The LinkedList contains:")
            For Each s As String In  ll
                Console.WriteLine("   {0}", s)
            Next s 
        Else
            Console.WriteLine("The LinkedList is empty.")
        End If

    End Sub 

End Class 

'This code produces the following output.
'
'The first item in the list is <null>.
'The last item in the list is orange.
'The LinkedList contains:
'   red
'   orange
'   yellow
'   orange

' </snippet1>