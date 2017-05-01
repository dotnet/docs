Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Namespace ExampleControl
    '<Snippet1>
    <DesignerSerializerAttribute(GetType(ExampleSerializer), GetType(CodeDomSerializer))> _
     Public Class ExampleControl
        Inherits System.Windows.Forms.UserControl

        Public Sub New()
        End Sub
    End Class   
    '</Snippet1>

    Public Class ExampleSerializer
        Inherits System.ComponentModel.Design.Serialization.CodeDomSerializer

        Public Sub New()
        End Sub 'New

        Public Overrides Function Deserialize(ByVal manager As System.ComponentModel.Design.Serialization.IDesignerSerializationManager, ByVal codeObject As Object) As Object
            Return Nothing
        End Function 'Deserialize

        Public Overrides Function Serialize(ByVal manager As System.ComponentModel.Design.Serialization.IDesignerSerializationManager, ByVal value As Object) As Object
            Return Nothing
        End Function 'Serialize

    End Class 'ExampleSerializer

End Namespace 'ExampleControl 