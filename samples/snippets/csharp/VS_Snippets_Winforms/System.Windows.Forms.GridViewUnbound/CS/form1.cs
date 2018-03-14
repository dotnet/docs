using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
    private DataGridView dataGridView1 = new DataGridView();
    private Button addNewRowButton = new Button();
    private Button deleteRowButton = new Button();
    private Button ledgerStyleButton = new Button();

    public Form1()
    {
        this.Load += Form1_Load;
    }

    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        SetUpLayout();

        SetUpDataGridView();
        StyleCells();

        PopulateDataGridView();
    }

    // Set up the button and button panel.
    private void SetUpLayout()
    {
        this.Size = new Size(600, 600);
        addNewRowButton.Text = "Add Row";
        deleteRowButton.Text = "Delete Row";
        ledgerStyleButton.Text = "Ledger Style";
        buttonPanel.Controls.AddRange(new Control[] 
            { addNewRowButton, deleteRowButton, ledgerStyleButton });
        buttonPanel.Dock = DockStyle.Bottom;
        this.Controls.Add(this.buttonPanel);
    }

    //<snippet1>
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // If the column is the Artist column, check the
        // value.
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Artist")
        {
            if (e.Value != null)
            {
                // Check for the string "pink" in the cell.
                string stringValue = (string)e.Value;
                stringValue = stringValue.ToLower();
                if ((stringValue.IndexOf("pink") > -1))
                {
                    e.CellStyle.BackColor = Color.Pink;
                }

            }
        }
        else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Release Date")
        {
            ShortFormDateFormat(e);
        }
    }

    //Even though the date internaly stores the year as YYYY, using formatting, the
    //UI can have the format in YY.  
    private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
    {
        if (formatting.Value != null)
        {
            try
            {
                System.Text.StringBuilder dateString = new System.Text.StringBuilder();
                DateTime theDate = DateTime.Parse(formatting.Value.ToString());

                dateString.Append(theDate.Month);
                dateString.Append("/");
                dateString.Append(theDate.Day);
                dateString.Append("/");
                dateString.Append(theDate.Year.ToString().Substring(2));
                formatting.Value = dateString.ToString();
                formatting.FormattingApplied = true;
            }
            catch (FormatException)
            {
                // Set to false in case there are other handlers interested trying to
                // format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = false;
            }
        }
    }
    //</snippet1>

    //<snippet2>
    // Handling CellParsing allows one to accept user input, then map it to a different
    // internal representation.
    private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Release Date")
        {
            if (e != null)
            {
                if (e.Value != null)
                {
                    try
                    {
                        // Map what the user typed into UTC.
                        e.Value = DateTime.Parse(e.Value.ToString()).ToUniversalTime();
                        // Set the ParsingApplied property to 
                        // Show the event is handled.
                        e.ParsingApplied = true;

                    }
                    catch (FormatException)
                    {
                        // Set to false in case another CellParsing handler
                        // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                        e.ParsingApplied = false;
                    }
                }
            }
        }
    }
    //</snippet2>

    //<snippet3>
    private void addNewRowButton_Click(object sender, EventArgs e)
    {

        this.dataGridView1.Rows.Add();
    }
    //</snippet3>

    //<snippet4>
    private void deleteRowButton_Click(object sender, EventArgs e)
    {

        if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.SelectedRows[0].Index != this.dataGridView1.Rows.Count - 1)
        {
            this.dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
        }
    }
    //</snippet4>

    //<snippet8>
    //<snippet7>
    private void ledgerStyleButton_Click(object sender, System.EventArgs e)
    {
        // Create a new cell style.
        DataGridViewCellStyle style = new DataGridViewCellStyle();
        {
            style.BackColor = Color.Beige;
            style.ForeColor = Color.Brown;
            style.Font = new Font("Verdana", 8);
        }

        // Apply the style as the default cell style.
        dataGridView1.AlternatingRowsDefaultCellStyle = style;
        ledgerStyleButton.Enabled = false;
    }
    //</snippet7>

    //<snippet5>
    private void SetUpDataGridView()
    {
        this.Controls.Add(dataGridView1);
        dataGridView1.ColumnCount = 5;
        DataGridViewCellStyle style = 
            dataGridView1.ColumnHeadersDefaultCellStyle;
        style.BackColor = Color.Navy;
        style.ForeColor = Color.White;
        style.Font = new Font(dataGridView1.Font, FontStyle.Bold);

        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Location = new Point(8, 8);
        dataGridView1.Size = new Size(500, 300);
        dataGridView1.AutoSizeRowsMode = 
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        dataGridView1.ColumnHeadersBorderStyle = 
            DataGridViewHeaderBorderStyle.Raised;
        dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        dataGridView1.GridColor = SystemColors.ActiveBorder;
        dataGridView1.RowHeadersVisible = false;

        dataGridView1.Columns[0].Name = "Release Date";
        dataGridView1.Columns[1].Name = "Track";
        dataGridView1.Columns[1].DefaultCellStyle.Alignment = 
            DataGridViewContentAlignment.MiddleCenter;
        dataGridView1.Columns[2].Name = "Title";
        dataGridView1.Columns[3].Name = "Artist";
        dataGridView1.Columns[4].Name = "Album";

        // Make the font italic for row four.
        dataGridView1.Columns[4].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);

        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.MultiSelect = false;

        dataGridView1.BackgroundColor = Color.Honeydew;

        dataGridView1.Dock = DockStyle.Fill;

        dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        dataGridView1.CellParsing += new DataGridViewCellParsingEventHandler(dataGridView1_CellParsing);
        addNewRowButton.Click += new EventHandler(addNewRowButton_Click);
        deleteRowButton.Click += new EventHandler(deleteRowButton_Click);
        ledgerStyleButton.Click += new EventHandler(ledgerStyleButton_Click);
        dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);

    }
    //</snippet5>

    //<snippet6>
    private void PopulateDataGridView()
    {

        // Create the string array for each row of data.
        string[] row0 = { "11/22/1968", "29", "Revolution 9", "Beatles", "The Beatles [White Album]" };
        string[] row1 = { "4/4/1960", "6", "Fools Rush In", "Frank Sinatra", "Nice 'N' Easy" };
        string[] row2 = { "11/11/1971", "1", "One of These Days", "Pink Floyd", "Meddle" };
        string[] row3 = { "4/4/1988", "7", "Where Is My Mind?", "Pixies", "Surfer Rosa" };
        string[] row4 = { "5/1981", "9", "Can't Find My Mind", "Cramps", "Psychedelic Jungle" };
        string[] row5 = { "6/10/2003", "13", "Scatterbrain. (As Dead As Leaves.)", "Radiohead", "Hail to the Thief" };
        string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

        // Add a row for each string array.
        {
            DataGridViewRowCollection rows = this.dataGridView1.Rows;
            rows.Add(row0);
            rows.Add(row1);
            rows.Add(row2);
            rows.Add(row3);
            rows.Add(row4);
            rows.Add(row5);
            rows.Add(row6);
        }

        // Change the order the columns are displayed.
        {
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            columns[0].DisplayIndex = 3;
            columns[1].DisplayIndex = 4;
            columns[2].DisplayIndex = 0;
            columns[3].DisplayIndex = 1;
            columns[4].DisplayIndex = 2;
        }
    }
    //</snippet6>
    //</snippet8>

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    #region "snippet9 cell validating"
    //<snippet9>
    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {

        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];

        if (column.Name == "Track")
        {
            CheckTrack(e);
        }
        else if (column.Name == "Release Date")
        {
            CheckDate(e);
        }
    }

    private static void CheckTrack(DataGridViewCellValidatingEventArgs newValue)
    {
        Int32 ignored = new Int32();
        if (String.IsNullOrEmpty(newValue.FormattedValue.ToString()))
        {
            NotifyUserAndForceRedo("Please enter a track", newValue);
        }
        else if (!Int32.TryParse(newValue.FormattedValue.ToString(), out ignored))
        {
            NotifyUserAndForceRedo("A Track must be a number", newValue);
        }
        else if (Int32.Parse(newValue.FormattedValue.ToString()) < 1)
        {
            NotifyUserAndForceRedo("Not a valid track", newValue);
        }
    }

    private static void NotifyUserAndForceRedo(string errorMessage, DataGridViewCellValidatingEventArgs newValue)
    {
        MessageBox.Show(errorMessage);
        newValue.Cancel = true;
    }

    private void CheckDate(DataGridViewCellValidatingEventArgs newValue)
    {
        try
        {
            DateTime.Parse(newValue.FormattedValue.ToString()).ToLongDateString();
            AnnotateCell(String.Empty, newValue);
        }
        catch (FormatException)
        {
            AnnotateCell("You did not enter a valid date.", newValue);
        }
    }

    private void AnnotateCell(string errorMessage, DataGridViewCellValidatingEventArgs editEvent)
    {

        DataGridViewCell cell = dataGridView1.Rows[editEvent.RowIndex].Cells[editEvent.ColumnIndex];
        cell.ErrorText = errorMessage;
    }
    //</snippet9>
    #endregion

    #region "snippet10 cell border style"
    //<snippet10>
    private void StyleCells()
    {
        dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
        dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
    }
    //</snippet10>
    #endregion
}


