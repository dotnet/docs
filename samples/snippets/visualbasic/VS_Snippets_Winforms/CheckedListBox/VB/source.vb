'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form
    private insideCheckEveryOther as boolean

    Public Sub New()
        MyBase.New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents WhatIsChecked As System.Windows.Forms.Button
    Friend WithEvents CheckEveryOther As System.Windows.Forms.Button

    ' Required method for Designer support.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.WhatIsChecked = New System.Windows.Forms.Button()
        Me.CheckEveryOther = New System.Windows.Forms.Button()
        Me.SuspendLayout()

        ' CheckedListBox1
        Me.CheckedListBox1.Items.AddRange(New Object() {"one", "two", "three", "four", _
                                                        "five", "six", "seven", "eight", _
                                                        "nine", "ten"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(10, 25)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(158, 139)
        Me.CheckedListBox1.TabIndex = 0

        ' WhatIsChecked
        Me.WhatIsChecked.Location = New System.Drawing.Point(178, 27)
        Me.WhatIsChecked.Name = "WhatIsChecked"
        Me.WhatIsChecked.Size = New System.Drawing.Size(106, 23)
        Me.WhatIsChecked.TabIndex = 1
        Me.WhatIsChecked.Text = "What is checked?"

        ' CheckEveryOther
        Me.CheckEveryOther.Location = New System.Drawing.Point(178, 59)
        Me.CheckEveryOther.Name = "CheckEveryOther"
        Me.CheckEveryOther.Size = New System.Drawing.Size(106, 23)
        Me.CheckEveryOther.TabIndex = 2
        Me.CheckEveryOther.Text = "Check every other"

        ' Form1
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckedListBox1, _
                                                                 Me.WhatIsChecked, _
                                                                 Me.CheckEveryOther})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    '<Snippet2>
    Private Sub WhatIsChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhatIsChecked.Click
        ' Display in a message box all the items that are checked.
        Dim indexChecked As Integer
        Dim itemChecked As Object
        Const quote As String = """"

        ' First show the index and check state of all selected items.
        For Each indexChecked In CheckedListBox1.CheckedIndices
            ' The indexChecked variable contains the index of the item.
            MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" + _
                            CheckedListBox1.GetItemCheckState(indexChecked).ToString() + ".")
        Next

        ' Next show the object title and check state for each item selected.
        For Each itemChecked In CheckedListBox1.CheckedItems

            ' Use the IndexOf method to get the index of an item.
            MessageBox.Show("Item with title: " + quote + itemChecked.ToString() + quote + _
                            ", is checked. Checked state is: " + _
                            CheckedListBox1.GetItemCheckState(CheckedListBox1.Items.IndexOf(itemChecked)).ToString() + ".")
        Next

    End Sub
    '</Snippet2>

    '<Snippet4>
    '<Snippet3>
    Private Sub CheckEveryOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEveryOther.Click
        ' Cycle through every item and check every other.
        Dim i As Integer

        ' Set flag to true to know when this code is being executed. Used in the ItemCheck
        ' event handler.
        insideCheckEveryOther = True

        For i = 0 To CheckedListBox1.Items.Count - 1
            ' For every other item in the list, set as checked.

            If ((i Mod 2) = 0) Then
                ' But for each other item that is to be checked, set as being in an
                ' indeterminate checked state.

                If ((i Mod 4) = 0) Then
                    CheckedListBox1.SetItemCheckState(i, CheckState.Indeterminate)
                Else
                    CheckedListBox1.SetItemChecked(i, True)
                End If
            End If
        Next

        insideCheckEveryOther = False

    End Sub
    '</Snippet3>
    Private Sub CheckedListBox1_ItemCheck(ByVal sender As System.Object, ByVal e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        ' An item in the CheckedListBox is being checked or unchecked.
        ' Set the NewValue based upon the CurrentValue to allow for a tri-state checking.

        ' If the ItemCheck event is due to the code in CheckEveryOther, 
        ' then exit the sub.
        If insideCheckEveryOther Then Exit Sub

        ' Set the NewValue based upon the CurrentValue to allow for a tri-state checking.

        If (e.CurrentValue = CheckState.Unchecked) Then
            e.NewValue = CheckState.Indeterminate
        ElseIf (e.CurrentValue = CheckState.Indeterminate) Then
            e.NewValue = CheckState.Checked
        ElseIf (e.CurrentValue = CheckState.Checked) Then
            e.NewValue = CheckState.Unchecked
        End If
    End Sub
    '</Snippet4>


End Class
'</Snippet1>
