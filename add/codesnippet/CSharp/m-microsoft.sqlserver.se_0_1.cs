// The binary layout is as follows:
//    Bytes 0 - 19: string text, padded to the right with null characters
//    Bytes 20+: Double value
public void Write(System.IO.BinaryWriter w)
{        
    int maxStringSize = 20;
    string stringValue = "The value of PI: ";
    string paddedString; 
    double value = 3.14159;

    // Pad the string from the right with null characters.
    paddedString = stringValue.PadRight(maxStringSize, '\0');

    // Write the string value one byte at a time.
    for (int i = 0; i < paddedString.Length; i++)
    {
        w.Write(paddedString[i]);
    }

    // Write the double value.
    w.Write(value);
}