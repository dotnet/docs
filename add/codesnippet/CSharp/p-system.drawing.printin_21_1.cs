public void Printing(){
   try{
     streamToPrint = new StreamReader (filePath);
     try{
       printFont = new Font("Arial", 10);
       PrintDocument pd = new PrintDocument(); 
       pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
       pd.PrinterSettings.PrinterName = printer;
       // Create a new instance of Margins with 1-inch margins.
       Margins margins = new Margins(100,100,100,100);
       pd.DefaultPageSettings.Margins = margins;
       pd.Print();
     } 
     finally{
       streamToPrint.Close() ;
     }
   } 
   catch(Exception ex){ 
     MessageBox.Show(ex.Message);
   }
 }
 