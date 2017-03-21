    private void PrintListItems() {
    // Get the CurrencyManager of a TextBox control.
    CurrencyManager myCurrencyManager = (CurrencyManager)textBox1.BindingContext[0];
    // Presuming the list is a DataView, create a DataRowView variable.
    DataRowView drv;
    for(int i = 0; i < myCurrencyManager.Count; i++) {
        myCurrencyManager.Position = i;
        drv = (DataRowView)myCurrencyManager.Current;
        // Presuming a column named CompanyName exists.
        Console.WriteLine(drv["CompanyName"]);
    }
}
      