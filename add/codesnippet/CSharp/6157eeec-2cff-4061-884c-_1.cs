        public override DataGridViewAdvancedBorderStyle AdjustCellBorderStyle(
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput,
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceHolder,
            bool singleVerticalBorderAdded,
            bool singleHorizontalBorderAdded,
            bool firstVisibleColumn,
            bool firstVisibleRow)
        {
            // Customize the top border of cells in the first row and the 
            // right border of cells in the first column. Use the input style 
            // for all other borders.
            dataGridViewAdvancedBorderStylePlaceHolder.Left = firstVisibleColumn ?
                DataGridViewAdvancedCellBorderStyle.OutsetDouble :
                DataGridViewAdvancedCellBorderStyle.None;
            dataGridViewAdvancedBorderStylePlaceHolder.Top = firstVisibleRow ?
                DataGridViewAdvancedCellBorderStyle.InsetDouble :
                DataGridViewAdvancedCellBorderStyle.None;

            dataGridViewAdvancedBorderStylePlaceHolder.Right =
                dataGridViewAdvancedBorderStyleInput.Right;
            dataGridViewAdvancedBorderStylePlaceHolder.Bottom =
                dataGridViewAdvancedBorderStyleInput.Bottom;

            return dataGridViewAdvancedBorderStylePlaceHolder;
        }