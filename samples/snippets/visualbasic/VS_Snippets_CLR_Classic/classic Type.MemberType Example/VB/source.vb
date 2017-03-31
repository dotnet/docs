Imports System
Imports System.Reflection

Public Class Sample    
   
    Public Sub Method(t As Type, mi As MemberInfo)        
' <Snippet1>
      Dim others As MemberInfo() = t.GetMember(mi.Name, mi.MemberType, _
      BindingFlags.Public Or BindingFlags.Static Or BindingFlags.NonPublic _
      Or BindingFlags.Instance)
' </Snippet1>
    End Sub

    Public Shared Sub Main()
    End Sub
End Class
