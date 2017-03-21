   // Use the ParseChildren attribute to set the ChildrenAsProperties
   // and DefaultProperty properties. Using this constructor, the
   // control parses all child controls as properties and must define
   // a public property named Employees, which it declares as
   // an ArrayList. Nested (child) elements must correspond to
   // child elements of the Employees property or to other
   // properties of the control.  
   [ParseChildren(true, "Employees")]
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
         label.BackColor = System.Drawing.Color.Beige;
         label.ForeColor = System.Drawing.Color.Red;
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
         table.BackColor = System.Drawing.Color.Beige;
         table.ForeColor = System.Drawing.Color.Red;
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