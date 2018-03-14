'<snippet1>
' This example demonstrates the TextInfo.Clone() and
' TextInfo.ReadOnly() methods.

Imports System
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 
        ' Get the TextInfo of a predefined culture that ships with 
        ' the .NET Framework.
        Dim ci As New CultureInfo("en-US")
        Dim ti1 As TextInfo = ci.TextInfo
        
        ' Display whether the TextInfo is read-only or not.
        DisplayReadOnly("1) The original TextInfo object", ti1)
        Console.WriteLine()
        
        ' Create a clone of the original TextInfo and cast the clone to a TextInfo type.
        Console.WriteLine("2a) Create a clone of the original TextInfo object...")
        Dim ti2 As TextInfo = CType(ti1.Clone(), TextInfo)
        
        ' Display whether the clone is read-only.
        DisplayReadOnly("2b) The TextInfo clone", ti2)
        
        ' Set the ListSeparator property on the TextInfo clone.
        Console.WriteLine("2c) The original value of the clone's ListSeparator " & _
                          "property is ""{0}"".", ti2.ListSeparator)
        ti2.ListSeparator = "/"
        Console.WriteLine("2d) The new value of the clone's ListSeparator " & _ 
                          "property is ""{0}""." & vbCrLf, ti2.ListSeparator)
        
        ' Create a read-only clone of the original TextInfo.
        Console.WriteLine("3a) Create a read-only clone of the original TextInfo object...")
        Dim ti3 As TextInfo = TextInfo.ReadOnly(ti1)
        
        ' Display whether the read-only clone is actually read-only.
        DisplayReadOnly("3b) The TextInfo clone", ti3)
        
        ' Try to set the ListSeparator property of a read-only TextInfo object. Use the
        ' IsReadOnly property again to determine whether to attempt the set operation. You 
        ' could use a try-catch block instead and catch an InvalidOperationException when
        ' the set operation fails, but that programming technique is inefficient.
        Console.WriteLine("3c) Try to set the read-only clone's LineSeparator property.")
        If ti3.IsReadOnly = True Then
            Console.WriteLine("3d) The set operation is invalid.")
        Else
            ' This clause is not executed.
            ti3.ListSeparator = "/"
            Console.WriteLine("3d) The new value of the clone's ListSeparator " & _ 
                              "property is ""{0}""." & vbCrLf, ti2.ListSeparator)
        End If
    
    End Sub 'Main
    
    Private Shared Sub DisplayReadOnly(ByVal caption As String, ByVal ti As TextInfo)
        Dim middle As String
        If ti.IsReadOnly = True Then
            middle = ""
        Else 
            middle = "not "
        End If        
        Console.WriteLine("{0} is {1}read-only.", caption, middle)
    End Sub 'DisplayReadOnly
End Class 'Sample

'
'This code example produces the following results:
'
'1) The original TextInfo object is not read-only.
'
'2a) Create a clone of the original TextInfo object...
'2b) The TextInfo clone is not read-only.
'2c) The original value of the clone's ListSeparator property is ",".
'2d) The new value of the clone's ListSeparator property is "/".
'
'3a) Create a read-only clone of the original TextInfo object...
'3b) The TextInfo clone is read-only.
'3c) Try to set the read-only clone's LineSeparator property.
'3d) The set operation is invalid.
'
'</snippet1>