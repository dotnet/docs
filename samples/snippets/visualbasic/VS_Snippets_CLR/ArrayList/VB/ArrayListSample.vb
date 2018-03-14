'<snippet7>
Imports System
Imports System.Text
Imports System.Collections



Public Class SamplesArrayList
    
    
    Public Shared Sub Main()
        Dim myAL As New ArrayList()
        '<snippet1> 
        ' Creates and initializes a new ArrayList.
        myAL.Add("Eric")
        myAL.Add("Mark")
        myAL.Add("Lance")
        myAL.Add("Rob")
        myAL.Add("Kris")
        myAL.Add("Brad")
        myAL.Add("Kit")
        myAL.Add("Bradley")
        myAL.Add("Keith")
        myAL.Add("Susan")
        
        ' Displays the properties and values of	the	ArrayList.
        Console.WriteLine("Count: {0}", myAL.Count)
        '</snippet1>
        PrintValues("Unsorted", myAL)
        '<snippet3> 
        myAL.Sort()
        PrintValues("Sorted", myAL)
        '</snippet3>
        '<snippet4> 
        Dim comp as New ReverseStringComparer
        myAL.Sort(comp)
        PrintValues("Reverse", myAL)

        '<snippet5>  
        Dim names As String() = CType(myAL.ToArray(GetType(String)), String())
      '</snippet5>
    '</snippet4>
    End Sub 'Main
   
   
    
    '<snippet2> 
    Public Shared Sub PrintValues(title As String, myList As IEnumerable)
        Console.Write("{0,10}: ", title)
        Dim sb As New StringBuilder()
        Dim s As String
        For Each s In  myList
            sb.AppendFormat("{0}, ", s)
        Next s
        sb.Remove(sb.Length - 2, 2)
        Console.WriteLine(sb)
    End Sub 'PrintValues
'</snippet2>
End Class 'SamplesArrayList

'<snippet6> 
Public Class ReverseStringComparer 
  Implements IComparer
    
     Function Compare(x As Object, y As Object) As Integer implements IComparer.Compare
        Dim s1 As String = CStr (x)
        Dim s2 As String = CStr (y)
        
        'negate the return value to get the reverse order
        Return - [String].Compare(s1, s2)
    
    End Function 'Compare
End Class 'ReverseStringComparer
'</snippet6>

'</snippet7>
