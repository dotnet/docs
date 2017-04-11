// <Snippet1>
namespace WindowsApplication1
{
   using System;
   using System.Drawing;
   using System.Collections;
   using System.ComponentModel;
   using System.Windows.Forms;
   using System.Data;
   using System.IO ;

   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.CheckedListBox checkedListBox1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Button button3;
        private System.ComponentModel.Container components;
      
      public Form1()
      {
            InitializeComponent();

         // Sets up the initial objects in the CheckedListBox.
            string[] myFruit = {"Apples", "Oranges","Tomato"};
         checkedListBox1.Items.AddRange(myFruit);

            // Changes the selection mode from double-click to single click.
         checkedListBox1.CheckOnClick = true;
      }

      protected override void Dispose( bool disposing )
	  {
		if( disposing )
		{
			if (components != null) 
			{
			  components.Dispose();
			}
		}
		base.Dispose( disposing );
	  }

      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.textBox1.Location = new System.Drawing.Point(144, 64);
         this.textBox1.Size = new System.Drawing.Size(128, 20);
         this.textBox1.TabIndex = 1;
         this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
         this.checkedListBox1.Location = new System.Drawing.Point(16, 64);
         this.checkedListBox1.Size = new System.Drawing.Size(120, 184);
         this.checkedListBox1.TabIndex = 0;
         this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
         this.listBox1.Location = new System.Drawing.Point(408, 64);
         this.listBox1.Size = new System.Drawing.Size(128, 186);
         this.listBox1.TabIndex = 3;
         this.button1.Enabled = false;
         this.button1.Location = new System.Drawing.Point(144, 104);
         this.button1.Size = new System.Drawing.Size(104, 32);
         this.button1.TabIndex = 2;
         this.button1.Text = "Add Fruit";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         this.button2.Enabled = false;
         this.button2.Location = new System.Drawing.Point(288, 64);
         this.button2.Size = new System.Drawing.Size(104, 32);
         this.button2.TabIndex = 2;
         this.button2.Text = "Show Order";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         this.button3.Enabled = false;
         this.button3.Location = new System.Drawing.Point(288, 104);
         this.button3.Size = new System.Drawing.Size(104, 32);
         this.button3.TabIndex = 2;
         this.button3.Text = "Save Order";
         this.button3.Click += new System.EventHandler(this.button3_Click);
         this.ClientSize = new System.Drawing.Size(563, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {this.listBox1,
                                                        this.button3,
                                                        this.button2,
                                                        this.button1,
                                                        this.textBox1,
                                                        this.checkedListBox1});
         this.Text = "Fruit Order";
      }

      [STAThread]
      public static void Main(string[] args) 
      {
         Application.Run(new Form1());
      }

      // Adds the string if the text box has data in it.
      private void button1_Click(object sender, System.EventArgs e)
      {
         if(textBox1.Text != "")
         {
            if(checkedListBox1.CheckedItems.Contains(textBox1.Text)== false)
               checkedListBox1.Items.Add(textBox1.Text,CheckState.Checked);
            textBox1.Text = "";
         }

      }
      // Activates or deactivates the Add button.
      private void textBox1_TextChanged(object sender, System.EventArgs e)
      {
         if (textBox1.Text == "")
         {
            button1.Enabled = false;
         }
         else
         {
            button1.Enabled = true;
         }
            
        }

      // Moves the checked items from the CheckedListBox to the listBox.
      private void button2_Click(object sender, System.EventArgs e)
      {
         listBox1.Items.Clear();
         button3.Enabled=false;
         for (int i=0; i< checkedListBox1.CheckedItems.Count;i++)
         {
            listBox1.Items.Add(checkedListBox1.CheckedItems[i]);
         }
         if (listBox1.Items.Count>0)
            button3.Enabled=true;
         
      }
        // Activates the move button if there are checked items.
      private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         if(e.NewValue==CheckState.Unchecked)
         {
            if(checkedListBox1.CheckedItems.Count==1)
            {
               button2.Enabled = false;
            }
         }
         else
         {
            button2.Enabled = true;
         }
      }

        // Saves the items to a file.
      private void button3_Click(object sender, System.EventArgs e)
      {   
         // Insert code to save a file.
         listBox1.Items.Clear();
         IEnumerator myEnumerator;
         myEnumerator = checkedListBox1.CheckedIndices.GetEnumerator();
         int y;
         while (myEnumerator.MoveNext() != false)
         {
            y =(int) myEnumerator.Current;
            checkedListBox1.SetItemChecked(y, false);
         }
         button3.Enabled = false ;
      }        
    }
}
   
// </Snippet1>
