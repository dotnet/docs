using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void DemonstrateRefresh(){
    // Create an array with ten elements and bind to a TextBox.
    string[] myArray= new string[10];
    for(int i = 0; i <10; i++){
       myArray[i] = "item " + i;
    }
    textBox1.DataBindings.Add ("Text",myArray,"");
    // Change one value.
    myArray[0]= "New value";

    // Uncomment the next line to refresh the CurrencyManager.
    // RefreshGrid(myArray);
 }
 private void RefreshGrid(object dataSource){
    CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataSource];
    myCurrencyManager.Refresh();
 }
      
// </Snippet1>
}
