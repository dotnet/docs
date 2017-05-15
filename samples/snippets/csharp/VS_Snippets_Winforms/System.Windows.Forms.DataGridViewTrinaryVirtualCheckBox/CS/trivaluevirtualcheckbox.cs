//<snippet0>
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

public class TriValueVirtualCheckBox:Form
{
    DataGridView dataGridView1 = new DataGridView();

    const int initialSize = 500;

    Dictionary<int, LightStatus> store 
        = new Dictionary<int, LightStatus>();

    public TriValueVirtualCheckBox() : base()
    {        
        Text = this.GetType().Name;

        int index = 0;
        for(index=0; index<=initialSize; index++)
            store.Add(index, LightStatus.Unknown);

        Controls.Add(dataGridView1);
        dataGridView1.VirtualMode = true;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.CellValueNeeded += new 
            DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
        dataGridView1.CellValuePushed += new 
            DataGridViewCellValueEventHandler(dataGridView1_CellValuePushed);

        dataGridView1.Columns.Add(CreateCheckBoxColumn());
        dataGridView1.Rows.AddCopies(0, initialSize);
    }

    //<snippet10>
    private DataGridViewCheckBoxColumn CreateCheckBoxColumn()
    {
        DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1 
            = new DataGridViewCheckBoxColumn();
        dataGridViewCheckBoxColumn1.HeaderText = "Lights On";
        dataGridViewCheckBoxColumn1.TrueValue = LightStatus.TurnedOn;
        dataGridViewCheckBoxColumn1.FalseValue = LightStatus.TurnedOff;
        dataGridViewCheckBoxColumn1.IndeterminateValue 
            = LightStatus.Unknown;
        dataGridViewCheckBoxColumn1.ThreeState = true;
        dataGridViewCheckBoxColumn1.ValueType = typeof(LightStatus);
        return dataGridViewCheckBoxColumn1;
    }
    //</snippet10>

#region "data store maintance"
    private void dataGridView1_CellValueNeeded(object sender, 
        DataGridViewCellValueEventArgs e)
    {
        e.Value = store[e.RowIndex];
    }

    private void dataGridView1_CellValuePushed(object sender, 
        DataGridViewCellValueEventArgs e)
    {
        store[e.RowIndex] = (LightStatus) e.Value;
    }
#endregion

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new TriValueVirtualCheckBox());
    }
}

public enum LightStatus
{
    Unknown, 
    TurnedOn, 
    TurnedOff
};

//</snippet0>