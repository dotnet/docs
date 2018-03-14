//<snippet1>
    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Drawing;
    using System.ComponentModel;

    public class MyForm : Form 
    {
        private DataTable myTable;
        private DataGrid myGrid = new DataGrid();
        
        public MyForm() : base() 
        {
            try
            {
                InitializeComponent();

                myTable = new DataTable("NamesTable");
                myTable.Columns.Add(new DataColumn("Name"));
                DataColumn column = new DataColumn
                    ("id", typeof(System.Int32));
                myTable.Columns.Add(column);
                myTable.Columns.Add(new 
                    DataColumn("calculatedField", typeof(bool)));
                DataSet namesDataSet = new DataSet();
                namesDataSet.Tables.Add(myTable);
                myGrid.SetDataBinding(namesDataSet, "NamesTable");
            
                AddTableStyle();
                AddData();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        
        private void grid_Enter(object sender, EventArgs e) 
        {
            myGrid.CurrentCell = new DataGridCell(2,2);
        }

        private void AddTableStyle()
        {
            // Map a new  TableStyle to the DataTable. Then 
            // add DataGridColumnStyle objects to the collection
            // of column styles with appropriate mappings.
            DataGridTableStyle dgt = new DataGridTableStyle();
            dgt.MappingName = "NamesTable";

            DataGridTextBoxColumn dgtbc = new DataGridTextBoxColumn();
            dgtbc.MappingName = "Name";
            dgtbc.HeaderText= "Name";
            dgt.GridColumnStyles.Add(dgtbc);

            dgtbc = new DataGridTextBoxColumn();
            dgtbc.MappingName = "id";
            dgtbc.HeaderText= "id";
            dgt.GridColumnStyles.Add(dgtbc);

            DataGridBoolColumnInherit db = 
                new DataGridBoolColumnInherit();
            db.HeaderText= "less than 1000 = blue";
            db.Width= 150;
            db.MappingName = "calculatedField";
            dgt.GridColumnStyles.Add(db);

            myGrid.TableStyles.Add(dgt);

            // This expression instructs the grid to change
            // the color of the inherited DataGridBoolColumn
            // according to the value of the id field. If it's
            // less than 1000, the row is blue. Otherwise,
            // the color is yellow.
            db.Expression = "id < 1000";
        }

        private void AddData() 
        {
            // Add data with varying numbers for the id field.
            // If the number is over 1000, the cell will paint
            // yellow. Otherwise, it will be blue.
            DataRow dRow = myTable.NewRow();

            dRow["Name"] = "name 1 ";
            dRow["id"] = 999;
            myTable.Rows.Add(dRow);

            dRow = myTable.NewRow();
            dRow["Name"] = "name 2";
            dRow["id"] = 2300;
            myTable.Rows.Add(dRow);

            dRow = myTable.NewRow();
            dRow["Name"] = "name 3";
            dRow["id"] = 120;
            myTable.Rows.Add(dRow);

            dRow = myTable.NewRow();
            dRow["Name"] = "name 4";
            dRow["id"] = 4023;
            myTable.Rows.Add(dRow);

            dRow = myTable.NewRow();
            dRow["Name"] = "name 5";
            dRow["id"] = 2345;
            myTable.Rows.Add(dRow);

            myTable.AcceptChanges();
        }

        private void InitializeComponent() 
        {
            this.Size = new Size(500, 500);
            myGrid.Size = new Size(350, 250);
            myGrid.TabStop = true;
            myGrid.TabIndex = 1;
          
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(myGrid);
          }
        [STAThread]
        public static void Main() 
        {
            Application.Run(new MyForm());
        }
    }

    public class DataGridBoolColumnInherit : DataGridBoolColumn 
    {
        private SolidBrush trueBrush = Brushes.Blue as SolidBrush;
        private SolidBrush falseBrush = Brushes.Yellow as SolidBrush;
        private DataColumn expressionColumn = null;
        private static int count = 0;

        public Color FalseColor 
        {
            get 
            {
                return falseBrush.Color;
            }
            set 
            {
                falseBrush = new SolidBrush(value);
                Invalidate();
            }
        }

        public Color TrueColor 
        {
            get 
            {
                return trueBrush.Color;
            }
            set 
            {
                trueBrush = new SolidBrush(value);
                Invalidate();
            }
        }

        public DataGridBoolColumnInherit() : base () 
        {
            count ++;
        }


        // This will work only with a DataSet or DataTable.
        // The code is not compatible with IBindingList implementations.
        public string Expression 
        {
            get 
            {
                return this.expressionColumn == null ? String.Empty : 
                    this.expressionColumn.Expression;
            }
            set 
            {
                if (expressionColumn == null)
                    AddExpressionColumn(value);
                else 
                    expressionColumn.Expression = value;
                if (expressionColumn != null && 
                    expressionColumn.Expression.Equals(value))
                    return;
                Invalidate();
            }
        }

        private void AddExpressionColumn(string value) 
        {
            // Get the grid's data source. First check for a null 
            // table or data grid.
            if (this.DataGridTableStyle == null || 
                this.DataGridTableStyle.DataGrid == null)
                return;

            DataGrid myGrid = this.DataGridTableStyle.DataGrid;
            DataView myDataView = ((CurrencyManager) 
                myGrid.BindingContext[myGrid.DataSource, 
                myGrid.DataMember]).List 
                as DataView;

            // This works only with System.Data.DataTable.
            if (myDataView == null)
                return;

            // If the user already added a column with the name 
            // then exit. Otherwise, add the column and set the 
            // expression to the value passed to this function.
            DataColumn col = myDataView.Table.Columns["__Computed__Column__"];
            if (col != null)
                return;
            col = new DataColumn("__Computed__Column__" + count.ToString());

            myDataView.Table.Columns.Add(col);
            col.Expression = value;
            expressionColumn = col;
        }

        // override the OnPaint method to paint the cell based on the expression.
        protected override void Paint(Graphics g, Rectangle bounds,
            CurrencyManager source, int rowNum,
            Brush backBrush, Brush foreBrush,
            bool alignToRight) 
        {
            bool trueExpression = false;
            bool hasExpression = false;
            DataRowView drv = source.List[rowNum] as DataRowView;

            hasExpression = this.expressionColumn != null && 
                this.expressionColumn.Expression != null && 
                !this.expressionColumn.Expression.Equals(String.Empty);

            Console.WriteLine(string.Format("hasExpressionValue {0}",hasExpression));
            // Get the value from the expression column.
            // For simplicity, we assume a True/False value for the 
            // expression column.
            if (hasExpression) 
            {
                object expr = drv.Row[expressionColumn.ColumnName];
                trueExpression = expr.Equals("True");
            }

            // Let the DataGridBoolColumn do the painting.
            if (!hasExpression)
                base.Paint(g, bounds, source, rowNum, 
                    backBrush, foreBrush, alignToRight);

            // Paint using the expression color for true or false, as calculated.
            if (trueExpression)
                base.Paint(g, bounds, source, rowNum, 
                    trueBrush, foreBrush, alignToRight);
            else
                base.Paint(g, bounds, source, rowNum, 
                    falseBrush, foreBrush, alignToRight);
        }
    }
//</snippet1>