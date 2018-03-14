using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomerCodeExamples
{
   public class TV1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.Button button1;

	 public TV1()
	 {
	    InitializeComponent();
	 }

         [STAThread]
         static void Main() 
         {
            Application.Run(new TV1());
         }

         private void InitializeComponent()
	 {
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // treeView1
         // 
         this.treeView1.ImageIndex = -1;
         this.treeView1.Name = "treeView1";
         this.treeView1.SelectedImageIndex = -1;
         this.treeView1.Size = new System.Drawing.Size(128, 240);
         this.treeView1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(216, 248);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // TV1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {this.button1,
                                                                      this.treeView1});
         this.Name = "TV1";
         this.Text = "TV1";
         this.ResumeLayout(false);

      }

// <snippet1>

// The basic Customer class.
public class Customer : System.Object
{
   private string custName = "";
   protected ArrayList custOrders = new ArrayList();

   public Customer(string customername)
   {
      this.custName = customername;
   }

   public string CustomerName
   {      
      get{return this.custName;}
      set{this.custName = value;}
   }

   public ArrayList CustomerOrders 
   {
      get{return this.custOrders;}
   }

} // End Customer class 


// The basic customer Order class.
public class Order : System.Object
{
   private string ordID = "";

   public Order(string orderid)
   {
      this.ordID = orderid;
   }

   public string OrderID
   {      
      get{return this.ordID;}
      set{this.ordID = value;}
   }

} // End Order class

// Create a new ArrayList to hold the Customer objects.
private ArrayList customerArray = new ArrayList(); 

private void FillMyTreeView()
{
   // Add customers to the ArrayList of Customer objects.
   for(int x=0; x<1000; x++)
   {
      customerArray.Add(new Customer("Customer" + x.ToString()));
   }

   // Add orders to each Customer object in the ArrayList.
   foreach(Customer customer1 in customerArray)
   {
      for(int y=0; y<15; y++)
      {
         customer1.CustomerOrders.Add(new Order("Order" + y.ToString()));    
      }
   }

   // Display a wait cursor while the TreeNodes are being created.
   Cursor.Current = new Cursor("MyWait.cur");
        
   // Suppress repainting the TreeView until all the objects have been created.
   treeView1.BeginUpdate();

   // Clear the TreeView each time the method is called.
   treeView1.Nodes.Clear();

   // Add a root TreeNode for each Customer object in the ArrayList.
   foreach(Customer customer2 in customerArray)
   {
      treeView1.Nodes.Add(new TreeNode(customer2.CustomerName));
          
      // Add a child treenode for each Order object in the current Customer object.
      foreach(Order order1 in customer2.CustomerOrders)
      {
         treeView1.Nodes[customerArray.IndexOf(customer2)].Nodes.Add(
           new TreeNode(customer2.CustomerName + "." + order1.OrderID));
      }
   }

   // Reset the cursor to the default for all controls.
   Cursor.Current = Cursors.Default;

   // Begin repainting the TreeView.
   treeView1.EndUpdate();
}
// </snippet1>
      
      
   private void button1_Click(object sender, System.EventArgs e)
   {
      this.FillMyTreeView();      
   }
} // End TV1 Class



} // End NameSpace
