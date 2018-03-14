'<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.ComponentModel.Design

'  This sample demonstrates a designer that adds menu commands
'   to the design-time shortcut menu for a component.
'
'   To test this sample, build the code for the component as a class library, 
'   add the resulting component to the toolbox, open a form in design mode, 
'   and drag the component from the toolbox onto the form. 
'
'   The component should appear in the component tray beneath the form. 
'   Right-click the component.  The verbs should appear in the shortcut menu.

Namespace VBDesignerVerb
    ' Associate MyDesigner with this component type using a DesignerAttribute
    <Designer(GetType(MyDesigner))> _
    Public Class Component1
        Inherits System.ComponentModel.Component
    End Class 


    '  This is a designer class which provides designer verb menu commands for 
    '  the associated component. This code is called by the design environment at design-time.    
    Friend Class MyDesigner
        Inherits ComponentDesigner

        Private m_Verbs As DesignerVerbCollection

        ' DesignerVerbCollection is overridden from ComponentDesigner
        Public Overrides ReadOnly Property Verbs() As DesignerVerbCollection
            Get
                If m_Verbs Is Nothing Then
                    ' Create and initialize the collection of verbs
                    m_Verbs = New DesignerVerbCollection()
                    m_Verbs.Add( New DesignerVerb("First Designer Verb", New EventHandler(AddressOf OnFirstItemSelected)) )
                    m_Verbs.Add( New DesignerVerb("Second Designer Verb", New EventHandler(AddressOf OnSecondItemSelected)) )
                End If
                Return m_Verbs
            End Get
        End Property

        Sub New()
        End Sub 

        Private Sub OnFirstItemSelected(ByVal sender As Object, ByVal args As EventArgs)
            ' Display a message
            System.Windows.Forms.MessageBox.Show("The first designer verb was invoked.")
        End Sub 

        Private Sub OnSecondItemSelected(ByVal sender As Object, ByVal args As EventArgs)
            ' Display a message
            System.Windows.Forms.MessageBox.Show("The second designer verb was invoked.")
        End Sub 
    End Class 
End Namespace
'</Snippet1>