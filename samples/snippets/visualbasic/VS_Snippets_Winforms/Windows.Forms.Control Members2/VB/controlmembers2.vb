Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Namespace ControlMembers3
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private withevents button1 As System.Windows.Forms.Button
      Private withevents mainMenu1 As System.Windows.Forms.MainMenu
      Private withevents menuItemHelp As System.Windows.Forms.MenuItem
      Private withevents menuItemHelpAbout As System.Windows.Forms.MenuItem
      Private withevents buttonNewCustomer As System.Windows.Forms.Button
      Private withevents menuItemEditInsertCustomerInfo As System.Windows.Forms.MenuItem
      Private withevents textBox1 As System.Windows.Forms.TextBox
      Private withevents menuItemEdit As System.Windows.Forms.MenuItem
      Private withevents menuItemEditFontArial As System.Windows.Forms.MenuItem
      Private withevents menuItemEditFontTimeNewRoman As System.Windows.Forms.MenuItem
      Private withevents menuItemEditFont As System.Windows.Forms.MenuItem
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
         Dim cust As New Customer()
         cust.Name = "Microsoft"
         cust.AccountNumber = 123456
         Me.Tag = cust
      End Sub 'New
      
      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.mainMenu1 = New System.Windows.Forms.MainMenu()
         Me.menuItemHelp = New System.Windows.Forms.MenuItem()
         Me.menuItemHelpAbout = New System.Windows.Forms.MenuItem()
         Me.buttonNewCustomer = New System.Windows.Forms.Button()
         Me.menuItemEdit = New System.Windows.Forms.MenuItem()
         Me.menuItemEditInsertCustomerInfo = New System.Windows.Forms.MenuItem()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.menuItemEditFont = New System.Windows.Forms.MenuItem()
         Me.menuItemEditFontArial = New System.Windows.Forms.MenuItem()
         Me.menuItemEditFontTimeNewRoman = New System.Windows.Forms.MenuItem()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(56, 168)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 0
         Me.button1.Text = "New Form"
         ' 
         ' mainMenu1
         ' 
         Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemHelp, Me.menuItemEdit})
         ' 
         ' menuItemHelp
         ' 
         Me.menuItemHelp.Index = 0
         Me.menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemHelpAbout})
         Me.menuItemHelp.Text = "Help"
         ' 
         ' menuItemHelpAbout
         ' 
         Me.menuItemHelpAbout.Index = 0
         Me.menuItemHelpAbout.Text = "About"
         ' 
         ' buttonNewCustomer
         ' 
         Me.buttonNewCustomer.Location = New System.Drawing.Point(144, 168)
         Me.buttonNewCustomer.Name = "buttonNewCustomer"
         Me.buttonNewCustomer.Size = New System.Drawing.Size(72, 24)
         Me.buttonNewCustomer.TabIndex = 1
         Me.buttonNewCustomer.Text = "New Customer"
         ' 
         ' menuItemEdit
         ' 
         Me.menuItemEdit.Index = 1
         Me.menuItemEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemEditInsertCustomerInfo, Me.menuItemEditFont})
         Me.menuItemEdit.Text = "Edit"
         ' 
         ' menuItemEditInsertCustomerInfo
         ' 
         Me.menuItemEditInsertCustomerInfo.Enabled = False
         Me.menuItemEditInsertCustomerInfo.Index = 0
         Me.menuItemEditInsertCustomerInfo.Text = "Insert Customer Information"
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(56, 96)
         Me.textBox1.Multiline = True
         Me.textBox1.Name = "textBox1"
         Me.textBox1.Size = New System.Drawing.Size(160, 64)
         Me.textBox1.TabIndex = 2
         Me.textBox1.Text = ""
         ' 
         ' menuItemEditFont
         ' 
         Me.menuItemEditFont.Index = 1
         Me.menuItemEditFont.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemEditFontArial, Me.menuItemEditFontTimeNewRoman})
         Me.menuItemEditFont.Text = "Font"
         ' 
         ' menuItemEditFontArial
         ' 
         Me.menuItemEditFontArial.Index = 0
         Me.menuItemEditFontArial.Text = "Arial"
         ' 
         ' menuItemEditFontTimeNewRoman
         ' 
         Me.menuItemEditFontTimeNewRoman.Index = 1
         Me.menuItemEditFontTimeNewRoman.Text = "Times New Roman"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.buttonNewCustomer, Me.button1})
         Me.Menu = Me.mainMenu1
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      <STAThread()> _
      Shared Sub Main() '
         Application.Run(New Form1())
      End Sub 'Main
      
      
      Private Sub button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         AddButtons()
      End Sub 'button1_Click
      
      
      

      
' <snippet1>
Private Sub menuItemHelpAbout_Click(sender As Object, _
  e As EventArgs) Handles menuItemHelpAbout.Click
   ' Create and display a modless about dialog box.
   Dim about As New AboutDialog()
   about.Show()
   
   ' Draw a blue square on the form.
   ' NOTE: This is not a persistent object, it will no longer be
   ' visible after the next call to OnPaint. To make it persistent, 
   ' override the OnPaint method and draw the square there 
   Dim g As Graphics = about.CreateGraphics()
   g.FillRectangle(Brushes.Blue, 10, 10, 50, 50)
End Sub
' </snippet1>

' <snippet2>
Private Sub AddButtons()
   ' Suspend the form layout and add two buttons.
   Me.SuspendLayout()
   Dim buttonOK As New Button()
   buttonOK.Location = New Point(10, 10)
   buttonOK.Size = New Size(75, 25)
   buttonOK.Text = "OK"
   
   Dim buttonCancel As New Button()
   buttonCancel.Location = New Point(90, 10)
   buttonCancel.Size = New Size(75, 25)
   buttonCancel.Text = "Cancel"
   
   Me.Controls.AddRange(New Control() {buttonOK, buttonCancel})
   Me.ResumeLayout()
End Sub
' </snippet2>
      
' <snippet3>
Private Sub buttonNewCustomer_Click(sender As Object, _
  e As EventArgs) Handles buttonNewCustomer.Click
   ' Create a new customer form and assign a new 
   ' Customer object to the Tag property. 
   Dim customerForm As New CustomerForm()
   customerForm.Tag = New Customer()
   customerForm.Show()
End Sub
' </snippet3>
      
' <snippet4>
Private Sub menuItemEdit_Popup(sender As Object, _
  e As EventArgs) Handles menuItemEdit.Popup
   ' Disable the menu item if the text box does not have focus.
   Me.menuItemEditInsertCustomerInfo.Enabled = Me.textBox1.Focused
End Sub
' </snippet4>



Private Sub menuItemEditInsertCustomerInfo_Click(sender As Object, _
   e As EventArgs) Handles menuItemEditInsertCustomerInfo.Click
   ' Insert the customer information into the text box.
   Me.textBox1.Text += CType(Me.Tag, Customer).ToString()
End Sub

      
      
      Private Sub menuItemEditFont_Click(sender As Object, e As System.EventArgs) Handles menuItemEditFontArial.Click, menuItemEditFontTimeNewRoman.Click
         Dim menuItem As MenuItem = CType(sender, MenuItem)
         If menuItem.Parent IS Me.menuItemEditFont Then
            ' Uncheck all the menu items.
            Dim menu As MenuItem
            For Each menu In  Me.menuItemEditFont.MenuItems
               menu.Checked = False
            Next menu
            
            ' Check the menu item that was clicked.
            menuItem.Checked = True
            
            ' Update the font used in the text box.
            textBox1.Font = New Font(menuItem.Text, textBox1.Font.Size)
         End If
      End Sub 'menuItemEditFont_Click
   End Class 'Form1
   
   
   
   Public Class CustomerForm
      Inherits Form
      Public UserName As String
   End Class 'CustomerForm
   
   Public Class Customer
      Public Name As String
      Public AccountNumber As Integer
      
      
      Public Overrides Function ToString() As String
         Return AccountNumber.ToString() + Environment.NewLine + Name
      End Function 'ToString
   End Class 'Customer
   
   
   
   Public Class AboutDialog
      Inherits Form
      Public FormText As String
   End Class 'AboutDialog

End Namespace 'ControlMembers3