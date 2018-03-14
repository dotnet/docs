// This example demonstrates the StringBuilder.AppendFormat method
//<snippet1>
using System;
using System.Text;
using System.Globalization;

class Sample 
{
    static StringBuilder sb = new StringBuilder();

    public static void Main() 
    {
    int    var1   = 111;
    float  var2   = 2.22F;
    string var3   = "abcd";
    object[] var4 = {3, 4.4, 'X'};

    Console.WriteLine();
    Console.WriteLine("StringBuilder.AppendFormat method:");
    sb.AppendFormat("1) {0}", var1);
    Show(sb);
    sb.AppendFormat("2) {0}, {1}", var1, var2);
    Show(sb);
    sb.AppendFormat("3) {0}, {1}, {2}", var1, var2, var3);
    Show(sb);
    sb.AppendFormat("4) {0}, {1}, {2}", var4);
    Show(sb);
    CultureInfo ci = new CultureInfo("es-ES", true);
    sb.AppendFormat(ci, "5) {0}", var2);
    Show(sb);
    }

    public static void Show(StringBuilder sbs)
    {
    Console.WriteLine(sbs.ToString());
    sb.Length = 0;
    }
}
/*
This example produces the following results:

StringBuilder.AppendFormat method:
1) 111
2) 111, 2.22
3) 111, 2.22, abcd
4) 3, 4.4, X
5) 2,22
*/
//</snippet1>