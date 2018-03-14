'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms

Namespace ExampleComponent

    ' Provides an example component designer.
    Public Class ExampleComponentDesigner
        Inherits System.ComponentModel.Design.ComponentDesigner

        Public Sub New()
        End Sub 'New

        ' This method provides an opportunity to perform processing when a designer is initialized.
        ' The component parameter is the component that the designer is associated with.
        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            ' Always call the base Initialize method in an override of this method.
            MyBase.Initialize(component)
        End Sub 'Initialize

        ' This method is invoked when the associated component is double-clicked.
        Public Overrides Sub DoDefaultAction()
            MessageBox.Show("The event handler for the default action was invoked.")
        End Sub 'DoDefaultAction

        ' This method provides designer verbs.
        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            Get
                Return New DesignerVerbCollection(New DesignerVerb() {New DesignerVerb("Example Designer Verb Command", New EventHandler(AddressOf Me.onVerb))})
            End Get
        End Property

        ' Event handling method for the example designer verb
        Private Sub onVerb(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("The event handler for the Example Designer Verb Command was invoked.")
        End Sub 'onVerb
    End Class 'ExampleComponentDesigner

    ' Provides an example component associated with the example component designer.
    <DesignerAttribute(GetType(ExampleComponentDesigner), GetType(IDesigner))> _
     Public Class ExampleComponent
        Inherits System.ComponentModel.Component

        Public Sub New()
        End Sub 'New
    End Class 'ExampleComponent

End Namespace 'ExampleComponent
'</Snippet1>