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