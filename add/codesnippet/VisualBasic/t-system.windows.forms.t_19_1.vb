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