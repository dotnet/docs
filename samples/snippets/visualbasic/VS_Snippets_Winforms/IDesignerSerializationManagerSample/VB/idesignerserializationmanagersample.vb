
'<snippet1>
Imports System
Imports System.CodeDom
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing
Imports System.Windows.Forms

Namespace CodeDomSerializerSample
   Friend Class MyCodeDomSerializer
      Inherits CodeDomSerializer

      Public Overrides Function Deserialize(ByVal manager As IDesignerSerializationManager, _
                                                ByVal codeObject As Object) As Object
         ' This is how we associate the component with the serializer.
         Dim baseClassSerializer As CodeDomSerializer = CType(manager.GetSerializer( _
                GetType(MyComponent).BaseType, GetType(CodeDomSerializer)), CodeDomSerializer)

         ' This is the simplest case, in which the class just calls the base class
         '  to do the work. 
         Return baseClassSerializer.Deserialize(manager, codeObject)
      End Function 'Deserialize

      Public Overrides Function Serialize(ByVal manager As IDesignerSerializationManager, _
                                            ByVal value As Object) As Object
         ' Associate the component with the serializer in the same manner as with
         '  Deserialize
         Dim baseClassSerializer As CodeDomSerializer = CType(manager.GetSerializer( _
                GetType(MyComponent).BaseType, GetType(CodeDomSerializer)), CodeDomSerializer)

         Dim codeObject As Object = baseClassSerializer.Serialize(manager, value)

         ' Anything could be in the codeObject.  This sample operates on a
         '  CodeStatementCollection.
         If TypeOf codeObject Is CodeStatementCollection Then
            Dim statements As CodeStatementCollection = CType(codeObject, CodeStatementCollection)

            ' The code statement collection is valid, so add a comment.
            Dim commentText As String = "This comment was added to this object by a custom serializer."
            Dim comment As New CodeCommentStatement(commentText)
            statements.Insert(0, comment)
         End If
         Return codeObject
      End Function 'Serialize
   End Class 'MyCodeDomSerializer

'<Snippet2>
   <DesignerSerializer(GetType(MyCodeDomSerializer), GetType(CodeDomSerializer))> _
   Public Class MyComponent
      Inherits Component
      Private localProperty As String = "Component Property Value"

      Public Property LocalProp() As String
         Get
            Return localProperty
         End Get
         Set(ByVal Value As String)
            localProperty = Value
         End Set
      End Property
   End Class 'MyComponent
'</Snippet2>

End Namespace
'</snippet1>

Namespace CodeDomSerializerSample
   Class CodeDomSerializerStart
      Public Shared Sub Main()
      End Sub 'Main
   End Class 'CodeDomSerializerStart
End Namespace 'CodeDomSerializerSample
