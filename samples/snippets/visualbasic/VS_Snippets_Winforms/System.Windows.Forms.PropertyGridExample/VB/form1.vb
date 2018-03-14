' The following example combines some controls on 
' a form with using a CheckedListBox and PropertyGrid.  
' This method demonstrates the using the PropertyGrid.PropertySort, 
' PropertyGrid.SelectedObjects, CheckedListBox.SelectionMode, 
' and CheckListBox.ThreeDCheckBoxes, and CheckedListBox.CheckOnClick members.

'<snippet3>
' This form combines uses a CheckedListBox and PropertyGrid to 
' combine some controls.  CheckedListBox1 is populated with itself
' and the other controls on the form. The user can then click Button1
' to see the PropertyGrid for the selected controls.

Imports System.Windows.Forms

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1.Location = New System.Drawing.Point(40, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        Me.Label1.Location = New System.Drawing.Point(40, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        Me.Button1.Location = New System.Drawing.Point(40, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 4
        Me.Button1.Size = New Size(100, 50)
        Me.Button1.Text = "Show properties for selected control(s)"
        Me.ClientSize = New System.Drawing.Size(350, 350)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        InitializeCheckedListBox()
        InitializePropertyGrid()


    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    ' This method initializes CheckedListBox1 with a list of all the controls
    ' on the form. It sets the selection mode to single selection and
    ' allows selection with a single click. It adds itself to the list before 
    ' adding itself to the form.
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox

    Private Sub InitializeCheckedListBox()
        Me.CheckedListBox1 = New CheckedListBox
        Me.CheckedListBox1.Location = New System.Drawing.Point(40, 90)
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(120, 94)
        Me.CheckedListBox1.TabIndex = 1
        Me.CheckedListBox1.SelectionMode = SelectionMode.One
        Me.CheckedListBox1.ThreeDCheckBoxes = True

        Dim aControl As Control
        For Each aControl In Me.Controls
            Me.CheckedListBox1.Items.Add(aControl, False)
        Next

        Me.CheckedListBox1.DisplayMember = "Name"
        Me.CheckedListBox1.Items.Add(CheckedListBox1)
        Me.Controls.Add(Me.CheckedListBox1)
    End Sub
    '</snippet1>

    '<snippet2>

    'Declare a propertyGrid.
    Friend WithEvents propertyGrid1 As PropertyGrid

    'Initialize propertyGrid1.
    Private Sub InitializePropertyGrid()
        propertyGrid1 = New PropertyGrid
        propertyGrid1.Name = "PropertyGrid1"
        propertyGrid1.Location = New Point(185, 20)
        propertyGrid1.Size = New System.Drawing.Size(150, 300)
        propertyGrid1.TabIndex = 5

        'Set the sort to alphabetical and set Toolbar visible
        'to false, so the user cannot change the sort.
        propertyGrid1.PropertySort = PropertySort.Alphabetical
        propertyGrid1.ToolbarVisible = False
        propertyGrid1.Text = "Property Grid"

        ' Add the PropertyGrid to the form, but set its
        ' visibility to False so it will not appear when the form loads.
        propertyGrid1.Visible = False
        Me.Controls.Add(propertyGrid1)

    End Sub
    '</snippet2>

    ' Sets the SelectedObjects property of PropertyGrid1's 
    ' SelectedObjects to the controls the user has selected in CheckedListBox1.
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Button1.Click

        propertyGrid1.Visible = True
        Dim selectedControls(CheckedListBox1.CheckedItems.Count - 1) As Control
        Dim counter As Integer
        For counter = 0 To CheckedListBox1.CheckedItems.Count - 1
            selectedControls(counter) = CheckedListBox1.CheckedItems(counter)
        Next
        propertyGrid1.SelectedObjects = selectedControls
    End Sub
    '</snippet3>


End Class
