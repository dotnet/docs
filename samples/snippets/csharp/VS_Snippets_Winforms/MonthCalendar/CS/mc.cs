//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO ;

namespace MonthCalender
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;        
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;        
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.Closing += new CancelEventHandler(this.this_Closing);
            textBox1.LostFocus += new EventHandler(this.textBox1_LostFocus);
            setCalendarLook();

            dateTimePicker1.Value = monthCalendar1.MinDate ;
            dateTimePicker2.Value = monthCalendar1.MaxDate ;
            textBox1.Text = monthCalendar1.MaxSelectionCount.ToString();
            for(Day day = Day.Monday;day<=Day.Default;day++)
            {
                comboBox1.Items.Add(day.ToString());
            }
            comboBox1.SelectedItem = comboBox1.Items[comboBox1.Items.IndexOf(monthCalendar1.FirstDayOfWeek.ToString())];
            loadDates();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 16);
            this.label4.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max Selection Count";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.TabIndex = 4;
            this.label2.Text = "Min Date";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.TabIndex = 6;
            this.label3.Text = "Max Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(8, 128);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(216, 192);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(216, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add Description";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(24, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_keypress);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validate);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(488, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 24);
            this.button3.TabIndex = 12;
            this.button3.Text = "Clear All";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 160);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 24);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Show Todays Date";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(488, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(176, 160);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(8, 192);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 24);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "Show Today Circle";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(216, 8);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(488, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 24);
            this.button2.TabIndex = 11;
            this.button2.Text = "Delete Selected";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownWidth = 121;
            this.comboBox1.Location = new System.Drawing.Point(8, 232);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Text = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(672, 273);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.comboBox1,
                                                                          this.checkBox2,
                                                                          this.checkBox1,
                                                                          this.button3,
                                                                          this.button2,
                                                                          this.button1,
                                                                          this.textBox2,
                                                                          this.label4,
                                                                          this.dateTimePicker2,
                                                                          this.label3,
                                                                          this.dateTimePicker1,
                                                                          this.label2,
                                                                          this.textBox1,
                                                                          this.label1,
                                                                          this.listBox1,
                                                                          this.monthCalendar1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        //<Snippet8>
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if(checkBox1.Checked == true)
                monthCalendar1.ShowToday = true;
            else
                monthCalendar1.ShowToday = false;
        }
        //</Snippet8>

        //<Snippet9>
        private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            if(checkBox2.Checked == true)
                monthCalendar1.ShowTodayCircle = true;
            else
                monthCalendar1.ShowTodayCircle = false;
        }
        //</Snippet9>

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value != monthCalendar1.MinDate)
            {    
                if(dateTimePicker1.Value>monthCalendar1.MaxDate)
                    dateTimePicker2.Value = dateTimePicker1.Value.AddDays(monthCalendar1.MaxSelectionCount);
                monthCalendar1.MinDate = dateTimePicker1.Value;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker2.Value != monthCalendar1.MaxDate)
            {    
                if(dateTimePicker2.Value<monthCalendar1.MinDate)
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-monthCalendar1.MaxSelectionCount);
                monthCalendar1.MaxDate = dateTimePicker2.Value;
            }
        }
        private void textBox1_keypress (object sender, KeyPressEventArgs k)
        {
            k.Handled = true ;
            if((k.KeyChar >= '0' && k.KeyChar <= '9') ||
                k.KeyChar == '\t' ||
                k.KeyChar == '\b' ||
                k.KeyChar == '\r')
            {
                k.Handled = false ;
            }
            if(k.KeyChar == '\r')
            {
                monthCalendar1.Focus();
            }
        }
        private void textBox1_Validate(object sender, CancelEventArgs c)
        {
            if( int.Parse(textBox1.Text) < 1 || int.Parse(textBox1.Text) > 365)
            {
                MessageBox.Show("Max Selection Count must be greater than zero and less than 366.");
                c.Cancel = true;
            }
        }
        //<Snippet5>
        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            monthCalendar1.MaxSelectionCount = int.Parse(textBox1.Text);
        }
        //</Snippet5>

        //<Snippet6>
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            monthCalendar1.FirstDayOfWeek = (Day) comboBox1.SelectedIndex ;
        }
        //</Snippet6>

        private void monthCalendar1_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            label4.Text = "Enter description for " + monthCalendar1.SelectionStart.ToShortDateString();
            if (monthCalendar1.SelectionEnd != monthCalendar1.SelectionStart)
                label4.Text += " to " + monthCalendar1.SelectionEnd.ToShortDateString();

            textBox2.Enabled = true ;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            for(int i = 0;monthCalendar1.SelectionEnd >= monthCalendar1.SelectionStart.AddDays(i);i++)
            {
                listBox1.Items.Add(monthCalendar1.SelectionStart.AddDays(i).ToShortDateString() + " " + textBox2.Text);
            }
            label4.Text = "";
            textBox2.Enabled = false;
            button1.Enabled = false ;
            button3.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            if(textBox2.Text.Trim() == "")
            {    
                textBox2.Text = textBox2.Text.Trim();
                button1.Enabled = false ;
            }
            else
                button1.Enabled = true ;
        }
        private void this_Closing (object Sender, CancelEventArgs c)
        {
            StreamWriter myOutputStream = File.CreateText("myDates.txt");
            IEnumerator myDates = listBox1.Items.GetEnumerator();
            while(myDates.MoveNext() == true)
            {

                myOutputStream.WriteLine(myDates.Current.ToString());
            }
            myOutputStream.Flush();
            myOutputStream.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
                button2.Enabled = true;
            else
                button2.Enabled = false;
        }
        //<Snippet2>    
        // The following method uses Add to add dates that are 
        // bolded, followed by an UpdateBoldedDates to make the
        // added dates visible.
        
        private void loadDates()
        {
            String myInput ;
            try
            {
                StreamReader myInputStream = File.OpenText("myDates.txt");
                while((myInput = myInputStream.ReadLine()) != null)
                {
                    monthCalendar1.AddBoldedDate(DateTime.Parse(myInput.Substring(0,myInput.IndexOf(" "))));
                    listBox1.Items.Add(myInput);
                }
                monthCalendar1.UpdateBoldedDates();
                myInputStream.Close();
                File.Delete("myDates.txt");
            }catch(FileNotFoundException fnfe)
            {
                // Code to handle a file that could not be found should go here.
            Console.WriteLine("An error occurred: '{0}'", fnfe);
            }             
        }
        //</Snippet2>

        //<Snippet3>
        private void button2_Click(object sender, System.EventArgs e)
        {
            monthCalendar1.RemoveBoldedDate(DateTime.Parse(listBox1.SelectedItem.ToString().Substring(0,listBox1.SelectedItem.ToString().IndexOf(" "))));
            monthCalendar1.UpdateBoldedDates();
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if(listBox1.Items.Count == 0)
                button3.Enabled = false;
        }
        //</Snippet3>

        //<Snippet4>
        private void button3_Click(object sender, System.EventArgs e)
        {
            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.UpdateBoldedDates();
            listBox1.Items.Clear();
            button3.Enabled = false ;
        }
        //</Snippet4>
        //<Snippet7>
        private void setCalendarLook()
        {
            monthCalendar1.MinDate = DateTime.Parse("1/1/1900");
            monthCalendar1.MaxDate = DateTime.Parse("12/31/2099");
            
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }
        //</Snippet7>
    }
}
//</Snippet1>
