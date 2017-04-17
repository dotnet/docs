' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Runtime.InteropServices

<Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")>
Module Example
   Public Sub Main()
      Dim guidAttr As GuidAttribute = CType(Attribute.GetCustomAttribute(GetType(Example), 
                                                      GetType(GuidAttribute)), GuidAttribute)
      Dim guidValue As Guid = Guid.Parse(guidAttr.Value)
      Dim values() As Object = { Nothing, 16, 
                               Guid.Parse("01e75c83-c6f5-4192-b57e-7427cec5560d"),
                               guidValue }
      For Each value In values
         Try
            Console.WriteLine("{0} and {1}: {2}", guidValue, 
                              If(value Is Nothing, "null", value),
                              guidValue.CompareTo(value))
         Catch e As ArgumentException
            Console.WriteLine("Cannot compare {0} and {1}", guidValue,
                              If(value Is Nothing, "null", value))
         End Try                     
      Next                         
   End Sub
End Module
' The example displays the following output:
'    936da01f-9abd-4d9d-80c7-02af85c822a8 and null: 1
'    Cannot compare 936da01f-9abd-4d9d-80c7-02af85c822a8 and 16
'    936da01f-9abd-4d9d-80c7-02af85c822a8 and 01e75c83-c6f5-4192-b57e-7427cec5560d: 1
'    936da01f-9abd-4d9d-80c7-02af85c822a8 and 936da01f-9abd-4d9d-80c7-02af85c822a8: 0
' </Snippet2>

