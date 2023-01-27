//<main>
using System.Globalization;

string name = "Bill";

Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
Console.WriteLine($"Culture = {Thread.CurrentThread.CurrentCulture.DisplayName}");
Console.WriteLine($"   Is 'Bill' the same as 'BILL'? {name.Equals("BILL", StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine($"   Does 'Bill' start with 'BILL'? {name.StartsWith("BILL", true, null)}");
Console.WriteLine();

Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
Console.WriteLine($"Culture = {Thread.CurrentThread.CurrentCulture.DisplayName}");
Console.WriteLine($"   Is 'Bill' the same as 'BILL'? {name.Equals("BILL", StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine($"   Does 'Bill' start with 'BILL'? {name.StartsWith("BILL", true, null)}");

//' The example displays the following output:
//'
//'     Culture = English (United States)
//'        Is 'Bill' the same as 'BILL'? True
//'        Does 'Bill' start with 'BILL'? True
//'     
//'     Culture = Turkish (Turkey)
//'        Is 'Bill' the same as 'BILL'? True
//'        Does 'Bill' start with 'BILL'? False
//</main>

public class Example2
{
    // <culture_sensitive>
    public static bool IsFileURI(string path) =>
        path.StartsWith("FILE:", true, null);
    // </culture_sensitive>
}

public class Example3
{
    // <ordinal>
    public static bool IsFileURI(string path) =>
        path.StartsWith("FILE:", StringComparison.OrdinalIgnoreCase);
    // </ordinal>
}
