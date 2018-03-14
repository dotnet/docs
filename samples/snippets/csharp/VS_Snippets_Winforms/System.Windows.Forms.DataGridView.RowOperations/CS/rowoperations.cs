using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

public class RowOperations : System.Windows.Forms.Form
{
    private Panel buttonPanel = new Panel();
    private DataGridView songsDataGridView = new DataGridView();
    private Button addnewRowButton = new Button();
    private Button deleteRowButton = new Button();
    private Button ledgerStyleButton = new Button();

    private void RowOperations_Load(System.Object sender,
        System.EventArgs e)
    {
        SetupLayout();
        SetupDataGridView();
        PopulateDataGridView();
    }

    private void SetupLayout()
    {
        this.Size = new Size(600, 600);

        addnewRowButton.Text = "Add Row";
        addnewRowButton.Location = new Point(10, 10);

        deleteRowButton.Text = "Delete Row";
        deleteRowButton.Location = new Point(100, 10);

        ledgerStyleButton.Text = "Ledger Style";
        ledgerStyleButton.Size = new Size(80, 30);
        ledgerStyleButton.Location = new Point(200, 10);
                
        buttonPanel.Controls.Add(addnewRowButton);
        buttonPanel.Controls.Add(deleteRowButton);
        buttonPanel.Controls.Add(ledgerStyleButton);
        buttonPanel.Height = 50;
        buttonPanel.Dock = DockStyle.Bottom;

        this.Controls.Add(this.buttonPanel);
        this.Text = "DataGridView row operations";
    }

    private void songsDataGridView_CellFormatting(Object sender, 
        DataGridViewCellFormattingEventArgs e) 
    {

        if (this.songsDataGridView.Columns[e.ColumnIndex].Name ==
            "Artist")
        {
            if (e.Value != null)
            {
                // Check for the string "pink" in the cell.
                String stringValue = (String)e.Value;
                stringValue = stringValue.ToLower();
                if (((stringValue.IndexOf("pink") > -1)))
        		{
                    e.CellStyle.BackColor = Color.Pink;
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Font = 
                        new Font("Times new Roman", 8, 
                        FontStyle.Bold);
                }

                // Set the FormattingApplied property to true 
                // to show the event is handled.
                e.FormattingApplied = true;
            }
        }
        else if (this.songsDataGridView.Columns[e.ColumnIndex]
            .Name.Equals("Release Date"))
		{
            ShortFormDateFormat(e);
        }
    }

    // Even though the date internaly stores the year as YYYY,
    // using formatting, the
    // UI can have the format in YY.  
    private static void ShortFormDateFormat 
        (DataGridViewCellFormattingEventArgs formatting)
    {

        if (formatting.Value != null)
		{
            try
            {
                StringBuilder dateString = new StringBuilder();
                DateTime theDate = 
                    DateTime.Parse(formatting.Value.ToString());

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
                // Set to false in case there are other handlers 
                // interested trying to
                // format this DataGridViewCellFormattingEventArgs 
                // instance.
                formatting.FormattingApplied = false;
            }
        }
    }

    private void songsDataGridView_CellParsing(Object sender, 
        DataGridViewCellParsingEventArgs e) 
    {
        if (this.songsDataGridView.Columns[e.ColumnIndex].Name == 
            "Release Date")
		{
            if (e != null)
    		{
                if (e.Value != null)
	        	{
                    try
                    {
                        // Map what the user typed into UTC.
                        e.Value = 
                        DateTime.Parse(e.Value.ToString()).ToUniversalTime();
                        // Set the ParsingApplied property to 
                        // Show the event is handled.
                        e.ParsingApplied = true;
                    }
                    catch (FormatException)
                    {
                        // Set to false in case another 
                        // CellParsing(handler)
                        // wants to try to parse this 
                        // DataGridViewCellParsingEventArgs instance.
                        e.ParsingApplied = false;
                    }
                }
            }
        }
    }

    private void addnewRowButton_Click(Object sender, 
        EventArgs e)
    {
        this.songsDataGridView.Rows.Add();
    }
    
    private void deleteRowButton_Click(Object sender, 
        EventArgs e) 
    {
        if (this.songsDataGridView.SelectedRows.Count > 0 &&
           !(this.songsDataGridView.SelectedRows[0].Index == 
           this.songsDataGridView.Rows.Count - 1))
		{

            this.songsDataGridView.Rows.RemoveAt( 
                this.songsDataGridView.SelectedRows[0].Index);
        }
    }

    private void ledgerStyleButton_Click(Object sender, 
        System.EventArgs e)
    {
        // Create a new cell style.
        DataGridViewCellStyle style = new DataGridViewCellStyle();

        style.BackColor = Color.Beige;
        style.ForeColor = Color.Brown;
        style.Font = new Font("Verdana", 8);

        // Apply the style as the default cell style.
        songsDataGridView.AlternatingRowsDefaultCellStyle = style;
        ledgerStyleButton.Enabled = false;
    }

    private void SetupDataGridView()
    {
        this.Controls.Add(songsDataGridView);
        songsDataGridView.ColumnCount = 5;

        songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = 
            Color.Navy;
        songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = 
            Color.White;
        songsDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(
            songsDataGridView.Font, FontStyle.Bold);

        songsDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
        songsDataGridView.Name = "songsDataGridView";
        songsDataGridView.Location = new Point(8, 8);
        songsDataGridView.Size = new Size(500, 300);
        songsDataGridView.AutoSizeRowsMode = 
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        songsDataGridView.ColumnHeadersBorderStyle = 
            DataGridViewHeaderBorderStyle.Raised;
        songsDataGridView.CellBorderStyle = 
            DataGridViewCellBorderStyle.Single;
        songsDataGridView.GridColor = SystemColors.ActiveBorder;
        songsDataGridView.Columns[0].Name = "Release Date";
        songsDataGridView.Columns[1].Name = "Track";
        songsDataGridView.Columns[1].DefaultCellStyle.Alignment = 
            DataGridViewContentAlignment.MiddleCenter;
        songsDataGridView.Columns[2].Name = "Title";
        songsDataGridView.Columns[3].Name = "Artist";
        songsDataGridView.Columns[4].Name = "Album";
        songsDataGridView.Columns[4].DefaultCellStyle.Font = 
            new Font(Control.DefaultFont, FontStyle.Italic);
        songsDataGridView.SelectionMode = 
            DataGridViewSelectionMode.FullRowSelect;
        songsDataGridView.MultiSelect = false;

        // Set the non-cell background color.
        songsDataGridView.BackgroundColor = Color.Honeydew;

        songsDataGridView.Dock = DockStyle.Fill;
    }

    private void PopulateDataGridView()
    {
        // Create the string array foreach (row of data.
        String[] row0 = {"11/22/1968", "29", "Revolution 9", 
            "Beatles", "The Beatles [White Album]"};
        String[] row1 = {"4/4/1960", "6", "Fools Rush In", 
            "Frank Sinatra", "Nice 'N// Easy"};
        String[] row2 = {"11/11/1971", "1", 
            "One of These Days", "Pink Floyd", "Meddle"};
        String[] row3 = {"4/4/1988", "7", 
            "Where Is My Mind?", 
            "Pixies", "Surfer Rosa"};
        String[] row4 = {"5/1981", "9", 
            "Can't Find My Mind", 
            "Cramps", "Psychedelic Jungle"};
        String[] row5 = {"6/10/2003", "13", 
            "Scatterbrain. (As Dead As Leaves.)", "Radiohead", 
            "Hail to the Thief"};
        String[] row6 = {"6/30/1992", "3", "Dress", 
            "P J Harvey", "Dry"};

        // Add a row foreach (string array.
        this.songsDataGridView.Rows.Add(row0);
        this.songsDataGridView.Rows.Add(row1);
        this.songsDataGridView.Rows.Add(row2);
        this.songsDataGridView.Rows.Add(row3);
        this.songsDataGridView.Rows.Add(row4);
        this.songsDataGridView.Rows.Add(row5);
        this.songsDataGridView.Rows.Add(row6);

        // Change the order the columns are displayed.
        this.songsDataGridView.Columns[0].DisplayIndex = 3;
        this.songsDataGridView.Columns[1].DisplayIndex = 4;
        this.songsDataGridView.Columns[2].DisplayIndex = 0;
        this.songsDataGridView.Columns[3].DisplayIndex = 1;
        this.songsDataGridView.Columns[4].DisplayIndex = 2;
    }

    public static void Main()
    {
        Application.Run(new RowOperations());
    }

    #region "Row validation"
    //<snippet5>
    private void ValidateByRow(Object sender, 
        DataGridViewCellCancelEventArgs data) 
    {
        DataGridViewRow row = 
            songsDataGridView.Rows[data.RowIndex];
        DataGridViewCell trackCell = 
            row.Cells[songsDataGridView.Columns["Track"].Index];
        DataGridViewCell dateCell = 
            row.Cells[songsDataGridView.Columns["Release Date"].Index];
        data.Cancel = !(IsTrackGood(trackCell) && IsDateGood(dateCell));
    }

    private Boolean IsTrackGood(DataGridViewCell cell)
    {
        Int32 cellValueAsInt;
        if (cell.Value.ToString().Length == 0)
		{
            cell.ErrorText = "Please enter a track";
            songsDataGridView.Rows[cell.RowIndex].ErrorText = 
                "Please enter a track";
            return false;
        }
        else if (cell.Value.ToString().Equals("0"))
        {
            cell.ErrorText = "Zero is not a valid track";
            songsDataGridView.Rows[cell.RowIndex].ErrorText =
                "Zero is not a valid track";
            return false;
        }
        else if (!Int32.TryParse(cell.Value.ToString(), out cellValueAsInt))
        {
            cell.ErrorText = "A Track must be a number";
            songsDataGridView.Rows[cell.RowIndex].ErrorText =
                "A Track must be a number";
            return false;
        }
        return true;
    }

    private Boolean IsDateGood(DataGridViewCell cell) 
    {
        if (cell.Value == null)
		{
            cell.ErrorText = "Missing date";
            songsDataGridView.Rows[cell.RowIndex].ErrorText = 
                "Missing date";
            return false;
        }
        else
        {
            try
            {
                DateTime.Parse(cell.Value.ToString());
            }
            catch (FormatException)
            {
                cell.ErrorText = "Invalid format";
                songsDataGridView.Rows[cell.RowIndex].ErrorText = 
                    "Invalid format";

                return false;
            }
        }
        return true;
    }
    //</snippet5>

    //<snippet10>
    private void RemoveAnnotations(Object sender, 
        DataGridViewCellEventArgs args) 
    {
        foreach (DataGridViewCell cell in 
            songsDataGridView.Rows[args.RowIndex].Cells)
        {
            cell.ErrorText = String.Empty;
        }

        foreach (DataGridViewRow row in songsDataGridView.Rows)
        {
            row.ErrorText = String.Empty;
        }
    }
    //</snippet10>
    #endregion
}