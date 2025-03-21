using System;
using System.Globalization;

public class Class1
{
    public static void Main()
    {
        Show_dSpecifier();
        Console.WriteLine();
        Show_ddSpecifier();
        Show_dddSpecifier();
        Show_ddddSpecifier();
        Show_fSpecifiers();
        Show_gSpecifier();
        Show_hSpecifier();
        Show_hhSpecifier();
        ShowHSpecifier();
        ShowHHSpecifier();
        ShowMSpecifier();
        ShowKSpecifier();
        Show_ySpecifier();
        Show_zSpecifier();
    }

    private static void Show_dSpecifier()
    {
        Console.WriteLine("d format specifier");
        // <Snippet1>
        DateTime date1 = new DateTime(2008, 8, 29, 19, 27, 15);

        Console.WriteLine(date1.ToString("d, M",
                          CultureInfo.InvariantCulture));
        // Displays 29, 8

        Console.WriteLine(date1.ToString("d MMMM",
                          CultureInfo.CreateSpecificCulture("en-US")));
        // Displays 29 August
        Console.WriteLine(date1.ToString("d MMMM",
                          CultureInfo.CreateSpecificCulture("es-MX")));
        // Displays 29 agosto
        // </Snippet1>
        Console.WriteLine();
    }

    private static void Show_ddSpecifier()
    {
        Console.WriteLine("dd format specifier");
        // <Snippet2>
        DateTime date1 = new DateTime(2008, 1, 2, 6, 30, 15);

        Console.WriteLine(date1.ToString("dd, MM",
                          CultureInfo.InvariantCulture));
        // 02, 01
        // </Snippet2>
        Console.WriteLine();
    }

    private static void Show_dddSpecifier()
    {
        Console.WriteLine("ddd format specifier");
        // <Snippet3>
        DateTime date1 = new DateTime(2008, 8, 29, 19, 27, 15);

        Console.WriteLine(date1.ToString("ddd d MMM",
                          CultureInfo.CreateSpecificCulture("en-US")));
        // Displays Fri 29 Aug
        Console.WriteLine(date1.ToString("ddd d MMM",
                          CultureInfo.CreateSpecificCulture("fr-FR")));
        // Displays ven. 29 août
        // </Snippet3>
        Console.WriteLine();
    }

    private static void Show_ddddSpecifier()
    {
        Console.WriteLine("dddd format specifier");
        // <Snippet4>
        DateTime date1 = new DateTime(2008, 8, 29, 19, 27, 15);

        Console.WriteLine(date1.ToString("dddd dd MMMM",
                          CultureInfo.CreateSpecificCulture("en-US")));
        // Displays Friday 29 August
        Console.WriteLine(date1.ToString("dddd dd MMMM",
                          CultureInfo.CreateSpecificCulture("it-IT")));
        // Displays venerdì 29 agosto
        // </Snippet4>
        Console.WriteLine();
    }

    private static void Show_fSpecifiers()
    {
        Console.WriteLine("f and F format specifiers");
        // <Snippet5>
        DateTime date1 = new DateTime(2008, 8, 29, 19, 27, 15, 18);
        CultureInfo ci = CultureInfo.InvariantCulture;

        Console.WriteLine(date1.ToString("hh:mm:ss.f", ci));
        // Displays 07:27:15.0
        Console.WriteLine(date1.ToString("hh:mm:ss.F", ci));
        // Displays 07:27:15
        Console.WriteLine(date1.ToString("hh:mm:ss.ff", ci));
        // Displays 07:27:15.01
        Console.WriteLine(date1.ToString("hh:mm:ss.FF", ci));
        // Displays 07:27:15.01
        Console.WriteLine(date1.ToString("hh:mm:ss.fff", ci));
        // Displays 07:27:15.018
        Console.WriteLine(date1.ToString("hh:mm:ss.FFF", ci));
        // Displays 07:27:15.018
        // </Snippet5>
        Console.WriteLine();
    }

    private static void Show_gSpecifier()
    {
        Console.WriteLine("g format specifier");
        // <Snippet6>
        DateTime date1 = new DateTime(70, 08, 04);

        Console.WriteLine(date1.ToString("MM/dd/yyyy g",
                          CultureInfo.InvariantCulture));
        // Displays 08/04/0070 A.D.
        Console.WriteLine(date1.ToString("MM/dd/yyyy g",
                          CultureInfo.CreateSpecificCulture("fr-FR")));
        // Displays 08/04/0070 ap. J.-C.
        // </Snippet6>
        Console.WriteLine();
    }

    private static void Show_hSpecifier()
    {
        Console.WriteLine("h format specifier");
        // <Snippet7>
        DateTime date1;
        date1 = new DateTime(2008, 1, 1, 18, 9, 1);
        Console.WriteLine(date1.ToString("h:m:s.F t",
                          CultureInfo.InvariantCulture));
        // Displays 6:9:1 P
        Console.WriteLine(date1.ToString("h:m:s.F t",
                          CultureInfo.CreateSpecificCulture("el-GR")));
        // Displays 6:9:1 µ
        date1 = new DateTime(2008, 1, 1, 18, 9, 1, 500);
        Console.WriteLine(date1.ToString("h:m:s.F t",
                          CultureInfo.InvariantCulture));
        // Displays 6:9:1.5 P
        Console.WriteLine(date1.ToString("h:m:s.F t",
                          CultureInfo.CreateSpecificCulture("el-GR")));
        // Displays 6:9:1.5 µ
        // </Snippet7>
        Console.WriteLine();
    }

    private static void Show_hhSpecifier()
    {
        Console.WriteLine("hh format specifier");
        // <Snippet8>
        DateTime date1;
        date1 = new DateTime(2008, 1, 1, 18, 9, 1);
        Console.WriteLine(date1.ToString("hh:mm:ss tt",
                          CultureInfo.InvariantCulture));
        // Displays 06:09:01 PM
        Console.WriteLine(date1.ToString("hh:mm:ss tt",
                          CultureInfo.CreateSpecificCulture("hu-HU")));
        // Displays 06:09:01 du.
        date1 = new DateTime(2008, 1, 1, 18, 9, 1, 500);
        Console.WriteLine(date1.ToString("hh:mm:ss.ff tt",
                          CultureInfo.InvariantCulture));
        // Displays 06:09:01.50 PM
        Console.WriteLine(date1.ToString("hh:mm:ss.ff tt",
                          CultureInfo.CreateSpecificCulture("hu-HU")));
        // Displays 06:09:01.50 du.
        // </Snippet8>
        Console.WriteLine();
    }

    private static void ShowHSpecifier()
    {
        Console.WriteLine("H format specifier");
        // <Snippet9>
        DateTime date1 = new DateTime(2008, 1, 1, 6, 9, 1);
        Console.WriteLine(date1.ToString("H:mm:ss",
                          CultureInfo.InvariantCulture));
        // Displays 6:09:01
        // </Snippet9>
        Console.WriteLine();
    }

    private static void ShowHHSpecifier()
    {
        Console.WriteLine("HH format specifier");
        // <Snippet10>
        DateTime date1 = new DateTime(2008, 1, 1, 6, 9, 1);
        Console.WriteLine(date1.ToString("HH:mm:ss",
                          CultureInfo.InvariantCulture));
        // Displays 06:09:01
        // </Snippet10>
        Console.WriteLine();
    }

    private static void ShowMSpecifier()
    {
        Console.WriteLine("M format specifier");
        // <Snippet11>
        DateTime date1 = new DateTime(2008, 8, 18);
        Console.WriteLine(date1.ToString("(M) MMM, MMMM",
                          CultureInfo.CreateSpecificCulture("en-US")));
        // Displays (8) Aug, August
        Console.WriteLine(date1.ToString("(M) MMM, MMMM",
                          CultureInfo.CreateSpecificCulture("nl-NL")));
        // Displays (8) aug, augustus
        Console.WriteLine(date1.ToString("(M) MMM, MMMM",
                          CultureInfo.CreateSpecificCulture("lv-LV")));
        // Displays (8) Aug, augusts
        // </Snippet11>
        Console.WriteLine();
    }

    private static void ShowKSpecifier()
    {
        Console.WriteLine("K format specifier");
        // <Snippet12>
        Console.WriteLine(DateTime.Now.ToString("%K"));
        // Displays -07:00
        Console.WriteLine(DateTime.UtcNow.ToString("%K"));
        // Displays Z
        Console.WriteLine("'{0}'",
                          DateTime.SpecifyKind(DateTime.Now,
                               DateTimeKind.Unspecified).ToString("%K"));
        // Displays ''
        Console.WriteLine(DateTimeOffset.Now.ToString("%K"));
        // Displays -07:00
        Console.WriteLine(DateTimeOffset.UtcNow.ToString("%K"));
        // Displays +00:00
        Console.WriteLine(new DateTimeOffset(2008, 5, 1, 6, 30, 0,
                              new TimeSpan(5, 0, 0)).ToString("%K"));
        // Displays +05:00
        // </Snippet12>
        Console.WriteLine();
    }

    private static void Show_ySpecifier()
    {
        Console.WriteLine("y format specifier");
        // <Snippet13>
        DateTime date1 = new DateTime(1, 12, 1);
        DateTime date2 = new DateTime(2010, 1, 1);
        Console.WriteLine(date1.ToString("%y"));
        // Displays 1
        Console.WriteLine(date1.ToString("yy"));
        // Displays 01
        Console.WriteLine(date1.ToString("yyy"));
        // Displays 001
        Console.WriteLine(date1.ToString("yyyy"));
        // Displays 0001
        Console.WriteLine(date1.ToString("yyyyy"));
        // Displays 00001
        Console.WriteLine(date2.ToString("%y"));
        // Displays 10
        Console.WriteLine(date2.ToString("yy"));
        // Displays 10
        Console.WriteLine(date2.ToString("yyy"));
        // Displays 2010
        Console.WriteLine(date2.ToString("yyyy"));
        // Displays 2010
        Console.WriteLine(date2.ToString("yyyyy"));
        // Displays 02010
        // </Snippet13>
        Console.WriteLine();
    }

    private static void Show_zSpecifier()
    {
        Console.WriteLine("z format specifier");
        // <Snippet14>
        DateTime date1 = DateTime.UtcNow;
        Console.WriteLine(String.Format("{0:%z}, {0:zz}, {0:zzz}",
                          date1));
        // Displays -7, -07, -07:00 on .NET Framework
        // Displays +0, +00, +00:00 on .NET Core and .NET 5+

        DateTimeOffset date2 = new DateTimeOffset(2008, 8, 1, 0, 0, 0,
                                                  new TimeSpan(6, 0, 0));
        Console.WriteLine(String.Format("{0:%z}, {0:zz}, {0:zzz}",
                          date2));
        // Displays +6, +06, +06:00
        // </Snippet14>
        Console.WriteLine();
    }
}
