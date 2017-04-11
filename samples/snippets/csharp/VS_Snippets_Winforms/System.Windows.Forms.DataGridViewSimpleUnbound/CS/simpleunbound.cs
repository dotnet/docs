//<Snippet00>
//<Snippet01>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private Panel buttonPanel = new Panel();
    private DataGridView songsDataGridView = new DataGridView();
    private Button addNewRowButton = new Button();
    private Button deleteRowButton = new Button();
    //</Snippet01>

    //<Snippet10>
    public Form1()
    {
        this.Load += new EventHandler(Form1_Load);
    }

    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        SetupLayout();
        SetupDataGridView();
        PopulateDataGridView();
    }

    private void songsDataGridView_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
        if (e != null)
        {
            if (this.songsDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
            {
                if (e.Value != null)
                {
                    try
                    {
                        e.Value = DateTime.Parse(e.Value.ToString())
                            .ToLongDateString();
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                    }
                }
            }
        }
    }

    private void addNewRowButton_Click(object sender, EventArgs e)
    {
        this.songsDataGridView.Rows.Add();
    }

    private void deleteRowButton_Click(object sender, EventArgs e)
    {
        if (this.songsDataGridView.SelectedRows.Count > 0 &&
            this.songsDataGridView.SelectedRows[0].Index !=
            this.songsDataGridView.Rows.Count - 1)
        {
            this.songsDataGridView.Rows.RemoveAt(
                this.songsDataGridView.SelectedRows[0].Index);
        }
    }
    //</Snippet10>

    //<Snippet20>
    private void SetupLayout()
    {
        this.Size = new Size(600, 500);

        addNewRowButton.Text = "Add Row";
        addNewRowButton.Location = new Point(10, 10);
        addNewRowButton.Click += new EventHandler(addNewRowButton_Click);

        deleteRowButton.Text = "Delete Row";
        deleteRowButton.Location = new Point(100, 10);
        deleteRowButton.Click += new EventHandler(deleteRowButton_Click);

        buttonPanel.Controls.Add(addNewRowButton);
        buttonPanel.Controls.Add(deleteRowButton);
        buttonPanel.Height = 50;
        buttonPanel.Dock = DockStyle.Bottom;

        this.Controls.Add(this.buttonPanel);
    }
    //</Snippet20>

    //<Snippet30>
    private void SetupDataGridView()
    {
        this.Controls.Add(songsDataGridView);

        songsDataGridView.ColumnCount = 5;

        songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
        songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        songsDataGridView.ColumnHeadersDefaultCellStyle.Font =
            new Font(songsDataGridView.Font, FontStyle.Bold);

        songsDataGridView.Name = "songsDataGridView";
        songsDataGridView.Location = new Point(8, 8);
        songsDataGridView.Size = new Size(500, 250);
        songsDataGridView.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        songsDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
        songsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        songsDataGridView.GridColor = Color.Black;
        songsDataGridView.RowHeadersVisible = false;

        songsDataGridView.Columns[0].Name = "Release Date";
        songsDataGridView.Columns[1].Name = "Track";
        songsDataGridView.Columns[2].Name = "Title";
        songsDataGridView.Columns[3].Name = "Artist";
        songsDataGridView.Columns[4].Name = "Album";
        songsDataGridView.Columns[4].DefaultCellStyle.Font =
            new Font(songsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

        songsDataGridView.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        songsDataGridView.MultiSelect = false;
        songsDataGridView.Dock = DockStyle.Fill;

        songsDataGridView.CellFormatting += new
            DataGridViewCellFormattingEventHandler(
            songsDataGridView_CellFormatting);
    }
    //</Snippet30>

    //<Snippet40>
    private void PopulateDataGridView()
    {

        string[] row0 = { "11/22/1968", "29", "Revolution 9", 
            "Beatles", "The Beatles [White Album]" };
        string[] row1 = { "1960", "6", "Fools Rush In", 
            "Frank Sinatra", "Nice 'N' Easy" };
        string[] row2 = { "11/11/1971", "1", "One of These Days", 
            "Pink Floyd", "Meddle" };
        string[] row3 = { "1988", "7", "Where Is My Mind?", 
            "Pixies", "Surfer Rosa" };
        string[] row4 = { "5/1981", "9", "Can't Find My Mind", 
            "Cramps", "Psychedelic Jungle" };
        string[] row5 = { "6/10/2003", "13", 
            "Scatterbrain. (As Dead As Leaves.)", 
            "Radiohead", "Hail to the Thief" };
        string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

        songsDataGridView.Rows.Add(row0);
        songsDataGridView.Rows.Add(row1);
        songsDataGridView.Rows.Add(row2);
        songsDataGridView.Rows.Add(row3);
        songsDataGridView.Rows.Add(row4);
        songsDataGridView.Rows.Add(row5);
        songsDataGridView.Rows.Add(row6);

        songsDataGridView.Columns[0].DisplayIndex = 3;
        songsDataGridView.Columns[1].DisplayIndex = 4;
        songsDataGridView.Columns[2].DisplayIndex = 0;
        songsDataGridView.Columns[3].DisplayIndex = 1;
        songsDataGridView.Columns[4].DisplayIndex = 2;
    }
    //</Snippet40>

    //<Snippet02>

    [STAThreadAttribute()]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}
//</Snippet02>
//</Snippet00>