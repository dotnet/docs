Imports System
Imports System.CodeDom

Public Class Class1

    Public Shared Function GetCompileUnit() As CodeCompileUnit
        Dim cu As New CodeCompileUnit()

        Dim nsp As New CodeNamespace("TestNamespace")
        cu.Namespaces.Add(nsp)

        Dim testType As New CodeTypeDeclaration("testType")
        nsp.Types.Add(testType)

        '<Snippet1>
        ' This example demonstrates declaring a public constant type member field.
        ' When declaring a public constant type member field, you must set a particular
        ' access and scope mask to the member attributes of the field in order for the
        ' code generator to properly generate the field as a constant field.
        ' Declares an integer field using a CodeMemberField
        Dim constPublicField As New CodeMemberField(GetType(Integer), "testConstPublicField")

        ' Resets the access and scope mask bit flags of the member attributes of the field
        ' before setting the member attributes of the field to public and constant.
        constPublicField.Attributes = constPublicField.Attributes And Not MemberAttributes.AccessMask And Not MemberAttributes.ScopeMask Or MemberAttributes.Public Or MemberAttributes.Const
        '</Snippet1>
        testType.Members.Add(constPublicField)
        Return cu
    End Function
End Class