using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;

    public void Method() {
// <Snippet1>
UniqueConstraint uniqueConstraint = new UniqueConstraint(
    DataSet1.Tables["Table1"].Columns["Column1"]);
// </Snippet1>

    }

}