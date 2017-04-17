' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Reflection

Public Class TestClass
   Public Sub DisplayValue(s As String)
      Console.WriteLine(s)
   End Sub
   
   Public Sub DisplayValue(s As String, ParamArray values() As Object)
      Console.WriteLine(s, values)
   End Sub
   
   Public Overloads Shared Function Equals(t1 As TestClass, t2 As TestClass) As Boolean
      Return Object.ReferenceEquals(t1, t2)
   End Function
   
   Public Overloads Function Equals(t As TestClass) As Boolean
      Return Object.ReferenceEquals(Me, t)
   End Function          
End Class

Module Example
   Public Sub Main()
      Dim t As Type = GetType(TestClass)
      
      RetrieveMethod(t, "DisplayValue", BindingFlags.Public Or BindingFlags.Instance)

      RetrieveMethod(t, "Equals", BindingFlags.Public Or BindingFlags.Instance)
      
      RetrieveMethod(t, "Equals", BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
      
      RetrieveMethod(t, "Equals", BindingFlags.Public Or BindingFlags.Static)
   End Sub
   
   Public Sub RetrieveMethod(t As Type, name As String, flags As BindingFlags)
      Try
         Dim m As MethodInfo = t.GetMethod(name, flags)
         If m IsNot Nothing Then
            Console.Write("{0}.{1}(", t.Name, m.Name)
           Dim parms() As ParameterInfo = m.GetParameters()
            For ctr As Integer = 0 To parms.Length - 1
               Console.Write(parms(ctr).ParameterType.Name)
               if ctr < parms.Length - 1 Then 
                  Console.Write(", ")
               End If      
            Next
            Console.WriteLine(")")
         Else
            Console.WriteLine("Method not found")
         End If
      Catch e As AmbiguousMatchException
         Console.WriteLine("The following duplicate matches were found:")
         Dim methods() As MethodInfo = t.GetMethods(flags)
         For Each method In methods
            If method.Name <> name Then Continue For

            Console.Write("   {0}.{1}(", t.Name, method.Name)
            Dim parms() As ParameterInfo = method.GetParameters()
            For ctr As Integer = 0 To parms.Length - 1
               Console.Write(parms(ctr).ParameterType.Name)
               if ctr < parms.Length - 1 Then 
                  Console.Write(", ")
               End If      
            Next
            Console.WriteLine(")")
         Next 
      End Try         
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'       The following duplicate matches were found:
'          TestClass.DisplayValue(String)
'          TestClass.DisplayValue(String, Object[])
'       
'       The following duplicate matches were found:
'          TestClass.Equals(TestClass)
'          TestClass.Equals(Object)
'       
'       TestClass.Equals(TestClass)
'       
'       TestClass.Equals(TestClass, TestClass)
' </Snippet2>
