        // This code example demonstrates using the Padding property to 
        // create a border around a RichTextBox control.
        public Form1()
        {
            InitializeComponent();

            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        }