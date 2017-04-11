namespace DataGridSample 
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Drawing;
    using System.ComponentModel;


    public class MyDataGridForm : Form 
    {
        private DataTable dataTable;
        private DataGridSample.MyDataGrid grid = new DataGridSample.MyDataGrid();
        private Button button1 = new Button();
        private Label label1 = new Label();

        public MyDataGridForm() : base() 
        {
            InitForm();

            dataTable = new DataTable("name");
            dataTable.Columns.Add(new DataColumn("First"));
            DataColumn column = new DataColumn("name");
            dataTable.Columns.Add(column);
            dataTable.Columns.Add(new DataColumn("Second", typeof(bool)));
            //dataTable.Columns["First"].ReadOnly = true;
            DataSet First = new DataSet();
            First.Tables.Add(dataTable);
            grid.DataSource = First;
            grid.DataMember = "name";
            AddSomeData();

            // grid.SetDataBinding(First, "name");
            // grid.ReadOnly = true;

            // grid.DataMember = "First";

            button1.Click += new EventHandler(OnButtonClick);

        }

        private void OnButtonClick(object sender, EventArgs e) 
        {
            //combo.Sorted = true;
            // grid[0,0] = "nou";
            // grid.SetDataBinding(null, "");
            //DataGridSample.SortDataGrid.Sort(grid, "First", true);

        }

        private void grid_Enter(object sender, EventArgs e) 
        {
            grid.CurrentCell = new DataGridCell(2,2);
        }

        private void AddSomeData() 
        {
            DataRow dRow;

            for(int i = 0; i<5;i++)
            {
                dRow = dataTable.NewRow();
                dRow["First"] = string.Format("FirstName {0}", i) ;
                dRow["name"] = string.Format("LastName {0}", i);
                dataTable.Rows.Add(dRow);

            }
        }

        private void foo(object sender, KeyEventArgs e) 
        {
            Console.WriteLine("on key down handler called");
        }

        private void InitForm() 
        {
            this.Size = new Size(700, 500);
            button1.Location= new Point(300, 300);
            button1.Text = "Sort the grid programatically";
            button1.Width = 200;
            grid.Size = new Size(350, 250);
            grid.TabStop = true;
            grid.TabIndex = 1;
            button1.TabStop = true;
            button1.TabIndex = 1;
            label1.Width = 300;
            label1.Height = 100;
            label1.Top = grid.Top;
            label1.Left = grid.Right + 10;
            label1.Text = "The grid on this app overrides the OnMouseDown event, so that when the user clicks anywhere on the grid, the user will select the row beneath the mouse cursor";
            this.Controls.Add(label1);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(grid);
            this.Controls.Add(button1);
        }
        [STAThread]
        public static void Main() 
        {
            Application.Run(new MyDataGridForm());
        }
    }

//<snippet1>
    public class MyDataGrid : DataGrid 
    {
        // Override the OnMouseDown event to select the whole row
        // when the user clicks anywhere on a row.
        protected override void OnMouseDown(MouseEventArgs e) 
        {
            // Get the HitTestInfo to return the row and pass
            // that value to the IsSelected property of the DataGrid.
            DataGrid.HitTestInfo hit = this.HitTest(e.X, e.Y);
            if (hit.Row < 0)
                return;
            if (this.IsSelected(hit.Row))
                UnSelect(hit.Row);
            else
                Select(hit.Row);
        }
    }
    //</snippet1>
}
