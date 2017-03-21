        public void GetHashCode_Example(PaintEventArgs e)
        {
                     
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Get the hash code for myFont.
            int hashCode = myFont.GetHashCode();
                     
            // Display the hash code in a message box.
            MessageBox.Show(hashCode.ToString());
        }