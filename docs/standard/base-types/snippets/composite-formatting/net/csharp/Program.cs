
void Index()
{
    // <index>
    string primes = string.Format("Four prime numbers: {0}, {1}, {2}, {3}",
                                  2, 3, 5, 7);
    Console.WriteLine(primes);

    // The example displays the following output:
    //      Four prime numbers: 2, 3, 5, 7
    // </index>
}

void Multiple()
{
    // <multiple>
    string multiple = string.Format("0x{0:X} {0:E} {0:N}",
                                    Int64.MaxValue);
    Console.WriteLine(multiple);

    // The example displays the following output:
    //      0x7FFFFFFFFFFFFFFF 9.223372E+018 9,223,372,036,854,775,807.00
    // </multiple>
}

void Alignment()
{
    // <alignment>
    string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
                       "Ebenezer", "Francine", "George" };
    decimal[] hours = { 40, 6.667m, 40.39m, 82,
                        40.333m, 80, 16.75m };

    Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");

    for (int counter = 0; counter < names.Length; counter++)
        Console.WriteLine("{0,-20} {1,5:N1}", names[counter], hours[counter]);

    // The example displays the following output:
    //      Name                 Hours
    //      
    //      Adam                  40.0
    //      Bridgette              6.7
    //      Carla                 40.4
    //      Daniel                82.0
    //      Ebenezer              40.3
    //      Francine              80.0
    //      George                16.8
    // </alignment>
}

void NowGood()
{
    // <now_good>
    int value = 6324;
    string output = string.Format("{{{0:D}}}", value);
    
    Console.WriteLine(output);
    // The example displays the following output:
    //       {6324}
    // </now_good>
}

void Examples_ToString()
{
    // <example_tostring>
    string formatString1 = string.Format("{0:dddd MMMM}", DateTime.Now);
    string formatString2 = DateTime.Now.ToString("dddd MMMM");
    // </example_tostring>
}

void Examples_Currency()
{
    // <example_currency>
    int myNumber = 100;
    Console.WriteLine("{0:C}", myNumber);

    // The example displays the following output
    // if en-US is the current culture:
    //        $100.00
    // </example_currency>
}

void Examples_Multiple()
{
    // <example_multiple>
    string myName = "Fred";
    Console.WriteLine(string.Format("Name = {0}, hours = {1:hh}, minutes = {1:mm}",
                                    myName, DateTime.Now));

    // Depending on the current time, the example displays output like the following:
    //        Name = Fred, hours = 11, minutes = 30
    // </example_multiple>
}

void Examples_Bar()
{
    // <example_bar>
    string firstName = "Fred";
    string lastName = "Opals";
    int myNumber = 100;

    string formatFirstName = string.Format("First Name = |{0,10}|", firstName);
    string formatLastName = string.Format("Last Name =  |{0,10}|", lastName);
    string formatPrice = string.Format("Price =      |{0,10:C}|", myNumber);
    Console.WriteLine(formatFirstName);
    Console.WriteLine(formatLastName);
    Console.WriteLine(formatPrice);
    Console.WriteLine();

    formatFirstName = string.Format("First Name = |{0,-10}|", firstName);
    formatLastName = string.Format("Last Name =  |{0,-10}|", lastName);
    formatPrice = string.Format("Price =      |{0,-10:C}|", myNumber);
    Console.WriteLine(formatFirstName);
    Console.WriteLine(formatLastName);
    Console.WriteLine(formatPrice);

    // The example displays the following output on a system whose current
    // culture is en-US:
    //     First Name = |      Fred|
    //     Last Name =  |     Opals|
    //     Price =      |   $100.00|
    //
    //     First Name = |Fred      |
    //     Last Name =  |Opals     |
    //     Price =      |$100.00   |
    // </example_bar>
}

// <basic>
string.Format("Name = {0}, hours = {1:hh}", "Fred", DateTime.Now);
// </basic>

Index();
Multiple();
Alignment();
NowGood();

Examples_ToString();
Examples_Currency();
Examples_Multiple();
Examples_Bar();
