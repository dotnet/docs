<ObfuscationAttribute(Exclude:=True, ApplyToMembers:=False)> _
Public Class Type2

    ' The exclusion of the type is not applied to its members,
    ' however in order to mark the member with the "default" 
    ' feature it is necessary to specify Exclude:=False,
    ' because the default value of Exclude is True. The tool
    ' should not strip this attribute after obfuscation.
    <ObfuscationAttribute(Exclude:=False, _
        Feature:="default", StripAfterObfuscation:=False)> _
    Public Sub MethodA()
    End Sub

    ' This member is marked for obfuscation, because the 
    ' exclusion of the type is not applied to its members.
    Public Sub MethodB()
    End Sub

End Class