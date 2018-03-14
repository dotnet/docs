' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Reflection

<InheritedAttribute> Public Class BaseA
   <InheritedAttribute> Public Overridable Sub MethodA()   
   End Sub
End Class

Public Class DerivedA : Inherits BaseA
   Public Overrides Sub MethodA
   End Sub
End Class 

<NotInheritedAttribute> Public Class BaseB
   <NotInheritedAttribute> Public Overridable Sub MethodB()   
   End Sub
End Class

Public Class DerivedB : Inherits BaseB
   Public Overrides Sub MethodB
   End Sub
End Class 

Module Example
   Public Sub Main()
      Dim typeA As Type = GetType(DerivedA)
      Console.WriteLine("DerivedA has Inherited attribute: {0}", 
                        typeA.GetCustomAttributes(GetType(InheritedAttribute), True).Length > 0) 
      Dim memberA As MethodInfo = typeA.GetMethod("MethodA")
      Console.WriteLine("DerivedA.MemberA has Inherited attribute: {0}", 
                        memberA.GetCustomAttributes(GetType(InheritedAttribute), True).Length > 0) 
      Console.WriteLine()
      
      Dim typeB As Type = GetType(DerivedB)
      Console.WriteLine("DerivedB has Inherited attribute: {0}", 
                        typeB.GetCustomAttributes(GetType(InheritedAttribute), True).Length > 0) 
      Dim memberB As MethodInfo = typeB.GetMethod("MethodB")
      Console.WriteLine("DerivedB.MemberB has Inherited attribute: {0}", 
                        memberB.GetCustomAttributes(GetType(InheritedAttribute), True).Length > 0) 
   End Sub
End Module
' The example displays the following output:
'       DerivedA has Inherited attribute: True
'       DerivedA.MemberA has Inherited attribute: True
'       
'       DerivedB has Inherited attribute: False
'       DerivedB.MemberB has Inherited attribute: False
' </Snippet2>

' <Snippet1>
<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method _ 
                Or AttributeTargets.Property Or AttributeTargets.Field, 
                Inherited := True)>
Public Class InheritedAttribute : Inherits Attribute
End Class

<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method _
                Or AttributeTargets.Property Or AttributeTargets.Field, 
                Inherited := False)>
Public Class NotInheritedAttribute : Inherits Attribute
End Class
' </Snippet1>

