        // This example demonstrates the use of the ControlAdded and
        // ControlRemoved events. This example assumes that two Button controls
        // are added to the form and connected to the addControl_Click and
        // removeControl_Click event-handler methods.
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Connect the ControlRemoved and ControlAdded event handlers
            // to the event-handler methods.
            // ControlRemoved and ControlAdded are not available at design time.
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.Control_Removed);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_Added);
        }

        private void Control_Added(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            MessageBox.Show("The control named " + e.Control.Name + " has been added to the form.");
        }

        private void Control_Removed(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            MessageBox.Show("The control named " + e.Control.Name + " has been removed from the form.");
        }

        // Click event handler for a Button control. Adds a TextBox to the form.
        private void addControl_Click(object sender, System.EventArgs e)
        {
            // Create a new TextBox control and add it to the form.
            TextBox textBox1 = new TextBox();
            textBox1.Size = new Size(100,10);
            textBox1.Location = new Point(10,10);
            // Name the control in order to remove it later. The name must be specified
            // if a control is added at run time.
            textBox1.Name = "textBox1";

            // Add the control to the form's control collection.
            this.Controls.Add(textBox1);
        }

        // Click event handler for a Button control.
        // Removes the previously added TextBox from the form.
        private void removeControl_Click(object sender, System.EventArgs e)
        {
            // Loop through all controls in the form's control collection.
            foreach (Control tempCtrl in this.Controls)
            {
                // Determine whether the control is textBox1,
                // and if it is, remove it.
                if (tempCtrl.Name == "textBox1")
                {
                    this.Controls.Remove(tempCtrl);
                }
            }
        }