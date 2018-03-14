using System;
using System.IO;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

namespace test
{

public class Class1: IBinarySerialize
{

[STAThread]
static void Main(string [] args)
{
    string fileName = "info.dat";
    Class1 temp = new Class1();

    FileStream fs = new FileStream(fileName, FileMode.Create);
    BinaryWriter w = new BinaryWriter(fs);

    temp.Write(w);

    w.Close();
    fs.Close();

    fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
    BinaryReader r = new BinaryReader(fs);

    temp.Read(r);

    Console.WriteLine("String value: " + temp.StringValue);
    Console.WriteLine("Double value: " + temp.DoubleValue);
 
    r.Close();
    fs.Close();
    
    
}

public string StringValue;
public double DoubleValue;

//<Snippet1>
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
//</Snippet1>

//<Snippet2>
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
//</Snippet2>
    
}

}