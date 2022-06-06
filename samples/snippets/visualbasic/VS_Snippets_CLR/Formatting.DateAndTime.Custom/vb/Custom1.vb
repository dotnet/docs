' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
    Public Sub Main()
        Show_dSpecifier()
        Console.WriteLine()
        Show_ddSpecifier()
        Show_dddSpecifier()
        Show_ddddSpecifier()
        Show_fSpecifiers()
        Show_gSpecifier()
        Show_hSpecifier()
        Show_hhSpecifier()
        ShowHSpecifier()
        ShowHHSpecifier()
        ShowMSpecifier()
        ShowKSpecifier()
        Show_ySpecifier()
        Show_zSpecifier()
    End Sub

    Private Sub Show_dSpecifier()
        Console.WriteLine("d format specifier")
        ' <Snippet1>
        Dim date1 As Date = #08/29/2008 7:27:15PM#

        Console.WriteLine(date1.ToString("d, M", _
                          CultureInfo.InvariantCulture))
        ' Displays 29, 8

        Console.WriteLine(date1.ToString("d MMMM", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays 29 August
        Console.WriteLine(date1.ToString("d MMMM", _
                          CultureInfo.CreateSpecificCulture("es-MX")))
        ' Displays 29 agosto                                                
        ' </Snippet1>
        Console.WriteLine()
    End Sub

    Private Sub Show_ddSpecifier()
        Console.WriteLine("dd format specifier")
        ' <Snippet2>
        Dim date1 As Date = #1/2/2008 6:30:15AM#

        Console.WriteLine(date1.ToString("dd, MM", _
                          CultureInfo.InvariantCulture))
        ' 02, 01
        ' </Snippet2>
        Console.WriteLine()
    End Sub

    Private Sub Show_dddSpecifier()
        Console.WriteLine("ddd format specifier")
        ' <Snippet3>
        Dim date1 As Date = #08/29/2008 7:27:15PM#

        Console.WriteLine(date1.ToString("ddd d MMM", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays Fri 29 Aug
        Console.WriteLine(date1.ToString("ddd d MMM", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays ven. 29 août                                                
        ' </Snippet3>
        Console.WriteLine()
    End Sub

    Private Sub Show_ddddSpecifier()
        Console.WriteLine("dddd format specifier")
        ' <Snippet4>
        Dim date1 As Date = #08/29/2008 7:27:15PM#

        Console.WriteLine(date1.ToString("dddd dd MMMM", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays Friday 29 August
        Console.WriteLine(date1.ToString("dddd dd MMMM", _
                          CultureInfo.CreateSpecificCulture("it-IT")))
        ' Displays venerdì 29 agosto                                          
        ' </Snippet4>
        Console.WriteLine()
    End Sub

    Private Sub Show_fSpecifiers()
        Console.WriteLine("f and F format specifiers")
        ' <Snippet5>
        Dim date1 As New Date(2008, 8, 29, 19, 27, 15, 018)
        Dim ci As CultureInfo = CultureInfo.InvariantCulture

        Console.WriteLine(date1.ToString("hh:mm:ss.f", ci))
        ' Displays 07:27:15.0
        Console.WriteLine(date1.ToString("hh:mm:ss.F", ci))
        ' Displays 07:27:15
        Console.WriteLine(date1.ToString("hh:mm:ss.ff", ci))
        ' Displays 07:27:15.01
        Console.WriteLine(date1.ToString("hh:mm:ss.FF", ci))
        ' Displays 07:27:15.01
        Console.WriteLine(date1.ToString("hh:mm:ss.fff", ci))
        ' Displays 07:27:15.018
        Console.WriteLine(date1.ToString("hh:mm:ss.FFF", ci))
        ' Displays 07:27:15.018
        ' </Snippet5>
        Console.WriteLine()
    End Sub

    Private Sub Show_gSpecifier()
        Console.WriteLine("g format specifier")
        ' <Snippet6>
        Dim date1 As Date = #08/04/0070#

        Console.WriteLine(date1.ToString("MM/dd/yyyy g", _
                          CultureInfo.InvariantCulture))
        ' Displays 08/04/0070 A.D.                        
        Console.WriteLine(date1.ToString("MM/dd/yyyy g", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays 08/04/0070 ap. J.-C.
        ' </Snippet6>
        Console.WriteLine()
    End Sub

    Private Sub Show_hSpecifier()
        Console.WriteLine("h format specifier")
        ' <Snippet7>
        Dim date1 As Date
        date1 = #6:09:01PM#
        Console.WriteLine(date1.ToString("h:m:s.F t", _
                          CultureInfo.InvariantCulture))
        ' Displays 6:9:1 P
        Console.WriteLine(date1.ToString("h:m:s.F t", _
                          CultureInfo.CreateSpecificCulture("el-GR")))
        ' Displays 6:9:1 µ                        
        date1 = New Date(2008, 1, 1, 18, 9, 1, 500)
        Console.WriteLine(date1.ToString("h:m:s.F t", _
                          CultureInfo.InvariantCulture))
        ' Displays 6:9:1.5 P
        Console.WriteLine(date1.ToString("h:m:s.F t", _
                          CultureInfo.CreateSpecificCulture("el-GR")))
        ' Displays 6:9:1.5 µ
        ' </Snippet7>
        Console.WriteLine()
    End Sub

    Private Sub Show_hhSpecifier()
        Console.WriteLine("hh format specifier")
        ' <Snippet8>
        Dim date1 As Date
        date1 = #6:09:01PM#
        Console.WriteLine(date1.ToString("hh:mm:ss tt", _
                          CultureInfo.InvariantCulture))
        ' Displays 06:09:01 PM                        
        Console.WriteLine(date1.ToString("hh:mm:ss tt", _
                          CultureInfo.CreateSpecificCulture("hu-HU")))
        ' Displays 06:09:01 du.
        date1 = New Date(2008, 1, 1, 18, 9, 1, 500)
        Console.WriteLine(date1.ToString("hh:mm:ss.ff tt", _
                          CultureInfo.InvariantCulture))
        ' Displays 06:09:01.50 PM                        
        Console.WriteLine(date1.ToString("hh:mm:ss.ff tt", _
                          CultureInfo.CreateSpecificCulture("hu-HU")))
        ' Displays 06:09:01.50 du.
        ' </Snippet8>
        Console.WriteLine()
    End Sub

    Private Sub ShowHSpecifier()
        Console.WriteLine("H format specifier")
        ' <Snippet9>
        Dim date1 As Date = #6:09:01AM#
        Console.WriteLine(date1.ToString("H:mm:ss", _
                          CultureInfo.InvariantCulture))
        ' Displays 6:09:01                        
        ' </Snippet9>
        Console.WriteLine()
    End Sub

    Private Sub ShowHHSpecifier()
        Console.WriteLine("HH format specifier")
        ' <Snippet10>
        Dim date1 As Date = #6:09:01AM#
        Console.WriteLine(date1.ToString("HH:mm:ss", _
                          CultureInfo.InvariantCulture))
        ' Displays 06:09:01                        
        ' </Snippet10>
        Console.WriteLine()
    End Sub

    Private Sub ShowMSpecifier()
        Console.WriteLine("M format specifier")
        ' <Snippet11>
        Dim date1 As Date = #8/18/2008#
        Console.WriteLine(date1.ToString("(M) MMM, MMMM", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays (8) Aug, August
        Console.WriteLine(date1.ToString("(M) MMM, MMMM", _
                          CultureInfo.CreateSpecificCulture("nl-NL")))
        ' Displays (8) aug, augustus
        Console.WriteLine(date1.ToString("(M) MMM, MMMM", _
                          CultureInfo.CreateSpecificCulture("lv-LV")))
        ' Displays (8) Aug, augusts                       
        ' </Snippet11>
        Console.WriteLine()
    End Sub

    Private Sub ShowKSpecifier()
        Console.WriteLine("K format specifier")
        ' <Snippet12>
        Console.WriteLine(Date.Now.ToString("%K"))
        ' Displays -07:00
        Console.WriteLine(Date.UtcNow.ToString("%K"))
        ' Displays Z      
        Console.WriteLine("'{0}'", _
                          Date.SpecifyKind(Date.Now, _
                                           DateTimeKind.Unspecified). _
                          ToString("%K"))
        ' Displays ''      
        Console.WriteLine(DateTimeOffset.Now.ToString("%K"))
        ' Displays -07:00
        Console.WriteLine(DateTimeOffset.UtcNow.ToString("%K"))
        ' Displays +00:00
        Console.WriteLine(New DateTimeOffset(2008, 5, 1, 6, 30, 0, _
                                             New TimeSpan(5, 0, 0)). _
                          ToString("%K"))
        ' Displays +05:00                        
        ' </Snippet12>
        Console.WriteLine()
    End Sub

    Private Sub Show_ySpecifier()
        Console.WriteLine("y format specifier")
        ' <Snippet13>
        Dim date1 As Date = #12/1/0001#
        Dim date2 As Date = #1/1/2010#
        Console.WriteLine(date1.ToString("%y"))
        ' Displays 1
        Console.WriteLine(date1.ToString("yy"))
        ' Displays 01
        Console.WriteLine(date1.ToString("yyy"))
        ' Displays 001
        Console.WriteLine(date1.ToString("yyyy"))
        ' Displays 0001
        Console.WriteLine(date1.ToString("yyyyy"))
        ' Displays 00001
        Console.WriteLine(date2.ToString("%y"))
        ' Displays 10
        Console.WriteLine(date2.ToString("yy"))
        ' Displays 10
        Console.WriteLine(date2.ToString("yyy"))
        ' Displays 2010      
        Console.WriteLine(date2.ToString("yyyy"))
        ' Displays 2010      
        Console.WriteLine(date2.ToString("yyyyy"))
        ' Displays 02010      
        ' </Snippet13>
        Console.WriteLine()
    End Sub

    Private Sub Show_zSpecifier()
        Console.WriteLine("z format specifier")
        ' <Snippet14>
        Dim date1 As Date = Date.UtcNow
        Console.WriteLine(String.Format("{0:%z}, {0:zz}, {0:zzz}", _
                          date1))
        ' Displays -7, -07, -07:00 on .NET Framework
        ' Displays +0, +00, +00:00 on .NET Core and .NET 5+

        Dim date2 As New DateTimeOffset(2008, 8, 1, 0, 0, 0, _
                                        New Timespan(6, 0, 0))
        Console.WriteLine(String.Format("{0:%z}, {0:zz}, {0:zzz}", _
                          date2))
        ' Displays +6, +06, +06:00
        ' </Snippet14>
        Console.WriteLine()
    End Sub
End Module


