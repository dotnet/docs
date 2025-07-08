// <Snippet2>
using System;

[Flags]
public enum PhoneService
{
    None = 0,
    LandLine = 1,
    Cell = 2,
    Fax = 4,
    Internet = 8,
    Other = 16
}

public class Example1
{
    public static void Main()
    {
        // Define three variables representing the types of phone service
        // in three households.
        var household1 = PhoneService.LandLine | PhoneService.Cell |
                         PhoneService.Internet;
        var household2 = PhoneService.None;
        var household3 = PhoneService.Cell | PhoneService.Internet;

        // Store the variables in an array for ease of access.
        PhoneService[] households = { household1, household2, household3 };

        // Which households have no service?
        for (int ctr = 0; ctr < households.Length; ctr++)
            Console.WriteLine($"Household {ctr + 1} has phone service:" +
                $"{(households[ctr] == PhoneService.None ? "No" : "Yes")}");
        Console.WriteLine();

        // Which households have cell phone service?
        for (int ctr = 0; ctr < households.Length; ctr++)
            Console.WriteLine($"Household {ctr + 1} has cell phone service: " +
                $"{((households[ctr] & PhoneService.Cell) == PhoneService.Cell ? "Yes" : "No")}");
        Console.WriteLine();

        // Which households have cell phones and land lines?
        var cellAndLand = PhoneService.Cell | PhoneService.LandLine;
        for (int ctr = 0; ctr < households.Length; ctr++)
            Console.WriteLine($"Household {ctr + 1} has cell and land line service: " +
                $"{((households[ctr] & cellAndLand) == cellAndLand ? "Yes" : "No")}");
        Console.WriteLine();

        // List all types of service of each household?//
        for (int ctr = 0; ctr < households.Length; ctr++)
            Console.WriteLine($"Household {ctr + 1} has: {households[ctr]:G}");
        Console.WriteLine();
    }
}
// The example displays the following output:
//    Household 1 has phone service: Yes
//    Household 2 has phone service: No
//    Household 3 has phone service: Yes
//
//    Household 1 has cell phone service: Yes
//    Household 2 has cell phone service: No
//    Household 3 has cell phone service: Yes
//
//    Household 1 has cell and land line service: Yes
//    Household 2 has cell and land line service: No
//    Household 3 has cell and land line service: No
//
//    Household 1 has: LandLine, Cell, Internet
//    Household 2 has: None
//    Household 3 has: Cell, Internet
// </Snippet2>
