 public void DisplayOleDbErrorCollection(OleDbException exception) 
 {
    for (int i=0; i < exception.Errors.Count; i++)
    {
       MessageBox.Show("Index #" + i + "\n" +
              "Message: " + exception.Errors[i].Message + "\n" +
              "Native: " + exception.Errors[i].NativeError.ToString() + "\n" +
              "Source: " + exception.Errors[i].Source + "\n" +
              "SQL: " + exception.Errors[i].SQLState + "\n");
    }
 }