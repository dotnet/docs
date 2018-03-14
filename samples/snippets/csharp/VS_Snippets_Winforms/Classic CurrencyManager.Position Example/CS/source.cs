using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void MoveNext(CurrencyManager myCurrencyManager){
    if(myCurrencyManager.Count == 0) {
       Console.WriteLine("No records to move to.");
       return;
    }
    if (myCurrencyManager.Position == myCurrencyManager.Count - 1){
       Console.WriteLine("You're at end of the records");
    }
    else{
      myCurrencyManager.Position += 1;
    }
 }
 
 private void MoveFirst(CurrencyManager myCurrencyManager){
    if(myCurrencyManager.Count == 0) {
       Console.WriteLine("No records to move to.");
       return;
    }
 
    myCurrencyManager.Position = 0;
 }
 
 private void MovePrevious(CurrencyManager myCurrencyManager){
    if(myCurrencyManager.Count == 0) {
       Console.WriteLine("No records to move to.");
       return;
    }
    if(myCurrencyManager.Position == 0) {
       Console.WriteLine("You're at the beginning of the records.");
    }   
    else{
       myCurrencyManager.Position -= 1;
    }
 }
 
 private void MoveLast(CurrencyManager myCurrencyManager){
    if(myCurrencyManager.Count == 0) {
       Console.WriteLine("No records to move to.");
       return;
    }
    myCurrencyManager.Position = myCurrencyManager.Count - 1;
 }
   
// </Snippet1>
}
