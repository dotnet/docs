using namespace System;

void ShowToString()
{
    // <Snippet10>
    Decimal value = static_cast<Decimal>(123.456);
    Console::WriteLine(value.ToString("C2"));
    // Displays $123.46
    // </Snippet10>
}

void ShowComposite()
{
    // <Snippet11>
    Decimal value = static_cast<Decimal>(123.456);
    Console::WriteLine("Your account balance is {0:C2}.", value);
    // Displays "Your account balance is $123.46."
    // </Snippet11>
}

void ShowCompositeWithAlignment()
{
    // <Snippet12>
    array<Decimal>^ amounts = { static_cast<Decimal>(16305.32), 
                                static_cast<Decimal>(18794.16) };
    Console::WriteLine("   Beginning Balance           Ending Balance");
    Console::WriteLine("   {0,-28:C2}{1,14:C2}", amounts[0], amounts[1]);
    // Displays:
    //        Beginning Balance           Ending Balance
    //        $16,305.32                      $18,794.16      
    // </Snippet12>
}

void main()
{
    ShowToString();
    ShowComposite();
    ShowCompositeWithAlignment();
}
