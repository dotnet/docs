' Completely rewrote sample 2/15/06 GlennHa
' <Snippet1>
Imports System
Imports System.Reflection

Public class Example

    Public f_Public As Integer
    Friend f_Friend As Integer 
    Protected f_Protected As Integer
    Protected Friend f_Protected_Friend As Integer

    Public Shared Sub Main()
    
        Console.WriteLine(vbCrLf & _
            "{0,-30}{1,-18}{2}", "", "IsAssembly", "IsFamilyOrAssembly") 
        Console.WriteLine("{0,-21}{1,-18}{2,-18}{3}" & vbCrLf, _
            "", "IsPublic", "IsFamily", "IsFamilyAndAssembly")
   
        For Each f As FieldInfo In GetType(Example).GetFields( _
            BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public)
        
            Console.WriteLine("{0,-21}{1,-9}{2,-9}{3,-9}{4,-9}{5,-9}", _
                f.Name, _
                f.IsPublic, _
                f.IsAssembly, _
                f.IsFamily, _
                f.IsFamilyOrAssembly, _
                f.IsFamilyAndAssembly _
            )
        Next
    End Sub
End Class

' This code example produces output similar to the following:
'
'                              IsAssembly        IsFamilyOrAssembly
'                     IsPublic          IsFamily          IsFamilyAndAssembly
'
'f_Public             True     False    False    False    False
'f_Friend             False    True     False    False    False
'f_Protected          False    False    True     False    False
'f_Protected_Friend   False    False    False    True     False
' </Snippet1>

