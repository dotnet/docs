// <Snippet2>
using namespace System;

[FlagsAttribute] enum class PhoneService
{
   None = 0,
   LandLine = 1,
   Cell = 2,
   Fax = 4,
   Internet = 8,
   Other = 16
};

void main()
{
   // Define three variables representing the types of phone service
   // in three households.
   PhoneService household1 = PhoneService::LandLine | PhoneService::Cell |
                             PhoneService::Internet;
   PhoneService household2 = PhoneService::None;
   PhoneService household3 = PhoneService::Cell | PhoneService::Internet;

   // Store the variables in an array for ease of access.
   array<PhoneService>^ households = { household1, household2, household3 };

   // Which households have no service?
   for (int ctr = 0; ctr < households->Length; ctr++)
      Console::WriteLine("Household {0} has phone service: {1}",
                         ctr + 1,
                         households[ctr] == PhoneService::None ?
                             "No" : "Yes");
   Console::WriteLine();

   // Which households have cell phone service?
   for (int ctr = 0; ctr < households->Length; ctr++)
      Console::WriteLine("Household {0} has cell phone service: {1}",
                         ctr + 1,
                         (households[ctr] & PhoneService::Cell) == PhoneService::Cell ?
                            "Yes" : "No");
   Console::WriteLine();

   // Which households have cell phones and land lines?
   PhoneService cellAndLand = PhoneService::Cell | PhoneService::LandLine;
   for (int ctr = 0; ctr < households->Length; ctr++)
      Console::WriteLine("Household {0} has cell and land line service: {1}",
                         ctr + 1,
                         (households[ctr] & cellAndLand) == cellAndLand ?
                            "Yes" : "No");
   Console::WriteLine();

   // List all types of service of each household?//
   for (int ctr = 0; ctr < households->Length; ctr++)
      Console::WriteLine("Household {0} has: {1:G}",
                         ctr + 1, households[ctr]);
   Console::WriteLine();
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

