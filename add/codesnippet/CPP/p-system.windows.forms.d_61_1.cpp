   void ToolTips()
   {
      DataGridViewColumn^ firstColumn = dataGridView->Columns[ 0 ];
      DataGridViewColumn^ thirdColumn = dataGridView->Columns[ 2 ];
      firstColumn->ToolTipText = L"This column uses a default cell.";
      thirdColumn->ToolTipText = L"This column uses a template cell."
      L" Style changes to one cell apply to all cells.";
   }

