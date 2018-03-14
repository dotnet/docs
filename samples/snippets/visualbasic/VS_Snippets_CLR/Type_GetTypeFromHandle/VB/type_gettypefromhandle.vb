' System.Type.GetTypeFromHandle(RuntimeTypeHandle)

' The following example demonstrates the 'GetTypeFromHandle(RuntimeTypeHandle)' method
' of the 'Type' Class.
' It defines an empty class 'Myclass1' and obtains an object of 'Myclass1'. Then the runtime handle of 
' the object is obtained and passed as argument to 'GetTypeFromHandle(RuntimeTypeHandle)'method. That 
'  returns the type referenced by the specified type handle.


Imports System
Imports System.Reflection

Public Class MyClass1
End Class 'MyClass1

Public Class MyClass2
   
   Public Shared Sub Main()
' <Snippet1>
      Dim myClass1 As New MyClass1()
      ' Get the type referenced by the specified type handle.
      Dim myClass1Type As Type = Type.GetTypeFromHandle(Type.GetTypeHandle(MyClass1))
      Console.WriteLine(("The Names of the Attributes :" + myClass1Type.Attributes.ToString()))
   End Sub 'Main 
' </Snippet1>
End Class 'MyClass2
