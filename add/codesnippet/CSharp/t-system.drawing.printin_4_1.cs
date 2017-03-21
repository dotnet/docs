 public void Printing(string printer) {
   try {
     streamToPrint = new StreamReader (filePath);
     try {
       printFont = new Font("Arial", 10);
       PrintDocument pd = new PrintDocument(); 
       pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
       // Specify the printer to use.
       pd.PrinterSettings.PrinterName = printer;

       if (pd.PrinterSettings.IsValid) {
          pd.Print();
       } 
       else {	
          MessageBox.Show("Printer is invalid.");
       }
     } 
     finally {
       streamToPrint.Close();
     }
   } 
   catch(Exception ex) {
     MessageBox.Show(ex.Message);
   }
 }
 