
	//Reference the GDI DeleteObject method.
        [System.Runtime.InteropServices.DllImport("GDI32.dll")]
        public static extern bool DeleteObject(IntPtr objectHandle); 

        public void ToHfont_Example(PaintEventArgs e)
        {
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Get a handle to the Font object.
            IntPtr hFont = myFont.ToHfont();
                     
            // Display a message box with the value of hFont.
            MessageBox.Show(hFont.ToString());
            
            //Dispose of the hFont.
            DeleteObject(hFont);
        }