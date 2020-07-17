' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain

    Public Sub Main()
        Console.Clear()
        Console.WRiteLine()
        Console.WriteLine("***d Specifier***")
        Show_dSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***D Specifier***")
        ShowDSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***f Specifier***")
        Show_fSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***F Specifier***")
        ShowFSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***g Specifier***")
        Show_gSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***G Specifier***")
        ShowGSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***M Specifier***")
        ShowMSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***O Specifier***")
        ShowOSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***R Specifier***")
        ShowRSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***S Specifier***")
        ShowSSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***t Specifier***")
        Show_tSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***T Specifier***")
        ShowTSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***u Specifier***")
        Show_uSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***U Specifier***")
        ShowUSpecifier()
        Console.WRiteLine()
        Console.WriteLine("***Y Specifier***")
        ShowYSpecifier()
    End Sub

    Private Sub Show_dSpecifier()
        ' d Format Specifier
        ' <Snippet1>
        Dim date1 As Date = #4/10/2008#
        Console.WriteLine(date1.ToString("d", DateTimeFormatInfo.InvariantInfo))
        ' Displays 04/10/2008
        Console.WriteLine(date1.ToString("d", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays 4/10/2008                       
        Console.WriteLine(date1.ToString("d", _
                          CultureInfo.CreateSpecificCulture("en-NZ")))
        ' Displays 10/04/2008                       
        Console.WriteLine(date1.ToString("d", _
                          CultureInfo.CreateSpecificCulture("de-DE")))
        ' Displays 10.04.2008                       
        ' </Snippet1>
    End Sub

    Private Sub ShowDSpecifier()
        ' D Format Specifier
        ' <Snippet2>
        Dim date1 As Date = #4/10/2008#
        Console.WriteLine(date1.ToString("D", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays Thursday, April 10, 2008                        
        Console.WriteLine(date1.ToString("D", _
                          CultureInfo.CreateSpecificCulture("pt-BR")))
        ' Displays quinta-feira, 10 de abril de 2008                        
        Console.WriteLine(date1.ToString("D", _
                          CultureInfo.CreateSpecificCulture("es-MX")))
        ' Displays jueves, 10 de abril de 2008                        
        ' </Snippet2>
    End Sub

    Private Sub Show_fSpecifier()
        ' f Format Specifier
        ' <Snippet3>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("f", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays Thursday, April 10, 2008 6:30 AM                        
        Console.WriteLine(date1.ToString("f", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays jeudi 10 avril 2008 06:30                       
        ' </Snippet3>   
    End Sub

    Private Sub ShowFSpecifier()
        ' F Format Specifier
        ' <Snippet4>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("F", _
                          CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays Thursday, April 10, 2008 6:30:00 AM                        
        Console.WriteLine(date1.ToString("F", _
                          CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays jeudi 10 avril 2008 06:30:00                       
        ' </Snippet4>   
    End Sub

    Private Sub Show_gSpecifier()
        ' g Format Specifier
        ' <Snippet5>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("g", _
                          DateTimeFormatInfo.InvariantInfo))
        ' Displays 04/10/2008 06:30                      
        Console.WriteLine(date1.ToString("g", _
                          CultureInfo.CreateSpecificCulture("en-us")))
        ' Displays 4/10/2008 6:30 AM                       
        Console.WriteLine(date1.ToString("g", _
                          CultureInfo.CreateSpecificCulture("fr-BE")))
        ' Displays 10/04/2008 6:30                        
        ' </Snippet5>   
    End Sub

    Private Sub ShowGSpecifier()
        ' G Format Specifier
        ' <Snippet6>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("G", _
                          DateTimeFormatInfo.InvariantInfo))
        ' Displays 04/10/2008 06:30:00
        Console.WriteLine(date1.ToString("G", _
                          CultureInfo.CreateSpecificCulture("en-us")))
        ' Displays 4/10/2008 6:30:00 AM                        
        Console.WriteLine(date1.ToString("G", _
                          CultureInfo.CreateSpecificCulture("nl-BE")))
        ' Displays 10/04/2008 6:30:00                       
        ' </Snippet6>   
    End Sub

    Private Sub ShowMSpecifier()
        ' M Format Specifier
        ' <Snippet7>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("m", _
                          CultureInfo.CreateSpecificCulture("en-us")))
        ' Displays April 10                        
        Console.WriteLine(date1.ToString("m", _
                          CultureInfo.CreateSpecificCulture("ms-MY")))
        ' Displays 10 April                       
        ' </Snippet7>   
    End Sub

    Private Sub ShowOSpecifier()
        ' O Format Specifier

        Dim date1 As Date = #4/10/2008 6:30AM#
        Dim dateOffset As New DateTimeOffset(date1, TimeZoneInfo.Local.GetUtcOFfset(date1))
        Console.WriteLine(date1.ToString("o"))
        ' Displays 2008-04-10T06:30:00.0000000                        
        Console.WriteLine(dateOffset.ToString("o"))
        ' Displays 2008-04-10T06:30:00.0000000-07:00                       

    End Sub

    Private Sub ShowRSpecifier()
        ' R Format Specifier
        ' <Snippet9>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Dim dateOffset As New DateTimeOffset(date1, TimeZoneInfo.Local.GetUtcOFfset(date1))
        Console.WriteLine(date1.ToUniversalTime.ToString("r"))
        ' Displays Thu, 10 Apr 2008 13:30:00 GMT                       
        Console.WriteLine(dateOffset.ToUniversalTime.ToString("r"))
        ' Displays Thu, 10 Apr 2008 13:30:00 GMT                        
        ' </Snippet9>   
    End Sub

    Private Sub ShowSSpecifier()
        ' S Format Specifier
        ' <Snippet10>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("s"))
        ' Displays 2008-04-10T06:30:00                       
        ' </Snippet10>   
    End Sub

    Private Sub Show_tSpecifier()
        ' t Format Specifier
        ' <Snippet11>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("t", _
                          CultureInfo.CreateSpecificCulture("en-us")))
        ' Displays 6:30 AM                        
        Console.WriteLine(date1.ToString("t", _
                          CultureInfo.CreateSpecificCulture("es-ES")))
        ' Displays 6:30                      
        ' </Snippet11>   
    End Sub

    Private Sub ShowTSpecifier()
        ' T Format Specifier
        ' <Snippet12>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("T", _
                          CultureInfo.CreateSpecificCulture("en-us")))
        ' Displays 6:30:00 AM                       
        Console.WriteLine(date1.ToString("T", _
                          CultureInfo.CreateSpecificCulture("es-ES")))
        ' Displays 6:30:00                      
        ' </Snippet12>   
    End Sub

    Private Sub Show_uSpecifier()
        ' u Format Specifier
        ' <Snippet13>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToUniversalTime.ToString("u"))
        ' Displays 2008-04-10 13:30:00Z                       
        ' </Snippet13>   
    End Sub

    Private Sub ShowUSpecifier()
        ' U Format Specifier
        ' <Snippet14>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("U", CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays Thursday, April 10, 2008 1:30:00 PM                       
        Console.WriteLine(date1.ToString("U", CultureInfo.CreateSpecificCulture("sv-FI")))
        ' Displays den 10 april 2008 13:30:00                       
        ' </Snippet14>   
    End Sub

    Private Sub ShowYSpecifier()
        ' Y/y Format Specifier
        ' <Snippet15>
        Dim date1 As Date = #4/10/2008 6:30AM#
        Console.WriteLine(date1.ToString("Y", CultureInfo.CreateSpecificCulture("en-US")))
        ' Displays April, 2008                       
        Console.WriteLine(date1.ToString("y", CultureInfo.CreateSpecificCulture("af-ZA")))
        ' Displays April 2008                       
        ' </Snippet15>   
    End Sub
End Module






