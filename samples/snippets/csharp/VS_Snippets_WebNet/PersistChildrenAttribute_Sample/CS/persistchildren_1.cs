// <snippet1>
using System;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace PersistChildrenSamples
{
   // The child element class.
   [AspNetHostingPermission(SecurityAction.Demand, 
      Level=AspNetHostingPermissionLevel.Minimal)]
   public sealed class Employee
   {
      private String name;
      private String title;
      private String alias;

      public Employee():this ("","",""){}
      
      public Employee (String name, String title, String alias)
      {
         this.name = name;
         this.title = title;
         this.alias = alias;
      }
      public String Name
      {
         get
         {
            return name;
         }
         set
         {
            name = value;
         }
      }
      
      public String Title
      {
         get
         {
            return title;
         }
         set
         {
            title = value;
         }
      }
      
      public String Alias
      {
         get
         {
            return alias;
         }
         set
         {
            alias = value;
         }
      }
   }
// <snippet2>
   // Use the PersistChildren attribute to set the Persist
   // property to false so that none of this class's
   // child controls will be persisted as controls. They will
   // be persisted only as child elements of this class.
   // If you set the PersistChildren attribute to true, or if you
   // do not include this attribute when you create a control,
   // the child controls will be persisted as controls.   
   [PersistChildren(false)]
   [AspNetHostingPermission(SecurityAction.Demand, 
      Level=AspNetHostingPermissionLevel.Minimal)]
   public sealed class CollectionPropertyControl : Control
   {  
      private String header;
      private ArrayList employees = new ArrayList();
      
      public String Header
      {
         get
         {
            return header;
         }
         set
         {
            header = value;
         }
      }


      
      public ArrayList Employees
      {
         get 
         {
            return employees;
         }
      }
      // Override the CreateChildControls method to 
      // add child controls to the Employees property when this
      // custom control is requested from a page.
      protected override void CreateChildControls()
      {
         Label label = new Label();
         label.Text = Header;
         label.BackColor = Color.Beige;
         label.ForeColor = Color.Red;
         Controls.Add(label);
         Controls.Add(new LiteralControl("<BR> <BR>"));

         Table table = new Table();
         TableRow htr = new TableRow();

         TableHeaderCell hcell1 = new TableHeaderCell();    
         hcell1.Text = "Name";
         htr.Cells.Add(hcell1);

         TableHeaderCell hcell2 = new TableHeaderCell();
         hcell2.Text = "Title";
         htr.Cells.Add(hcell2);
         
         TableHeaderCell hcell3 = new TableHeaderCell();
         hcell3.Text = "Alias";
         htr.Cells.Add(hcell3);
         table.Rows.Add(htr);

         table.BorderWidth = 2;
         table.BackColor = Color.Beige;
         table.ForeColor = Color.Red;
         foreach (Employee employee in Employees)
         {
            TableRow tr = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Text = employee.Name;
            tr.Cells.Add(cell1);
            
            TableCell cell2 = new TableCell();
            cell2.Text = employee.Title;
            tr.Cells.Add(cell2);
            
            TableCell cell3 = new TableCell();
            cell3.Text = employee.Alias;
            tr.Cells.Add(cell3);
            
            table.Rows.Add(tr);
         }
         Controls.Add(table);
         
      }
   }
// </snippet2>
}
// </snippet1>