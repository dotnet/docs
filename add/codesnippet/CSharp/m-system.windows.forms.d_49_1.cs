private void CreateMyFormat2() {
    DataFormats.Format myFormat = new DataFormats.Format("AnotherNewFormat", 20916);
 
    // Displays the contents of myFormat.
    textBox1.Text = "ID value: " + myFormat.Id + '\n' +
       "Format name: " + myFormat.Name;
 }
 