using System;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;


public class Form1: Form {

 protected DataSet DS;

 protected void Method(TraceContext Context) {
// <Snippet1>
if (Context.IsEnabled) { 
   for (int i=0; i<DS.Tables["Categories"].Rows.Count; i++) { 
     Trace.Write("ProductCategory", DS.Tables["Categories"].Rows[i][0].ToString());
    }
}
   
// </Snippet1>
    }
}
