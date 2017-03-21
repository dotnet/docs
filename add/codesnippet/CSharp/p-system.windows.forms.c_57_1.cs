private void GetCurrentItem() {
    CurrencyManager myCurrencyManager;
    // Get the CurrencyManager of a TextBox control.
    myCurrencyManager = (CurrencyManager)textBox1.BindingContext[0];
    // Get the current item cast as a DataRowView.
    DataRowView myDataRowView;
    myDataRowView = (DataRowView) myCurrencyManager.Current;
    // Print the column named ContactName.
    Console.WriteLine(myDataRowView["ContactName"]);
}