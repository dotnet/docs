' This example demonstrates using the following members: 
' ComboBox.FindStringExact(string)
' ComboBox.FindStringExact(string, integer), ComboBox.ObjectCollection.AddRange(),
' ComboBox.ObjectCollection.RemoveAt(), and ComboBox.MaxDropDownItems, 
' and TextBox.ReadOnly.

' CAUTION   This code exposes a known bug: If the index passed to the 
' FindStringExact(searchString, index) method is the last index of the array,
' the code throws an exception.

'<snippet0>
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComboBox()
        InitializeTextBox()
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Use drop-down to choose a name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1)
    End Sub

   
    Friend WithEvents Label1 As System.Windows.Forms.Label
    
    
    
    '<snippet3>

    ' Declare and initialize the text box.
    ' This text box text will be update programmatically. The user is not 
    ' allowed to update it, so the ReadOnly property is set to true.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    Private Sub InitializeTextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox1.ScrollBars = ScrollBars.Vertical
        Me.TextBox1.Location = New System.Drawing.Point(64, 128)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(184, 120)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "Employee and Number of Awards:"
        Me.Controls.Add(Me.TextBox1)
    End Sub
    '</snippet3>

    '<snippet1>

    ' Declare comboBox1 as a ComboBox.
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

    ' This method initializes the combo box, adding a large string 
    ' array but limiting the drop-down size to six rows so the combo box
    ' doesn't cover other controls when it expands.
    Private Sub InitializeComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Dim employees() As String = New String() {"Hamilton, David", _
            "Hensien, Kari", "Hammond, Maria", "Harris, Keith", _
            "Henshaw, Jeff D.", "Hanson, Mark", "Harnpadoungsataya, Sariya", _
            "Harrington, Mark", "Harris, Keith", "Hartwig, Doris", _
            "Harui, Roger", "Hassall, Mark", "Hasselberg, Jonas", _
            "Harnpadoungsataya, Sariya", "Henshaw, Jeff D.", "Henshaw, Jeff D.", _
            "Hensien, Kari", "Harris, Keith", "Henshaw, Jeff D.", _
            "Hensien, Kari", "Hasselberg, Jonas", "Harrington, Mark", _
            "Hedlund, Magnus", "Hay, Jeff", "Heidepriem, Brandon D."}

        ComboBox1.Items.AddRange(employees)
        Me.ComboBox1.Location = New System.Drawing.Point(136, 32)
        Me.ComboBox1.IntegralHeight = False
        Me.ComboBox1.MaxDropDownItems = 5
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 81)
        Me.ComboBox1.TabIndex = 0
        Me.Controls.Add(Me.ComboBox1)
    End Sub


    '</snippet1>

    '<snippet2>
    ' This method is called when the user changes his or her selection.
    ' It searches for all occurrences of the selected employee's
    ' name in the Items array and adds the employee's name and 
    ' the number of occurrences to TextBox1.Text.

    ' CAUTION   This code exposes a known bug: If the index passed to the 
    ' FindStringExact(searchString, index) method is the last index 
    ' of the array, the code throws an exception.
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim comboBox As comboBox = CType(sender, comboBox)

        ' Save the selected employee's name, because we will remove
        ' the employee's name from the list.
        Dim selectedEmployee = CType(ComboBox1.SelectedItem, String)

        Dim count As Integer = 0
        Dim resultIndex As Integer = -1

        ' Call the FindStringExact method to find the first 
        ' occurrence in the list.
        resultIndex = ComboBox1.FindStringExact(ComboBox1.SelectedItem)

        ' Remove the name as it is found, and increment the found count. 
        ' Then call the FindStringExact method again, passing in the index of the
        ' current found item so the search starts there instead of 
        ' at the beginning of the list.
        While (resultIndex <> -1)
            ComboBox1.Items.RemoveAt(resultIndex)
            count += 1
            resultIndex = ComboBox1.FindStringExact _
            (selectedEmployee, resultIndex)
        End While

        ' Update the text in Textbox1.
        TextBox1.Text = TextBox1.Text & Microsoft.VisualBasic.vbCrLf _
            & selectedEmployee & ": " & count
    End Sub
    '</snippet2>

End Class
'</snippet0>
