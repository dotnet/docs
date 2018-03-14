Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text


Namespace ListViewAfterLabelEditEx
    _
   '/ <summary>
   '/ Summary description for Form1.
   '/ </summary>
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents listView1 As System.Windows.Forms.ListView
      '/ <summary>
      '/ Required designer variable.
      '/ </summary>
      Private components As System.ComponentModel.Container = Nothing


      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub 'New

      Private Sub InitializeComponent()
         Dim listViewItem1 As New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Item A", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte)))}, -1)
         Dim listViewItem2 As New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Item B", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte)))}, -1)
         Dim listViewItem3 As New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Item C", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte)))}, -1)
         Dim listViewItem4 As New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Item D", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte)))}, -1)
         Me.listView1 = New System.Windows.Forms.ListView()
         Me.SuspendLayout()
         ' 
         ' listView1
         ' 
         Me.listView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem1, listViewItem2, listViewItem3, listViewItem4})
         Me.listView1.LabelEdit = True
         Me.listView1.Location = New System.Drawing.Point(16, 24)
         Me.listView1.Name = "listView1"
         Me.listView1.Size = New System.Drawing.Size(424, 328)
         Me.listView1.TabIndex = 0
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(464, 422)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.listView1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent

      '<Snippet1>
      Private Sub MyListView_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles listView1.AfterLabelEdit

         ' Determine if label is changed by checking to see if it is equal to Nothing.
         If e.Label Is Nothing Then
            Return
         End If
         ' ASCIIEncoding is used to determine if a number character has been entered.
         Dim AE As New ASCIIEncoding()
         ' Convert the new label to a character array.
         Dim temp As Char() = e.Label.ToCharArray()

         ' Check each character in the new label to determine if it is a number.
         Dim x As Integer
         For x = 0 To temp.Length - 1
            ' Encode the character from the character array to its ASCII code.
            Dim bc As Byte() = AE.GetBytes(temp(x).ToString())

            ' Determine if the ASCII code is within the valid range of numerical values.
            If bc(0) > 47 And bc(0) < 58 Then
               ' Cancel the event and return the lable to its original state.
               e.CancelEdit = True
               ' Display a MessageBox alerting the user that numbers are not allowed.
               MessageBox.Show("The text for the item cannot contain numerical values.")
               ' Break out of the loop and exit.
               Return
            End If
         Next x
      End Sub
      '</Snippet1>
   End Class
End Namespace