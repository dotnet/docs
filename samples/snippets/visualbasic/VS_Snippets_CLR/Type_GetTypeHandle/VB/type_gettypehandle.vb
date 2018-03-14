' <Snippet1>
Imports System
Imports System.Reflection

Public Class MyClass1
    Private x As Integer = 0
   
    Public Function MyMethod() As Integer
        Return x
    End Function 'MyMethod
End Class 

Public Class MyClass2
   
    Public Shared Sub Main()
        Dim myClass1 As New MyClass1()
      
        ' Get the RuntimeTypeHandle from an object.
        Dim myRTHFromObject As RuntimeTypeHandle = Type.GetTypeHandle(myClass1)
        ' Get the RuntimeTypeHandle from a type.
        Dim myRTHFromType As RuntimeTypeHandle = GetType(MyClass1).TypeHandle
      
        Console.WriteLine(vbLf & "myRTHFromObject.Value:  {0}", _
            myRTHFromObject.Value)
        Console.WriteLine("myRTHFromObject.GetType():  {0}", _
            myRTHFromObject.GetType())
        Console.WriteLine("Get the type back from the handle...")
        Console.WriteLine("Type.GetTypeFromHandle(myRTHFromObject):  {0}", _
            Type.GetTypeFromHandle(myRTHFromObject))

        Console.WriteLine(vbLf & "myRTHFromObject.Equals(myRTHFromType):  {0}", _
            myRTHFromObject.Equals(myRTHFromType))

        Console.WriteLine(vbLf & "myRTHFromType.Value:  {0}", _
            myRTHFromType.Value)
        Console.WriteLine("myRTHFromType.GetType():  {0}", _
            myRTHFromType.GetType())
        Console.WriteLine("Get the type back from the handle...")
        Console.WriteLine("Type.GetTypeFromHandle(myRTHFromType):  {0}", _
            Type.GetTypeFromHandle(myRTHFromType))
    End Sub 
End Class 

' This code example produces output similar to the following:
'
'myRTHFromObject.Value:  7549720
'myRTHFromObject.GetType():  System.RuntimeTypeHandle
'Get the type back from the handle...
'Type.GetTypeFromHandle(myRTHFromObject):  MyClass1
'
'myRTHFromObject.Equals(myRTHFromType):  True
'
'myRTHFromType.Value:  7549720
'myRTHFromType.GetType():  System.RuntimeTypeHandle
'Get the type back from the handle...
'Type.GetTypeFromHandle(myRTHFromType):  MyClass1
' </Snippet1>


