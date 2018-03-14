' <Snippet1>
Imports System.Reflection

Public Module Example
   ' Mark OldProperty As Obsolete.
   <ObsoleteAttribute("This property is obsolete. Use NewProperty instead.", False)> 
   Public ReadOnly Property OldProperty As String
      Get
         Return "The old property value."
      End Get
   End Property
   
   Public ReadOnly Property NewProperty As String
      Get
         Return "The new property value."
      End Get
   End Property
   
   ' Mark OldMethod As Obsolete.
   <ObsoleteAttribute("This method is obsolete. Call NewMethod instead.", True)> 
   Public Function OldMethod() As String
      Return "You have called OldMethod."
   End Function
      
   Public Function NewMethod() As String   
      Return "You have called NewMethod."
   End Function   
   
   Public Sub Main()
      ' Get all public members of this type.
      Dim members() As MemberInfo = GetType(Example).GetMembers()
      ' Count total obsolete members.
      Dim n As Integer = 0
      
      ' Try to get the ObsoleteAttribute for each public member.
      Console.WriteLine("Obsolete members in the Example class:")
      Console.WriteLine()
      For Each member In members
         Dim attribs() As ObsoleteAttribute = CType(member.GetCustomAttributes(GetType(ObsoleteAttribute), 
                                                                             False), ObsoleteAttribute())
         If attribs.Length > 0 Then
            Dim attrib As ObsoleteAttribute = attribs(0)
            Console.WriteLine("Member Name: {0}.{1}", member.DeclaringType.FullName, member.Name)
            Console.WriteLine("   Message: {0}", attrib.Message)             
            Console.WriteLine("   Warning/Error: {0}", if(attrib.IsError, "Error", "Warning"))      
            n += 1
         End If
      Next
      
      If n = 0 Then
         Console.WriteLine("The Example type has no obsolete attributes.")
      End If 
   End Sub  
End Module
' The example displays the following output:
'       Obsolete members in the Example class:
'       
'       Member Name: Example.OldMethod
'          Message: This method is obsolete. Call NewMethod instead.
'          Warning/Error: Error
'       Member Name: Example.OldProperty
'          Message: This property is obsolete. Use NewProperty instead.
'          Warning/Error: Warning
' </Snippet1>
