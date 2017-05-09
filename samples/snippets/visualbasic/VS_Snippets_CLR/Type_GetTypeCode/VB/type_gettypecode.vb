' System.Type.GetTypeCode()
' System.Type.GetProperties()
' System.Type.GetTypeArray()
' System.Type.GetType(String,Boolean,Boolean)

' The following example demonstrates the  'GetTypeCode()', 'GetProperties()', 'GetTypeArray()',
'	'GetType(String,Boolean,Boolean)' methods of 'Type' class.
'	'TypeCode' of 'System.Int32' is retrieved.Properties of 'System.Type' is retrieved into
'	'PropertyInfo' array and displayed.	Array of 'Type' objects is created which represents 
'	the type specified by an arbitary	set of objects. When 'Type' object is attempted to 
'	create for 'sYSTem.iNT32', an exception is thrown when case-sensitive search is done.  
Imports System
Imports System.Reflection


Namespace TypeCodeNamespace
    
   Class MyClass1
      
      Shared Sub Main()
' <Snippet1>
         ' Creates an object of 'Type' class.
         Dim myType1 As Type = Type.GetType("System.Int32")
         ' Get the 'TypeCode' of the 'Type' class object created above.
         Dim myTypeCode As TypeCode = Type.GetTypeCode(myType1)
         Console.WriteLine("TypeCode is: {0}", myTypeCode)
' </Snippet1>
' <Snippet2>
         Dim myPropertyInfo() As PropertyInfo
         ' Get the properties of 'Type' class object.
         myPropertyInfo = Type.GetType("System.Type").GetProperties()
         Console.WriteLine("Properties of System.Type are:")
         Dim i As Integer
         For i = 0 To myPropertyInfo.Length - 1
            Console.WriteLine(myPropertyInfo(i).ToString())
         Next i
' </Snippet2>
' <Snippet3>
         Dim myObject(2) As Object
         myObject(0) = 66
         myObject(1) = "puri"
         myObject(2) = 33.33
         ' Get the array of 'Type' class objects.
         Dim myTypeArray As Type() = Type.GetTypeArray(myObject)
         Console.WriteLine("Full names of the 'Type' objects in the array are:")
         Dim h As Integer
         For h = 0 To myTypeArray.Length - 1
            Console.WriteLine(myTypeArray(h).FullName)
         Next h
' </Snippet3>
' <Snippet4>
         Try
            ' Throws 'TypeLoadException' because of case-sensitive search.
            Dim myType2 As Type = Type.GetType("sYSTem.iNT32", True, False)
            Console.WriteLine(myType2.FullName)
         Catch e As TypeLoadException
            Console.WriteLine(e.Message)
' </Snippet4>
         Catch e As Exception
            Console.WriteLine(e.Message)
         End Try
      End Sub 'Main
   End Class 'MyClass1
End Namespace 'TypeCodeNamespace
