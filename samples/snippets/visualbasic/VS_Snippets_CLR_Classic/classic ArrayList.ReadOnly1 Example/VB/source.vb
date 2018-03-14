' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesArrayList

   Public Shared Sub Main()

      Dim myStr As [String]

      ' Creates and initializes a new ArrayList.
      Dim myAL As New ArrayList()
      myAL.Add("red")
      myAL.Add("orange")
      myAL.Add("yellow")

      ' Creates a read-only copy of the ArrayList.
      Dim myReadOnlyAL As ArrayList = ArrayList.ReadOnly(myAL)

      ' Displays whether the ArrayList is read-only or writable.
      If myAL.IsReadOnly Then
         Console.WriteLine("myAL is read-only.")
      Else
         Console.WriteLine("myAL is writable.")
      End If
      If myReadOnlyAL.IsReadOnly Then
         Console.WriteLine("myReadOnlyAL is read-only.")
      Else
         Console.WriteLine("myReadOnlyAL is writable.")
      End If

      ' Displays the contents of both collections.
      Console.WriteLine()
      Console.WriteLine("Initially,")
      Console.WriteLine("The original ArrayList myAL contains:")
      For Each myStr In  myAL
         Console.WriteLine("   {0}", myStr)
      Next myStr
      Console.WriteLine("The read-only ArrayList myReadOnlyAL contains:")
      For Each myStr In  myReadOnlyAL
         Console.WriteLine("   {0}", myStr)
      Next myStr 

      ' Adding an element to a read-only ArrayList throws an exception.
      Console.WriteLine()
      Console.WriteLine("Trying to add a new element to the read-only ArrayList:")
      Try
         myReadOnlyAL.Add("green")
      Catch myException As Exception
         Console.WriteLine(("Exception: " + myException.ToString()))
      End Try

      ' Adding an element to the original ArrayList affects the read-only ArrayList.
      myAL.Add("blue")

      ' Displays the contents of both collections again.
      Console.WriteLine()
      Console.WriteLine("After adding a new element to the original ArrayList,")
      Console.WriteLine("The original ArrayList myAL contains:")
      For Each myStr In  myAL
         Console.WriteLine("   {0}", myStr)
      Next myStr
      Console.WriteLine("The read-only ArrayList myReadOnlyAL contains:")
      For Each myStr In  myReadOnlyAL
         Console.WriteLine("   {0}", myStr)
      Next myStr 

   End Sub 'Main

End Class 'SamplesArrayList 


'This code produces the following output.
'
'myAL is writable.
'myReadOnlyAL is read-only.
'
'Initially,
'The original ArrayList myAL contains:
'   red
'   orange
'   yellow
'The read-only ArrayList myReadOnlyAL contains:
'   red
'   orange
'   yellow
'
'Trying to add a new element to the read-only ArrayList:
'Exception: System.NotSupportedException: Collection is read-only.
'   at System.Collections.ReadOnlyArrayList.Add(Object obj)
'   at SamplesArrayList.Main()
'
'After adding a new element to the original ArrayList,
'The original ArrayList myAL contains:
'   red
'   orange
'   yellow
'   blue
'The read-only ArrayList myReadOnlyAL contains:
'   red
'   orange
'   yellow
'   blue

' </Snippet1>