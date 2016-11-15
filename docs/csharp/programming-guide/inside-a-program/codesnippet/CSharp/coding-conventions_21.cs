        // Using a lambda expression shortens the following traditional definition.
        public Form1()
        {
            this.Click += new EventHandler(Form1_Click);
        }

        void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((MouseEventArgs)e).Location.ToString());
        }