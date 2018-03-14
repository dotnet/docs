' <Snippet2>
Imports System.Reflection

Interface IValue 
   Function GetValue() As Integer 
End Interface
 
Class A : Implements IValue 
   Public Overridable Function GetValue() As Integer _
                               Implements IValue.GetValue 
      Return 0 
   End Function
End Class
 
Class B : Inherits A 
   Public Shadows Function GetValue() As Integer 
      Return 0 
   End Function
End Class
 
Class C : Inherits A 
End Class

Class D : Inherits A
   Public Overrides Function GetValue() As Integer
      Return 0
   End Function
End Class

Public Module Example
   Public Sub Main()
      ' Get members of IValue interface.
      ShowMembersAndDeclaringTypes(GetType(IValue))
      Console.WriteLine()
      ShowMembersAndDeclaringTypes(GetType(A))
      Console.WriteLine()
      ShowMembersAndDeclaringTypes(GetType(B))
      Console.WriteLine()
      ShowMembersAndDeclaringTypes(GetType(C))
      Console.WriteLine()
      ShowMembersAndDeclaringTypes(GetType(D))
      Console.WriteLine()
   End Sub

   Private Sub ShowMembersAndDeclaringTypes(t As Type)
      Dim members() As MemberInfo = t.GetMembers()
      Console.WriteLine("{0} Members: ", t.Name)
      For Each member In members
         Console.WriteLine("   {0}, Declaring type: {1}", 
                           member.Name, member.DeclaringType.Name)
      Next                      
   End Sub
End Module
' The example displays the following output:
'       IValue Members:
'          GetValue, Declaring type: IValue
'       
'       A Members:
'          GetValue, Declaring type: A
'          ToString, Declaring type: Object
'          Equals, Declaring type: Object
'          GetHashCode, Declaring type: Object
'          GetType, Declaring type: Object
'          .ctor, Declaring type: A
'       
'       B Members:
'          GetValue, Declaring type: B
'          GetValue, Declaring type: A
'          ToString, Declaring type: Object
'          Equals, Declaring type: Object
'          GetHashCode, Declaring type: Object
'          GetType, Declaring type: Object
'          .ctor, Declaring type: B
'       
'       C Members:
'          GetValue, Declaring type: A
'          ToString, Declaring type: Object
'          Equals, Declaring type: Object
'          GetHashCode, Declaring type: Object
'          GetType, Declaring type: Object
'          .ctor, Declaring type: C
'       
'       D Members:
'          GetValue, Declaring type: D
'          ToString, Declaring type: Object
'          Equals, Declaring type: Object
'          GetHashCode, Declaring type: Object
'          GetType, Declaring type: Object
'          .ctor, Declaring type: D
' </Snippet2>

