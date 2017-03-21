 public void DisplayOleDbErrors(OleDbException exception) 
 {
    for (int i=0; i < exception.Errors.Count; i++)
    {
       MessageBox.Show("Index #" + i + "\n" +
            "Error: " + exception.Errors[i].ToString() + "\n");
    }
 }