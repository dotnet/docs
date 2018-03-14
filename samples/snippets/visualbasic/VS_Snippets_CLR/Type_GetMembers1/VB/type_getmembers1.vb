' System.Type.GetMembers()
' This program demonstrates GetMembers() method of System.Type Class.
' Get the members (properties, methods, fields, events, and so on)
' of the class 'MyClass' and displays the same to the console.     


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

Class Type_GetMembers
   
   Public Shared Sub Main()
      Try
         Dim myObject As New [MyClass]()
         Dim myMemberInfo() As MemberInfo
         
         ' Get the type of 'MyClass'.
         Dim myType As Type = myObject.GetType()
         
         ' Get the information related to all public member's of 'MyClass'. 
         myMemberInfo = myType.GetMembers()
         
         Console.WriteLine(ControlChars.Cr + "The members of class '{0}' are :" + ControlChars.Cr, myType)
         Dim i As Integer
         For i = 0 To myMemberInfo.Length - 1
            ' Display name and type of the concerned member.
            Console.WriteLine("'{0}' is a {1}", myMemberInfo(i).Name, myMemberInfo(i).MemberType)
         Next i

      Catch e As SecurityException
         Console.WriteLine(("Exception : " + e.Message.ToString()))
      End Try
   End Sub 'Main
End Class 'Type_GetMembers
' </Snippet1>