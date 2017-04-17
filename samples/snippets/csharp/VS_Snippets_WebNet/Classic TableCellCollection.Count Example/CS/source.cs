using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Page1: Page
{
 protected Table Table1;
// <Snippet1>
void Button_Click_Coord(object sender, EventArgs e) 
 {
          
    for (int i=0; i<Table1.Rows.Count; i++) 
    {          
       for (int j=0; j<Table1.Rows[i].Cells.Count; j++) 
       {
                
          Table1.Rows[i].Cells[j].Text = "(" + 
             j.ToString() + ", " + i.ToString() + ")";
                
       }            
    }
 
 }
 
// </Snippet1>
}
