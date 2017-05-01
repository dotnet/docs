using System;

namespace Win32Form1Namespace {
    
    
    public class Win32Form1 : System.Windows.Forms.Form {
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        
        public Win32Form1() {
            this.InitializeComponent();
            comboBox1.DisplayMember = "String1";
        }
        
        [System.STAThreadAttribute()]
        public static void Main() {
            System.Windows.Forms.Application.Run(new Win32Form1());
        }
        
        private void InitializeComponent() {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2.Location = new System.Drawing.Point(48, 72);
            this.textBox2.Size = new System.Drawing.Size(208, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "";
            this.button1.Location = new System.Drawing.Point(184, 104);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.comboBox1.DropDownWidth = 280;
            this.comboBox1.Location = new System.Drawing.Point(8, 248);
            this.comboBox1.Size = new System.Drawing.Size(280, 21);
            this.comboBox1.TabIndex = 0;
            this.label1.Location = new System.Drawing.Point(48, 16);
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add new item";
            this.label4.Location = new System.Drawing.Point(8, 152);
            this.label4.Size = new System.Drawing.Size(216, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Select field to display in the ComboBox";
            this.textBox1.Location = new System.Drawing.Point(48, 40);
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "";
            this.radioButton1.Location = new System.Drawing.Point(8, 184);
            this.radioButton1.Size = new System.Drawing.Size(128, 24);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "String 1";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton2.Location = new System.Drawing.Point(8, 216);
            this.radioButton2.Size = new System.Drawing.Size(128, 24);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "String 2";
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sring 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(0, 72);
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "String 2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.label4,
                        this.label3,
                        this.label2,
                        this.label1,
                        this.radioButton2,
                        this.radioButton1,
                        this.textBox2,
                        this.textBox1,
                        this.button1,
                        this.comboBox1});
            this.Text = "Win32Form1";
        }
        
//<Snippet6>
        //Sample class to use for the ComboBox item.
        private class Item {
            String string1;
            String string2;

            public Item(String s1, String s2) {
                string1 = s1;
                string2 = s2;
            }

            public String String1 {
                get {
                    return string1;
                }
                set {
                    string1 = value;
                }
            }

            public String String2 {
                get {
                    return string2;
                }
                set {
                    string2 = value;
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e) {
            //Adds a new instance ot the Item class to the ComboBox
            Item newItem = new Item(textBox1.Text, textBox2.Text);
            comboBox1.Items.Add(newItem);
        }
        
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e) {
            //swaps the ComboBox's DisplayMember
            if (radioButton1.Checked) {
                comboBox1.DisplayMember = "String1";
            }
            else{
                comboBox1.DisplayMember = "String2";
            }
        }
//</Snippet6>
    }
}
