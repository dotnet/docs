using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected TextBox textBox1;
    protected CurrencyManager myCurrencyManager;
    
    // <Snippet1>
    private void BindControl(DataTable myTable)
    {
        // Bind A TextBox control to a DataTable column in a DataSet.
        textBox1.DataBindings.Add("Text", myTable, "CompanyName");
        // Specify the CurrencyManager for the DataTable.
        myCurrencyManager = (CurrencyManager)this.BindingContext[myTable, ""];
        // Add event handlers.
        myCurrencyManager.ItemChanged+=
        new ItemChangedEventHandler(CurrencyManager_ItemChanged);
        myCurrencyManager.PositionChanged+= 
        new EventHandler(CurrencyManager_PositionChanged);
        // Set the initial Position of the control.
        myCurrencyManager.Position = 0;
    }
 
    private void CurrencyManager_PositionChanged(object sender, System.EventArgs e){
        CurrencyManager myCurrencyManager = (CurrencyManager) sender;
        Console.WriteLine("Position Changed " + myCurrencyManager.Position);
    }

    private void CurrencyManager_ItemChanged(object sender, System.Windows.Forms.ItemChangedEventArgs e){
        CurrencyManager myCurrencyManager = (CurrencyManager) sender;
        Console.WriteLine("Item Changed " + myCurrencyManager.Position);
    }
    // </Snippet1>
}
