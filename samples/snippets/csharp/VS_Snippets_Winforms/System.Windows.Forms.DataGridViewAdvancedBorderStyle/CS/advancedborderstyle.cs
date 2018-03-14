// This entire sample can go in DataGridViewAdvancedBorderStyle class overview.
//  - Snippet10 can go in DataGridView.EnableHeadersVisualStyles property (state in the
//    Example intro that EnableVisualStyles() was called for the app itself, so setting
//    this property to false overrides that).
//  - Snippet12 can go in DataGridView.AdjustedTopLeftHeaderBorderStyle property
//  - Snippet15 can go in DataGridView.AdjustColumnHeaderBorderStyle()
//  - Snippet20 can go in DataGridViewCell.AdjustCellBorderStyle()
//  - Snippet30 can go in DataGridViewRow.AdjustRowHeaderBorderStyle()


// <Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataGridViewAdvancedBorderStyleSample
{
    class Form1 : Form
    {
        [STAThreadAttribute()]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
        {
            this.AutoSize = true;
            this.Controls.Add(new CustomDataGridView());
            this.Text = "DataGridView advanced border styles demo";
        }
    }

    public class CustomDataGridView : DataGridView
    {
        // <Snippet10>
        public CustomDataGridView()
        {
            this.RowTemplate = new DataGridViewCustomRow();
            this.Columns.Add(new DataGridViewCustomColumn());
            this.Columns.Add(new DataGridViewCustomColumn());
            this.Columns.Add(new DataGridViewCustomColumn());
            this.RowCount = 4;
            this.EnableHeadersVisualStyles = false;
            this.AutoSize = true;
        }
        // </Snippet10>

        // <Snippet12>
        public override DataGridViewAdvancedBorderStyle AdjustedTopLeftHeaderBorderStyle
        {
            get
            {
                DataGridViewAdvancedBorderStyle newStyle =
                    new DataGridViewAdvancedBorderStyle();
                newStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                newStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                newStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
                newStyle.Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble;
                return newStyle;
            }
        }
        // </Snippet12>

        // <Snippet15>
        public override DataGridViewAdvancedBorderStyle AdjustColumnHeaderBorderStyle(
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput,
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceHolder,
            bool firstDisplayedColumn,
            bool lastVisibleColumn)
        {
            // Customize the left border of the first column header and the
            // bottom border of all the column headers. Use the input style for 
            // all other borders.
            dataGridViewAdvancedBorderStylePlaceHolder.Left = firstDisplayedColumn ?
                DataGridViewAdvancedCellBorderStyle.OutsetDouble :
                DataGridViewAdvancedCellBorderStyle.None;
            dataGridViewAdvancedBorderStylePlaceHolder.Bottom =
                DataGridViewAdvancedCellBorderStyle.Single;

            dataGridViewAdvancedBorderStylePlaceHolder.Right =
                dataGridViewAdvancedBorderStyleInput.Right;
            dataGridViewAdvancedBorderStylePlaceHolder.Top =
                dataGridViewAdvancedBorderStyleInput.Top;

            return dataGridViewAdvancedBorderStylePlaceHolder;
        }
        // </Snippet15>
    }

    public class DataGridViewCustomColumn : DataGridViewColumn
    {
        public DataGridViewCustomColumn()
        {
            this.CellTemplate = new DataGridViewCustomCell();
        }
    }

    public class DataGridViewCustomCell : DataGridViewTextBoxCell
    {
        // <Snippet20>
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
        // </Snippet20>
    }

    public class DataGridViewCustomRow : DataGridViewRow
    {
        // <Snippet30>
        public override DataGridViewAdvancedBorderStyle AdjustRowHeaderBorderStyle(
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput,
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceHolder,
            bool singleVerticalBorderAdded,
            bool singleHorizontalBorderAdded,
            bool isFirstDisplayedRow,
            bool isLastDisplayedRow)
        {
            // Customize the top border of the first row header and the
            // right border of all the row headers. Use the input style for 
            // all other borders.
            dataGridViewAdvancedBorderStylePlaceHolder.Top = isFirstDisplayedRow ?
                DataGridViewAdvancedCellBorderStyle.InsetDouble :
                DataGridViewAdvancedCellBorderStyle.None;
            dataGridViewAdvancedBorderStylePlaceHolder.Right =
                DataGridViewAdvancedCellBorderStyle.OutsetDouble;

            dataGridViewAdvancedBorderStylePlaceHolder.Left =
                dataGridViewAdvancedBorderStyleInput.Left;
            dataGridViewAdvancedBorderStylePlaceHolder.Bottom =
                dataGridViewAdvancedBorderStyleInput.Bottom;

            return dataGridViewAdvancedBorderStylePlaceHolder;
        }
        // </Snippet30>
    }
}
// </Snippet0>