' The following class implements a sliding-tile puzzle.
' The GridStrip control is a custom ToolStrip that arranges
' its ToolStripButton controls in a grid layout. There is 
' one empty cell, into which the user can slide an adjacent
' tile with a drag-and-drop operation. Tiles that are eligible 
' for moving are highlighted.
Public Class GridStrip
    Inherits ToolStrip

   ' The button that is the drag source.
   Private dragButton As ToolStripButton = Nothing
   
   ' Settings for the ToolStrip control's TableLayoutPanel.
   ' This provides access to the cell position of each
   ' ToolStripButton.
   Private tableSettings As TableLayoutSettings = Nothing
   
   ' The empty cell. ToolStripButton controls that are
   ' adjacent to this button can be moved to this button's
   ' cell position.
   Private emptyCellButton As ToolStripButton = Nothing
   
   ' The dimensions of each tile. A tile is represented
   ' by a ToolStripButton controls.
   Private tileSize As New Size(128, 128)
   
   ' The number of rows in the GridStrip control.
   Private rows As Integer = 5
   
   ' The number of columns in the GridStrip control.
   Private columns As Integer = 5
   
   ' The one-time initialzation behavior is enforced
   ' with this field. For more information, see the 
   ' OnPaint method.
   Private firstTime As Boolean = False
   
   ' This is a required by the Windows Forms designer.
   Private components As System.ComponentModel.IContainer
   
   
   ' The default constructor.  
    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        Me.InitializeTableLayoutSettings()
    End Sub
   
   ' This property exposes the empty cell to the 
   ' GridStripRenderer class.
   Friend ReadOnly Property EmptyCell() As ToolStripButton
      Get
         Return Me.emptyCellButton
      End Get
   End Property
   
   
   ' This utility method initializes the TableLayoutPanel 
   ' which contains the ToolStripButton controls.
    Private Sub InitializeTableLayoutSettings()

        ' Specify the numbers of rows and columns in the GridStrip control.
        Me.tableSettings = CType(MyBase.LayoutSettings, TableLayoutSettings)
        Me.tableSettings.ColumnCount = Me.rows
        Me.tableSettings.RowCount = Me.columns

        ' Create a dummy bitmap with the dimensions of each tile.
        ' The GridStrip control sizes itself based on these dimensions.
        Dim b As New Bitmap(tileSize.Width, tileSize.Height)

        ' Populate the GridStrip control with ToolStripButton controls.
        Dim i As Integer
        For i = 0 To (Me.tableSettings.ColumnCount) - 1
            Dim j As Integer
            For j = 0 To (Me.tableSettings.RowCount) - 1
                ' Create a new ToolStripButton control.
                Dim btn As New ToolStripButton()
                btn.DisplayStyle = ToolStripItemDisplayStyle.Image
                btn.Image = b
                btn.ImageAlign = ContentAlignment.MiddleCenter
                btn.ImageScaling = ToolStripItemImageScaling.None
                btn.Margin = System.Windows.Forms.Padding.Empty
                btn.Padding = System.Windows.Forms.Padding.Empty

                ' Add the new ToolStripButton control to the GridStrip.
                Me.Items.Add(btn)

                ' Set the cell position of the ToolStripButton control.
                Dim cellPos As New TableLayoutPanelCellPosition(i, j)
                Me.tableSettings.SetCellPosition(btn, cellPos)

                ' If this is the ToolStripButton control at cell (0,0),
                ' assign it as the empty cell button.
                If i = 0 AndAlso j = 0 Then
                    btn.Text = "Empty Cell"
                    btn.Image = b
                    Me.emptyCellButton = btn
                End If
            Next j
        Next i
    End Sub
   
   
   ' This method defines the Paint event behavior.
   ' The GridStripRenderer requires that the GridStrip
   ' be fully layed out when it is renders, so this
   ' initialization code cannot be placed in the
   ' GridStrip constructor. By the time the Paint
   ' event is raised, the control layout has been 
   ' completed, so the GridStripRenderer can paint
   ' correctly. This one-time initialization is
   ' implemented with the firstTime field.
   Protected Overrides Sub OnPaint(e As PaintEventArgs)
      MyBase.OnPaint(e)
      
      If Not Me.firstTime Then
         Me.Renderer = New GridStripRenderer()
         
         ' Comment this line to see the unscrambled image.
         Me.ScrambleButtons()
         Me.firstTime = True
      End If
    End Sub
   
   
   ' This utility method changes the ToolStripButton control 
   ' positions in the TableLayoutPanel. This scrambles the 
   ' buttons to initialize the puzzle.
   Private Sub ScrambleButtons()
      Dim i As Integer = 0
      Dim lastElement As Integer = Me.Items.Count - 1
      
      While i <> lastElement AndAlso lastElement - i > 1
            Dim pos1 As TableLayoutPanelCellPosition = _
            Me.tableSettings.GetCellPosition(Me.Items(i))
         
            Dim pos2 As TableLayoutPanelCellPosition = _
            Me.tableSettings.GetCellPosition(Me.Items(lastElement))
         
            Me.tableSettings.SetCellPosition(Me.Items(i), pos2)
            i += 1
         
            Me.tableSettings.SetCellPosition(Me.Items(lastElement), pos1)
            lastElement -= 1
      End While
    End Sub
   
   
   ' This method defines the MouseDown event behavior. 
   ' If the user has clicked on a valid drag source, 
   ' the drag operation starts.
   Protected Overrides Sub OnMouseDown(mea As MouseEventArgs)
      MyBase.OnMouseDown(mea)
      
        Dim btn As ToolStripButton = CType(Me.GetItemAt(mea.Location), ToolStripButton)
      
      If (btn IsNot Nothing) Then
         If Me.IsValidDragSource(btn) Then
            Me.dragButton = btn
         End If
      End If
    End Sub
   
   
   ' This method defines the MouseMove event behavior. 
   Protected Overrides Sub OnMouseMove(mea As MouseEventArgs)
      MyBase.OnMouseMove(mea)
      
      ' Is a drag operation pending?
      If (Me.dragButton IsNot Nothing) Then
         ' A drag operation is pending. Call DoDragDrop to 
         ' determine the disposition of the operation.
         Dim dropEffect As DragDropEffects = Me.DoDragDrop(New DataObject(Me.dragButton), DragDropEffects.Move)
      End If
    End Sub
   
   ' This method defines the DragOver event behavior. 
   Protected Overrides Sub OnDragOver(dea As DragEventArgs)
      MyBase.OnDragOver(dea)
      
      ' Get the ToolStripButton control 
      ' at the given mouse position.
      Dim p As New Point(dea.X, dea.Y)
      Dim item As ToolStripButton = CType(Me.GetItemAt(Me.PointToClient(p)), ToolStripButton)
      
      
      ' If the ToolStripButton control is the empty cell,
      ' indicate that the move operation is valid.
        If item Is Me.emptyCellButton Then
            ' Set the drag operation to indicate a valid move.
            dea.Effect = DragDropEffects.Move
        End If
    End Sub
   
   
   ' This method defines the DragDrop event behavior. 
   Protected Overrides Sub OnDragDrop(dea As DragEventArgs)
      MyBase.OnDragDrop(dea)
      
      ' Did a valid move operation occur?
      If dea.Effect = DragDropEffects.Move Then
         ' The move operation is valid. Adjust the state
         ' of the GridStrip control's TableLayoutPanel,
         ' by swapping the positions of the source button
         ' and the empty cell button.
         ' Get the cell of the control to move.
         Dim sourcePos As TableLayoutPanelCellPosition = tableSettings.GetCellPosition(Me.dragButton)
         
         ' Get the cell of the emptyCellButton.
         Dim dropPos As TableLayoutPanelCellPosition = tableSettings.GetCellPosition(Me.emptyCellButton)
         
         ' Move the control to the empty cell.
         tableSettings.SetCellPosition(Me.dragButton, dropPos)
         
         ' Set the position of the empty cell to 
         ' that of the previously occupied cell.
         tableSettings.SetCellPosition(Me.emptyCellButton, sourcePos)
         
         ' Reset the drag operation.
         Me.dragButton = Nothing
      End If
    End Sub
   
   
   ' This method defines the DragLeave event behavior. 
   ' If the mouse leaves the client area of the GridStrip
   ' control, the drag operation is canceled.
   Protected Overrides Sub OnDragLeave(e As EventArgs)
      MyBase.OnDragLeave(e)
      
      ' Reset the drag operation.
      Me.dragButton = Nothing
    End Sub
   
   
   ' This method defines the ueryContinueDrag event behavior. 
   ' If the mouse leaves the client area of the GridStrip
   ' control, the drag operation is canceled.
   Protected Overrides Sub OnQueryContinueDrag(qcdevent As QueryContinueDragEventArgs)
      MyBase.OnQueryContinueDrag(qcdevent)
      
      ' Get the current mouse position, in screen coordinates.
      Dim mousePos As Point = Me.PointToClient(Control.MousePosition)
      
      ' If the mouse position is outside the GridStrip control's
      ' client area, cancel the drag operation. Be sure to
      ' transform the mouse's screen coordinates to client coordinates. 
      If Not Me.ClientRectangle.Contains(mousePos) Then
         qcdevent.Action = DragAction.Cancel
      End If
    End Sub
   
   
   ' This utility method determines if a button
   ' is positioned relative to the empty cell 
   ' such that it can be dragged into the empty cell.
   Overloads Private Function IsValidDragSource(b As ToolStripButton) As Boolean
      Dim sourcePos As TableLayoutPanelCellPosition = tableSettings.GetCellPosition(b)
      
      Dim emptyPos As TableLayoutPanelCellPosition = tableSettings.GetCellPosition(Me.emptyCellButton)
      
        Return IsValidDragSource(sourcePos, emptyPos)

    End Function
   
   
   ' This utility method determines if a cell position
   ' is adjacent to the empty cell.
    Friend Overloads Shared Function IsValidDragSource( _
    ByVal sourcePos As TableLayoutPanelCellPosition, _
    ByVal emptyPos As TableLayoutPanelCellPosition) As Boolean
        Dim returnValue As Boolean = False

        ' A cell is considered to be a valid drag source if it
        ' is adjacent to the empty cell. Cells that are positioned
        ' on a diagonal are not valid.
        If sourcePos.Column = emptyPos.Column - 1 AndAlso sourcePos.Row = emptyPos.Row OrElse _
        (sourcePos.Column = emptyPos.Column + 1 AndAlso sourcePos.Row = emptyPos.Row) OrElse _
        (sourcePos.Column = emptyPos.Column AndAlso sourcePos.Row = emptyPos.Row - 1) OrElse _
        (sourcePos.Column = emptyPos.Column AndAlso sourcePos.Row = emptyPos.Row + 1) Then
            returnValue = True
        End If

        Return returnValue
    End Function