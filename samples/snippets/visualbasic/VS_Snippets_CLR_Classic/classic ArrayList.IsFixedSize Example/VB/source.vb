' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("The")
        myAL.Add("quick")
        myAL.Add("brown")
        myAL.Add("fox")
        myAL.Add("jumped")
        myAL.Add("over")
        myAL.Add("the")
        myAL.Add("lazy")
        myAL.Add("dog")
        
        ' Create a fixed-size wrapper around the ArrayList.
        Dim myFixedSizeAL As ArrayList = ArrayList.FixedSize(myAL)
        
        ' Display whether the ArrayLists have a fixed size or not.
        Dim msg As String
        If myAL.IsFixedSize Then
            msg = "has a fixed size"
        Else
            msg = "does not have a fixed size"
        End If
        Console.WriteLine("myAL {0}.", msg)
        If myFixedSizeAL.IsFixedSize Then
            msg = "has a fixed size"
        Else
            msg = "does not have a fixed size"
        End If
        Console.WriteLine("myFixedSizeAL {0}.", msg)
        Console.WriteLine()
        
        ' Display both ArrayLists.
        Console.WriteLine("Initially,")
        Console.Write("Standard  :")
        PrintValues(myAL, " "c)
        Console.Write("Fixed size:")
        PrintValues(myFixedSizeAL, " "c)
        
        ' Sort is allowed in the fixed-size ArrayList.
        myFixedSizeAL.Sort()
        
        ' Display both ArrayLists.
        Console.WriteLine("After Sort,")
        Console.Write("Standard  :")
        PrintValues(myAL, " "c)
        Console.Write("Fixed size:")
        PrintValues(myFixedSizeAL, " "c)
        
        ' Reverse is allowed in the fixed-size ArrayList.
        myFixedSizeAL.Reverse()
        
        ' Display both ArrayLists.
        Console.WriteLine("After Reverse,")
        Console.Write("Standard  :")
        PrintValues(myAL, " "c)
        Console.Write("Fixed size:")
        PrintValues(myFixedSizeAL, " "c)
        
        ' Add an element to the standard ArrayList.
        myAL.Add("AddMe")
        
        ' Display both ArrayLists.
        Console.WriteLine("After adding to the standard ArrayList,")
        Console.Write("Standard  :")
        PrintValues(myAL, " "c)
        Console.Write("Fixed size:")
        PrintValues(myFixedSizeAL, " "c)
        Console.WriteLine()
        
        ' Adding or inserting elements to the fixed-size ArrayList throws an exception.
        Try
            myFixedSizeAL.Add("AddMe2")
        Catch myException As Exception
            Console.WriteLine("Exception: " + myException.ToString())
        End Try
        Try
            myFixedSizeAL.Insert(3, "InsertMe")
        Catch myException As Exception
            Console.WriteLine("Exception: " + myException.ToString())
        End Try
    End Sub 'Main

    Public Shared Sub PrintValues(myList As IEnumerable, mySeparator As Char)
        Dim obj As [Object]
        For Each obj In  myList
            Console.Write("{0}{1}", mySeparator, obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class


' This code produces the following output.
' 
' myAL does not have a fixed size.
' myFixedSizeAL has a fixed size.
' 
' Initially,
' Standard  : The quick brown fox jumped over the lazy dog
' Fixed size: The quick brown fox jumped over the lazy dog
' After Sort,
' Standard  : brown dog fox jumped lazy over quick the The
' Fixed size: brown dog fox jumped lazy over quick the The
' After Reverse,
' Standard  : The the quick over lazy jumped fox dog brown
' Fixed size: The the quick over lazy jumped fox dog brown
' After adding to the standard ArrayList,
' Standard  : The the quick over lazy jumped fox dog brown AddMe
' Fixed size: The the quick over lazy jumped fox dog brown AddMe
' 
' Exception: System.NotSupportedException: Collection was of a fixed size.
'    at System.Collections.FixedSizeArrayList.Add(Object obj)
'    at SamplesArrayList.Main()
' Exception: System.NotSupportedException: Collection was of a fixed size.
'    at System.Collections.FixedSizeArrayList.Insert(Int32 index, Object obj)
'    at SamplesArrayList.Main()
' </Snippet1>
