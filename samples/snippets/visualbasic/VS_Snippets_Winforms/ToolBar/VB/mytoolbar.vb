Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


   Public Class MyToolBar
      Inherits System.Windows.Forms.Form
      Private toolBar1 As System.Windows.Forms.ToolBar
      Private imageList1 As System.Windows.Forms.ImageList
      Private toolBarButton1 As System.Windows.Forms.ToolBarButton
      Private withevents button1 As System.Windows.Forms.Button
      Private withevents button2 As System.Windows.Forms.Button
      Private textBox1 As System.Windows.Forms.TextBox
      Private components As System.ComponentModel.IContainer
      Private contextMenu1 As ContextMenu
      Private menuItem1 As MenuItem
      Private menuItem2 As MenuItem
      
      
      Public Sub New()
         InitializeComponent()
         Me.AddToolBar()
      End Sub
      
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.imageList1.Images.Add(Image.FromFile("c:\copy.bmp"))
         Me.imageList1.Images.Add(Image.FromFile("c:\button.bmp"))
         Me.imageList1.Images.Add(Image.FromFile("c:\camera.bmp"))
         Me.toolBarButton1 = New System.Windows.Forms.ToolBarButton()
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.menuItem1 = New MenuItem("Clear")
         Me.menuItem2 = New MenuItem("Test")
         Me.contextMenu1 = New ContextMenu(New MenuItem() {menuItem1, menuItem2})
         Me.SuspendLayout()
         
         ' 
         ' imageList1
         ' 
         Me.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
         Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
         'this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
         ' 
         ' toolBarButton1
         ' 
         Me.toolBarButton1.ImageIndex = 0
         Me.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
         Me.toolBarButton1.DropDownMenu = Me.contextMenu1
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(24, 192)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "button1"
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(136, 200)
         Me.button2.Name = "button2"
         Me.button2.TabIndex = 2
         Me.button2.Text = "button2"
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(96, 144)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.TabIndex = 3
         Me.textBox1.Text = "textBox1"
         ' 
         ' MyToolBar
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.button2, Me.button1})
         Me.Name = "MyToolBar"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub
       
      <STAThread()> Shared Sub Main() 
         Application.Run(New MyToolBar())
      End Sub 
      

' <snippet1>
Private Sub AddToolBar()
   ' Add a toolbar and set some of its properties.
   toolBar1 = New ToolBar()
   toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
   toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.None
   toolBar1.Buttons.Add(Me.toolBarButton1)
   toolBar1.ButtonSize = New System.Drawing.Size(24, 24)
   toolBar1.Divider = True
   toolBar1.DropDownArrows = True
   toolBar1.ImageList = Me.imageList1
   toolBar1.ShowToolTips = True
   toolBar1.Size = New System.Drawing.Size(292, 25)
   toolBar1.TabIndex = 0
   toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
   toolBar1.Wrappable = False

   ' Add handlers for the ButtonClick and ButtonDropDown events.
   AddHandler toolBar1.ButtonDropDown, AddressOf toolBar1_ButtonDropDown
   AddHandler toolBar1.ButtonClick, AddressOf toolBar1_ButtonClicked

   ' Add the toolbar to the form.
   Me.Controls.Add(toolBar1)
End Sub
' </snippet1>

' <snippet2>
Private Sub AddToolbarButtons(toolBar As ToolBar)
   If Not toolBar.Buttons.IsReadOnly Then
      ' If toolBarButton1 in in the collection, remove it.
      If toolBar.Buttons.Contains(toolBarButton1) Then
         toolBar.Buttons.Remove(toolBarButton1)
      End If

      ' Create three toolbar buttons.
      Dim tbb1 As New ToolBarButton("tbb1")
      Dim tbb2 As New ToolBarButton("tbb2")
      Dim tbb3 As New ToolBarButton("tbb3")

      ' Add toolbar buttons to the toolbar.		
      toolBar.Buttons.AddRange(New ToolBarButton() {tbb2, tbb3})
      toolBar.Buttons.Add("tbb4")

      ' Insert tbb1 into the first position in the collection.
      toolBar.Buttons.Insert(0, tbb1)
   End If
End Sub
' </snippet2>

' <snippet3>
Private Function GetButtonList(toolBar As ToolBar) As String
   Dim buttonList As String = "ToolBarButtons: "
   Dim x As IEnumerator = toolBar.Buttons.GetEnumerator()
   
   ' Enumerate through the collection of toolbar buttons.
   While x.MoveNext()
      buttonList += CType(x.Current, ToolBarButton).Text + " "
   End While

   Return buttonList
End Function
' </snippet3>

'<snippet4>
Private Sub toolBar1_ButtonDropDown(sender As Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs)
   ' If the text box is disabled, disable the menu item.
   If Not textBox1.Enabled Then
      contextMenu1.MenuItems(Me.contextMenu1.MenuItems.IndexOf(menuItem1)).Enabled = False
   End If
End Sub

Private Sub toolBar1_ButtonClicked(sender As Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs)
   ' Disable the text box.
   textBox1.Enabled = False
End Sub
' </snippet4>
      


      Private Sub button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         AddToolbarButtons(Me.toolBar1)
      End Sub 'button1_Click
      
      
      Private Sub button2_Click(sender As Object, e As System.EventArgs) Handles button2.Click
         MessageBox.Show(Me.GetButtonList(toolBar1))
      End Sub 'button2_Click
   End Class 'MyToolBar