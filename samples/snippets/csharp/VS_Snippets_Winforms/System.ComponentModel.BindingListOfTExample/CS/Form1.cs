//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BindingListOfTExamples
{
    public partial class Form1 : Form
    {
        private TextBox textBox2;
        private ListBox listBox1;
        private Button button1;
        private TextBox textBox1;
        Random randomNumber = new Random();
    
        public Form1()
        {
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.textBox1 = new System.Windows.Forms.TextBox();
           this.textBox2 = new System.Windows.Forms.TextBox();
           this.listBox1 = new System.Windows.Forms.ListBox();
           this.button1 = new System.Windows.Forms.Button();
           this.textBox1.Location = new System.Drawing.Point(169, 26);
           this.textBox1.Size = new System.Drawing.Size(100, 20);
           this.textBox1.Text = "Bracket";
           this.textBox2.Location = new System.Drawing.Point(169, 57);
           this.textBox2.ReadOnly = true;
           this.textBox2.Size = new System.Drawing.Size(100, 20);
           this.textBox2.Text = "4343";
           this.listBox1.FormattingEnabled = true;
           this.listBox1.Location = new System.Drawing.Point(12, 12);
           this.listBox1.Size = new System.Drawing.Size(120, 95);
           this.button1.Location = new System.Drawing.Point(180, 83);
           this.button1.Size = new System.Drawing.Size(75, 23);
           this.button1.Text = "Add New Item";
           this.button1.Click += new System.EventHandler(this.button1_Click);
           this.ClientSize = new System.Drawing.Size(292, 266);
           this.Controls.Add(this.button1);
           this.Controls.Add(this.listBox1);
           this.Controls.Add(this.textBox2);
           this.Controls.Add(this.textBox1);
           this.Text = "Parts Form";
           this.Load += new EventHandler(Form1_Load);
          
        }
    
        void Form1_Load(object sender, EventArgs e)
        {
            InitializeListOfParts();
            listBox1.DataSource = listOfParts;
            listBox1.DisplayMember = "PartName";
            listOfParts.AddingNew += new AddingNewEventHandler(listOfParts_AddingNew);
            listOfParts.ListChanged += new ListChangedEventHandler(listOfParts_ListChanged);
            
        }

       

        //<snippet2>
        // Declare a new BindingListOfT with the Part business object.
        BindingList<Part> listOfParts; 
        private void InitializeListOfParts()
        {
            // Create the new BindingList of Part type.
            listOfParts = new BindingList<Part>();
    
            // Allow new parts to be added, but not removed once committed.        
            listOfParts.AllowNew = true;
            listOfParts.AllowRemove = false;

            // Raise ListChanged events when new parts are added.
            listOfParts.RaiseListChangedEvents = true;

            // Do not allow parts to be edited.
            listOfParts.AllowEdit = false;
            
            // Add a couple of parts to the list.
            listOfParts.Add(new Part("Widget", 1234));
            listOfParts.Add(new Part("Gadget", 5647));
        }
        //</snippet2>

        
        //<snippet3>
        // Create a new part from the text in the two text boxes.
        void listOfParts_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Part(textBox1.Text, int.Parse(textBox2.Text));
            
        }
        //</snippet3>

        
        //<snippet4>
        // Add the new part unless the part number contains
        // spaces. In that case cancel the add.
        private void button1_Click(object sender, EventArgs e)
        {
            Part newPart = listOfParts.AddNew();

            if (newPart.PartName.Contains(" "))
            {
                MessageBox.Show("Part names cannot contain spaces.");
                listOfParts.CancelNew(listOfParts.IndexOf(newPart));
            }
            else
            {
                textBox2.Text = randomNumber.Next(9999).ToString();
                textBox1.Text = "Enter part name";
            }
        }
        //</snippet4>

        //<snippet5>
        void listOfParts_ListChanged(object sender, ListChangedEventArgs e)
        {
            MessageBox.Show(e.ListChangedType.ToString());
        }
        //</snippet5>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

    }
    
    // A simple business object for example purposes.
    public class Part
    {
        private string name;
        private int number;
        public Part() { }
        public Part(string nameForPart, int numberForPart)
        {
            PartName = nameForPart;
            PartNumber = numberForPart;
        }

        public string PartName
        {
            get { return name; }
            set { name = value; }
        }

        public int PartNumber
        {
            get { return number; }
            set { number = value; }
        }
    }
}
//</snippet1>