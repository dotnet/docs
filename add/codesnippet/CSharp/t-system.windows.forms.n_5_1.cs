        private NumericUpDown numericUpDown1;
        private void InitializeAcceleratedUpDown()
        {
            numericUpDown1 = new NumericUpDown();
            numericUpDown1.Location = new Point(40, 40);
            numericUpDown1.Maximum = 40000;
            numericUpDown1.Minimum = -40000;

            // Add some accelerations to the control.
            numericUpDown1.Accelerations.Add(new NumericUpDownAcceleration(2,100));
            numericUpDown1.Accelerations.Add(new NumericUpDownAcceleration(5, 1000));
            numericUpDown1.Accelerations.Add(new NumericUpDownAcceleration(8, 5000));
            Controls.Add(numericUpDown1);
       
        }