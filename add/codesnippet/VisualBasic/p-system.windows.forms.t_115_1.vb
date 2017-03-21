Public Sub ViewMyTextBoxContents()
    Dim counter as Integer
    'Create a string array and store the contents of the Lines property.
    Dim tempArray() as String
    tempArray = textBox1.Lines
    
    'Loop through the array and send the contents of the array to debug window.
    For counter = 0 to tempArray.GetUpperBound(0)
        System.Diagnostics.Debug.WriteLine( tempArray(counter) )
    Next
 End Sub
 