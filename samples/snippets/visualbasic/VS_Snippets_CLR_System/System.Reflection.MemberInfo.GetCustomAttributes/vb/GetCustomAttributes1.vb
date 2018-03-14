' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class BaseClass
   <ThreadStatic> Public total As Integer
   
   <CLSCompliant(False)> Public Overridable Function MethodA() As UInt32
      Return CUInt(100)
   End Function
End Class

Public Class DerivedClass : Inherits BaseClass
   Public Overrides Function MethodA() As UInt32
      total += 1
      Return 200
   End Function
End Class

Module Example
   Public Sub Main()
      Dim t As Type = GetType(DerivedClass)
      Console.WriteLine("Members of {0}:", t.FullName)
      For Each m In t.GetMembers()
         Dim hasAttribute As Boolean = False
         Console.Write("   {0}: ", m.Name)
         If m.GetCustomAttributes(GetType(CLSCompliantAttribute), True).Length > 0 Then
            Console.Write("CLSCompliant")
            hasAttribute = True
         End If
         If m.GetCustomAttributes(GetType(ThreadStaticAttribute), True).Length > 0 Then
            Console.Write("ThreadStatic")
            hasAttribute = True
         End If
         If Not hasAttribute Then
            Console.Write("No attributes")
         End If
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       Members of DerivedClass:
'          MethodA: CLSCompliant
'          ToString: No attributes
'          Equals: No attributes
'          GetHashCode: No attributes
'          GetType: No attributes
'          .ctor: No attributes
'          total: ThreadStatic
' </Snippet1>
