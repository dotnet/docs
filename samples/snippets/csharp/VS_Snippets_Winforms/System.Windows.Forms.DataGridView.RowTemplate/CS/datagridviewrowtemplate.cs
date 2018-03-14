using System;
using System.Drawing;
using System.Windows.Forms;

class Form1 : Form
{
    private DataGridView dataGridView1 = new DataGridView();

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        this.dataGridView1.Dock = DockStyle.Fill;
        this.Controls.Add(this.dataGridView1);
        this.Load += new EventHandler(Form1_Load);
        this.Text = "DataGridView.RowTemplate demo";
    }

    void Form1_Load(object sender, EventArgs e)
    {
        //<Snippet1>
        DataGridViewRow row = this.dataGridView1.RowTemplate;
        row.DefaultCellStyle.BackColor = Color.Bisque;
        row.Height = 35;
        row.MinimumHeight = 20;
        //</Snippet1>

        this.dataGridView1.ColumnCount = 5;
        this.dataGridView1.RowCount = 10;
    }
}
