using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        Console.WriteLine("Hi!");
    }
}

// System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)
public class CompareSample1_1
{
    //<Snippet2>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet2>
}

// System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)
public class CompareSample1_2
{
    //<Snippet3>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet3>
}

//System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,System.Boolean)
public class CompareSample2_1
{
    //<Snippet4>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet4>
}

//System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,System.Boolean)
public class CompareSample2_2
{
    //<Snippet5>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet5>
}


//System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,
//  System.Boolean,System.Globalization.CultureInfo)
public class CompareSample3_1
{
    //<Snippet6>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet6>
}

//System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32,
//  System.Boolean,System.Globalization.CultureInfo)
public class CompareSample3_2
{
    //<Snippet7>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet7>
}

//System.String.Compare(System.String,System.Int32,System.String,System.Int32,
//  System.Int32,System.StringComparison)
public class CompareSample4_1
{
    //<Snippet8>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet8>
}

//System.String.Compare(System.String,System.Int32,System.String,System.Int32,
//  System.Int32,System.StringComparison)
public class CompareSample4_2
{
    //<Snippet9>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet9>
}

//System.String.Compare(System.String,System.String)
public class CompareSample5_1
{
    //<Snippet10>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet10>
}

//System.String.Compare(System.String,System.String)
public class CompareSample5_2
{
    //<Snippet11>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet11>
}

//System.String.Compare(System.String,System.String,System.Boolean)
public class CompareSample6_1
{
    //<Snippet12>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet12>
}

//System.String.Compare(System.String,System.String,System.Boolean)
public class CompareSample6_2
{
    //<Snippet13>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet13>
}

//System.String.Compare(System.String,System.String,System.Boolean,System.Globalization.CultureInfo)
public class CompareSample7_1
{
    //<Snippet14>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet14>
}

//System.String.Compare(System.String,System.String,System.Boolean,System.Globalization.CultureInfo)
public class CompareSample7_2
{
    //<Snippet15>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet15>
}

//System.String.Compare(System.String,System.String,System.StringComparison)
public class CompareSample8_1
{
    //<Snippet16>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, true) == 0);
    }
    //</Snippet16>
}

//System.String.Compare(System.String,System.String,System.StringComparison)
public class CompareSample8_2
{
    //<Snippet17>
    static bool IsFileURI(String path)
    {
        return (String.Compare(path, 0, "file:", 0, 5, StringComparison.OrdinalIgnoreCase) == 0);
    }
    //</Snippet17>
}
