// Call this method from the constructor of your form
    private void OtherInitialize() {
       this.Closing += new CancelEventHandler(this.Form1_Closing);
       // Exchange commented line and note the difference.
       this.isDataSaved = true;
       //this.isDataSaved = false;
    }

    private void Form1_Closing(Object sender, CancelEventArgs e) {
       if (!isDataSaved) {
          e.Cancel = true;
          MessageBox.Show("You must save first.");
       }
       else {
          e.Cancel = false;
          MessageBox.Show("Goodbye.");
       }
    }
 