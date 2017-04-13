'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Data
Imports System.Diagnostics
Imports System.Reflection
Imports System.Windows.Forms

' Provides an example control that functions in design mode to 
' demonstrate use of the IToolboxService to list and select toolbox 
' categories and items, and to add components or controls 
' to the parent form using code.
<DesignerAttribute(GetType(WindowMessageDesigner), GetType(IDesigner))> _
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class IToolboxServiceControl
    Inherits System.Windows.Forms.UserControl

    Private WithEvents listBox1 As System.Windows.Forms.ListBox
    Private listBox2 As System.Windows.Forms.ListBox
    Private toolboxService As IToolboxService = Nothing
    Private tools As ToolboxItemCollection
    Private controlSpacingMultiplier As Integer

    Public Sub New()
        InitializeComponent()
        AddHandler listBox2.DoubleClick, AddressOf Me.CreateComponent
        controlSpacingMultiplier = 0
    End Sub

    ' Obtain or reset IToolboxService reference on each siting of control.
    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal Value As System.ComponentModel.ISite)
            MyBase.Site = Value

            ' If the component was sited, attempt to obtain 
            ' an IToolboxService instance.
            If (MyBase.Site IsNot Nothing) Then
                toolboxService = CType(Me.GetService(GetType(IToolboxService)), IToolboxService)
                ' If an IToolboxService instance was located, update the 
                ' category list.
                If (toolboxService IsNot Nothing) Then
                    UpdateLists()
                End If
            Else
                toolboxService = Nothing
            End If
        End Set
    End Property

    ' Updates the list of categories and the list of items in the 
    ' selected category.
    Private Sub UpdateLists()
        If (toolboxService IsNot Nothing) Then
            RemoveHandler listBox1.SelectedIndexChanged, AddressOf Me.UpdateSelectedCategory
            RemoveHandler listBox2.SelectedIndexChanged, AddressOf Me.UpdateSelectedItem
            listBox1.Items.Clear()
            Dim i As Integer
            For i = 0 To toolboxService.CategoryNames.Count - 1
                listBox1.Items.Add(toolboxService.CategoryNames(i))
                If toolboxService.CategoryNames(i) = toolboxService.SelectedCategory Then
                    listBox1.SelectedIndex = i
                    tools = toolboxService.GetToolboxItems(toolboxService.SelectedCategory)
                    listBox2.Items.Clear()
                    Dim j As Integer
                    For j = 0 To tools.Count - 1
                        listBox2.Items.Add(tools(j).DisplayName)
                    Next j
                End If
            Next i
            AddHandler Me.listBox1.SelectedIndexChanged, AddressOf Me.UpdateSelectedCategory
            AddHandler Me.listBox2.SelectedIndexChanged, AddressOf Me.UpdateSelectedItem
        End If
    End Sub

    ' Sets the selected category when a category is clicked in the 
    ' category list.
    Private Sub UpdateSelectedCategory(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.SelectedIndexChanged
        If (toolboxService IsNot Nothing) Then
            toolboxService.SelectedCategory = CStr(listBox1.SelectedItem)
            UpdateLists()
        End If
    End Sub

    ' Sets the selected item when an item is clicked in the item list.
    Private Sub UpdateSelectedItem(ByVal sender As Object, ByVal e As System.EventArgs)
        If (toolboxService IsNot Nothing) Then
            If listBox1.SelectedIndex <> -1 Then
                If CStr(listBox1.SelectedItem) = toolboxService.SelectedCategory Then
                    toolboxService.SetSelectedToolboxItem(tools(listBox2.SelectedIndex))
                Else
                    UpdateLists()
                End If
            End If
        End If
    End Sub

    ' Creates a control from a double-clicked toolbox item and adds 
    ' it to the parent form.
    Private Sub CreateComponent(ByVal sender As Object, ByVal e As EventArgs)

        ' Obtains an IDesignerHost service from design environment.
        Dim host As IDesignerHost = CType(Me.GetService(GetType(IDesignerHost)), IDesignerHost)

        ' Gets the project components container. (Windows Forms control 
        ' containment depends on controls collections).
        Dim container As IContainer = host.Container

        ' Identifies the parent Form.
        Dim parentForm As System.Windows.Forms.Form = Me.FindForm()

        ' Retrieves the parent Form's designer host.
        Dim parentHost As IDesignerHost = CType(parentForm.Site.GetService(GetType(IDesignerHost)), IDesignerHost)

        ' Create the components.
        Dim comps As IComponent() = Nothing
        Try
            comps = toolboxService.GetSelectedToolboxItem().CreateComponents(parentHost)
        Catch ex As Exception
            ' Catch and show any exceptions to prevent 
            ' disabling the control's UI.
            MessageBox.Show(ex.ToString(), "Exception message")
        End Try

        If comps Is Nothing Then
            Return
        End If

        ' Add any created controls to the parent form's controls 
        ' collection. Note: components are added from the 
        ' ToolboxItem.CreateComponents(IDesignerHost) method.
        Dim i As Integer
        For i = 0 To comps.Length - 1
            If (parentForm IsNot Nothing) AndAlso CType(comps(i), Object).GetType().IsSubclassOf(GetType(System.Windows.Forms.Control)) Then
                CType(comps(i), System.Windows.Forms.Control).Location = New Point(20 * controlSpacingMultiplier, 20 * controlSpacingMultiplier)
                If controlSpacingMultiplier > 10 Then
                    controlSpacingMultiplier = 0
                Else
                    controlSpacingMultiplier += 1
                End If
                parentForm.Controls.Add(CType(comps(i), System.Windows.Forms.Control))
            End If
        Next i
    End Sub

    ' Displays labels.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawString("IToolboxService Control", New Font("Arial", 14), New SolidBrush(Color.Black), 6, 4)
        e.Graphics.DrawString("Category List", New Font("Arial", 8), New SolidBrush(Color.Black), 8, 26)
        e.Graphics.DrawString("Items in Category", New Font("Arial", 8), New SolidBrush(Color.Black), 208, 26)
        e.Graphics.DrawString("(Double-click item to add to parent form)", New Font("Arial", 7), New SolidBrush(Color.Black), 232, 12)
    End Sub

    Private Sub InitializeComponent()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.listBox2 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        Me.listBox1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
        Me.listBox1.Location = New System.Drawing.Point(8, 41)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(192, 368)
        Me.listBox1.TabIndex = 0
        Me.listBox2.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.listBox2.Location = New System.Drawing.Point(208, 41)
        Me.listBox2.Name = "listBox2"
        Me.listBox2.Size = New System.Drawing.Size(228, 368)
        Me.listBox2.TabIndex = 3
        Me.BackColor = System.Drawing.Color.Beige
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.listBox2, Me.listBox1})
        Me.Location = New System.Drawing.Point(500, 400)
        Me.Name = "IToolboxServiceControl"
        Me.Size = New System.Drawing.Size(442, 422)
        Me.ResumeLayout(False)
    End Sub

End Class

' This designer passes window messages to the controls at design time.    
Public Class WindowMessageDesigner
    Inherits System.Windows.Forms.Design.ControlDesigner

    Public Sub New()
    End Sub

    ' Window procedure override passes events to control.
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.HWnd.Equals(Me.Control.Handle) Then
            MyBase.WndProc(m)
        Else
            Me.DefWndProc(m)
        End If
    End Sub

End Class
'</Snippet1>
