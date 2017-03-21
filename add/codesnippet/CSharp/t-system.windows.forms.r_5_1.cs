        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton selectedrb;
        private Button getSelectedRB;

        public void InitializeRadioButtons()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.getSelectedRB = new System.Windows.Forms.Button();

            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.getSelectedRB);
            this.groupBox1.Location = new System.Drawing.Point(30, 100);
            this.groupBox1.Size = new System.Drawing.Size(220, 125);
            this.groupBox1.Text = "Radio Buttons";

            this.radioButton2.Location = new System.Drawing.Point(31, 53);
            this.radioButton2.Size = new System.Drawing.Size(67, 17);
            this.radioButton2.Text = "Choice 2";
            this.radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.radioButton1.Location = new System.Drawing.Point(31, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.Text = "Choice 1";
            this.radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.getSelectedRB.Location = new System.Drawing.Point(10, 75);
            this.getSelectedRB.Size = new System.Drawing.Size(200, 25);
            this.getSelectedRB.Text = "Get selected RadioButton";
            this.getSelectedRB.Click += new EventHandler(getSelectedRB_Click);

            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.groupBox1);
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                selectedrb = rb;
            }
        }

        // Show the text of the selected RadioButton.
        void getSelectedRB_Click(object sender, EventArgs e)
        {
            MessageBox.Show(selectedrb.Text);
        }
        