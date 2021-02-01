
Imports System

Namespace ca2211

    Public Class SomeStaticFields
        ' Violates rule: AvoidNonConstantStatic;
        ' the field is public and not a literal.
        Public Shared publicField As DateTime = DateTime.Now

        ' Satisfies rule: AvoidNonConstantStatic.
        Public Shared ReadOnly literalField As DateTime = DateTime.Now

        ' Satisfies rule: NonConstantFieldsShouldNotBeVisible;
        ' the field is private.
        Private Shared privateField As DateTime = DateTime.Now
    End Class
End Namespace
