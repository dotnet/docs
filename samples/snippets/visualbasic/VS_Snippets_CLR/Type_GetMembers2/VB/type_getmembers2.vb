' System.Type.GetMembers(BindingFlags)

' This program demonstrates 'GetMembers(BindingFlags)' method of 
' System.Type Class. This will get all the public instance members
' declared or inherited by this type and displays the members to
' the console.

Imports System
Imports System.Reflection
Imports System.Security
Imports Microsoft.VisualBasic

' <Snippet1>
Class [MyClass]
   Public myInt As Integer = 0
   Public myString As String = Nothing
   
   
   Public Sub New()
   End Sub 'New
   
   Public Sub Myfunction()
   End Sub 'Myfunction
End Class '[MyClass]

Class Type_GetMembers_BindingFlags
   
   Public Shared Sub Main()
      Try
         Dim MyObject As New [MyClass]()
         Dim myMemberInfo() As MemberInfo
         
         ' Get the type of the class 'MyClass'.
         Dim myType As Type = MyObject.GetType()
         
         ' Get the public instance members of the class 'MyClass'. 
         myMemberInfo = myType.GetMembers((BindingFlags.Public Or BindingFlags.Instance))
         
         Console.WriteLine(ControlChars.Cr + "The public instance members of class '{0}' are : " + ControlChars.Cr, myType)
         Dim i As Integer
         For i = 0 To myMemberInfo.Length - 1
            ' Display name and type of the member of 'MyClass'.
            Console.WriteLine("'{0}' is a {1}", myMemberInfo(i).Name, myMemberInfo(i).MemberType)
         Next i
      
      Catch e As SecurityException
         Console.WriteLine(("SecurityException : " + e.Message.ToString()))
      End Try


      'Output:
      'The public instance members of class 'MyClass' are :

      ''Myfunction' is a Method
      ''ToString' is a Method
      ''Equals' is a Method
      ''GetHashCode' is a Method
      ''GetType' is a Method
      ''.ctor' is a Constructor
      ''myInt' is a Field
      ''myString' is a Field


   End Sub 'Main 
End Class 'Type_GetMembers_BindingFlags
' </Snippet1>      

