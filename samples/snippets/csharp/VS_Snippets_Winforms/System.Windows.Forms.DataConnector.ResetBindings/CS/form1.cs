//<snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace System_Windows_Forms_UpdateBinding
{
	class Form1 : Form
	{
        // Declare the objects on the form.
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private BindingSource bindingSource1;
        ArrayList states;

		public Form1()
		{
            // Basic form setup.
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1.Location = new System.Drawing.Point(12, 18);
            this.button1.Size = new System.Drawing.Size(119, 38);
            this.button1.Text = "RemoveAt(0)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.textBox1.Location = new System.Drawing.Point(55, 75);
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.Text = "Capital:";
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.Text = "State:";
            this.textBox2.Location = new System.Drawing.Point(55, 110);
            this.textBox2.Size = new System.Drawing.Size(119, 20);
            this.textBox2.ReadOnly = true;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Text = "Form1";

            // Create an ArrayList containing some of the State objects.
            states = new ArrayList();
            states.Add(new State("California", "Sacramento"));
            states.Add(new State("Oregon", "Salem"));
            states.Add(new State("Washington", "Olympia"));
            states.Add(new State("Idaho", "Boise"));
            states.Add(new State("Utah", "Salt Lake City"));
            states.Add(new State("Hawaii", "Honolulu"));
            states.Add(new State("Colorado", "Denver"));
            states.Add(new State("Montana", "Helena"));

            bindingSource1 = new BindingSource();

            // Bind BindingSource1 to the list of states.
            bindingSource1.DataSource = states;

            // Bind the two text boxes to properties of State.
            textBox1.DataBindings.Add("Text", bindingSource1, "Name");
            textBox2.DataBindings.Add("Text", bindingSource1, "Capital");
		}

        //<snippet3>
        private void button1_Click(object sender, EventArgs e)
        {
            // If items remain in the list, remove the first item. 
            if (states.Count > 0)
            {
                states.RemoveAt(0);

                // Call ResetBindings to update the textboxes.
                bindingSource1.ResetBindings(false);
            }
        }
        //</snippet3>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());

        }
    
        // The State class to add to the ArrayList.
		private class State
		{
			private string stateName;
			public string Name 
			{
				get {return stateName;}
			}

			private string stateCapital;
			public string Capital 
			{
				get {return stateCapital;}
			}

			public State ( string name, string capital)
			{
                stateName = name;
                stateCapital = capital;
			}
		}
              
	}
}
//</snippet1>