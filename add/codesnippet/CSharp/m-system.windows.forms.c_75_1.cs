private void RemoveFromList(){
    // Get the CurrencyManager of a TextBox control.
    CurrencyManager myCurrencyManager = (CurrencyManager)textBox1.BindingContext[0];
    // If the count is 0, exit the function.
    if(myCurrencyManager.Count > 1)
    myCurrencyManager.RemoveAt(0);
}