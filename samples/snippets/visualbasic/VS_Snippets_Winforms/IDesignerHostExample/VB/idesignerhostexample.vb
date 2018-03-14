' <Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms

Namespace IDesignerHostExample
   
   ' IDesignerHostExampleComponent is a component associated 
   ' with the IDesignerHostExampleDesigner that demonstrates 
   ' acquisition and use of the IDesignerHost service 
   ' to list project components.
    <DesignerAttribute(GetType(IDesignerHostExampleDesigner))> _
    Public Class IDesignerHostExampleComponent
        Inherits System.ComponentModel.Component

        Public Sub New()
        End Sub 'New

        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
        End Sub 
    End Class 

    ' You can double-click the component of a IDesignerHostExampleDesigner
    ' to show a form containing a listbox that lists the name and type 
    ' of each component or control in the current design-time project.
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class IDesignerHostExampleDesigner
        Implements IDesigner
        Private component_ As System.ComponentModel.IComponent

        Public Sub New()
        End Sub 'New

        Public Sub DoDefaultAction() Implements IDesigner.DoDefaultAction
            ListComponents()
        End Sub

        Public Sub Initialize(ByVal component As System.ComponentModel.IComponent) Implements IDesigner.Initialize
            Me.component_ = component
            MessageBox.Show("Double-click the IDesignerHostExample component to view a list of project components.")
        End Sub

        ' Displays a list of components in the current design 
        ' document when the default action of the designer is invoked.
        Private Sub ListComponents()

            Using listform As New DesignerHostListForm()

                ' Obtain an IDesignerHost service from the design environment.
                Dim host As IDesignerHost = CType(Me.Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)
                ' Get the project components container (control containment depends on Controls collections)
                Dim container As IContainer = host.Container
                ' Add each component's type name and name to the list box.
                Dim comp As Component
                For Each comp In container.Components
                    listform.listBox1.Items.Add((comp.GetType().Name + " : " + Component.Site.Name))
                Next comp
                ' Display the form.
                listform.ShowDialog()

            End Using

        End Sub

        Public ReadOnly Property Component() As System.ComponentModel.IComponent Implements IDesigner.Component
            Get
                Return component_
            End Get
        End Property

        Public ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection Implements IDesigner.Verbs
            Get
                Dim dvc As New DesignerVerbCollection()
                dvc.Add(New DesignerVerb("List Components", New EventHandler(AddressOf ListHandler)))
                Return dvc
            End Get
        End Property

        Private Sub ListHandler(ByVal sender As Object, ByVal e As EventArgs)
            ListComponents()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
    End Class
    _ 

    ' Provides a form containing a list box that can display 
    ' a list of project components.
    Public Class DesignerHostListForm
        Inherits System.Windows.Forms.Form
        Public listBox1 As System.Windows.Forms.ListBox
        Private ok_button As System.Windows.Forms.Button

        Public Sub New()
            Me.Name = "DesignerHostListForm"
            Me.Text = "List of design-time project components"
            Me.SuspendLayout()
            Me.listBox1 = New System.Windows.Forms.ListBox()
            Me.listBox1.Location = New System.Drawing.Point(8, 8)
            Me.listBox1.Name = "listBox1"
            Me.listBox1.Size = New System.Drawing.Size(385, 238)
            Me.listBox1.TabIndex = 0
            Me.listBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)
            Me.ok_button = New System.Windows.Forms.Button()
            Me.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.ok_button.Location = New System.Drawing.Point(232, 256)
            Me.ok_button.Name = "ok_button"
            Me.ok_button.TabIndex = 1
            Me.ok_button.Text = "OK"
            Me.ok_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.ClientSize = New System.Drawing.Size(400, 285)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ok_button, Me.listBox1})
            Me.ResumeLayout(False)
        End Sub 

        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
        End Sub 
    End Class 
End Namespace 
' </Snippet1>