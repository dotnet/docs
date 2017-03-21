 private void GetMyFormatInfomation() {
    // Creates a DataFormats.Format for the Unicode data format.
    DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.UnicodeText);
 
    // Displays the contents of myFormat.
    textBox1.Text = "ID value: " + myFormat.Id + '\n' +
       "Format name: " + myFormat.Name;
 }
 