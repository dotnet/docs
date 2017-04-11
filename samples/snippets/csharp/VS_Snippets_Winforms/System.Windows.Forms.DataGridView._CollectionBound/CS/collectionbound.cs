//<snippet00>
using System;
using System.Windows.Forms;
//<snippet20>
public enum Title
{
    King,
    Sir
};
//</snippet20>
public class EnumsAndComboBox : Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();

    public EnumsAndComboBox()
    {
        this.Load += new System.EventHandler(EnumsAndComboBox_Load);
    }

    //<snippet10>
    private void EnumsAndComboBox_Load(object sender, System.EventArgs e)
    {
        // Populate the data source.
        bindingSource1.Add(new Knight(Title.King, "Uther", true));
        bindingSource1.Add(new Knight(Title.King, "Arthur", true));
        bindingSource1.Add(new Knight(Title.Sir, "Mordred", false));
        bindingSource1.Add(new Knight(Title.Sir, "Gawain", true));
        bindingSource1.Add(new Knight(Title.Sir, "Galahad", true));

        // Initialize the DataGridView.
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.AutoSize = true;
        dataGridView1.DataSource = bindingSource1;

        dataGridView1.Columns.Add(CreateComboBoxWithEnums());

        // Initialize and add a text box column.
        DataGridViewColumn column = new DataGridViewTextBoxColumn();
        column.DataPropertyName = "Name";
        column.Name = "Knight";
        dataGridView1.Columns.Add(column);

        // Initialize and add a check box column.
        column = new DataGridViewCheckBoxColumn();
        column.DataPropertyName = "GoodGuy";
        column.Name = "Good";
        dataGridView1.Columns.Add(column);

        // Initialize the form.
        this.Controls.Add(dataGridView1);
        this.AutoSize = true;
        this.Text = "DataGridView object binding demo";
    }

    DataGridViewComboBoxColumn CreateComboBoxWithEnums()
    {
        DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
        combo.DataSource = Enum.GetValues(typeof(Title));
        combo.DataPropertyName = "Title";
        combo.Name = "Title";
        return combo;
    }
    #region "business object"
    private class Knight
    {
        private string hisName;
        private bool good;
        private Title hisTitle;

        public Knight(Title title, string name, bool good)
        {
            hisTitle = title;
            hisName = name;
            this.good = good;
        }

        public Knight()
        {
            hisTitle = Title.Sir;
            hisName = "<enter name>";
            good = true;
        }

        public string Name
        {
            get
            {
                return hisName;
            }

            set
            {
                hisName = value;
            }
        }

        public bool GoodGuy
        {
            get
            {
                return good;
            }
            set
            {
                good = value;
            }
        }

        public Title Title
        {
            get
            {
                return hisTitle;
            }
            set
            {
                hisTitle = value;
            }
        }
    }
    #endregion
    //</snippet10>

    [STAThread]
    public static void Main()
    {
        Application.Run(new EnumsAndComboBox());
    }

}
//</snippet00>



