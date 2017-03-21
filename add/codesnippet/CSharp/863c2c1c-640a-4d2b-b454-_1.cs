    // Override OnMouseClick in a class derived from DataGridViewCell to 
    // enter edit mode when the user clicks the cell. 
    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
        if (base.DataGridView != null)
        {
            Point point1 = base.DataGridView.CurrentCellAddress;
            if (point1.X == e.ColumnIndex &&
                point1.Y == e.RowIndex &&
                e.Button == MouseButtons.Left &&
                base.DataGridView.EditMode !=
                DataGridViewEditMode.EditProgrammatically)
            {
                base.DataGridView.BeginEdit(true);
            }
        }
    }