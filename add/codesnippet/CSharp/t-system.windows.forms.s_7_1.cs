        private void button1_Click(object sender, System.EventArgs e)
        {
            // For each screen, add the screen properties to a list box.
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                listBox1.Items.Add("Device Name: " + screen.DeviceName);
                listBox1.Items.Add("Bounds: " + 
                    screen.Bounds.ToString());
                listBox1.Items.Add("Type: " + 
                    screen.GetType().ToString());
                listBox1.Items.Add("Working Area: " + 
                    screen.WorkingArea.ToString());
                listBox1.Items.Add("Primary Screen: " + 
                    screen.Primary.ToString());
            }

        }