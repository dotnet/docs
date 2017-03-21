public void ViewMyTextBoxContents()
 {
    // Create a string array and store the contents of the Lines property.
    string[] tempArray = textBox1.Lines;
 
    // Loop through the array and send the contents of the array to debug window.
    for(int counter=0; counter < tempArray.Length;counter++)
    {
       System.Diagnostics.Debug.WriteLine(tempArray[counter]);
    }
 }
 