    // Force the cell to repaint itself when the mouse pointer enters it.
    protected override void OnMouseEnter(int rowIndex)
    {
        this.DataGridView.InvalidateCell(this);
    }

    // Force the cell to repaint itself when the mouse pointer leaves it.
    protected override void OnMouseLeave(int rowIndex)
    {
        this.DataGridView.InvalidateCell(this);
    }