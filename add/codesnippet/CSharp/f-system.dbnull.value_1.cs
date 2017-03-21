   private void OutputLabels(DataTable dt)
   {
      string label; 

      // Iterate rows of table
      foreach (DataRow row in dt.Rows)
      {
         int labelLen;
         label = String.Empty;
         label += AddFieldValue(label, row, "Title");
         label += AddFieldValue(label, row, "FirstName");
         label += AddFieldValue(label, row, "MiddleInitial");
         label += AddFieldValue(label, row, "LastName");
         label += AddFieldValue(label, row, "Suffix");
         label += "\n";
         label += AddFieldValue(label, row, "Address1");
         label += AddFieldValue(label, row, "AptNo");
         label += "\n";
         labelLen = label.Length;
         label += AddFieldValue(label, row, "Address2");
         if (label.Length != labelLen)
            label += "\n";
         label += AddFieldValue(label, row, "City");
         label += AddFieldValue(label, row, "State");
         label += AddFieldValue(label, row, "Zip");
         Console.WriteLine(label);
         Console.WriteLine();
      }
   }

   private string AddFieldValue(string label, DataRow row, 
                                string fieldName) 
   {                                
      if (! DBNull.Value.Equals(row[fieldName])) 
         return (string) row[fieldName] + " ";
      else
         return String.Empty;
   }