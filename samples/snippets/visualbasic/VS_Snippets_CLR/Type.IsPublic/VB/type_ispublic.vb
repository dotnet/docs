' <Snippet1>  
Public Class TestClass
End Class

Public Class Example
   Public Shared Sub Main()
      Dim testClassInstance As New TestClass()
      
      ' Get the type of testClassInstance.
      Dim testType As Type = testClassInstance.GetType()
      ' Get the IsPublic property of testClassInstance.
      Dim isPublic As Boolean = testType.IsPublic
      Console.WriteLine("Is {0} public? {1}", testType.FullName, isPublic)
   End Sub 
End Class 
' The example displays the following output:
'       Is TestClass public? True
' </Snippet1>
