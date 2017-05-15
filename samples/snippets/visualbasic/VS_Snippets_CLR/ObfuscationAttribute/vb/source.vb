' REDMOND\glennha
'<Snippet1>
Imports System.Reflection

' Mark this public assembly for obfuscation.
<Assembly: ObfuscateAssemblyAttribute(False)>

' This class is marked for obfuscation, because the assembly
' is marked.
Public Class Type1

    ' Exclude this method from obfuscation. The default value
    ' of the Exclude property is True, so it is not necessary
    ' to specify Exclude:=True, although spelling it out makes
    ' your intent clearer.
    <ObfuscationAttribute(Exclude:=True)> _
    Public Sub MethodA()
    End Sub

    ' This member is marked for obfuscation because the class
    ' is marked.
    Public Sub MethodB()
    End Sub

End Class

' Exclude this type from obfuscation, but do not apply that
' exclusion to members. The default value of the Exclude 
' property is True, so it is not necessary to specify 
' Exclude:=True, although spelling it out makes your intent 
' clearer.
'<Snippet4>
'<Snippet2>
<ObfuscationAttribute(Exclude:=True, ApplyToMembers:=False)> _
Public Class Type2
'</Snippet2>

    ' The exclusion of the type is not applied to its members,
    ' however in order to mark the member with the "default" 
    ' feature it is necessary to specify Exclude:=False,
    ' because the default value of Exclude is True. The tool
    ' should not strip this attribute after obfuscation.
'<Snippet3>
    <ObfuscationAttribute(Exclude:=False, _
        Feature:="default", StripAfterObfuscation:=False)> _
    Public Sub MethodA()
    End Sub
'</Snippet3>

    ' This member is marked for obfuscation, because the 
    ' exclusion of the type is not applied to its members.
    Public Sub MethodB()
    End Sub

End Class
'</Snippet4>

' This class only exists to provide an entry point for the
' assembly and to display the attribute values.
Friend Class Test

    Public Shared Sub Main()

        ' Display the ObfuscateAssemblyAttribute properties
        ' for the assembly.        
        Dim assem As Assembly =GetType(Test).Assembly
        Dim assemAttrs() As Object = _
            assem.GetCustomAttributes( _
                GetType(ObfuscateAssemblyAttribute), _
                False)

        For Each a As Attribute In assemAttrs
            ShowObfuscateAssembly(CType(a, ObfuscateAssemblyAttribute))
        Next

        ' Display the ObfuscationAttribute properties for each
        ' type that is visible to users of the assembly.
        For Each t As Type In assem.GetTypes()
            If t.IsVisible Then
                Dim tAttrs() As Object = _
                    t.GetCustomAttributes( _
                        GetType(ObfuscationAttribute), _
                        False)

                For Each a As Attribute In tAttrs
                    ShowObfuscation(CType(a, ObfuscationAttribute), _
                        t.Name)
                Next

                ' Display the ObfuscationAttribute properties
                ' for each member in the type.
                For Each m As MemberInfo In t.GetMembers()
                    Dim mAttrs() As Object = _
                        m.GetCustomAttributes( _
                            GetType(ObfuscationAttribute), _
                            False)

                    For Each a As Attribute In mAttrs
                        ShowObfuscation(CType(a, ObfuscationAttribute), _
                            t.Name & "." & m.Name)
                    Next
                Next
            End If
        Next
    End Sub

    Private Shared Sub ShowObfuscateAssembly( _
        ByVal ob As ObfuscateAssemblyAttribute)
        
        Console.WriteLine(vbCrLf & "ObfuscateAssemblyAttribute properties:")
        Console.WriteLine("   AssemblyIsPrivate: " _
            & ob.AssemblyIsPrivate)
        Console.WriteLine("   StripAfterObfuscation: " _
            & ob.StripAfterObfuscation)

    End Sub

    Private Shared Sub ShowObfuscation( _
        ByVal ob As ObfuscationAttribute, _
        ByVal target As String)
        
        Console.WriteLine(vbCrLf _
            & "ObfuscationAttribute properties for: " _
            & target)
        Console.WriteLine("   Exclude: " & ob.Exclude)
        Console.WriteLine("   Feature: " & ob.Feature)
        Console.WriteLine("   StripAfterObfuscation: " _
            & ob.StripAfterObfuscation)
        Console.WriteLine("   ApplyToMembers: " & ob.ApplyToMembers)

    End Sub
End Class

' This code example produces the following output:
'
'ObfuscateAssemblyAttribute properties:
'   AssemblyIsPrivate: False
'   StripAfterObfuscation: True
'
'ObfuscationAttribute properties for: Type1.MethodA
'   Exclude: True
'   Feature: all
'   StripAfterObfuscation: True
'   ApplyToMembers: True
'
'ObfuscationAttribute properties for: Type2
'   Exclude: True
'   Feature: all
'   StripAfterObfuscation: True
'   ApplyToMembers: False
'
'ObfuscationAttribute properties for: Type2.MethodA
'   Exclude: False
'   Feature: default
'   StripAfterObfuscation: False
'   ApplyToMembers: True
'</Snippet1>
