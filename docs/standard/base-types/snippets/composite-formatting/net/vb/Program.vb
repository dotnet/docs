Imports System

Module Program
    Sub Main(args As String())
        '<basic>
        String.Format("Name = {0}, hours = {1:hh}", "Fred", DateTime.Now)
        '</basic>

        Index()
        Multiple()
        Alignment()
        NowGood()

        Examples_ToString()
        Examples_Currency()
        Examples_Multiple()
        Examples_Bar()
    End Sub

    Sub Index()
        '<index>
        Dim primes As String = String.Format("Four prime numbers: {0}, {1}, {2}, {3}",
                                              2, 3, 5, 7)
        Console.WriteLine(primes)

        'The example displays the following output
        '     Four prime numbers 2, 3, 5, 7
        '</index>
    End Sub

    Sub Multiple()
        '<multiple>
        Dim multiple As String = String.Format("0x{0:X} {0:E} {0:N}",
                                               Int64.MaxValue)
        Console.WriteLine(multiple)

        'The example displays the following output
        '     0x7FFFFFFFFFFFFFFF 9.223372E+018 9,223,372,036,854,775,807.00
        '</multiple>
    End Sub

    Sub Alignment()
        '<alignment>
        Dim names As String() = {"Adam", "Bridgette", "Carla", "Daniel",
                                 "Ebenezer", "Francine", "George"}

        Dim hours As Decimal() = {40, 6.667D, 40.39D, 82,
                                  40.333D, 80, 16.75D}

        Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours")

        For counter = 0 To names.Length - 1
            Console.WriteLine("{0,-20} {1,5:N1}", names(counter), hours(counter))
        Next

        'The example displays the following output
        '     Name                 Hours
        '     
        '     Adam                  40.0
        '     Bridgette              6.7
        '     Carla                 40.4
        '     Daniel                82.0
        '     Ebenezer              40.3
        '     Francine              80.0
        '     George                16.8
        '</alignment>
    End Sub

    Sub NowGood()
        '<now_good>
        Dim value As Integer = 6324
        Dim output As String = String.Format("{{{0:D}}}", value)

        Console.WriteLine(output)

        'The example displays the following output
        '      {6324}
        '</now_good>
    End Sub

    Sub Examples_ToString()
        '<example_tostring>
        Dim formatString1 As String = String.Format("{0:dddd MMMM}", DateTime.Now)
        Dim formatString2 As String = DateTime.Now.ToString("dddd MMMM")
        '</example_tostring>
    End Sub

    Sub Examples_Currency()
        '<example_currency>
        Dim myNumber As Integer = 100
        Console.WriteLine("{0:C}", myNumber)

        'The example displays the following output
        'if en-US Is the current culture:
        '       $100.00
        '</example_currency>
    End Sub

    Sub Examples_Multiple()
        '<example_multiple>
        Dim myName As String = "Fred"
        Console.WriteLine(String.Format("Name = {0}, hours = {1:hh}, minutes = {1:mm}",
                                        myName, DateTime.Now))
        'Depending on the current time, the example displays output Like the following:
        '       Name = Fred, hours = 11, minutes = 30
        '</example_multiple>
    End Sub

    Sub Examples_Bar()
        '<example_bar>
        Dim firstName As String = "Fred"
        Dim lastName As String = "Opals"
        Dim myNumber As Integer = 100

        Dim formatFirstName As String = String.Format("First Name = |{0,10}|", firstName)
        Dim formatLastName As String = String.Format("Last Name =  |{0,10}|", lastName)
        Dim formatPrice As String = String.Format("Price =      |{0,10:C}|", myNumber)
        Console.WriteLine(formatFirstName)
        Console.WriteLine(formatLastName)
        Console.WriteLine(formatPrice)
        Console.WriteLine()

        formatFirstName = String.Format("First Name = |{0,-10}|", firstName)
        formatLastName = String.Format("Last Name =  |{0,-10}|", lastName)
        formatPrice = String.Format("Price =      |{0,-10:C}|", myNumber)
        Console.WriteLine(formatFirstName)
        Console.WriteLine(formatLastName)
        Console.WriteLine(formatPrice)

        'The example displays the following output on a system whose current
        'culture Is en-US:
        '    First Name = |      Fred|
        '    Last Name =  |     Opals|
        '    Price =      |   $100.00|
        '
        '    First Name = |Fred      |
        '    Last Name =  |Opals     |
        '    Price =      |$100.00   |
        '</example_bar>
    End Sub

End Module
