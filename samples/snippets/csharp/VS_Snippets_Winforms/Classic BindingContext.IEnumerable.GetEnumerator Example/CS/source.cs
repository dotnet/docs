using System;
using System.Collections;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 private void GetManagerEnumerator(){
    IEnumerator myEnumerator;
    myEnumerator = ((IEnumerable)this.BindingContext).GetEnumerator();
    ForEachEnumerator();
 }
 
 private void ForEachEnumerator(){
    foreach( IEnumerator myEnumerator in this.BindingContext){
       Console.WriteLine(myEnumerator.ToString());
    }
 } 
// </Snippet1>
}
