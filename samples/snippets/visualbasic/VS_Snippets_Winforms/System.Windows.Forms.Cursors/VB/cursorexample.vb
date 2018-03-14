'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace MCursor
    
    ' Summary description for Form1.
    Public NotInheritable Class Form1
        Inherits System.Windows.Forms.Form

        Friend WithEvents cursorSelectionComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents testPanel As System.Windows.Forms.Panel

        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private cursorEventViewer As System.Windows.Forms.ListView
        Private label3 As System.Windows.Forms.Label

        <System.STAThread()> _
        Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New Form1)
        End Sub 'Main

        Public Sub New()

            Me.cursorSelectionComboBox = New System.Windows.Forms.ComboBox
            Me.testPanel = New System.Windows.Forms.Panel
            Me.label1 = New System.Windows.Forms.Label
            Me.label2 = New System.Windows.Forms.Label
            Me.cursorEventViewer = New System.Windows.Forms.ListView
            Me.label3 = New System.Windows.Forms.Label

            ' Select Cursor Label
            Me.label2.Location = New System.Drawing.Point(24, 16)
            Me.label2.Size = New System.Drawing.Size(80, 16)
            Me.label2.Text = "Select cursor:"            '

            ' Cursor Testing Panel Label
            Me.label1.Location = New System.Drawing.Point(24, 80)
            Me.label1.Size = New System.Drawing.Size(144, 23)
            Me.label1.Text = "Cursor testing panel:"

            ' Cursor Changed Events Label
            Me.label3.Location = New System.Drawing.Point(184, 16)
            Me.label3.Size = New System.Drawing.Size(128, 16)
            Me.label3.Text = "Cursor changed events:"

            ' Cursor Selection ComboBox
            Me.cursorSelectionComboBox.Location = New System.Drawing.Point(24, 40)
            Me.cursorSelectionComboBox.Size = New System.Drawing.Size(152, 21)
            Me.cursorSelectionComboBox.TabIndex = 0

            ' Cursor Test Panel
            Me.testPanel.BackColor = System.Drawing.SystemColors.ControlDark
            Me.testPanel.Location = New System.Drawing.Point(24, 104)
            Me.testPanel.Size = New System.Drawing.Size(152, 160)

            ' Cursor Event ListView
            Me.cursorEventViewer.Location = New System.Drawing.Point(184, 40)
            Me.cursorEventViewer.Size = New System.Drawing.Size(256, 224)
            Me.cursorEventViewer.TabIndex = 4
            Me.cursorEventViewer.View = System.Windows.Forms.View.List

            ' Set up how the form should be displayed and add the controls to the form.
            Me.ClientSize = New System.Drawing.Size(456, 286)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label3, _
                                    Me.cursorEventViewer, Me.label2, Me.label1, _
                                    Me.testPanel, Me.cursorSelectionComboBox})

            Me.Text = "Cursors Example"

            ' Add all the cursor types to the combobox.
            Dim cursor As Cursor
            For Each cursor In CursorList()
                cursorSelectionComboBox.Items.Add(cursor)
            Next cursor
        End Sub 'New 

        Private Function CursorList() As Cursor()
            ' Make an array of all the types of cursors in Windows Forms.
            return New Cursor() {Cursors.AppStarting, Cursors.Arrow, Cursors.Cross, _
                                 Cursors.Default, Cursors.Hand, Cursors.Help, _
                                 Cursors.HSplit, Cursors.IBeam, Cursors.No, _
                                 Cursors.NoMove2D, Cursors.NoMoveHoriz, Cursors.NoMoveVert, _
                                 Cursors.PanEast, Cursors.PanNE, Cursors.PanNorth, _
                                 Cursors.PanNW, Cursors.PanSE, Cursors.PanSouth, _
                                 Cursors.PanSW, Cursors.PanWest, Cursors.SizeAll, _
                                 Cursors.SizeNESW, Cursors.SizeNS, Cursors.SizeNWSE, _
                                 Cursors.SizeWE, Cursors.UpArrow, Cursors.VSplit, Cursors.WaitCursor}
        End Function

        Private Sub cursorSelectionComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cursorSelectionComboBox.SelectedIndexChanged
            ' Set the cursor in the test panel to be the selected cursor style.
            testPanel.Cursor = CType(cursorSelectionComboBox.SelectedItem, Cursor)

        End Sub 

        Private Sub testPanel_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles testPanel.CursorChanged
            ' Build up a string containing the type of object sending the event, and the event.
            Dim cursorEvent As String = String.Format("[{0}]: {1}", sender.GetType().ToString(), "Cursor changed")

            ' Records this event in the list view.
            Me.cursorEventViewer.Items.Add(cursorEvent)

        End Sub 

    End Class 'Form1
End Namespace 'MCursor
'</Snippet1>
