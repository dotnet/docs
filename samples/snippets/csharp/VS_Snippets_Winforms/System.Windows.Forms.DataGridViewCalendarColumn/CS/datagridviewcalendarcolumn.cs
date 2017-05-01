//<Snippet000>
//<Snippet001>
using System;
using System.Windows.Forms;
//</Snippet001>

//<Snippet100>
public class CalendarColumn : DataGridViewColumn
{
    public CalendarColumn() : base(new CalendarCell())
    {
    }

    public override DataGridViewCell CellTemplate
    {
        get
        {
            return base.CellTemplate;
        }
        set
        {
            // Ensure that the cell used for the template is a CalendarCell.
            if (value != null && 
                !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
            {
                throw new InvalidCastException("Must be a CalendarCell");
            }
            base.CellTemplate = value;
        }
    }
}
//</Snippet100>

//<Snippet200>
public class CalendarCell : DataGridViewTextBoxCell
{

    public CalendarCell()
        : base()
    {
        // Use the short date format.
        this.Style.Format = "d";
    }

    //<Snippet210>
    public override void InitializeEditingControl(int rowIndex, object 
        initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        // Set the value of the editing control to the current cell value.
        base.InitializeEditingControl(rowIndex, initialFormattedValue, 
            dataGridViewCellStyle);
        CalendarEditingControl ctl = 
            DataGridView.EditingControl as CalendarEditingControl;
        // Use the default row value when Value property is null.
        if (this.Value == null)
        {
            ctl.Value = (DateTime)this.DefaultNewRowValue;
        }
        else
        {
            ctl.Value = (DateTime)this.Value;
        }
    }
    //</Snippet210>

    public override Type EditType
    {
        get
        {
            // Return the type of the editing control that CalendarCell uses.
            return typeof(CalendarEditingControl);
        }
    }

    public override Type ValueType
    {
        get
        {
            // Return the type of the value that CalendarCell contains.
            
            return typeof(DateTime);
        }
    }

    public override object DefaultNewRowValue
    {
        get
        {
            // Use the current date and time as the default value.
            return DateTime.Now;
        }
    }
}
//</Snippet200>

//<Snippet300>
class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
{
    DataGridView dataGridView;
    private bool valueChanged = false;
    int rowIndex;

    public CalendarEditingControl()
    {
        this.Format = DateTimePickerFormat.Short;
    }

    //<Snippet301>
    // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
    // property.
    public object EditingControlFormattedValue
    {
        get
        {
            return this.Value.ToShortDateString();
        }
        set
        {            
            if (value is String)
            {
                try
                {
                    // This will throw an exception of the string is 
                    // null, empty, or not in the format of a date.
                    this.Value = DateTime.Parse((String)value);
                }
                catch
                {
                    // In the case of an exception, just use the 
                    // default value so we're not left with a null
                    // value.
                    this.Value = DateTime.Now;
                }
            }
        }
    }
    //</Snippet301>

    //<Snippet302>
    // Implements the 
    // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
    public object GetEditingControlFormattedValue(
        DataGridViewDataErrorContexts context)
    {
        return EditingControlFormattedValue;
    }
    //</Snippet302>

    //<Snippet303>
    // Implements the 
    // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
    public void ApplyCellStyleToEditingControl(
        DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
    }
    //</Snippet303>

    //<Snippet304>
    // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
    // property.
    public int EditingControlRowIndex
    {
        get
        {
            return rowIndex;
        }
        set
        {
            rowIndex = value;
        }
    }
    //</Snippet304>

    //<Snippet305>
    // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
    // method.
    public bool EditingControlWantsInputKey(
        Keys key, bool dataGridViewWantsInputKey)
    {
        // Let the DateTimePicker handle the keys listed.
        switch (key & Keys.KeyCode)
        {
            case Keys.Left:
            case Keys.Up:
            case Keys.Down:
            case Keys.Right:
            case Keys.Home:
            case Keys.End:
            case Keys.PageDown:
            case Keys.PageUp:
                return true;
            default:
                return !dataGridViewWantsInputKey;
        }
    }
    //</Snippet305>

    //<Snippet306>
    // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
    // method.
    public void PrepareEditingControlForEdit(bool selectAll)
    {
        // No preparation needs to be done.
    }
    //</Snippet306>

    //<Snippet307>
    // Implements the IDataGridViewEditingControl
    // .RepositionEditingControlOnValueChange property.
    public bool RepositionEditingControlOnValueChange
    {
        get
        {
            return false;
        }
    }
    //</Snippet307>

    //<Snippet308>
    // Implements the IDataGridViewEditingControl
    // .EditingControlDataGridView property.
    public DataGridView EditingControlDataGridView
    {
        get
        {
            return dataGridView;
        }
        set
        {
            dataGridView = value;
        }
    }
    //</Snippet308>

    //<Snippet309>
    // Implements the IDataGridViewEditingControl
    // .EditingControlValueChanged property.
    public bool EditingControlValueChanged
    {
        get
        {
            return valueChanged;
        }
        set
        {
            valueChanged = value;
        }
    }
    //</Snippet309>

    //<Snippet311>
    // Implements the IDataGridViewEditingControl
    // .EditingPanelCursor property.
    public Cursor EditingPanelCursor
    {
        get
        {
            return base.Cursor;
        }
    }
    //</Snippet311>

    //<Snippet310>
    protected override void OnValueChanged(EventArgs eventargs)
    {
        // Notify the DataGridView that the contents of the cell
        // have changed.
        valueChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(eventargs);
    }
    //</Snippet310>
}
//</Snippet300>

//<Snippet400>
public class Form1 : Form
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
        this.Text = "DataGridView calendar column demo";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        CalendarColumn col = new CalendarColumn();
        this.dataGridView1.Columns.Add(col);
        this.dataGridView1.RowCount = 5;
        foreach (DataGridViewRow row in this.dataGridView1.Rows)
        {
            row.Cells[0].Value = DateTime.Now;
        }
    }
}
//</Snippet400>
//</Snippet000>