    // The following class implements a sliding-tile puzzle.
    // The GridStrip control is a custom ToolStrip that arranges
    // its ToolStripButton controls in a grid layout. There is 
    // one empty cell, into which the user can slide an adjacent
    // tile with a drag-and-drop operation. Tiles that are eligible 
    // for moving are highlighted.
    public class GridStrip : ToolStrip
    {
        // The button that is the drag source.
        private ToolStripButton dragButton = null;

        // Settings for the ToolStrip control's TableLayoutPanel.
        // This provides access to the cell position of each
        // ToolStripButton.
        private TableLayoutSettings tableSettings = null;

        // The empty cell. ToolStripButton controls that are
        // adjacent to this button can be moved to this button's
        // cell position.
        private ToolStripButton emptyCellButton = null;

        // The dimensions of each tile. A tile is represented
        // by a ToolStripButton controls.
        private Size tileSize = new Size(128, 128);

        // The number of rows in the GridStrip control.
        private readonly int rows = 5;

        // The number of columns in the GridStrip control.
        private readonly int columns = 5;

        // The one-time initialzation behavior is enforced
        // with this field. For more information, see the 
        // OnPaint method.
        private bool firstTime = false;

        // This is a required by the Windows Forms designer.
        private System.ComponentModel.IContainer components;
 
        // The default constructor.  
        public GridStrip()
        {
            this.InitializeComponent();

            this.InitializeTableLayoutSettings();
        }

        // This property exposes the empty cell to the 
        // GridStripRenderer class.
        internal ToolStripButton EmptyCell
        {
            get
            {
                return this.emptyCellButton;
            }
        }

        // This utility method initializes the TableLayoutPanel 
        // which contains the ToolStripButton controls.
        private void InitializeTableLayoutSettings()
        {
            // Specify the numbers of rows and columns in the GridStrip control.
            this.tableSettings = base.LayoutSettings as TableLayoutSettings;
            this.tableSettings.ColumnCount = this.rows;
            this.tableSettings.RowCount = this.columns;

            // Create a dummy bitmap with the dimensions of each tile.
            // The GridStrip control sizes itself based on these dimensions.
            Bitmap b = new Bitmap(tileSize.Width, tileSize.Height);

            // Populate the GridStrip control with ToolStripButton controls.
            for (int i = 0; i < this.tableSettings.ColumnCount; i++)
            {
                for (int j = 0; j < this.tableSettings.RowCount; j++)
                {
                    // Create a new ToolStripButton control.
                    ToolStripButton btn = new ToolStripButton();
                    btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
                    btn.Image = b;
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.ImageScaling = ToolStripItemImageScaling.None;
                    btn.Margin = Padding.Empty;
                    btn.Padding = Padding.Empty;

                    // Add the new ToolStripButton control to the GridStrip.
                    this.Items.Add(btn);

                    // Set the cell position of the ToolStripButton control.
                    TableLayoutPanelCellPosition cellPos = new TableLayoutPanelCellPosition(i, j);
                    this.tableSettings.SetCellPosition(btn, cellPos);

                    // If this is the ToolStripButton control at cell (0,0),
                    // assign it as the empty cell button.
                    if( i == 0 && j == 0 )
                    {
                        btn.Text = "Empty Cell";
                        btn.Image = b;
                        this.emptyCellButton = btn;
                    }
                }
            }
        }

        // This method defines the Paint event behavior.
        // The GridStripRenderer requires that the GridStrip
        // be fully layed out when it is renders, so this
        // initialization code cannot be placed in the
        // GridStrip constructor. By the time the Paint
        // event is raised, the control layout has been 
        // completed, so the GridStripRenderer can paint
        // correctly. This one-time initialization is
        // implemented with the firstTime field.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!this.firstTime)
            {
                this.Renderer = new GridStripRenderer();

                // Comment this line to see the unscrambled image.
                this.ScrambleButtons();
                this.firstTime = true;
            }
        }

        // This utility method changes the ToolStripButton control 
        // positions in the TableLayoutPanel. This scrambles the 
        // buttons to initialize the puzzle.
        private void ScrambleButtons()
        {
            int i = 0;
            int lastElement = this.Items.Count - 1;

            while ( (i != lastElement ) &&
                    (lastElement - i > 1) )
            {
                TableLayoutPanelCellPosition pos1 = 
                    this.tableSettings.GetCellPosition(this.Items[i]);

                TableLayoutPanelCellPosition pos2 = 
                    this.tableSettings.GetCellPosition(this.Items[lastElement]);

                this.tableSettings.SetCellPosition(
                    this.Items[i++], 
                    pos2);

                this.tableSettings.SetCellPosition(
                    this.Items[lastElement--], 
                    pos1);
            }
        }

        // This method defines the MouseDown event behavior. 
        // If the user has clicked on a valid drag source, 
        // the drag operation starts.
        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);

            ToolStripButton btn = this.GetItemAt(mea.Location) as ToolStripButton;

            if (btn != null)
            {
                if (this.IsValidDragSource(btn))
                {
                    this.dragButton = btn;
                }
            }
        }

        // This method defines the MouseMove event behavior. 
        protected override void OnMouseMove(MouseEventArgs mea)
        {
            base.OnMouseMove(mea);

            // Is a drag operation pending?
            if (this.dragButton != null)
            {
                // A drag operation is pending. Call DoDragDrop to 
                // determine the disposition of the operation.
                DragDropEffects dropEffect = this.DoDragDrop(
                    new DataObject(this.dragButton), 
                    DragDropEffects.Move);
            }
        }

        // This method defines the DragOver event behavior. 
        protected override void OnDragOver(DragEventArgs dea)
        {
            base.OnDragOver(dea);

            // Get the ToolStripButton control 
            // at the given mouse position.
            Point p = new Point(dea.X, dea.Y);
            ToolStripButton item = this.GetItemAt(
                this.PointToClient(p)) as ToolStripButton;

            // If the ToolStripButton control is the empty cell,
            // indicate that the move operation is valid.
            if( item == this.emptyCellButton )
            {
                // Set the drag operation to indicate a valid move.
                dea.Effect = DragDropEffects.Move;
            }
        }

        // This method defines the DragDrop event behavior. 
        protected override void OnDragDrop(DragEventArgs dea)
        {
            base.OnDragDrop(dea);

            // Did a valid move operation occur?
            if (dea.Effect == DragDropEffects.Move)
            {
                // The move operation is valid. Adjust the state
                // of the GridStrip control's TableLayoutPanel,
                // by swapping the positions of the source button
                // and the empty cell button.

                // Get the cell of the control to move.
                TableLayoutPanelCellPosition sourcePos = 
                    tableSettings.GetCellPosition(this.dragButton);

                // Get the cell of the emptyCellButton.
                TableLayoutPanelCellPosition dropPos = 
                    tableSettings.GetCellPosition(this.emptyCellButton);

                // Move the control to the empty cell.
                tableSettings.SetCellPosition(this.dragButton, dropPos);

                // Set the position of the empty cell to 
                // that of the previously occupied cell.
                tableSettings.SetCellPosition(this.emptyCellButton, sourcePos);

                // Reset the drag operation.
                this.dragButton = null;
            }
        }

        // This method defines the DragLeave event behavior. 
        // If the mouse leaves the client area of the GridStrip
        // control, the drag operation is canceled.
        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);

            // Reset the drag operation.
            this.dragButton = null;
        }

        // This method defines the ueryContinueDrag event behavior. 
        // If the mouse leaves the client area of the GridStrip
        // control, the drag operation is canceled.
        protected override void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
        {
            base.OnQueryContinueDrag(qcdevent);

            // Get the current mouse position, in screen coordinates.
            Point mousePos = this.PointToClient(Control.MousePosition);

            // If the mouse position is outside the GridStrip control's
            // client area, cancel the drag operation. Be sure to
            // transform the mouse's screen coordinates to client coordinates. 
            if (!this.ClientRectangle.Contains(mousePos))
            {
                qcdevent.Action = DragAction.Cancel;
            }
        }

        // This utility method determines if a button
        // is positioned relative to the empty cell 
        // such that it can be dragged into the empty cell.
        private bool IsValidDragSource(ToolStripButton b)
        {
            TableLayoutPanelCellPosition sourcePos = 
                tableSettings.GetCellPosition(b);

            TableLayoutPanelCellPosition emptyPos = 
                tableSettings.GetCellPosition(this.emptyCellButton);

            return (IsValidDragSource(sourcePos, emptyPos));
        }

        // This utility method determines if a cell position
        // is adjacent to the empty cell.
        internal static bool IsValidDragSource(
            TableLayoutPanelCellPosition sourcePos, 
            TableLayoutPanelCellPosition emptyPos)
        {
            bool returnValue = false;

            // A cell is considered to be a valid drag source if it
            // is adjacent to the empty cell. Cells that are positioned
            // on a diagonal are not valid.
            if (((sourcePos.Column == emptyPos.Column - 1) && (sourcePos.Row == emptyPos.Row)) ||
                ((sourcePos.Column == emptyPos.Column + 1) && (sourcePos.Row == emptyPos.Row)) ||
                ((sourcePos.Column == emptyPos.Column) && (sourcePos.Row == emptyPos.Row - 1)) ||
                ((sourcePos.Column == emptyPos.Column) && (sourcePos.Row == emptyPos.Row + 1)))
            {
                returnValue = true;
            }

            return returnValue;
        }