// The binary layout is as follows:
//    Bytes 0 - 19: string text, padded to the right with null characters
//    Bytes 20+: Double value

public void Read(System.IO.BinaryReader r)
{

    int maxStringSize = 20;
    char[] chars;
    int stringEnd;
    string stringValue;
    double doubleValue;

    // Read the characters from the binary stream.
    chars = r.ReadChars(maxStringSize);

    // Find the start of the null character padding.
    stringEnd = Array.IndexOf(chars, '\0');

    if (stringEnd == 0)
    {
        stringValue = null;
        return;
    }

    // Build the string from the array of characters.
    stringValue = new String(chars, 0, stringEnd);

    // Read the double value from the binary stream.
    doubleValue = r.ReadDouble();

    // Set the object's properties equal to the values.
    this.StringValue = stringValue;
    this.DoubleValue = doubleValue;
}