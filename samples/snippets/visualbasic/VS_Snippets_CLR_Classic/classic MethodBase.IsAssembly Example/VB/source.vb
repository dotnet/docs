' Completely rewrote sample 2/15/06 GlennHa
' <Snippet1>
Imports System
Imports System.Reflection

Public class Example

    Public Sub m_Public() 
    End Sub
    Friend Sub m_Friend() 
    End Sub
    Protected Sub m_Protected() 
    End Sub
    Protected Friend Sub m_Protected_Friend() 
    End Sub

    Public Shared Sub Main()
    
        Console.WriteLine(vbCrLf & _
            "{0,-30}{1,-18}{2}", "", "IsAssembly", "IsFamilyOrAssembly") 
        Console.WriteLine("{0,-21}{1,-18}{2,-18}{3}" & vbCrLf, _
            "", "IsPublic", "IsFamily", "IsFamilyAndAssembly")
   
        For Each m As MethodBase In GetType(Example).GetMethods( _
            BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public)
        
            If Left(m.Name, 1) = "m"
            
                Console.WriteLine("{0,-21}{1,-9}{2,-9}{3,-9}{4,-9}{5,-9}", _
                    m.Name, _
                    m.IsPublic, _
                    m.IsAssembly, _
                    m.IsFamily, _
                    m.IsFamilyOrAssembly, _
                    m.IsFamilyAndAssembly _
                )
            End If
        Next
    End Sub
End Class

' This code example produces output similar to the following:
'
'                              IsAssembly        IsFamilyOrAssembly
'                     IsPublic          IsFamily          IsFamilyAndAssembly
'
'm_Public             True     False    False    False    False
'm_Friend             False    True     False    False    False
'm_Protected          False    False    True     False    False
'm_Protected_Friend   False    False    False    True     False
' </Snippet1>

